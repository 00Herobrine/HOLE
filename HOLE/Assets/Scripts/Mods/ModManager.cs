using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using HOLE.Assets.Scripts.Utils;
using HtmlAgilityPack;
using Newtonsoft.Json;
using SharpCompress.Archives;
using SharpCompress.Archives.SevenZip;
using SharpCompress.Archives.Zip;
using SharpCompress.Common;
using SharpCompress.Readers;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using JsonException = System.Text.Json.JsonException;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace HOLE.Assets.Scripts.Mods
{
    public enum ModType
    {
        None,
        BepInEx,
        User,
    }
    public enum UrlOrigin
    {
        Invalid,
        Direct,
        [Description("dropbox.com")]
        Dropbox,
        [Description("github.com")]
        GitHub,
        [Description("drive.google.com")]
        Google,
        [Description("mediafire.com")]
        Mediafire,
        [Description("sp-tarkov.com")]
        SPT
    }
    public struct SPTModData
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("version")]
        public string version { get; set; }
        [JsonProperty("link")]
        public string link { get; set; }
        [JsonProperty("featured")]
        public string featured { get; set; }
        [JsonProperty("downloads")]
        public string downloads { get; set; }
        [JsonProperty("versionLabel")]
        public string versionLabel { get; set; }
        [JsonProperty("versionColour")]
        public string versionColour { get; set; }
    }
    public struct SPTVersionData
    {
        public int count { get; set; }
        public string colour { get; set; }
    }
    public struct SPTModsData
    {
        public SPTModData[] mod_data { get; set; }
        public string last_updated { get; set; } // time the list was updated server-side
        public Dictionary<string, SPTVersionData> versions { get; set; }
    }

    public struct SPTMod(string id, string url, string name, string sptVersion,
        string author, string teaser, string downloads, string commentCount,
        string reactionCount, bool featured, DateTime lastUpdated, string? imageUrl = null)
    {
        public string Id = id;
        public string Url = url;
        public string Name = name;
        public string SPTVersion = sptVersion;
        public string Author = author;
        public string Teaser = teaser;
        public bool Featured = featured;
        public DateTime LastUpdated = lastUpdated;
        public string? Downloads = downloads;
        public string? CommentCount = commentCount;
        public string? ReactionCount = reactionCount;
        public string? ImageUrl = imageUrl;
        public readonly bool HasImage() => ImageUrl != null || File.Exists(GetIconPath());
        public readonly bool HasIconStored() => File.Exists(GetIconPath()); 
        public readonly string? GetImageName() => ImageUrl != null ? Path.GetFileName(ImageUrl) : null;
        public readonly string? GetIconPath() => GetImageName() != null
            ? Path.Combine(Launcher.Config.Paths.ModIcons, GetImageName()!)
            : null;

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine("SPTMod");
            sb.AppendLine("[");
            sb.AppendLine($"{Id},");
            sb.AppendLine($"{Url},");
            sb.AppendLine($"{Name},");
            sb.AppendLine($"{SPTVersion},");
            sb.AppendLine($"{Author},");
            sb.AppendLine($"{Teaser},");
            sb.AppendLine($"{Downloads},");
            sb.AppendLine($"{CommentCount},");
            sb.AppendLine($"{ReactionCount},");
            sb.AppendLine($"{LastUpdated},");
            sb.AppendLine($"{ImageUrl}(Cached: {HasIconStored()} {GetIconPath()})");
            sb.AppendLine("]");
            return sb.ToString();
        }
    }
    
    public enum SortOrder
    {
        [Description("Descending")]
        DESC,
        [Description("Ascending")]
        ASC,
    }

    public enum SortBy
    {
        Relevance,
        Subject,
        Time,
        Author,
    }
    public struct SortFilter(SortBy sortBy = SortBy.Relevance, SortOrder sortOrder = SortOrder.DESC)
    {
        public SortBy SortBy = sortBy;
        public SortOrder SortOrder = sortOrder;
    }
    
    public struct ModDownload(string filePath)
    {
        public readonly string FilePath = filePath;
        public int Id;
        public string Name;
        public string Version; 
        public long TotalBytes;
        public long CurrentBytes;
        public long LastUpdate;
        public double CurrentDownloadSpeed;
        public double AverageDownloadSpeed;
        public Stream ContentStream;
    }
    
    public static class ModManager
    {
        public const string FikaUrl = "https://github.com/project-fika/";
        public const string FikaWikiUrl = "https://github.com/project-fika/gitbook-wiki";
        public const string FikaClientUrl = "https://github.com/project-fika/Fika-Plugin";
        public const string FikaServerUrl = "https://github.com/project-fika/Fika-Server";
        private const string SPTUrl = "https://hub.sp-tarkov.com/";
        private const string SPTModListBaseUrl = $"{SPTUrl}files/";
        private const string SPTModsJsonUrl = $"{SPTUrl}mods.json";
        private const string SPTModsFileBaseUrl = $"{SPTModListBaseUrl}file/"; // URL to query the main Mod page for dependencies, full description, etc.
        private const string SPTModDownloadBaseUrl = $"{SPTUrl}files/download/";
        private const string BaseDirectGoogleLink = "https://drive.google.com/uc?export=download&id=";
        private const string Pattern = @"var SECURITY_TOKEN = '(.+?)';"; 
        private const string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
        private const string BepInExFolderName = "BepInEx";
        private const string UserFolderName = "user";
        private static readonly string[] AllowedFileTypes = [".rar", ".7z", ".zip", ".dll"];
        
        private static int DownloadBufferSize => Launcher.Config.ModDownloadBufferSize;
        private static int ModCacheRefresh => Launcher.Config.ModCacheRefresh;

        private static SPTModsData? _sptModData;
        public static Action<SPTModsData>? SPTModDataQueried;
        public static int TotalCachedMods { get; private set; }

        #region Downloader
        private static Dictionary<int, ModDownload> _currentDownloads = new(); // Id, ModDownload (maybe I should just iterate through them all instead of having a dictionary)

        public static async void ScheduleDownloadAsync(int modId)
        {
            try
            {
                _currentDownloads ??= new Dictionary<int, ModDownload>();
                ModDownload? download = await DownloadAsync(modId);
                if (download == null) return;
                if (_currentDownloads.TryAdd(modId, download.Value))
                {
                    Logger.Info($"Scheduled download of {download.Value.Name} ({download.Value.Version})");
                }
            }
            catch (Exception e)
            {
                Logger.Warn("Failed to Schedule Mod Download"); // TODO: add this to lang file
            }
        }
        
        #region Queries
        // Queries the basic mods.json list which is super light
        private static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions { WriteIndented = true, IncludeFields = true };
        private static async Task<SPTModsData?> QuerySPTModsJson()
        {
            try
            {
                HttpClient client = new();
                string json = await client.GetStringAsync(SPTModsJsonUrl);
                // Cache mods.json so we don't need to download it each time
                await File.WriteAllTextAsync(Launcher.ModsJsonPath, json);
                return JsonSerializer.Deserialize<SPTModsData>(json, SerializerOptions);
            }
            catch (HttpRequestException ex)
            {
                Logger.Warn($"Failed to download mods.json: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Logger.Warn($"Failed to parse mods.json: {ex.Message}");
            }
            return null;
        }
        
        // Goes through the main SPT page like a normal user
        public static async Task<bool> QuerySPTModList(int pageNumber = 0, SortBy sortField = SortBy.Relevance, SortOrder sortOrder = SortOrder.DESC) 
        {
            string formattedUrl = $"{SPTModListBaseUrl}?pageNo={pageNumber}&sortField={sortField}&sortOrder={sortOrder}";
            HttpClient client = new();
            client.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);
            HttpResponseMessage response = await client.GetAsync(formattedUrl);
            string responseContent = await response.Content.ReadAsStringAsync();
            HtmlDocument document = new();
            document.LoadHtml(responseContent);
            File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "test.html"), responseContent);
            List<SPTMod>? modList = await GetModButtons(document);
            if (modList == null)
            {
                Logger.Warn("Failed to get mod list.");
                return false;
            }
            else
            {
                foreach (var mod in modList)
                {
                    Logger.Info(mod.ToString());
                }
            }
            return true;
        }

        private static async Task<List<SPTMod>?> GetModButtons(HtmlDocument document)
        {
            HtmlNodeCollection? modElements = document.DocumentNode.SelectNodes("//div[contains(@class, 'filebaseFileCard')]");
            if (modElements == null)
            {
                Logger.Warn("modElements == null");
                return null;
            }

            List<SPTMod> modList = new();
            foreach (HtmlNode modNode in modElements)
            {
                string isoString = modNode.SelectSingleNode(".//time[@class='datetime']")
                    ?.GetAttributeValue("datetime", "0L") ?? "0L";
                DateTime dateTime = DateTime.ParseExact(isoString, "yyyy-MM-ddTHH:mm:sszzz", CultureInfo.InvariantCulture);
                SPTMod mod = new()
                {
                    Id = modNode.ParentNode.GetAttributeValue("data-file-id", "").Trim(),
                    Url = modNode.SelectSingleNode(".//a[contains(@class, 'box128')]")?.GetAttributeValue("href", "").Trim() ?? "null",
                    Name = modNode.SelectSingleNode(".//h3[contains(@class, 'filebaseFileSubject')]")?.InnerText.Trim() ?? "null",
                    SPTVersion = modNode.SelectSingleNode(".//ul[contains(@class, 'labelList')]/li[1]")?.InnerText.Trim() ?? "null",
                    Author = modNode.SelectSingleNode(".//ul[contains(@class, 'filebaseFileMetaData')]/li[not(time)]")?.InnerText.Trim() ?? "null",
                    Teaser = modNode.SelectSingleNode(".//div[contains(@class, 'filebaseFileTeaser')]")?.InnerText.Trim() ?? "null",
                    Downloads = modNode.SelectSingleNode(".//span[contains(@class, 'fa-download')]")?.ParentNode.InnerText.Trim() ?? "null",
                    CommentCount = modNode.SelectSingleNode(".//div[contains(@class, 'fa-comments')]")?.ParentNode.InnerText.Trim() ?? "null",
                    //ReactionCount = modNode.SelectNodes(".//div[contains(@class, 'filebaseFileCardReactionCount')]")?.ToString() ?? "null",
                    LastUpdated = dateTime,
                    Featured = modNode.SelectSingleNode(".//span[contains(@class, 'jsLabelFeatured')]") != null,
                    ImageUrl = modNode.SelectSingleNode(".//span[@class='filebaseFileIcon']/img")?.GetAttributeValue("src", "") ?? null,
                };
                modList.Add(mod);
                if(mod.ImageUrl != null) await CacheModIcon(mod.ImageUrl); 
            }
            return modList;
        }

        private static async Task<bool> CacheModIcon(string iconUrl)
        {
            if (!FileManagement.DirectoryCheck(Launcher.Config.Paths.ModIcons) || !iconUrl.Contains(SPTUrl)) 
                return false;
            
            string fileName = Path.GetFileName(iconUrl);
            string filePath = Path.Combine(Launcher.Config.Paths.ModIcons, fileName);
            Logger.Info($"Caching {filePath}");
            if (File.Exists(filePath)) 
                return true;
            try
            {
                using HttpClient client = new();
                client.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);
                HttpResponseMessage response = await client.GetAsync(iconUrl);
                if (response.IsSuccessStatusCode)
                {
                    await using Stream contentStream = await response.Content.ReadAsStreamAsync();
                    await using FileStream fileStream = new(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
                    await contentStream.CopyToAsync(fileStream);
                    return true;
                }
                else return false;
            }
            catch (Exception e)
            {
                Logger.Warn($"Failed to cache mod icon: {e.Message}");
                return false;
            }
        }
        
        // Going through the main page is required to generate a token to submit to the page
        // ModID -> Query Mod Page -> Get DownloadButton -> Get DownloadButtonUrl -> ?Determine Direct or Redirect? -> Query DownloadButton URL -> Determine Direct or Redirect -> Get Target URL
        private static async Task<HttpResponseMessage?> QuerySPTModPage(HttpClient httpClient, int modId)
        {
            try
            {
                string modUrl = $"{SPTModsFileBaseUrl}/{modId}";
                HttpResponseMessage response = await httpClient.GetAsync(modUrl);
                return response;
            }
            catch (HttpRequestException ex)
            {
                Logger.Warn($"Failed to Query SPT mod's page.\n'{ex.Message}'");
            }
            return null;
        }
        
        private static async Task<ModDownload?> DownloadAsync(int modId)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage? response = await QuerySPTModPage(client, modId);
            if (response == null) 
                return null;
            
            string responseContent = await response.Content.ReadAsStringAsync();
            HtmlDocument document = new();
            document.LoadHtml(responseContent);
            HtmlNode? downloadButton = await GetDownloadButton(document);
            if (downloadButton == null) 
                return null;
            
            string versionUrl = downloadButton.Attributes["href"].Value.TrimEnd('/');
            string versionId = versionUrl.Split('/').Last();
            Match tokenMatch = Regex.Match(responseContent, Pattern);
            string? token = tokenMatch.Success ? tokenMatch.Groups[1].Value : null;
            if (token == null)
            {
                Logger.Warn("Failed to find token.");
                return null;
            }
            return await QueryDownloadAsync(client, versionUrl, versionId, token);
        }

        private static async Task<bool> ScheduleDownload(ModDownload mod, Stream contentStream, byte[] buffer)
        {
            try
            {
                await using FileStream fileStream = new FileStream(mod.FilePath, FileMode.Create, FileAccess.Write, FileShare.None);
                int bytesRead;
                DateTime startTime = DateTime.Now;
                while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    await fileStream.WriteAsync(buffer, 0, bytesRead);
                    mod.CurrentBytes += bytesRead;
                    mod.CurrentDownloadSpeed = bytesRead;
                    var totalElapsed = DateTime.Now - startTime;
                    if (totalElapsed.TotalSeconds > 0)
                    {
                        mod.AverageDownloadSpeed = mod.CurrentBytes / totalElapsed.TotalSeconds;
                    }

                    if (totalElapsed.TotalSeconds % 2 == 0)
                    {
                        Logger.Info($"Current: {mod.CurrentDownloadSpeed} Average: {mod.AverageDownloadSpeed}");
                        
                    } 
                }
                var finalElapsed = DateTime.Now - startTime;
                if (finalElapsed.TotalSeconds > 0)
                {
                    mod.AverageDownloadSpeed = mod.CurrentBytes / finalElapsed.TotalSeconds;
                    //mod.CurrentDownloadSpeed = mod.AverageDownloadSpeed;
                }
            }
            catch(Exception e)
            {
                Logger.Warn($"Failed to schedule download: {e.Message}");
                return false;
            }
            return await Task.FromResult(true);
        }
        
        private static async Task<ModDownload?> QueryDownloadAsync(HttpClient client, string versionUrl, string versionId, string token)
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);
            HttpContent content = new FormUrlEncodedContent([
                new KeyValuePair<string, string>("confirm", "1"),
                new KeyValuePair<string, string>("purchase", "0"),
                new KeyValuePair<string, string>("versionID", versionId),
                new KeyValuePair<string, string>("t", token)
            ]);
            HttpResponseMessage response = await client.PostAsync(versionUrl, content);
            string responseContent = await response.Content.ReadAsStringAsync();
            
            // Possible Direct File from SPT redirect
            ModDownload? modDownload = await GetFileFromResponseAsync(response);
            if (modDownload != null)
                return modDownload;
            
            HtmlDocument document = new();
            document.LoadHtml(responseContent);
            string? downloadUrl = await GetDownloadLink(document);
            if(downloadUrl != null) FormatUrl(ref downloadUrl);

            response = await client.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead);
            // Possible Direct File from Download Page
            Logger.Info($"modDownload {modDownload != null}");
            //modDownload.stream = GetContentStream(response);
            modDownload ??= await GetFileFromResponseAsync(response);
            if (modDownload != null)
                await ScheduleDownload(modDownload.Value, await response.Content.ReadAsStreamAsync(), new byte[DownloadBufferSize]);
            return modDownload;
        }
        #endregion
        
        public static async Task<SPTModsData> GetSPTModDataAsync(bool forceQuery = false)
        {
            if(forceQuery) _sptModData = null;
            else if(File.Exists(Launcher.ModsJsonPath))
            {
                DateTime lastWrite = File.GetLastWriteTime(Launcher.ModsJsonPath);
                TimeSpan span = DateTime.Now.Subtract(lastWrite);
                if (span.TotalSeconds < ModCacheRefresh)
                {
                    string modsJson = await File.ReadAllTextAsync(Launcher.ModsJsonPath);
                    _sptModData = JsonSerializer.Deserialize<SPTModsData>(modsJson);
                }
            }
            _sptModData ??= await QuerySPTModsJson();
            SPTModDataQueried?.Invoke((SPTModsData)_sptModData!);
            return (SPTModsData)_sptModData!;
        }
        
        private static void FormatUrl(ref string url) // Changes URL to known ways of direct downloading
        {
            UrlOrigin origin = DetermineOrigin(url);
            Debug.WriteLine($"Origin: {origin}");
            switch (origin)
            {
                case UrlOrigin.Dropbox:
                    url = url.Replace("dl=0", "dl=1", StringComparison.OrdinalIgnoreCase).Replace("amp;", "", StringComparison.OrdinalIgnoreCase);
                    break;
                case UrlOrigin.GitHub:
                    
                    break;
                case UrlOrigin.Google:
                    if (url.Contains("export=download") && url.Contains("id=")) return; // some people already have direct links
                    string googleId = url.Split("d/")[1].Split("/")[0];
                    url = BaseDirectGoogleLink + googleId;
                    break;
                case UrlOrigin.Mediafire:
                    break;
            }
        }

        private static UrlOrigin DetermineOrigin(string url)
        {
            UrlOrigin origin = UrlOrigin.Invalid;
            string websiteName = url.Replace("https://", "", StringComparison.OrdinalIgnoreCase).Replace("http://", "", StringComparison.OrdinalIgnoreCase).Split("/").First();
            foreach (UrlOrigin urlOrigin in Enum.GetValues(typeof(UrlOrigin)))
            {
                if (!websiteName.Equals(urlOrigin.GetDescription(), StringComparison.OrdinalIgnoreCase)) 
                    continue;
                origin = urlOrigin;
                break;
            }
            return origin;
        }

        private static async Task<ModDownload?> GetFileFromResponseAsync(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode) 
                return null;
            if (!await HasDirectFileFromResponse(response)) 
                return null;
            
            string? fileName = await GetFileNameFromResponse(response);
            if (fileName == null) 
                return null;
            
            string extension = Path.GetExtension(fileName);
            if (!IsAllowedFileType(extension.TrimEnd()))
            {
                Logger.Warn($"Invalid file type: {extension}");
                return null;
            }

            ModDownload modDownload = new($"{Launcher.Config.Paths.Mods}{fileName}")
            {
                TotalBytes = response.Content.Headers.ContentLength ?? 0L,
                CurrentBytes = 0L,
                Id = 0,
                Name = fileName,
                Version = ""
            };
            
            return modDownload;
        }
        private static Task<string?> GetFileNameFromResponse(HttpResponseMessage response) 
            => Task.FromResult(response.Content.Headers.ContentDisposition?.FileName ?? null);
        private static Task<HtmlNode?> GetDownloadButton(HtmlDocument document)
            => Task.FromResult(document.DocumentNode.SelectSingleNode("//a[@class='button buttonPrimary externalURL']"));
        private static Task<string?> GetDownloadLink(HtmlDocument document) => 
            Task.FromResult(document.DocumentNode.SelectSingleNode("//a[starts-with(@class, 'button buttonPrimary')]")?.Attributes["href"].Value);
        private static Task<bool> HasDirectFileFromResponse(HttpResponseMessage response) => 
            Task.FromResult(response.Content.Headers.ContentDisposition != null);
        #endregion
        
        #region Extractor
        public static async Task<bool> ExtractModAsync(string downloadedModFile)
        {
            // open mod.
            // check through all entries for a BepInEx folder and/or a user folder
            // if properly formatted, extract to the mods directory.
            // else need to manually determine BepInEx and user Files.
            // I want to start enforcing people to add a "dependencies" file in the root archive
            // which allows specifying what mods to download by their id
            if (!File.Exists(downloadedModFile)) 
                return false;
                    
            string fileType = Path.GetExtension(downloadedModFile);
            if (!IsAllowedFileType(fileType)) 
                return false;

            return fileType switch
            {
                ".dll" => await ExtractDllModAsync(downloadedModFile),
                ".zip" => await ExtractArchiveModAsync(downloadedModFile),
                ".rar" => await ExtractRarModAsync(downloadedModFile),
                ".7z" => await Extract7zModAsync(downloadedModFile),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private static async Task<bool> ExtractDllModAsync(string localModFile)
        {
            if (!File.Exists(localModFile))
                return false;
            
            File.Move(localModFile, Path.Combine(Launcher.Config.Paths.Mods, Path.GetFileName(localModFile)));
            return await Task.FromResult(true);
        }
        private static async Task<bool> ExtractZipModAsync(string localModFile) => await ExtractArchiveModAsync(localModFile);
        private static async Task<bool> Extract7zModAsync(string localModFile) => await ExtractArchiveModAsync(localModFile);
        private static async Task<bool> ExtractRarModAsync(string localModFile) => await ExtractArchiveModAsync(localModFile);
        private static async Task<bool> ExtractArchiveModAsync(string localModFile)
        {
            if (!File.Exists(localModFile)) 
                return false;
            
            if (!FileManagement.DirectoryCheck(Launcher.Config.Paths.Mods))
                return false;
            
            string modFileName = Path.GetFileNameWithoutExtension(localModFile);
            string destinationPath = Path.Combine(Launcher.Config.Paths.Mods, modFileName);
            if (!FileManagement.DirectoryCheck(destinationPath))
                return false;
            try
            {
                IArchive archive = ArchiveFactory.Open(localModFile);
                foreach (IArchiveEntry entry in archive.Entries)
                {
                    if (string.IsNullOrEmpty(entry.Key)) 
                        continue;

                    string rootFolderName = entry.Key.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).First();
                    string entryType = Path.GetExtension(entry.Key);
                    bool isDll = entryType.Equals(".dll", StringComparison.OrdinalIgnoreCase);
                    Logger.Info($"entryKey: {entry.Key} RootFolder: {rootFolderName} isDll: {isDll}");
                    if (rootFolderName.Equals(BepInExFolderName, StringComparison.OrdinalIgnoreCase) 
                        || rootFolderName.Equals(UserFolderName, StringComparison.OrdinalIgnoreCase))
                    {
                        Logger.Info($"Destination: {destinationPath}");
                        entry.WriteToDirectory(destinationPath, new ExtractionOptions()
                        {
                            Overwrite = true,
                            ExtractFullPath = true,
                            PreserveAttributes = true,
                            PreserveFileTime = false,
                        });
                    }
                    else if (isDll)
                    {
                        destinationPath = Path.Combine(Launcher.Config.Paths.Mods, modFileName, "BepInEx", "plugins");
                        FileManagement.DirectoryCheck(destinationPath);
                        entry.WriteToDirectory(destinationPath, new ExtractionOptions()
                        {
                            Overwrite = true,
                            ExtractFullPath = false,
                            PreserveAttributes = true,
                            PreserveFileTime = false,
                        });
                    }
                }
            } catch (Exception e)
            {
                Logger.Warn($"Failed to Install ZIP Mod.\n{e.Message}");
            }
            return await Task.FromResult(false);
        }
        #endregion
        
        #region Installer
        private static async Task<bool> InstallDllModAsync(string localModFile, Instance instance, bool createJunction = true)
        {
            try
            {
                if (createJunction)
                {
                    FileManagement.CreateJunction(localModFile, instance.BepInExPath);
                }
            }
            catch (Exception e)
            {
                Logger.Warn($"Failed to Install DLL Mod.\n{e.Message}");
            }
            return await Task.FromResult(false);
        }
        #endregion
        
        #region Uninstaller

        public static async Task<bool> UninstallModAsync(string localModFile)
        {
            return await Task.FromResult(false);
        }
        #endregion

        private static bool IsAllowedFileType(string extension) 
            => AllowedFileTypes.Contains(extension);
    }
}

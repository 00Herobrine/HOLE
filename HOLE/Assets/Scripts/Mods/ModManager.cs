using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using HOLE.Assets.Scripts.Utils;
using HtmlAgilityPack;
using Newtonsoft.Json;
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
        Unsupported,
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

    public struct SPTMod
    {
        public string Url;
        public string Name;
        public string SPTVersion;
        public string Author;
        public string Teaser;
        public string Downloads;
        public string ReactionCount;
        public DateTime LastUpdated;
        // Need to Retrieve
        public string? Version;
        public string? Description;
        public string? ImageUrl;
        public string? IconPath;

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine("SPTMod");
            sb.AppendLine("[");
            sb.AppendLine($"{Url},");
            sb.AppendLine($"{Name},");
            sb.AppendLine($"{SPTVersion},");
            sb.AppendLine($"{Author},");
            sb.AppendLine($"{Teaser},");
            sb.AppendLine($"{Downloads},");
            sb.AppendLine($"{ReactionCount},");
            sb.AppendLine($"{LastUpdated}");
            sb.AppendLine("]");
            return sb.ToString();
        }
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

    public struct ModDownloadQuery(SPTModData modData)
    {
        public string Id = modData.id;
        public string Name;
        public string Version;
        public string Author;
        public string Description;
        public long TotalBytes;
    }
    public static class ModManager
    {
        private const string SPTUrl = "https://hub.sp-tarkov.com/";
        private const string SPTModListBaseUrl = $"{SPTUrl}files/";
        private const string SPTModsJsonUrl = $"{SPTUrl}mods.json";
        private const string SPTModsFileBaseUrl = $"{SPTModListBaseUrl}file/"; // URL to query the main Mod page for dependencies, full description, etc.
        private const string SPTModDownloadBaseUrl = $"{SPTUrl}files/download/";
        private const string BaseDirectGoogleLink = "https://drive.google.com/uc?export=download&id=";
        private const string Pattern = @"var SECURITY_TOKEN = '(.+?)';"; 
        private const string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
        private static readonly string[] AllowedFileTypes = [".rar", ".7z", ".zip", ".dll"];
        
        private static int DownloadBufferSize => Launcher.Config.ModDownloadBufferSize;
        private static int ModCacheRefresh => Launcher.Config.ModCacheRefresh;

        private static SPTModsData? _sptModData;
        public static Action<SPTModsData>? SPTModDataQueried;
        public static int TotalCachedMods { get; private set; }

        #region Downloader
        private static Dictionary<int, ModDownload> _currentDownloads; // Id, ModDownload (maybe I should just iterate through them all instead of having a dictionary)

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
                SPTMod mod = new()
                {
                    Name = modNode.SelectSingleNode("//div[contains(@class, 'filebaseFileSubject')]")?.InnerText ?? "",
                    SPTVersion = modNode.SelectSingleNode("//div[contains(@class, 'filebaseFileCardVersion')]")?.InnerText ?? "",
                    Author = modNode.SelectSingleNode("//div[contains(@class, 'filebaseFileCardAuthor')]")?.InnerText ?? "",
                    Teaser = modNode.SelectSingleNode("//div[contains(@class, 'filebaseFileTeaser')]")?.InnerText ?? "",
                    Url = modNode.SelectSingleNode("//a[contains(@class, 'box128')]")?.Attributes["href"].Value ?? "",
                    Downloads = modNode.SelectSingleNode("//span[contains(@class, 'fa-downloads')]")?.InnerText ?? "",
                    ReactionCount = modNode.SelectSingleNode("//div[contains(@class, 'filebaseFileCardReactionCount')]")?.InnerText ?? "",
                    LastUpdated = DateTime.Now,
                };
                modList.Add(mod);
            }
            return modList;
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
            if (!IsValidFileType(extension.TrimEnd()))
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
        
        #region Installer
        public static async Task<bool> InstallModAsync(string localModFile)
        {
            
            return await Task.FromResult(false);
        }
        #endregion
        
        #region Uninstaller

        public static async Task<bool> UninstallModAsync(string localModFile)
        {
            return await Task.FromResult(false);
        }
        #endregion

        private static bool IsValidFileType(string extension) 
            => AllowedFileTypes.Contains(extension);
    }
}

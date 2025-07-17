using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;
using HOLE.Assets.Scripts.Utils;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace HOLE.Assets.Scripts
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
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string version { get; set; }
        public string link { get; set; }
        public string featured { get; set; }
        public string downloads { get; set; }
        public string versionLabel { get; set; }
        public string versionColour { get; set; }
    }
    public struct SPTVersionData
    {
        public int count { get; set; }
        public string colour { get; set; }
    }
    public struct SPTModsQuery
    {
        public SPTModData[] mod_data { get; set; }
        public string last_updated { get; set; } // time the list was updated server-side
        public Dictionary<string, SPTVersionData> versions { get; set; }
    }
    public struct ModDownload
    {
        public int modId;
        public string modName;
        public string modVersion; 
        public long currentBytes;
        public long totalBytes;
    }
    public static class ModManager
    {
        private const string SPTUrl = "https://hub.sp-tarkov.com/";
        private const string SPTModsListUrl = "https://hub.sp-tarkov.com/mods.json";
        private const string SPTModsFileBaseUrl = "https://hub.sp-tarkov.com/files/file/"; // URL to query the main Mod page for dependencies, full description, etc
        private const string SPTModDownloadBaseUrl = "https://hub.sp-tarkov.com/files/download/";
        private static readonly string[] AllowedFileTypes = [".rar", ".7z", ".zip", ".dll"];
        
        private static int DownloadBufferSize => Launcher.Config.ModDownloadBufferSize;
        private static int ModCacheRefresh => Launcher.Config.ModCacheRefresh;

        private static SPTModsQuery? _sptModData;
        public static Action<SPTModsQuery>? SPTModDataQueried;
        public static int TotalCachedMods { get; private set; }

        #region Queries
        // Queries the basic mods.json list which is super light
        private static async Task<SPTModsQuery?> QuerySPTModsList()
        {
            try
            {
                HttpClient client = new();
                string json = await client.GetStringAsync(SPTModsListUrl);
                Debug.WriteLine(json);
                // Cache mods.json so we don't need to download it each time
                await File.WriteAllTextAsync(Launcher.ModsJsonPath, json);
                return JsonSerializer.Deserialize<SPTModsQuery>(json);
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"Failed to download mods.json: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Debug.WriteLine($"Failed to parse mods.json: {ex.Message}");
            }
            return null;
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
                Logger.Log(ex.Message);
            }
            return null;
        }
        
        public static async Task<ModDownload?> DownloadAsync(int modId)
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
                Debug.WriteLine("Failed to find token.");
                return null;
            }
            
            return await QueryDownloadAsync(client, versionUrl, versionId, token);
        }
        
        private const string Pattern = @"var SECURITY_TOKEN = '(.+?)';"; 
        private const string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
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
            
            // Direct file download check from SPT redirect
            ModDownload? modDownload = await GetFileFromResponseAsync(response);
            if (modDownload != null)
            {
                return modDownload;
            } 
            
            HtmlDocument document = new();
            document.LoadHtml(responseContent);
            string? downloadUrl = await GetDownloadLink(document);
            if(downloadUrl != null) FormatUrl(ref downloadUrl);

            response = await client.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead);
            // File download check from the download page
            modDownload ??= await GetFileFromResponseAsync(response);
            
            Debug.WriteLine($"===Node values===\nURL:{versionUrl}\nID:{versionId}\nDownload:{downloadUrl}\nFile:{modDownload != null}");
            return modDownload;
        }
        #endregion

        private const string BaseDirectGoogleLinke = "https://drive.google.com/uc?export=download&id=";
        private static void FormatUrl(ref string url)
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
                    url = BaseDirectGoogleLinke + googleId;
                    break;
                case UrlOrigin.Mediafire:
                    break;
            }
        }

        private static UrlOrigin DetermineOrigin(string url)
        {
            UrlOrigin origin = UrlOrigin.Invalid;
            string websiteName = url.Split("/").First();
            Debug.WriteLine($"Website: {websiteName}");
            foreach (UrlOrigin urlOrigin in Enum.GetValues(typeof(UrlOrigin)))
            {
                if (!websiteName.Equals(urlOrigin.GetDescription(), StringComparison.OrdinalIgnoreCase)) 
                    continue;
                origin = urlOrigin;
                break;
            }
            return origin;
        }

        public static async Task<SPTModsQuery> GetSPTModQueryAsync()
        {
            if(File.Exists(Launcher.ModsJsonPath))
            {
                DateTime lastWrite = File.GetLastWriteTime(Launcher.ModsJsonPath);
                TimeSpan span = DateTime.Now.Subtract(lastWrite);
                if (span.TotalSeconds < ModCacheRefresh)
                {
                    string modsJson = await File.ReadAllTextAsync(Launcher.ModsJsonPath);
                    _sptModData = JsonSerializer.Deserialize<SPTModsQuery>(modsJson);
                }
            }
            _sptModData ??= await QuerySPTModsList();
            SPTModDataQueried?.Invoke((SPTModsQuery)_sptModData!);
            return (SPTModsQuery)_sptModData!;
        }
        
        public static async Task<HtmlNode?> GetDownloadButton(HtmlDocument document)
        {
            HtmlNode? node = document.DocumentNode.SelectSingleNode("//a[@class='button buttonPrimary externalURL']");
            return node;
        }

        private static async Task<string?> GetDownloadLink(HtmlDocument document)
        {
            HtmlNode? node = document.DocumentNode.SelectSingleNode("//a[starts-with(@class, 'button buttonPrimary')]");
            if(node != null) return node.Attributes["href"].Value;
            return null;
        }

        public static Task<bool> HasDirectFile(HttpResponseMessage response)
        {
            return Task.FromResult(response.Content.Headers.ContentDisposition != null);
        }

        private static async Task<ModDownload?> GetFileFromResponseAsync(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode) 
                return null;
            
            string? fileName = await GetFileNameFromResponseAsync(response);
            if (fileName == null) 
                return null;
            
            string extension = Path.GetExtension(fileName);
            if (!IsValidFileType(extension.TrimEnd()))
            {
                Debug.WriteLine($"Invalid file type: {extension}");
                return null;
            }

            ModDownload modDownload = new()
            {
                totalBytes = response.Content.Headers.ContentLength ?? 0L,
                currentBytes = 0L,
                modId = 0,
                modName = "",
                modVersion = ""
            };
            
            return modDownload;
        }

        private static Task<string?> GetFileNameFromResponseAsync(HttpResponseMessage response) 
            => Task.FromResult(response.Content.Headers.ContentDisposition?.FileName ?? null);
        private static bool IsValidFileType(string extension) 
            => AllowedFileTypes.Contains(extension);
        
    }
}

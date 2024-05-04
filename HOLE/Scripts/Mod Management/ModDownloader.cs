using SortOrder = HOLE.Scripts.Mod_Management.SortOrder;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using HOLE.Scripts.Misc;
using HOLE.Scripts.Mod_Management;
using System.Text.Json;

namespace HOLE.Scripts
{
    public static class ModDownloader
    {
        public static int PageNumber { get; private set; } = 1;
        public static SortField SortField { get; private set; } = SortField.NEWEST;
        public static SortOrder SortOrder { get; private set; } = SortOrder.ASCENDING;
        public static int ExpirationTime { get; private set; } = 30;
        public static string SPT_PAGE_FILTERS =>
            $"{PageNumber}" +
            $"&sortField={SortOrder.GetDisplayNameAttribute()?.Value ?? "time"}" +
            $"&sortOrder={SortOrder.GetDisplayNameAttribute()?.Value ?? "DESC"}";
        #region Base URLS
        public const string SPT_BASE_URL = "https://hub.sp-tarkov.com/files/";
        public const string SPT_MODS_URL = "https://hub.sp-tarkov.com/mods.json";
        public static string BASE_SPT_PAGE_URL => $"https://hub.sp-tarkov.com/files/?pageNo={SPT_PAGE_FILTERS}";
        public const string BASE_GOOGLE_URL = "https://drive.google.com/";
        public const string BASE_MEDIAFIRE_URL = "https://mediafire.com";

        public static readonly string ModsJsonPath = Path.Combine(Settings.DownloadPath, "mods.json");
        public static readonly JsonSerializerOptions options = new() { WriteIndented = true };
        #endregion
        public static HttpClient? Client { get; private set; }
        public static async Task<HttpClient> CreateClient()
        {
            await Task.Delay(0);
            return new HttpClient();
        }
        public static async Task Download()
        {
            Client ??= await CreateClient();

        }
        public static void QueryNextPage()
        {
            PageNumber++;
            Task.Run(async () =>
            {
                await QueryPage(PageNumber);
            });
        }
        public static async Task<BasicModDownload[]> QueryBasicModDownloads()
        {
            Client ??= await CreateClient();
            Logger.Log($"Querying {SPT_MODS_URL}");
            HttpResponseMessage response = await Client.GetAsync(SPT_MODS_URL);
            string body = await response.Content.ReadAsStringAsync();
            Logger.Log($"Got repsonse!\n{body}");
            BasicModDownload[] downloads = JsonSerializer.Deserialize<BasicModDownload[]>(body) ?? [];
            SaveBasicModsConfig(new BasicModsConfig() { Downloads = downloads, Generated = DateTime.Now });
            Logger.Log($"Queried {downloads.Length} BasicMods");
            return downloads;
        }

        private static async void SaveBasicModsConfig(BasicModsConfig modsConfig)
        {
            await File.WriteAllTextAsync(ModsJsonPath, JsonSerializer.Serialize(modsConfig, options));
            Logger.Log($"Saved to {ModsJsonPath}");
        }
        public static async Task QueryPage(int pageNumber)
        {
            PageNumber = pageNumber;
            Client ??= await CreateClient();
            HttpResponseMessage response = await Client.GetAsync(SPT_BASE_URL);
            string body = await response.Content.ReadAsStringAsync();
            HtmlDocument htmlDoc = new();
            htmlDoc.LoadHtml(body);
            //ScrapeModButtons(htmlDoc);
        }
    }
    public enum DownloadSource { DIRECT, DROPBOX, GITHUB, GOOGLE, MEDIAFIRE, MEGA, SPT }
    public struct BasicModsConfig
    {
        public BasicModsConfig()
        {
            Downloads = [];
            if (Generated == null) Generated = DateTime.Now;
        }
        public DateTime? Generated { get; set; }
        public BasicModDownload[] Downloads { get; set; }
    }
    public struct BasicModDownload
    {
        public string name { get; set; }
        public string description { get; set; }
        public string version { get; set; }
        public string link { get; set; }
        public int featured { get; set; }
        public int downloads { get; set; }
    }
    public struct ModDownload
    {
        public string URL { get; private set; }
        public ModDownload(string URL)
        {
            this.URL = URL;
        }
    }
}

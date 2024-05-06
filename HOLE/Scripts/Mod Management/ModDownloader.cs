using SortOrder = HOLE.Scripts.Mod_Management.SortOrder;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using HOLE.Scripts.Misc;
using HOLE.Scripts.Mod_Management;
using System.Text.Json;
using HtmlAgilityPack;
using System.Net.Http.Headers;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace HOLE.Scripts
{
    public static class ModDownloader
    {
        public static int PageNumber { get; private set; } = 1;
        public static SortField SortField { get; private set; } = SortField.NEWEST;
        public static SortOrder SortOrder { get; private set; } = SortOrder.ASCENDING;
        public static int ExpirationTime { get; private set; } = 120;
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
        #endregion
        public static readonly string ModsJsonPath = Path.Combine(Settings.DownloadPath, "mods.json");
        public static readonly JsonSerializerOptions options = new() { WriteIndented = true };
        public static HttpClient? Client { get; private set; }
        public static ConcurrentQueue<ModDownload> DownloadQueue { get; private set; } = new();
        public static async Task<HttpClient> GetCreateClient() => Client ??= await CreateClient();
        public static async Task<HttpResponseMessage> QueryPage(string URL) => await HttpUtils.QueryPage(await GetCreateClient(), URL);
        public static async Task<HttpClient> CreateClient()
        {
            await Task.Delay(0);
            HttpClient client = new();
            client.DefaultRequestHeaders.Add("User-Agent", Settings.USER_AGENT);
            return client;
        }

        #region Fancy
        public static void QueryNextPage()
        {
            PageNumber++;
            Task.Run(async () =>
            {
                await QueryMods(PageNumber);
            });
        }
        public static async Task<ModCard[]> QueryMods(int pageNumber)
        {
            PageNumber = pageNumber;
            Client ??= await CreateClient();
            Logger.Log($"Querying {SPT_BASE_URL}");
            HttpResponseMessage response = await Client.GetAsync(SPT_BASE_URL);
            string body = await response.Content.ReadAsStringAsync();
            Logger.Log($"Got response from {SPT_BASE_URL}");
            HtmlDocument htmlDoc = new();
            htmlDoc.LoadHtml(body);
            await File.WriteAllTextAsync(Path.Combine(Settings.DownloadPath, "SPTMods.html"), body);
            return GetModCards(htmlDoc);
        }
        public static ModCard[] GetModCards(HtmlDocument html)
        {
            HtmlNodeCollection fileCards = GetFileCards(html);
            Logger.Log($"Got {fileCards.Count} ModCards from {html.DocumentNode.Name}.");
            ModCard[] modCards = new ModCard[fileCards.Count];
            for (int i = 0; i < modCards.Length; i++)
            {
                Logger.Log("Creating ModFileCard for " + i);
                Logger.Log(modCards[i].link);
                modCards[i] = new ModCard(fileCards[i]);
            }
            return modCards;
        }
        public static async Task CacheImage(ModCard modCard)
        {
            if (modCard.ImageURL == null || modCard.ImagePath == null) return;
            try
            {
                HttpResponseMessage response = await QueryPage(modCard.ImageURL);
                response.EnsureSuccessStatusCode();
                Stream imageStream = await response.Content.ReadAsStreamAsync();
                FileStream fileStream = new(modCard.ImagePath, FileMode.Create);
                await imageStream.CopyToAsync(fileStream);
                Logger.Log($"Cached {modCard.ImageName} for {modCard.name}");
            } catch (Exception ex) { Logger.Log(ex.Message); }
        }
        public static HtmlNodeCollection GetFileCards(HtmlDocument html) => html.DocumentNode.SelectNodes("//div[@class='filebaseFileCard new']");
        #endregion

        #region Basic
        public static async Task<BasicModsConfig> QueryBasicModDownloads()
        {
            Client ??= await CreateClient();
            Logger.Log($"Querying {SPT_MODS_URL}");
            HttpResponseMessage response = await Client.GetAsync(SPT_MODS_URL);
            string body = await response.Content.ReadAsStringAsync();
            Logger.Log($"Got repsonse!\n{body}");
            BasicModsConfig modData = JsonSerializer.Deserialize<BasicModsConfig>(body);
            SaveBasicModsConfig(modData);
            Logger.Log($"Queried {modData.mod_data.Length} BasicMods");
            return modData;
        }
        private static async void SaveBasicModsConfig(BasicModsConfig modsConfig)
        {
            await File.WriteAllTextAsync(ModsJsonPath, JsonSerializer.Serialize(modsConfig, options));
            Logger.Log($"Saved to {ModsJsonPath}");
        }
        #endregion

        #region Download
        internal static async Task<List<ModDownload>> QueueDownloads(params string[] links) // returns the mods queued
        {
            List<ModDownload> queued = [];
            foreach (string link in links)
            {
                ModDownload download = new(link);
                if (await Queue(download)) queued.Add(download);
            }
            DownloadModsAsync(DownloadQueue);
            return queued;
        }
        private static async Task<bool> Queue(ModDownload download) // returns true if not in queue
        {
            await Task.Delay(0);
            foreach (ModDownload queuedDownload in DownloadQueue)
                if (string.Equals(queuedDownload.URL, download.URL, StringComparison.OrdinalIgnoreCase)) return false;
            DownloadQueue.Enqueue(download);
            return true;
        }

        public static async void DownloadModsAsync(ConcurrentQueue<ModDownload> downloadQueue)
        {
            while (!downloadQueue.IsEmpty)
            {
                if (downloadQueue.TryDequeue(out ModDownload modDownload))
                {
                    await DownloadModAsync(modDownload);
                }
            }
        }
        private static async Task<bool> DownloadModAsync(string downloadURL)
        {
            try
            {
                Logger.Log($"Attempting Mod Download for {downloadURL}");
                HttpResponseMessage response = await QueryPage(downloadURL);
                HttpContent content = response.Content;
                response.EnsureSuccessStatusCode();
                string fileName = HttpUtils.GetFileNameFromContentHeaders(content.Headers).Trim('"');
                string fileExtension = Path.GetExtension(fileName);
                string filePath = Path.Combine(Settings.DownloadModsPath, fileName);
                long fileSize = content.Headers?.ContentLength ?? -1;
                FileType? fileType = FileUtils.GetType(fileExtension);
                if (fileType == null) return false; // Unknown/unaccepted filetype
                ModDownload download = new(downloadURL, (FileType)fileType, fileSize);
                FileStream stream = new(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
                Logger.Log($"Downloading {fileName}");
                await content.CopyToAsync(stream);
                stream.Close();
                Logger.Log($"Downloaded to {filePath}");
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
            return false;
        }
        private static async Task<bool> DownloadModAsync(ModDownload download)
        {
            try
            {
                Logger.Log($"Attempting Mod Download for {download.URL}");
                HttpResponseMessage response = await QueryPage(download.URL);
                HttpContent content = response.Content;
                response.EnsureSuccessStatusCode();
                string fileName = HttpUtils.GetFileNameFromContentHeaders(content.Headers).Trim('"');
                string filePath = Path.Combine(Settings.DownloadModsPath, fileName);
                FileStream stream = new(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
                Logger.Log($"Downloading {fileName}");
                await content.CopyToAsync(stream);
                stream.Close();
                Logger.Log($"Downloaded to {filePath}");
                return true;
            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            return false;
            throw new NotImplementedException();
        }
        #endregion
    }
    public struct ModDownload(string URL, FileType type, long TotalBytes)
    {
        public readonly string URL { get; } = URL;
        public readonly URLOrigin Origin { get; } = HttpUtils.DetermineOrigin(URL);
        public readonly FileType Type { get; } = type;
        public long DownloadedBytes { get; private set; }
        public long TotalBytes { get; private set; } = TotalBytes;
    }
}

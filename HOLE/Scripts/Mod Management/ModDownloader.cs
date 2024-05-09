using SortOrder = HOLE.Scripts.Mod_Management.SortOrder;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using HOLE.Scripts.Misc;
using HOLE.Scripts.Mod_Management;
using System.Text.Json;
using HtmlAgilityPack;
using System.Collections.Concurrent;

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
        public const string SPT_FILES_URL = "https://hub.sp-tarkov.com/files/";
        public const string SPT_MODS_URL = "https://hub.sp-tarkov.com/mods.json";
        public const string FIKA_CLIENT_URL = "https://github.com/project-fika/Fika-Server/";
        public const string FIKA_SERVER_URL = "https://github.com/project-fika/Fika-Plugin/";
        public static string SPT_QUERY_URL => $"{SPT_FILES_URL}?pageNo={SPT_PAGE_FILTERS}";
        public const string BASE_GOOGLE_URL = "https://drive.google.com/";
        public const string BASE_MEDIAFIRE_URL = "https://mediafire.com";
        #endregion
        public static readonly string ModsJsonPath = Path.Combine(Settings.DownloadPath, "mods.json");
        public static readonly JsonSerializerOptions options = new() { WriteIndented = true };
        public static HttpClient? Client { get; private set; }
        public static ConcurrentQueue<ModDownload> DownloadQueue { get; private set; } = new();
        public static ModDownload? CurrentDownload { get; private set; }
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
            Logger.Log($"Querying {SPT_QUERY_URL}");
            HttpResponseMessage response = await Client.GetAsync(SPT_QUERY_URL);
            string body = await response.Content.ReadAsStringAsync();
            Logger.Log($"Got response from {SPT_QUERY_URL}");
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
        public static async Task<List<ModDownload>> DownloadFikaClientServer() => await QueueAndDownload([FIKA_CLIENT_URL, FIKA_SERVER_URL]);
        internal static async Task<List<ModDownload>> QueueAndDownload(params string[] links) // returns the mods queued
        {
            List<ModDownload> queued = [];
            foreach (string link in links)
            {
                ModDownload download = new(link);
                if (await Queue(download)) queued.Add(download);
            }
            DownloadModsQueueAsync(DownloadQueue);
            return queued;
        }
        private static async Task<bool> Queue(ModDownload download) // returns true if not in queue
        {
            await Task.Delay(0);
            foreach (ModDownload queuedDownload in DownloadQueue) // Checks if the download queue already has that URL
                if (string.Equals(queuedDownload.URL, download.URL, StringComparison.OrdinalIgnoreCase)) return false;
            DownloadQueue.Enqueue(download);
            return true;
        }
        public static async void DownloadModsQueueAsync(ConcurrentQueue<ModDownload> downloadQueue)
        {
            List<ModDownload> downloaded = [];
            int queueSize = downloadQueue.Count;
            while (!downloadQueue.IsEmpty)
                if (downloadQueue.TryDequeue(out ModDownload modDownload))
                    if(await DownloadModAsync(modDownload)) downloaded.Add(modDownload);
            MessageBox.Show($"Downloaded {downloaded.Count}/{queueSize} mods successfully!", "Queue Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string extension = Path.GetExtension(filePath);
                long fileSize = content.Headers.ContentLength ?? 0;
                download.FileName = fileName;
                download.Type = FileUtils.GetType(extension);
                Logger.Log($"Downloading {fileName}");
                FileStream stream = new(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
                var contentStream = await content.ReadAsStreamAsync();
                byte[] buffer = new byte[Settings.BufferSize];
                int bytesRead = 0;
                long downloadedBytes = 0;
                download.TotalBytes = fileSize;
                while ((bytesRead = await contentStream.ReadAsync(buffer)) > 0)
                {
                    await stream.WriteAsync(buffer.AsMemory(0, bytesRead));
                    downloadedBytes += bytesRead;
                    download.DownloadedBytes = downloadedBytes;
                    CurrentDownload = download;
                }
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
    public enum DownloadResult
    {
        DOWNLOADED,
        NEWER,
        REPLACED,
    }
    public struct ModDownload(string URL, FileType? type = null, long? TotalBytes = null)
    {
        public readonly string URL { get; } = URL;
        public readonly URLOrigin Origin { get; } = HttpUtils.DetermineOrigin(URL);
        public FileType? Type { get; internal set; } = type;
        public string FileName { get; internal set; }
        public long DownloadedBytes { get; internal set; }
        public long? TotalBytes { get; internal set; } = TotalBytes;
        public readonly float Progress => TotalBytes != 0 ? ((DownloadedBytes / TotalBytes) ?? 0) * 100 : 0;
    }
}

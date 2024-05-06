using HOLE.Scripts.Misc;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HOLE.Scripts
{
    public static class Updater
    {
        private static readonly string GITHUB_URL = "https://api.github.com/repos/00Herobrine/HOLE/releases/latest";
        public static async Task<bool> CheckForUpdate()
        {
            HttpClient client = new();
            client.DefaultRequestHeaders.Add("User-Agent", Settings.USER_AGENT);
            try
            {
                HttpResponseMessage response = await client.GetAsync(GITHUB_URL);
                response.EnsureSuccessStatusCode();
                string body = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(body)) return false;
                GitHubRelease latestRelease = JsonSerializer.Deserialize<GitHubRelease>(body);
                return latestRelease.Version > FileUtils.GetProjectVersion();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error Updating: {ex.Message}");
                return false;
            }
        }
    }

    public struct GitHubRelease
    {
        [JsonPropertyName("html_url")]
        public string URL { get; set; }
        [JsonPropertyName("tag_name")]
        public string Tag { get; set; }
        public readonly Version Version => new(Tag.Replace("v", ""));
        public string Name { get; set; }
        [JsonPropertyName("body")]
        public string Description { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonPropertyName("published_at")]
        public DateTime PublishedAt { get; set; }
        public List<GitHubAsset> Assets { get; set; }
    }
    
    public struct GitHubAsset
    {
        [JsonPropertyName("name")]
        public string FileName { get; set; }
        public int ID { get; set; }
        [JsonPropertyName("browser_download_url")]
        public string DownloadURL { get; set; }
        [JsonPropertyName("content_type")]
        public string FileType { get; set; }
        [JsonPropertyName("size")]
        public long FileSize { get; set; }
    }
}

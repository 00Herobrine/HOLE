using System.Text.Json.Serialization;

namespace Updater;

public struct GitHubRelease
{
    [JsonPropertyName("tag_name")]
    public string TagName { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("assets")]
    public List<GitHubAsset> Assets { get; set; }
}

public struct GitHubAsset
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("browser_download_url")]
    public string DownloadUrl { get; set; }
    [JsonPropertyName("size")]
    public long Size { get; set; }
    [JsonPropertyName("content_type")]
    public string ContentType { get; set; }
}
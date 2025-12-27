using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Updater;

public partial class UpdaterForm : Form
{
    public const string RepoOwner = "00Herobrine";
    public const string RepoName = "HOLE";
    public const string LauncherPath = "HOLE.exe";
    public const string DownloadPath = "cache/";
    public const string LatestReleaseUrl = "https://api.github.com/repos/{repoOwner}/{repoName}/releases/latest";
    public const string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/98.0.4758.102 Safari/537.36";
    public const string NoExeVersion = "0.0.0";
    
    public static readonly string ApplicationPath = Directory.GetCurrentDirectory();
    public static readonly string FormattedLauncherPath = Path.Combine(ApplicationPath, LauncherPath);
    public static readonly string FormattedDownloadPath = Path.Combine(ApplicationPath, DownloadPath);
    public UpdaterForm()
    {
        InitializeComponent();
    }

    private void UpdaterForm_Load(object sender, EventArgs e)
    {
        _ = CheckForUpdateAsync();
    }

    private async Task CheckForUpdateAsync()
    {
        // if the current launcher version == latest repo version do nothing
        // else download the latest launcher version
        using HttpClient updateClient = new HttpClient();
        Version launcherVersion = GetLauncherVersion();
        Version latestVersion = await GetLatestVersionAsync(updateClient);
        if (launcherVersion >= latestVersion)
        {
            MessageBox.Show("You are up to date!");
        }
        else
        {
            await DownloadUpdateAsync(updateClient);
        }
    }
    
    private Version GetLauncherVersion()
    {
        if (!File.Exists(FormattedLauncherPath))
            return new Version($"{NoExeVersion}");

        string fileVersion = FileVersionInfo.GetVersionInfo(FormattedLauncherPath).ProductVersion ?? $"{NoExeVersion}";
        return new Version(fileVersion);
    }

    private async Task<Version> GetLatestVersionAsync(HttpClient client)
    {
        try
        {
            client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            GitHubRelease latestRelease = await GetLatestGitHubReleaseAsync(client);
            if (Version.TryParse(Regex.Replace(latestRelease.TagName, @"[^0-9.]", ""), out Version? latestVersion))
                    return latestVersion;
            return new Version(NoExeVersion);
        }
        catch (Exception e)
        {
            throw new ArgumentException("Failed to get latest version", e);
        }
    }
    
    private async Task DownloadUpdateAsync(HttpClient client) 
    {
        try
        {
            GitHubRelease latestRelease = await GetLatestGitHubReleaseAsync(client);
            GitHubAsset latestAsset = latestRelease.Assets[0];
            string downloadUrl = latestAsset.DownloadUrl;
            if (string.IsNullOrEmpty(downloadUrl))
                return;
            
            if(!Directory.Exists(FormattedDownloadPath)) 
                Directory.CreateDirectory(FormattedDownloadPath);
            
            byte[] fileContent = await client.GetByteArrayAsync(downloadUrl);
            string filePath = Path.Combine(FormattedDownloadPath, latestAsset.Name);
            await File.WriteAllBytesAsync(filePath, fileContent);
            ExtractZipFile(DownloadPath, LauncherPath);
        }
        catch (Exception e)
        {
            throw new ArgumentException("Failed to download update", e);
        }
    }

    private async Task<GitHubRelease> GetLatestGitHubReleaseAsync(HttpClient client)
    {
        try 
        {
            string json = await  client.GetStringAsync(LatestReleaseUrl.Replace("{repoOwner}", RepoOwner).Replace("{repoName}", RepoName));
            GitHubRelease release = JsonSerializer.Deserialize<GitHubRelease>(json);
            return release;
        }
        catch(Exception e)
        {
            // TODO: Display message box saying repo can't be pinged
            throw new ArgumentException("Failed to get GitHubRelease", e);
        }
    }


    private void ExtractZipFile(string zipFilePath, string outputPath)
    {
        
    }
}
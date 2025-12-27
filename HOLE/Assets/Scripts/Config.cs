using System.Text;
using HOLE.Assets.Scripts.Mods;

namespace HOLE.Assets.Scripts;

public struct Config(string baseDirectory)
{
    public struct LogConfig(
        string prefix = Logger.DefaultPrefix,
        string format = Logger.DefaultLoggerFormat,
        int maxLogLines = 10000)
    {
        public string Prefix = prefix;
        public string Format = format;
        public int MaxLogLines = maxLogLines;
    }

    public Paths Paths = new Paths(baseDirectory);
    public LogConfig Logging;
    public LauncherConfig Launcher;
    public ModManagerConfig ModManager;
    public DownloaderSettings Downloader;
}

public struct Paths(string baseDirectory)
{
    // Default folder names
    public const string TarkovFolderName = "tarkov";
    public const string InstancesFolderName = "Instances";
    public const string CacheFolderName = "cache";
    public const string ModFolderName = "mods";
    public const string ModDownloadFolderName = "cache/mods";
    public const string ModIconFolderName = "cache/icons";
    public const string ModListName = "cache/mods.json";
    public const string IconsFolderName = "icons";
    public const string ThemesFolderName = "themes";
    public const string LocalesFolderName = "locales";
    public const string LogsFolderName = "logs";

    public string Tarkov = Path.Combine(baseDirectory, TarkovFolderName);
    public string Instances = Path.Combine(baseDirectory, InstancesFolderName);
    public string Cache = Path.Combine(baseDirectory, CacheFolderName);
    public string Mods = Path.Combine(baseDirectory, ModFolderName);
    public string ModDownloads = Path.Combine(baseDirectory, ModDownloadFolderName);
    public string ModIcons = Path.Combine(baseDirectory, ModIconFolderName);
    public string ModList = Path.Combine(baseDirectory, ModListName);
    public string Icons = Path.Combine(baseDirectory, IconsFolderName);
    public string Themes = Path.Combine(baseDirectory, ThemesFolderName);
    public string Locales = Path.Combine(baseDirectory, LocalesFolderName);
    public string Logs = Path.Combine(baseDirectory, LogsFolderName);

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Paths:");
        sb.AppendLine("[");
        sb.AppendLine($"{Tarkov}");
        sb.AppendLine($"{Instances}");
        sb.AppendLine($"{Icons}");
        sb.AppendLine($"{Mods}");
        sb.AppendLine($"{ModIcons}");
        sb.AppendLine($"{Themes}");
        sb.AppendLine($"{Locales}");
        sb.AppendLine("]");
        return sb.ToString();
    }
}

public struct DownloaderSettings(
    int maxSpeed = 0,
    int bufferSize = 8192,
    int refreshTime = 900,
    int concurrentDownloads = 1,
    int retryAttempts = 1,
    int defaultPagesQueried = 3,
    bool infiniteScroll = false,
    bool webSearch = false)
{
    public int MaxSpeed = maxSpeed; // 0 = unrestricted
    public int BufferSize = bufferSize;
    public int RefreshTime = refreshTime; // in seconds
    public int ConcurrentDownloads = concurrentDownloads;
    public int RetryAttempts = retryAttempts;
    public int DefaultPagesQueried = defaultPagesQueried;
    public bool InfiniteScroll = infiniteScroll;
    public bool WebSearch = webSearch;
}

public struct ModManagerConfig(
        bool autoUpdate = false,
        string modFolderFormat = ModManager.ModFolderFormat)
{
    public bool AutoUpdate = autoUpdate;
    public string ModFolderFormat = modFolderFormat;
}


public struct LauncherConfig(
    string baseDirectory,
    bool autoUpdate = false,
    bool showTimePlayed = true,
    bool showTotalTimePlayed = true,
    bool recordTimePlayed = true,
    string timeFormat = "YY:DD:HH:MM:SS",
    LaunchPreference launchPreference = LaunchPreference.None)
{
    public bool AutoUpdate = autoUpdate;
    public bool ShowTimePlayed = showTimePlayed;
    public bool ShowTotalTimePlayed = showTotalTimePlayed;
    public bool RecordTimePlayed = recordTimePlayed;
    public string TimeFormat = timeFormat;

    public LaunchPreference LaunchPreference = launchPreference;
    /*public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("LauncherConfig:");
        sb.AppendLine("[");
        sb.AppendLine($"{Paths.ToString()},");
        sb.AppendLine($"{Downloader.ToString()},");
        sb.AppendLine($"{Logger.ToString()},");
        sb.AppendLine($"{AutoUpdate}");
        sb.AppendLine("]");
        return sb.ToString();
    }*/
}

public enum LaunchPreference
{
    None,
    MinimizeOnLaunch,
    CloseOnLaunch,
}
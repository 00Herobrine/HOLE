using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;

namespace HOLE.Assets.Scripts
{
    public struct LauncherPaths(string baseDirectory)
    {
        // Default folder names
        public const string TarkovFolderName = "tarkov";
        public const string InstancesFolderName = "Instances";
        public const string CacheFolderName = "cache";
        public const string ModFolderName = "mods";
        public const string ModDownloadFolderName = "cache/mods";
        public const string ModIconFolderName = "cache/icons";
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

    public struct DownloaderSettings(int downloadSpeed = 0, int concurrentDownloads = 1, int retryAttempts = 1, bool infiniteScroll = false, bool webSearch = false)
    {
        public int DownloadSpeed = downloadSpeed;
        public int ConcurrentDownloads = concurrentDownloads;
        public int RetryAttempts = retryAttempts;
        public bool InfiniteScroll = infiniteScroll;
        public bool WebSearch = webSearch;
    }

    public struct LauncherSettings(bool autoUpdate, bool showTimeSpentPlaying, bool showTotalTimeSpentPlaying, bool recordTimeSpentPlaying, DateTimeFormat timeFormat, LaunchPreference launchPreference)
    {
        public bool AutoUpdate = autoUpdate;
        public bool ShowTimeSpentPlaying = showTimeSpentPlaying;
        public bool ShowTotalTimeSpentPlaying = showTotalTimeSpentPlaying;
        public bool RecordTimeSpentPlaying = recordTimeSpentPlaying;
        public DateTimeFormat TimeFormat = timeFormat;
        public LaunchPreference LaunchPreference = launchPreference;
    }

    public struct LoggerSettings(string prefix, string format, int maxLogLines = 10000)
    {
        public string Prefix = prefix;
        public string Format = format;
        public int MaxLogLines = maxLogLines;
    }

    public struct LauncherConfig(string baseDirectory,
        int modDownloadBufferSize = 8192, int modCacheRefresh = 10, int maxLogLines = 100,
        bool autoUpdate = false, bool infiniteScroll = true, LaunchPreference launchPreference = LaunchPreference.None)
    {
        public LauncherPaths Paths = new LauncherPaths(baseDirectory);
        public int ModDownloadBufferSize = modDownloadBufferSize;
        public int ModCacheRefresh = modCacheRefresh;
        public int MaxLogLines = maxLogLines;
        public string LogPrefix = Logger.DefaultPrefix;
        public string LogFormat = "[{Prefix}] [{Level}] {Message}";
        public bool AutoUpdate = autoUpdate;
        public bool InfiniteScroll = infiniteScroll;
        public bool WebSearch = false; // Will search through the SPT website as well as the local cache
        public LaunchPreference LaunchPreference = launchPreference; 
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("LauncherConfig:");
            sb.AppendLine("[");
            sb.AppendLine($"{Paths.ToString()},");
            sb.AppendLine($"{ModDownloadBufferSize},");
            sb.AppendLine($"{AutoUpdate}");
            sb.AppendLine("]");
            return sb.ToString();
        }
    }

    public enum LaunchPreference
    {
        None,
        MinimizeOnLaunch,
        CloseOnLaunch,
    }

    public static class Launcher
    {
        public static LauncherConfig Config { get; private set; }
        // These Paths shouldn't really change, but I think I should include them in the LauncherPaths for consistency.
        public static readonly string ExePath = Environment.CurrentDirectory; // This does not need to be included in LauncherPaths
        public static readonly string ConfigPath = Path.Combine(ExePath, "config.json");
        public static readonly string UISettingsPath = Path.Combine(ExePath, "UISettings.json");
        public static readonly string ModsJsonPath = Path.Combine(ExePath, "mods.json");

        public static void Initialize()
        {
            LoadLauncherConfig();
            //InstanceManager.LoadInstances();
            //InitializeCoreManagers();
        }

        private static async Task InitializeCoreManagers()
        {
            //InstanceManager.GetInstances();
            //await Task.Run(IconManager.InitializeAsync);
            //ProfileManager.LoadInstances();
        }
        
        private static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions { WriteIndented = true, IncludeFields = true };
        private static void LoadLauncherConfig(bool forceCreate = false)
        {
            if (!File.Exists(ConfigPath) || forceCreate)
            {
                if (CreateLauncherConfig())
                {
                    Logger.Info($"Created config to '{ConfigPath}'.");
                } else Logger.Warn($"Failed to save config to '{ConfigPath}'.");
            }
            string configJson = File.ReadAllText(ConfigPath);
            Config = JsonSerializer.Deserialize<LauncherConfig>(configJson, SerializerOptions);
        }

        private static bool CreateLauncherConfig()
        {
            try
            {
                LauncherConfig launcherConfig = new LauncherConfig(ExePath);
                string json = JsonSerializer.Serialize(launcherConfig, SerializerOptions);
                File.WriteAllText(ConfigPath, json);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

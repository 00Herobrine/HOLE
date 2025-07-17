using System.Diagnostics;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;

namespace HOLE.Assets.Scripts
{
    public struct LauncherPaths(string baseDirectory)
    {
        // Default folder names
        public const string TarkovFolderName = "Tarkov";
        public const string InstancesFolderName = "Instances";
        public const string ModsFolderName = "Mods";
        public const string ModIconsFolderName = "ModIcons";
        public const string IconsFolderName = "Icons";
        public const string ThemesFolderName = "Themes";

        public string Tarkov = Path.Combine(baseDirectory, TarkovFolderName);
        public string Instances = Path.Combine(baseDirectory, InstancesFolderName);
        public string Icons = Path.Combine(baseDirectory, IconsFolderName);
        public string Mods = Path.Combine(baseDirectory, ModsFolderName);
        public string ModIcons = Path.Combine(baseDirectory, ModIconsFolderName);
        public string Themes = Path.Combine(baseDirectory, ThemesFolderName);

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
            sb.AppendLine("]");
            return sb.ToString();
        }
    }

    public struct DownloadSettings
    {
        public int DownloadSpeed;
        public int ConcurrentDownloads;
        public int NumberOfRetries;
    }

    public struct GameSettings
    {
        public bool ShowTimeSpentPlaying;
        public bool ShowTotalTimeSpentPlaying;
        public bool RecordTimeSpentPlaying;
        public DateTimeFormat TimeFormat;
        public LaunchPreference LaunchPreference;
    }

    public struct LauncherConfig(string baseDirectory)
    {
        public LauncherPaths Paths { get; set; } = new LauncherPaths(baseDirectory);
        public int ModDownloadBufferSize { get; set; }
        public int ModCacheRefresh { get; set; }
        public bool AutoUpdate { get; set; } = false;
        public LaunchPreference LaunchPreference { get; set; } = LaunchPreference.None;
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
            //InitializeCoreManagers();
        }

        private static async Task InitializeCoreManagers()
        {
            //InstanceManager.GetInstances();
            //await Task.Run(IconManager.InitializeAsync);
            //ProfileManager.LoadInstances();
        }
        
        private static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions { WriteIndented = true, IncludeFields = true };
        public static void LoadLauncherConfig()
        {
            if (!File.Exists(ConfigPath))
            {
                CreateLauncherConfig();
            } 
            string json = File.ReadAllText(ConfigPath);
            Config = JsonSerializer.Deserialize<LauncherConfig>(json, SerializerOptions);
        }

        private static void CreateLauncherConfig(bool overwrite = false)
        {
            try
            {
                LauncherConfig launcherConfig = new LauncherConfig(ExePath);
                string json = JsonSerializer.Serialize(launcherConfig, SerializerOptions);
                File.WriteAllText(ConfigPath, json);
                Debug.WriteLine($"Created config to {ConfigPath}.\n{launcherConfig.ToString()}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to save config: {ex.Message}");
            }
        }
    }
}

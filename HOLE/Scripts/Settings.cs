using HOLE.Scripts.Misc;
using System.Text.Json;

namespace HOLE.Scripts
{
    internal static class Settings
    {
        public static LauncherSettings LauncherSettings { get; private set; } = new();
        public static string LauncherPath => LauncherSettings.LauncherDataPath;
        public static string ConfigPath => Path.Combine(LauncherPath, "config.json");
        public static string InstancesPath => LauncherSettings.InstancesPath;
        public static string ModsPath => LauncherSettings.ModsPath;
        public static string DownloadPath => LauncherSettings.DownloadPath;
        public static string DownloadModsPath => LauncherSettings.DownloadModsPath;
        public static string DownloadIconsPath => LauncherSettings.DownloadIconsPath;
        public static string BackupsPath => LauncherSettings.BackupsPath;
        public static string IconPacksPath => LauncherSettings.IconPacksPath;
        public static string DefaultPackPath => Path.Combine(IconPacksPath, "Default");
        public static IconPack DefaultIcons { get; } = new IconPack(DefaultPackPath);
        public static IconPack SelectedIcons { get; set; } = DefaultIcons;
        public static string Language => LauncherSettings.Preset.Language;
        public static int BufferSize => LauncherSettings.BufferSize;
        public static string LauncherSettingsJson => JsonSerializer.Serialize(LauncherSettings, options);
        public static readonly string USER_AGENT = $"H.O.L.E/{FileUtils.GetProjectVersion()} (.NET Core {Environment.Version}; {Environment.OSVersion})";

        public static void Initialize()
        {
            SettingsFileCheck();
            string config = File.ReadAllText(ConfigPath);
            LauncherSettings? settings = JsonSerializer.Deserialize<LauncherSettings>(config);
            if (settings != null)
            {
                SetLauncherSettings(settings);
                Logger.Log($"Setting launcher settings \n{config}");
                Initialize(settings);
            }
            else Logger.Log("Settings == null");
        }
        private static void Initialize(LauncherSettings settings)
        {
            PathCheck(settings.LauncherDataPath, settings.InstancesPath, settings.ModsPath, settings.BackupsPath, settings.PresetsPath, settings.IconPacksPath, DefaultPackPath);
            Logger.Log($"Set LauncherSettings to {settings.Preset.Name}");
        }


        #region Launcher Settings
        private static void SetLauncherSettings(LauncherSettings settings)
        {
            LauncherSettings = settings;
        }

        public static void SaveLauncherSettings()
        {
            File.WriteAllText(ConfigPath, LauncherSettingsJson);
        }
        public static void SettingsFileCheck()
        {
            if (!File.Exists(ConfigPath)) CreateSettingsFile();
        }

        private static readonly JsonSerializerOptions options = new() { WriteIndented = true };
        private static void CreateSettingsFile()
        {
            File.WriteAllText(ConfigPath, LauncherSettingsJson);
            Logger.Log($"Settings File Created at {ConfigPath}");
        }
        #endregion

        private static void PathCheck(params string[] paths)
        {
            foreach (string path in paths)
            {
                if (Directory.Exists(path)) continue;
                Directory.CreateDirectory(path);
                Logger.Log($"Created Directory {path}");
            }
        }

        internal static void SetInstancesPath(string path, bool save = false)
        {
            LauncherSettings.InstancesPath = path;
            Logger.Log($"Set Instances Path to {path}");
            if (save) SaveLauncherSettings();
        }
        internal static void SetModsPath(string path)
        {
            LauncherSettings.ModsPath = path;
        }
    }
}

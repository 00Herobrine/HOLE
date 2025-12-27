using System.Text.Json;

namespace HOLE.Assets.Scripts
{
    public static class Launcher
    {
        public static Config Config { get; private set; }
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
        private static void LoadLauncherConfig(bool forceCreate = false)
        {
            if (!File.Exists(ConfigPath) || forceCreate)
            {
                CreateLauncherConfig();
            }
            string configJson = File.ReadAllText(ConfigPath);
            Config = JsonSerializer.Deserialize<Config>(configJson, SerializerOptions);
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
                Logger.Exception(ex);
                return false;
            }
        }
    }
}

using HOLE.Scripts.Misc;

namespace HOLE.Scripts
{
    internal static class Settings
    {
        public static LauncherSettings LauncherSettings { get; private set; } = new();
        public static Instance? SelectedInstance { get; private set; }
        public static string LauncherPath => LauncherSettings.LauncherPath;
        public static string InstancesPath => LauncherSettings.InstancesPath;
        public static string ModsPath => LauncherSettings.ModsPath;
        public static string BackupsPath => LauncherSettings.BackupsPath;
        public static string Language => LauncherSettings.Language;

        public static void Initialize(LauncherSettings settings)
        {
            SetLauncherSettings(settings);
        }

        private static void SetLauncherSettings(LauncherSettings settings)
        {
            LauncherSettings = settings;
        }

        public static void Initialize()
        {
            PathCheck(LauncherPath, InstancesPath, ModsPath, BackupsPath);
            Logger.Log(new LauncherSettings().ToString());
        }

        private static void PathCheck(params string[] paths)
        {
            foreach (string path in paths)
            {
                if (Directory.Exists(path)) continue;
                Directory.CreateDirectory(path);
                Logger.Log($"Created Directory {path}");
            }
        }

        internal static void SetSelectedInstance(Instance? instance)
        {
            SelectedInstance = instance;
        }

        internal static void SetInstancesPath(string path)
        {
            LauncherSettings.InstancesPath = path;
            Logger.Log($"Set Instances Path to {path}");
        }
        internal static void SetModsPath(string path)
        {
            LauncherSettings.ModsPath = path;
        }
    }
}

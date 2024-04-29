using HOLE.Scripts.Misc;
using System.Diagnostics;

namespace HOLE.Scripts
{
    internal static class Settings
    {
        public static string Prefix { get; private set; } = "[H.O.L.E]";
        public static string LauncherPath { get; private set; } = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}{Path.DirectorySeparatorChar}HerosLauncher{Path.DirectorySeparatorChar}";
        public static string LauncherConfigPath { get; private set; } = $"{LauncherPath}config.yml";
        public static string InstancesPath { get; private set; } = $"{LauncherPath}Instances{Path.DirectorySeparatorChar}";
        public static string ModsPath { get; private set; } = $"{LauncherPath}Mods{Path.DirectorySeparatorChar}";
        public static string DownloadingModsPath { get; private set; } = $"{ModsPath}Downloading{Path.DirectorySeparatorChar}";
        public static string BackupsPath { get; private set; } = $"{LauncherPath}Backups{Path.DirectorySeparatorChar}";
        public static string Language { get; private set; } = "en";
        public static LauncherSettings LauncherSettings { get; private set; }
        public static Dictionary<string, Locale> Locales { get; private set; } = new();
        public static Instance? SelectedInstance { get; private set; }

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
            Debug.WriteLine(new LauncherSettings().ToString());
        }

        internal static void StoreLocales(Instance instance)
        {
            Locales.Clear();
            Locales.Add("global", new Locale(instance.GlobalLocale));
            Locales.Add("server", new Locale(instance.ServerLocale));
            Debug.WriteLine("Stored Locales");
        }

        private static void PathCheck(params string[] paths)
        {
            foreach (string path in paths)
            {
                if (Directory.Exists(path)) continue;
                Directory.CreateDirectory(path);
                Debug.WriteLine($"Created Directory {path}");
            }
        }

        internal static void SetSelectedInstance(Instance? instance)
        {
            SelectedInstance = instance;
        }

        internal static void SetInstancesPath(string path)
        {
            InstancesPath = path;
            Debug.WriteLine($"Set Instances Path to {path}");
        }
        internal static void SetModsPath(string path)
        {
            ModsPath = path;
        }
    }
}

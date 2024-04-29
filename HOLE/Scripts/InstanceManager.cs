using System.Diagnostics;

namespace HOLE.Scripts
{
    internal static class InstanceManager
    {
        public static string directory => Settings.InstancesPath;
        public static Instance? SelectedInstance { get; private set; } 
        public static Dictionary<string, Instance> Instances { get; private set; } = new();

        public static void Cache()
        {
            Instances.Clear();
            foreach (string subdir in Directory.GetDirectories(directory)) 
                Add(subdir);
        }
        public static Instance? Get(string name) => Instances.TryGetValue(name, out Instance instance) ? instance : null;
        public static void Add(string Path, string? Name = null) => Add(new Instance(Path, Name));
        public static void Add(Instance Instance)
        {
            string name = Instance.Name;
            if (Instances.ContainsKey(name)) Debug.WriteLine($"{name} is already in use");
            Instances.Add(name, Instance);
            Debug.WriteLine("Added Instance " + name);
        }

        public static void Remove(string name)
        {
            Instances.Remove(name);
        }

        internal static void SetSelected(Instance? selectedInstance)
        {
            SelectedInstance = selectedInstance;
        }
    }

    public struct Instance(string Directory, string? Name = null)
    {
        public string Directory { get; set; } = $"{Directory}{Path.DirectorySeparatorChar}";
        public string Name { get; set; } = Name ?? Directory.Split(Path.DirectorySeparatorChar).Last();
        public void StoreLocales() => Settings.StoreLocales(this);
        public readonly string AkiDataPath => Path.Combine(Directory, "Aki_Data");
        public readonly string ServerPath => Path.Combine(AkiDataPath, "Server");
        public readonly string DatabasePath => Path.Combine(ServerPath, "database");
        public readonly string HideoutPath => Path.Combine(DatabasePath, "hideout");
        public readonly string LocalesPath => Path.Combine(DatabasePath, "locales");
        public readonly string GlobalLocaleDir => Path.Combine(LocalesPath, "global");
        public readonly string GlobalLocale => Path.Combine(GlobalLocaleDir, $"{Settings.Language}.json");
        public readonly string ServerLocaleDir => Path.Combine(LocalesPath, "server");
        public readonly string ServerLocale => Path.Combine(ServerLocaleDir, $"{Settings.Language}.json");
        public readonly string BepInExPath => $"{Directory}BepInEx{Path.DirectorySeparatorChar}";
        public readonly string PluginsPath => $"{BepInExPath}plugins{Path.DirectorySeparatorChar}";
        public readonly string UserPath => $"{Directory}User{Path.DirectorySeparatorChar}";
        public readonly string ModsPath => $"{UserPath}mods{Path.DirectorySeparatorChar}";
        public readonly string ProfilesPath => $"{UserPath}profiles{Path.DirectorySeparatorChar}";
    }
}

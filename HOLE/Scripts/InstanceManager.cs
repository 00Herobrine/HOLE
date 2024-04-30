using System.ComponentModel;

namespace HOLE.Scripts
{
    internal static class InstanceManager
    {
        public static string directory => Settings.InstancesPath;
        public static Instance? SelectedInstance { get; private set; } 
        public static Dictionary<string, Instance> Instances { get; private set; } = new();
        public static event EventHandler<InstanceEventArgs>? InstanceChangingEvent;
        public static event EventHandler<InstanceEventArgs>? InstanceChangedEvent;
        public static event EventHandler<InstanceEventArgs>? InstanceAddedEvent;
        public static event EventHandler<InstanceEventArgs>? InstanceRemovedEvent;

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
            if (Instances.ContainsKey(name)) Logger.Log($"{name} is already in use.");
            Instances.Add(name, Instance);
            InstanceAddedEvent?.Invoke(null, new InstanceEventArgs(Instance));
            Logger.Log($"Added Instance {name}.");
        }
        public static void Remove(string name)
        {
            Instance? instance = Instances[name];
            if (Instances.Remove(name)) InstanceRemovedEvent?.Invoke(null, new InstanceEventArgs(instance));
        }

        internal static void SetSelected(Instance? selectedInstance)
        {
            var args = new InstanceEventArgs(selectedInstance);
            InstanceChangingEvent?.Invoke(null, args);
            if (args.Cancel) return;
            SelectedInstance = selectedInstance;
            InstanceChangedEvent?.Invoke(null, args);
        }
    }

    public class InstanceEventArgs(Instance? newInstance) : CancelEventArgs
    {
        public Instance? Instance { get; } = newInstance;
    }

    public struct Instance(string Directory, string? Name = null)
    {
        public string Directory { get; set; } = $"{Directory}{Path.DirectorySeparatorChar}";
        public string Name { get; set; } = Name ?? Directory.Split(Path.DirectorySeparatorChar).Last();
        public readonly string AkiDataPath => Path.Combine(Directory, "Aki_Data");
        public readonly string ServerPath => Path.Combine(AkiDataPath, "Server");
        public readonly string DatabasePath => Path.Combine(ServerPath, "database");
        public readonly string HideoutPath => Path.Combine(DatabasePath, "hideout");
        public readonly string LocalesPath => Path.Combine(DatabasePath, "locales");
        public readonly string GlobalLocaleDir => Path.Combine(LocalesPath, "global");
        public readonly string GlobalLocale => Path.Combine(GlobalLocaleDir, $"{Settings.Language}.json");
        public readonly string ServerLocaleDir => Path.Combine(LocalesPath, "server");
        public readonly string ServerLocale => Path.Combine(ServerLocaleDir, $"{Settings.Language}.json");
        public readonly string BepInExPath => Path.Combine(Directory, "BepInEx");
        public readonly string PluginsPath => Path.Combine(BepInExPath, "Plugins");
        public readonly string UserPath => Path.Combine(Directory, "user");
        public readonly string ModsPath => Path.Combine(UserPath, "mods");
        public readonly string ProfilesPath => Path.Combine(UserPath, "profiles");
    }
}

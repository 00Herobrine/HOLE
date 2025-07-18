using System.Diagnostics;

namespace HOLE.Assets.Scripts
{
    public class Instance
    {
        public readonly string InstancePath;
        public readonly string Name;
        public string BepInExPath => Path.Combine(InstancePath, "BepInEx");
        public string PluginsPath => Path.Combine(BepInExPath, "plugins");
        public string UserPath => Path.Combine(InstancePath, "user");
        public string UserCachePath => Path.Combine(UserPath, "cache");
        public string ModsPath => Path.Combine(UserPath, "mods");
        public string ProfilesPath => Path.Combine(UserPath, "profiles");

        public Process[] GameProcess { get; private set; } = [];
        public Instance(string instancePath)
        {
            InstancePath = instancePath;
            Name = InstancePath.Split(Path.DirectorySeparatorChar).Last();
        }
    }
    public static class InstanceManager
    {
        public static string InstancesFolder => Launcher.Config.Paths.Instances;
        private static List<Instance> Instances = new();
        //public static InstanceFolder SelectedInstance { get; private set; }
        //public static Action? InstancesLoadedEvent;
        //public static Action? InstanceSelectedEvent;

        public static async void LoadInstances()
        {
            if (!Directory.Exists(InstancesFolder))
            {
                Directory.CreateDirectory(InstancesFolder);
            }
        }

        public static async Task<List<Instance>> GetInstances()
        {
            if(!Directory.Exists(InstancesFolder)) 
            {
                Directory.CreateDirectory(InstancesFolder);
            }

            List<Instance> instances = [];
            foreach (var instanceFolder in Directory.GetDirectories(InstancesFolder))
            {
                Instance instance = new Instance(instanceFolder);
                instances.Add(instance);
            }
            await Task.CompletedTask;
            return instances;
        }

        public static Instance? GetInstance(string instanceName)
        {
            string instanceDir = Path.Combine(InstancesFolder, instanceName);
            if (!Path.Exists(instanceDir))
            {
                // Instance doesn't exist
                return null;
            }
            return new Instance(instanceDir);
        }

        public static void DeleteInstance(string instanceName)
        {
            string instanceDir = Path.Combine(InstancesFolder, instanceName);
            if (!Path.Exists(instanceDir))
            {
                // Couldn't find instance with that name
                return;
            }
            Directory.Delete(instanceDir);
        }

        public static void RenameInstance(string instanceName, string updatedName)
        {
            string oldDir = Path.Combine(InstancesFolder, instanceName);
            string newDir = Path.Combine(InstancesFolder, updatedName);
            Directory.Move(oldDir, newDir);
        }
    }
}

using System.Diagnostics;
using System.Text.Json;
using HOLE.Assets.Scripts.Utils;

namespace HOLE.Assets.Scripts
{
    public class Instance(string folder)
    {
        public const string BepInExFolderName = "BepInEx";
        public const string PluginsFolderName = "plugins";
        public const string UserFolderName = "user";
        public const string CacheFolderName = "cache";
        public const string ModsFolderName = "mods";
        public const string ProfilesFolderName = "profiles";
        public const string ConfigFileName = "config.json";
        public const string ServerExeName = "spt.server.exe";
        
        public readonly string Folder = folder;
        public readonly string Name = Path.GetDirectoryName(folder) ?? "INVALID DIRECTORY";
        public InstanceConfig Config;
        public readonly string BepInExPath = Path.Combine(folder, BepInExFolderName);
        public readonly string PluginsPath = Path.Combine(folder, BepInExFolderName, PluginsFolderName);
        public readonly string ServerExePath = Path.Combine(folder, ServerExeName);
        public readonly string UserPath = Path.Combine(folder, UserFolderName);
        public readonly string UserCachePath = Path.Combine(folder, UserFolderName, CacheFolderName);
        public readonly string ModsPath = Path.Combine(folder, UserFolderName, ModsFolderName);
        public readonly string ProfilesPath = Path.Combine(folder, UserFolderName, ProfilesFolderName);
        public readonly string ConfigPath = Path.Combine(folder, ConfigFileName);

        public Process[] GameProcess { get; private set; } = [];
        public Process[] ServerProcess { get; private set; } = [];
        
        public void LoadConfig()
        {
            try
            {
                if (File.Exists(ConfigPath))
                {
                    var json = File.ReadAllText(ConfigPath);
                    Config = JsonSerializer.Deserialize<InstanceConfig?>(json) ?? new InstanceConfig();
                }
            }
            catch (Exception ex)
            {
                Logger.Warn($"Failed to load config for instance '{Name}': {ex.Message}");
                Config = new InstanceConfig();
            }
        }

        public bool HasServerExe() => File.Exists(ServerExePath);
    }

    public struct InstanceConfig(string icon = "wifi.png", string? group = null)
    {
        public string? Icon = icon;
        public string? Group = group;
    }
    
    public static class InstanceManager
    {
        public static string InstancesFolder => Launcher.Config.Paths.Instances;
        //private static List<Instance> _instances = new();
        //public static InstanceFolder SelectedInstance { get; private set; }
        //public static Action? InstancesLoadedEvent;
        //public static Action? InstanceSelectedEvent;

        /*public static async void LoadInstances()
        {
            _instances = await LoadInstancesFromDirectory();
        }*/

        public static List<Instance> GetInstances()
        {
            List<Instance> instances = [];
            if(!FileManagement.DirectoryCheck(InstancesFolder)) return instances;
            foreach (var instanceFolder in Directory.GetDirectories(InstancesFolder))
            {
                Instance instance = new Instance(instanceFolder);
                if (!instance.IsValid()) continue;
                instance.LoadConfig();
                instances.Add(instance);
            }
            return instances;
        }

        public static Instance? GetInstance(string instanceName)
        {
            string instanceDir = Path.Combine(InstancesFolder, instanceName);
            if (!Path.Exists(instanceDir))
                return null;
            Instance instance = new Instance(instanceDir);
            return instance.IsValid() ? instance : null;
        }

        public static void AddInstance(string instancePath)
        {
            
        }

        public static void DeleteInstance(string instanceName)
        {
            string instanceDir = Path.Combine(InstancesFolder, instanceName);
            if (!Path.Exists(instanceDir))
                return;

            try
            {
                Directory.Delete(instanceDir);
            } catch (Exception e)
            {
                Logger.Warn($"Failed to delete instance '{instanceName}'.\n'{e.Message}'");
            }
        }

        public static void RenameInstance(string instanceName, string updatedName)
        {
            try
            {
                string oldDir = Path.Combine(InstancesFolder, instanceName);
                string newDir = Path.Combine(InstancesFolder, updatedName);
                Directory.Move(oldDir, newDir);
            }
            catch(Exception e)
            {
                Logger.Warn($"Failed to renamed instance '{instanceName}' to '{updatedName}'.\n'{e.Message}'");
            }
        }

        public static bool IsValidInstance(string instanceName, StringComparison comparisonType = StringComparison.OrdinalIgnoreCase)
        {
            foreach (Instance instance in GetInstances())
            {
                if (!instance.Name.Equals(instanceName, comparisonType)) continue;
                return IsValidInstance(instance);
            }
            return false;
        }
        public static bool IsValidInstance(Instance instance)
        {
            return Path.Exists(instance.BepInExPath)
                   && Path.Exists(instance.ServerExePath);
        }

        public static void SetGroup(Instance instance, string group)
        {
            instance.Config.Group = group;
        }
    }
}

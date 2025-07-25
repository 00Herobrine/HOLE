﻿using System.Diagnostics;
using HOLE.Assets.Scripts.Utils;

namespace HOLE.Assets.Scripts
{
    public class Instance
    {
        public readonly string Folder;
        public readonly string Name;
        public string BepInExPath => Path.Combine(Folder, "BepInEx");
        public string PluginsPath => Path.Combine(BepInExPath, "plugins");
        public string UserPath => Path.Combine(Folder, "user");
        public string ServerExePath => Path.Combine(Folder, "spt.server.exe");
        public string UserCachePath => Path.Combine(UserPath, "cache");
        public string ModsPath => Path.Combine(UserPath, "mods");
        public string ProfilesPath => Path.Combine(UserPath, "profiles");

        public Process[] GameProcess { get; private set; } = [];
        public Instance(string folder)
        {
            Folder = folder;
            Name = Folder.Split(Path.DirectorySeparatorChar).Last();
        }
        
    }
    public static class InstanceManager
    {
        public static string InstancesFolder => Launcher.Config.Paths.Instances;
        private static List<Instance> _instances = new();
        //public static InstanceFolder SelectedInstance { get; private set; }
        //public static Action? InstancesLoadedEvent;
        //public static Action? InstanceSelectedEvent;

        public static async void LoadInstances()
        {
            _instances = await LoadInstancesFromDirectory();
        }

        private static async Task<List<Instance>> LoadInstancesFromDirectory()
        {
            FileManagement.DirectoryCheck(InstancesFolder);
            List<Instance> instances = [];
            foreach (var instanceFolder in Directory.GetDirectories(InstancesFolder))
            {
                Instance instance = new Instance(instanceFolder);
                instances.Add(instance);
            }
            return await Task.FromResult(instances);
        }

        public static List<Instance> GetInstances()
        {
            return _instances;
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

        public static bool IsValidInstance(string instanceName, StringComparison comparisonType = StringComparison.OrdinalIgnoreCase)
        {
            foreach (Instance instance in _instances)
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
    }
}

﻿using Aki.Launcher.MiniCommon;
using HOLE.Scripts.Aki;
using HOLE.Scripts.Launcher;
using HOLE.Scripts.Misc;
using System.ComponentModel;
using System.Text.Json;

namespace HOLE.Scripts
{
    internal static class InstanceManager
    {
        public static AkiInstance? SelectedInstance { get; private set; } 
        public static Dictionary<string, AkiInstance> Instances { get; private set; } = new();
        public static event EventHandler<InstanceEventArgs>? InstanceChangingEvent;
        public static event EventHandler<InstanceEventArgs>? InstanceChangedEvent;
        public static event EventHandler<InstanceEventArgs>? InstanceAddedEvent;
        public static event EventHandler<InstanceEventArgs>? InstanceRemovedEvent;

        public static void Cache()
        {
            Instances.Clear();
            foreach (string InstancePath in Directory.GetDirectories(Settings.InstancesPath)) 
                Add(InstancePath);
        }
        public static AkiInstance? Get(string name) => Instances.TryGetValue(name, out AkiInstance instance) ? instance : null;
        public static void Add(string Path) => Add(new AkiInstance(Path));
        public static void Add(AkiInstance Instance)
        {
            string name = Instance.Name;
            if (Instances.ContainsKey(name)) Logger.Log($"{name} is already in use.");
            Instances.Add(name, Instance);
            InstanceAddedEvent?.Invoke(null, new InstanceEventArgs(Instance));
            Logger.Log($"Added Instance {name}.");
        }
        public static void Remove(string name)
        {
            AkiInstance? instance = Instances[name];
            if (Instances.Remove(name)) InstanceRemovedEvent?.Invoke(null, new InstanceEventArgs(instance));
        }

        internal static void SetSelected(AkiInstance? selectedInstance)
        {
            var args = new InstanceEventArgs(selectedInstance);
            InstanceChangingEvent?.Invoke(null, args);
            if (args.Cancel) return;
            SelectedInstance = selectedInstance;
            InstanceChangedEvent?.Invoke(null, args);
        }

        private static Dictionary<string, InstanceManagerForm> Managers = new(); // InstanceName, ManagerForm
        internal static void Open(AkiInstance selectedInstance)
        {
            string InstanceName = selectedInstance.Name;
            if (Managers.TryGetValue(InstanceName, out InstanceManagerForm? form))
            {
                if (form.IsDisposed)
                    Managers[InstanceName] = new InstanceManagerForm(selectedInstance);
                form = Managers[InstanceName];
            }
            else form = new InstanceManagerForm(selectedInstance);
            form.Show();
        }
    }

    public class InstanceEventArgs(AkiInstance? newInstance) : CancelEventArgs
    {
        public AkiInstance? Instance { get; } = newInstance;
    }

    public struct AkiInstance
    {
        public readonly string Directory { get; }
        public readonly string Name { get; }
        public readonly string ConfigPath => Path.Combine(Directory, "config.json");
        public readonly string AkiDataPath => Path.Combine(Directory, "Aki_Data");
        public readonly string ServerPath => Path.Combine(AkiDataPath, "Server");
        public readonly string DatabasePath => Path.Combine(ServerPath, "database");
        public readonly string HideoutPath => Path.Combine(DatabasePath, "hideout");
        public readonly string ProductionPath => Path.Combine(HideoutPath, "production.json");
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
        public ServerManager ServerManager { get; }
        public AccountManager AccountManager { get; }
        public Request Request { get; }
        public AkiInstance(string InstanceDirectory)
        {
            Directory = InstanceDirectory;
            Name = Path.GetFileName(InstanceDirectory) ?? InstanceDirectory.Split(Path.DirectorySeparatorChar).Last();
            ConfigCheck();
            ServerManager = new(this);
            AccountManager = new(this);
            Request = new Request(null, Settings.LauncherSettings.ServerURL);
        }

        private static readonly JsonSerializerOptions options = new() { WriteIndented = true };
        public void ConfigCheck()
        {
            if (File.Exists(ConfigPath)) return;
            File.WriteAllText(ConfigPath, JsonSerializer.Serialize(new InstanceConfig() { IconPath = Path.Combine(Directory, "icon.png") }, options));
        }
    }

    public struct InstanceConfig
    {
        public string IconPath { get; set; }
    }
}

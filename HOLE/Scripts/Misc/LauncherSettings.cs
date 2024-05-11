using HOLE.Scripts.Presets;

namespace HOLE.Scripts.Misc
{
    public class LauncherSettings : Preset
    {
        public PresetInfo Preset { get; set; }
        #region Paths
        public string LauncherDataPath { get; set; }
        public string InstancesPath { get; set; }
        public string ModsPath { get; set; }
        public string DownloadPath { get; set; }
        public string DownloadModsPath { get; set; }
        public string DownloadIconsPath { get; set; }
        public string BackupsPath { get; set; }
        public string PresetsPath { get; set; }
        public string IconPacksPath { get; set; }
        public string ServerIP { get; set; }
        public string ServerPort { get; set; }
        public string ServerURL => $"{ServerIP}:{ServerPort}";
        public int BufferSize { get; set; }
        #endregion

        public LauncherSettings()
        {
            Preset = new();
            LauncherDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "HerosLauncher");
            InstancesPath = Path.Combine(LauncherDataPath, "Instances");
            ModsPath = Path.Combine(LauncherDataPath, "Mods");
            DownloadPath = Path.Combine(LauncherDataPath, "Download");
            DownloadModsPath = Path.Combine(DownloadPath, "Mods");
            DownloadIconsPath = Path.Combine(DownloadPath, "Icons");
            BackupsPath = Path.Combine(LauncherDataPath, "Backups");
            PresetsPath = Path.Combine(LauncherDataPath, "Presets");
            IconPacksPath = Path.Combine(LauncherDataPath, "Icons");
            ServerIP = "127.0.0.1";
            ServerPort = "6969";
            BufferSize = 8192; // 8KB
        }
    }
    public struct PresetInfo()
    {
        public string? Name { get; set; }
        public string Version { get; set; } = FileUtils.GetProjectVersion().ToString();
        public bool MinimizeLauncher { get; set; } = false;
        public bool AutoLaunch { get; set; } = false;
        public bool AutoStartAki { get; set; } = false;
        public bool AutoKillAki { get; set; } = false;
        public string Prefix { get; set; } = "[H.O.L.E]";
        public string Language { get; set; } = "en";
        public bool Debug { get; set; } = false;
    }
}

namespace HOLE.Scripts.Misc
{
    public class LauncherSettings
    {
        public LauncherSettings()
        {
            LauncherPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "HerosLauncher");
            InstancesPath = Path.Combine(LauncherPath, "Instances");
            ModsPath = Path.Combine(LauncherPath, "Mods");
            DownloadingModsPath = Path.Combine(ModsPath, "Downloading");
            BackupsPath = Path.Combine(LauncherPath, "backups");
        }
        public string Version { get; internal set; } = FileUtils.GetProjectVersion();
        public bool MinimizeLauncher { get; internal set; } = false;
        public bool AutoLaunch { get; internal set; } = false;
        public bool AutoStartAki { get; internal set; } = false;
        public bool AutoKillAki { get; internal set; } = false;
        public string Prefix { get; internal set; } = "[H.O.L.E]";
        public string Language { get; internal set; } = "en";
        public bool Debug { get; internal set; } = false;

        // Paths
        public string LauncherPath { get; internal set; }
        public string InstancesPath { get; internal set; }
        public string ModsPath { get; internal set; }
        public string DownloadingModsPath { get; internal set; }
        public string BackupsPath { get; internal set; }

        public override string ToString()
        {
            return $"Version: {Version},\n" +
                $"MinimizeLauncher: {MinimizeLauncher},\n" +
                $"AutoLaunch: {AutoLaunch}\n" +
                $"AutoStartAki: {AutoStartAki}\n" +
                $"AutoKillAki: {AutoKillAki}\n" +
                $"Prefix: {Prefix}\n" +
                $"LauncherPath: {LauncherPath}\n" +
                $"InstancesPath: {InstancesPath}\n" +
                $"ModsPath: {ModsPath}\n" +
                $"DownloadingPath: {DownloadingModsPath}\n" +
                $"BackupsPath: {BackupsPath}\n";
        }
    }
}

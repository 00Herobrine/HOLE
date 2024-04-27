namespace HOLE.Scripts
{
    internal struct LauncherSettings()
    {
        public string Version { get; set; } = FileUtils.GetProjectVersion();
        public int Lang { get; set; } = 0;
        public bool MinimizeLauncher { get; set; } = false;
        public bool AutoLaunch { get; set; } = false;
        public bool AutoStartAki { get; set; } = false;
        public bool AutoKillAki { get; set; } = false;
        
        // Important Stuff
        public string Prefix { get; private set; } = "[H.O.L.E]";
        public string LauncherPath { get; private set; } = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}{Path.DirectorySeparatorChar}HerosLauncher";
        public string InstancesPath { get; private set; } = $"{Settings.LauncherPath}{Path.DirectorySeparatorChar}Instances";
        public string ModsPath { get; private set; } = $"{Settings.LauncherPath}{Path.DirectorySeparatorChar}Mods";
        public string DownloadingModsPath { get; private set; } = $"{Settings.ModsPath}/Downloading";
        public static string BackupsPath { get; private set; } = $"{Settings.LauncherPath}{Path.DirectorySeparatorChar}Backups";
        public static bool Debug { get; private set; } = false;

        public override string ToString()
        {
            return $"Version: {Version},\n" +
                $"Lang: {Lang},\n" +
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

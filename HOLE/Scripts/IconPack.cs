namespace HOLE.Scripts
{
    public struct IconPack
    {
        public string PackDirectory { get; set; }
        public readonly string[] Files => Directory.GetFiles(PackDirectory);
        public readonly string InstancesPath => Path.Combine(PackDirectory, "Instances");
        public readonly string[] InstanceImages => Directory.GetFiles(InstancesPath);
        public readonly string FactionsPath => Path.Combine(PackDirectory, "Factions");
        public readonly FactionIcons FactionIcons { get; }
        public readonly string LauncherPath => Path.Combine(PackDirectory, "Launcher");
        public readonly LauncherIcons LauncherIcons { get; }
        public IconPack(string PackDirectory)
        {
            this.PackDirectory = PackDirectory;
            FactionIcons = new FactionIcons(FactionsPath);
            LauncherIcons = new LauncherIcons(LauncherPath);
        }
    }
    public struct Icon(string path)
    {
        public readonly string IconPath { get; } = path;
        public readonly Image Image => Image.FromFile(IconPath);
    }
    public struct FactionIcons(string IconsDirectory)
    {
        public string IconsDirectory { get; set; } = IconsDirectory;
        public readonly Icon USEC { get; } = new Icon(Path.Combine(IconsDirectory, "USEC.png"));
        public readonly Icon BEAR { get; } = new Icon(Path.Combine(IconsDirectory, "BEAR.png"));
        public readonly string[] Files => Directory.GetFiles(IconsDirectory);
    }
    public struct LauncherIcons(string IconsDirectory)
    {
        public string IconsDirectory { get; set; } = IconsDirectory;
        public Icon AddInstanceButton { get; } = new Icon(Path.Combine(IconsDirectory, "AddInstance.png"));
        public Icon FoldersButton { get; } = new Icon(Path.Combine(IconsDirectory, "Folders.png"));
        public readonly string[] Files => Directory.GetFiles(IconsDirectory);
    }
}

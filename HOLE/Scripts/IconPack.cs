namespace HOLE.Scripts
{
    public readonly struct IconPack
    {
        public readonly string PackDirectory { get; }
        public readonly string[] Files => Directory.GetFiles(PackDirectory);
        public readonly string InstancesPath => Path.Combine(PackDirectory, "Instances");
        public readonly InstanceIcons Instances { get; }
        public readonly string FactionsPath => Path.Combine(PackDirectory, "Factions");
        public readonly FactionIcons Factions { get; }
        public readonly string LauncherPath => Path.Combine(PackDirectory, "Launcher");
        public readonly LauncherIcons Launcher { get; }
        public IconPack(string PackDirectory)
        {
            this.PackDirectory = PackDirectory;
            Factions = new FactionIcons(FactionsPath);
            Launcher = new LauncherIcons(LauncherPath);
            Instances = new InstanceIcons(InstancesPath);
        }
    }
    public readonly struct Icon(string path)
    {
        public readonly string IconPath { get; } = path;
        public readonly Image? Image => File.Exists(IconPath) ? Image.FromFile(IconPath) : null;
    }
    public readonly struct FactionIcons(string IconsDirectory)
    {
        public readonly string IconsDirectory { get; } = IconsDirectory;
        public readonly Icon USEC { get; } = new Icon(Path.Combine(IconsDirectory, "USEC.png"));
        public readonly Icon BEAR { get; } = new Icon(Path.Combine(IconsDirectory, "BEAR.png"));
        public readonly string[] Files => Directory.GetFiles(IconsDirectory);
    }
    public readonly struct LauncherIcons(string IconsDirectory)
    {
        public readonly string IconsDirectory { get; } = IconsDirectory;
        public Icon AddInstanceButton { get; } = new Icon(Path.Combine(IconsDirectory, "AddInstance.png"));
        public Icon FoldersButton { get; } = new Icon(Path.Combine(IconsDirectory, "Folders.png"));
        public readonly string[] Files => Directory.GetFiles(IconsDirectory);
    }

    public readonly struct InstanceIcons
    {
        private static readonly string[] AllowedImageExtensions = [".png", ".jpg", ".jpeg", ".gif"];
        public readonly string IconsDirectory { get; }
        public readonly Icon[] Icons { get; }
        public InstanceIcons(string IconsDirectory)
        {
            this.IconsDirectory = IconsDirectory;
            List<Icon> iconList = [];
            foreach(string file in Directory.GetFiles(IconsDirectory))
            {
                string ext = Path.GetExtension(file);
                if (AllowedImageExtensions.Contains(ext)) iconList.Add(new Icon(file));
            }
            Icons = [.. iconList];
            Logger.Log($"Stored {iconList.Count} Instance Images.");
        } 
    }
}

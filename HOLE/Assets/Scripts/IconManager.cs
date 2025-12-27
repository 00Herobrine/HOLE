namespace HOLE.Assets.Scripts
{
    public static class IconManager
    {
        public static string IconsFolder => Launcher.Config.Paths.Icons;
        public static string ThemesFolder => Launcher.Config.Paths.Themes;
        //public static string DefaultPackFolder => Path.Combine(IconPacksFolder, DefaultPackPath);
        public static string[] AllowedImageTypes = [".png", ".jpg", ".jpeg", ".gif", ".ico", ".bmp"];

        private static IconPack _currentPack;

        public static Action<IconPack>? IconPackUpdatedEvent;

        public static async Task InitializeAsync()
        {
            if(!Directory.Exists(ThemesFolder))
            {
                Logger.Info("Themes folder not found");
            }

            foreach(var dir in Directory.GetDirectories(ThemesFolder))
            {
                Logger.Info($"Found '{dir}' in ThemesFolder");
                LoadIconPack(dir);
            }
            await Task.CompletedTask;
        }

        public static void LoadIconPack(string dir)
        {
            if (_currentPack.PackPath != dir)
            {
                //_currentPack = new IconPack(dir);
                //IconPackUpdatedEvent?.Invoke(_currentPack);
            }
            Logger.Info($"Loaded Theme {dir}.");
        }

        public static List<string> GetInstanceIconPaths()
        {
            List<string> paths = new();
            foreach (string file in Directory.GetFiles(Launcher.Config.Paths.Icons))
            {
                string fileType = Path.GetExtension(file);
                if (!AllowedImageTypes.Contains(fileType, StringComparer.OrdinalIgnoreCase))
                    continue;
                paths.Add(file);
            }
            return paths;
        }
        public static List<Image> GetInstanceIcons()
        {
            List<Image> icons = new();
            foreach (string file in GetInstanceIconPaths())
            {
                icons.Add(Image.FromFile(file));
            }
            return icons;
        }

        public static Image? GetInstanceIcon(string name, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            foreach (string iconPath in GetInstanceIconPaths())
            {
                string fileName = Path.GetFileNameWithoutExtension(iconPath);
                if(fileName.Equals(name, comparison))
                    return Image.FromFile(iconPath);
            }
            return null;
        }
    }
}

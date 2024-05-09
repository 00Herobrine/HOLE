using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Archives.SevenZip;
using SharpCompress.Archives.Zip;

namespace HOLE.Scripts.Mod_Management
{
    public static class ModManager
    {
        public const string BepInEx = "BepInEx/";
        public const string UserMods = "user/mods/";
        public static string? PluginsPath => InstanceManager.SelectedInstance?.PluginsPath;
        public static string? ModsPath => InstanceManager.SelectedInstance?.ModsPath;
        public static async Task<bool> CreateJunction(string modPath, Instance instance)
        {
            return false;
        }
        public static async Task ExtractMod(string filepath, Instance? instance) => await ExtractMod(filepath, instance?.Directory ?? Settings.ModsPath);
        public static async Task ExtractMod(string filepath, string extractPath)
        {
            await Task.Delay(0);
            try
            {
                string ModName = Path.GetFileNameWithoutExtension(filepath);
                if (!Directory.Exists(extractPath)) Directory.CreateDirectory(extractPath);
                string extension = Path.GetExtension(filepath).ToLower();
                IArchive? archive = null;
                switch (extension)
                {
                    case ".7z":
                        archive = SevenZipArchive.Open(filepath);
                        break;
                    case ".rar":
                        archive = RarArchive.Open(filepath);
                        break;
                    case ".zip":
                        archive = ZipArchive.Open(filepath);
                        break;
                    case ".dll":
                        File.Move(filepath, Path.Combine(extractPath, Path.GetFileName(filepath)));
                        break;
                    default:
                        break;
                }
                if (archive == null) return;
                var entries = archive.Entries;
                string extractedPath = Path.Combine(extractPath, ModName);
                bool subrooted = false;

                //Logger.Log($"{entry.Key} || {entry.IsDirectory}");
                //archive.ExtractToDirectory(extractedPath);
                ModFolder modFolder = new(extractedPath);
                Logger.Log($"{ModName} Info => Count:{entries.Count()}, {entries.ToArray()}");
                Logger.Log($"Extracted {ModName} to {extractedPath}");
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
        }
        public struct ModArchive
        {
            public readonly IArchive Archive { get; }
            public List<IArchiveEntry> BepInExEntries { get; set; } = [];
            public List<IArchiveEntry> UserModEntries { get; set; } = [];

            public ModArchive(IArchive archive)
            {
                // Detect for UserMod Files in main dir
                // check if starts with BepInEx or UserMod
                // if not check for BepInEx and UserMod path
                // if paths not in maindir then Subrooted = true;
                // if no paths found then why tf did it get passed
                Archive = archive;
                foreach(IArchiveEntry entry in archive.Entries)
                {
                    string? entryPath = entry.Key;
                    if (entryPath == null) continue;
                    bool subrooted = IsSubrooted(entry);
                    Logger.Log($"Entry subrooted? {subrooted} | {entryPath}");
                    //if(IsSubrooted(entry) && !Subrooted) Subrooted = true;
                    if(IsBepInExFile(entry)) BepInExEntries.Add(entry);
                    else if(IsUserModFile(entry)) UserModEntries.Add(entry);
                }
            }
            private static bool IsSubrooted(IArchiveEntry entry)
            {
                string? path = entry.Key;
                if (path == null) return false;
                return Directory.GetParent(path) != null;
            }
            private static bool IsBepInExFile(IArchiveEntry entry)
            {
                string? path = entry.Key;
                if (path == null) return false;
                if (Path.GetExtension(path).Equals(".dll", StringComparison.OrdinalIgnoreCase)) return true;
                return false;
            }
            private static bool IsUserModFile(IArchiveEntry entry)
            {
                string? path = entry.Key;
                if (path == null) return false;
                return false;
            }

            private void ExtractUserMod(string instancePath)
            {
                foreach(var entry in UserModEntries) entry.WriteToDirectory(Path.Combine());
            }
        }
        public static async void LoadSharedMods()
        {
            await Task.Run(async () => // Don't want this to hold up the main thread as it's taxing :3
            {
                if (!Directory.Exists(Settings.DownloadModsPath)) Directory.CreateDirectory(Settings.DownloadModsPath);
                foreach (string dir in Directory.GetFileSystemEntries(Settings.DownloadModsPath))
                    await ExtractMod(dir, Settings.ModsPath);
            });
        }
    }
    
}

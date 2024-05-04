using HOLE.Scripts.Misc;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Archives.SevenZip;
using SharpCompress.Archives.Zip;
using System.Text.Json;

namespace HOLE.Scripts.Mod_Management
{
    public static class ModManager
    {
        public static readonly string BepInEx = "BepInEx/";
        public static readonly string UserMods = "User/mods/";
        public static string? PluginsPath => InstanceManager.SelectedInstance?.PluginsPath;
        public static string? ModsPath => InstanceManager.SelectedInstance?.ModsPath;
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
            public readonly bool Subrooted { get; }
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
                List<IArchiveEntry> rootFolders = archive.GetRootFolders();
                List<IArchiveEntry> rootFiles = archive.GetRootFiles();
                bool hasDll = false;
                bool hasUserModFiles = false;
                DetectModFiles();
/*                foreach (var entry in archive.Entries)
                {
                    string? entryPath = entry.Key;
                    if (entryPath == null) continue;
                    if(entryPath.Contains(BepInEx))
                    {
                        if (!entryPath.StartsWith(BepInEx) && !Subrooted) Subrooted = true;

                    }
                    if ((!entryPath.StartsWith(BepInEx) || !entryPath.StartsWith(UserMods)) && !Subrooted) 
                        Subrooted = true;
                    if (entryPath.Contains(BepInEx)) BepInExEntries.Add(entry);
                    else if(entryPath.Contains(UserMods)) UserModEntries.Add(entry);
                }*/
            }
            private void DetectModFiles() => DetectModFiles(null);
            private void DetectModFiles(string? subdir)
            {

            }
            public void Extract()
            {

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
    public struct ModFolder
    {
        public readonly string directory;
        public readonly string ConfigPath;
        public ModConfig Config { get; private set; }
        public static readonly JsonSerializerOptions Options = new() { WriteIndented = true };
        public ModFolder(string directory)
        {
            this.directory = directory;
            this.ConfigPath = Path.Combine(directory, "config.json");
            if (!directory.Contains(Settings.LauncherPath) || !Directory.Exists(directory)) return;
            InitializeConfig();
        }

        internal void InitializeConfig()
        {
            if (!File.Exists(ConfigPath))
            {
                ModConfig config = new ModConfig();
                File.WriteAllText(ConfigPath, JsonSerializer.Serialize(new ModConfig(), Options));
                Logger.Log($"Created ModConfig for {Path.GetDirectoryName(directory)} at {ConfigPath}");
            }
            else Config = JsonSerializer.Deserialize<ModConfig>(File.ReadAllText(ConfigPath));
        }
    }
    public struct ModFile
    {
        public string[] BepInExPlugins { get; private set; } = [];
        public string[] UserMods { get; private set; } = [];
        public ModFile(string FilePath)
        {

        }
    }
    public enum ModType
    { 
        BepInEx, // Client
        User // Server
    }
    public struct Mod
    {
        public ModConfig Config { get; set; }
        public ModType[] Type { get; set; }
        public string ConfigPath { get; set; }
    }
    public struct ModConfig
    {
        public string URL { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
        public string AkiVersion { get; set; }
        public bool AutoUpdate { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime DownloadedAt { get; set; }
    }
}

using HtmlAgilityPack;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HOLE.Scripts.Mod_Management
{
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
    public struct ModsConfig
    {
        public DateTime? Generated { get; set; }
        public ModCard[] Downloads { get; set; }
    }
    public readonly struct BasicModsConfig
    {
        [JsonPropertyName("last_updated")]
        public readonly DateTime? LastUpdated;
        [JsonPropertyName("mod_data")]
        public readonly BasicModCard[] Mods;
        [JsonPropertyName("versions")]
        public readonly AkiVersionLabel[] Versions;
    }
    public struct AkiVersionLabel
    {
        [JsonPropertyName("count")]
        public readonly int Count;
        [JsonPropertyName("colour")]
        public readonly string Colour;
    }
   
}

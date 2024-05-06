using HtmlAgilityPack;
using System.Text.Json;

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
    public struct BasicModsConfig
    {
        public DateTime? last_updated { get; set; }
        public BasicModCard[] mod_data { get; set; }
    }
    public interface IModCard
    {
        public string name { get; }
        public string description { get; }
        //public string version { get; } // mod version
        public string versionLabel { get; } // Aki Version
        public string link { get; }
        public string featured { get; }
        public string downloads { get; }
    }
    public struct BasicModCard : IModCard
    {
        public string ID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string version { get; set; }  // mod version
        public string versionLabel { get; set; }  // aki version
        public string link { get; set; }
        public string featured { get; set; }
        public string downloads { get; set; }
        public readonly string AkiVersion => versionLabel.Replace("SPT-AKI", "").Trim();
        public readonly bool IsFeatured => featured.Equals("1");
    }
    public struct ModCard : IModCard
    {
        public string name { get; set; }
        public string description { get; set; }
        public string featured { get; set; }
        public string downloads { get; set; }
        public string link { get; set; }
        public int ModID { get; set; }
        public string versionLabel { get; set; }
        public string LastUpdated { get; set; }
        public string? Comments { get; set; }
        public string? Reactions { get; set; }
        public string? ImageURL { get; set; }
        public string? ImageName { get; set; }
        public readonly string? ImagePath => ImageName != null ? Path.Combine(Settings.DownloadPath, ImageName) : null;

        public async void CacheImage() => await ModDownloader.CacheImage(this); 
        readonly bool Featured => featured.Equals("1");

        public ModCard(HtmlNode fileCard)
        {
            HtmlNode box = fileCard.SelectSingleNode(".//a[@class='box128']");
            HtmlNode iconNode = box.SelectSingleNode(".//div[@class='filebaseFileIconContainer']");
            HtmlNode dataNode = box.SelectSingleNode(".//div[@class='filebaseFileDataContainer']");
            HtmlNodeCollection fileStats = fileCard.SelectSingleNode(".//ul[@class='inlineList filebaseFileStats']").SelectNodes(".//li");
            HtmlNodeCollection labelList = fileCard.SelectSingleNode(".//ul[@class='labelList']").SelectNodes(".//li");
            name = dataNode.SelectSingleNode(".//h3[@class='filebaseFileSubject']").InnerText.Trim();
            description = dataNode.SelectSingleNode(".//div[@class='containerContent filebaseFileTeaser']").InnerText.Trim();
            featured = iconNode.SelectSingleNode(".//span[starts-with(@class, 'badge label') and contains(@class, 'jsLabelFeatured')]").InnerText.Trim();
            //Downloads = int.Parse(fileStats[0].InnerText.Replace("Download", "").Replace("s", "").Trim());
            link = box.Attributes["href"].Value;
            ModID = int.Parse(link.Split("files/file/")[1].Split("-")[0]);
            versionLabel = labelList[0].InnerText.Replace("SPT-AKI", "").Trim(); // AkiVersion
            LastUpdated = dataNode.SelectSingleNode(".//time[@class='datetime']").InnerText;
            ImageURL = iconNode.GetAttributeValue("src", null);
            ImageName = ImageURL?.Split(Path.PathSeparator)[^1] ?? $"{ModID}.{Path.GetExtension(ImageURL)}";
            if (!File.Exists(ImagePath)) CacheImage();
        }
    }
}

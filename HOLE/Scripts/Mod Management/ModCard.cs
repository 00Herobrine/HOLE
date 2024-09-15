using HtmlAgilityPack;

namespace HOLE.Scripts.Mod_Management
{
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
            downloads = fileStats[0].InnerText.Replace("Download", "").Replace("s", "").Trim();
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

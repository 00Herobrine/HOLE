namespace HOLE.Scripts
{
    internal static class ModDownloader
    {
    }

    public struct ModDownload
    {
        public string URL { get; private set; }
        public ModDownload(string URL)
        {
            this.URL = URL;
        }
    }
}

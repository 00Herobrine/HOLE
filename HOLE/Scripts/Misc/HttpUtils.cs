using System.Net.Http.Headers;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace HOLE.Scripts.Misc
{
    public enum URLOrigin 
    {
        UNKNOWN,
        [String("dropbox.com")]
        DROPBOX,
        [String("github.com")]
        GITHUB,
        [String("drive.google.com")]
        GOOGLE,
        [String("mediafire.com")]
        MEDIAFIRE,
        [String("mega.nz")]
        MEGA,
        [String("sp-tarkov.com")]
        SPT
    }
    public static class HttpUtils
    {
        public static URLOrigin DetermineOrigin(string URL)
        {
            foreach(URLOrigin origin in Enum.GetValues(typeof(URLOrigin)))
                if(origin.GetStringAttribute()?.Validate(URL) ?? false) return origin;
            return URLOrigin.UNKNOWN; // UNKNOWN if no URL matches
        }

        internal static async Task<HttpResponseMessage> QueryPage(HttpClient client, string URL)
        {
            // Validate URL, don't wanna just query anything :3
            Logger.Log($"Querying {URL}");
            HttpResponseMessage response = new();
            try
            {
                response = await client.GetAsync(URL);
                response.EnsureSuccessStatusCode();
                return response;
            }
            catch (Exception ex) { Logger.Log(ex.Message); }
            return response;
        }
        public static string GetFileNameFromContentHeaders(HttpContentHeaders headers)
        {
            string? fileName = null;
            if (headers.ContentDisposition != null)
                fileName = headers.ContentDisposition.FileName;

            if (string.IsNullOrEmpty(fileName))
                fileName = "downloaded_file"; // You can specify any default name here

            fileName = Path.GetFileName(fileName);
            return fileName;
        }
        public static async Task<bool> HasDirectDownload(HttpContent Content)
        {
            string htmlContent = await Content.ReadAsStringAsync();
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(htmlContent);
            string fileName = GetFileNameFromContentHeaders(Content.Headers);
            string fileType = Path.GetExtension(fileName.TrimEnd('"'));
            bool allowed = FileUtils.IsAllowedFileType(fileType);
            Logger.Log($"HasDirectDownload for {fileName} | {fileType} | {allowed}");
            return FileUtils.IsAllowedFileType(fileType);
        }
    }
}

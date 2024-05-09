using HOLE.Scripts.Mod_Management;
using SharpCompress.Archives;
using System.Diagnostics;
using System.Reflection;

namespace HOLE.Scripts.Misc
{
    public static class FileUtils
    {
        public static string ConvertBytesToString(this long bytes)
        {
            string[] suffixes = { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            const int bytesInKilobyte = 1024;
            if (bytes == 0)
            {
                return "0" + suffixes[0];
            }
            var magnitude = Math.Abs(bytes);
            var magnitudeIndex = (int)Math.Floor(Math.Log(magnitude, bytesInKilobyte));
            var adjustedValue = magnitude / Math.Pow(bytesInKilobyte, magnitudeIndex);
            return (bytes < 0 ? "-" : "") + $"{adjustedValue:0.##} {suffixes[magnitudeIndex]}";
        }
        public static Version GetProjectVersion()
        {
            Assembly assembly = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
            Version? version = assembly.GetName().Version;
            return version ?? new Version("0.0.0.0");
        }

        public static void OpenExplorer(string path)
        {
            Process.Start("explorer", path);
        }

        public static List<IArchiveEntry> GetRootFiles(this IArchive archive)
        {
            return archive.Entries
                .Where(entry => !entry.IsDirectory && entry.Key.Contains('.'))
                .Select(entry => entry)
                .Distinct()
                .ToList();
        }

        public static void OpenForm<T>() where T : Form, new()
        {
            var existingForm = Application.OpenForms.OfType<T>().FirstOrDefault();
            if (existingForm == null || existingForm.IsDisposed)
                existingForm = new T();
            if (!existingForm.Visible)
                existingForm.Show();
            else existingForm.BringToFront();
        }

        public static List<IArchiveEntry> GetRootFolders(this IArchive archive)
        {
            return archive.Entries
            .Select(entry => entry)
            .Distinct()
            .ToList();
        }

        public static bool IsDLL(string path) => File.Exists(path) && string.Equals(Path.GetExtension(path), ".dll", StringComparison.OrdinalIgnoreCase);

        public static readonly string[] AllowedFileTypes = [".dll", ".zip", ".7z", ".rar"];
        internal static bool IsAllowedFileType(string? v) => v != null && AllowedFileTypes.Contains(v);
        public static FileType? GetType(string extension)
        {
            foreach (FileType type in Enum.GetValues(typeof(FileType)))
                if(type.GetStringAttribute()?.Value == extension) return type;
            return null;
        }
    }
}

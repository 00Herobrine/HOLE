using SharpCompress.Archives;
using System.Diagnostics;
using System.Reflection;

namespace HOLE.Scripts.Misc
{
    public static class FileUtils
    {
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

    }
}

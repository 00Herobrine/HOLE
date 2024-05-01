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
    }
}

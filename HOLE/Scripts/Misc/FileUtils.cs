using System.Reflection;

namespace HOLE.Scripts.Misc
{
    public static class FileUtils
    {
        public static string GetProjectVersion()
        {
            // Get the entry assembly of the application
            Assembly assembly = Assembly.GetEntryAssembly();

            // If the entry assembly is null, fallback to executing assembly
            if (assembly == null)
                assembly = Assembly.GetExecutingAssembly();

            // Retrieve the assembly version
            Version version = assembly.GetName().Version;

            // Convert the version to string
            return version.ToString();
        }
    }
}

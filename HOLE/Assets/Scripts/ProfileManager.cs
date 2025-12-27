using System.Diagnostics;

namespace HOLE.Assets.Scripts
{
    /*public class Profile
    {
        public string ProfilePath { get; }
        public string Name { get; set; }

        public Profile(string filePath)
        {
            ProfilePath = filePath;
            Name = Path.GetDirectoryName(filePath) ?? "INVALID DIRECTORY";
        }

        public override string ToString()
        {
            return $"{Name} @ {ProfilePath}";
        }
    }

    public static class ProfileManager
    {
        private static string[] AllowedFileExtensions = [".json"];
        public static string ProfilesFolder = Path.Combine(Launcher.UserFolder, "profiles");
        public static List<Profile> Instances { get; private set; } = new();
        public static void LoadInstances()
        {
            if (!Path.Exists(ProfilesFolder)) return;
            foreach (var profileFile in Directory.GetFiles(ProfilesFolder))
            {
                foreach(string fileExtension in AllowedFileExtensions)
                {
                    if (!profileFile.GetFileExtension().Equals(fileExtension, StringComparison.OrdinalIgnoreCase)) return;
                    Profile profile = new Profile(profileFile);
                    Debug.WriteLine($"Added new Profile " + profile);
                }
            }
        }
    }*/
}

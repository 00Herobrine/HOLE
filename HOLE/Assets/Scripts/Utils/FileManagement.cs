using System.Diagnostics;

namespace HOLE.Assets.Scripts.Utils
{
    public static class FileManagement
    {
        public static bool IsDllFile(string entryKey) => entryKey.EndsWith(".dll", StringComparison.OrdinalIgnoreCase);
        public static string[] GetContents(string[] paths)
        {
            List<string> filePaths = new();
            foreach(string path in paths)
            {
                foreach(string dir in Directory.GetDirectories(path)) filePaths.Add(dir);
                foreach (string file in Directory.GetFiles(path)) filePaths.Add(file);
            }
            return filePaths.ToArray();
        }

        public static bool CreateJunction(string sourcePath, string targetPath) // symlink without the admin privileges
        {
            if (!Directory.Exists(sourcePath))
            {
                Logger.Warn($"Source directory '{sourcePath}' does not exist.");
                return false;
            }
            
            string fullFileName = Path.GetFileName(sourcePath);
            string shortFileName = Path.GetFileNameWithoutExtension(sourcePath);
            /*if (File.Exists(sourcePath)) // This shouldn't be here as mods should be extracted to their own folders prior to junction
            {
                DirectoryInfo di = Directory.GetParent(sourcePath)!.CreateSubdirectory(shortFileName); // change to use mod name possibly
                Logger.Info("Writing file to " + di);
                File.Move(sourcePath, Path.Combine(di.ToString(), fullFileName));
                sourcePath = di.ToString();
            }*/
            
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();

                Logger.Info($"Junction create attempt {sourcePath} -> {Path.Combine(targetPath, shortFileName)}");
                StreamWriter sw = process.StandardInput;
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine($"mklink /J \"{Path.Combine(targetPath, shortFileName)}\" \"{sourcePath}\"");
                    sw.WriteLine("exit");
                }

                process.WaitForExit();
                process.Close();

                Logger.Info($"Created junction '{sourcePath}' successfully!");
                return true;
            }
            catch (Exception ex)
            {
                Logger.Warn($"Failed to create junction\n'{ex.Message}'");
                return false;
            }
        }
        
        public static bool DirectoryCheck(string folderPath)
        {
            if (Directory.Exists(folderPath)) return true;
            try
            {
                Directory.CreateDirectory(folderPath);
                Logger.Info($"Created directory '{folderPath}'");
                if (Directory.Exists(folderPath)) return true;
            } catch (Exception ex)
            {
                Logger.Warn($"Failed to create directory '{folderPath}'.\n'{ex.Message}'");
            }
            return false;
        }
    }
}

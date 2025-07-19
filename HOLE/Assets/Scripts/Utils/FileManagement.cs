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
            //Logger.Info($"Creating junction for '{sourcePath}'");
            if (File.Exists(sourcePath))
            {
                Logger.Warn($"Existing File for path");
                string fileName = Path.GetFileName(sourcePath);
                string shortName = fileName.Split(".")[0];
                DirectoryInfo di = Directory.GetParent(sourcePath)!.CreateSubdirectory(shortName); // change it to mod name possibly, fileName works similarly
                Debug.WriteLine("Writing file to " + di);
                File.Move(sourcePath, Path.Combine(di.ToString(), fileName));
                sourcePath = di.ToString();
            }
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();

                StreamWriter sw = process.StandardInput;
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine($"mklink /J \"{Path.Combine(targetPath, Path.GetFileName(sourcePath))}\" \"{sourcePath}\"");
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
            try
            {
                if (Directory.Exists(folderPath)) return false;
                Directory.CreateDirectory(folderPath);
                Logger.Info($"Created directory '{folderPath}'");
                return true;
            } catch (Exception ex)
            {
                Logger.Warn($"Failed to create directory '{folderPath}'.\n'{ex.Message}'");
            }
            return false;
        }
    }
}

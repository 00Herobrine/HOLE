using System.Diagnostics;

namespace HOLE.Scripts
{
    public static class Logger
    {
        public static async void LogAsync(params string[] args)
        {
            await Task.Run(() => { Log(args); });
        }
        public static void Log(params string[]? args)
        {
            if (!Settings.LauncherSettings.Preset.Debug || args == null) return;
            foreach(string arg in args)
                Debug.WriteLine(arg);
        }
    }
}

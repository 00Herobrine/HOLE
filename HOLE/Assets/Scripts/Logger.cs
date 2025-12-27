using System.Diagnostics;
using System.Text;

namespace HOLE.Assets.Scripts
{
    public enum LogLevel
    {
        None,
        Info,
        Warn,
        Error,
        Debug,
    }
    public static class Logger
    {
        public struct LogPrefix(string prefix)
        {
            public readonly string Prefix = prefix;
        }
        // Source, LogLevel?, string[]
        // [SPT] Started webserver at https://127.0.0.1:6969
        // [HOLE] [INFO] Successfully created LauncherConfig at '{location}'.
        // [HOLE] [WARN] Failed to create Instances folder '{location}'.
        public const string DefaultPrefix = "[HOLE]";
        public const string DefaultLoggerFormat = "[{Prefix}] [{LogLevel}] {Message}";
        public static readonly LogPrefix DefaultLogPrefix = new LogPrefix(DefaultPrefix);
        public static string Prefix => Launcher.Config.Logging.Prefix;

        public static void Exception(Exception ex) 
            => Log(DefaultLogPrefix, LogLevel.Error, ex.ToString());

        public static void Warn(params string[] args) 
            => Warn(DefaultLogPrefix, args);
        public static void Warn(LogPrefix? prefix = null, params string[] args)
        {
            prefix ??= DefaultLogPrefix;
            Log(prefix.Value, LogLevel.Warn, args);
        }

        public static void Info(params string[] args) 
            => Info(DefaultLogPrefix, args);
        public static void Info(LogPrefix? prefix = null, params string[] args)
        {
            prefix ??= DefaultLogPrefix;
            Log(prefix.Value, LogLevel.Info, args);
        }

        private static void Log(LogPrefix prefix, LogLevel? logLevel = LogLevel.None, params string[] args)
        {
            string logFormat = Launcher.Config.Logging.Format;
            if (logLevel == LogLevel.None) logLevel = null;
            foreach(string arg in args)
            {
                string formattedMessage = logFormat
                    .Replace("{Prefix}", prefix.Prefix)
                    .Replace("{LogLevel}", logLevel?.ToString() ?? "")
                    .Replace("{Level}", logLevel?.ToString() ?? "")
                    .Replace("{Message}", arg);
                Debug.WriteLine(formattedMessage);
            }
        }
    }
}

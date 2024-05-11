using Aki.Launcher;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace HOLE.Scripts
{
    public enum AkiStatus
    {
        OFFLINE,
        STARTING,
        ONLINE,
        BINDING,
    }
    internal partial class AkiManager
    {
        public static Process? AkiProcess { get; private set; } = null;
        public static Action<Instance>? AkiStartingEvent; // Aki Window Opened
        public static Action<Instance>? AkiStartedEvent; // Online
        public static Action<Instance>? AkiStoppedEvent; // Offline/Exited
        public static Action<AkiStatus>? AkiStatusEvent; // Status Changed
        private static AkiStatus status = AkiStatus.OFFLINE;
        public static AkiStatus Status // Property
        {
            get => status;
            set
            {
                if (status != value)
                {
                    status = value;
                    AkiStatusEvent?.Invoke(value); // Invoke event when Status changes
                }
            }
        }
        public const string AKI_SERVER = "aki.server";
        public const string AKI_SERVER_EXE = $"{AKI_SERVER}.exe";

        public static async Task<Process[]> GetProcessesAsync() => await Task.Run(GetProcesses);
        public static Process[] GetProcesses() => Process.GetProcessesByName(AKI_SERVER);
        public static async Task<bool> IsAkiRunningAsync() => await Task.Run(IsAkiRunning);
        public static bool IsAkiRunning() => GetProcesses().Length > 0;

        public static async Task<AkiStatus> CheckStatus()
        {
            try
            {
                bool akiRunning = await IsAkiRunningAsync();
                bool akiBound = false;
                if (akiRunning)
                    if (akiBound) return AkiStatus.ONLINE; // need to determine if it's starting
                    else return AkiStatus.OFFLINE;
            } catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
            return AkiStatus.OFFLINE;
        }

        public static async Task DetectAki()
        {
            try
            {
                Process[] activeAkis = await GetProcessesAsync();
                bool isActive = activeAkis.Length > 0;
                if (isActive && AkiProcess == null) // Not Bound so can't get info
                    Status = ServerManager.PingServer() ? AkiStatus.ONLINE : AkiStatus.OFFLINE; 
                foreach(Process akiProcess in activeAkis)
                {
                    if (akiProcess != AkiProcess) continue;
                    // the checked process is the current active server so check its status
                    Status = ServerManager.PingServer() ? AkiStatus.ONLINE : Status == AkiStatus.STARTING ? AkiStatus.STARTING : AkiStatus.OFFLINE;
                }
            } catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
            Status = AkiStatus.OFFLINE;
            await Task.CompletedTask;
        }

        public static async Task StartAkiAsync(Instance instance)
        {
            try
            {
                Process akiProcess = new();
                akiProcess.StartInfo.WorkingDirectory = instance.Directory;
                akiProcess.StartInfo.FileName = Path.Combine(instance.Directory, AKI_SERVER_EXE);
                //akiProcess.StartInfo.CreateNoWindow = true;
                akiProcess.StartInfo.UseShellExecute = false;
                akiProcess.StartInfo.RedirectStandardOutput = true;
                akiProcess.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                akiProcess.OutputDataReceived += ProcessAkiConsoleOutput;
                akiProcess.Exited += (sender, e) => // Listen for the Process Exit
                {
                    AkiStoppedEvent?.Invoke(instance);
                };
                if (akiProcess.Start()) AkiStartingEvent?.Invoke(instance);
                akiProcess.BeginOutputReadLine();
                AkiProcess = akiProcess;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
            await Task.CompletedTask;
        }

        public static async void KillAki()
        {
            bool isRunning = await IsAkiRunningAsync();
            if (!isRunning) return;
            Process[] activeAkis = await GetProcessesAsync();
            foreach (Process akiProcess in activeAkis)
            {
                akiProcess.Kill();
                Logger.Log($"Killed {akiProcess.ProcessName} ({akiProcess.Id})");
                await akiProcess.WaitForExitAsync();
                AkiProcess = null;
            }
            await Task.Delay(250);
            await DetectAki();
        }
        private static async void ProcessAkiConsoleOutput(object sender, DataReceivedEventArgs e)
        {
            string? r = e.Data;
            if (r == null) return;
            r = ConsoleRegex().Replace(r, string.Empty);
            //if(r.Contains($"Port {Settings.LauncherSettings.ServerPort} is already in use"))
            if (r.Contains(Settings.LauncherSettings.ServerURL)) Status = AkiStatus.ONLINE;
            Logger.Log(r);
            await Task.CompletedTask;
        }
        [GeneratedRegex(@"\[[0-1];[0-9][a-z]|\[[0-9][0-9][a-z]|\[[0-9][a-z]|\[[0-9][A-Z]")]
        private static partial Regex ConsoleRegex();
    }
}

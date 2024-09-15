
using System.Diagnostics;
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
        public static Dictionary<string, AkiInstance> AkiInstances { get; private set; } = []; // Instance Name, Process 
        public static Action<AkiInstance>? AkiStartingEvent; // Aki Window Opened
        public static Action<AkiInstance>? AkiStoppedEvent; // Exited
        public static Action<AkiInstance, AkiStatus>? AkiStatusEvent; // Status Changed, <Instance, oldStatus, New Status
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

        private static void SetStatus(AkiInstance akiInstance)
        {
            AkiInstances[akiInstance.Instance.Name] = akiInstance;
            AkiStatusEvent?.Invoke(akiInstance.Instance, akiInstance.Status);
            Logger.Log($"Set status for {akiInstance.Instance.Name} with {akiInstance.Status}");
        }
        private static void SetStatus(AkiInstance instance, AkiStatus akiStatus)
        {
            if (!AkiInstances.TryGetValue(instance.Name, out AkiInstance akiInstance)) return;
            akiInstance.Status = akiStatus;
            AkiInstances[instance.Name] = akiInstance;
            AkiStatusEvent?.Invoke(akiInstance.Instance, akiStatus);
        }
        public static async Task StartAkiAsync(AkiInstance instance)
        {
            try
            {
                Process akiProcess = new();
                akiProcess.StartInfo.WorkingDirectory = instance.Directory;
                akiProcess.StartInfo.FileName = Path.Combine(instance.Directory, AKI_SERVER_EXE);
                akiProcess.StartInfo.CreateNoWindow = false;
                akiProcess.StartInfo.UseShellExecute = false;
                akiProcess.StartInfo.RedirectStandardOutput = true;
                akiProcess.StartInfo.RedirectStandardError = true;
                akiProcess.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                akiProcess.OutputDataReceived += (sender, e) => ProcessAkiConsoleOutput(sender, e, instance);
                akiProcess.ErrorDataReceived += (sender, e) => ProcessAkiConsoleOutput(sender, e, instance);
                // Listen for the Process Exit
                akiProcess.Exited += (sender, e) => AkiStoppedEvent?.Invoke(instance);
                if (!akiProcess.Start()) return;
                //akiProcess.BeginOutputReadLine();
                akiProcess.BeginOutputReadLine();
                SetStatus(new AkiInstance(instance, akiProcess, AkiStatus.STARTING));
                AkiStartingEvent?.Invoke(instance);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
            await Task.CompletedTask;
        }
        private static async void ProcessAkiConsoleOutput(object sender, DataReceivedEventArgs e, AkiInstance instance)
        {
            string? r = e.Data;
            if (r == null) return;
            r = ConsoleRegex().Replace(r, string.Empty);
            if (r.Contains($"Port {Settings.LauncherSettings.ServerPort} is already in use")) SetStatus(instance, AkiStatus.OFFLINE);
            else if (r.Contains(Settings.LauncherSettings.ServerURL)) SetStatus(instance, AkiStatus.ONLINE);
            Logger.Log(r);
            await Task.CompletedTask;
        }
        [GeneratedRegex(@"\[[0-1];[0-9][a-z]|\[[0-9][0-9][a-z]|\[[0-9][a-z]|\[[0-9][A-Z]")]
        private static partial Regex ConsoleRegex();

        internal static AkiStatus GetStatus(AkiInstance instance)
        {
            AkiStatus status = AkiInstances.TryGetValue(instance.Name, out AkiInstance akiInstance) ? akiInstance.Status : AkiStatus.OFFLINE;
            Logger.Log($"Got status '{status}' for {instance.Name}");
            return status;
        }

        internal static async void KillAki(AkiInstance instance)
        {
            if (!AkiInstances.TryGetValue(instance.Name, out AkiInstance akiInstance)) return;
            akiInstance.Process.Kill();
            await akiInstance.Process.WaitForExitAsync();
            AkiStoppedEvent?.Invoke(instance);
        }
        public static async void KillActiveAkis()
        {
            bool isRunning = await IsAkiRunningAsync();
            if (!isRunning) return;
            Process[] activeAkis = await GetProcessesAsync();
            foreach (Process akiProcess in activeAkis)
            {
                akiProcess.Kill();
                Logger.Log($"Killed {akiProcess.ProcessName} ({akiProcess.Id})");
                await akiProcess.WaitForExitAsync();
            }
            await Task.Delay(250);
            //await DetectAki();
        }
    }
}

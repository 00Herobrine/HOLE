using Aki.Launcher.Helpers;
using Aki.Launcher.Models.Launcher;
using System.Diagnostics;

namespace HOLE.Scripts
{
    public static class GameManager
    {
        public static Dictionary<string, List<Process>> TarkovProcesses { get; private set; } = []; // instance name, Processes assosciated
        public static Action<GameEventArgs>? TarkovStartingEvent;
        public static Action<GameEventArgs>? TarkovStartedEvent;
        public static Action<GameEventArgs>? TarkovStoppedEvent;
        public const int MAX_PATCH_ATTEMPTS = 3;

        public static async Task StartTarkov(Instance instance, Profile profile)
        {
            // File Patching
            PatchResultInfo? patchResult = await PatchTarkovDlls(instance);
            
            // Tarkov Detection
            bool tarkovRunning = await IsTarkovRunning();
            if (tarkovRunning)
                if (MessageBox.Show("Another Tarkov process has been found running.\nWould you like to Continue?", "Tarkov Active!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error) != DialogResult.Yes) return;

            // Create New Tarkov for the Instance
            ProcessStartInfo tarkov = new(Path.Combine(instance.Directory, "EscapeFromTarkov.exe"))
            {
                Arguments = $"-token={profile.Info.id}" + "-config={'BackendUrl':'" + Settings.LauncherSettings.ServerURL + "','Version':'live'}",
                UseShellExecute = false,
                WorkingDirectory = instance.Directory,
            };
            Process? process = Process.Start(tarkov);
            if (process == null) return;
            // Tarkov Started
            TarkovStartedEvent?.Invoke(new GameEventArgs(process.Id, instance));
            process.Exited += (sender, e) => // Listen for the Process Exit
            {
                TarkovStoppedEvent?.Invoke(new GameEventArgs(process.Id, instance));
            };
            if (!TarkovProcesses.TryGetValue(instance.Name, out List<Process>? value))
                TarkovProcesses[instance.Name] = [process];
            else value.Add(process);
            await Task.CompletedTask;
        }

        public static async Task KillTarkov() // The true killer was themselves.
        {
            bool isRunning = await IsTarkovRunning();
            if (!isRunning) return;
            Process[] tarkovProcesses = Process.GetProcessesByName("escapefromtarkov");
            foreach (Process tarkov in tarkovProcesses)
            {
                tarkov.Kill();
                Logger.Log($"Killed {tarkov.ProcessName} ({tarkov.Id}");
            }
        }
        public static async Task<bool> IsTarkovRunning()
        {
            try
            {
                await Task.Delay(0);
                return Process.GetProcessesByName("escapefromtarkov").Length > 0;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                return false;
            }
        }

        private static async Task<PatchResultInfo?> PatchTarkovDlls(Instance instance, int patchAttempt = 1)
        {
            if(patchAttempt > MAX_PATCH_ATTEMPTS) return null;
            string dll = Path.Combine(instance.Directory, "/EscapeFromTarkov_Data/Managed/Assembly-CSharp.dll");
            string bpf = Path.Combine(instance.Directory, "/Aki_Data/Launcher/Patches/aki-core/EscapeFromTarkov_Data/Managed/Assembly-CSharp.dll.bpf");
            PatchResultInfo patchResult = FilePatcher.Patch(dll, bpf, false);
            if (patchResult.OK) return patchResult;
            if (MessageBox.Show($"'{dll}' patching failed with '{bpf}'.", ".dll Patching Failed",
                MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation) == DialogResult.Retry) await PatchTarkovDlls(instance, patchAttempt++);
            return null;
        }
    }
    public class GameEventArgs(int processID, Instance instance) : EventArgs
    {
        public readonly int ProcessID = processID;
        public Instance Instance { get; private set; } = instance;
    }
}

using HOLE.Scripts;
using HOLE.Scripts.Misc;
using HOLE.Scripts.Mod_Management;
using System.Diagnostics;
using System.Text;

namespace HOLE
{
    public partial class Form1 : Form
    {
        public ToolStripItem[] ActiveAkiComponents { get; }
        public ToolStripItem[] ActiveGameComponents { get; }
        public ToolStripItem[] ActiveInstanceComponents { get; }
        public static Process? AkiProcess { get; private set; }
        public static Process? TarkovProcess { get; private set; }
        public Form1()
        {
            InitializeComponent();
            ActiveAkiComponents = [KillAKIButton];
            ActiveGameComponents = [KillGameButton];
            ActiveInstanceComponents = [ModsFolderButton, InstanceFolder, InstanceFolderButton, EditInstanceButton, CopyInstanceButton, DeleteInstanceButton];
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            Initialize();
            await DetectAki();
        }

        private void Initialize()
        {
            SubToEvents();
            KillAKIButton.Enabled = false;
            ToggleGameButtons(false);
            ToggleServerConfigButtons(false);
            Settings.Initialize();
            RecipeManager.Initialize();
            ModManager.LoadSharedMods();
            LoadInstances();
            LoadIcons();
        }

        private void SubToEvents()
        {
            InstanceManager.InstanceChangedEvent += LoadInstance;
        }

        #region UI
        private void LoadIcons()
        {
            IconPack icons = Settings.SelectedIcons;
            AddInstanceButton.Image = icons.Launcher.AddInstanceButton.Image;
            PlayerButton.Image = icons.Factions.BEAR.Image;
        }
        private void IconsFolderButton_Click(object sender, EventArgs e)
        {
            FileUtils.OpenExplorer(Settings.IconPacksPath);
        }
        private void InstanceFolderButton_Click(object sender, EventArgs e)
        {
            Instance? instance = InstanceManager.SelectedInstance;
            if (instance == null) return;
            FileUtils.OpenExplorer(((Instance)instance).Directory);
        }
        private void ModsFolderButton_Click(object sender, EventArgs e)
        {
            Instance? instance = InstanceManager.SelectedInstance;
            if (instance == null) return;
            FileUtils.OpenExplorer(((Instance)instance).ModsPath); // Instance Mods Folder
        }
        private void SharedModsFolderButton_Click(object sender, EventArgs e)
        {
            FileUtils.OpenExplorer(Settings.ModsPath); // Shared Mods Folder
        }
        private void InstancesFolderButton_Click(object sender, EventArgs e)
        {
            FileUtils.OpenExplorer(Settings.InstancesPath);
        }
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            FileUtils.OpenForm<SettingsForm>();
        }
        #endregion

        #region Misc
        private void LauncherFolderButton_Click(object sender, EventArgs e)
        {
            FileUtils.OpenExplorer(Settings.LauncherPath);
        }
        private void ToggleStripItems(bool state, params ToolStripItem[] components)
        {
            foreach (ToolStripItem item in components)
            {
                if (item == null) continue;
                item.Enabled = state;
            }
        }
        #endregion

        #region Aki Functions
        public static async Task<bool> IsAkiRunning()
        {
            try
            {
                await Task.Delay(0);
                return Process.GetProcessesByName("aki.server").Length > 0; ;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                return false;
            }
        }
        private async Task DetectAki()
        {
            bool isRunning = await IsAkiRunning();
            if (isRunning)
            {
                await Task.Run(() => MessageBox.Show("Active Aki detected", "AKI Detected!"));
                KillAKIButton.Enabled = true;
                ToggleGameButtons(true);
                // Disallow editing server values while live as they won't save
                ToggleServerConfigButtons(false);
            }
            else
            {
                ToggleGameButtons(false);
                KillAKIButton.Enabled = false;
            }
        }
        public async Task<bool> StartAki(Instance instance)
        {
            await Task.Delay(0);
            Process akiProcess = new();
            akiProcess.StartInfo.WorkingDirectory = instance.Directory;
            akiProcess.StartInfo.FileName = "aki.server.exe";
            akiProcess.StartInfo.CreateNoWindow = true;
            akiProcess.StartInfo.UseShellExecute = false;
            akiProcess.StartInfo.RedirectStandardOutput = true;
            akiProcess.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            akiProcess.OutputDataReceived += ProcessAkiConsoleOutput;
            akiProcess.Exited += AkiExited;
            try
            {
                akiProcess.Start();
                akiProcess.BeginOutputReadLine();
                AkiProcess = akiProcess;
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
            }
            return false;
        }

        private void AkiExited(object? sender, EventArgs e)
        {
            AkiProcess = null;
            ToggleGameButtons(false);
            ToggleServerConfigButtons(true);
        }

        private static void ProcessAkiConsoleOutput(object sender, DataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnAkiActive()
        {
            ToggleServerConfigButtons(false);
            ToggleGameButtons(true);
        }

        private async Task KillAki()
        {
            bool isRunning = await IsAkiRunning();
            if (!isRunning) return;
            Process[] akiProcesses = Process.GetProcessesByName("aki.server");
            foreach (Process aki in akiProcesses)
            {
                aki.Kill();
                Logger.Log($"Killed {aki.ProcessName} ({aki.Id})");
            }
        }
        #region UI
        private void ToggleServerConfigButtons(bool enabled)
        {

        }
        #endregion
        private async void KillAKIButton_Click(object sender, EventArgs e)
        {
            await KillAki();
        }

        private void StartAKIButton_Click(object sender, EventArgs e)
        {
            //StartAndBindAki();
        }
        #endregion

        #region Game Functions
        private async void ToggleGameButtons(bool enabled)
        {
            PlayButton.Enabled = enabled && InstanceManager.SelectedInstance != null;
            KillGameButton.Enabled = enabled && await IsTarkovRunning();
        }
        private void PlayButton_Click(object sender, EventArgs e)
        {
            StartTarkov();
        }
        public async static void StartTarkov()
        {
            bool tarkovRunning = await IsTarkovRunning();
            if (tarkovRunning)
                if (MessageBox.Show("Another Tarkov instance has been found running.\nWould you like to Continue?", "Tarkov Active!", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {

                }
        }
        private async void KillGameButton_Click(object sender, EventArgs e)
        {
            await KillTarkov();
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
        #endregion

        #region Instance
        #region Functions
        private void LoadInstance(object? sender, InstanceEventArgs e)
        {
            ToggleInstanceButtons(e.Instance);
            CheckGameButtons();
            PlayerButton.Text = e.Instance?.Name ?? "";
        }
        private async void CheckGameButtons()
        {
            CheckAkiButtons();
            ToggleStripItems(await IsTarkovRunning(), ActiveGameComponents);
        }
        private async void CheckAkiButtons()
        {
            ToggleStripItems(await IsAkiRunning(), ActiveAkiComponents);
        }
        private void LoadInstances()
        {
            InstanceManager.Cache();
            InstanceView.Items.Clear();
            foreach (Instance instance in InstanceManager.Instances.Values)
            {
                if (TarkovCache.Directory == null) TarkovCache.LoadCache(instance);
                DisplayInstance(instance);
            }
        }
        private void DisplayInstance(Instance instance)
        {
            InstanceView.Items.Add(instance.Name);
        }
        private async void ToggleInstanceButtons(Instance? instance)
        {
            await Task.Delay(0);
            ToggleStripItems(instance != null, ActiveInstanceComponents);
        }
        #endregion

        #region UI
        private void InstanceView_SelectedIndexChanged(object sender, EventArgs e)
        {
            Instance? selectedInstance = null;
            if (InstanceView.SelectedItems.Count == 1) selectedInstance = InstanceManager.Get(InstanceView.SelectedItems[0].Text);
            InstanceManager.SetSelected(selectedInstance);
        }
        private void AddInstanceButton_ButtonClick(object sender, EventArgs e)
        {

        }
        private void AddNewInstanceButton_Click(object sender, EventArgs e)
        {
            //InstanceManager.;
        }
        private void AddExistingInstanceButton_Click(object sender, EventArgs e)
        {

        }
        private void InstanceFolder_Click(object sender, EventArgs e)
        {
            Instance? selectedInstance = InstanceManager.SelectedInstance;
            if (selectedInstance == null) return;
            FileUtils.OpenExplorer(((Instance)selectedInstance).Directory);
        }
        private void EditInstanceButton_Click(object sender, EventArgs e)
        {
            Instance? selectedInstance = InstanceManager.SelectedInstance;
            if (selectedInstance == null) return;
            InstanceManager.Open((Instance)selectedInstance);
        }
        #endregion
        #endregion

        #region Update Functions
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            FileUtils.OpenForm<ModDownloaderForm>();
            //CheckForUpdate();
        }

        private async void CheckForUpdate()
        {
            bool updateAvailable = await Updater.CheckForUpdate();
            if (updateAvailable)
            {
                if (MessageBox.Show("There is an update available at {URL}! \nWould you like to open Update Page?",
                    "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Process.Start("explorer", "https://github.com");
            }
            else MessageBox.Show("You are on the latest version of H.O.L.E!", "Up To Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        private void FoldersButton_ButtonClick(object sender, EventArgs e)
        {

        }
    }
}

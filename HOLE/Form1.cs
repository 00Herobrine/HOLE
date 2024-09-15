using Aki.Launcher.Models.Aki;
using HOLE.Aki.Launcher.Base.Models.Models.Aki;
using HOLE.Scripts;
using HOLE.Scripts.Aki;
using HOLE.Scripts.Launcher;
using HOLE.Scripts.Misc;
using HOLE.Scripts.Mod_Management;
using System.Diagnostics;
using Settings = HOLE.Scripts.Settings;

namespace HOLE
{
    public partial class Form1 : Form
    {
        public ToolStripItem[] ActiveAkiComponents { get; }
        public ToolStripItem[] ActiveGameComponents { get; }
        public ToolStripItem[] ActiveInstanceComponents { get; }
        public Form1()
        {
            InitializeComponent();
            ActiveAkiComponents = [KillAKIButton];
            ActiveGameComponents = [KillGameButton];
            ActiveInstanceComponents = [ModsFolderButton, InstanceFolder, InstanceFolderButton, EditInstanceButton, CopyInstanceButton, DeleteInstanceButton];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Initialize();
            DetectActiveAki();
        }

        private static async void DetectActiveAki()
        {
            if ((await AkiManager.GetProcessesAsync()).Length == 0) return;
            if (MessageBox.Show("Active Aki Detected would you like to Kill it?", "Aki Detected!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes) AkiManager.KillActiveAkis();
        }

        private void Initialize()
        {
            SubToEvents();
            KillAKIButton.Enabled = false;
            ToggleGameButtons(false);
            ToggleServerConfigButtons(false);
            ToggleInstanceButtons(null);
            Settings.Initialize();
            RecipeManager.Initialize();
            ModManager.LoadSharedMods();
            LoadServerAsync();
            LoadInstances();
            LoadIcons();
            LoadPlayTime();
        }

        private void LoadPlayTime()
        {
            //Settings.ConfigPath
        }

        private void SubToEvents()
        {
            InstanceManager.InstanceChangedEvent += SelectInstance;
            //AkiManager.AkiStartedEvent += AkiStarted;
            //AkiManager.AkiStoppedEvent += AkiExited;
            AkiManager.AkiStatusEvent += AkiStatusChanged;
        }

        private void AkiStatusChanged(AkiInstance instance, AkiStatus status)
        {
            AkiInstance? selectedInstance = InstanceManager.SelectedInstance;
            if (!selectedInstance.Equals(instance)) return;
            UpdateStatusLabel(status);
        }

        private async void UpdateStatusLabel(AkiStatus status)
        {

            Invoke((MethodInvoker)delegate {
                AkiStatusLabel.Text = status.ToString();
            });
            await Task.CompletedTask;
        }

        private void AkiExited(AkiInstance instance)
        {
            ToggleGameButtons(false);
            ToggleServerConfigButtons(true);
        }

        private void AkiStarted(AkiInstance instance)
        {
            ToggleServerConfigButtons(false);
            ToggleGameButtons(true);
        }

        #region UI
        private void LoadIcons()
        {
            IconPack icons = Settings.SelectedIcons;
            AddInstanceButton.Image = icons.Launcher.AddInstanceButton.Image;
            ProfileButton.Image = icons.Factions.BEAR.Image;
        }
        private void IconsFolderButton_Click(object sender, EventArgs e)
        {
            FileUtils.OpenExplorer(Settings.IconPacksPath);
        }
        private void InstanceFolderButton_Click(object sender, EventArgs e)
        {
            AkiInstance? instance = InstanceManager.SelectedInstance;
            if (instance == null) return;
            FileUtils.OpenExplorer(((AkiInstance)instance).Directory);
        }
        private void ModsFolderButton_Click(object sender, EventArgs e)
        {
            AkiInstance? instance = InstanceManager.SelectedInstance;
            if (instance == null) return;
            FileUtils.OpenExplorer(((AkiInstance)instance).ModsPath); // Instance Mods Folder
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
        private async Task ToggleStripItemsAsync(bool state, params ToolStripItem[] components)
        {
            await Task.Run(() => { ToggleStripItems(state, components); return Task.CompletedTask; });
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
        #region UI
        private void ToggleServerConfigButtons(bool enabled)
        {

        }
        #endregion
        private void KillAKIButton_Click(object sender, EventArgs e)
        {
            AkiInstance? selectedInstance = InstanceManager.SelectedInstance;
            if (selectedInstance == null) return;
            AkiManager.KillAki((AkiInstance)selectedInstance);
        }

        private async void StartAKIButton_Click(object sender, EventArgs e)
        {
            AkiInstance? instance = InstanceManager.SelectedInstance;
            if(instance == null) return;
            await AkiManager.StartAkiAsync((AkiInstance)instance);
            await LoadServerAsync();
        }
        #endregion

        #region Game Functions
        private async void ToggleGameButtons(bool enabled)
        {
            PlayButton.Enabled = enabled && InstanceManager.SelectedInstance != null;
            KillGameButton.Enabled = enabled && await GameManager.IsTarkovRunning();
        }
        private void PlayButton_Click(object sender, EventArgs e)
        {
            //ServerProfileInfo profiles = GetServerProfiles();
            AkiInstance? instance = InstanceManager.SelectedInstance;
            //Profile? selectedProfile = InstanceManager.SelectedInstance;
            //if (instance == null || selectedProfile == null) return;
            //StartTarkov((Instance)instance,(Profile)selectedProfile);

        }
        private void GameExited(object? sender, EventArgs e)
        {
            CheckGameButtons();
        }

        private async void KillGameButton_Click(object sender, EventArgs e)
        {
            await GameManager.KillTarkov();
        }
        #endregion

        #region Instance
        #region Functions
        private async Task LoadServerAsync(AkiInstance instance)
        {
            await instance.ServerManager.LoadDefaultServerAsync();
            //await ServerManager.PingServer();
        }
        private async void SelectInstance(object? sender, InstanceEventArgs e)
        {
            AkiInstance? instance = e.Instance;
            ToggleInstanceButtons(instance);
            CheckGameButtons();
            ProfileButton.Text = e.Instance?.Name ?? "";
            if (instance == null) return;
            TarkovCache.LoadCache((AkiInstance)instance);
            UpdateStatusLabel(AkiManager.GetStatus((AkiInstance)instance));
            bool response = ServerManager.PingServer();
            if (!response) return; // Aki Dead
            ServerProfileInfo[] profiles = await GetProfilesAsync();
            ProfileButton.DropDownItems.Clear();
            foreach (ServerProfileInfo profile in profiles)
                 ProfileButton.DropDownItems.Add(profile.username);
        }
        private async Task<ServerProfileInfo[]> GetProfilesAsync()
        {
            await Task.Delay(0);
            return AccountManager.GetExistingProfiles();
        }
        private async void CheckGameButtons()
        {
            CheckAkiButtons();
            ToggleStripItems(await GameManager.IsTarkovRunning(), ActiveGameComponents);
        }
        private async void CheckAkiButtons()
        {
            ToggleStripItems(await AkiManager.IsAkiRunningAsync(), ActiveAkiComponents);
        }
        private void LoadInstances()
        {
            InstanceManager.Cache();
            InstanceView.Items.Clear();
            foreach (AkiInstance instance in InstanceManager.Instances.Values)
            {
                if (TarkovCache.Directory == null) TarkovCache.LoadCache(instance);
                DisplayInstance(instance);
            }
        }
        private void DisplayInstance(AkiInstance instance)
        {
            InstanceView.Items.Add(instance.Name);
        }
        private async void ToggleInstanceButtons(AkiInstance? instance)
        {
            await ToggleStripItemsAsync(instance != null, ActiveInstanceComponents);
        }
        #endregion

        #region UI
        private void InstanceView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InstanceView.SelectedItems.Count == 1) 
                InstanceManager.SetSelected(InstanceManager.Get(InstanceView.SelectedItems[0].Text));
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
            AkiInstance? selectedInstance = InstanceManager.SelectedInstance;
            if (selectedInstance == null) return;
            FileUtils.OpenExplorer(((AkiInstance)selectedInstance).Directory);
        }
        private void EditInstanceButton_Click(object sender, EventArgs e)
        {
            AkiInstance? selectedInstance = InstanceManager.SelectedInstance;
            if (selectedInstance == null) return;
            InstanceManager.Open((AkiInstance)selectedInstance);
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

        private void ProfileButton_DefaultItemChanged(object sender, EventArgs e)
        {
            Logger.Log("Changed Default");
        }
    }
}

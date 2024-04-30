using HOLE.Scripts;
using System.Diagnostics;

namespace HOLE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            DisableGameButtons();
            Settings.Initialize();
            LoadInstances();
        }
        private void SubToEvents()
        {
            InstanceManager.InstanceChangedEvent += LoadInstance;
        }

        #region Aki Functions
        public static async Task<bool> IsAkiRunning()
        {
            try
            {
                await Task.Delay(0);
                Process[] process = Process.GetProcessesByName("aki.server");
                return process.Length > 0;
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
                EnableGameButtons();
                // Disallow editing server values while live as they won't save
                DisableServerConfigButtons();
            }
            else
            {
                DisableGameButtons();
                KillAKIButton.Enabled = false;
            }
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
        public static async Task<bool> IsTarkovRunning()
        {
            try
            {
                await Task.Delay(0);
                Process[] process = Process.GetProcessesByName("escapefromtarkov");
                return process.Length > 0;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                return false;
            }
        }
        public static void StartTarkov()
        {

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
        private void EnableGameButtons()
        {
            PlayButton.Enabled = InstanceManager.SelectedInstance != null;
            KillGameButton.Enabled = true;
        }
        private void DisableGameButtons()
        {
            PlayButton.Enabled = false;
            KillGameButton.Enabled = false;
        }
        private void PlayButton_Click(object sender, EventArgs e)
        {
            StartTarkov();
        }

        private async void KillGameButton_Click(object sender, EventArgs e)
        {
            await KillTarkov();
        }
        #endregion

        #region Instance Functions
        private void LoadInstance(object? sender, InstanceEventArgs e)
        {
            if (e.Cancel) return;
            PlayButton.Enabled = e.Instance != null;
            PlayerButton.Text = e.Instance?.Name ?? "";
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
        private void InstanceView_SelectedIndexChanged(object sender, EventArgs e)
        {
            Instance? selectedInstance = null;
            if (InstanceView.SelectedItems.Count == 1) selectedInstance = InstanceManager.Get(InstanceView.SelectedItems[0].Text);
            InstanceManager.SetSelected(selectedInstance);
        }
        private void AddNewInstanceButton_Click(object sender, EventArgs e)
        {
            //InstanceManager.;
        }
        private void AddExistingInstanceButton_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Update Functions
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            LoadInstances();
            CheckForUpdate();
        }

        private void CheckForUpdate()
        {

        }
        #endregion

        #region Misc
        public static void OpenForm<T>() where T : Form, new()
        {
            var existingForm = Application.OpenForms.OfType<T>().FirstOrDefault();
            if (existingForm == null || existingForm.IsDisposed)
                existingForm = new T();
            if (!existingForm.Visible)
                existingForm.Show();
            else existingForm.BringToFront();
        }
        #endregion

        private void DisableServerConfigButtons()
        {

        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            OpenForm<SettingsForm>();
        }
    }
}

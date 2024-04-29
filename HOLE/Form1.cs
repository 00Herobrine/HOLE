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

        public static async Task<bool> IsAkiRunning()
        {
            try
            {
                await Task.Delay(0);
                Process[] process = Process.GetProcessesByName("aki.server");
                return process.Length > 0;
            } catch (Exception ex)
            {
                Debug.WriteLine(ex);
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
            } else
            {
                DisableGameButtons();
                KillAKIButton.Enabled = false;
            }
        }
        private void KillAki()
        {

        }
        private void EnableGameButtons()
        {
            PlayButton.Enabled = true;
            KillGameButton.Enabled = true;
        }
        private void DisableGameButtons()
        {
            PlayButton.Enabled = false;
            KillGameButton.Enabled = false;
        }

        private void DisableServerConfigButtons()
        {

        }

        private void Initialize()
        {
            KillAKIButton.Enabled = false;
            DisableGameButtons();
            Settings.Initialize();
            LoadInstances();
            //TarkovCache.Initialize(instance, Settings.Language);
        }

        // Instances
        private void AddNewInstanceButton_Click(object sender, EventArgs e)
        {
            //InstanceManager.;
        }
        private void LoadInstances()
        {
            InstanceManager.Cache();
            InstanceView.Items.Clear();
            foreach (Instance instance in InstanceManager.Instances.Values)
            {
                if (TarkovCache.Directory == null) new TarkovCache(instance);
                DisplayInstance(instance);
            }
            //TarkovCache.Initialize(InstanceManager.Instances.Values.First());
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
            //InstanceManager.Get(InstanceView.SelectedItems[0].Text);
        }

        // Update Stuff
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            LoadInstances();
            CheckForUpdate();
        }

        private void CheckForUpdate()
        {

        }
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            OpenForm<SettingsForm>();
        }

        public static void OpenForm<T>() where T : Form, new()
        {
            var existingForm = Application.OpenForms.OfType<T>().FirstOrDefault();

            if (existingForm == null || existingForm.IsDisposed)
                existingForm = new T();
            if (!existingForm.Visible)
                existingForm.Show();
            else existingForm.BringToFront();
        }
    }
}

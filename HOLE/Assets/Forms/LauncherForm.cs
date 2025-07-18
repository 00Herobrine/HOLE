using HOLE.Assets.Scripts;
using SPT.Launcher;
using SPT.Launcher.Helpers;
using SPT.Launcher.Models.SPT;

namespace HOLE.Assets.Forms
{
    public partial class LauncherForm : Form
    {
        public LauncherForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Launcher.Initialize(); // Should only be Initialized once
            SubscribeToEvents();
            LoadInstanceIcons();
            LoadInstances();
            //Task.Run(() => ConnectServer());
        }

        private void LoadInstanceIcons()
        {
            IconManager.GetInstanceIcons();
        }

        private async void LoadInstances()
        {
            List<Instance> instances = new();
            instances = await InstanceManager.GetInstances();
            InstancesView.Items.Clear();
            foreach (Instance instance in instances)
            {
                InstancesView.Items.Add(instance.Name, 0);
            }
        }

        public async Task ConnectServer()
        {
            LauncherSettingsProvider.Instance.AllowSettings = false;

            if (!await ServerManager.LoadDefaultServerAsync(LauncherSettingsProvider.Instance.Server.Url))
            {
                LauncherSettingsProvider.Instance.AllowSettings = true;
                return;
            }

            bool connected = ServerManager.PingServer();

            if (connected)
            {
                string vers = ServerManager.GetVersion();
                SPTVersion version = new();
                version.ParseVersionInfo(vers);
            }

            LauncherSettingsProvider.Instance.AllowSettings = true;
        }

        private void SubscribeToEvents()
        {
            IconManager.IconPackUpdatedEvent += IconPackUpdated;
        }

        private void IconPackUpdated(IconPack iconPack)
        {
            SetIcons(iconPack);
        }

        private async void SetIcons(IconPack iconPack)
        {
            AddFIKAButton.Image = Image.FromFile(iconPack.AddInstanceIcon + ".png");
        }

        private void InstancesView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {

        }

        private Dictionary<string, ModDownloaderForm> downloaders = new(); // Instance name, downloader form
        private void downloadModsButton_Click(object sender, EventArgs e)
        {
            // No Instance Selected Maybe open the downloader that saves directly to cache and doesn't install
            if (InstancesView.SelectedItems.Count <= 0) 
                return;

            var selectedItem = InstancesView.SelectedItems[0];
            if (selectedItem == null) return;
            Instance? selectedInstance = InstanceManager.GetInstance(selectedItem.Text);
            if (selectedInstance == null) return;
            LaunchDownloader(selectedInstance);
        }

        private void LaunchDownloader(Instance instance)
        {
            if(downloaders.TryGetValue(instance.Name, out var downloader))
            { // Downloader for instance already launched
                if (downloader.IsDisposed) // Check if the Downloader was closed
                {
                    downloader = null;
                    downloaders.Remove(instance.Name);
                }
            }

            if (downloader == null)
            {
                downloader = new ModDownloaderForm(instance);
                downloaders[instance.Name] = downloader;
            }
            downloader.Show();
        }
    }
}

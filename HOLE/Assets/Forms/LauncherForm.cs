using System.Diagnostics;
using HOLE.Assets.Scripts;
using HOLE.Assets.Scripts.Mods;
using HOLE.Assets.Scripts.Utils;
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
            InstanceManager.LoadInstances();
            List<Instance> instances = InstanceManager.GetInstances();
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
            AddFikaButton.Image = Image.FromFile(iconPack.AddInstanceIcon + ".png");
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
            if (downloaders.TryGetValue(instance.Name, out var downloader))
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

        private void FolderButton_Click(object sender, EventArgs e)
        {
            Instance? instance = GetSelectedInstance();
            if (instance == null) return;
            Process.Start("explorer.exe", instance.Folder);
        }

        private Instance? GetSelectedInstance()
        {
            if (InstancesView.SelectedItems.Count <= 0) return null;
            return InstanceManager.GetInstance(InstancesView.SelectedItems[0].Text);
        }

        private void AddInstanceButton_Click(object sender, EventArgs e)
        {
            FileManagement.DirectoryCheck(Launcher.Config.Paths.ModDownloads);
            foreach (var file in Directory.GetFiles(Launcher.Config.Paths.ModDownloads))
            {
                _ = ModManager.ExtractModAsync(file);
            }
        }

        private void FikaWikiButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", $"{ModManager.FikaWikiUrl}");
        }

        private void AddFikaClientButton_Click(object sender, EventArgs e)
        {

        }

        private void AddFikaServerButton_Click(object sender, EventArgs e)
        {

        }

        private void FoldersLauncherButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Launcher.ExePath);
        }

        private void FoldersInstancesButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Launcher.Config.Paths.Instances);
        }

        private void FolderInstanceIcons_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Launcher.Config.Paths.Icons);
        }

        private void FoldersModsButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Launcher.Config.Paths.Mods);
        }

        private void FoldersModCache_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Launcher.Config.Paths.ModDownloads);
        }

        private void FoldersModIcons_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Launcher.Config.Paths.ModIcons);
        }

        private void FoldersLogs_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Launcher.Config.Paths.Logs);
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {

        }
    }
}

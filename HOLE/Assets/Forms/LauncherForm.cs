using System.Diagnostics;
using System.Media;
using HOLE.Assets.Scripts;
using HOLE.Assets.Scripts.Mods;
using HOLE.Assets.Scripts.Utils;

namespace HOLE.Assets.Forms
{
    public partial class LauncherForm : Form
    {
        public LauncherForm()
        {
            InitializeComponent();
            Launcher.Initialize(); // Should only be Initialized once
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SubscribeToEvents();
            LoadElementLists();
            LoadInstances();
            CheckSelectedInstance();
            //Task.Run(() => ConnectServer());
        }

        ToolStripItem[] ServerElements, GameElements;
        private void LoadElementLists()
        {
            ServerElements = [StartServerButton, ServerSectionSeparator];
            GameElements = [StartGameButton, EditButton, ShortcutButton, DeleteButton];
        }

        private void LoadInstances()
        {
            InitializeImageList();

            List<Instance> instances = InstanceManager.GetInstances();
            foreach (Instance instance in instances)
            {
                Debug.WriteLine($"Icon: {instance.Config.Icon}");
                InstancesView.Items.Add(instance.Name, instance.Config.Icon);
            }
        }

        private void InitializeImageList()
        {
            InstancesView.Items.Clear();
            InstancesView.LargeImageList ??= new ImageList();
            InstancesView.LargeImageList.Images.Clear();
            foreach (string imagePath in IconManager.GetInstanceIconPaths())
            {
                string imageName = Path.GetFileName(imagePath);
                Image image = Image.FromFile(imagePath);
                Debug.WriteLine($"{imageName}");
                InstancesView.LargeImageList.Images.Add(imageName, image);
            }
        }

        /*public async Task ConnectToServer()
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
        }*/

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


        private void DownloadModsButton_Click(object sender, EventArgs e)
        {
            // If no Instance selected maybe open ModDownloader that saves directly to cache and doesn't install to an instance
            Instance? selectedInstance = GetSelectedInstance();
            if (selectedInstance == null)
            {
                Logger.Info("Selected Instance == null");
                return;
            }

            ModManager.Open(selectedInstance);
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

        private Form? newInstanceForm;

        private void OpenNewInstanceForm()
        {
            if (newInstanceForm == null || newInstanceForm.IsDisposed)
            {
                newInstanceForm = new NewInstanceForm();
                //newInstanceForm.ShowDialog();
            }
            else
            {
                // Play Windows Audio
                SystemSounds.Asterisk.Play();
            }

            newInstanceForm.Show();
            newInstanceForm.BringToFront();
        }
        private void AddInstanceButton_Click(object sender, EventArgs e)
        {
            OpenNewInstanceForm();
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

        private void InstanceIcon_Click(object sender, EventArgs e)
        {

        }


        private void InstancesView_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSelectedInstance();
        }

        private void CheckSelectedInstance()
        {
            Instance? instance = GetSelectedInstance();
            if (instance == null)
            {
                DisableElements(GameElements);
            }
            else
            {
                EnableElements(GameElements);
                if (!instance.HasServerExe()) DisableElements(ServerElements);
            }
        }

        private void EnableElements(params ToolStripItem[] toolStripItems)
        {
            foreach (ToolStripItem toolStripItem in toolStripItems)
            {
                toolStripItem.Enabled = true;
            }
        }

        private void DisableElements(params ToolStripItem[] toolStripItems)
        {
            foreach (ToolStripItem toolStripItem in toolStripItems)
            {
                toolStripItem.Enabled = false;
            }
        }

        private void GroupBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // set selected instance's group to text
                Instance? instance = GetSelectedInstance();
                if (instance == null) return;
                InstanceManager.SetGroup(instance, GroupBox.Text);
            }
        }
    }
}

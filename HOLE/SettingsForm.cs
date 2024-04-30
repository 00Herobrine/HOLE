using HOLE.Scripts;

namespace HOLE
{
    public partial class SettingsForm : Form
    {
        internal enum SettingsTab
        {
            Launcher, ModDownloader, ServerConsole, TarkovCache
        }
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void InstancePathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                SetInstancesPath(dialog.SelectedPath, true);
        }

        private void SetInstancesPath(string path, bool save = false)
        {
            InstancesPath.Text = path;
            if (save) Settings.SetInstancesPath(path, save);
        }

        private void InstancesPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            SetInstancesPath(InstancesPath.Text, true);
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            LoadTab();
        }

        private void LoadTab()
        {
            PopulateInfo();
        }

        private void PopulateInfo()
        {
            InstancesPath.Text = Settings.LauncherSettings.InstancesPath;
        }
    }
}

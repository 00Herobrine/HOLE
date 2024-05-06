using HOLE.Scripts;
using HOLE.Scripts.Mod_Management;
using System.Text.Json;

namespace HOLE
{
    public partial class ModDownloaderForm : Form
    {
        public Instance? Instance { get; }

        public static readonly string ForbiddenInstanceName = "ANameThatShouldntBeUsed";
        public ModDownloaderForm()
        {
            InitializeComponent();
            Instance = null;
        }
        public ModDownloaderForm(Instance? instance)
        {
            InitializeComponent();
            Instance = instance;
        }

        private void ModDownloaderForm_Load(object sender, EventArgs e)
        {
            LoadMods();
            //LoadFancyMods();
        }

        private async void LoadFancyMods()
        {
            await Task.Delay(0);
            QueryAndAddMods(1);
        }
        private async void LoadMods()
        {
            await Task.Delay(0);
            if (!File.Exists(ModDownloader.ModsJsonPath)) QueryAndAddBasicMods();
            else
            {
                BasicModsConfig config = JsonSerializer.Deserialize<BasicModsConfig>(await File.ReadAllTextAsync(ModDownloader.ModsJsonPath));
                if ((DateTime.Now - config.last_updated) > TimeSpan.FromMinutes(ModDownloader.ExpirationTime)) QueryAndAddBasicMods();
                else Populate(ref basicModsList, config.mod_data);
            }
        }
        private async void QueryAndAddMods(int pageNumber)
        {
            ModCard[] modCards = await ModDownloader.QueryMods(pageNumber);
            Populate(ref basicModsList, modCards);
        }
        private async void QueryAndAddBasicMods()
        {
            BasicModCard[] modCards = (await ModDownloader.QueryBasicModDownloads()).mod_data;
            Populate(ref basicModsList, modCards);
        }
        private static void Populate(ref ListView listView, params BasicModCard[] basicModCards)
        {
            listView.Items.Clear();
            foreach (BasicModCard modCard in basicModCards)
                listView.Items.Add(new ListViewItem([modCard.name, modCard.description, $"{modCard.version}", $"{modCard.AkiVersion}", modCard.link, $"{modCard.featured}", $"{modCard.downloads}"]));
        }
        private static void Populate(ref ListView listView, params ModCard[] modCards)
        {
            listView.Items.Clear();
            foreach (ModCard modCard in modCards)
            {
                listView.Items.Add(new ListViewItem([modCard.name, modCard.description, modCard.versionLabel, modCard.link, $"{modCard.featured}", $"{modCard.downloads}"]));
            }
        }
        private static void Populate(ref ListView listView, params IModCard[] downloads)
        {
            listView.Items.Clear();
            //PopulateColumns(ref listView, "Name", "Description", "Version", "Link", "Featured", "Downloads");
            foreach (IModCard modCard in downloads)
                listView.Items.Add(new ListViewItem([modCard.name, modCard.description, $"{modCard.versionLabel}", modCard.link, $"{modCard.featured}", $"{modCard.downloads}"]));
        }
        private static void PopulateColumns(ref ListView listView, params string[] colums)
        {
            listView.Columns.Clear();
            foreach (var colum in colums) listView.Columns.Add(colum);
        }

        private async void DownloadButton_ButtonClick(object sender, EventArgs e)
        {
            string[] links = new string[basicModsList.CheckedItems.Count];
            for (int i = 0; i < links.Length; i++)
            {
                links[i] = basicModsList.CheckedItems[i].SubItems[4].Text;
            }
            MessageBox.Show($"Queued {(await ModDownloader.QueueDownloads(links)).Count}/{links.Length} selected mods to download.");
        }
    }
}

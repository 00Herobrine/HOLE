using HOLE.Scripts;
using System.Text.Json;

namespace HOLE
{
    public partial class ModDownloaderForm : Form
    {
        public Instance? Instance { get; }
        public static readonly string ForbiddenInstanceName = "ANameThatShouldntUse";
        public ModDownloaderForm() {
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
        }

        private async void LoadMods()
        {
            await Task.Delay(0);
            if(!File.Exists(ModDownloader.ModsJsonPath)) QueryAndAddBasicMods();
            else
            {
                BasicModsConfig config = JsonSerializer.Deserialize<BasicModsConfig>(await File.ReadAllTextAsync(ModDownloader.ModsJsonPath));
                if ((DateTime.Now - config.Generated) > TimeSpan.FromMinutes(ModDownloader.ExpirationTime)) QueryAndAddBasicMods();
                else Populate(ref basicModsList, config.Downloads);
            }
        }

        private async void QueryAndAddBasicMods()
        {
            BasicModDownload[] downloads = await ModDownloader.QueryBasicModDownloads();
            Populate(ref basicModsList, downloads);
        }

        private static void Populate(ref ListView listView, params BasicModDownload[] downloads)
        {
            listView.Items.Clear();
            //PopulateColumns(ref listView, "Name", "Description", "Version", "Link", "Featured", "Downloads");
            foreach (BasicModDownload basicMod in downloads) 
                listView.Items.Add(new ListViewItem([basicMod.name, basicMod.description, $"{basicMod.version}", basicMod.link, $"{(basicMod.featured == 1 ? "true" : "false")}", $"{basicMod.downloads}"]));
        }
        private static void PopulateColumns(ref ListView listView, params string[] colums)
        {
            listView.Columns.Clear();
            foreach (var colum in colums) listView.Columns.Add(colum);
        }
    }
}

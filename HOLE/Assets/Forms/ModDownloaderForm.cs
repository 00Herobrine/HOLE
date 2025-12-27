using HOLE.Assets.Scripts;
using HOLE.Assets.Scripts.Mods;

namespace HOLE.Assets.Forms
{
    public partial class ModDownloaderForm : Form
    {
        private readonly Instance _instance;

        public ModDownloaderForm(Instance instance)
        {
            InitializeComponent();
            _instance = instance;
        }

        private void ModDownloaderForm_Load(object sender, EventArgs e)
        {
            SubscribeToEvents();
            Text = $@"{Text} - {_instance.Name}";
            GetModList();
            //_ = ModManager.QuerySPTModList();
            //_ = ModManager.GetSPTModDataAsync();
        }
        
        private void SubscribeToEvents()
        {
            ModManager.SPTModsJsonQueried += ModsQueried;
        }

        private void GetModList()
        {
            _ = ModManager.GetSPTModList();
        }

        private void ModsQueried(SPTModsJson modJsonJson)
        {
            UpdateModList(modJsonJson.mod_data);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            UpdateWithFilters();
        }

        private void UpdateWithFilters() => UpdateWithFiltersAsync(ModManager.GetSPTModsJsonAsync().Result.mod_data);
        private async void UpdateWithFiltersAsync(SPTModData[] modData)
        {
            modsView.Items.Clear();
            var filtered = await FilterDownloadsAsync(modData, searchBox.Text);
            UpdateModList(filtered.ToArray());
        }
        private void UpdateModList(SPTModData[] modData)
        {
            modsView.BeginUpdate();
            modsView.Items.Clear();

            foreach (var item in modData)
            {
                var listViewItem = new ListViewItem(item.name)
                {
                    Tag = item
                };
                listViewItem.SubItems.Add(item.version);
                listViewItem.SubItems.Add(item.downloads);
                modsView.Items.Add(listViewItem);
            }
            modsView.EndUpdate();
        }

        private async Task<List<SPTModData>> FilterDownloadsAsync(SPTModData[] modData, string? input = null)
        {
            List<SPTModData> filterList = modData.ToList();
            if (string.IsNullOrWhiteSpace(input) || (!FilterDescription.Checked && !FilterName.Checked) /*&& !FilterAuthorCheck.Checked*/)
                return filterList;
            return filterList.FindAll(o =>
                (o.name.Contains(input, StringComparison.OrdinalIgnoreCase) && FilterName.Checked)
                //|| (o.author.Contains(input, StringComparison.OrdinalIgnoreCase) && FilterAuthorCheck.Checked)
                || (o.description.Contains(input, StringComparison.OrdinalIgnoreCase) && FilterDescription.Checked));
        }

        private async void DownloadConfirmButton_Click(object sender, EventArgs e)
        {
            if (modsView.SelectedItems.Count <= 0) return;
            SPTModData? modData = (SPTModData?)modsView.SelectedItems[0].Tag;
            if (modData == null) return;
            if (int.TryParse(modData.Value.id, out int modId))
                ModManager.ScheduleDownloadAsync(modId);
        }
    }
}

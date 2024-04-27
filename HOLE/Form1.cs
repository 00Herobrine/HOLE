using HOLE.Scripts;

namespace HOLE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Initialize()
        {
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
            InstanceManager.Load();
            InstanceView.Items.Clear();
            foreach (Instance instance in InstanceManager.Instances.Values)
            {
                if (TarkovCache.Directory == null) TarkovCache.Initialize(instance);
                DisplayInstance(instance);
            }
            //TarkovCache.Initialize(InstanceManager.Instances.Values.First());
        }
        private void LoadInstance(Instance instance)
        {
            InstanceManager.Add(instance);
            DisplayInstance(instance);
        }
        private void DisplayInstance(Instance instance)
        {
            InstanceView.Items.Add(instance.Name);
        }
        private void InstanceView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InstanceView.SelectedItems.Count != 1) return;
            InstanceManager.Get(InstanceView.SelectedItems[0].Text);
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

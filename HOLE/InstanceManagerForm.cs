using HOLE.Scripts;

namespace HOLE
{
    public partial class InstanceManagerForm : Form
    {
        public readonly Instance Instance;
        public InstanceManagerForm(Instance instance)
        {
            Instance = instance;
            InitializeComponent();
        }

        private void InstanceEditorForm_Load(object sender, EventArgs e)
        {

        }
    }
}

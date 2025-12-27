using HOLE.Assets.Scripts;
using HOLE.Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOLE.Assets.Forms
{
    public partial class NewInstanceForm : Form
    {
        public NewInstanceForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameBox.Text))
            {
                return;
            }
            if (string.IsNullOrEmpty(PathBox.Text))
            {
                MessageBox.Show("Path for SPT Instance is empty.", "No Path Set!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            string? directoryName = Path.GetDirectoryName(NameBox.Text);
            Instance? instance = directoryName != null ? InstanceManager.GetInstance(directoryName) : null;
            if (directoryName == null || instance == null || instance.IsValid()) 
                return;
                
            //InstanceManager.AddInstance(PathBox.Text);
        }

        private void PathButton_Click(object sender, EventArgs e)
        {

        }
    }
}

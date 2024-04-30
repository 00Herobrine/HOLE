namespace HOLE
{
    partial class ProfileEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileEditorForm));
            toolStripContainer1 = new ToolStripContainer();
            HideoutButton = new ToolStripButton();
            EncyclopediaButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            PMCButton = new ToolStripButton();
            ScavButton = new ToolStripButton();
            toolStrip1 = new ToolStrip();
            HideoutPanel = new Panel();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStripContainer1
            // 
            toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.Controls.Add(toolStrip1);
            toolStripContainer1.ContentPanel.Size = new Size(90, 450);
            toolStripContainer1.Dock = DockStyle.Left;
            toolStripContainer1.Location = new Point(0, 0);
            toolStripContainer1.Name = "toolStripContainer1";
            toolStripContainer1.RightToolStripPanelVisible = false;
            toolStripContainer1.Size = new Size(90, 450);
            toolStripContainer1.TabIndex = 0;
            toolStripContainer1.Text = "toolStripContainer1";
            toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // HideoutButton
            // 
            HideoutButton.Image = (Image)resources.GetObject("HideoutButton.Image");
            HideoutButton.ImageTransparentColor = Color.Magenta;
            HideoutButton.Name = "HideoutButton";
            HideoutButton.Size = new Size(88, 36);
            HideoutButton.Text = "Hideout";
            // 
            // EncyclopediaButton
            // 
            EncyclopediaButton.Image = (Image)resources.GetObject("EncyclopediaButton.Image");
            EncyclopediaButton.ImageTransparentColor = Color.Magenta;
            EncyclopediaButton.Name = "EncyclopediaButton";
            EncyclopediaButton.Size = new Size(88, 36);
            EncyclopediaButton.Text = "Inspects";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(88, 6);
            // 
            // PMCButton
            // 
            PMCButton.Image = (Image)resources.GetObject("PMCButton.Image");
            PMCButton.ImageTransparentColor = Color.Magenta;
            PMCButton.Name = "PMCButton";
            PMCButton.Size = new Size(88, 36);
            PMCButton.Text = "PMC";
            // 
            // ScavButton
            // 
            ScavButton.Image = (Image)resources.GetObject("ScavButton.Image");
            ScavButton.ImageTransparentColor = Color.Magenta;
            ScavButton.Name = "ScavButton";
            ScavButton.Size = new Size(88, 36);
            ScavButton.Text = "SCAV";
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Fill;
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { HideoutButton, EncyclopediaButton, toolStripSeparator1, PMCButton, ScavButton });
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(90, 450);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // HideoutPanel
            // 
            HideoutPanel.Dock = DockStyle.Fill;
            HideoutPanel.Location = new Point(90, 0);
            HideoutPanel.Name = "HideoutPanel";
            HideoutPanel.Size = new Size(710, 450);
            HideoutPanel.TabIndex = 1;
            // 
            // ProfileEditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(HideoutPanel);
            Controls.Add(toolStripContainer1);
            Name = "ProfileEditorForm";
            Text = "ProfileEditorForm";
            toolStripContainer1.ContentPanel.ResumeLayout(false);
            toolStripContainer1.ContentPanel.PerformLayout();
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ToolStripContainer toolStripContainer1;
        private ToolStrip toolStrip1;
        private ToolStripButton HideoutButton;
        private ToolStripButton EncyclopediaButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton PMCButton;
        private ToolStripButton ScavButton;
        private Panel HideoutPanel;
    }
}
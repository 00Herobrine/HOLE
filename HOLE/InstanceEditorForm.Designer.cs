namespace HOLE
{
    partial class InstanceEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstanceEditorForm));
            ListViewItem listViewItem2 = new ListViewItem(new string[] { "662bd45200012640ea93c910", "Hero", "Edge of Darkness", "42", "13", "3.8.0 (29197)" }, -1);
            toolStrip1 = new ToolStrip();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStripButton1 = new ToolStripButton();
            UserTab = new TabControl();
            ModsTab = new TabPage();
            ProfilesTab = new TabPage();
            toolStrip2 = new ToolStrip();
            toolStripButton5 = new ToolStripButton();
            toolStripButton4 = new ToolStripButton();
            listView1 = new ListView();
            ID = new ColumnHeader();
            Edition = new ColumnHeader();
            PMCLevel = new ColumnHeader();
            ScavLevel = new ColumnHeader();
            AKIVersion = new ColumnHeader();
            SPTSettingsTab = new TabPage();
            UserPanel = new Panel();
            toolStrip1.SuspendLayout();
            UserTab.SuspendLayout();
            ProfilesTab.SuspendLayout();
            toolStrip2.SuspendLayout();
            UserPanel.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Left;
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton2, toolStripButton3, toolStripButton1 });
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(88, 450);
            toolStrip1.Stretch = true;
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(85, 36);
            toolStripButton2.Text = "Aki Data";
            // 
            // toolStripButton3
            // 
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(85, 36);
            toolStripButton3.Text = "BepInEx";
            // 
            // toolStripButton1
            // 
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(85, 36);
            toolStripButton1.Text = "User";
            // 
            // UserTab
            // 
            UserTab.Controls.Add(ModsTab);
            UserTab.Controls.Add(ProfilesTab);
            UserTab.Controls.Add(SPTSettingsTab);
            UserTab.Dock = DockStyle.Fill;
            UserTab.Location = new Point(0, 0);
            UserTab.Name = "UserTab";
            UserTab.SelectedIndex = 0;
            UserTab.Size = new Size(712, 450);
            UserTab.TabIndex = 3;
            // 
            // ModsTab
            // 
            ModsTab.Location = new Point(4, 24);
            ModsTab.Name = "ModsTab";
            ModsTab.Padding = new Padding(3);
            ModsTab.Size = new Size(704, 422);
            ModsTab.TabIndex = 0;
            ModsTab.Text = "Mods";
            ModsTab.UseVisualStyleBackColor = true;
            // 
            // ProfilesTab
            // 
            ProfilesTab.Controls.Add(toolStrip2);
            ProfilesTab.Controls.Add(listView1);
            ProfilesTab.Location = new Point(4, 24);
            ProfilesTab.Name = "ProfilesTab";
            ProfilesTab.Padding = new Padding(3);
            ProfilesTab.Size = new Size(704, 422);
            ProfilesTab.TabIndex = 1;
            ProfilesTab.Text = "Profiles";
            ProfilesTab.UseVisualStyleBackColor = true;
            // 
            // toolStrip2
            // 
            toolStrip2.Dock = DockStyle.Right;
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripButton5, toolStripButton4 });
            toolStrip2.Location = new Point(646, 3);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(55, 416);
            toolStrip2.TabIndex = 1;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton5
            // 
            toolStripButton5.Image = (Image)resources.GetObject("toolStripButton5.Image");
            toolStripButton5.ImageTransparentColor = Color.Magenta;
            toolStripButton5.Name = "toolStripButton5";
            toolStripButton5.Size = new Size(52, 20);
            toolStripButton5.Text = "Edit";
            // 
            // toolStripButton4
            // 
            toolStripButton4.Image = (Image)resources.GetObject("toolStripButton4.Image");
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(52, 20);
            toolStripButton4.Text = "Wipe";
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { ID, Edition, PMCLevel, ScavLevel, AKIVersion });
            listView1.Dock = DockStyle.Fill;
            listView1.Items.AddRange(new ListViewItem[] { listViewItem2 });
            listView1.Location = new Point(3, 3);
            listView1.Name = "listView1";
            listView1.Size = new Size(698, 416);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // ID
            // 
            ID.Text = "ID";
            ID.Width = 165;
            // 
            // Edition
            // 
            Edition.Text = "Edition";
            Edition.Width = 125;
            // 
            // PMCLevel
            // 
            PMCLevel.Text = "PMC";
            PMCLevel.TextAlign = HorizontalAlignment.Center;
            PMCLevel.Width = 50;
            // 
            // ScavLevel
            // 
            ScavLevel.Text = "Scav";
            ScavLevel.TextAlign = HorizontalAlignment.Center;
            ScavLevel.Width = 50;
            // 
            // AKIVersion
            // 
            AKIVersion.Text = "AKI Version";
            AKIVersion.Width = 85;
            // 
            // SPTSettingsTab
            // 
            SPTSettingsTab.Location = new Point(4, 24);
            SPTSettingsTab.Name = "SPTSettingsTab";
            SPTSettingsTab.Padding = new Padding(3);
            SPTSettingsTab.Size = new Size(704, 422);
            SPTSettingsTab.TabIndex = 2;
            SPTSettingsTab.Text = "SPTSettings";
            SPTSettingsTab.UseVisualStyleBackColor = true;
            // 
            // UserPanel
            // 
            UserPanel.Controls.Add(UserTab);
            UserPanel.Dock = DockStyle.Fill;
            UserPanel.Location = new Point(88, 0);
            UserPanel.Name = "UserPanel";
            UserPanel.Size = new Size(712, 450);
            UserPanel.TabIndex = 0;
            // 
            // InstanceEditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(UserPanel);
            Controls.Add(toolStrip1);
            Name = "InstanceEditorForm";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "InstanceEditorForm";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            UserTab.ResumeLayout(false);
            ProfilesTab.ResumeLayout(false);
            ProfilesTab.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            UserPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private TabControl UserTab;
        private TabPage ModsTab;
        private TabPage ProfilesTab;
        private Panel UserPanel;
        private TabPage SPTSettingsTab;
        private ListView listView1;
        private ColumnHeader ID;
        private ColumnHeader NameColumn;
        private ColumnHeader Edition;
        private ToolStrip toolStrip2;
        private ToolStripButton toolStripButton4;
        private ToolStripButton toolStripButton5;
        private ColumnHeader PMCLevel;
        private ColumnHeader ScavLevel;
        private ColumnHeader AKIVersion;
    }
}
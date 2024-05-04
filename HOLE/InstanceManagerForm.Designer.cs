namespace HOLE
{
    partial class InstanceManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstanceManagerForm));
            ListViewItem listViewItem1 = new ListViewItem(new string[] { "662bd45200012640ea93c910", "Hero", "Edge of Darkness", "42", "13", "3.8.0 (29197)" }, -1);
            toolStrip1 = new ToolStrip();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStripButton1 = new ToolStripButton();
            toolStripButton7 = new ToolStripButton();
            UserPanel = new Panel();
            UserTab = new TabControl();
            ModsTab = new TabPage();
            ProfilesTab = new TabPage();
            toolStrip3 = new ToolStrip();
            toolStripButton5 = new ToolStripButton();
            toolStripButton4 = new ToolStripButton();
            listView1 = new ListView();
            ID = new ColumnHeader();
            Edition = new ColumnHeader();
            PMCLevel = new ColumnHeader();
            ScavLevel = new ColumnHeader();
            AKIVersion = new ColumnHeader();
            SPTSettingsTab = new TabPage();
            toolStrip2 = new ToolStrip();
            toolStripButton6 = new ToolStripButton();
            miniToolStrip = new ToolStrip();
            ModsPanel = new Panel();
            listView2 = new ListView();
            toolStrip5 = new ToolStrip();
            toolStripButton8 = new ToolStripButton();
            toolStripButton10 = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            toolStripButton9 = new ToolStripButton();
            toolStripButton13 = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButton12 = new ToolStripButton();
            toolStripButton14 = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripButton11 = new ToolStripButton();
            toolStrip4 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            toolStrip1.SuspendLayout();
            UserPanel.SuspendLayout();
            UserTab.SuspendLayout();
            ProfilesTab.SuspendLayout();
            toolStrip3.SuspendLayout();
            toolStrip2.SuspendLayout();
            ModsPanel.SuspendLayout();
            toolStrip5.SuspendLayout();
            toolStrip4.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Left;
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton2, toolStripButton3, toolStripButton1, toolStripButton7 });
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
            // toolStripButton7
            // 
            toolStripButton7.Image = (Image)resources.GetObject("toolStripButton7.Image");
            toolStripButton7.ImageTransparentColor = Color.Magenta;
            toolStripButton7.Name = "toolStripButton7";
            toolStripButton7.Size = new Size(85, 36);
            toolStripButton7.Text = "Mods";
            // 
            // UserPanel
            // 
            UserPanel.Controls.Add(UserTab);
            UserPanel.Controls.Add(toolStrip2);
            UserPanel.Dock = DockStyle.Fill;
            UserPanel.Location = new Point(88, 0);
            UserPanel.Name = "UserPanel";
            UserPanel.Size = new Size(712, 450);
            UserPanel.TabIndex = 0;
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
            UserTab.Size = new Size(613, 450);
            UserTab.TabIndex = 5;
            // 
            // ModsTab
            // 
            ModsTab.Location = new Point(4, 24);
            ModsTab.Name = "ModsTab";
            ModsTab.Padding = new Padding(3);
            ModsTab.Size = new Size(605, 422);
            ModsTab.TabIndex = 0;
            ModsTab.Text = "Mods";
            ModsTab.UseVisualStyleBackColor = true;
            // 
            // ProfilesTab
            // 
            ProfilesTab.Controls.Add(toolStrip3);
            ProfilesTab.Controls.Add(listView1);
            ProfilesTab.Location = new Point(4, 24);
            ProfilesTab.Name = "ProfilesTab";
            ProfilesTab.Padding = new Padding(3);
            ProfilesTab.Size = new Size(605, 422);
            ProfilesTab.TabIndex = 1;
            ProfilesTab.Text = "Profiles";
            ProfilesTab.UseVisualStyleBackColor = true;
            // 
            // toolStrip3
            // 
            toolStrip3.Dock = DockStyle.Right;
            toolStrip3.Items.AddRange(new ToolStripItem[] { toolStripButton5, toolStripButton4 });
            toolStrip3.Location = new Point(547, 3);
            toolStrip3.Name = "toolStrip3";
            toolStrip3.Size = new Size(55, 416);
            toolStrip3.TabIndex = 1;
            toolStrip3.Text = "toolStrip3";
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
            listView1.Items.AddRange(new ListViewItem[] { listViewItem1 });
            listView1.Location = new Point(3, 3);
            listView1.Name = "listView1";
            listView1.Size = new Size(599, 416);
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
            SPTSettingsTab.Size = new Size(605, 422);
            SPTSettingsTab.TabIndex = 2;
            SPTSettingsTab.Text = "SPTSettings";
            SPTSettingsTab.UseVisualStyleBackColor = true;
            // 
            // toolStrip2
            // 
            toolStrip2.Dock = DockStyle.Right;
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripButton6 });
            toolStrip2.Location = new Point(613, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(99, 450);
            toolStrip2.TabIndex = 0;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton6
            // 
            toolStripButton6.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton6.Image = (Image)resources.GetObject("toolStripButton6.Image");
            toolStripButton6.ImageTransparentColor = Color.Magenta;
            toolStripButton6.Name = "toolStripButton6";
            toolStripButton6.Size = new Size(96, 19);
            toolStripButton6.Text = "toolStripButton6";
            // 
            // miniToolStrip
            // 
            miniToolStrip.AccessibleName = "New item selection";
            miniToolStrip.AccessibleRole = AccessibleRole.ButtonDropDown;
            miniToolStrip.AutoSize = false;
            miniToolStrip.CanOverflow = false;
            miniToolStrip.Dock = DockStyle.None;
            miniToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            miniToolStrip.Location = new Point(10, 55);
            miniToolStrip.Name = "miniToolStrip";
            miniToolStrip.Size = new Size(55, 416);
            miniToolStrip.TabIndex = 1;
            // 
            // ModsPanel
            // 
            ModsPanel.Controls.Add(listView2);
            ModsPanel.Controls.Add(toolStrip5);
            ModsPanel.Controls.Add(toolStrip4);
            ModsPanel.Dock = DockStyle.Fill;
            ModsPanel.Location = new Point(88, 0);
            ModsPanel.Name = "ModsPanel";
            ModsPanel.Size = new Size(712, 450);
            ModsPanel.TabIndex = 3;
            // 
            // listView2
            // 
            listView2.Dock = DockStyle.Fill;
            listView2.Location = new Point(0, 25);
            listView2.Name = "listView2";
            listView2.Size = new Size(645, 425);
            listView2.TabIndex = 3;
            listView2.UseCompatibleStateImageBehavior = false;
            // 
            // toolStrip5
            // 
            toolStrip5.Dock = DockStyle.Right;
            toolStrip5.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip5.Items.AddRange(new ToolStripItem[] { toolStripButton8, toolStripButton10, toolStripSeparator4, toolStripButton9, toolStripButton13, toolStripSeparator1, toolStripButton12, toolStripButton14, toolStripSeparator2, toolStripButton11 });
            toolStrip5.Location = new Point(645, 25);
            toolStrip5.Name = "toolStrip5";
            toolStrip5.Size = new Size(67, 425);
            toolStrip5.TabIndex = 2;
            toolStrip5.Text = "toolStrip5";
            // 
            // toolStripButton8
            // 
            toolStripButton8.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton8.Image = (Image)resources.GetObject("toolStripButton8.Image");
            toolStripButton8.ImageTransparentColor = Color.Magenta;
            toolStripButton8.Name = "toolStripButton8";
            toolStripButton8.Size = new Size(64, 19);
            toolStripButton8.Text = "Download";
            // 
            // toolStripButton10
            // 
            toolStripButton10.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton10.Image = (Image)resources.GetObject("toolStripButton10.Image");
            toolStripButton10.ImageTransparentColor = Color.Magenta;
            toolStripButton10.Name = "toolStripButton10";
            toolStripButton10.Size = new Size(64, 19);
            toolStripButton10.Text = "Install";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(64, 6);
            // 
            // toolStripButton9
            // 
            toolStripButton9.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton9.Image = (Image)resources.GetObject("toolStripButton9.Image");
            toolStripButton9.ImageTransparentColor = Color.Magenta;
            toolStripButton9.Name = "toolStripButton9";
            toolStripButton9.Size = new Size(64, 19);
            toolStripButton9.Text = "Update All";
            // 
            // toolStripButton13
            // 
            toolStripButton13.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton13.Image = (Image)resources.GetObject("toolStripButton13.Image");
            toolStripButton13.ImageTransparentColor = Color.Magenta;
            toolStripButton13.Name = "toolStripButton13";
            toolStripButton13.Size = new Size(64, 19);
            toolStripButton13.Text = "Update";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(64, 6);
            // 
            // toolStripButton12
            // 
            toolStripButton12.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton12.Image = (Image)resources.GetObject("toolStripButton12.Image");
            toolStripButton12.ImageTransparentColor = Color.Magenta;
            toolStripButton12.Name = "toolStripButton12";
            toolStripButton12.Size = new Size(64, 19);
            toolStripButton12.Text = "Enable";
            // 
            // toolStripButton14
            // 
            toolStripButton14.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton14.Image = (Image)resources.GetObject("toolStripButton14.Image");
            toolStripButton14.ImageTransparentColor = Color.Magenta;
            toolStripButton14.Name = "toolStripButton14";
            toolStripButton14.Size = new Size(64, 19);
            toolStripButton14.Text = "Disable";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(64, 6);
            // 
            // toolStripButton11
            // 
            toolStripButton11.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton11.Image = (Image)resources.GetObject("toolStripButton11.Image");
            toolStripButton11.ImageTransparentColor = Color.Magenta;
            toolStripButton11.Name = "toolStripButton11";
            toolStripButton11.Size = new Size(64, 19);
            toolStripButton11.Text = "Remove";
            // 
            // toolStrip4
            // 
            toolStrip4.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip4.Items.AddRange(new ToolStripItem[] { toolStripLabel1 });
            toolStrip4.Location = new Point(0, 0);
            toolStrip4.Name = "toolStrip4";
            toolStrip4.Size = new Size(712, 25);
            toolStrip4.TabIndex = 1;
            toolStrip4.Text = "toolStrip4";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(219, 22);
            toolStripLabel1.Text = "Mods: 98/100 BepInEx: 49/50 User: 49/50";
            // 
            // InstanceManagerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ModsPanel);
            Controls.Add(UserPanel);
            Controls.Add(toolStrip1);
            Name = "InstanceManagerForm";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "InstanceEditorForm";
            Load += InstanceEditorForm_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            UserPanel.ResumeLayout(false);
            UserPanel.PerformLayout();
            UserTab.ResumeLayout(false);
            ProfilesTab.ResumeLayout(false);
            ProfilesTab.PerformLayout();
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            ModsPanel.ResumeLayout(false);
            ModsPanel.PerformLayout();
            toolStrip5.ResumeLayout(false);
            toolStrip5.PerformLayout();
            toolStrip4.ResumeLayout(false);
            toolStrip4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private Panel UserPanel;
        private ColumnHeader NameColumn;
        private ToolStripButton toolStripButton7;
        private ToolStrip miniToolStrip;
        private TabControl UserTab;
        private TabPage ModsTab;
        private TabPage ProfilesTab;
        private ToolStrip toolStrip3;
        private ToolStripButton toolStripButton5;
        private ToolStripButton toolStripButton4;
        private ListView listView1;
        private ColumnHeader ID;
        private ColumnHeader Edition;
        private ColumnHeader PMCLevel;
        private ColumnHeader ScavLevel;
        private ColumnHeader AKIVersion;
        private TabPage SPTSettingsTab;
        private ToolStrip toolStrip2;
        private ToolStripButton toolStripButton6;
        private Panel ModsPanel;
        private ToolStrip toolStrip4;
        private ToolStrip toolStrip5;
        private ToolStripButton toolStripButton8;
        private ToolStripButton toolStripButton9;
        private ToolStripButton toolStripButton10;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton12;
        private ToolStripButton toolStripButton13;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButton11;
        private ToolStripButton toolStripButton14;
        private ToolStripLabel toolStripLabel1;
        private ListView listView2;
        private ToolStripSeparator toolStripSeparator4;
    }
}
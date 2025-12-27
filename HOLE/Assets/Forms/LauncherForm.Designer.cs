namespace HOLE.Assets.Forms
{
    partial class LauncherForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ListViewGroup listViewGroup3 = new ListViewGroup("", HorizontalAlignment.Left);
            ListViewItem listViewItem3 = new ListViewItem("TestInstance");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherForm));
            toolStripContainer1 = new ToolStripContainer();
            NewsStrip = new ToolStrip();
            InfoStrip = new ToolStrip();
            InstancesView = new ListView();
            InstanceStrip = new ToolStrip();
            InstanceIcon = new ToolStripButton();
            InstanceName = new ToolStripButton();
            GroupBox = new ToolStripComboBox();
            toolStripSeparator3 = new ToolStripSeparator();
            StartGameButton = new ToolStripButton();
            ServerSectionSeparator = new ToolStripSeparator();
            StartServerButton = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            FolderButton = new ToolStripButton();
            EditButton = new ToolStripButton();
            ShortcutButton = new ToolStripButton();
            DownloadModsButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            DeleteButton = new ToolStripButton();
            toolStrip = new ToolStrip();
            AddInstanceButton = new ToolStripButton();
            AddFikaButton = new ToolStripDropDownButton();
            FikaWikiButton = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            AddFikaClientButton = new ToolStripMenuItem();
            AddFikaServerButton = new ToolStripMenuItem();
            toolStripSeparator8 = new ToolStripSeparator();
            AddFikaHeadlessButton = new ToolStripMenuItem();
            FoldersButton = new ToolStripDropDownButton();
            FoldersLauncherButton = new ToolStripMenuItem();
            FoldersInstancesButton = new ToolStripMenuItem();
            FolderInstanceIcons = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            FoldersModsButton = new ToolStripMenuItem();
            FoldersModCache = new ToolStripMenuItem();
            FoldersModIcons = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            FoldersLogs = new ToolStripMenuItem();
            SettingsButton = new ToolStripButton();
            UpdateButton = new ToolStripButton();
            CatButton = new ToolStripButton();
            ProfileButton = new ToolStripDropDownButton();
            toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.RightToolStripPanel.SuspendLayout();
            toolStripContainer1.TopToolStripPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            InstanceStrip.SuspendLayout();
            toolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            toolStripContainer1.BottomToolStripPanel.Controls.Add(NewsStrip);
            toolStripContainer1.BottomToolStripPanel.Controls.Add(InfoStrip);
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.Controls.Add(InstancesView);
            toolStripContainer1.ContentPanel.Size = new Size(681, 404);
            toolStripContainer1.Dock = DockStyle.Fill;
            toolStripContainer1.Location = new Point(0, 0);
            toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.RightToolStripPanel
            // 
            toolStripContainer1.RightToolStripPanel.Controls.Add(InstanceStrip);
            toolStripContainer1.Size = new Size(800, 479);
            toolStripContainer1.TabIndex = 0;
            toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip);
            // 
            // NewsStrip
            // 
            NewsStrip.Dock = DockStyle.None;
            NewsStrip.Location = new Point(0, 0);
            NewsStrip.Name = "NewsStrip";
            NewsStrip.RenderMode = ToolStripRenderMode.System;
            NewsStrip.Size = new Size(800, 25);
            NewsStrip.Stretch = true;
            NewsStrip.TabIndex = 3;
            NewsStrip.Text = "toolStrip4";
            // 
            // InfoStrip
            // 
            InfoStrip.Dock = DockStyle.None;
            InfoStrip.Location = new Point(0, 25);
            InfoStrip.Name = "InfoStrip";
            InfoStrip.RenderMode = ToolStripRenderMode.System;
            InfoStrip.Size = new Size(800, 25);
            InfoStrip.Stretch = true;
            InfoStrip.TabIndex = 2;
            InfoStrip.Text = "toolStrip3";
            // 
            // InstancesView
            // 
            InstancesView.Dock = DockStyle.Fill;
            listViewGroup3.Name = "Instances";
            listViewGroup3.Tag = "";
            InstancesView.Groups.AddRange(new ListViewGroup[] { listViewGroup3 });
            InstancesView.Items.AddRange(new ListViewItem[] { listViewItem3 });
            InstancesView.LabelEdit = true;
            InstancesView.LabelWrap = false;
            InstancesView.Location = new Point(0, 0);
            InstancesView.MultiSelect = false;
            InstancesView.Name = "InstancesView";
            InstancesView.RightToLeft = RightToLeft.No;
            InstancesView.Size = new Size(681, 404);
            InstancesView.TabIndex = 0;
            InstancesView.TileSize = new Size(200, 100);
            InstancesView.UseCompatibleStateImageBehavior = false;
            InstancesView.AfterLabelEdit += InstancesView_AfterLabelEdit;
            InstancesView.SelectedIndexChanged += InstancesView_SelectedIndexChanged;
            // 
            // InstanceStrip
            // 
            InstanceStrip.AllowItemReorder = true;
            InstanceStrip.Dock = DockStyle.None;
            InstanceStrip.GripStyle = ToolStripGripStyle.Hidden;
            InstanceStrip.Items.AddRange(new ToolStripItem[] { InstanceIcon, InstanceName, GroupBox, toolStripSeparator3, StartGameButton, ServerSectionSeparator, StartServerButton, toolStripSeparator2, EditButton, ShortcutButton, FolderButton, DownloadModsButton, toolStripSeparator1, DeleteButton });
            InstanceStrip.Location = new Point(0, 0);
            InstanceStrip.Name = "InstanceStrip";
            InstanceStrip.Padding = new Padding(0);
            InstanceStrip.RenderMode = ToolStripRenderMode.System;
            InstanceStrip.RightToLeft = RightToLeft.No;
            InstanceStrip.Size = new Size(119, 404);
            InstanceStrip.Stretch = true;
            InstanceStrip.TabIndex = 1;
            InstanceStrip.Text = "toolStrip2";
            // 
            // InstanceIcon
            // 
            InstanceIcon.AutoSize = false;
            InstanceIcon.BackgroundImage = (Image)resources.GetObject("InstanceIcon.BackgroundImage");
            InstanceIcon.BackgroundImageLayout = ImageLayout.Stretch;
            InstanceIcon.DisplayStyle = ToolStripItemDisplayStyle.Image;
            InstanceIcon.ImageTransparentColor = Color.Magenta;
            InstanceIcon.Name = "InstanceIcon";
            InstanceIcon.Size = new Size(119, 119);
            InstanceIcon.Text = "InstanceIcon";
            InstanceIcon.Click += InstanceIcon_Click;
            // 
            // InstanceName
            // 
            InstanceName.DisplayStyle = ToolStripItemDisplayStyle.Text;
            InstanceName.Image = (Image)resources.GetObject("InstanceName.Image");
            InstanceName.ImageTransparentColor = Color.Magenta;
            InstanceName.Name = "InstanceName";
            InstanceName.Size = new Size(118, 19);
            InstanceName.Text = "Instance Name";
            // 
            // GroupBox
            // 
            GroupBox.Name = "GroupBox";
            GroupBox.Size = new Size(116, 23);
            GroupBox.KeyDown += GroupBox_KeyDown;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(118, 6);
            // 
            // StartGameButton
            // 
            StartGameButton.Image = (Image)resources.GetObject("StartGameButton.Image");
            StartGameButton.ImageAlign = ContentAlignment.MiddleLeft;
            StartGameButton.ImageTransparentColor = Color.Magenta;
            StartGameButton.Name = "StartGameButton";
            StartGameButton.Size = new Size(118, 20);
            StartGameButton.Text = "Play";
            StartGameButton.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ServerSectionSeparator
            // 
            ServerSectionSeparator.Name = "ServerSectionSeparator";
            ServerSectionSeparator.Size = new Size(118, 6);
            // 
            // StartServerButton
            // 
            StartServerButton.Image = (Image)resources.GetObject("StartServerButton.Image");
            StartServerButton.ImageAlign = ContentAlignment.MiddleLeft;
            StartServerButton.ImageTransparentColor = Color.Magenta;
            StartServerButton.Name = "StartServerButton";
            StartServerButton.Size = new Size(118, 20);
            StartServerButton.Text = "Start Server";
            StartServerButton.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(118, 6);
            // 
            // FolderButton
            // 
            FolderButton.Image = (Image)resources.GetObject("FolderButton.Image");
            FolderButton.ImageAlign = ContentAlignment.MiddleLeft;
            FolderButton.ImageTransparentColor = Color.Magenta;
            FolderButton.Name = "FolderButton";
            FolderButton.Size = new Size(118, 20);
            FolderButton.Text = "Folder";
            FolderButton.TextAlign = ContentAlignment.MiddleLeft;
            FolderButton.Click += FolderButton_Click;
            // 
            // EditButton
            // 
            EditButton.Image = (Image)resources.GetObject("EditButton.Image");
            EditButton.ImageAlign = ContentAlignment.MiddleLeft;
            EditButton.ImageTransparentColor = Color.Magenta;
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(118, 20);
            EditButton.Text = "Edit";
            EditButton.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ShortcutButton
            // 
            ShortcutButton.Image = (Image)resources.GetObject("ShortcutButton.Image");
            ShortcutButton.ImageAlign = ContentAlignment.MiddleLeft;
            ShortcutButton.ImageTransparentColor = Color.Magenta;
            ShortcutButton.Name = "ShortcutButton";
            ShortcutButton.Size = new Size(118, 20);
            ShortcutButton.Text = "Create Shortcut";
            ShortcutButton.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // DownloadModsButton
            // 
            DownloadModsButton.Image = (Image)resources.GetObject("DownloadModsButton.Image");
            DownloadModsButton.ImageTransparentColor = Color.Magenta;
            DownloadModsButton.Name = "DownloadModsButton";
            DownloadModsButton.Size = new Size(118, 20);
            DownloadModsButton.Text = "Download Mods";
            DownloadModsButton.Click += DownloadModsButton_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(118, 6);
            // 
            // DeleteButton
            // 
            DeleteButton.Image = (Image)resources.GetObject("DeleteButton.Image");
            DeleteButton.ImageAlign = ContentAlignment.MiddleLeft;
            DeleteButton.ImageTransparentColor = Color.Magenta;
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(118, 20);
            DeleteButton.Text = "Delete";
            DeleteButton.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // toolStrip
            // 
            toolStrip.Dock = DockStyle.None;
            toolStrip.Items.AddRange(new ToolStripItem[] { AddInstanceButton, AddFikaButton, FoldersButton, SettingsButton, UpdateButton, CatButton, ProfileButton });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.RenderMode = ToolStripRenderMode.System;
            toolStrip.Size = new Size(800, 25);
            toolStrip.Stretch = true;
            toolStrip.TabIndex = 0;
            toolStrip.Text = "toolStrip1";
            // 
            // AddInstanceButton
            // 
            AddInstanceButton.Image = (Image)resources.GetObject("AddInstanceButton.Image");
            AddInstanceButton.ImageTransparentColor = Color.Magenta;
            AddInstanceButton.Name = "AddInstanceButton";
            AddInstanceButton.Size = new Size(96, 22);
            AddInstanceButton.Text = "Add Instance";
            AddInstanceButton.Click += AddInstanceButton_Click;
            // 
            // AddFikaButton
            // 
            AddFikaButton.DropDownItems.AddRange(new ToolStripItem[] { FikaWikiButton, toolStripSeparator6, AddFikaClientButton, AddFikaServerButton, toolStripSeparator8, AddFikaHeadlessButton });
            AddFikaButton.Image = (Image)resources.GetObject("AddFikaButton.Image");
            AddFikaButton.ImageTransparentColor = Color.Magenta;
            AddFikaButton.Name = "AddFikaButton";
            AddFikaButton.Size = new Size(60, 22);
            AddFikaButton.Text = "FIKA";
            // 
            // FikaWikiButton
            // 
            FikaWikiButton.Name = "FikaWikiButton";
            FikaWikiButton.Size = new Size(121, 22);
            FikaWikiButton.Text = "Wiki";
            FikaWikiButton.Click += FikaWikiButton_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(118, 6);
            // 
            // AddFikaClientButton
            // 
            AddFikaClientButton.Name = "AddFikaClientButton";
            AddFikaClientButton.Size = new Size(121, 22);
            AddFikaClientButton.Text = "Client";
            AddFikaClientButton.Click += AddFikaClientButton_Click;
            // 
            // AddFikaServerButton
            // 
            AddFikaServerButton.Name = "AddFikaServerButton";
            AddFikaServerButton.Size = new Size(121, 22);
            AddFikaServerButton.Text = "Server";
            AddFikaServerButton.Click += AddFikaServerButton_Click;
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(118, 6);
            // 
            // AddFikaHeadlessButton
            // 
            AddFikaHeadlessButton.Name = "AddFikaHeadlessButton";
            AddFikaHeadlessButton.Size = new Size(121, 22);
            AddFikaHeadlessButton.Text = "Headless";
            // 
            // FoldersButton
            // 
            FoldersButton.DropDownItems.AddRange(new ToolStripItem[] { FoldersLauncherButton, FoldersInstancesButton, FolderInstanceIcons, toolStripSeparator5, FoldersModsButton, FoldersModCache, FoldersModIcons, toolStripSeparator4, FoldersLogs });
            FoldersButton.Image = (Image)resources.GetObject("FoldersButton.Image");
            FoldersButton.ImageTransparentColor = Color.Magenta;
            FoldersButton.Name = "FoldersButton";
            FoldersButton.Size = new Size(74, 22);
            FoldersButton.Text = "Folders";
            // 
            // FoldersLauncherButton
            // 
            FoldersLauncherButton.Name = "FoldersLauncherButton";
            FoldersLauncherButton.Size = new Size(149, 22);
            FoldersLauncherButton.Text = "Launcher";
            FoldersLauncherButton.Click += FoldersLauncherButton_Click;
            // 
            // FoldersInstancesButton
            // 
            FoldersInstancesButton.Name = "FoldersInstancesButton";
            FoldersInstancesButton.Size = new Size(149, 22);
            FoldersInstancesButton.Text = "Instances";
            FoldersInstancesButton.Click += FoldersInstancesButton_Click;
            // 
            // FolderInstanceIcons
            // 
            FolderInstanceIcons.Name = "FolderInstanceIcons";
            FolderInstanceIcons.Size = new Size(149, 22);
            FolderInstanceIcons.Text = "Instance Icons";
            FolderInstanceIcons.Click += FolderInstanceIcons_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(146, 6);
            // 
            // FoldersModsButton
            // 
            FoldersModsButton.Name = "FoldersModsButton";
            FoldersModsButton.Size = new Size(149, 22);
            FoldersModsButton.Text = "Mods";
            FoldersModsButton.Click += FoldersModsButton_Click;
            // 
            // FoldersModCache
            // 
            FoldersModCache.Name = "FoldersModCache";
            FoldersModCache.Size = new Size(149, 22);
            FoldersModCache.Text = "ModCache";
            FoldersModCache.Click += FoldersModCache_Click;
            // 
            // FoldersModIcons
            // 
            FoldersModIcons.Name = "FoldersModIcons";
            FoldersModIcons.Size = new Size(149, 22);
            FoldersModIcons.Text = "ModIcons";
            FoldersModIcons.Click += FoldersModIcons_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(146, 6);
            // 
            // FoldersLogs
            // 
            FoldersLogs.Name = "FoldersLogs";
            FoldersLogs.Size = new Size(149, 22);
            FoldersLogs.Text = "Logs";
            FoldersLogs.Click += FoldersLogs_Click;
            // 
            // SettingsButton
            // 
            SettingsButton.Image = (Image)resources.GetObject("SettingsButton.Image");
            SettingsButton.ImageTransparentColor = Color.Magenta;
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Size = new Size(69, 22);
            SettingsButton.Text = "Settings";
            SettingsButton.Click += SettingsButton_Click;
            // 
            // UpdateButton
            // 
            UpdateButton.Image = (Image)resources.GetObject("UpdateButton.Image");
            UpdateButton.ImageTransparentColor = Color.Magenta;
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(65, 22);
            UpdateButton.Text = "Update";
            // 
            // CatButton
            // 
            CatButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            CatButton.Image = (Image)resources.GetObject("CatButton.Image");
            CatButton.ImageTransparentColor = Color.Magenta;
            CatButton.Name = "CatButton";
            CatButton.Size = new Size(23, 22);
            CatButton.Text = "Cat";
            // 
            // ProfileButton
            // 
            ProfileButton.Alignment = ToolStripItemAlignment.Right;
            ProfileButton.Image = (Image)resources.GetObject("ProfileButton.Image");
            ProfileButton.ImageTransparentColor = Color.Magenta;
            ProfileButton.Name = "ProfileButton";
            ProfileButton.Size = new Size(105, 22);
            ProfileButton.Text = "Profile Name";
            ProfileButton.ToolTipText = " ";
            // 
            // LauncherForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 479);
            Controls.Add(toolStripContainer1);
            Name = "LauncherForm";
            Text = "Hero's Only Launcher Experience (HOLE)";
            Load += Form1_Load;
            toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            toolStripContainer1.BottomToolStripPanel.PerformLayout();
            toolStripContainer1.ContentPanel.ResumeLayout(false);
            toolStripContainer1.RightToolStripPanel.ResumeLayout(false);
            toolStripContainer1.RightToolStripPanel.PerformLayout();
            toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.PerformLayout();
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            InstanceStrip.ResumeLayout(false);
            InstanceStrip.PerformLayout();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ToolStripContainer toolStripContainer1;
        private ToolStrip toolStrip;
        private ToolStrip NewsStrip;
        private ToolStrip InfoStrip;
        private ToolStrip InstanceStrip;
        private ToolStripButton SettingsButton;
        private ToolStripButton UpdateButton;
        private ToolStripButton CatButton;
        private ToolStripButton InstanceIcon;
        private ToolStripButton InstanceName;
        private ToolStripButton StartGameButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton EditButton;
        private ToolStripButton DeleteButton;
        private ToolStripButton ShortcutButton;
        private ToolStripButton FolderButton;
        private ListView InstancesView;
        private ToolStripDropDownButton FoldersButton;
        private ToolStripMenuItem FoldersLauncherButton;
        private ToolStripMenuItem FoldersInstancesButton;
        private ToolStripDropDownButton ProfileButton;
        private ToolStripButton AddInstanceButton;
        private ToolStripDropDownButton AddFikaButton;
        private ToolStripMenuItem AddFikaClientButton;
        private ToolStripMenuItem AddFikaServerButton;
        private ToolStripButton DownloadModsButton;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem FoldersModsButton;
        private ToolStripMenuItem FolderInstanceIcons;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem FoldersLogs;
        private ToolStripMenuItem FoldersModIcons;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem FoldersModCache;
        private ToolStripComboBox GroupBox;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem FikaWikiButton;
        private ToolStripButton StartServerButton;
        private ToolStripSeparator ServerSectionSeparator;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem AddFikaHeadlessButton;
    }
}

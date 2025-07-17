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
            ListViewGroup listViewGroup1 = new ListViewGroup("", HorizontalAlignment.Left);
            ListViewItem listViewItem1 = new ListViewItem("TestInstance");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherForm));
            toolStripContainer1 = new ToolStripContainer();
            NewsStrip = new ToolStrip();
            InfoStrip = new ToolStrip();
            InstancesView = new ListView();
            InstanceStrip = new ToolStrip();
            InstanceIcon = new ToolStripButton();
            InstanceName = new ToolStripButton();
            LaunchButton = new ToolStripButton();
            KillButton = new ToolStripButton();
            GroupButton = new ToolStripDropDownButton();
            enterGroupNameToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripComboBox1 = new ToolStripComboBox();
            toolStripSeparator1 = new ToolStripSeparator();
            EditButton = new ToolStripButton();
            FolderButton = new ToolStripButton();
            ExportButton = new ToolStripButton();
            CopyButton = new ToolStripButton();
            DeleteButton = new ToolStripButton();
            ShortcutButton = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            downloadModsButton = new ToolStripButton();
            toolStrip = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            AddInstanceButton = new ToolStripDropDownButton();
            clientToolStripMenuItem = new ToolStripMenuItem();
            serverToolStripMenuItem = new ToolStripMenuItem();
            FoldersButton = new ToolStripDropDownButton();
            launcherToolStripMenuItem = new ToolStripMenuItem();
            iconsToolStripMenuItem = new ToolStripMenuItem();
            modsToolStripMenuItem = new ToolStripMenuItem();
            instancesToolStripMenuItem = new ToolStripMenuItem();
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
            listViewGroup1.Name = "Instances";
            listViewGroup1.Tag = "";
            InstancesView.Groups.AddRange(new ListViewGroup[] { listViewGroup1 });
            InstancesView.Items.AddRange(new ListViewItem[] { listViewItem1 });
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
            // 
            // InstanceStrip
            // 
            InstanceStrip.AllowItemReorder = true;
            InstanceStrip.Dock = DockStyle.None;
            InstanceStrip.GripStyle = ToolStripGripStyle.Hidden;
            InstanceStrip.Items.AddRange(new ToolStripItem[] { InstanceIcon, InstanceName, GroupButton, LaunchButton, KillButton, toolStripSeparator1, EditButton, FolderButton, ExportButton, CopyButton, DeleteButton, ShortcutButton, toolStripSeparator3, downloadModsButton });
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
            // LaunchButton
            // 
            LaunchButton.Image = (Image)resources.GetObject("LaunchButton.Image");
            LaunchButton.ImageAlign = ContentAlignment.MiddleLeft;
            LaunchButton.ImageTransparentColor = Color.Magenta;
            LaunchButton.Name = "LaunchButton";
            LaunchButton.Size = new Size(118, 20);
            LaunchButton.Text = "Launch";
            LaunchButton.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // KillButton
            // 
            KillButton.Image = (Image)resources.GetObject("KillButton.Image");
            KillButton.ImageAlign = ContentAlignment.MiddleLeft;
            KillButton.ImageTransparentColor = Color.Magenta;
            KillButton.Name = "KillButton";
            KillButton.Size = new Size(118, 20);
            KillButton.Text = "Kill";
            KillButton.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // GroupButton
            // 
            GroupButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            GroupButton.DropDownItems.AddRange(new ToolStripItem[] { enterGroupNameToolStripMenuItem, toolStripSeparator2, toolStripComboBox1 });
            GroupButton.Name = "GroupButton";
            GroupButton.Size = new Size(118, 19);
            GroupButton.Text = "Group";
            // 
            // enterGroupNameToolStripMenuItem
            // 
            enterGroupNameToolStripMenuItem.Name = "enterGroupNameToolStripMenuItem";
            enterGroupNameToolStripMenuItem.Size = new Size(181, 22);
            enterGroupNameToolStripMenuItem.Text = "Enter Group Name";
            enterGroupNameToolStripMenuItem.TextImageRelation = TextImageRelation.Overlay;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(178, 6);
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(121, 23);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(118, 6);
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
            // FolderButton
            // 
            FolderButton.Image = (Image)resources.GetObject("FolderButton.Image");
            FolderButton.ImageAlign = ContentAlignment.MiddleLeft;
            FolderButton.ImageTransparentColor = Color.Magenta;
            FolderButton.Name = "FolderButton";
            FolderButton.Size = new Size(118, 20);
            FolderButton.Text = "Folder";
            FolderButton.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ExportButton
            // 
            ExportButton.Image = (Image)resources.GetObject("ExportButton.Image");
            ExportButton.ImageAlign = ContentAlignment.MiddleLeft;
            ExportButton.ImageTransparentColor = Color.Magenta;
            ExportButton.Name = "ExportButton";
            ExportButton.Size = new Size(118, 20);
            ExportButton.Text = "Export";
            ExportButton.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CopyButton
            // 
            CopyButton.Image = (Image)resources.GetObject("CopyButton.Image");
            CopyButton.ImageAlign = ContentAlignment.MiddleLeft;
            CopyButton.ImageTransparentColor = Color.Magenta;
            CopyButton.Name = "CopyButton";
            CopyButton.Size = new Size(118, 20);
            CopyButton.Text = "Copy";
            CopyButton.TextAlign = ContentAlignment.MiddleLeft;
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
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(118, 6);
            // 
            // downloadModsButton
            // 
            downloadModsButton.Image = (Image)resources.GetObject("downloadModsButton.Image");
            downloadModsButton.ImageTransparentColor = Color.Magenta;
            downloadModsButton.Name = "downloadModsButton";
            downloadModsButton.Size = new Size(118, 20);
            downloadModsButton.Text = "Download Mods";
            downloadModsButton.Click += downloadModsButton_Click;
            // 
            // toolStrip
            // 
            toolStrip.Dock = DockStyle.None;
            toolStrip.Items.AddRange(new ToolStripItem[] { toolStripButton1, AddInstanceButton, FoldersButton, SettingsButton, UpdateButton, CatButton, ProfileButton });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.RenderMode = ToolStripRenderMode.System;
            toolStrip.Size = new Size(800, 25);
            toolStrip.Stretch = true;
            toolStrip.TabIndex = 0;
            toolStrip.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(96, 22);
            toolStripButton1.Text = "Add Instance";
            // 
            // AddInstanceButton
            // 
            AddInstanceButton.DropDownItems.AddRange(new ToolStripItem[] { clientToolStripMenuItem, serverToolStripMenuItem });
            AddInstanceButton.Image = (Image)resources.GetObject("AddInstanceButton.Image");
            AddInstanceButton.ImageTransparentColor = Color.Magenta;
            AddInstanceButton.Name = "AddInstanceButton";
            AddInstanceButton.Size = new Size(85, 22);
            AddInstanceButton.Text = "Add FIKA";
            // 
            // clientToolStripMenuItem
            // 
            clientToolStripMenuItem.Name = "clientToolStripMenuItem";
            clientToolStripMenuItem.Size = new Size(180, 22);
            clientToolStripMenuItem.Text = "Client";
            // 
            // serverToolStripMenuItem
            // 
            serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            serverToolStripMenuItem.Size = new Size(180, 22);
            serverToolStripMenuItem.Text = "Server";
            // 
            // FoldersButton
            // 
            FoldersButton.DropDownItems.AddRange(new ToolStripItem[] { launcherToolStripMenuItem, instancesToolStripMenuItem });
            FoldersButton.Image = (Image)resources.GetObject("FoldersButton.Image");
            FoldersButton.ImageTransparentColor = Color.Magenta;
            FoldersButton.Name = "FoldersButton";
            FoldersButton.Size = new Size(74, 22);
            FoldersButton.Text = "Folders";
            // 
            // launcherToolStripMenuItem
            // 
            launcherToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { iconsToolStripMenuItem, modsToolStripMenuItem });
            launcherToolStripMenuItem.Name = "launcherToolStripMenuItem";
            launcherToolStripMenuItem.Size = new Size(123, 22);
            launcherToolStripMenuItem.Text = "Launcher";
            // 
            // iconsToolStripMenuItem
            // 
            iconsToolStripMenuItem.Name = "iconsToolStripMenuItem";
            iconsToolStripMenuItem.Size = new Size(104, 22);
            iconsToolStripMenuItem.Text = "Icons";
            // 
            // modsToolStripMenuItem
            // 
            modsToolStripMenuItem.Name = "modsToolStripMenuItem";
            modsToolStripMenuItem.Size = new Size(104, 22);
            modsToolStripMenuItem.Text = "Mods";
            // 
            // instancesToolStripMenuItem
            // 
            instancesToolStripMenuItem.Name = "instancesToolStripMenuItem";
            instancesToolStripMenuItem.Size = new Size(123, 22);
            instancesToolStripMenuItem.Text = "Instances";
            // 
            // SettingsButton
            // 
            SettingsButton.Image = (Image)resources.GetObject("SettingsButton.Image");
            SettingsButton.ImageTransparentColor = Color.Magenta;
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Size = new Size(69, 22);
            SettingsButton.Text = "Settings";
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
        private ToolStripButton LaunchButton;
        private ToolStripButton KillButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton EditButton;
        private ToolStripButton ExportButton;
        private ToolStripButton DeleteButton;
        private ToolStripButton ShortcutButton;
        private ToolStripButton FolderButton;
        private ToolStripButton CopyButton;
        private ToolStripDropDownButton GroupButton;
        private ListView InstancesView;
        private ToolStripComboBox toolStripComboBox1;
        private ToolStripMenuItem enterGroupNameToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripDropDownButton FoldersButton;
        private ToolStripMenuItem launcherToolStripMenuItem;
        private ToolStripMenuItem iconsToolStripMenuItem;
        private ToolStripMenuItem modsToolStripMenuItem;
        private ToolStripMenuItem instancesToolStripMenuItem;
        private ToolStripDropDownButton ProfileButton;
        private ToolStripButton toolStripButton1;
        private ToolStripDropDownButton AddInstanceButton;
        private ToolStripMenuItem clientToolStripMenuItem;
        private ToolStripMenuItem serverToolStripMenuItem;
        private ToolStripButton downloadModsButton;
        private ToolStripSeparator toolStripSeparator3;
    }
}

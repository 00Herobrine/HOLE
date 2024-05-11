namespace HOLE
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            toolStripContainer2 = new ToolStripContainer();
            toolStrip4 = new ToolStrip();
            LastPlayedLabel = new ToolStripLabel();
            TotalPlayTimeLabel = new ToolStripLabel();
            toolStripContainer1 = new ToolStripContainer();
            toolStrip3 = new ToolStrip();
            toolStripLabel3 = new ToolStripLabel();
            InstanceView = new ListView();
            toolStrip1 = new ToolStrip();
            InstanceLogoButton = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            AkiVersionLabel = new ToolStripLabel();
            AkiStatusLabel = new ToolStripLabel();
            StartAKIButton = new ToolStripButton();
            KillAKIButton = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripLabel2 = new ToolStripLabel();
            PlayButton = new ToolStripButton();
            KillGameButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            EditInstanceButton = new ToolStripButton();
            InstanceFolderButton = new ToolStripButton();
            toolStripSplitButton4 = new ToolStripSplitButton();
            CopyInstanceButton = new ToolStripButton();
            DeleteInstanceButton = new ToolStripButton();
            toolStrip2 = new ToolStrip();
            ProfileButton = new ToolStripSplitButton();
            AddInstanceButton = new ToolStripSplitButton();
            AddNewInstanceButton = new ToolStripMenuItem();
            AddExistingInstanceButton = new ToolStripMenuItem();
            FoldersButton = new ToolStripSplitButton();
            InstanceFolder = new ToolStripMenuItem();
            InstancesFolderButton = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            ModsFolderButton = new ToolStripMenuItem();
            SharedModsFolderButton = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            LauncherFolderButton = new ToolStripMenuItem();
            IconsFolderButton = new ToolStripMenuItem();
            SettingsButton = new ToolStripButton();
            HelpButton = new ToolStripSplitButton();
            UpdateButton = new ToolStripButton();
            panel1.SuspendLayout();
            toolStripContainer2.TopToolStripPanel.SuspendLayout();
            toolStripContainer2.SuspendLayout();
            toolStrip4.SuspendLayout();
            toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.RightToolStripPanel.SuspendLayout();
            toolStripContainer1.TopToolStripPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            toolStrip3.SuspendLayout();
            toolStrip1.SuspendLayout();
            toolStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gray;
            panel1.Controls.Add(toolStripContainer2);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 426);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 24);
            panel1.TabIndex = 0;
            // 
            // toolStripContainer2
            // 
            toolStripContainer2.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer2.ContentPanel
            // 
            toolStripContainer2.ContentPanel.Size = new Size(800, 0);
            toolStripContainer2.Dock = DockStyle.Fill;
            toolStripContainer2.LeftToolStripPanelVisible = false;
            toolStripContainer2.Location = new Point(0, 0);
            toolStripContainer2.Name = "toolStripContainer2";
            toolStripContainer2.RightToolStripPanelVisible = false;
            toolStripContainer2.Size = new Size(800, 24);
            toolStripContainer2.TabIndex = 0;
            toolStripContainer2.Text = "toolStripContainer2";
            // 
            // toolStripContainer2.TopToolStripPanel
            // 
            toolStripContainer2.TopToolStripPanel.Controls.Add(toolStrip4);
            // 
            // toolStrip4
            // 
            toolStrip4.BackColor = Color.Gray;
            toolStrip4.Dock = DockStyle.None;
            toolStrip4.Items.AddRange(new ToolStripItem[] { LastPlayedLabel, TotalPlayTimeLabel });
            toolStrip4.Location = new Point(0, 0);
            toolStrip4.Name = "toolStrip4";
            toolStrip4.Size = new Size(800, 25);
            toolStrip4.Stretch = true;
            toolStrip4.TabIndex = 1;
            toolStrip4.Text = "toolStrip4";
            // 
            // LastPlayedLabel
            // 
            LastPlayedLabel.ForeColor = SystemColors.HighlightText;
            LastPlayedLabel.Name = "LastPlayedLabel";
            LastPlayedLabel.Size = new Size(508, 22);
            LastPlayedLabel.Text = "Last Played '{InstanceName}' on 4/20/69 9:11 AM for 1hr 42m 32s, Total Played: 1d 4hr 32ms 16s";
            // 
            // TotalPlayTimeLabel
            // 
            TotalPlayTimeLabel.Alignment = ToolStripItemAlignment.Right;
            TotalPlayTimeLabel.ForeColor = SystemColors.HighlightText;
            TotalPlayTimeLabel.Name = "TotalPlayTimeLabel";
            TotalPlayTimeLabel.Size = new Size(172, 22);
            TotalPlayTimeLabel.Text = "Total Playtime: 12d 1hr 47m 16s";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            toolStripContainer1.BottomToolStripPanel.Controls.Add(toolStrip3);
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.BackColor = Color.DarkGray;
            toolStripContainer1.ContentPanel.Controls.Add(InstanceView);
            toolStripContainer1.ContentPanel.Size = new Size(710, 372);
            toolStripContainer1.Dock = DockStyle.Fill;
            toolStripContainer1.Location = new Point(0, 0);
            toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.RightToolStripPanel
            // 
            toolStripContainer1.RightToolStripPanel.Controls.Add(toolStrip1);
            toolStripContainer1.Size = new Size(800, 426);
            toolStripContainer1.TabIndex = 1;
            toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip2);
            // 
            // toolStrip3
            // 
            toolStrip3.BackColor = Color.Gray;
            toolStrip3.Dock = DockStyle.None;
            toolStrip3.Items.AddRange(new ToolStripItem[] { toolStripLabel3 });
            toolStrip3.Location = new Point(0, 0);
            toolStrip3.Name = "toolStrip3";
            toolStrip3.Size = new Size(800, 25);
            toolStrip3.Stretch = true;
            toolStrip3.TabIndex = 0;
            toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.ForeColor = SystemColors.HighlightText;
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(453, 22);
            toolStripLabel3.Text = "Some very long information is supposed to go here. Where from? Idk, maybe github.";
            // 
            // InstanceView
            // 
            InstanceView.BackColor = Color.DimGray;
            InstanceView.Dock = DockStyle.Fill;
            InstanceView.Location = new Point(0, 0);
            InstanceView.Name = "InstanceView";
            InstanceView.Size = new Size(710, 372);
            InstanceView.TabIndex = 0;
            InstanceView.UseCompatibleStateImageBehavior = false;
            InstanceView.SelectedIndexChanged += InstanceView_SelectedIndexChanged;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.Gray;
            toolStrip1.Dock = DockStyle.None;
            toolStrip1.Items.AddRange(new ToolStripItem[] { InstanceLogoButton, toolStripSeparator3, AkiVersionLabel, AkiStatusLabel, StartAKIButton, KillAKIButton, toolStripSeparator2, toolStripLabel2, PlayButton, KillGameButton, toolStripSeparator1, EditInstanceButton, InstanceFolderButton, toolStripSplitButton4, CopyInstanceButton, DeleteInstanceButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(5, 0, 5, 0);
            toolStrip1.Size = new Size(90, 372);
            toolStrip1.Stretch = true;
            toolStrip1.TabIndex = 3;
            // 
            // InstanceLogoButton
            // 
            InstanceLogoButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            InstanceLogoButton.Image = (Image)resources.GetObject("InstanceLogoButton.Image");
            InstanceLogoButton.ImageTransparentColor = Color.Magenta;
            InstanceLogoButton.Name = "InstanceLogoButton";
            InstanceLogoButton.Size = new Size(79, 20);
            InstanceLogoButton.Text = "Instance Logo";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(79, 6);
            // 
            // AkiVersionLabel
            // 
            AkiVersionLabel.Font = new Font("Arial", 9F);
            AkiVersionLabel.ForeColor = SystemColors.HighlightText;
            AkiVersionLabel.Name = "AkiVersionLabel";
            AkiVersionLabel.Size = new Size(79, 15);
            AkiVersionLabel.Text = "AKI-3.6.1";
            // 
            // AkiStatusLabel
            // 
            AkiStatusLabel.DisplayStyle = ToolStripItemDisplayStyle.Text;
            AkiStatusLabel.Font = new Font("Arial", 9F);
            AkiStatusLabel.ForeColor = SystemColors.HighlightText;
            AkiStatusLabel.Name = "AkiStatusLabel";
            AkiStatusLabel.Size = new Size(79, 15);
            AkiStatusLabel.Text = "OFFLINE";
            // 
            // StartAKIButton
            // 
            StartAKIButton.Font = new Font("Arial", 9F);
            StartAKIButton.ForeColor = SystemColors.HighlightText;
            StartAKIButton.Image = (Image)resources.GetObject("StartAKIButton.Image");
            StartAKIButton.ImageTransparentColor = Color.Magenta;
            StartAKIButton.Name = "StartAKIButton";
            StartAKIButton.Size = new Size(79, 20);
            StartAKIButton.Text = "Start AKI";
            StartAKIButton.Click += StartAKIButton_Click;
            // 
            // KillAKIButton
            // 
            KillAKIButton.Font = new Font("Arial", 9F);
            KillAKIButton.ForeColor = SystemColors.HighlightText;
            KillAKIButton.Image = (Image)resources.GetObject("KillAKIButton.Image");
            KillAKIButton.ImageTransparentColor = Color.Magenta;
            KillAKIButton.Name = "KillAKIButton";
            KillAKIButton.Size = new Size(79, 20);
            KillAKIButton.Text = "Kill AKI";
            KillAKIButton.Click += KillAKIButton_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(79, 6);
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Font = new Font("Arial", 9F);
            toolStripLabel2.ForeColor = SystemColors.HighlightText;
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(79, 15);
            toolStripLabel2.Text = "EFT-0.14.356";
            // 
            // PlayButton
            // 
            PlayButton.Font = new Font("Arial", 9F);
            PlayButton.ForeColor = SystemColors.HighlightText;
            PlayButton.Image = (Image)resources.GetObject("PlayButton.Image");
            PlayButton.ImageTransparentColor = Color.Magenta;
            PlayButton.Name = "PlayButton";
            PlayButton.Size = new Size(79, 20);
            PlayButton.Text = "Play";
            PlayButton.Click += PlayButton_Click;
            // 
            // KillGameButton
            // 
            KillGameButton.Font = new Font("Arial", 9F);
            KillGameButton.ForeColor = SystemColors.HighlightText;
            KillGameButton.Image = (Image)resources.GetObject("KillGameButton.Image");
            KillGameButton.ImageTransparentColor = Color.Magenta;
            KillGameButton.Name = "KillGameButton";
            KillGameButton.Size = new Size(79, 20);
            KillGameButton.Text = "Kill";
            KillGameButton.Click += KillGameButton_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(79, 6);
            // 
            // EditInstanceButton
            // 
            EditInstanceButton.Font = new Font("Arial", 9F);
            EditInstanceButton.ForeColor = SystemColors.HighlightText;
            EditInstanceButton.Image = (Image)resources.GetObject("EditInstanceButton.Image");
            EditInstanceButton.ImageTransparentColor = Color.Magenta;
            EditInstanceButton.Name = "EditInstanceButton";
            EditInstanceButton.Size = new Size(79, 20);
            EditInstanceButton.Text = "Edit";
            EditInstanceButton.Click += EditInstanceButton_Click;
            // 
            // InstanceFolderButton
            // 
            InstanceFolderButton.Font = new Font("Arial", 9F);
            InstanceFolderButton.ForeColor = SystemColors.HighlightText;
            InstanceFolderButton.Image = (Image)resources.GetObject("InstanceFolderButton.Image");
            InstanceFolderButton.ImageTransparentColor = Color.Magenta;
            InstanceFolderButton.Name = "InstanceFolderButton";
            InstanceFolderButton.Size = new Size(79, 20);
            InstanceFolderButton.Text = "Folder";
            InstanceFolderButton.Click += InstanceFolderButton_Click;
            // 
            // toolStripSplitButton4
            // 
            toolStripSplitButton4.Font = new Font("Arial", 9F);
            toolStripSplitButton4.ForeColor = SystemColors.HighlightText;
            toolStripSplitButton4.Image = (Image)resources.GetObject("toolStripSplitButton4.Image");
            toolStripSplitButton4.ImageTransparentColor = Color.Magenta;
            toolStripSplitButton4.Name = "toolStripSplitButton4";
            toolStripSplitButton4.Size = new Size(79, 20);
            toolStripSplitButton4.Text = "Export";
            // 
            // CopyInstanceButton
            // 
            CopyInstanceButton.Font = new Font("Arial", 9F);
            CopyInstanceButton.ForeColor = SystemColors.HighlightText;
            CopyInstanceButton.Image = (Image)resources.GetObject("CopyInstanceButton.Image");
            CopyInstanceButton.ImageTransparentColor = Color.Magenta;
            CopyInstanceButton.Name = "CopyInstanceButton";
            CopyInstanceButton.Size = new Size(79, 20);
            CopyInstanceButton.Text = "Copy";
            // 
            // DeleteInstanceButton
            // 
            DeleteInstanceButton.Font = new Font("Arial", 9F);
            DeleteInstanceButton.ForeColor = SystemColors.HighlightText;
            DeleteInstanceButton.Image = (Image)resources.GetObject("DeleteInstanceButton.Image");
            DeleteInstanceButton.ImageTransparentColor = Color.Magenta;
            DeleteInstanceButton.Name = "DeleteInstanceButton";
            DeleteInstanceButton.Size = new Size(79, 20);
            DeleteInstanceButton.Text = "Delete";
            // 
            // toolStrip2
            // 
            toolStrip2.BackColor = Color.Gray;
            toolStrip2.Dock = DockStyle.None;
            toolStrip2.Items.AddRange(new ToolStripItem[] { ProfileButton, AddInstanceButton, FoldersButton, SettingsButton, HelpButton, UpdateButton });
            toolStrip2.Location = new Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Padding = new Padding(0, 3, 1, 3);
            toolStrip2.Size = new Size(800, 29);
            toolStrip2.Stretch = true;
            toolStrip2.TabIndex = 4;
            toolStrip2.Text = "toolStrip2";
            // 
            // ProfileButton
            // 
            ProfileButton.Alignment = ToolStripItemAlignment.Right;
            ProfileButton.Font = new Font("Arial", 9F);
            ProfileButton.ForeColor = SystemColors.HighlightText;
            ProfileButton.Image = (Image)resources.GetObject("ProfileButton.Image");
            ProfileButton.ImageTransparentColor = Color.Magenta;
            ProfileButton.Name = "ProfileButton";
            ProfileButton.Size = new Size(111, 20);
            ProfileButton.Text = "Profile Name";
            // 
            // AddInstanceButton
            // 
            AddInstanceButton.DropDownItems.AddRange(new ToolStripItem[] { AddNewInstanceButton, AddExistingInstanceButton });
            AddInstanceButton.Font = new Font("Arial", 9F);
            AddInstanceButton.ForeColor = SystemColors.HighlightText;
            AddInstanceButton.Image = (Image)resources.GetObject("AddInstanceButton.Image");
            AddInstanceButton.ImageTransparentColor = Color.Magenta;
            AddInstanceButton.Name = "AddInstanceButton";
            AddInstanceButton.Size = new Size(110, 20);
            AddInstanceButton.Text = "Add Instance";
            AddInstanceButton.ButtonClick += AddInstanceButton_ButtonClick;
            // 
            // AddNewInstanceButton
            // 
            AddNewInstanceButton.Name = "AddNewInstanceButton";
            AddNewInstanceButton.Size = new Size(149, 22);
            AddNewInstanceButton.Text = "New";
            AddNewInstanceButton.Click += AddNewInstanceButton_Click;
            // 
            // AddExistingInstanceButton
            // 
            AddExistingInstanceButton.Name = "AddExistingInstanceButton";
            AddExistingInstanceButton.Size = new Size(149, 22);
            AddExistingInstanceButton.Text = "From Existing";
            AddExistingInstanceButton.Click += AddExistingInstanceButton_Click;
            // 
            // FoldersButton
            // 
            FoldersButton.DropDownItems.AddRange(new ToolStripItem[] { InstanceFolder, InstancesFolderButton, toolStripSeparator4, ModsFolderButton, SharedModsFolderButton, toolStripSeparator5, LauncherFolderButton, IconsFolderButton });
            FoldersButton.Font = new Font("Arial", 9F);
            FoldersButton.ForeColor = SystemColors.HighlightText;
            FoldersButton.Image = (Image)resources.GetObject("FoldersButton.Image");
            FoldersButton.ImageTransparentColor = Color.Magenta;
            FoldersButton.Name = "FoldersButton";
            FoldersButton.Size = new Size(81, 20);
            FoldersButton.Text = "Folders";
            FoldersButton.ButtonClick += FoldersButton_ButtonClick;
            // 
            // InstanceFolder
            // 
            InstanceFolder.Name = "InstanceFolder";
            InstanceFolder.Size = new Size(147, 22);
            InstanceFolder.Text = "Instance";
            InstanceFolder.Click += InstanceFolder_Click;
            // 
            // InstancesFolderButton
            // 
            InstancesFolderButton.Name = "InstancesFolderButton";
            InstancesFolderButton.Size = new Size(147, 22);
            InstancesFolderButton.Text = "Instances";
            InstancesFolderButton.Click += InstancesFolderButton_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(144, 6);
            // 
            // ModsFolderButton
            // 
            ModsFolderButton.Name = "ModsFolderButton";
            ModsFolderButton.Size = new Size(147, 22);
            ModsFolderButton.Text = "Mods";
            ModsFolderButton.Click += ModsFolderButton_Click;
            // 
            // SharedModsFolderButton
            // 
            SharedModsFolderButton.Name = "SharedModsFolderButton";
            SharedModsFolderButton.Size = new Size(147, 22);
            SharedModsFolderButton.Text = "Shared Mods";
            SharedModsFolderButton.Click += SharedModsFolderButton_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(144, 6);
            // 
            // LauncherFolderButton
            // 
            LauncherFolderButton.Name = "LauncherFolderButton";
            LauncherFolderButton.Size = new Size(147, 22);
            LauncherFolderButton.Text = "Launcher";
            LauncherFolderButton.Click += LauncherFolderButton_Click;
            // 
            // IconsFolderButton
            // 
            IconsFolderButton.Name = "IconsFolderButton";
            IconsFolderButton.Size = new Size(147, 22);
            IconsFolderButton.Text = "Icons";
            IconsFolderButton.Click += IconsFolderButton_Click;
            // 
            // SettingsButton
            // 
            SettingsButton.Font = new Font("Arial", 9F);
            SettingsButton.ForeColor = SystemColors.HighlightText;
            SettingsButton.Image = (Image)resources.GetObject("SettingsButton.Image");
            SettingsButton.ImageTransparentColor = Color.Magenta;
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Size = new Size(72, 20);
            SettingsButton.Text = "Settings";
            SettingsButton.Click += SettingsButton_Click;
            // 
            // HelpButton
            // 
            HelpButton.Font = new Font("Arial", 9F);
            HelpButton.ForeColor = SystemColors.HighlightText;
            HelpButton.Image = (Image)resources.GetObject("HelpButton.Image");
            HelpButton.ImageTransparentColor = Color.Magenta;
            HelpButton.Name = "HelpButton";
            HelpButton.Size = new Size(65, 20);
            HelpButton.Text = "Help";
            // 
            // UpdateButton
            // 
            UpdateButton.Font = new Font("Arial", 9F);
            UpdateButton.ForeColor = SystemColors.HighlightText;
            UpdateButton.Image = (Image)resources.GetObject("UpdateButton.Image");
            UpdateButton.ImageTransparentColor = Color.Magenta;
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(67, 20);
            UpdateButton.Text = "Update";
            UpdateButton.Click += UpdateButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(toolStripContainer1);
            Controls.Add(panel1);
            Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "Hero's Only Launcher Experience";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            toolStripContainer2.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer2.TopToolStripPanel.PerformLayout();
            toolStripContainer2.ResumeLayout(false);
            toolStripContainer2.PerformLayout();
            toolStrip4.ResumeLayout(false);
            toolStrip4.PerformLayout();
            toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            toolStripContainer1.BottomToolStripPanel.PerformLayout();
            toolStripContainer1.ContentPanel.ResumeLayout(false);
            toolStripContainer1.RightToolStripPanel.ResumeLayout(false);
            toolStripContainer1.RightToolStripPanel.PerformLayout();
            toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.PerformLayout();
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ToolStripMenuItem instanceFolderMenuItem;
        private ToolStripMenuItem instancesFolderMenuItem;
        private ToolStripMenuItem modsButton;
        private Panel panel1;
        private ToolStripContainer toolStripContainer1;
        private ToolStrip toolStrip1;
        private ToolStripButton InstanceLogoButton;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripLabel AkiStatusLabel;
        private ToolStripButton StartAKIButton;
        private ToolStripButton KillAKIButton;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel toolStripLabel2;
        private ToolStripButton PlayButton;
        private ToolStripButton KillGameButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton EditInstanceButton;
        private ToolStripButton InstanceFolderButton;
        private ToolStripSplitButton toolStripSplitButton4;
        private ToolStripButton CopyInstanceButton;
        private ToolStripButton DeleteInstanceButton;
        private ToolStrip toolStrip2;
        private ToolStripSplitButton AddInstanceButton;
        private ToolStripMenuItem AddNewInstanceButton;
        private ToolStripMenuItem AddExistingInstanceButton;
        private ToolStripSplitButton FoldersButton;
        private ToolStripMenuItem InstanceFolder;
        private ToolStripMenuItem InstancesFolderButton;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem ModsFolderButton;
        private ToolStripMenuItem SharedModsFolderButton;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem LauncherFolderButton;
        private ToolStripMenuItem IconsFolderButton;
        private ToolStripButton SettingsButton;
        private ToolStripSplitButton HelpButton;
        private ToolStripButton UpdateButton;
        private ToolStrip toolStrip3;
        private ToolStripLabel toolStripLabel3;
        private ListView InstanceView;
        private ToolStripContainer toolStripContainer2;
        private ToolStrip toolStrip4;
        private ToolStripLabel LastPlayedLabel;
        private ToolStripLabel TotalPlayTimeLabel;
        private ToolStripSplitButton ProfileButton;
        private ToolStripLabel AkiVersionLabel;
    }
}

namespace HOLE
{
    partial class ModDownloaderForm
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
            ListViewItem listViewItem1 = new ListViewItem("Lol");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModDownloaderForm));
            basicModsList = new ListView();
            NameColumn = new ColumnHeader();
            DescriptionColumn = new ColumnHeader();
            VersionColumn = new ColumnHeader();
            AkiVersion = new ColumnHeader();
            LinkColumn = new ColumnHeader();
            FeaturedColumn = new ColumnHeader();
            DownloadsColumn = new ColumnHeader();
            toolStrip1 = new ToolStrip();
            DownloadButton = new ToolStripSplitButton();
            DownloadCurrentButton = new ToolStripMenuItem();
            DownloadInstancesButton = new ToolStripMenuItem();
            toolStripProgressBar1 = new ToolStripProgressBar();
            ProgressLabel = new ToolStripLabel();
            toolStrip2 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            SearchFilter = new ToolStripTextBox();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripLabel2 = new ToolStripLabel();
            AkiVersionFilter = new ToolStripComboBox();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripButton1 = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            FiltersButton = new ToolStripDropDownButton();
            toolStripMenuItem1 = new ToolStripMenuItem();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            ModsList = new ListView();
            toolStrip1.SuspendLayout();
            toolStrip2.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // basicModsList
            // 
            basicModsList.CheckBoxes = true;
            basicModsList.Columns.AddRange(new ColumnHeader[] { NameColumn, DescriptionColumn, VersionColumn, AkiVersion, LinkColumn, FeaturedColumn, DownloadsColumn });
            basicModsList.Dock = DockStyle.Fill;
            listViewItem1.Checked = true;
            listViewItem1.StateImageIndex = 1;
            basicModsList.Items.AddRange(new ListViewItem[] { listViewItem1 });
            basicModsList.Location = new Point(0, 0);
            basicModsList.Name = "basicModsList";
            basicModsList.Size = new Size(899, 400);
            basicModsList.TabIndex = 0;
            basicModsList.UseCompatibleStateImageBehavior = false;
            basicModsList.View = View.Details;
            // 
            // NameColumn
            // 
            NameColumn.Text = "Name";
            NameColumn.Width = 150;
            // 
            // DescriptionColumn
            // 
            DescriptionColumn.DisplayIndex = 4;
            DescriptionColumn.Text = "Description";
            DescriptionColumn.TextAlign = HorizontalAlignment.Center;
            DescriptionColumn.Width = 225;
            // 
            // VersionColumn
            // 
            VersionColumn.DisplayIndex = 1;
            VersionColumn.Text = "Version";
            VersionColumn.TextAlign = HorizontalAlignment.Center;
            VersionColumn.Width = 75;
            // 
            // AkiVersion
            // 
            AkiVersion.DisplayIndex = 2;
            AkiVersion.Text = "SPT-AKI";
            AkiVersion.TextAlign = HorizontalAlignment.Center;
            // 
            // LinkColumn
            // 
            LinkColumn.DisplayIndex = 6;
            LinkColumn.Text = "Link";
            LinkColumn.TextAlign = HorizontalAlignment.Center;
            LinkColumn.Width = 200;
            // 
            // FeaturedColumn
            // 
            FeaturedColumn.Text = "Featured";
            FeaturedColumn.TextAlign = HorizontalAlignment.Center;
            FeaturedColumn.Width = 70;
            // 
            // DownloadsColumn
            // 
            DownloadsColumn.DisplayIndex = 3;
            DownloadsColumn.Text = "Downloads";
            DownloadsColumn.TextAlign = HorizontalAlignment.Center;
            DownloadsColumn.Width = 75;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Bottom;
            toolStrip1.Items.AddRange(new ToolStripItem[] { DownloadButton, toolStripProgressBar1, ProgressLabel });
            toolStrip1.Location = new Point(0, 425);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(899, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // DownloadButton
            // 
            DownloadButton.DropDownItems.AddRange(new ToolStripItem[] { DownloadCurrentButton, DownloadInstancesButton });
            DownloadButton.Image = (Image)resources.GetObject("DownloadButton.Image");
            DownloadButton.ImageTransparentColor = Color.Magenta;
            DownloadButton.Name = "DownloadButton";
            DownloadButton.Size = new Size(93, 22);
            DownloadButton.Text = "Download";
            DownloadButton.ButtonClick += DownloadButton_ButtonClick;
            // 
            // DownloadCurrentButton
            // 
            DownloadCurrentButton.Name = "DownloadCurrentButton";
            DownloadCurrentButton.Size = new Size(180, 22);
            DownloadCurrentButton.Text = "Current Instance";
            // 
            // DownloadInstancesButton
            // 
            DownloadInstancesButton.Name = "DownloadInstancesButton";
            DownloadInstancesButton.Size = new Size(180, 22);
            DownloadInstancesButton.Text = "Instances";
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Alignment = ToolStripItemAlignment.Right;
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(250, 22);
            // 
            // ProgressLabel
            // 
            ProgressLabel.Alignment = ToolStripItemAlignment.Right;
            ProgressLabel.Name = "ProgressLabel";
            ProgressLabel.Size = new Size(124, 22);
            ProgressLabel.Text = "0MB/0MB (0MB/s) 0%";
            // 
            // toolStrip2
            // 
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripLabel1, SearchFilter, toolStripSeparator1, toolStripLabel2, AkiVersionFilter, toolStripSeparator2, toolStripButton1, toolStripSeparator3, FiltersButton });
            toolStrip2.Location = new Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(899, 25);
            toolStrip2.TabIndex = 3;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(45, 22);
            toolStripLabel1.Text = "Search:";
            // 
            // SearchFilter
            // 
            SearchFilter.Name = "SearchFilter";
            SearchFilter.Size = new Size(125, 25);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(28, 22);
            toolStripLabel2.Text = "AKI:";
            // 
            // AkiVersionFilter
            // 
            AkiVersionFilter.Name = "AkiVersionFilter";
            AkiVersionFilter.Size = new Size(75, 25);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // toolStripButton1
            // 
            toolStripButton1.Alignment = ToolStripItemAlignment.Right;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(58, 22);
            toolStripButton1.Text = "Apply";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Alignment = ToolStripItemAlignment.Right;
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // FiltersButton
            // 
            FiltersButton.Alignment = ToolStripItemAlignment.Right;
            FiltersButton.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            FiltersButton.Image = (Image)resources.GetObject("FiltersButton.Image");
            FiltersButton.ImageTransparentColor = Color.Magenta;
            FiltersButton.Name = "FiltersButton";
            FiltersButton.Size = new Size(114, 22);
            FiltersButton.Text = "Selected Filters";
            FiltersButton.ToolTipText = "Enable and Disable which filters should be applied.";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Checked = true;
            toolStripMenuItem1.CheckState = CheckState.Checked;
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(180, 22);
            toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // panel1
            // 
            panel1.Controls.Add(basicModsList);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 25);
            panel1.Name = "panel1";
            panel1.Size = new Size(899, 400);
            panel1.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(ModsList);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(899, 400);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(459, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(440, 400);
            panel3.TabIndex = 1;
            // 
            // ModsList
            // 
            ModsList.Dock = DockStyle.Left;
            ModsList.Location = new Point(0, 0);
            ModsList.Name = "ModsList";
            ModsList.Size = new Size(440, 400);
            ModsList.TabIndex = 0;
            ModsList.UseCompatibleStateImageBehavior = false;
            ModsList.View = View.SmallIcon;
            // 
            // ModDownloaderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(899, 450);
            Controls.Add(panel1);
            Controls.Add(toolStrip2);
            Controls.Add(toolStrip1);
            Name = "ModDownloaderForm";
            Text = "ModDownloader";
            Load += ModDownloaderForm_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView basicModsList;
        private ToolStrip toolStrip1;
        private ToolStripSplitButton DownloadButton;
        private ToolStripMenuItem DownloadInstancesButton;
        private ToolStripMenuItem DownloadCurrentButton;
        private ToolStripProgressBar toolStripProgressBar1;
        private ToolStripLabel ProgressLabel;
        private ToolStrip toolStrip2;
        private Panel panel1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox SearchFilter;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripComboBox AkiVersionFilter;
        private ToolStripLabel toolStripLabel2;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel toolStripLabel3;
        private ToolStripDropDownButton FiltersButton;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripButton toolStripButton1;
        private ToolStripSeparator toolStripSeparator3;
        private ColumnHeader NameColumn;
        private ColumnHeader DescriptionColumn;
        private ColumnHeader VersionColumn;
        private ColumnHeader LinkColumn;
        private ColumnHeader FeaturedColumn;
        private ColumnHeader DownloadsColumn;
        private Panel panel2;
        private ListView ModsList;
        private Panel panel3;
        private ColumnHeader AkiVersion;
    }
}
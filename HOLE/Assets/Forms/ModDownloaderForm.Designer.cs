namespace HOLE.Assets.Forms
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
            tableLayoutPanel1 = new TableLayoutPanel();
            splitContainer1 = new SplitContainer();
            modsView = new ListView();
            richTextBox1 = new RichTextBox();
            panel1 = new Panel();
            versionBox = new ComboBox();
            searchBox = new TextBox();
            SearchButton = new Button();
            panel2 = new Panel();
            FilterDescription = new CheckBox();
            FilterName = new CheckBox();
            DownloadConfirmButton = new Button();
            SortLabel = new Label();
            VersionLabel = new Label();
            DownloadSelectButton = new Button();
            selectedVersionBox = new ComboBox();
            comboBox1 = new ComboBox();
            InfiniteScroll = new CheckBox();
            FilterWebSearch = new CheckBox();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(splitContainer1, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.158508F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 91.84149F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 59F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 34);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(modsView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(richTextBox1);
            splitContainer1.Size = new Size(794, 353);
            splitContainer1.SplitterDistance = 397;
            splitContainer1.TabIndex = 0;
            // 
            // modsView
            // 
            modsView.Dock = DockStyle.Fill;
            modsView.Location = new Point(0, 0);
            modsView.Name = "modsView";
            modsView.Size = new Size(397, 353);
            modsView.TabIndex = 0;
            modsView.UseCompatibleStateImageBehavior = false;
            modsView.View = View.Tile;
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Location = new Point(0, 0);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(393, 353);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // panel1
            // 
            panel1.Controls.Add(versionBox);
            panel1.Controls.Add(searchBox);
            panel1.Controls.Add(SearchButton);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(794, 25);
            panel1.TabIndex = 1;
            // 
            // versionBox
            // 
            versionBox.FormattingEnabled = true;
            versionBox.Location = new Point(584, 1);
            versionBox.Name = "versionBox";
            versionBox.Size = new Size(121, 23);
            versionBox.TabIndex = 2;
            // 
            // searchBox
            // 
            searchBox.Dock = DockStyle.Left;
            searchBox.Location = new Point(0, 0);
            searchBox.Name = "searchBox";
            searchBox.PlaceholderText = "Search Mods...";
            searchBox.Size = new Size(578, 23);
            searchBox.TabIndex = 1;
            // 
            // SearchButton
            // 
            SearchButton.Dock = DockStyle.Right;
            SearchButton.Location = new Point(708, 0);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(86, 25);
            SearchButton.TabIndex = 0;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(FilterWebSearch);
            panel2.Controls.Add(InfiniteScroll);
            panel2.Controls.Add(FilterDescription);
            panel2.Controls.Add(FilterName);
            panel2.Controls.Add(DownloadConfirmButton);
            panel2.Controls.Add(SortLabel);
            panel2.Controls.Add(VersionLabel);
            panel2.Controls.Add(DownloadSelectButton);
            panel2.Controls.Add(selectedVersionBox);
            panel2.Controls.Add(comboBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 393);
            panel2.Name = "panel2";
            panel2.Size = new Size(794, 54);
            panel2.TabIndex = 2;
            // 
            // FilterDescription
            // 
            FilterDescription.AutoSize = true;
            FilterDescription.Location = new Point(426, 7);
            FilterDescription.Name = "FilterDescription";
            FilterDescription.Size = new Size(86, 19);
            FilterDescription.TabIndex = 7;
            FilterDescription.Text = "Description";
            FilterDescription.UseVisualStyleBackColor = true;
            // 
            // FilterName
            // 
            FilterName.AutoSize = true;
            FilterName.Location = new Point(520, 7);
            FilterName.Name = "FilterName";
            FilterName.Size = new Size(58, 19);
            FilterName.TabIndex = 6;
            FilterName.Text = "Name";
            FilterName.UseVisualStyleBackColor = true;
            // 
            // DownloadConfirmButton
            // 
            DownloadConfirmButton.Location = new Point(626, 28);
            DownloadConfirmButton.Name = "DownloadConfirmButton";
            DownloadConfirmButton.Size = new Size(166, 23);
            DownloadConfirmButton.TabIndex = 5;
            DownloadConfirmButton.Text = "Confirm Download";
            DownloadConfirmButton.UseVisualStyleBackColor = true;
            DownloadConfirmButton.Click += DownloadConfirmButton_Click;
            // 
            // SortLabel
            // 
            SortLabel.AutoSize = true;
            SortLabel.Location = new Point(625, 6);
            SortLabel.Name = "SortLabel";
            SortLabel.Size = new Size(31, 15);
            SortLabel.TabIndex = 4;
            SortLabel.Text = "Sort:";
            // 
            // VersionLabel
            // 
            VersionLabel.AutoSize = true;
            VersionLabel.Location = new Point(3, 6);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Size = new Size(48, 15);
            VersionLabel.TabIndex = 3;
            VersionLabel.Text = "Version:";
            // 
            // DownloadSelectButton
            // 
            DownloadSelectButton.Location = new Point(3, 28);
            DownloadSelectButton.Name = "DownloadSelectButton";
            DownloadSelectButton.Size = new Size(261, 23);
            DownloadSelectButton.TabIndex = 2;
            DownloadSelectButton.Text = "Select For Download";
            DownloadSelectButton.UseVisualStyleBackColor = true;
            // 
            // selectedVersionBox
            // 
            selectedVersionBox.FormattingEnabled = true;
            selectedVersionBox.Location = new Point(57, 3);
            selectedVersionBox.Name = "selectedVersionBox";
            selectedVersionBox.Size = new Size(207, 23);
            selectedVersionBox.TabIndex = 1;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(659, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(132, 23);
            comboBox1.TabIndex = 0;
            // 
            // InfiniteScroll
            // 
            InfiniteScroll.AutoSize = true;
            InfiniteScroll.Location = new Point(520, 28);
            InfiniteScroll.Name = "InfiniteScroll";
            InfiniteScroll.Size = new Size(97, 19);
            InfiniteScroll.TabIndex = 8;
            InfiniteScroll.Text = "Infinite-Scroll";
            InfiniteScroll.UseVisualStyleBackColor = true;
            // 
            // FilterWebSearch
            // 
            FilterWebSearch.AutoSize = true;
            FilterWebSearch.Location = new Point(426, 28);
            FilterWebSearch.Name = "FilterWebSearch";
            FilterWebSearch.Size = new Size(88, 19);
            FilterWebSearch.TabIndex = 9;
            FilterWebSearch.Text = "Web Search";
            FilterWebSearch.UseVisualStyleBackColor = true;
            // 
            // ModDownloaderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "ModDownloaderForm";
            Text = "ModDownloaderForm";
            Load += ModDownloaderForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private SplitContainer splitContainer1;
        private ListView modsView;
        private TextBox searchBox;
        private Button SearchButton;
        private Panel panel1;
        private Panel panel2;
        private ComboBox versionBox;
        private RichTextBox richTextBox1;
        private ComboBox comboBox1;
        private ComboBox selectedVersionBox;
        private Button DownloadSelectButton;
        private Label VersionLabel;
        private Label SortLabel;
        private Button DownloadConfirmButton;
        private CheckBox FilterDescription;
        private CheckBox FilterName;
        private CheckBox FilterWebSearch;
        private CheckBox InfiniteScroll;
    }
}
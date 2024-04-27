namespace HOLE
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            TarkovCacheButton = new ToolStripButton();
            LauncherPanel = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            groupBox2 = new GroupBox();
            InstancePathButton = new Button();
            InstancesPath = new TextBox();
            groupBox1 = new GroupBox();
            comboBox1 = new ComboBox();
            groupBox3 = new GroupBox();
            ServerAddress = new TextBox();
            toolStrip1.SuspendLayout();
            LauncherPanel.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Left;
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2, toolStripButton3, TarkovCacheButton });
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(136, 450);
            toolStrip1.Stretch = true;
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(133, 36);
            toolStripButton1.Text = "Launcher";
            // 
            // toolStripButton2
            // 
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(133, 36);
            toolStripButton2.Text = "Mod Downloader";
            // 
            // toolStripButton3
            // 
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(133, 36);
            toolStripButton3.Text = "Server Console";
            // 
            // TarkovCacheButton
            // 
            TarkovCacheButton.Image = (Image)resources.GetObject("TarkovCacheButton.Image");
            TarkovCacheButton.ImageTransparentColor = Color.Magenta;
            TarkovCacheButton.Name = "TarkovCacheButton";
            TarkovCacheButton.Size = new Size(133, 36);
            TarkovCacheButton.Text = "Tarkov Cache";
            // 
            // LauncherPanel
            // 
            LauncherPanel.Controls.Add(flowLayoutPanel1);
            LauncherPanel.Dock = DockStyle.Fill;
            LauncherPanel.Location = new Point(136, 0);
            LauncherPanel.Name = "LauncherPanel";
            LauncherPanel.Size = new Size(664, 450);
            LauncherPanel.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(groupBox2);
            flowLayoutPanel1.Controls.Add(groupBox1);
            flowLayoutPanel1.Controls.Add(groupBox3);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(664, 450);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(InstancePathButton);
            groupBox2.Controls.Add(InstancesPath);
            groupBox2.Location = new Point(3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(321, 50);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Instances Path";
            // 
            // InstancePathButton
            // 
            InstancePathButton.Location = new Point(287, 17);
            InstancePathButton.Name = "InstancePathButton";
            InstancePathButton.Size = new Size(24, 23);
            InstancePathButton.TabIndex = 2;
            InstancePathButton.Text = "...";
            InstancePathButton.UseVisualStyleBackColor = true;
            InstancePathButton.Click += InstancePathButton_Click;
            // 
            // InstancesPath
            // 
            InstancesPath.Location = new Point(6, 17);
            InstancesPath.Name = "InstancesPath";
            InstancesPath.Size = new Size(275, 23);
            InstancesPath.TabIndex = 1;
            InstancesPath.KeyDown += InstancesPath_KeyDown;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Location = new Point(330, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(125, 50);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Language";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(6, 18);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(113, 23);
            comboBox1.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(ServerAddress);
            groupBox3.Location = new Point(461, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(115, 50);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Server Address";
            // 
            // ServerAddress
            // 
            ServerAddress.Location = new Point(6, 18);
            ServerAddress.Name = "ServerAddress";
            ServerAddress.Size = new Size(103, 23);
            ServerAddress.TabIndex = 0;
            ServerAddress.Text = "127.0.0.1:6969";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LauncherPanel);
            Controls.Add(toolStrip1);
            Name = "SettingsForm";
            Text = "Settings";
            Load += SettingsForm_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            LauncherPanel.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton1;
        private Panel LauncherPanel;
        private FlowLayoutPanel flowLayoutPanel1;
        private GroupBox groupBox2;
        private Button InstancePathButton;
        private TextBox InstancesPath;
        private ToolStripButton TarkovCacheButton;
        private GroupBox groupBox1;
        private ComboBox comboBox1;
        private GroupBox groupBox3;
        private TextBox ServerAddress;
    }
}
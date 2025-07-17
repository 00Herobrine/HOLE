namespace HOLE.Forms
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
            GameButton = new Button();
            LauncherButton = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            LauncherPanel = new Panel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            LanguageButton = new Button();
            flowLayoutPanel1.SuspendLayout();
            LauncherPanel.SuspendLayout();
            SuspendLayout();
            // 
            // GameButton
            // 
            GameButton.Location = new Point(3, 49);
            GameButton.Name = "GameButton";
            GameButton.Size = new Size(150, 40);
            GameButton.TabIndex = 1;
            GameButton.Text = "Game";
            GameButton.UseVisualStyleBackColor = true;
            // 
            // LauncherButton
            // 
            LauncherButton.Location = new Point(3, 3);
            LauncherButton.Name = "LauncherButton";
            LauncherButton.Size = new Size(150, 40);
            LauncherButton.TabIndex = 0;
            LauncherButton.Text = "Launcher";
            LauncherButton.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(LauncherButton);
            flowLayoutPanel1.Controls.Add(GameButton);
            flowLayoutPanel1.Controls.Add(LanguageButton);
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(156, 620);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // LauncherPanel
            // 
            LauncherPanel.Controls.Add(flowLayoutPanel2);
            LauncherPanel.Dock = DockStyle.Fill;
            LauncherPanel.Location = new Point(156, 0);
            LauncherPanel.Name = "LauncherPanel";
            LauncherPanel.Size = new Size(586, 620);
            LauncherPanel.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(0, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(586, 620);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // LanguageButton
            // 
            LanguageButton.Location = new Point(3, 95);
            LanguageButton.Name = "LanguageButton";
            LanguageButton.Size = new Size(150, 40);
            LanguageButton.TabIndex = 2;
            LanguageButton.Text = "Language";
            LanguageButton.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(742, 620);
            Controls.Add(LauncherPanel);
            Controls.Add(flowLayoutPanel1);
            Name = "SettingsForm";
            Text = "SettingsForm";
            flowLayoutPanel1.ResumeLayout(false);
            LauncherPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button GameButton;
        private Button LauncherButton;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel LauncherPanel;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button LanguageButton;
    }
}
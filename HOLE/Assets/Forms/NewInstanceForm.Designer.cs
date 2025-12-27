namespace HOLE.Assets.Forms
{
    partial class NewInstanceForm
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
            panel1 = new Panel();
            CancelButton = new Button();
            OKButton = new Button();
            PathButton = new Button();
            label3 = new Label();
            PathBox = new TextBox();
            GroupBox = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            NameBox = new TextBox();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(CancelButton);
            panel1.Controls.Add(OKButton);
            panel1.Controls.Add(PathButton);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(PathBox);
            panel1.Controls.Add(GroupBox);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(NameBox);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(759, 131);
            panel1.TabIndex = 0;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(678, 103);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 19;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // OKButton
            // 
            OKButton.Location = new Point(597, 103);
            OKButton.Name = "OKButton";
            OKButton.Size = new Size(75, 23);
            OKButton.TabIndex = 18;
            OKButton.Text = "OK";
            OKButton.UseVisualStyleBackColor = true;
            OKButton.Click += OKButton_Click;
            // 
            // PathButton
            // 
            PathButton.Location = new Point(725, 74);
            PathButton.Name = "PathButton";
            PathButton.Size = new Size(27, 23);
            PathButton.TabIndex = 17;
            PathButton.Text = "...";
            PathButton.UseVisualStyleBackColor = true;
            PathButton.Click += PathButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(145, 78);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 16;
            label3.Text = "Path:";
            // 
            // PathBox
            // 
            PathBox.Location = new Point(182, 74);
            PathBox.Name = "PathBox";
            PathBox.Size = new Size(537, 23);
            PathBox.TabIndex = 15;
            // 
            // GroupBox
            // 
            GroupBox.FormattingEnabled = true;
            GroupBox.Location = new Point(182, 45);
            GroupBox.Name = "GroupBox";
            GroupBox.Size = new Size(570, 23);
            GroupBox.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(136, 49);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 13;
            label2.Text = "Group:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(137, 17);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 12;
            label1.Text = "Name:";
            // 
            // NameBox
            // 
            NameBox.Location = new Point(182, 13);
            NameBox.Name = "NameBox";
            NameBox.Size = new Size(570, 23);
            NameBox.TabIndex = 11;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(128, 128);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // NewInstanceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(759, 131);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NewInstanceForm";
            Text = "Add New Instance";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button OKButton;
        private Button CancelButton;
        private Button PathButton;
        private Label label3;
        private TextBox PathBox;
        private ComboBox GroupBox;
        private Label label2;
        private Label label1;
        private TextBox NameBox;
        private PictureBox pictureBox1;
    }
}
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
            ListViewItem listViewItem3 = new ListViewItem(new string[] { "662bd45200012640ea93c910", "Hero", "Edge of Darkness", "42", "13", "3.8.0 (29197)" }, -1);
            toolStrip1 = new ToolStrip();
            ServerButton = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStripButton1 = new ToolStripButton();
            toolStripButton7 = new ToolStripButton();
            miniToolStrip = new ToolStrip();
            UserPanel = new Panel();
            ServerPanel = new Panel();
            ServerTabs = new TabControl();
            ServerConfigsTab = new TabPage();
            ServerDatabaseTab = new TabPage();
            tabControl1 = new TabControl();
            DatabaseBots = new TabPage();
            DatabaseHideout = new TabPage();
            tabControl2 = new TabControl();
            HideoutProduction = new TabPage();
            ProductionGroup = new GroupBox();
            ProductionLimitLabel = new Label();
            ProductionLimit = new NumericUpDown();
            ProductionDuration = new NumericUpDown();
            label5 = new Label();
            ProductionCount = new NumericUpDown();
            ProductionFuelNeeded = new RadioButton();
            ProductionContinuous = new RadioButton();
            ProductionLocked = new RadioButton();
            label4 = new Label();
            ProductionResult = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            ProductionModule = new ComboBox();
            RequirementTypeBox = new ComboBox();
            DeleteRequirementButton = new Button();
            AddRequirementButton = new Button();
            groupBox2 = new GroupBox();
            RequirementsList = new ListBox();
            groupBox4 = new GroupBox();
            RequirementEncoded = new RadioButton();
            RequirementFunctional = new RadioButton();
            label6 = new Label();
            RequirementAmount = new NumericUpDown();
            groupBox3 = new GroupBox();
            QuestButton = new RadioButton();
            ResourceButton = new RadioButton();
            ItemButton = new RadioButton();
            AreaButton = new RadioButton();
            ToolButton = new RadioButton();
            label1 = new Label();
            RequirementID = new ComboBox();
            ProductionList = new ListBox();
            HideoutScavCase = new TabPage();
            DatabaseLocales = new TabPage();
            DatabaseLocations = new TabPage();
            DatabaseLoot = new TabPage();
            DatabaseMatch = new TabPage();
            DatabaseTraders = new TabPage();
            ServerImagesTab = new TabPage();
            UserTab = new TabControl();
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
            ServerPanel.SuspendLayout();
            ServerTabs.SuspendLayout();
            ServerDatabaseTab.SuspendLayout();
            tabControl1.SuspendLayout();
            DatabaseHideout.SuspendLayout();
            tabControl2.SuspendLayout();
            HideoutProduction.SuspendLayout();
            ProductionGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ProductionLimit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ProductionDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ProductionCount).BeginInit();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RequirementAmount).BeginInit();
            groupBox3.SuspendLayout();
            UserTab.SuspendLayout();
            ProfilesTab.SuspendLayout();
            toolStrip3.SuspendLayout();
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
            toolStrip1.Items.AddRange(new ToolStripItem[] { ServerButton, toolStripButton3, toolStripButton1, toolStripButton7 });
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(86, 450);
            toolStrip1.Stretch = true;
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // ServerButton
            // 
            ServerButton.Image = (Image)resources.GetObject("ServerButton.Image");
            ServerButton.ImageTransparentColor = Color.Magenta;
            ServerButton.Name = "ServerButton";
            ServerButton.Size = new Size(83, 36);
            ServerButton.Text = "Server";
            // 
            // toolStripButton3
            // 
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(83, 36);
            toolStripButton3.Text = "BepInEx";
            // 
            // toolStripButton1
            // 
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(83, 36);
            toolStripButton1.Text = "User";
            // 
            // toolStripButton7
            // 
            toolStripButton7.Image = (Image)resources.GetObject("toolStripButton7.Image");
            toolStripButton7.ImageTransparentColor = Color.Magenta;
            toolStripButton7.Name = "toolStripButton7";
            toolStripButton7.Size = new Size(83, 36);
            toolStripButton7.Text = "Mods";
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
            // UserPanel
            // 
            UserPanel.Controls.Add(ServerPanel);
            UserPanel.Controls.Add(UserTab);
            UserPanel.Controls.Add(ModsPanel);
            UserPanel.Dock = DockStyle.Fill;
            UserPanel.Location = new Point(86, 0);
            UserPanel.Name = "UserPanel";
            UserPanel.Size = new Size(714, 450);
            UserPanel.TabIndex = 0;
            // 
            // ServerPanel
            // 
            ServerPanel.Controls.Add(ServerTabs);
            ServerPanel.Dock = DockStyle.Fill;
            ServerPanel.Location = new Point(0, 0);
            ServerPanel.Name = "ServerPanel";
            ServerPanel.Size = new Size(714, 450);
            ServerPanel.TabIndex = 8;
            // 
            // ServerTabs
            // 
            ServerTabs.Controls.Add(ServerConfigsTab);
            ServerTabs.Controls.Add(ServerDatabaseTab);
            ServerTabs.Controls.Add(ServerImagesTab);
            ServerTabs.Dock = DockStyle.Fill;
            ServerTabs.Location = new Point(0, 0);
            ServerTabs.Name = "ServerTabs";
            ServerTabs.SelectedIndex = 0;
            ServerTabs.Size = new Size(714, 450);
            ServerTabs.TabIndex = 0;
            // 
            // ServerConfigsTab
            // 
            ServerConfigsTab.Location = new Point(4, 24);
            ServerConfigsTab.Name = "ServerConfigsTab";
            ServerConfigsTab.Padding = new Padding(3);
            ServerConfigsTab.Size = new Size(706, 422);
            ServerConfigsTab.TabIndex = 0;
            ServerConfigsTab.Text = "Configs";
            ServerConfigsTab.UseVisualStyleBackColor = true;
            // 
            // ServerDatabaseTab
            // 
            ServerDatabaseTab.Controls.Add(tabControl1);
            ServerDatabaseTab.Location = new Point(4, 24);
            ServerDatabaseTab.Name = "ServerDatabaseTab";
            ServerDatabaseTab.Padding = new Padding(3);
            ServerDatabaseTab.Size = new Size(706, 422);
            ServerDatabaseTab.TabIndex = 1;
            ServerDatabaseTab.Text = "Database";
            ServerDatabaseTab.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(DatabaseBots);
            tabControl1.Controls.Add(DatabaseHideout);
            tabControl1.Controls.Add(DatabaseLocales);
            tabControl1.Controls.Add(DatabaseLocations);
            tabControl1.Controls.Add(DatabaseLoot);
            tabControl1.Controls.Add(DatabaseMatch);
            tabControl1.Controls.Add(DatabaseTraders);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(3, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(700, 416);
            tabControl1.TabIndex = 0;
            // 
            // DatabaseBots
            // 
            DatabaseBots.Location = new Point(4, 24);
            DatabaseBots.Name = "DatabaseBots";
            DatabaseBots.Padding = new Padding(3);
            DatabaseBots.Size = new Size(692, 388);
            DatabaseBots.TabIndex = 0;
            DatabaseBots.Text = "Bots";
            DatabaseBots.UseVisualStyleBackColor = true;
            // 
            // DatabaseHideout
            // 
            DatabaseHideout.Controls.Add(tabControl2);
            DatabaseHideout.Location = new Point(4, 24);
            DatabaseHideout.Name = "DatabaseHideout";
            DatabaseHideout.Padding = new Padding(3);
            DatabaseHideout.Size = new Size(692, 388);
            DatabaseHideout.TabIndex = 1;
            DatabaseHideout.Text = "Hideout";
            DatabaseHideout.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(HideoutProduction);
            tabControl2.Controls.Add(HideoutScavCase);
            tabControl2.Dock = DockStyle.Fill;
            tabControl2.Location = new Point(3, 3);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(686, 382);
            tabControl2.TabIndex = 0;
            // 
            // HideoutProduction
            // 
            HideoutProduction.Controls.Add(ProductionGroup);
            HideoutProduction.Controls.Add(ProductionList);
            HideoutProduction.Location = new Point(4, 24);
            HideoutProduction.Name = "HideoutProduction";
            HideoutProduction.Padding = new Padding(3);
            HideoutProduction.Size = new Size(678, 354);
            HideoutProduction.TabIndex = 0;
            HideoutProduction.Text = "Production";
            HideoutProduction.UseVisualStyleBackColor = true;
            // 
            // ProductionGroup
            // 
            ProductionGroup.Controls.Add(ProductionLimitLabel);
            ProductionGroup.Controls.Add(ProductionLimit);
            ProductionGroup.Controls.Add(ProductionDuration);
            ProductionGroup.Controls.Add(label5);
            ProductionGroup.Controls.Add(ProductionCount);
            ProductionGroup.Controls.Add(ProductionFuelNeeded);
            ProductionGroup.Controls.Add(ProductionContinuous);
            ProductionGroup.Controls.Add(ProductionLocked);
            ProductionGroup.Controls.Add(label4);
            ProductionGroup.Controls.Add(ProductionResult);
            ProductionGroup.Controls.Add(label3);
            ProductionGroup.Controls.Add(label2);
            ProductionGroup.Controls.Add(ProductionModule);
            ProductionGroup.Controls.Add(RequirementTypeBox);
            ProductionGroup.Controls.Add(DeleteRequirementButton);
            ProductionGroup.Controls.Add(AddRequirementButton);
            ProductionGroup.Controls.Add(groupBox2);
            ProductionGroup.Dock = DockStyle.Fill;
            ProductionGroup.Location = new Point(203, 3);
            ProductionGroup.Name = "ProductionGroup";
            ProductionGroup.Size = new Size(472, 348);
            ProductionGroup.TabIndex = 1;
            ProductionGroup.TabStop = false;
            ProductionGroup.Text = "{Name} || {ResultName} Recipe";
            // 
            // ProductionLimitLabel
            // 
            ProductionLimitLabel.AutoSize = true;
            ProductionLimitLabel.Location = new Point(6, 82);
            ProductionLimitLabel.Name = "ProductionLimitLabel";
            ProductionLimitLabel.Size = new Size(99, 15);
            ProductionLimitLabel.TabIndex = 16;
            ProductionLimitLabel.Text = "Production Limit:";
            // 
            // ProductionLimit
            // 
            ProductionLimit.Location = new Point(111, 80);
            ProductionLimit.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            ProductionLimit.Name = "ProductionLimit";
            ProductionLimit.Size = new Size(53, 23);
            ProductionLimit.TabIndex = 15;
            ProductionLimit.TextAlign = HorizontalAlignment.Center;
            // 
            // ProductionDuration
            // 
            ProductionDuration.Location = new Point(63, 51);
            ProductionDuration.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            ProductionDuration.Name = "ProductionDuration";
            ProductionDuration.Size = new Size(66, 23);
            ProductionDuration.TabIndex = 14;
            ProductionDuration.TextAlign = HorizontalAlignment.Center;
            ProductionDuration.Value = new decimal(new int[] { 14400, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(323, 53);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 13;
            label5.Text = "Count:";
            // 
            // ProductionCount
            // 
            ProductionCount.Location = new Point(372, 51);
            ProductionCount.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            ProductionCount.Name = "ProductionCount";
            ProductionCount.Size = new Size(53, 23);
            ProductionCount.TabIndex = 12;
            ProductionCount.TextAlign = HorizontalAlignment.Center;
            ProductionCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // ProductionFuelNeeded
            // 
            ProductionFuelNeeded.AutoSize = true;
            ProductionFuelNeeded.Location = new Point(9, 109);
            ProductionFuelNeeded.Name = "ProductionFuelNeeded";
            ProductionFuelNeeded.Size = new Size(91, 19);
            ProductionFuelNeeded.TabIndex = 11;
            ProductionFuelNeeded.TabStop = true;
            ProductionFuelNeeded.Text = "Fuel Needed";
            ProductionFuelNeeded.UseVisualStyleBackColor = true;
            // 
            // ProductionContinuous
            // 
            ProductionContinuous.AutoSize = true;
            ProductionContinuous.Location = new Point(106, 109);
            ProductionContinuous.Name = "ProductionContinuous";
            ProductionContinuous.Size = new Size(87, 19);
            ProductionContinuous.TabIndex = 10;
            ProductionContinuous.TabStop = true;
            ProductionContinuous.Text = "Continuous";
            ProductionContinuous.UseVisualStyleBackColor = true;
            // 
            // ProductionLocked
            // 
            ProductionLocked.AutoSize = true;
            ProductionLocked.Location = new Point(199, 109);
            ProductionLocked.Name = "ProductionLocked";
            ProductionLocked.Size = new Size(63, 19);
            ProductionLocked.TabIndex = 9;
            ProductionLocked.TabStop = true;
            ProductionLocked.Text = "Locked";
            ProductionLocked.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(221, 25);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 8;
            label4.Text = "Result:";
            // 
            // ProductionResult
            // 
            ProductionResult.FormattingEnabled = true;
            ProductionResult.Location = new Point(269, 22);
            ProductionResult.Name = "ProductionResult";
            ProductionResult.Size = new Size(156, 23);
            ProductionResult.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 54);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 6;
            label3.Text = "Duration:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 25);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 5;
            label2.Text = "Module:";
            // 
            // ProductionModule
            // 
            ProductionModule.FormattingEnabled = true;
            ProductionModule.Location = new Point(63, 22);
            ProductionModule.Name = "ProductionModule";
            ProductionModule.Size = new Size(153, 23);
            ProductionModule.TabIndex = 4;
            // 
            // RequirementTypeBox
            // 
            RequirementTypeBox.FormattingEnabled = true;
            RequirementTypeBox.Location = new Point(189, 129);
            RequirementTypeBox.Name = "RequirementTypeBox";
            RequirementTypeBox.Size = new Size(104, 23);
            RequirementTypeBox.TabIndex = 3;
            // 
            // DeleteRequirementButton
            // 
            DeleteRequirementButton.Location = new Point(323, 129);
            DeleteRequirementButton.Name = "DeleteRequirementButton";
            DeleteRequirementButton.Size = new Size(23, 23);
            DeleteRequirementButton.TabIndex = 2;
            DeleteRequirementButton.Text = "-";
            DeleteRequirementButton.UseVisualStyleBackColor = true;
            // 
            // AddRequirementButton
            // 
            AddRequirementButton.Location = new Point(299, 129);
            AddRequirementButton.Name = "AddRequirementButton";
            AddRequirementButton.Size = new Size(23, 23);
            AddRequirementButton.TabIndex = 1;
            AddRequirementButton.Text = "+";
            AddRequirementButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(RequirementsList);
            groupBox2.Controls.Add(groupBox4);
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(RequirementID);
            groupBox2.Location = new Point(6, 134);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(348, 183);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Requirements";
            // 
            // RequirementsList
            // 
            RequirementsList.FormattingEnabled = true;
            RequirementsList.ItemHeight = 15;
            RequirementsList.Location = new Point(3, 14);
            RequirementsList.Name = "RequirementsList";
            RequirementsList.Size = new Size(150, 169);
            RequirementsList.TabIndex = 8;
            RequirementsList.SelectedIndexChanged += RequirementsList_SelectedIndexChanged;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(RequirementEncoded);
            groupBox4.Controls.Add(RequirementFunctional);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(RequirementAmount);
            groupBox4.Location = new Point(159, 117);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(182, 63);
            groupBox4.TabIndex = 7;
            groupBox4.TabStop = false;
            groupBox4.Text = "Params";
            // 
            // RequirementEncoded
            // 
            RequirementEncoded.AutoSize = true;
            RequirementEncoded.Location = new Point(93, 39);
            RequirementEncoded.Name = "RequirementEncoded";
            RequirementEncoded.Size = new Size(71, 19);
            RequirementEncoded.TabIndex = 17;
            RequirementEncoded.TabStop = true;
            RequirementEncoded.Text = "Encoded";
            RequirementEncoded.UseVisualStyleBackColor = true;
            // 
            // RequirementFunctional
            // 
            RequirementFunctional.AutoSize = true;
            RequirementFunctional.Location = new Point(12, 39);
            RequirementFunctional.Name = "RequirementFunctional";
            RequirementFunctional.Size = new Size(81, 19);
            RequirementFunctional.TabIndex = 16;
            RequirementFunctional.TabStop = true;
            RequirementFunctional.Text = "Functional";
            RequirementFunctional.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(35, 18);
            label6.Name = "label6";
            label6.Size = new Size(52, 15);
            label6.TabIndex = 15;
            label6.Text = "Amt/Lvl:";
            // 
            // RequirementAmount
            // 
            RequirementAmount.Location = new Point(93, 15);
            RequirementAmount.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            RequirementAmount.Name = "RequirementAmount";
            RequirementAmount.Size = new Size(53, 23);
            RequirementAmount.TabIndex = 14;
            RequirementAmount.TextAlign = HorizontalAlignment.Center;
            RequirementAmount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(QuestButton);
            groupBox3.Controls.Add(ResourceButton);
            groupBox3.Controls.Add(ItemButton);
            groupBox3.Controls.Add(AreaButton);
            groupBox3.Controls.Add(ToolButton);
            groupBox3.Location = new Point(171, 22);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(157, 54);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Type";
            // 
            // QuestButton
            // 
            QuestButton.AutoSize = true;
            QuestButton.Location = new Point(90, 32);
            QuestButton.Name = "QuestButton";
            QuestButton.Size = new Size(56, 19);
            QuestButton.TabIndex = 4;
            QuestButton.TabStop = true;
            QuestButton.Text = "Quest";
            QuestButton.UseVisualStyleBackColor = true;
            // 
            // ResourceButton
            // 
            ResourceButton.AutoSize = true;
            ResourceButton.Location = new Point(15, 32);
            ResourceButton.Name = "ResourceButton";
            ResourceButton.Size = new Size(73, 19);
            ResourceButton.TabIndex = 3;
            ResourceButton.TabStop = true;
            ResourceButton.Text = "Resource";
            ResourceButton.UseVisualStyleBackColor = true;
            // 
            // ItemButton
            // 
            ItemButton.AutoSize = true;
            ItemButton.Location = new Point(54, 14);
            ItemButton.Name = "ItemButton";
            ItemButton.Size = new Size(49, 19);
            ItemButton.TabIndex = 2;
            ItemButton.TabStop = true;
            ItemButton.Text = "Item";
            ItemButton.UseVisualStyleBackColor = true;
            // 
            // AreaButton
            // 
            AreaButton.AutoSize = true;
            AreaButton.Location = new Point(6, 14);
            AreaButton.Name = "AreaButton";
            AreaButton.Size = new Size(49, 19);
            AreaButton.TabIndex = 1;
            AreaButton.TabStop = true;
            AreaButton.Text = "Area";
            AreaButton.UseVisualStyleBackColor = true;
            // 
            // ToolButton
            // 
            ToolButton.AutoSize = true;
            ToolButton.Location = new Point(104, 14);
            ToolButton.Name = "ToolButton";
            ToolButton.Size = new Size(47, 19);
            ToolButton.TabIndex = 0;
            ToolButton.TabStop = true;
            ToolButton.Text = "Tool";
            ToolButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(161, 91);
            label1.Name = "label1";
            label1.Size = new Size(21, 15);
            label1.TabIndex = 5;
            label1.Text = "ID:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // RequirementID
            // 
            RequirementID.FormattingEnabled = true;
            RequirementID.Location = new Point(188, 88);
            RequirementID.Name = "RequirementID";
            RequirementID.Size = new Size(133, 23);
            RequirementID.TabIndex = 4;
            // 
            // ProductionList
            // 
            ProductionList.Dock = DockStyle.Left;
            ProductionList.FormattingEnabled = true;
            ProductionList.ItemHeight = 15;
            ProductionList.Location = new Point(3, 3);
            ProductionList.Name = "ProductionList";
            ProductionList.Size = new Size(200, 348);
            ProductionList.TabIndex = 2;
            ProductionList.SelectedIndexChanged += ProductionList_SelectedIndexChanged;
            // 
            // HideoutScavCase
            // 
            HideoutScavCase.Location = new Point(4, 24);
            HideoutScavCase.Name = "HideoutScavCase";
            HideoutScavCase.Padding = new Padding(3);
            HideoutScavCase.Size = new Size(678, 354);
            HideoutScavCase.TabIndex = 1;
            HideoutScavCase.Text = "Scav Case";
            HideoutScavCase.UseVisualStyleBackColor = true;
            // 
            // DatabaseLocales
            // 
            DatabaseLocales.Location = new Point(4, 24);
            DatabaseLocales.Name = "DatabaseLocales";
            DatabaseLocales.Padding = new Padding(3);
            DatabaseLocales.Size = new Size(692, 388);
            DatabaseLocales.TabIndex = 2;
            DatabaseLocales.Text = "Locales";
            DatabaseLocales.UseVisualStyleBackColor = true;
            // 
            // DatabaseLocations
            // 
            DatabaseLocations.Location = new Point(4, 24);
            DatabaseLocations.Name = "DatabaseLocations";
            DatabaseLocations.Size = new Size(692, 388);
            DatabaseLocations.TabIndex = 3;
            DatabaseLocations.Text = "Locations";
            DatabaseLocations.UseVisualStyleBackColor = true;
            // 
            // DatabaseLoot
            // 
            DatabaseLoot.Location = new Point(4, 24);
            DatabaseLoot.Name = "DatabaseLoot";
            DatabaseLoot.Size = new Size(692, 388);
            DatabaseLoot.TabIndex = 4;
            DatabaseLoot.Text = "Loot";
            DatabaseLoot.UseVisualStyleBackColor = true;
            // 
            // DatabaseMatch
            // 
            DatabaseMatch.Location = new Point(4, 24);
            DatabaseMatch.Name = "DatabaseMatch";
            DatabaseMatch.Size = new Size(692, 388);
            DatabaseMatch.TabIndex = 5;
            DatabaseMatch.Text = "Match";
            DatabaseMatch.UseVisualStyleBackColor = true;
            // 
            // DatabaseTraders
            // 
            DatabaseTraders.Location = new Point(4, 24);
            DatabaseTraders.Name = "DatabaseTraders";
            DatabaseTraders.Size = new Size(692, 388);
            DatabaseTraders.TabIndex = 6;
            DatabaseTraders.Text = "Traders";
            DatabaseTraders.UseVisualStyleBackColor = true;
            // 
            // ServerImagesTab
            // 
            ServerImagesTab.Location = new Point(4, 24);
            ServerImagesTab.Name = "ServerImagesTab";
            ServerImagesTab.Size = new Size(706, 422);
            ServerImagesTab.TabIndex = 2;
            ServerImagesTab.Text = "Images";
            ServerImagesTab.UseVisualStyleBackColor = true;
            // 
            // UserTab
            // 
            UserTab.Controls.Add(ProfilesTab);
            UserTab.Controls.Add(SPTSettingsTab);
            UserTab.Dock = DockStyle.Fill;
            UserTab.Location = new Point(0, 0);
            UserTab.Name = "UserTab";
            UserTab.SelectedIndex = 0;
            UserTab.Size = new Size(714, 450);
            UserTab.TabIndex = 6;
            // 
            // ProfilesTab
            // 
            ProfilesTab.Controls.Add(toolStrip3);
            ProfilesTab.Controls.Add(listView1);
            ProfilesTab.Location = new Point(4, 24);
            ProfilesTab.Name = "ProfilesTab";
            ProfilesTab.Padding = new Padding(3);
            ProfilesTab.Size = new Size(706, 422);
            ProfilesTab.TabIndex = 1;
            ProfilesTab.Text = "Profiles";
            ProfilesTab.UseVisualStyleBackColor = true;
            // 
            // toolStrip3
            // 
            toolStrip3.Dock = DockStyle.Right;
            toolStrip3.Items.AddRange(new ToolStripItem[] { toolStripButton5, toolStripButton4 });
            toolStrip3.Location = new Point(648, 3);
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
            listView1.Items.AddRange(new ListViewItem[] { listViewItem3 });
            listView1.Location = new Point(3, 3);
            listView1.Name = "listView1";
            listView1.Size = new Size(700, 416);
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
            SPTSettingsTab.Size = new Size(706, 422);
            SPTSettingsTab.TabIndex = 2;
            SPTSettingsTab.Text = "SPTSettings";
            SPTSettingsTab.UseVisualStyleBackColor = true;
            // 
            // ModsPanel
            // 
            ModsPanel.Controls.Add(listView2);
            ModsPanel.Controls.Add(toolStrip5);
            ModsPanel.Controls.Add(toolStrip4);
            ModsPanel.Dock = DockStyle.Fill;
            ModsPanel.Location = new Point(0, 0);
            ModsPanel.Name = "ModsPanel";
            ModsPanel.Size = new Size(714, 450);
            ModsPanel.TabIndex = 7;
            // 
            // listView2
            // 
            listView2.Dock = DockStyle.Fill;
            listView2.Location = new Point(0, 25);
            listView2.Name = "listView2";
            listView2.Size = new Size(647, 425);
            listView2.TabIndex = 3;
            listView2.UseCompatibleStateImageBehavior = false;
            // 
            // toolStrip5
            // 
            toolStrip5.Dock = DockStyle.Right;
            toolStrip5.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip5.Items.AddRange(new ToolStripItem[] { toolStripButton8, toolStripButton10, toolStripSeparator4, toolStripButton9, toolStripButton13, toolStripSeparator1, toolStripButton12, toolStripButton14, toolStripSeparator2, toolStripButton11 });
            toolStrip5.Location = new Point(647, 25);
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
            toolStrip4.Size = new Size(714, 25);
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
            Controls.Add(UserPanel);
            Controls.Add(toolStrip1);
            Name = "InstanceManagerForm";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "InstanceEditorForm";
            Load += InstanceEditorForm_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            UserPanel.ResumeLayout(false);
            ServerPanel.ResumeLayout(false);
            ServerTabs.ResumeLayout(false);
            ServerDatabaseTab.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            DatabaseHideout.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            HideoutProduction.ResumeLayout(false);
            ProductionGroup.ResumeLayout(false);
            ProductionGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ProductionLimit).EndInit();
            ((System.ComponentModel.ISupportInitialize)ProductionDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize)ProductionCount).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)RequirementAmount).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            UserTab.ResumeLayout(false);
            ProfilesTab.ResumeLayout(false);
            ProfilesTab.PerformLayout();
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
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
        private ColumnHeader NameColumn;
        private ToolStrip toolStrip1;
        private ToolStripButton ServerButton;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton7;
        private ToolStrip miniToolStrip;
        private Panel UserPanel;
        private TabControl UserTab;
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
        private Panel ModsPanel;
        private ListView listView2;
        private ToolStrip toolStrip5;
        private ToolStripButton toolStripButton8;
        private ToolStripButton toolStripButton10;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton toolStripButton9;
        private ToolStripButton toolStripButton13;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton12;
        private ToolStripButton toolStripButton14;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButton11;
        private ToolStrip toolStrip4;
        private ToolStripLabel toolStripLabel1;
        private Panel ServerPanel;
        private TabControl ServerTabs;
        private TabPage ServerConfigsTab;
        private TabPage ServerDatabaseTab;
        private TabPage ServerImagesTab;
        private TabControl tabControl1;
        private TabPage DatabaseBots;
        private TabPage DatabaseHideout;
        private TabPage DatabaseLocales;
        private TabPage DatabaseLocations;
        private TabPage DatabaseLoot;
        private TabPage DatabaseMatch;
        private TabPage DatabaseTraders;
        private TabControl tabControl2;
        private TabPage HideoutProduction;
        private TabPage HideoutScavCase;
        private GroupBox ProductionGroup;
        private GroupBox groupBox2;
        private Button AddRequirementButton;
        private Button DeleteRequirementButton;
        private ComboBox RequirementTypeBox;
        private ComboBox RequirementID;
        private Label label1;
        private GroupBox groupBox3;
        private RadioButton ItemButton;
        private RadioButton AreaButton;
        private RadioButton ToolButton;
        private GroupBox groupBox4;
        private RadioButton ResourceButton;
        private Label label2;
        private ComboBox ProductionModule;
        private Label label3;
        private ComboBox ProductionResult;
        private Label label4;
        private RadioButton ProductionLocked;
        private RadioButton ProductionContinuous;
        private RadioButton ProductionFuelNeeded;
        private NumericUpDown ProductionCount;
        private Label label5;
        private NumericUpDown ProductionDuration;
        private RadioButton QuestButton;
        private Label label6;
        private NumericUpDown RequirementAmount;
        private RadioButton RequirementFunctional;
        private RadioButton RequirementEncoded;
        private Label ProductionLimitLabel;
        private NumericUpDown ProductionLimit;
        private ListBox ProductionList;
        private ListBox RequirementsList;
    }
}
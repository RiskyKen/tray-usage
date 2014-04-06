namespace RiskyKen.TrayUsage
{
    partial class frmOptions
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.lblLoaded = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkMissingIconFix = new System.Windows.Forms.CheckBox();
            this.chkFullScreenSleep = new System.Windows.Forms.CheckBox();
            this.chkRunOnStartup = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numUpdateCheckTime = new System.Windows.Forms.NumericUpDown();
            this.chkAutoUpdate = new System.Windows.Forms.CheckBox();
            this.tabIcons = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabText = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRollover = new System.Windows.Forms.TextBox();
            this.txtIconName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabData = new System.Windows.Forms.TabPage();
            this.listData = new System.Windows.Forms.ListBox();
            this.btnEditDataLinks = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tabRender = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblRenderInfo = new System.Windows.Forms.Label();
            this.comboRenderType = new System.Windows.Forms.ComboBox();
            this.btnRenderOptions = new System.Windows.Forms.Button();
            this.btnMoveIconUp = new System.Windows.Forms.Button();
            this.btnMoveIconDown = new System.Windows.Forms.Button();
            this.btnAddPresetIcon = new System.Windows.Forms.Button();
            this.contextMenuPersets = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addCPUItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRAMIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDiskSpaceIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDiskAccessIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBatteryIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddIcon = new System.Windows.Forms.Button();
            this.btnRemoveIcon = new System.Windows.Forms.Button();
            this.listIcons = new System.Windows.Forms.ListBox();
            this.tabAdvanced = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comboThreadPriority = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkAlwaysRedraw = new System.Windows.Forms.CheckBox();
            this.txtUpdateURL = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpdateCheckTime)).BeginInit();
            this.tabIcons.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabText.SuspendLayout();
            this.tabData.SuspendLayout();
            this.tabRender.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuPersets.SuspendLayout();
            this.tabAdvanced.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabIcons);
            this.tabControl1.Controls.Add(this.tabAdvanced);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(770, 399);
            this.tabControl1.TabIndex = 0;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.lblLoaded);
            this.tabGeneral.Controls.Add(this.groupBox4);
            this.tabGeneral.Controls.Add(this.groupBox3);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(10);
            this.tabGeneral.Size = new System.Drawing.Size(762, 373);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // lblLoaded
            // 
            this.lblLoaded.AutoSize = true;
            this.lblLoaded.Location = new System.Drawing.Point(7, 358);
            this.lblLoaded.Name = "lblLoaded";
            this.lblLoaded.Size = new System.Drawing.Size(111, 13);
            this.lblLoaded.TabIndex = 3;
            this.lblLoaded.Text = "Loaded Data Classes:";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.chkMissingIconFix);
            this.groupBox4.Controls.Add(this.chkFullScreenSleep);
            this.groupBox4.Controls.Add(this.chkRunOnStartup);
            this.groupBox4.Location = new System.Drawing.Point(3, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(6, 0, 6, 3);
            this.groupBox4.Size = new System.Drawing.Size(746, 87);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // chkMissingIconFix
            // 
            this.chkMissingIconFix.AutoSize = true;
            this.chkMissingIconFix.Location = new System.Drawing.Point(9, 62);
            this.chkMissingIconFix.Name = "chkMissingIconFix";
            this.chkMissingIconFix.Size = new System.Drawing.Size(174, 17);
            this.chkMissingIconFix.TabIndex = 0;
            this.chkMissingIconFix.Text = "Use Win7/Vista missing icon fix";
            this.chkMissingIconFix.UseVisualStyleBackColor = true;
            // 
            // chkFullScreenSleep
            // 
            this.chkFullScreenSleep.AutoSize = true;
            this.chkFullScreenSleep.Location = new System.Drawing.Point(9, 39);
            this.chkFullScreenSleep.Name = "chkFullScreenSleep";
            this.chkFullScreenSleep.Size = new System.Drawing.Size(222, 17);
            this.chkFullScreenSleep.TabIndex = 0;
            this.chkFullScreenSleep.Text = "Sleep when full screen program is running";
            this.chkFullScreenSleep.UseVisualStyleBackColor = true;
            // 
            // chkRunOnStartup
            // 
            this.chkRunOnStartup.AutoSize = true;
            this.chkRunOnStartup.Location = new System.Drawing.Point(9, 16);
            this.chkRunOnStartup.Name = "chkRunOnStartup";
            this.chkRunOnStartup.Size = new System.Drawing.Size(128, 17);
            this.chkRunOnStartup.TabIndex = 0;
            this.chkRunOnStartup.Text = "Run on system starup";
            this.chkRunOnStartup.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.numUpdateCheckTime);
            this.groupBox3.Controls.Add(this.chkAutoUpdate);
            this.groupBox3.Location = new System.Drawing.Point(3, 106);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6, 0, 6, 3);
            this.groupBox3.Size = new System.Drawing.Size(746, 89);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Update";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Check every x mins (0 = Disabled):";
            // 
            // numUpdateCheckTime
            // 
            this.numUpdateCheckTime.Location = new System.Drawing.Point(9, 37);
            this.numUpdateCheckTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUpdateCheckTime.Name = "numUpdateCheckTime";
            this.numUpdateCheckTime.Size = new System.Drawing.Size(60, 20);
            this.numUpdateCheckTime.TabIndex = 1;
            this.numUpdateCheckTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkAutoUpdate
            // 
            this.chkAutoUpdate.AutoSize = true;
            this.chkAutoUpdate.Location = new System.Drawing.Point(9, 63);
            this.chkAutoUpdate.Name = "chkAutoUpdate";
            this.chkAutoUpdate.Size = new System.Drawing.Size(84, 17);
            this.chkAutoUpdate.TabIndex = 0;
            this.chkAutoUpdate.Text = "Auto update";
            this.chkAutoUpdate.UseVisualStyleBackColor = true;
            // 
            // tabIcons
            // 
            this.tabIcons.Controls.Add(this.tabControl2);
            this.tabIcons.Controls.Add(this.btnMoveIconUp);
            this.tabIcons.Controls.Add(this.btnMoveIconDown);
            this.tabIcons.Controls.Add(this.btnAddPresetIcon);
            this.tabIcons.Controls.Add(this.btnAddIcon);
            this.tabIcons.Controls.Add(this.btnRemoveIcon);
            this.tabIcons.Controls.Add(this.listIcons);
            this.tabIcons.Location = new System.Drawing.Point(4, 22);
            this.tabIcons.Name = "tabIcons";
            this.tabIcons.Padding = new System.Windows.Forms.Padding(10);
            this.tabIcons.Size = new System.Drawing.Size(762, 373);
            this.tabIcons.TabIndex = 1;
            this.tabIcons.Text = "Icons";
            this.tabIcons.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabText);
            this.tabControl2.Controls.Add(this.tabData);
            this.tabControl2.Controls.Add(this.tabRender);
            this.tabControl2.Location = new System.Drawing.Point(168, 13);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(581, 349);
            this.tabControl2.TabIndex = 6;
            // 
            // tabText
            // 
            this.tabText.Controls.Add(this.label1);
            this.tabText.Controls.Add(this.txtRollover);
            this.tabText.Controls.Add(this.txtIconName);
            this.tabText.Controls.Add(this.label7);
            this.tabText.Location = new System.Drawing.Point(4, 22);
            this.tabText.Name = "tabText";
            this.tabText.Padding = new System.Windows.Forms.Padding(3);
            this.tabText.Size = new System.Drawing.Size(573, 323);
            this.tabText.TabIndex = 0;
            this.tabText.Text = "Text";
            this.tabText.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Icon Name:";
            // 
            // txtRollover
            // 
            this.txtRollover.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRollover.Location = new System.Drawing.Point(3, 58);
            this.txtRollover.Multiline = true;
            this.txtRollover.Name = "txtRollover";
            this.txtRollover.Size = new System.Drawing.Size(564, 112);
            this.txtRollover.TabIndex = 8;
            this.toolTip1.SetToolTip(this.txtRollover, "{iconname} will show the icon name.\r\n{Data Name:DataIndex} example {CPU:0} will s" +
                    "how total cpu use.");
            this.txtRollover.TextChanged += new System.EventHandler(this.txtRollover_TextChanged);
            // 
            // txtIconName
            // 
            this.txtIconName.Location = new System.Drawing.Point(3, 19);
            this.txtIconName.Name = "txtIconName";
            this.txtIconName.Size = new System.Drawing.Size(100, 20);
            this.txtIconName.TabIndex = 1;
            this.txtIconName.Text = "Test Icon";
            this.txtIconName.TextChanged += new System.EventHandler(this.txtIconName_TextChanged);
            this.txtIconName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIconName_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Rollover Text:";
            // 
            // tabData
            // 
            this.tabData.Controls.Add(this.listData);
            this.tabData.Controls.Add(this.btnEditDataLinks);
            this.tabData.Controls.Add(this.label3);
            this.tabData.Location = new System.Drawing.Point(4, 22);
            this.tabData.Name = "tabData";
            this.tabData.Padding = new System.Windows.Forms.Padding(3);
            this.tabData.Size = new System.Drawing.Size(573, 321);
            this.tabData.TabIndex = 1;
            this.tabData.Text = "Data";
            this.tabData.UseVisualStyleBackColor = true;
            // 
            // listData
            // 
            this.listData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listData.FormattingEnabled = true;
            this.listData.IntegralHeight = false;
            this.listData.Location = new System.Drawing.Point(3, 19);
            this.listData.Name = "listData";
            this.listData.Size = new System.Drawing.Size(564, 134);
            this.listData.TabIndex = 6;
            // 
            // btnEditDataLinks
            // 
            this.btnEditDataLinks.Location = new System.Drawing.Point(3, 159);
            this.btnEditDataLinks.Name = "btnEditDataLinks";
            this.btnEditDataLinks.Size = new System.Drawing.Size(150, 23);
            this.btnEditDataLinks.TabIndex = 7;
            this.btnEditDataLinks.Text = "Edit...";
            this.btnEditDataLinks.UseVisualStyleBackColor = true;
            this.btnEditDataLinks.Click += new System.EventHandler(this.btnEditDataLinks_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data Inputs:";
            // 
            // tabRender
            // 
            this.tabRender.Controls.Add(this.label2);
            this.tabRender.Controls.Add(this.groupBox2);
            this.tabRender.Controls.Add(this.comboRenderType);
            this.tabRender.Controls.Add(this.btnRenderOptions);
            this.tabRender.Location = new System.Drawing.Point(4, 22);
            this.tabRender.Name = "tabRender";
            this.tabRender.Size = new System.Drawing.Size(573, 321);
            this.tabRender.TabIndex = 2;
            this.tabRender.Text = "Render";
            this.tabRender.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Render Type:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblRenderInfo);
            this.groupBox2.Location = new System.Drawing.Point(3, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(567, 125);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Renderer Info:";
            // 
            // lblRenderInfo
            // 
            this.lblRenderInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRenderInfo.Location = new System.Drawing.Point(6, 16);
            this.lblRenderInfo.Name = "lblRenderInfo";
            this.lblRenderInfo.Size = new System.Drawing.Size(555, 96);
            this.lblRenderInfo.TabIndex = 4;
            this.lblRenderInfo.Text = "label4";
            // 
            // comboRenderType
            // 
            this.comboRenderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRenderType.FormattingEnabled = true;
            this.comboRenderType.Location = new System.Drawing.Point(3, 19);
            this.comboRenderType.Name = "comboRenderType";
            this.comboRenderType.Size = new System.Drawing.Size(172, 21);
            this.comboRenderType.TabIndex = 3;
            this.comboRenderType.SelectedIndexChanged += new System.EventHandler(this.comboRenderType_SelectedIndexChanged);
            // 
            // btnRenderOptions
            // 
            this.btnRenderOptions.Location = new System.Drawing.Point(181, 19);
            this.btnRenderOptions.Name = "btnRenderOptions";
            this.btnRenderOptions.Size = new System.Drawing.Size(104, 23);
            this.btnRenderOptions.TabIndex = 4;
            this.btnRenderOptions.Text = "Render Options...";
            this.btnRenderOptions.UseVisualStyleBackColor = true;
            this.btnRenderOptions.Click += new System.EventHandler(this.btnRenderOptions_Click);
            // 
            // btnMoveIconUp
            // 
            this.btnMoveIconUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMoveIconUp.Image = global::RiskyKen.TrayUsage.Properties.Resources.arrow_up;
            this.btnMoveIconUp.Location = new System.Drawing.Point(34, 345);
            this.btnMoveIconUp.Name = "btnMoveIconUp";
            this.btnMoveIconUp.Size = new System.Drawing.Size(25, 25);
            this.btnMoveIconUp.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnMoveIconUp, "Move Up");
            this.btnMoveIconUp.UseVisualStyleBackColor = true;
            this.btnMoveIconUp.Click += new System.EventHandler(this.btnMoveIconUp_Click);
            // 
            // btnMoveIconDown
            // 
            this.btnMoveIconDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMoveIconDown.Image = global::RiskyKen.TrayUsage.Properties.Resources.arrow_down;
            this.btnMoveIconDown.Location = new System.Drawing.Point(65, 345);
            this.btnMoveIconDown.Name = "btnMoveIconDown";
            this.btnMoveIconDown.Size = new System.Drawing.Size(25, 25);
            this.btnMoveIconDown.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnMoveIconDown, "Move Down");
            this.btnMoveIconDown.UseVisualStyleBackColor = true;
            this.btnMoveIconDown.Click += new System.EventHandler(this.btnMoveIconDown_Click);
            // 
            // btnAddPresetIcon
            // 
            this.btnAddPresetIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddPresetIcon.ContextMenuStrip = this.contextMenuPersets;
            this.btnAddPresetIcon.Image = global::RiskyKen.TrayUsage.Properties.Resources.lightning_add;
            this.btnAddPresetIcon.Location = new System.Drawing.Point(127, 345);
            this.btnAddPresetIcon.Name = "btnAddPresetIcon";
            this.btnAddPresetIcon.Size = new System.Drawing.Size(25, 25);
            this.btnAddPresetIcon.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnAddPresetIcon, "Add Preset Icon");
            this.btnAddPresetIcon.UseVisualStyleBackColor = true;
            this.btnAddPresetIcon.Click += new System.EventHandler(this.btnAddPresetIcon_Click);
            // 
            // contextMenuPersets
            // 
            this.contextMenuPersets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCPUItemToolStripMenuItem,
            this.addRAMIconToolStripMenuItem,
            this.addToolStripMenuItem,
            this.addDiskSpaceIconToolStripMenuItem,
            this.addDiskAccessIconToolStripMenuItem,
            this.addBatteryIconToolStripMenuItem});
            this.contextMenuPersets.Name = "contextMenuPersets";
            this.contextMenuPersets.Size = new System.Drawing.Size(187, 136);
            this.contextMenuPersets.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuPersets_ItemClicked);
            // 
            // addCPUItemToolStripMenuItem
            // 
            this.addCPUItemToolStripMenuItem.Name = "addCPUItemToolStripMenuItem";
            this.addCPUItemToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addCPUItemToolStripMenuItem.Tag = "CPU";
            this.addCPUItemToolStripMenuItem.Text = "Add CPU Icon";
            // 
            // addRAMIconToolStripMenuItem
            // 
            this.addRAMIconToolStripMenuItem.Name = "addRAMIconToolStripMenuItem";
            this.addRAMIconToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addRAMIconToolStripMenuItem.Tag = "RAM";
            this.addRAMIconToolStripMenuItem.Text = "Add RAM Icon";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addToolStripMenuItem.Tag = "Network";
            this.addToolStripMenuItem.Text = "Add Network Icon";
            // 
            // addDiskSpaceIconToolStripMenuItem
            // 
            this.addDiskSpaceIconToolStripMenuItem.Name = "addDiskSpaceIconToolStripMenuItem";
            this.addDiskSpaceIconToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addDiskSpaceIconToolStripMenuItem.Tag = "Disk Space";
            this.addDiskSpaceIconToolStripMenuItem.Text = "Add Disk Space Icon";
            // 
            // addDiskAccessIconToolStripMenuItem
            // 
            this.addDiskAccessIconToolStripMenuItem.Name = "addDiskAccessIconToolStripMenuItem";
            this.addDiskAccessIconToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addDiskAccessIconToolStripMenuItem.Tag = "Disk Access";
            this.addDiskAccessIconToolStripMenuItem.Text = "Add Disk Access Icon";
            // 
            // addBatteryIconToolStripMenuItem
            // 
            this.addBatteryIconToolStripMenuItem.Name = "addBatteryIconToolStripMenuItem";
            this.addBatteryIconToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addBatteryIconToolStripMenuItem.Tag = "Battery";
            this.addBatteryIconToolStripMenuItem.Text = "Add Battery Icon";
            // 
            // btnAddIcon
            // 
            this.btnAddIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddIcon.Image = global::RiskyKen.TrayUsage.Properties.Resources.add;
            this.btnAddIcon.Location = new System.Drawing.Point(96, 345);
            this.btnAddIcon.Name = "btnAddIcon";
            this.btnAddIcon.Size = new System.Drawing.Size(25, 25);
            this.btnAddIcon.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnAddIcon, "Add");
            this.btnAddIcon.UseVisualStyleBackColor = true;
            this.btnAddIcon.Click += new System.EventHandler(this.btnAddIcon_Click);
            // 
            // btnRemoveIcon
            // 
            this.btnRemoveIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveIcon.Image = global::RiskyKen.TrayUsage.Properties.Resources.delete;
            this.btnRemoveIcon.Location = new System.Drawing.Point(3, 345);
            this.btnRemoveIcon.Name = "btnRemoveIcon";
            this.btnRemoveIcon.Size = new System.Drawing.Size(25, 25);
            this.btnRemoveIcon.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnRemoveIcon, "Remove");
            this.btnRemoveIcon.UseVisualStyleBackColor = true;
            this.btnRemoveIcon.Click += new System.EventHandler(this.btnRemoveIcon_Click);
            // 
            // listIcons
            // 
            this.listIcons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listIcons.FormattingEnabled = true;
            this.listIcons.IntegralHeight = false;
            this.listIcons.Items.AddRange(new object[] {
            "Test Icon"});
            this.listIcons.Location = new System.Drawing.Point(3, 13);
            this.listIcons.Name = "listIcons";
            this.listIcons.Size = new System.Drawing.Size(149, 326);
            this.listIcons.TabIndex = 0;
            this.listIcons.SelectedIndexChanged += new System.EventHandler(this.listIcons_SelectedIndexChanged);
            // 
            // tabAdvanced
            // 
            this.tabAdvanced.Controls.Add(this.groupBox5);
            this.tabAdvanced.Location = new System.Drawing.Point(4, 22);
            this.tabAdvanced.Name = "tabAdvanced";
            this.tabAdvanced.Padding = new System.Windows.Forms.Padding(10);
            this.tabAdvanced.Size = new System.Drawing.Size(762, 373);
            this.tabAdvanced.TabIndex = 2;
            this.tabAdvanced.Text = "Advanced";
            this.tabAdvanced.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.comboThreadPriority);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.chkAlwaysRedraw);
            this.groupBox5.Controls.Add(this.txtUpdateURL);
            this.groupBox5.Location = new System.Drawing.Point(3, 13);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(6, 0, 6, 3);
            this.groupBox5.Size = new System.Drawing.Size(746, 159);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            // 
            // comboThreadPriority
            // 
            this.comboThreadPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboThreadPriority.FormattingEnabled = true;
            this.comboThreadPriority.Items.AddRange(new object[] {
            "Lowest",
            "Below Normal",
            "Normal",
            "Above Normal",
            "Highest"});
            this.comboThreadPriority.Location = new System.Drawing.Point(9, 116);
            this.comboThreadPriority.Name = "comboThreadPriority";
            this.comboThreadPriority.Size = new System.Drawing.Size(121, 21);
            this.comboThreadPriority.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Thread Priority:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Update URL:";
            // 
            // chkAlwaysRedraw
            // 
            this.chkAlwaysRedraw.AutoSize = true;
            this.chkAlwaysRedraw.Location = new System.Drawing.Point(9, 67);
            this.chkAlwaysRedraw.Name = "chkAlwaysRedraw";
            this.chkAlwaysRedraw.Size = new System.Drawing.Size(169, 17);
            this.chkAlwaysRedraw.TabIndex = 2;
            this.chkAlwaysRedraw.Text = "Always redraw icons (DEBUG)";
            this.chkAlwaysRedraw.UseVisualStyleBackColor = true;
            // 
            // txtUpdateURL
            // 
            this.txtUpdateURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpdateURL.Location = new System.Drawing.Point(9, 32);
            this.txtUpdateURL.Name = "txtUpdateURL";
            this.txtUpdateURL.Size = new System.Drawing.Size(728, 20);
            this.txtUpdateURL.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(545, 417);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(626, 417);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(707, 417);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 15000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 452);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tray Usage - Options";
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpdateCheckTime)).EndInit();
            this.tabIcons.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabText.ResumeLayout(false);
            this.tabText.PerformLayout();
            this.tabData.ResumeLayout(false);
            this.tabData.PerformLayout();
            this.tabRender.ResumeLayout(false);
            this.tabRender.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.contextMenuPersets.ResumeLayout(false);
            this.tabAdvanced.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabIcons;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TabPage tabAdvanced;
        private System.Windows.Forms.ListBox listIcons;
        private System.Windows.Forms.Button btnAddIcon;
        private System.Windows.Forms.Button btnRemoveIcon;
        private System.Windows.Forms.Button btnRenderOptions;
        private System.Windows.Forms.ComboBox comboRenderType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIconName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listData;
        private System.Windows.Forms.Button btnEditDataLinks;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblRenderInfo;
        private System.Windows.Forms.CheckBox chkRunOnStartup;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkAutoUpdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numUpdateCheckTime;
        private System.Windows.Forms.TextBox txtUpdateURL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkAlwaysRedraw;
        private System.Windows.Forms.CheckBox chkMissingIconFix;
        private System.Windows.Forms.CheckBox chkFullScreenSleep;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox comboThreadPriority;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnMoveIconUp;
        private System.Windows.Forms.Button btnMoveIconDown;
        private System.Windows.Forms.TextBox txtRollover;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblLoaded;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabText;
        private System.Windows.Forms.TabPage tabData;
        private System.Windows.Forms.TabPage tabRender;
        private System.Windows.Forms.Button btnAddPresetIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuPersets;
        private System.Windows.Forms.ToolStripMenuItem addCPUItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRAMIconToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDiskSpaceIconToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDiskAccessIconToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBatteryIconToolStripMenuItem;

    }
}


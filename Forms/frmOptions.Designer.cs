namespace TrayUsage
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkMissingIconFix = new System.Windows.Forms.CheckBox();
            this.chkFullScreenSleep = new System.Windows.Forms.CheckBox();
            this.chkRunOnStartup = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numUpdateCheckTime = new System.Windows.Forms.NumericUpDown();
            this.chkAutoUpdate = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnMoveIconUp = new System.Windows.Forms.Button();
            this.btnMoveIconDown = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRollover = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblRenderInfo = new System.Windows.Forms.Label();
            this.btnEditDataLinks = new System.Windows.Forms.Button();
            this.listData = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRenderOptions = new System.Windows.Forms.Button();
            this.comboRenderType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIconName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddIcon = new System.Windows.Forms.Button();
            this.btnRemoveIcon = new System.Windows.Forms.Button();
            this.listIcons = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
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
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpdateCheckTime)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(528, 333);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage1.Size = new System.Drawing.Size(520, 307);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkMissingIconFix);
            this.groupBox4.Controls.Add(this.chkFullScreenSleep);
            this.groupBox4.Controls.Add(this.chkRunOnStartup);
            this.groupBox4.Location = new System.Drawing.Point(9, 9);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(6, 0, 6, 3);
            this.groupBox4.Size = new System.Drawing.Size(502, 87);
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
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.numUpdateCheckTime);
            this.groupBox3.Controls.Add(this.chkAutoUpdate);
            this.groupBox3.Location = new System.Drawing.Point(9, 102);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6, 0, 6, 3);
            this.groupBox3.Size = new System.Drawing.Size(502, 89);
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnMoveIconUp);
            this.tabPage2.Controls.Add(this.btnMoveIconDown);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.btnAddIcon);
            this.tabPage2.Controls.Add(this.btnRemoveIcon);
            this.tabPage2.Controls.Add(this.listIcons);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage2.Size = new System.Drawing.Size(520, 307);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Icons";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnMoveIconUp
            // 
            this.btnMoveIconUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMoveIconUp.Image = global::TrayUsage.Properties.Resources.arrow_up;
            this.btnMoveIconUp.Location = new System.Drawing.Point(42, 271);
            this.btnMoveIconUp.Name = "btnMoveIconUp";
            this.btnMoveIconUp.Size = new System.Drawing.Size(23, 23);
            this.btnMoveIconUp.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnMoveIconUp, "Move Up");
            this.btnMoveIconUp.UseVisualStyleBackColor = true;
            this.btnMoveIconUp.Click += new System.EventHandler(this.btnMoveIconUp_Click);
            // 
            // btnMoveIconDown
            // 
            this.btnMoveIconDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMoveIconDown.Image = global::TrayUsage.Properties.Resources.arrow_down;
            this.btnMoveIconDown.Location = new System.Drawing.Point(71, 271);
            this.btnMoveIconDown.Name = "btnMoveIconDown";
            this.btnMoveIconDown.Size = new System.Drawing.Size(23, 23);
            this.btnMoveIconDown.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnMoveIconDown, "Move Down");
            this.btnMoveIconDown.UseVisualStyleBackColor = true;
            this.btnMoveIconDown.Click += new System.EventHandler(this.btnMoveIconDown_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtRollover);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnEditDataLinks);
            this.groupBox1.Controls.Add(this.listData);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnRenderOptions);
            this.groupBox1.Controls.Add(this.comboRenderType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtIconName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(129, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 281);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Icon Options";
            // 
            // txtRollover
            // 
            this.txtRollover.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRollover.Location = new System.Drawing.Point(9, 76);
            this.txtRollover.Name = "txtRollover";
            this.txtRollover.Size = new System.Drawing.Size(224, 20);
            this.txtRollover.TabIndex = 8;
            this.toolTip1.SetToolTip(this.txtRollover, "{iconname} will show the icon name.\r\n{Data Name:DataIndex} example {CPU:0} will s" +
                    "how total cpu use.");
            this.txtRollover.TextChanged += new System.EventHandler(this.txtRollover_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Rollover Text:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblRenderInfo);
            this.groupBox2.Location = new System.Drawing.Point(9, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(240, 121);
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
            this.lblRenderInfo.Size = new System.Drawing.Size(228, 102);
            this.lblRenderInfo.TabIndex = 4;
            this.lblRenderInfo.Text = "label4";
            // 
            // btnEditDataLinks
            // 
            this.btnEditDataLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditDataLinks.Location = new System.Drawing.Point(255, 249);
            this.btnEditDataLinks.Name = "btnEditDataLinks";
            this.btnEditDataLinks.Size = new System.Drawing.Size(117, 23);
            this.btnEditDataLinks.TabIndex = 7;
            this.btnEditDataLinks.Text = "Edit...";
            this.btnEditDataLinks.UseVisualStyleBackColor = true;
            this.btnEditDataLinks.Click += new System.EventHandler(this.btnEditDataLinks_Click);
            // 
            // listData
            // 
            this.listData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listData.FormattingEnabled = true;
            this.listData.IntegralHeight = false;
            this.listData.Location = new System.Drawing.Point(255, 32);
            this.listData.Name = "listData";
            this.listData.Size = new System.Drawing.Size(117, 211);
            this.listData.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data Inputs:";
            // 
            // btnRenderOptions
            // 
            this.btnRenderOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRenderOptions.Location = new System.Drawing.Point(150, 124);
            this.btnRenderOptions.Name = "btnRenderOptions";
            this.btnRenderOptions.Size = new System.Drawing.Size(99, 23);
            this.btnRenderOptions.TabIndex = 4;
            this.btnRenderOptions.Text = "Render Options...";
            this.btnRenderOptions.UseVisualStyleBackColor = true;
            this.btnRenderOptions.Click += new System.EventHandler(this.btnRenderOptions_Click);
            // 
            // comboRenderType
            // 
            this.comboRenderType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboRenderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRenderType.Enabled = false;
            this.comboRenderType.FormattingEnabled = true;
            this.comboRenderType.Items.AddRange(new object[] {
            "Basic",
            "History",
            "Image"});
            this.comboRenderType.Location = new System.Drawing.Point(9, 124);
            this.comboRenderType.Name = "comboRenderType";
            this.comboRenderType.Size = new System.Drawing.Size(135, 21);
            this.comboRenderType.TabIndex = 3;
            this.comboRenderType.SelectedIndexChanged += new System.EventHandler(this.comboRenderType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Render Type:";
            // 
            // txtIconName
            // 
            this.txtIconName.Location = new System.Drawing.Point(9, 32);
            this.txtIconName.Name = "txtIconName";
            this.txtIconName.Size = new System.Drawing.Size(100, 20);
            this.txtIconName.TabIndex = 1;
            this.txtIconName.Text = "Test Icon";
            this.txtIconName.TextChanged += new System.EventHandler(this.txtIconName_TextChanged);
            this.txtIconName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIconName_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Icon Name:";
            // 
            // btnAddIcon
            // 
            this.btnAddIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddIcon.Image = global::TrayUsage.Properties.Resources.add;
            this.btnAddIcon.Location = new System.Drawing.Point(100, 271);
            this.btnAddIcon.Name = "btnAddIcon";
            this.btnAddIcon.Size = new System.Drawing.Size(23, 23);
            this.btnAddIcon.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnAddIcon, "Add");
            this.btnAddIcon.UseVisualStyleBackColor = true;
            this.btnAddIcon.Click += new System.EventHandler(this.btnAddIcon_Click);
            // 
            // btnRemoveIcon
            // 
            this.btnRemoveIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveIcon.Image = global::TrayUsage.Properties.Resources.delete;
            this.btnRemoveIcon.Location = new System.Drawing.Point(13, 271);
            this.btnRemoveIcon.Name = "btnRemoveIcon";
            this.btnRemoveIcon.Size = new System.Drawing.Size(23, 23);
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
            this.listIcons.Location = new System.Drawing.Point(13, 13);
            this.listIcons.Name = "listIcons";
            this.listIcons.Size = new System.Drawing.Size(110, 252);
            this.listIcons.TabIndex = 0;
            this.listIcons.SelectedIndexChanged += new System.EventHandler(this.listIcons_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage3.Size = new System.Drawing.Size(520, 307);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Advanced";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.comboThreadPriority);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.chkAlwaysRedraw);
            this.groupBox5.Controls.Add(this.txtUpdateURL);
            this.groupBox5.Location = new System.Drawing.Point(13, 13);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(6, 0, 6, 3);
            this.groupBox5.Size = new System.Drawing.Size(494, 159);
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
            this.txtUpdateURL.Size = new System.Drawing.Size(476, 20);
            this.txtUpdateURL.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(303, 351);
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
            this.btnCancel.Location = new System.Drawing.Point(384, 351);
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
            this.btnApply.Location = new System.Drawing.Point(465, 351);
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
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 386);
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
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpdateCheckTime)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox listIcons;
        private System.Windows.Forms.Button btnAddIcon;
        private System.Windows.Forms.Button btnRemoveIcon;
        private System.Windows.Forms.Button btnRenderOptions;
        private System.Windows.Forms.GroupBox groupBox1;
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

    }
}


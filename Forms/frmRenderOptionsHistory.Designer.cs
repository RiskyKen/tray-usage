namespace RiskyKen.TrayUsage
{
    partial class frmRenderOptionsHistory
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
            this.btnClose = new System.Windows.Forms.Button();
            this.chkUseAlpha = new System.Windows.Forms.CheckBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.colorPer = new RiskyKen.TrayUsage.ColorPresetPicker();
            this.picFGColour = new System.Windows.Forms.PictureBox();
            this.picBGColour = new System.Windows.Forms.PictureBox();
            this.btnColourFG = new System.Windows.Forms.Button();
            this.btnColourBG = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxDirection = new System.Windows.Forms.ComboBox();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFGColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBGColour)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(177, 197);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkUseAlpha
            // 
            this.chkUseAlpha.AutoSize = true;
            this.chkUseAlpha.Location = new System.Drawing.Point(12, 160);
            this.chkUseAlpha.Name = "chkUseAlpha";
            this.chkUseAlpha.Size = new System.Drawing.Size(75, 17);
            this.chkUseAlpha.TabIndex = 16;
            this.chkUseAlpha.Text = "Use Alpha";
            this.chkUseAlpha.UseVisualStyleBackColor = true;
            this.chkUseAlpha.CheckedChanged += new System.EventHandler(this.chkUseAlpha_CheckedChanged);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.label1);
            this.GroupBox1.Controls.Add(this.colorPer);
            this.GroupBox1.Controls.Add(this.picFGColour);
            this.GroupBox1.Controls.Add(this.picBGColour);
            this.GroupBox1.Controls.Add(this.btnColourFG);
            this.GroupBox1.Controls.Add(this.btnColourBG);
            this.GroupBox1.Location = new System.Drawing.Point(12, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(240, 102);
            this.GroupBox1.TabIndex = 14;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Colour";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Preset Colours:";
            // 
            // colorPer
            // 
            this.colorPer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.colorPer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorPer.Location = new System.Drawing.Point(6, 70);
            this.colorPer.Name = "colorPer";
            this.colorPer.Size = new System.Drawing.Size(104, 21);
            this.colorPer.TabIndex = 13;
            this.colorPer.SelectedIndexChanged += new System.EventHandler(this.colorPer_SelectedIndexChanged);
            // 
            // picFGColour
            // 
            this.picFGColour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picFGColour.Location = new System.Drawing.Point(197, 19);
            this.picFGColour.Name = "picFGColour";
            this.picFGColour.Size = new System.Drawing.Size(23, 23);
            this.picFGColour.TabIndex = 10;
            this.picFGColour.TabStop = false;
            // 
            // picBGColour
            // 
            this.picBGColour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBGColour.Location = new System.Drawing.Point(87, 19);
            this.picBGColour.Name = "picBGColour";
            this.picBGColour.Size = new System.Drawing.Size(23, 23);
            this.picBGColour.TabIndex = 10;
            this.picBGColour.TabStop = false;
            // 
            // btnColourFG
            // 
            this.btnColourFG.Location = new System.Drawing.Point(116, 19);
            this.btnColourFG.Name = "btnColourFG";
            this.btnColourFG.Size = new System.Drawing.Size(75, 23);
            this.btnColourFG.TabIndex = 9;
            this.btnColourFG.Text = "Foreground";
            this.btnColourFG.UseVisualStyleBackColor = true;
            this.btnColourFG.Click += new System.EventHandler(this.btnColourFG_Click);
            // 
            // btnColourBG
            // 
            this.btnColourBG.Location = new System.Drawing.Point(6, 19);
            this.btnColourBG.Name = "btnColourBG";
            this.btnColourBG.Size = new System.Drawing.Size(75, 23);
            this.btnColourBG.TabIndex = 8;
            this.btnColourBG.Text = "Background";
            this.btnColourBG.UseVisualStyleBackColor = true;
            this.btnColourBG.Click += new System.EventHandler(this.btnColourBG_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Direction:";
            // 
            // comboBoxDirection
            // 
            this.comboBoxDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDirection.FormattingEnabled = true;
            this.comboBoxDirection.Items.AddRange(new object[] {
            "Up",
            "Down",
            "Left",
            "Right"});
            this.comboBoxDirection.Location = new System.Drawing.Point(12, 133);
            this.comboBoxDirection.Name = "comboBoxDirection";
            this.comboBoxDirection.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDirection.TabIndex = 17;
            this.comboBoxDirection.SelectedIndexChanged += new System.EventHandler(this.comboBoxDirection_SelectedIndexChanged);
            // 
            // frmRenderOptionsHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 232);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxDirection);
            this.Controls.Add(this.chkUseAlpha);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRenderOptionsHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Render Options - History";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFGColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBGColour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkUseAlpha;
        internal System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Label label1;
        private ColorPresetPicker colorPer;
        internal System.Windows.Forms.PictureBox picFGColour;
        internal System.Windows.Forms.PictureBox picBGColour;
        internal System.Windows.Forms.Button btnColourFG;
        internal System.Windows.Forms.Button btnColourBG;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxDirection;
    }
}
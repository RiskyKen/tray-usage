namespace RiskyKen.TrayUsage
{
    partial class frmRenderOptionsImage
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxBgImage = new System.Windows.Forms.TextBox();
            this.textBoxActiveImage = new System.Windows.Forms.TextBox();
            this.buttonBrowseBgImage = new System.Windows.Forms.Button();
            this.buttonBrowseActiveImage = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonBrowseFgImage = new System.Windows.Forms.Button();
            this.textBoxFgImage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxDirection = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownBottomPadding = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRightPadding = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLeftPadding = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTopPadding = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBottomPadding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRightPadding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLeftPadding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTopPadding)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(391, 323);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Background Image:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Active Image:";
            // 
            // textBoxBgImage
            // 
            this.textBoxBgImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBgImage.Location = new System.Drawing.Point(6, 36);
            this.textBoxBgImage.Name = "textBoxBgImage";
            this.textBoxBgImage.Size = new System.Drawing.Size(361, 20);
            this.textBoxBgImage.TabIndex = 1;
            this.textBoxBgImage.TextChanged += new System.EventHandler(this.textBoxBgImage_TextChanged);
            // 
            // textBoxActiveImage
            // 
            this.textBoxActiveImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxActiveImage.Location = new System.Drawing.Point(6, 93);
            this.textBoxActiveImage.Name = "textBoxActiveImage";
            this.textBoxActiveImage.Size = new System.Drawing.Size(361, 20);
            this.textBoxActiveImage.TabIndex = 4;
            this.textBoxActiveImage.TextChanged += new System.EventHandler(this.textBoxActiveImage_TextChanged);
            // 
            // buttonBrowseBgImage
            // 
            this.buttonBrowseBgImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseBgImage.Location = new System.Drawing.Point(373, 34);
            this.buttonBrowseBgImage.Name = "buttonBrowseBgImage";
            this.buttonBrowseBgImage.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseBgImage.TabIndex = 2;
            this.buttonBrowseBgImage.Text = "Browse...";
            this.buttonBrowseBgImage.UseVisualStyleBackColor = true;
            this.buttonBrowseBgImage.Click += new System.EventHandler(this.buttonBrowseBgImage_Click);
            // 
            // buttonBrowseActiveImage
            // 
            this.buttonBrowseActiveImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseActiveImage.Location = new System.Drawing.Point(373, 91);
            this.buttonBrowseActiveImage.Name = "buttonBrowseActiveImage";
            this.buttonBrowseActiveImage.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseActiveImage.TabIndex = 5;
            this.buttonBrowseActiveImage.Text = "Browse...";
            this.buttonBrowseActiveImage.UseVisualStyleBackColor = true;
            this.buttonBrowseActiveImage.Click += new System.EventHandler(this.buttonBrowseActiveImage_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Foreground Image:";
            // 
            // buttonBrowseFgImage
            // 
            this.buttonBrowseFgImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseFgImage.Location = new System.Drawing.Point(373, 149);
            this.buttonBrowseFgImage.Name = "buttonBrowseFgImage";
            this.buttonBrowseFgImage.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseFgImage.TabIndex = 8;
            this.buttonBrowseFgImage.Text = "Browse...";
            this.buttonBrowseFgImage.UseVisualStyleBackColor = true;
            this.buttonBrowseFgImage.Click += new System.EventHandler(this.buttonBrowseFgImage_Click);
            // 
            // textBoxFgImage
            // 
            this.textBoxFgImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFgImage.Location = new System.Drawing.Point(6, 151);
            this.textBoxFgImage.Name = "textBoxFgImage";
            this.textBoxFgImage.Size = new System.Drawing.Size(361, 20);
            this.textBoxFgImage.TabIndex = 7;
            this.textBoxFgImage.TextChanged += new System.EventHandler(this.textBoxFgImage_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Direction:";
            // 
            // comboBoxDirection
            // 
            this.comboBoxDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDirection.Enabled = false;
            this.comboBoxDirection.FormattingEnabled = true;
            this.comboBoxDirection.Items.AddRange(new object[] {
            "Up",
            "Down",
            "Left",
            "Right"});
            this.comboBoxDirection.Location = new System.Drawing.Point(202, 224);
            this.comboBoxDirection.Name = "comboBoxDirection";
            this.comboBoxDirection.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDirection.TabIndex = 16;
            this.comboBoxDirection.SelectedIndexChanged += new System.EventHandler(this.comboBoxDirection_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBoxBgImage);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxFgImage);
            this.groupBox1.Controls.Add(this.textBoxActiveImage);
            this.groupBox1.Controls.Add(this.buttonBrowseFgImage);
            this.groupBox1.Controls.Add(this.buttonBrowseBgImage);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.buttonBrowseActiveImage);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 187);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image Path";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.numericUpDownBottomPadding);
            this.groupBox2.Controls.Add(this.numericUpDownRightPadding);
            this.groupBox2.Controls.Add(this.numericUpDownLeftPadding);
            this.groupBox2.Controls.Add(this.numericUpDownTopPadding);
            this.groupBox2.Location = new System.Drawing.Point(12, 205);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(173, 136);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Padding";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Bottom";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Left";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(122, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Right";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Top";
            // 
            // numericUpDownBottomPadding
            // 
            this.numericUpDownBottomPadding.Location = new System.Drawing.Point(55, 88);
            this.numericUpDownBottomPadding.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownBottomPadding.Name = "numericUpDownBottomPadding";
            this.numericUpDownBottomPadding.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownBottomPadding.TabIndex = 0;
            this.numericUpDownBottomPadding.ValueChanged += new System.EventHandler(this.numericUpDownBottomPadding_ValueChanged);
            // 
            // numericUpDownRightPadding
            // 
            this.numericUpDownRightPadding.Location = new System.Drawing.Point(104, 62);
            this.numericUpDownRightPadding.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownRightPadding.Name = "numericUpDownRightPadding";
            this.numericUpDownRightPadding.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownRightPadding.TabIndex = 0;
            this.numericUpDownRightPadding.ValueChanged += new System.EventHandler(this.numericUpDownRightPadding_ValueChanged);
            // 
            // numericUpDownLeftPadding
            // 
            this.numericUpDownLeftPadding.Location = new System.Drawing.Point(6, 62);
            this.numericUpDownLeftPadding.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownLeftPadding.Name = "numericUpDownLeftPadding";
            this.numericUpDownLeftPadding.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownLeftPadding.TabIndex = 0;
            this.numericUpDownLeftPadding.ValueChanged += new System.EventHandler(this.numericUpDownLeftPadding_ValueChanged);
            // 
            // numericUpDownTopPadding
            // 
            this.numericUpDownTopPadding.Location = new System.Drawing.Point(55, 38);
            this.numericUpDownTopPadding.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownTopPadding.Name = "numericUpDownTopPadding";
            this.numericUpDownTopPadding.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownTopPadding.TabIndex = 0;
            this.numericUpDownTopPadding.ValueChanged += new System.EventHandler(this.numericUpDownTopPadding_ValueChanged);
            // 
            // frmRenderOptionsImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 358);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxDirection);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRenderOptionsImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Render Options - Image";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBottomPadding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRightPadding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLeftPadding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTopPadding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxBgImage;
        private System.Windows.Forms.TextBox textBoxActiveImage;
        private System.Windows.Forms.Button buttonBrowseBgImage;
        private System.Windows.Forms.Button buttonBrowseActiveImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonBrowseFgImage;
        private System.Windows.Forms.TextBox textBoxFgImage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxDirection;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownBottomPadding;
        private System.Windows.Forms.NumericUpDown numericUpDownRightPadding;
        private System.Windows.Forms.NumericUpDown numericUpDownLeftPadding;
        private System.Windows.Forms.NumericUpDown numericUpDownTopPadding;
    }
}
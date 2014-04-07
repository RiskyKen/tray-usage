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
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(406, 234);
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
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Background Image:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Active Image:";
            // 
            // textBoxBgImage
            // 
            this.textBoxBgImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBgImage.Location = new System.Drawing.Point(12, 26);
            this.textBoxBgImage.Name = "textBoxBgImage";
            this.textBoxBgImage.Size = new System.Drawing.Size(388, 20);
            this.textBoxBgImage.TabIndex = 1;
            this.textBoxBgImage.TextChanged += new System.EventHandler(this.textBoxBgImage_TextChanged);
            // 
            // textBoxActiveImage
            // 
            this.textBoxActiveImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxActiveImage.Location = new System.Drawing.Point(12, 83);
            this.textBoxActiveImage.Name = "textBoxActiveImage";
            this.textBoxActiveImage.Size = new System.Drawing.Size(388, 20);
            this.textBoxActiveImage.TabIndex = 4;
            this.textBoxActiveImage.TextChanged += new System.EventHandler(this.textBoxActiveImage_TextChanged);
            // 
            // buttonBrowseBgImage
            // 
            this.buttonBrowseBgImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseBgImage.Location = new System.Drawing.Point(406, 24);
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
            this.buttonBrowseActiveImage.Location = new System.Drawing.Point(406, 81);
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
            this.label3.Location = new System.Drawing.Point(12, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Foreground Image:";
            // 
            // buttonBrowseFgImage
            // 
            this.buttonBrowseFgImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseFgImage.Location = new System.Drawing.Point(406, 139);
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
            this.textBoxFgImage.Location = new System.Drawing.Point(12, 141);
            this.textBoxFgImage.Name = "textBoxFgImage";
            this.textBoxFgImage.Size = new System.Drawing.Size(388, 20);
            this.textBoxFgImage.TabIndex = 7;
            this.textBoxFgImage.TextChanged += new System.EventHandler(this.textBoxFgImage_TextChanged);
            // 
            // frmRenderOptionsImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 269);
            this.Controls.Add(this.textBoxFgImage);
            this.Controls.Add(this.buttonBrowseFgImage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonBrowseActiveImage);
            this.Controls.Add(this.buttonBrowseBgImage);
            this.Controls.Add(this.textBoxActiveImage);
            this.Controls.Add(this.textBoxBgImage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRenderOptionsImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Render Options - Image";
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
    }
}
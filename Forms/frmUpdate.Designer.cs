namespace RiskyKen.TrayUsage
{
    partial class frmUpdate
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
            this.proBar = new System.Windows.Forms.ProgressBar();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblLocalVer = new System.Windows.Forms.Label();
            this.lblRemoteVer = new System.Windows.Forms.Label();
            this.richTextBoxChangeLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // proBar
            // 
            this.proBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.proBar.Location = new System.Drawing.Point(0, 339);
            this.proBar.Name = "proBar";
            this.proBar.Size = new System.Drawing.Size(547, 23);
            this.proBar.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(379, 310);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(460, 310);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblLocalVer
            // 
            this.lblLocalVer.AutoSize = true;
            this.lblLocalVer.Location = new System.Drawing.Point(12, 15);
            this.lblLocalVer.Name = "lblLocalVer";
            this.lblLocalVer.Size = new System.Drawing.Size(73, 13);
            this.lblLocalVer.TabIndex = 4;
            this.lblLocalVer.Text = "Local version:";
            // 
            // lblRemoteVer
            // 
            this.lblRemoteVer.AutoSize = true;
            this.lblRemoteVer.Location = new System.Drawing.Point(12, 44);
            this.lblRemoteVer.Name = "lblRemoteVer";
            this.lblRemoteVer.Size = new System.Drawing.Size(84, 13);
            this.lblRemoteVer.TabIndex = 5;
            this.lblRemoteVer.Text = "Remote version:";
            // 
            // richTextBoxChangeLog
            // 
            this.richTextBoxChangeLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxChangeLog.Location = new System.Drawing.Point(12, 60);
            this.richTextBoxChangeLog.Name = "richTextBoxChangeLog";
            this.richTextBoxChangeLog.ReadOnly = true;
            this.richTextBoxChangeLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBoxChangeLog.Size = new System.Drawing.Size(523, 244);
            this.richTextBoxChangeLog.TabIndex = 6;
            this.richTextBoxChangeLog.Text = "";
            // 
            // frmUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 362);
            this.Controls.Add(this.richTextBoxChangeLog);
            this.Controls.Add(this.lblRemoteVer);
            this.Controls.Add(this.lblLocalVer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.proBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateForm";
            this.Load += new System.EventHandler(this.frmUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar proBar;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblLocalVer;
        private System.Windows.Forms.Label lblRemoteVer;
        private System.Windows.Forms.RichTextBox richTextBoxChangeLog;
    }
}
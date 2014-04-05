#region "License"
//Tray Usage - Shows resource usage icons in the system tray.
//Copyright (C) 2013 RiskyKen

//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with this program.  If not, see [http://www.gnu.org/licenses/].
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace RiskyKen.TrayUsage
{
    public partial class frmUpdate : Form
    {
        private String updateFileListUrl;

        public frmUpdate()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.tray;
            lblLocalVer.Text = "Local version: " + Application.ProductVersion;
        }

        private void CheckRemoteVersion()
        {
            lblRemoteVer.Text = "Remote version: Checking...";
            proBar.Style = ProgressBarStyle.Marquee;
            Program.updateHelper.updater.UpdateCheckFinished += UpdateCheckReturn;
            Program.updateHelper.updater.CheckForUpdatesAsync(Globals.UpdateUrlMain);
        }

        //Fires when an update check has finished.
        private void UpdateCheckReturn(Updater.UpdateCheckResult result)
        {
            if (this.InvokeRequired)
            {
                Debug.WriteLine("Invoking update check result on update form.");
                Updater.UpdateCheckFinishedHandler updateFormInvoker = new Updater.UpdateCheckFinishedHandler(UpdateCheckReturn);
                this.Invoke(updateFormInvoker, result);
            }
            Program.updateHelper.updater.UpdateCheckFinished -= UpdateCheckReturn;
            proBar.Style = ProgressBarStyle.Continuous;
            lblRemoteVer.Text = "Remote version: " + result.LatestVersion.ToString();

            DownloadChangeLog(result.ChangeLogUrl);

            if (result.UpdateAvailable)
            {
                btnUpdate.Enabled = true;
                updateFileListUrl = result.UpdateFileListUrl;
            }
        }

        private void DownloadChangeLog(string fileUrl)
        {
            textBoxChangeLog.Text = "Downloading...";
            Program.updateHelper.updater.DownloadChangeLogFinished += new Updater.DownloadChangeLogFinishedHandler(DownloadChangeLogFinished);
            Program.updateHelper.updater.DownloadChangeLogAsync(fileUrl);
        }

        private void DownloadChangeLogFinished(Updater.DownloadChangeLogResult result)
        {
            if (this.InvokeRequired)
            {
                Debug.WriteLine("Invoking download change log on update form.");
                Updater.DownloadChangeLogFinishedHandler updateFormInvoker = new Updater.DownloadChangeLogFinishedHandler(DownloadChangeLogFinished);
                this.Invoke(updateFormInvoker, result);
            }
            Program.updateHelper.updater.DownloadChangeLogFinished -= DownloadChangeLogFinished;
            if (result.Success)
            {
                textBoxChangeLog.Text = result.LogText;
            }
        }

        //Start downloading an update
        private void DownloadUpdate()
        {
            Program.updateHelper.updater.DownloadUpdateFinished += DownloadUpdateReturn;
            Program.updateHelper.updater.DownloadUpdateAsync(updateFileListUrl);
        }

        //Fired when the update download is finished.
        private void DownloadUpdateReturn(Updater.DownloadUpdateResult result)
        {
            if (this.InvokeRequired)
            {
                Debug.WriteLine("Invoking download update result on update form.");
                Updater.DownloadUpdateFinishedHandler updateFormInvoker = new Updater.DownloadUpdateFinishedHandler(DownloadUpdateReturn);
                this.Invoke(updateFormInvoker, result);
            }
            Program.updateHelper.updater.DownloadUpdateFinished -= DownloadUpdateReturn;
            proBar.Style = ProgressBarStyle.Continuous;
            btnUpdate.Enabled = true;
            if (result.Success)
            {
                Program.updateRunFileList = result.RunFiles;
                Program.updateRestart = true;
                Program.updateLoopRunning = false; }
            else
            {
                MessageBox.Show(result.Message, Application.ProductName);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DownloadUpdate();
            btnUpdate.Enabled = false;
            proBar.Style = ProgressBarStyle.Marquee;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmUpdate_Load(object sender, EventArgs e)
        {
            this.Show();
            CheckRemoteVersion();
        }
    }
}

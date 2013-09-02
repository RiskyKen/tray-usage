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
using Microsoft.Win32;
using System.Threading;

namespace TrayUsage
{
    public partial class frmOptions : Form
    {

        private TrayIcon SelectedIcon = null;

        public frmOptions()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.tray;
            LoadIconTab();
            tabControl1.SelectedTab = tabPage2;
            LoadGeneralSettings();
            LoadAdvancedSettings();
        }

        public Boolean GetRunningOnStartup()
        {
            if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", Application.ProductName, null) == null)
            { return false; }
            return true;
        }

        public void SetRunningOnStartup(Boolean RunOnStartup)
        {
            if (!RunOnStartup)
            {
                if (GetRunningOnStartup())
                {
                    string keyName = @"Software\Microsoft\Windows\CurrentVersion\Run";
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName, true))
                    {
                        if (key != null)
                        {
                            key.DeleteValue(Application.ProductName);
                        }
                    }
                }
            }
            else
            {
                if (!GetRunningOnStartup())
                {
                    Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", Application.ProductName, Application.ExecutablePath);
                }
            }
        }

        private void LoadGeneralSettings()
        {
            chkRunOnStartup.Checked = GetRunningOnStartup();
            chkFullScreenSleep.Checked = Globals.FullscreenSleep;
            chkMissingIconFix.Checked = Globals.MissingIconFix;

            numUpdateCheckTime.Value = (Globals.UpdateCheckTime / 1000 / 60);
            chkAutoUpdate.Checked = Globals.AutoUpdate;
        }

        private void ApplyGeneralSettings()
        {
            SetRunningOnStartup(chkRunOnStartup.Checked);
            Globals.FullscreenSleep = chkFullScreenSleep.Checked;
            Globals.MissingIconFix = chkMissingIconFix.Checked;

            Globals.UpdateCheckTime = (Int32)numUpdateCheckTime.Value * 1000 * 60;
            Globals.AutoUpdate = chkAutoUpdate.Checked;
        }

        private void LoadAdvancedSettings()
        {
            chkAlwaysRedraw.Checked = Globals.AlwaysRedrawIcons;
            txtUpdateURL.Text = Globals.UpdateUrlMain;
            comboThreadPriority.SelectedIndex = (Int32)Globals.UpdateThreadPriority;
        }

        private void ApplyAdvancedSettings()
        {
            Globals.AlwaysRedrawIcons = chkAlwaysRedraw.Checked;
            Globals.UpdateUrlMain = txtUpdateURL.Text;
            Globals.UpdateThreadPriority =  (ThreadPriority)comboThreadPriority.SelectedIndex;
        }

        private void ApplySettings()
        {
            ApplyGeneralSettings();
            ApplyAdvancedSettings();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            ApplySettings();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ApplySettings();
            this.DialogResult = DialogResult.OK;
        }

    }
}

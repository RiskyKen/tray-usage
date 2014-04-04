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
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;

namespace RiskyKen.TrayUsage
{
    public class DummyIcon
    {
        //The name of this icon.
        private string IconName = null;

        //The notify icon that is seen in the system tray.
        private NotifyIcon TrayIcon = null;

        //Constructor
        public DummyIcon()
        {
            IconName = "Tray Usage - No Icons Active!";
            MakeTrayIcon();
        }

        private void MakeTrayIcon()
        {
            TrayIcon = new NotifyIcon();
            TrayIcon.ContextMenu = IconManager.TrayMenu.Menu;
            TrayIcon.Text = IconName;
            TrayIcon.Icon = Properties.Resources.tray;
            TrayIcon.Visible = false;
            TrayIcon.DoubleClick += TrayIcon_DoubleClick;
        }

        public void ShowBalloonPopup(String title, String text, ToolTipIcon icon)
        {
            TrayIcon.ShowBalloonTip(2000, title, text, icon);
        }

        public bool IconVisible
        {
            get { return TrayIcon.Visible; }
            set { TrayIcon.Visible = value; }
        }

        private void TrayIcon_DoubleClick(object sender, System.EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                IconManager.TrayMenu.TrayIcon_DoubleClick();
            }
        }

        public void Dispose()
        {
            TrayIcon.DoubleClick -= TrayIcon_DoubleClick;
            TrayIcon.Visible = false;
            TrayIcon.Dispose();
        }
    }
}
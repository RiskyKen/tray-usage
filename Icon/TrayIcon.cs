﻿#region "License"
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

namespace TrayUsage
{
    public partial class TrayIcon
    {
        //The name of this icon.
        public string pIconName = null;

        //The notify icon that is seen in the system tray.
        private NotifyIcon trayIcon = null;

        //The target data class.
        public DataLink[] TargetData = null;

        //The renderer that this icon will use.
        public clsRenderer Renderer = null;

        //Constructor
        public TrayIcon(string aIconName, DataLink[] aTargetData)
        {
            pIconName = aIconName;
            TargetData = aTargetData;
            Renderer = new clsRendererBasic();
            MakeTrayIcon();
        }

        private void MakeTrayIcon()
        {
            trayIcon = new NotifyIcon();
            trayIcon.ContextMenu = IconManager.TrayMenu.Menu;
            UpdateName();
            //TrayIcon.Text = IconName;
            RenderIcon(false);
            trayIcon.Visible = true;
            trayIcon.DoubleClick += TrayIcon_DoubleClick;
        }

        public void RenderIcon(Boolean sleeping)
        {
            Int32[] iconValues = Renderer.ConvertToIconValues(TargetData);
            if (Renderer.NeedRedraw(iconValues, sleeping))
            {
                if (!Renderer.isSleeping)
                { trayIcon.Icon = Renderer.RenderIcon(iconValues, sleeping); }
                else
                {
                    if (!sleeping)
                    { trayIcon.Icon = Renderer.RenderIcon(iconValues, sleeping); }
                }
            }
        }

        public void Hide()
        { trayIcon.Visible = false; }

        public void Show()
        { trayIcon.Visible = true; }

        public void Reload()
        {
            Renderer.Reload();
        }

        public void ShowBalloonPopup(String title, String text, ToolTipIcon icon)
        {
            trayIcon.ShowBalloonTip(2000, title, text, icon);
        }

        public void AddDataSource(DataLink aDataLink)
        {
            if (TargetData == null)
            {
                TargetData = new DataLink[1];
            }
            else
            {
                Array.Resize(ref TargetData, TargetData.GetUpperBound(0) + 2);
            }
            TargetData[TargetData.GetUpperBound(0)] = aDataLink;
            UpdateName();
            Renderer.ForceIconRedraw();
        }

        public void RemoveDataSource(Int32 aIndex)
        {
            if (TargetData == null) { return; }
            if (TargetData.GetUpperBound(0) == 0)
            {
                TargetData = null;
                return;
            }

            DataLink[] tempLink = null;
            tempLink = new DataLink[TargetData.GetUpperBound(0)];

            Int32 j = 0;

            for (Int32 i = 0; i <= TargetData.GetUpperBound(0); i++)
            {
                if (i != aIndex)
                {
                    tempLink[j] = TargetData[i];
                    j++;
                }
            }
            TargetData = tempLink;
            UpdateName();
            Renderer.ForceIconRedraw();
        }

        public void ChangeRenderer(string NewRenderer)
        {
            switch (NewRenderer)
            {
                case "Basic":
                    Renderer.Dispose();
                    Renderer = new clsRendererBasic();
                    break;

                case "Image":
                    Renderer.Dispose();
                    Renderer = new clsRendererImage();
                    break;
            }
        }

        public string IconName
        {
            get { return pIconName; }
            set {
                pIconName = value;
                    UpdateName(); 
                }
        }

        private void UpdateName()
        {
            if (TargetData == null)
            { trayIcon.Text = IconName + " - No Data Link"; }
            else
            { trayIcon.Text = IconName; }
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
            trayIcon.DoubleClick -= TrayIcon_DoubleClick;
            trayIcon.Visible = false;
            trayIcon.Dispose();
        }


    }
}
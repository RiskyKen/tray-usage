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
using System.Drawing;
using System.Xml;
using System.Diagnostics;
using RiskyKen.TrayUsage.Icons;

namespace RiskyKen.TrayUsage
{
    //Temp class, will handle loading and unloading of tray icons.
    public static class IconManager
    {
        public static IconMenu TrayMenu = null;

        public static TrayIcon[] trayIcons = null;

        private static Control InvokeControl = null;

        //Dummy icon that is shown if no other icons are active.
        private static DummyIcon dummyIcon = null;

        //Has the missing icon fix been run?
        private static Boolean _missingIconFixRun = false;

        //Lock object for the icons.
        public static object _iconLock;

        //Constructor
        public static void Init()
        {
            TrayMenu = new IconMenu();
            InvokeControl = new Control();
            InvokeControl.CreateControl();
            _iconLock = new object();
        }

        public static void LoadIcons()
        {
            dummyIcon = new DummyIcon();
            DataLink tempLink;
            tempLink.DataIndex = 0;
            CheckDummyIconVisibliy();
        }

        public static void LoadIcons(XmlReader r)
        {
            while (r.Read())
            {
                switch (r.NodeType)
                {
                    case XmlNodeType.Element:
                        if (r.Name == "Icon")
                        { AddIcon(r); }
                        break;
                    case XmlNodeType.EndElement:
                        if (r.Name == "TrayIcons")
                        { return; }
                        break;
                }
            }
        }

        public static void MakeDefaultIcons()
        {
            PresetIconHelper.AddPersetIcon("CPU");
            PresetIconHelper.AddPersetIcon("RAM");
            PresetIconHelper.AddPersetIcon("Network");
        }

        //Unload the tray manager and all icons.
        public static void Dispose()
        {
            if (trayIcons != null)
            {
                for (Int32 i = 0; i <= trayIcons.GetUpperBound(0); i++)
                {
                    trayIcons[i].Dispose();
                    trayIcons[i] = null;
                }
            }
            dummyIcon.Dispose();
            dummyIcon = null;
            TrayMenu.Dispose();
            TrayMenu = null;
            InvokeControl.Dispose();
            InvokeControl = null;
        }

        //Add an icon into the TrayIcons array.
        public static void AddIcon(string aIconName, String RolloverText, DataLink[] aTargetData, Color BackgroundColor, Color ForegroundColor)
        {
            lock (_iconLock)
            {
                if (InvokeControl.InvokeRequired)
                {
                    MessageBox.Show("Failed to invoke when adding icon.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw new Exception("Failed to invoke when adding icon.");
                }
                if (trayIcons == null) { trayIcons = new TrayIcon[1]; }
                else
                {
                    Array.Resize(ref trayIcons, trayIcons.GetUpperBound(0) + 2);
                }
                trayIcons[trayIcons.GetUpperBound(0)] = new TrayIcon(aIconName, RolloverText, aTargetData, BackgroundColor, ForegroundColor);
                CheckDummyIconVisibliy();
                ReshowIcons();
            }
        }

        public static void AddIcon(XmlReader r)
        {
            lock (_iconLock)
            {
                if (InvokeControl.InvokeRequired)
                {
                    MessageBox.Show("Failed to invoke when adding icon.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw new Exception("Failed to invoke when adding icon.");
                }
                if (trayIcons == null) { trayIcons = new TrayIcon[1]; }
                else
                {
                    Array.Resize(ref trayIcons, trayIcons.GetUpperBound(0) + 2);
                }
                trayIcons[trayIcons.GetUpperBound(0)] = new TrayIcon(r);
                CheckDummyIconVisibliy();
            }
        }


        //Remove an icon from the TrayIcons array.
        public static void RemoveIcon(Int32 aIconIndex)
        {
            lock (_iconLock)
            {
                if (trayIcons == null) { return; }

                if (trayIcons.GetUpperBound(0) == 0)
                {
                    trayIcons[0].Dispose();
                    trayIcons = null;
                }
                else
                {
                    TrayIcon[] NewIcons = new TrayIcon[trayIcons.GetUpperBound(0)];
                    Int32 OffsetCount = 0;
                    for (Int32 i = 0; i <= trayIcons.GetUpperBound(0); i++)
                    {
                        if (i != aIconIndex)
                        {
                            NewIcons[OffsetCount] = trayIcons[i];
                            OffsetCount++;
                        }
                        else
                        {
                            trayIcons[i].Dispose();
                            trayIcons[i] = null;
                        }
                    }
                    trayIcons = NewIcons;
                }
                CheckDummyIconVisibliy();
                ReshowIcons();
            }
        }

        //Move an icon up.
        public static void MoveIconUp(Int32 index)
        {
            lock (_iconLock)
            {
                TrayIcon tempIcon = trayIcons[index];
                trayIcons[index] = trayIcons[index - 1];
                trayIcons[index - 1] = tempIcon;
                ReshowIcons();
            }
        }

        //Move an icon down.
        public static void MoveIconDown(Int32 index)
        {
            lock (_iconLock)
            {
                TrayIcon tempIcon = trayIcons[index];
                trayIcons[index] = trayIcons[index + 1];
                trayIcons[index + 1] = tempIcon;
                ReshowIcons();
            }
        }

        //Shows all the icons.
        public static void HideAllIcons()
        {
            if (trayIcons == null) { return; }
            for (Int32 i = 0; i <= trayIcons.GetUpperBound(0); i++)
            { trayIcons[i].Hide(); }
        }

        //Hides all the icons.
        public static void ShowAllIcons()
        {
            if (trayIcons == null) { return; }
            for (Int32 i = trayIcons.GetUpperBound(0); i >= 0; i--)
            { trayIcons[i].Show(); }
        }

        //Hides then reshows all icons.
        public static void ReshowIcons()
        {
            HideAllIcons();
            ShowAllIcons();
        }

        //Reloads the icons.
        public static void ReloadIcons()
        {
            if (trayIcons == null) { return; }
            for (Int32 i = 0; i <= trayIcons.GetUpperBound(0); i++)
            { trayIcons[i].Reload(); }
        }

        private delegate void ShowBalloonPopupHandler(String title, String text, ToolTipIcon icon);

        //Shows a balloon popup.
        public static void ShowBalloonPopup(String title, String text, ToolTipIcon icon)
        {
            if (InvokeControl.InvokeRequired)
            {
                Debug.WriteLine("Invoking ShowBalloonPopup:" + title + " " + text);
                InvokeControl.Invoke(new ShowBalloonPopupHandler(ShowBalloonPopup), new object[] { title, text, icon});
            }
            if (trayIcons == null)
            {
                dummyIcon.ShowBalloonPopup(title, text, icon);
            }
            else
            {
                trayIcons[0].ShowBalloonPopup(title, text, icon);
            }
        }

        //Check if an icon exists by name.
        public static bool IconExists(string aIconName)
        {
            if (trayIcons == null) { return false; }
            for (Int32 i = 0; i <= trayIcons.GetUpperBound(0); i++)
            {
                if (trayIcons[i].IconName == aIconName) { return true; }
            }
            return false;
        }

        //Render the icons.
        public static void UpdateIcons(Boolean sleeping)
        {
            lock (_iconLock)
            {
                if (trayIcons == null) { return; }
                if (Globals.MissingIconFix)
                {
                    if (!_missingIconFixRun) { MissingIconFixCheck(); }
                }
                for (Int32 i = 0; i <= trayIcons.GetUpperBound(0); i++)
                {
                    trayIcons[i].RenderIcon(sleeping);
                }
            }
        }

        //Checks if the fix for missing icons needs to be run.
        private static void MissingIconFixCheck()
        {
            if (Program.startTick + Globals.missingIconFixTime <= Environment.TickCount)
            {
                Debug.WriteLine("Running missing icon fix.");
                _missingIconFixRun = true;
                ReshowIcons();
            }
        }

        private static void CheckDummyIconVisibliy()
        {
            if (trayIcons == null) { dummyIcon.IconVisible = true; }
            else { dummyIcon.IconVisible = false; }
        }

        public static void SaveIcons(XmlWriter aXmlW)
        {
            if (trayIcons == null) { return; }
            aXmlW.WriteStartElement("TrayIcons");
            for (Int32 i = 0; i <= trayIcons.GetUpperBound(0); i++)
            {
                trayIcons[i].SaveIconXml(aXmlW);
            }
            aXmlW.WriteEndElement();
        }
    }
}
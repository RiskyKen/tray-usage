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
using System.Threading;
using System.Xml;
using System.Drawing;
using System.Drawing.Imaging;

namespace TrayUsage
{
    class Globals
    {
        //The url that is used to look for updates.
        //"https://dl.dropbox.com/u/9733425/app_update/tray_usage/update.txt"
        public static string UpdateUrlMain = "https://dl.dropbox.com/u/9733425/app_update/tray_usage/update.txt";

        //Backup url that is used to look for updates, if the main one is down.
        //"http://dl.dropbox.com/u/9733425/app_update/tray_usage/update.txt"
        public static string UpdateUrlAlt = "";

        //Settings file path.
        public static readonly string SettingsFilePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\" + Application.ProductName + @"\settings.xml";

        //Temp location for files downloaded by updater.
        public static readonly string FileDownloadPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\" + Application.ProductName + @"\download";
        
        //Update rate in ms of tray icons.
        public static Int32 IconUpdateRate = 250;

        //Check for updates every x ms. Default 4 hours.
        public static Int32 UpdateCheckTime = 14400000;

        //The colour bit depth that the tray icons use.
        protected static PixelFormat colorBitDepth = PixelFormat.Format24bppRgb;

        //Auto update?
        public static Boolean AutoUpdate = true;

        //Missing icon fix for windows vista/7?
        public static Boolean MissingIconFix = true;

        //The thread priority of the main update loop.
        protected static ThreadPriority updateThreadPriority = ThreadPriority.Lowest;

        //Should the program sleep when a fullscreen application is running?
        public static Boolean FullscreenSleep = true;

        //DEBUG Always redraw icons.
        public static Boolean AlwaysRedrawIcons = false;

        //Perset colors.
        public static ColorPreset[] colorPresets = null;

        //How long the program will sleep for before checking if it needs to wake in ms. Default 2 secs.
        public static Int32 SleepTime = 1000 * 2;

        //How long untel icons are reshown for the missing icon fix. Default 6 secs.
        public static Int32 missingIconFixTime = 1000 * 6;

        public static ThreadPriority UpdateThreadPriority
        {
            get { return updateThreadPriority; }
            set
            {
                updateThreadPriority = value;
                Program.updateThread.Priority = value;
            }
        }

        public static PixelFormat ColorBitDepth
        {
            get { return colorBitDepth; }
            set
            {
                if (colorBitDepth != value)
                {
                    colorBitDepth = value;
                    IconManager.ReloadIcons();
                }
            }
        }

        public static void LoadGlobalSettings(XmlReader aR, String aName)
        {
            while (aR.Read())
            {
                switch (aR.NodeType)
                {
                    case XmlNodeType.Text:
                        LoadXmlElement(aName, aR.Value);
                        break;
                    case XmlNodeType.EndElement:
                        if (aR.Name == aName) { return; }
                        break;
                }
            }
        }

        private static void LoadXmlElement(string aName, string aValue)
        {
            switch (aName)
            {
                case "UpdateRate":
                    IconUpdateRate = Int32.Parse(aValue);
                    break;
                case "FullscreenSleep":
                    FullscreenSleep = Boolean.Parse(aValue);
                    break;
                case "AutoUpdate":
                    AutoUpdate = Boolean.Parse(aValue);
                    break;
                case "UpdateCheckTime":
                    UpdateCheckTime = Int32.Parse(aValue);
                    break;
                case "MissingIconFix":
                    MissingIconFix = Boolean.Parse(aValue);
                    break;
                case "ThreadPriority":
                    updateThreadPriority = (ThreadPriority)Int32.Parse(aValue);
                    break;
                case "ColorBitDepth":
                    colorBitDepth = (PixelFormat)Int32.Parse(aValue);
                    break;
                case "AlwaysRedrawIcons":
                    AlwaysRedrawIcons = Boolean.Parse(aValue);
                    break;
            }
        }

        public static void SaveGlobalSettings(XmlWriter w)
        {
            w.WriteStartElement("General");
            w.WriteElementString("UpdateRate", IconUpdateRate.ToString());
            w.WriteElementString("FullscreenSleep", FullscreenSleep.ToString());
            w.WriteElementString("AutoUpdate", AutoUpdate.ToString());
            w.WriteElementString("UpdateCheckTime", UpdateCheckTime.ToString());
            w.WriteElementString("MissingIconFix", MissingIconFix.ToString());
            w.WriteElementString("ThreadPriority", ((Int32)UpdateThreadPriority).ToString());
            w.WriteElementString("ColorBitDepth", ((Int32)ColorBitDepth).ToString());
            w.WriteElementString("AlwaysRedrawIcons", AlwaysRedrawIcons.ToString());
            w.WriteEndElement();
        }

        public static void LoadPresetColors()
        {
            AddColorPreset(Color.FromArgb(0, 32, 0), Color.FromArgb(0, 255, 0));
            AddColorPreset(Color.FromArgb(0, 0, 32), Color.FromArgb(0, 0, 255));
            AddColorPreset(Color.FromArgb(64, 0, 0), Color.FromArgb(255, 0, 0));

            AddColorPreset(Color.FromArgb(64, 64, 0), Color.FromArgb(255, 255, 0));
            AddColorPreset(Color.FromArgb(0, 64, 64), Color.FromArgb(0, 255, 255));
            AddColorPreset(Color.FromArgb(64, 0, 64), Color.FromArgb(255, 0, 255));

            AddColorPreset(Color.FromArgb(0, 0, 0), Color.FromArgb(255, 255, 255));
            AddColorPreset(Color.FromArgb(64, 64, 64), Color.FromArgb(192, 192, 192));

            AddColorPreset(Color.FromArgb(128, 64, 0), Color.FromArgb(255, 128, 0));
            AddColorPreset(Color.FromArgb(0, 128, 64), Color.FromArgb(0, 255, 128));
            AddColorPreset(Color.FromArgb(64, 0, 128), Color.FromArgb(128, 0, 255));

            AddColorPreset(Color.FromArgb(0, 0, 64), Color.FromArgb(65, 105, 225));
            AddColorPreset(Color.FromArgb(0, 64, 0), Color.FromArgb(105, 225, 65));
            AddColorPreset(Color.FromArgb(64, 0, 0), Color.FromArgb(225, 65, 105));
        }

        private static void AddColorPreset(Color bgColor,Color fgColor)
        {
            ColorPreset perset = new ColorPreset(bgColor, fgColor);
            if (colorPresets == null)
            { colorPresets = new ColorPreset[1]; }
            else
            {
                Array.Resize(ref colorPresets, colorPresets.GetUpperBound(0) + 2); 
            }
            colorPresets[colorPresets.GetUpperBound(0)] = perset;
        }
    }

    public struct DataLink
    {
        public Data DataClassRef;
        public Int32 DataIndex;
    }

    public class ColorPreset
    {
        public ColorPreset(Color bgColor,Color fgColor)
        { ForegroundColor = fgColor; BackgroundColor = bgColor; }

        public Color ForegroundColor;
        public Color BackgroundColor;
    }
}

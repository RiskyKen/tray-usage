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
using System.Xml;
using System.Windows.Forms;
using System.IO;

namespace TrayUsage
{
    public class Settings
    {
        //The array of settings.
        private Setting[] settings = null;

        //The last path that was use to save/load the settings.
        private string pFilePath = null;

        public Settings()
        {
            //SettingsXml[0].
        }

        public Settings(string aFileName)
        {
            Load(aFileName);
        }

        public void Dispose()
        {
        }

        //Put a setting into the settings array.
        public void Put(string aKey, string aValue, string aSection)
        {
            Setting tempSetting = new Setting();
            tempSetting.Value = aValue;
            tempSetting.Key = aKey;
            tempSetting.Section = aSection;

            if (settings == null)
            {
                settings = new Setting[1];
                settings[0] = tempSetting;
            }
            else
            {
                for (Int32 i = 0; i <= settings.GetUpperBound(0); i++)
                {
                    if (settings[i].Section == aSection)
                    {
                        if (settings[i].Key == aKey)
                        {
                            settings[i] = tempSetting;
                            return;
                        }
                    }
                }
                //The setting was not found. Resize the array and add it.
                Array.Resize(ref settings, settings.GetUpperBound(0) + 2);
                settings[settings.GetUpperBound(0)] = tempSetting;
            }
        }

        /// <summary>
        /// Get a setting from the settings array.
        /// </summary>
        /// <param name="aKey">Key of the setting to return.</param>
        /// <param name="aSection">Section of the setting to return.</param>
        /// <returns>String with the setting. Null if not found.</returns>
        public string Get(string aKey, string aSection)
        {
            if (settings == null) { return null; }
            for (Int32 i = 0; i <= settings.GetUpperBound(0); i++)
            {
                if (settings[i].Key == aKey)
                {
                    if (settings[i].Section == aSection)
                    {
                        return settings[i].Value;
                    }
                }
            }
            //No setting was found return null.
            return null;
        }

        /// <summary>
        /// Rename a section.
        /// </summary>
        /// <param name="aOldName">The old section name that has to be replaced.</param>
        /// <param name="aNewName">The new section name to replace with.</param>
        public void RenameSection(string aOldName, string aNewName)
        {
            if (settings == null) {return;}
            else
            {
                for (Int32 i = 0; i <= settings.GetUpperBound(0); i++)
                {
                    if (settings[i].Section == aOldName)
                    {
                        settings[i].Section = aNewName;
                    }
                }
            }
        }

        /// <summary>
        /// Load the settings from a file.
        /// </summary>
        /// <param name="aPath">The path to load setting from.</param>
        public void Load(string aPath)
        {
            if (!System.IO.File.Exists(aPath)) { throw new Exception("Settings file not found."); }
            XmlReader r = new XmlTextReader(aPath);
            while (r.Read())
            {
                switch (r.NodeType)
                {
                    case XmlNodeType.Element:
                        if (r.Name == "TrayUsageSettings")
                        { LoadTrayUsageSettings(r); }
                        break;
                }

            }
            r.Close();
        }

        private void LoadTrayUsageSettings(XmlReader r)
        {
            while (r.Read())
            {
                switch (r.NodeType)
                {
                    case XmlNodeType.Element:
                        if (r.Name == "General")
                        { LoadGeneralSettings(r); }
                        if (r.Name == "TrayIcons")
                        { IconManager.LoadIcons(r); }
                        break;
                    case XmlNodeType.EndElement:
                        if (r.Name == "TrayUsageSettings")
                        { return; }
                        break;
                }
            }
        }

        private void LoadGeneralSettings(XmlReader r)
        {
            while (r.Read())
            {
                switch (r.NodeType)
                {
                    case XmlNodeType.Element:
                        Globals.LoadGlobalSettings(r, r.Name);
                        break;
                    case XmlNodeType.EndElement:
                        if (r.Name == "General")
                        { return; }
                        break;
                }
            }
        }

        /// <summary>
        /// Save the settings to a file using the last file path.
        /// </summary>
        public void Save()
        {
            if (pFilePath != null)
            {
                throw new Exception("File path was not set.");
            }
            Save(pFilePath);
        }

        /// <summary>
        /// Save the settings to a file.
        /// </summary>
        /// <param name="aPath">The path to save setting to.</param>
        public void Save(string aPath)
        {
            XmlWriterSettings wSettings = new XmlWriterSettings();
            wSettings.NewLineOnAttributes = true;
            wSettings.Indent = true;
            wSettings.Encoding = Encoding.UTF8;

            String dirPath = new FileInfo(Globals.SettingsFilePath).Directory.FullName;

            if (!Directory.Exists(dirPath)) { Directory.CreateDirectory(dirPath); }
            XmlWriter w = XmlTextWriter.Create(Globals.SettingsFilePath, wSettings);
            w.WriteStartDocument();
            w.WriteStartElement("TrayUsageSettings");
            SaveGeneralSettings(w);
            SaveTrayIcons(w);
            w.WriteEndElement();
            w.WriteEndDocument();
            w.Flush();
            w.Close();
        }

        private void SaveGeneralSettings(XmlWriter w)
        {
            Globals.SaveGlobalSettings(w);
        }

        private void SaveTrayIcons(XmlWriter w)
        {
            IconManager.SaveIcons(w);
        }

        public struct Setting
        {
            public string Key;
            public string Value;
            public string Section;
        }
    }
}

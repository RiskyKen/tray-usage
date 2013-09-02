using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.Windows.Forms;

namespace TrayUsage
{
    public class clsSettingsNew
    {
        //The array of settings.
        private Setting[] Settings = null;

        //The last path that was use to save/load the settings.
        private string pFilePath = null;

        private XmlNodeList SettingsXml = null;

        public clsSettingsNew()
        {
            //SettingsXml[0].
        }

        public clsSettingsNew(string aFileName)
        {
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

            if (Settings == null)
            {
                Settings = new Setting[1];
                Settings[0] = tempSetting;
            }
            else
            {
                for (Int32 i = 0; i <= Settings.GetUpperBound(0); i++)
                {
                    if (Settings[i].Section == aSection)
                    {
                        if (Settings[i].Key == aKey)
                        {
                            Settings[i] = tempSetting;
                            return;
                        }
                    }
                }
                //The setting was not found. Resize the array and add it.
                Array.Resize(ref Settings, Settings.GetUpperBound(0) + 2);
                Settings[Settings.GetUpperBound(0)] = tempSetting;
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
            if (Settings == null) { return null; }
            for (Int32 i = 0; i <= Settings.GetUpperBound(0); i++)
            {
                if (Settings[i].Key == aKey)
                {
                    if (Settings[i].Section == aSection)
                    {
                        return Settings[i].Value;
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
            if (Settings == null) {return;}
            else
            {
                for (Int32 i = 0; i <= Settings.GetUpperBound(0); i++)
                {
                    if (Settings[i].Section == aOldName)
                    {
                        Settings[i].Section = aNewName;
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
            XmlDocument rr = new XmlDocument();
            rr.LoadXml(Application.StartupPath + "/settings.xml");
            SettingsXml = rr.SelectNodes("");
            //XmlTextReader r = new XmlTextReader(Application.StartupPath + "/settings.xml");
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

            XmlWriter w = XmlTextWriter.Create(Globals.SettinsFilePath, wSettings);
            w.WriteStartDocument();
            w.WriteStartElement("TrayUsageSettings");
            WriteGeneralSettings(w);

            w.WriteStartElement("Icons");
            WriteTrayIcon(w);
            WriteTrayIcon(w);
            w.WriteEndElement();
            
            w.WriteEndElement();
            w.WriteEndDocument();
            w.Flush();
            w.Close();
        }

        private void WriteGeneralSettings(XmlWriter w)
        {
            w.WriteStartElement("General");
            w.WriteElementString("UpdateRate", "250");
            w.WriteElementString("FullscreenSleep", "True");
            w.WriteElementString("UpdateCheck", "True");
            w.WriteEndElement();
        }

        private void WriteTrayIcon(XmlWriter w)
        {
            w.WriteStartElement("TrayIcon");
            w.WriteElementString("Name", "Test Icon");
            w.WriteElementString("RenderType", "Basic");
            w.WriteStartElement("DataSources");
            w.WriteElementString("Data1", "CPU1");
            w.WriteElementString("Data2", "CPU2");
            w.WriteEndElement();
            w.WriteEndElement();
        }

        public struct Setting
        {
            public string Key;
            public string Value;
            public string Section;
        }
    }
}

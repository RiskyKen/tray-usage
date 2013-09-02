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
using System.IO;
using System.Xml;
using System.Drawing;

namespace TrayUsage
{
    partial class TrayIcon
    {
        public TrayIcon(XmlReader aXmlReader)
        {
            LoadFromXml(aXmlReader);
            
        }

        private void LoadFromXml(XmlReader aR)
        {
            while (aR.Read())
            {
                switch (aR.NodeType)
                {
                    case XmlNodeType.Element:
                        if (aR.Name == "RendererBasic")
                        {
                            renderer = new RendererBasic(aR);
                            MakeTrayIcon();
                            break;
                        }
                        if (aR.Name == "RendererImage")
                        {
                            renderer = new RendererImage(aR);
                            MakeTrayIcon();
                            break;
                        }
                        if (aR.Name == "DataSources")
                        {
                            ReadDataLinks(aR);
                            break;
                        }
                        ReadXmlElement(aR,aR.Name);
                        break;
                    case XmlNodeType.EndElement:
                        if (aR.Name == "Icon") { return; }
                        break;
                }
            }
        }


        private void ReadXmlElement(XmlReader aR,string aName)
        {
            while (aR.Read())
            {
                switch (aR.NodeType)
                {
                    case XmlNodeType.Text:
                        switch (aName)
                        {
                            case "Name":
                                _iconName = aR.Value;
                                break;
                            case "Rollover":
                                _rolloverText = aR.Value;
                                break;
                        }
                        break;
                    case XmlNodeType.EndElement:
                        return;
                }
            }
        }

        private void ReadDataLinks(XmlReader aR)
        {
           while (aR.Read())
            {
                switch (aR.NodeType)
                {
                    case XmlNodeType.Element:
                        if (aR.Name == "Node")
                        { ReadDataNode(aR); }
                        break;
                    case XmlNodeType.Text:

                        break;
                    case XmlNodeType.EndElement:
                        if (aR.Name == "DataSources") { return; }
                        break;
                }
            }
        }

        private void ReadDataNode(XmlReader aR)
        {
            DataLink tempLink;
            tempLink = new DataLink();
            string thisNode = "";
            while (aR.Read())
            {
                switch (aR.NodeType)
                {
                    case XmlNodeType.Element:
                        thisNode = aR.Name;
                        break;
                    case XmlNodeType.Text:
                        if (thisNode == "Name")
                        {
                            tempLink.DataClassRef = Program.dataManager.GetDataClassRef(aR.Value);
                            break;
                        }
                        if (thisNode == "Index")
                        {
                            tempLink.DataIndex = Int32.Parse(aR.Value);
                            break;
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (aR.Name == "Node")
                        {
                            AddDataSource(tempLink);
                            return;
                        }
                        break;
                }
            }
        }

        #region "Save"
        public void SaveIconXml(XmlWriter aW)
        {
            aW.WriteStartElement("Icon");
            SaveGeneralSettings(aW);
            SaveRenderXml(aW);
            SaveDataSourceXml(aW);
            aW.WriteEndElement();
        }

        private void SaveGeneralSettings(XmlWriter aW)
        {
            aW.WriteElementString("Name", _iconName);
            if (_rolloverText != "")
            { aW.WriteElementString("Rollover", _rolloverText); }
        }

        private void SaveRenderXml(XmlWriter aW)
        {
            if (renderer != null) { renderer.SaveRenderer(aW); }
        }

        private void SaveDataSourceXml(XmlWriter aW)
        {
            if (TargetData != null)
            {
                aW.WriteStartElement("DataSources");
                for (Int32 i = 0; i <= TargetData.GetUpperBound(0); i++)
                {
                    aW.WriteStartElement("Node");
                    aW.WriteStartElement("Name");
                    aW.WriteString(TargetData[i].DataClassRef.DataName);
                    aW.WriteEndElement();
                    aW.WriteStartElement("Index");
                    aW.WriteString(TargetData[i].DataIndex.ToString());
                    aW.WriteEndElement();
                    aW.WriteEndElement();
                }
                aW.WriteEndElement();
            }
        }
        #endregion
    }
}

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
using System.Drawing;
using System.Xml;

namespace TrayUsage
{
    public class RendererImage : Renderer 
    {
        private bool pHorizontal = false;

        public bool Horizontal
        {
            get { return pHorizontal; }
            set { pHorizontal = value; }
        }

        public override string Name
        {
            get { return "Image"; }
        }

        public override string Discription
        {
            get { return "Image rendered."; }
        }

        public override Int32 MaxValues
        {
            get { return 1; }
        }

        //Constructor
        public RendererImage()
        {
            PostInt();
        }

        public RendererImage(XmlReader aR) : base(aR)
        {
            PostInt();
        }

        public override void Reload()
        {
            throw new NotImplementedException();
        }

        public override void LoadXmlElement(string aName, string aValue)
        {
            //throw new NotImplementedException();
            return;
        }

        public override void SaveRenderer(System.Xml.XmlWriter aXmlW)
        {
            aXmlW.WriteStartElement("RendererImage");
            aXmlW.WriteElementString("Horizontal", Horizontal.ToString());
            //aXmlW.WriteElementString("BackgroundColour", ColourToString(pBackgroundColour));
            //aXmlW.WriteElementString("ForegroundColour", ColourToString(pForegroundColour));
            aXmlW.WriteEndElement();
        }

        protected override void PostInt()
        {
            for (Int32 i = 0; i <= MaxValues - 1; i++)
            { LastValue[i] = -1; }
            
            //MakeBackgroundImage(pBackgroundColour);
        }

        public override Icon RenderIcon(Int32[] aValue, Boolean sleeping)
        {
            Bitmap tempBitmap = new Bitmap(16, 16);
            Graphics.FromImage(tempBitmap).Clear(Color.Pink);
            if (aValue != null)
            {
            }
            return bmpToIcon(tempBitmap);
        }

        new public void Dispose()
        {
            base.Dispose();
        }
    }
}

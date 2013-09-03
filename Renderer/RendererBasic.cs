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
using System.Drawing;
using System.Xml;

namespace TrayUsage
{
    public class RendererBasic : Renderer
    {
        private Boolean pHorizontal = false;

        private Bitmap BackgroundImage = null;

        private Bitmap SleepingImage = null;

        protected Color pBackgroundColour = Color.Black;

        protected Color pForegroundColour = Color.White;

        protected Boolean pShowBorder = true;

        public bool Horizontal
        {
            get { return pHorizontal; }
            set { pHorizontal = value; }
        }

        public Color BackgroundColour
        {
            get { return pBackgroundColour; }
            set
            {
                ForceIconRedraw();
                pBackgroundColour = value;
                PostInt();
            }
        }

        public Color ForegroundColour
        {
            get { return pForegroundColour; }
            set
            {
                ForceIconRedraw();
                pForegroundColour = value;
            }
        }

        public Boolean ShowBorder
        {
            get { return pShowBorder; }
            set
            {
                pShowBorder = value;
                if (pShowBorder)
                { DrawingSize = new Size(14, 14); }
                else { DrawingSize = new Size(16, 16); }
            }
        }

        public override string Name
        {
            get { return "Basic"; }
        }

        public override string Discription
        {
            get { return "Basic bar renderer. Can have one foreground and one background colour."; }
        }

        //Constructor
        public RendererBasic() : base(5,new Size(14,14))
        {
            PostInt();
        }

        public RendererBasic(XmlReader aR) : base(aR, 5, new Size(14, 14))
        {
            PostInt();
        }

        public override void Reload()
        {
            PostInt();
        }

        public override void LoadXmlElement(string aName, string aValue)
        {
            switch (aName)
            {
                case "Horizontal":
                    pHorizontal = Boolean.Parse(aValue);
                    break;
                case "BackgroundColour":
                    pBackgroundColour = StringToColour(aValue);
                    break;
                case "ForegroundColour":
                    pForegroundColour = StringToColour(aValue);
                    break;
            }
        }

        private void PostInt()
        {
            ForceIconRedraw();
            BackgroundImage = MakeBackgroundImage(pBackgroundColour);
            SleepingImage = (Bitmap)BackgroundImage.Clone();
            Graphics.FromImage(SleepingImage).DrawLine(new Pen(pForegroundColour,1), 1, 1, 14, 14);
            Graphics.FromImage(SleepingImage).DrawLine(new Pen(pForegroundColour, 1), 14, 1, 1, 14);
        }

        //Creates a blank background image.
        public Bitmap MakeBackgroundImage(Color aBGColour)
        {
            Bitmap tempBmp = new Bitmap(16, 16, Globals.ColorBitDepth);
            Graphics.FromImage(tempBmp).Clear(aBGColour);
            if (pShowBorder == true) { drawBorder(tempBmp); }
            return tempBmp;
        }

        public override Icon RenderIcon(Int32[] aValue, Boolean sleeping)
        {
            RenderCount++;
            if (sleeping) { return bmpToIcon(RenderSleeping()); }
            isSleeping = false;
            Bitmap tempBitmap = (Bitmap)BackgroundImage.Clone();
            if (aValue != null)
            {
                switch (aValue.GetUpperBound(0))
                {
                    case 0:
                        Render1Bar(aValue, tempBitmap);
                        break;
                    case 1:
                        Render2Bars(aValue, tempBitmap);
                        break;
                    case 2:
                        Render3Bars(aValue, tempBitmap);
                        break;
                    case 3:
                        Render4Bars(aValue, tempBitmap);
                        break;
                    default:
                        Render5Bars(aValue, tempBitmap);
                        break;
                }
            }
            return bmpToIcon(tempBitmap);
        }

        private Bitmap RenderSleeping()
        {
            isSleeping = true;
            return SleepingImage;
        }

        private void Render1Bar(Int32[] aValue, Bitmap tempBitmap)
        {
            for(Int32 i = 0;i == 0;i++)
            {
                SolidBrush tempBrush = new SolidBrush(pForegroundColour);
                RenderBar(tempBitmap, tempBrush, 14, aValue[i], 0, pHorizontal);
                tempBrush.Dispose();
                LastValue[i] = aValue[i];
            } 
        }

        private void Render2Bars(Int32[] aValue, Bitmap tempBitmap)
        {
            SolidBrush tempBrush = new SolidBrush(pForegroundColour);
            for (Int32 i = 0; i <= 1; i++)
            {
                if (i == 0)
                { RenderBar(tempBitmap, tempBrush, 6, aValue[i], 0, pHorizontal); }
                if (i == 1)
                { RenderBar(tempBitmap, tempBrush, 6, aValue[i], 8, pHorizontal); }
                LastValue[i] = aValue[i];
            }
            tempBrush.Dispose();
        }

        private void Render3Bars(Int32[] aValue, Bitmap tempBitmap)
        {
            SolidBrush tempBrush = new SolidBrush(pForegroundColour);
            for (Int32 i = 0; i <= 2; i++)
            {
                if (i == 0)
                { RenderBar(tempBitmap, tempBrush, 4, aValue[i], 0, pHorizontal); }
                if (i == 1)
                { RenderBar(tempBitmap, tempBrush, 4, aValue[i], 5, pHorizontal); }
                if (i == 2)
                { RenderBar(tempBitmap, tempBrush, 4, aValue[i], 10, pHorizontal); }
                LastValue[i] = aValue[i];
            }
            tempBrush.Dispose();
        }

        private void Render4Bars(Int32[] aValue, Bitmap tempBitmap)
        {
            SolidBrush tempBrush = new SolidBrush(pForegroundColour);
            for (Int32 i = 0; i <= 3; i++)
            {
                if (i == 0)
                { RenderBar(tempBitmap, tempBrush, 2, aValue[i], 0, pHorizontal); }
                if (i == 1)
                { RenderBar(tempBitmap, tempBrush, 2, aValue[i], 4, pHorizontal); }
                if (i == 2)
                { RenderBar(tempBitmap, tempBrush, 2, aValue[i], 8, pHorizontal); }
                if (i == 3)
                { RenderBar(tempBitmap, tempBrush, 2, aValue[i], 12, pHorizontal); }
                LastValue[i] = aValue[i];
            }
            tempBrush.Dispose();
        }

        private void Render5Bars(Int32[] aValue, Bitmap tempBitmap)
        {
            SolidBrush tempBrush = new SolidBrush(pForegroundColour);
            for (Int32 i = 0; i <= 4; i++)
            {
                if (i == 0)
                { RenderBar(tempBitmap, tempBrush, 2, aValue[i], 0, pHorizontal); }
                if (i == 1)
                { RenderBar(tempBitmap, tempBrush, 2, aValue[i], 3, pHorizontal); }
                if (i == 2)
                { RenderBar(tempBitmap, tempBrush, 2, aValue[i], 6, pHorizontal); }
                if (i == 3)
                { RenderBar(tempBitmap, tempBrush, 2, aValue[i], 9, pHorizontal); }
                if (i == 4)
                { RenderBar(tempBitmap, tempBrush, 2, aValue[i], 12, pHorizontal); }
                LastValue[i] = aValue[i];
            }
            tempBrush.Dispose();
        }

        private void RenderBar(Bitmap aBitmap, Brush aBrush, Int32 aWidth, Int32 aValue, Int32 aPos, Boolean aHorizontal)
        {
            if (aHorizontal)
            {
                Graphics.FromImage(aBitmap).FillRectangle(aBrush,1, 1 + aPos, aValue,aWidth );
            }
            else
            {
                Graphics.FromImage(aBitmap).FillRectangle(aBrush, 1 + aPos, 15 - aValue, aWidth, aValue);
            }
        }

        public override void SaveRenderer(System.Xml.XmlWriter aXmlW)
        {
            aXmlW.WriteStartElement("Renderer" + Name);
            aXmlW.WriteElementString("Horizontal", Horizontal.ToString());
            aXmlW.WriteElementString("BackgroundColour", ColourToString(pBackgroundColour));
            aXmlW.WriteElementString("ForegroundColour", ColourToString(pForegroundColour));
            aXmlW.WriteEndElement();
        }

        new public void Dispose()
        {
            if (BackgroundImage != null) { BackgroundImage.Dispose(); }
            base.Dispose();
        }
    }
}
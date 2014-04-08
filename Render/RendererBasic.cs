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
using RiskyKen.TrayUsage.Render;

namespace RiskyKen.TrayUsage
{
    public class RendererBasic : Renderer ,IRenderColorable, IRenderDirection
    {
        private RenderDirections _renderDirection = RenderDirections.UP;

        private Bitmap BackgroundImage = null;

        protected Color pBackgroundColour = Color.Black;

        protected Color pForegroundColour = Color.White;

        protected Boolean pShowBorder = true;

        private Boolean _useAlpha = false;

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

        public RenderDirections RenderDirection
        {
            get
            {
                return _renderDirection;
            }
            set
            {
                _renderDirection = value;
                ForceIconRedraw();
            }
        }

        public Boolean ShowBorder
        {
            get { return pShowBorder; }
            set
            {
                pShowBorder = value;
                PostInt();
            }
        }

        public Boolean UseAlpha
        {
            get { return _useAlpha; }
            set
            {
                _useAlpha = value;
                PostInt();
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

        public override Int32 MaxValues
        {
            get { return 5; }
        }

        //Constructor
        public RendererBasic()
        {
            PostInt();
        }

        public RendererBasic(XmlReader aR) : base(aR)
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
                case "RenderDirection":
                    _renderDirection = (RenderDirections)Byte.Parse(aValue);
                    break;
                case "UseAlpha":
                    _useAlpha = Boolean.Parse(aValue);
                    break;
                case "BackgroundColour":
                    pBackgroundColour = StringToColour(aValue);
                    break;
                case "ForegroundColour":
                    pForegroundColour = StringToColour(aValue);
                    break;
            }
        }

        protected override void PostInt()
        {
            ForceIconRedraw();
            BackgroundImage = MakeBackgroundImage(pBackgroundColour);
            SleepingImage = (Bitmap)BackgroundImage.Clone();
            Graphics.FromImage(SleepingImage).DrawLine(new Pen(pForegroundColour,1), 1, 1, 14, 14);
            Graphics.FromImage(SleepingImage).DrawLine(new Pen(pForegroundColour, 1), 14, 1, 1, 14);
            if (pShowBorder)
            {
                DrawingSize = new Rectangle(1, 1, 14, 14);
                valueScale = 14;
            }
            else
            {
                DrawingSize = new Rectangle(0,0,16, 16);
                valueScale = 16;
            }
            if (_useAlpha) { valueScale *= 256; }
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
                RenderBar(tempBitmap, tempBrush, 14, aValue[i], 0, _renderDirection);
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
                { RenderBar(tempBitmap, tempBrush, 6, aValue[i], 0, _renderDirection); }
                if (i == 1)
                { RenderBar(tempBitmap, tempBrush, 6, aValue[i], 8, _renderDirection); }
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
                { RenderBar(tempBitmap, tempBrush, 4, aValue[i], 0, _renderDirection); }
                if (i == 1)
                { RenderBar(tempBitmap, tempBrush, 4, aValue[i], 5, _renderDirection); }
                if (i == 2)
                { RenderBar(tempBitmap, tempBrush, 4, aValue[i], 10, _renderDirection); }
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
                { RenderBar(tempBitmap, tempBrush, 2, aValue[i], 0, _renderDirection); }
                if (i == 1)
                { RenderBar(tempBitmap, tempBrush, 2, aValue[i], 4, _renderDirection); }
                if (i == 2)
                { RenderBar(tempBitmap, tempBrush, 2, aValue[i], 8, _renderDirection); }
                if (i == 3)
                { RenderBar(tempBitmap, tempBrush, 2, aValue[i], 12, _renderDirection); }
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
                { RenderBar(tempBitmap, tempBrush, 2, aValue[i], 0, _renderDirection); }
                if (i == 1)
                { RenderBar(tempBitmap, tempBrush, 2, aValue[i], 3, _renderDirection); }
                if (i == 2)
                { RenderBar(tempBitmap, tempBrush, 2, aValue[i], 6, _renderDirection); }
                if (i == 3)
                { RenderBar(tempBitmap, tempBrush, 2, aValue[i], 9, _renderDirection); }
                if (i == 4)
                { RenderBar(tempBitmap, tempBrush, 2, aValue[i], 12, _renderDirection); }
                LastValue[i] = aValue[i];
            }
            tempBrush.Dispose();
        }

        private void RenderBar(Bitmap buffer, Brush brush, Int32 barWidth, Int32 barValue, Int32 barOffset, RenderDirections renderDirection)
        {
            int xOffset = 0;
            int yOffset = 0;

            switch (renderDirection)
            {
                case RenderDirections.UP:
                    yOffset = 1;
                    break;
                case RenderDirections.DOWN:
                    yOffset = 1;
                    break;
                case RenderDirections.RIGHT:
                    xOffset = 1;
                    break;
                case RenderDirections.LEFT:
                    xOffset = 1;
                    break;
            }

            int x;
            int y;
            int width;
            int height;

            x = 1 + (barOffset * yOffset);
            y = 1 + (barOffset * xOffset);

            if (!UseAlpha)
            {
                width = (barWidth * yOffset) + (barValue * xOffset);
                height = (barWidth * xOffset) + (barValue * yOffset);

                if (renderDirection == RenderDirections.UP) { y += 14 - barValue; }
                if (renderDirection == RenderDirections.RIGHT) { x += 14 - barValue; }

                Graphics.FromImage(buffer).FillRectangle(brush, x, y, width, height);
            }
            else
            {
                Int32 normalDrawAmount = (Int32)Math.Floor((Double)(barValue / 256));
                Int32 alphaDrawAmount = barValue - (normalDrawAmount * 256);

                width = (barWidth * yOffset) + (normalDrawAmount * xOffset);
                height = (barWidth * xOffset) + (normalDrawAmount * yOffset);

                if (renderDirection == RenderDirections.UP) { y += 14 - normalDrawAmount; }
                if (renderDirection == RenderDirections.RIGHT) { x += 14 - normalDrawAmount; }

                Graphics.FromImage(buffer).FillRectangle(brush, x, y, width, height);

                SolidBrush alphaBrush = new SolidBrush(Color.FromArgb(alphaDrawAmount, ForegroundColour.R, ForegroundColour.G, ForegroundColour.B));

                switch (renderDirection)
                {
                    case RenderDirections.UP:
                        Graphics.FromImage(buffer).FillRectangle(alphaBrush, x, y - 1, width, 1);
                        break;
                    case RenderDirections.DOWN:
                        Graphics.FromImage(buffer).FillRectangle(alphaBrush, x, y + 1, width, 1);
                        break;
                    case RenderDirections.RIGHT:
                        Graphics.FromImage(buffer).FillRectangle(alphaBrush, x - 1, y, 1, height);
                        break;
                    case RenderDirections.LEFT:
                        Graphics.FromImage(buffer).FillRectangle(alphaBrush, x + 1, y, 1, height);
                        break;
                }

                alphaBrush.Dispose();
            }
        }

        public override void SaveRenderer(System.Xml.XmlWriter aXmlW)
        {
            aXmlW.WriteStartElement("Renderer" + Name);
            aXmlW.WriteElementString("RenderDirection", ((byte)(_renderDirection)).ToString());
            aXmlW.WriteElementString("UseAlpha", UseAlpha.ToString());
            aXmlW.WriteElementString("BackgroundColour", ColourToString(pBackgroundColour));
            aXmlW.WriteElementString("ForegroundColour", ColourToString(pForegroundColour));
            aXmlW.WriteEndElement();
        }

        public override void Dispose()
        {
            if (BackgroundImage != null) { BackgroundImage.Dispose(); }
        }
    }
}

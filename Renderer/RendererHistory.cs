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
using System.Drawing;

namespace TrayUsage
{
    partial class RendererHistory : Renderer
    {
        private Boolean _horizontal = false;

        private Bitmap _backgroundImage = null;

        protected Color _backgroundColour = Color.Black;

        protected Color _foregroundColour = Color.White;

        protected Boolean _showBorder = true;

        private Boolean _useAlpha = false;

        private Int32[] _history = null;

        private Int32 _historyIndex = 0;

        public override string Name
        {
            get { return "History"; }
        }

        public override string Discription
        {
            get { return "Shows a history chart thing"; }
        }

        public override Int32 MaxValues
        {
            get { return 1; }
        }

        ///<summary>Constructor</summary>
        public RendererHistory()
        {
            PostInt();

        }

        ///<summary>Constructor using Xml</summary>
        public RendererHistory(XmlReader aR) : base(aR)
        {
            PostInt();
        }

        public override void Reload()
        {
            PostInt();
        }

        protected override void PostInt()
        {
            ForceIconRedraw();
            _backgroundImage = MakeBackgroundImage(_backgroundColour);
            SleepingImage = (Bitmap)_backgroundImage.Clone();
            Graphics.FromImage(SleepingImage).DrawLine(new Pen(_foregroundColour, 1), 1, 1, 14, 14);
            Graphics.FromImage(SleepingImage).DrawLine(new Pen(_foregroundColour, 1), 14, 1, 1, 14);
            if (_showBorder)
            {
                DrawingSize = new Rectangle(1, 1, 14, 14);
                valueScale = 14;
            }
            else
            {
                DrawingSize = new Rectangle(0, 0, 16, 16);
                valueScale = 16;
            }
            _history = new Int32[DrawingSize.Width];
            ResetHistory();
            if (_useAlpha) { valueScale *= 256; }
        }

        //Creates a blank background image.
        public Bitmap MakeBackgroundImage(Color aBGColour)
        {
            Bitmap tempBmp = new Bitmap(16, 16, Globals.ColorBitDepth);
            Graphics.FromImage(tempBmp).Clear(aBGColour);
            if (_showBorder == true) { drawBorder(tempBmp); }
            return tempBmp;
        }

        //TODO move into base class.
        private void RenderBar(Bitmap aBitmap, Brush aBrush, Int32 aWidth, Int32 aValue, Int32 aPos, Boolean aHorizontal)
        {
            if (aHorizontal)
            {
                if (!_useAlpha)
                { Graphics.FromImage(aBitmap).FillRectangle(aBrush, 1, 1 + aPos, aValue, aWidth); }
                else
                {
                    Int32 normalDrawAmount = (Int32)Math.Floor((Double)(aValue / 256));
                    Int32 alphaDrawAmount = aValue - (normalDrawAmount * 256);
                    Graphics.FromImage(aBitmap).FillRectangle(aBrush, 1, 1 + aPos, normalDrawAmount, aWidth);
                    SolidBrush tempBrush = new SolidBrush(Color.FromArgb(alphaDrawAmount, _foregroundColour.R, _foregroundColour.G, _foregroundColour.B));
                    Graphics.FromImage(aBitmap).FillRectangle(tempBrush, 1 + normalDrawAmount, 1 + aPos, 1, aWidth); tempBrush.Dispose();
                }
            }
            else
            {
                if (!_useAlpha)
                { Graphics.FromImage(aBitmap).FillRectangle(aBrush, 1 + aPos, 15 - aValue, aWidth, aValue); }
                else
                {
                    Int32 normalDrawAmount = (Int32)Math.Floor((Double)(aValue / 256));
                    Int32 alphaDrawAmount = aValue - (normalDrawAmount * 256);
                    Graphics.FromImage(aBitmap).FillRectangle(aBrush, 1 + aPos, 15 - normalDrawAmount, aWidth, normalDrawAmount);
                    SolidBrush tempBrush = new SolidBrush(Color.FromArgb(alphaDrawAmount, _foregroundColour.R, _foregroundColour.G, _foregroundColour.B));
                    Graphics.FromImage(aBitmap).FillRectangle(tempBrush, 1 + aPos, 15 - normalDrawAmount - 1, aWidth, 1);
                    tempBrush.Dispose();
                }
            }
        }

        public override Boolean NeedRedraw(Int32[] aValues, Boolean sleeping)
        {
            if (Globals.AlwaysRedrawIcons) { return true; }
            if (AlwaysRedraw) { return true; }
            if (aValues == null) { return true; }
            if (sleeping) { return true; }
            if (isSleeping) { return true; }

            Int32 tempHistory = _history[0];
            for (Int32 i = 1; i <= _history.GetUpperBound(0); i++)
            {
                if (tempHistory != _history[i]) { return true; }
            }

            if (tempHistory != aValues[0]) { return true; }

            return false;
        }

        private void ResetHistory()
        {
            for (Int32 i = 0; i <= _history.GetUpperBound(0); i++)
            { _history[i] = -1; }
        }

        public override void LoadXmlElement(string aName, string aValue)
        {
            switch (aName)
            {
                case "Horizontal":
                    _horizontal = Boolean.Parse(aValue);
                    break;
                case "UseAlpha":
                    _useAlpha = Boolean.Parse(aValue);
                    break;
                case "BackgroundColour":
                    _backgroundColour = StringToColour(aValue);
                    break;
                case "ForegroundColour":
                    _foregroundColour = StringToColour(aValue);
                    break;
            }
        }

        public override System.Drawing.Icon RenderIcon(int[] aValue, bool sleeping)
        {
            RenderCount++;
            if (sleeping) { return bmpToIcon(RenderSleeping()); }
            isSleeping = false;
            Bitmap tempBitmap = (Bitmap)_backgroundImage.Clone();
            if (aValue == null) { return bmpToIcon(tempBitmap); }

            _history[_historyIndex] = aValue[0];

            SolidBrush tempBrush = new SolidBrush(_foregroundColour);
            for (Int32 i = 0; i <= DrawingSize.Width - 1; i++)
            {
                Int32 thisPlace = _historyIndex - i;
                if (thisPlace < 0) { thisPlace += _history.GetUpperBound(0) + 1; }
                if (_history[thisPlace] != -1)
                { RenderBar(tempBitmap, tempBrush, 1, _history[thisPlace], 13 - i, _horizontal); }
            }
            tempBrush.Dispose();
            LastValue[0] = aValue[0];

            _historyIndex++;
            if (_historyIndex >= DrawingSize.Width) { _historyIndex = 0; }

            //throw new NotImplementedException();
            return bmpToIcon(tempBitmap);
        }

        private Bitmap RenderSleeping()
        {
            isSleeping = true;
            return SleepingImage;
        }

        public override void SaveRenderer(System.Xml.XmlWriter aXmlW)
        {
            aXmlW.WriteStartElement("Renderer" + Name);
            aXmlW.WriteElementString("Horizontal", _horizontal.ToString());
            aXmlW.WriteElementString("UseAlpha", _useAlpha.ToString());
            aXmlW.WriteElementString("BackgroundColour", ColourToString(_backgroundColour));
            aXmlW.WriteElementString("ForegroundColour", ColourToString(_foregroundColour));
            aXmlW.WriteEndElement();
        }

        new public void Dispose()
        {
            base.Dispose();
        }
    }
}

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
using System.IO;
using RiskyKen.TrayUsage.Render;

namespace RiskyKen.TrayUsage
{
    partial class RendererImage : Renderer, IRenderDirection
    {
        private RenderDirections _renderDirection = RenderDirections.UP;

        private string _backgroundImagePath = null;
        private string _activeImagePath = null;
        private string _foregroundImagePath = null;

        private Bitmap _backgroundImage = null;
        private Bitmap _activeImage = null;
        private Bitmap _foregroundImage = null;

        private bool _haveBackgroundImage = false;
        private bool _haveActiveImage = false;
        private bool _haveForegroundImage = false;

        private int _paddingTop = 0;
        private int _paddingBottom = 0;
        private int _paddingLeft = 0;
        private int _paddingRight = 0;

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

        ///<summary>Constructor</summary>
        public RendererImage()
        {
            PostInt();
        }

        ///<summary>Constructor using Xml</summary>
        public RendererImage(XmlReader aR) : base(aR)
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
                case "BackgroundImagePath":
                    _backgroundImagePath = aValue;
                    break;
                case "ActiveImagePath":
                    _activeImagePath = aValue;
                    break;
                case "ForegroundImagePath":
                    _foregroundImagePath = aValue;
                    break;
                case "PaddingTop":
                    _paddingTop = int.Parse(aValue);
                    break;
                case "PaddingBottom":
                    _paddingBottom = int.Parse(aValue);
                    break;
                case "PaddingLeft":
                    _paddingLeft = int.Parse(aValue);
                    break;
                case "PaddingRight":
                    _paddingRight = int.Parse(aValue);
                    break;
            }
        }

        public override void SaveRenderer(System.Xml.XmlWriter aXmlW)
        {
            aXmlW.WriteStartElement("RendererImage");
            aXmlW.WriteElementString("RenderDirection", ((byte)(_renderDirection)).ToString() );

            if (!String.IsNullOrEmpty(_backgroundImagePath))
            { aXmlW.WriteElementString("BackgroundImagePath", _backgroundImagePath); }

            if (!String.IsNullOrEmpty(_activeImagePath))
            { aXmlW.WriteElementString("ActiveImagePath", _activeImagePath); }

            if (!String.IsNullOrEmpty(_foregroundImagePath))
            { aXmlW.WriteElementString("ForegroundImagePath", _foregroundImagePath); }

            aXmlW.WriteElementString("PaddingTop", _paddingTop.ToString());
            aXmlW.WriteElementString("PaddingBottom", _paddingBottom.ToString());
            aXmlW.WriteElementString("PaddingLeft", _paddingLeft.ToString());
            aXmlW.WriteElementString("PaddingRight", _paddingRight.ToString());

            aXmlW.WriteEndElement();
        }

        protected override void PostInt()
        {
            DisposeOfImages();

            _haveBackgroundImage = false;
            _haveActiveImage = false;
            _haveForegroundImage = false;

            Bitmap tempBitmap;

            tempBitmap = LoadImage(_backgroundImagePath);
            if (tempBitmap != null)
            {
                _haveBackgroundImage = true;
                ApplyBitmap(tempBitmap, ref _backgroundImage);
                tempBitmap.Dispose();
            }

            tempBitmap = LoadImage(_activeImagePath);
            if (tempBitmap != null)
            {
                _haveActiveImage = true;
                ApplyBitmap(tempBitmap, ref _activeImage);
                tempBitmap.Dispose();
            }

            tempBitmap = LoadImage(_foregroundImagePath);
            if (tempBitmap != null)
            {
                _haveForegroundImage = true;
                ApplyBitmap(tempBitmap, ref _foregroundImage);
                tempBitmap.Dispose();
            }

            DrawingSize = new Rectangle(_paddingLeft, _paddingTop, 16 - (_paddingLeft + _paddingRight), 16 - (_paddingTop + _paddingBottom));
            if (RenderDirection == RenderDirections.UP || RenderDirection == RenderDirections.DOWN)
            {
                valueScale = DrawingSize.Height;
            }
            else if(RenderDirection == RenderDirections.LEFT | RenderDirection == RenderDirections.RIGHT)
            {
                valueScale = DrawingSize.Width;
            }

            ForceIconRedraw();
        }

        private Bitmap LoadImage(string path)
        {
            if (File.Exists(path))
            {
                return new Bitmap(path);
            }
            return null;
        }

        private void ApplyBitmap(Bitmap source, ref Bitmap target)
        {
            target = new Bitmap(16, 16, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics.FromImage(target).DrawImage(source, 0, 0);
        }

        public override Icon RenderIcon(Int32[] aValue, Boolean sleeping)
        {
            RenderCount++;
            Bitmap tempBitmap = new Bitmap(16, 16);
            if (_haveBackgroundImage)
            {
                Graphics.FromImage(tempBitmap).DrawImage(_backgroundImage, 0, 0);
            }
            if (aValue != null && aValue[0] != 0)
            {
                if (_haveActiveImage)
                {
                    Graphics.FromImage(tempBitmap).DrawImage(_activeImage,
                        new Rectangle(DrawingSize.X, DrawingSize.Height - aValue[0] + DrawingSize.Y, DrawingSize.Width, aValue[0]),
                        new Rectangle(DrawingSize.X, DrawingSize.Height - aValue[0] + DrawingSize.Y, DrawingSize.Width, aValue[0]),
                        GraphicsUnit.Pixel);
                    //Graphics.FromImage(tempBitmap).DrawImage(_activeImage, 0, 0);
                }
            }
            if (_haveForegroundImage)
            {
                Graphics.FromImage(tempBitmap).DrawImage(_foregroundImage, 0, 0);
            }

            return bmpToIcon(tempBitmap);
        }

        private void DisposeOfImages()
        {
            if (_backgroundImage != null) { _backgroundImage.Dispose(); _backgroundImage = null; }
            if (_activeImage != null) { _activeImage.Dispose(); _activeImage = null; }
            if (_foregroundImage != null) { _foregroundImage.Dispose(); _foregroundImage = null; }
        }

        public override void Dispose()
        {
            DisposeOfImages();
            //base.Dispose();
        }
    }
}

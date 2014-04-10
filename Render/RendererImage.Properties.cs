using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RiskyKen.TrayUsage.Render;

namespace RiskyKen.TrayUsage
{
    partial class RendererImage
    {
        public string BackgroundImagePath
        {
            get { return _backgroundImagePath; }
            set
            {
                _backgroundImagePath = value;
                PostInt();
                ForceIconRedraw();
            }
        }

        public string ActiveImagePath
        {
            get { return _activeImagePath; }
            set
            {
                _activeImagePath = value;
                PostInt();
                ForceIconRedraw();
            }
        }

        public string ForegroundImagePath
        {
            get { return _foregroundImagePath; }
            set
            {
                _foregroundImagePath = value;
                PostInt();
                ForceIconRedraw();
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

        public int PaddingTop
        {
            get { return _paddingTop; }
            set
            {
                _paddingTop = value;
                PostInt();
                ForceIconRedraw();
            }
        }

        public int PaddingBottom
        {
            get { return _paddingBottom; }
            set
            {
                _paddingBottom = value;
                PostInt();
                ForceIconRedraw();
            }
        }

        public int PaddingLeft
        {
            get { return _paddingLeft; }
            set
            {
                _paddingLeft = value;
                PostInt();
                ForceIconRedraw();
            }
        }
        public int PaddingRight
        {
            get { return _paddingRight; }
            set
            {
                _paddingRight = value;
                PostInt();
                ForceIconRedraw();
            }
        }


    }
}

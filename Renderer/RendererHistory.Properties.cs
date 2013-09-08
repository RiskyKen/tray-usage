using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TrayUsage
{
    partial class RendererHistory
    {
        public bool Horizontal
        {
            get { return _horizontal; }
            set { _horizontal = value; }
        }

        public Color BackgroundColour
        {
            get { return _backgroundColour; }
            set
            {
                ForceIconRedraw();
                _backgroundColour = value;
                PostInt();
            }
        }

        public Color ForegroundColour
        {
            get { return _foregroundColour; }
            set
            {
                ForceIconRedraw();
                _foregroundColour = value;
            }
        }

        public Boolean ShowBorder
        {
            get { return _showBorder; }
            set
            {
                _showBorder = value;
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
    }
}

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

namespace RiskyKen.TrayUsage
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

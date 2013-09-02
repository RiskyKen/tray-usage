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
using System.Windows.Forms;
using System.Drawing;

namespace TrayUsage
{
    class ColorPresetPicker : ComboBox
    {
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            if (Globals.colorPresets == null) { return; }
            if (e.Index == -1) { return; }

            Rectangle tempBounds = e.Bounds;
            tempBounds.Width = tempBounds.Width / 2;
            e.Graphics.FillRectangle(new SolidBrush(Globals.colorPresets[e.Index].BackgroundColor), tempBounds);
            tempBounds.X += tempBounds.Width;
            e.Graphics.FillRectangle(new SolidBrush(Globals.colorPresets[e.Index].ForegroundColor), tempBounds);
            e.DrawFocusRectangle();
        }
    }
}

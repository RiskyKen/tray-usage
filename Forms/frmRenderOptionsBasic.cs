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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrayUsage
{
    public partial class frmRenderOptionsBasic : Form
    {
        private TrayIcon TargetIcon = null;
        private RendererBasic TargetRender = null;

        public frmRenderOptionsBasic(TrayIcon aTargetIcon)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.tray;

            for (Int32 i = 0; i <= Globals.colorPresets.GetUpperBound(0); i++)
            {
                colorPer.Items.Add(i.ToString());
            }

            TargetIcon = aTargetIcon;
            TargetRender = (RendererBasic)TargetIcon.renderer;
            LoadColourPics();
            chkHorizontal.Checked = TargetRender.Horizontal;
        }

        private void LoadColourPics()
        {
            picBGColour.BackColor = TargetRender.BackgroundColour;
            picFGColour.BackColor = TargetRender.ForegroundColour;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnColourBG_Click(object sender, EventArgs e)
        {
            TargetRender.BackgroundColour = OpenColourDialog(picBGColour.BackColor);
            colorPer.SelectedIndex = -1;
            LoadColourPics();
        }

        private void btnColourFG_Click(object sender, EventArgs e)
        {
            TargetRender.ForegroundColour = OpenColourDialog(picFGColour.BackColor);
            colorPer.SelectedIndex = -1;
            LoadColourPics();
        }
        
        private Color OpenColourDialog(Color aStartColour)
        {
            ColorDialog ColorForm = new ColorDialog();
            ColorForm.FullOpen = true;
            ColorForm.Color = aStartColour;
            if (ColorForm.ShowDialog() == DialogResult.OK)
            { return ColorForm.Color; }
            else
            { return aStartColour; }
        }

        private void chkHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            TargetRender.Horizontal = chkHorizontal.Checked;
        }

        private void colorPer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TargetRender == null) { return; }
            if (colorPer.SelectedIndex == -1) { return; }
            TargetRender.BackgroundColour = Globals.colorPresets[colorPer.SelectedIndex].BackgroundColor;
            TargetRender.ForegroundColour = Globals.colorPresets[colorPer.SelectedIndex].ForegroundColor;
            LoadColourPics();
        }
    }
}

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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RiskyKen.TrayUsage.Render;

namespace RiskyKen.TrayUsage
{
    public partial class frmRenderOptionsImage : Form
    {
        private TrayIcon targetIcon = null;
        private RendererImage targetRender = null;

        public frmRenderOptionsImage(TrayIcon targetIcon)
        {
            InitializeComponent();
            this.targetIcon = targetIcon;
            targetRender = (RendererImage)targetIcon.renderer;

            textBoxBgImage.Text = targetRender.BackgroundImagePath;
            textBoxActiveImage.Text = targetRender.ActiveImagePath;
            textBoxFgImage.Text = targetRender.ForegroundImagePath;

            comboBoxDirection.SelectedIndex = (byte)targetRender.RenderDirection - 1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonBrowseBgImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                textBoxBgImage.Text = fd.FileName;
            }
            fd.Dispose();
        }

        private void buttonBrowseActiveImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                textBoxActiveImage.Text = fd.FileName;
            }
            fd.Dispose();
        }

        private void buttonBrowseFgImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                textBoxFgImage.Text = fd.FileName;
            }
            fd.Dispose();
        }

        private void textBoxBgImage_TextChanged(object sender, EventArgs e)
        {
            targetRender.BackgroundImagePath = textBoxBgImage.Text;
        }

        private void textBoxActiveImage_TextChanged(object sender, EventArgs e)
        {
            targetRender.ActiveImagePath = textBoxActiveImage.Text;
        }

        private void textBoxFgImage_TextChanged(object sender, EventArgs e)
        {
            targetRender.ForegroundImagePath = textBoxFgImage.Text;
        }

        private void comboBoxDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            targetRender.RenderDirection = (RenderDirections)comboBoxDirection.SelectedIndex + 1;
        }

        private void numericUpDownTopPadding_ValueChanged(object sender, EventArgs e)
        {
            targetRender.PaddingTop = (int)numericUpDownTopPadding.Value;
        }

        private void numericUpDownLeftPadding_ValueChanged(object sender, EventArgs e)
        {
            targetRender.PaddingLeft = (int)numericUpDownLeftPadding.Value;
        }

        private void numericUpDownRightPadding_ValueChanged(object sender, EventArgs e)
        {
            targetRender.PaddingRight = (int)numericUpDownRightPadding.Value;
        }

        private void numericUpDownBottomPadding_ValueChanged(object sender, EventArgs e)
        {
            targetRender.PaddingBottom = (int)numericUpDownBottomPadding.Value;
        }
    }
}

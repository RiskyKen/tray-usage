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
    public partial class frmRenderOptionsHistory : Form
    {
        private TrayIcon _targetIcon = null;
        private RendererHistory _targetRender = null;

        public frmRenderOptionsHistory(TrayIcon TargetIcon)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.tray;

            for (Int32 i = 0; i <= Globals.colorPresets.GetUpperBound(0); i++)
            {
                colorPer.Items.Add(i.ToString());
            }

            _targetIcon = TargetIcon;
            _targetRender = (RendererHistory)TargetIcon.renderer;
            LoadColourPics();
            chkHorizontal.Checked = _targetRender.Horizontal;
            chkUseAlpha.Checked = _targetRender.UseAlpha;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadColourPics()
        {
            picBGColour.BackColor = _targetRender.BackgroundColour;
            picFGColour.BackColor = _targetRender.ForegroundColour;
        }

        private void btnColourBG_Click(object sender, EventArgs e)
        {
            _targetRender.BackgroundColour = OpenColourDialog(picBGColour.BackColor);
            colorPer.SelectedIndex = -1;
            LoadColourPics();
        }

        private void btnColourFG_Click(object sender, EventArgs e)
        {
            _targetRender.ForegroundColour = OpenColourDialog(picFGColour.BackColor);
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
            _targetRender.Horizontal = chkHorizontal.Checked;
        }

        private void chkUseAlpha_CheckedChanged(object sender, EventArgs e)
        {
            _targetRender.UseAlpha = chkUseAlpha.Checked;
        }

        private void colorPer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_targetRender == null) { return; }
            if (colorPer.SelectedIndex == -1) { return; }
            _targetRender.BackgroundColour = Globals.colorPresets[colorPer.SelectedIndex].BackgroundColor;
            _targetRender.ForegroundColour = Globals.colorPresets[colorPer.SelectedIndex].ForegroundColor;
            LoadColourPics();
        }


    }
}

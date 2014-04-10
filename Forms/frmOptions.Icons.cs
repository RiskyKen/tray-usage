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
using System.Windows.Forms;
using RiskyKen.TrayUsage.Render;
using System.Diagnostics;
using RiskyKen.TrayUsage.Icons;

namespace RiskyKen.TrayUsage
{
    public partial class frmOptions
    {
        private void LoadIconTab()
        {
            foreach (string renderName in Render.RenderRegistry.GetRendererNames())
            {
                comboRenderType.Items.Add(renderName);
            }

            populateIconsList();
            if (listIcons.Items.Count > 0)
            {
                listIcons.SelectedIndex = 0;
            }
        }

        private void populateIconsList()
        {
            listIcons.Items.Clear();
            if (IconManager.trayIcons == null) { return; }
            for (Int32 i = 0; i <= IconManager.trayIcons.GetUpperBound(0); i++)
            {
                listIcons.Items.Add(IconManager.trayIcons[i].IconName);
            }
        }

        private void btnAddIcon_Click(object sender, EventArgs e)
        {
            IconManager.AddIcon("New Icon", "{iconname}", null, Color.Black, Color.White);
            populateIconsList();
        }

        private void btnAddPresetIcon_Click(object sender, EventArgs e)
        {
            MouseEventArgs em = (MouseEventArgs)e;
            contextMenuPersets.Show(btnAddPresetIcon, new Point(em.X, em.Y));
        }

        private void cPUIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PresetIconHelper.AddPersetIcon("CPU"))
            {
                populateIconsList();
            }
        }

        private void rAMIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PresetIconHelper.AddPersetIcon("RAM"))
            {
                populateIconsList();
            }
        }

        private void networkIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PresetIconHelper.AddPersetIcon("Network"))
            {
                populateIconsList();
            }
        }

        private void diskSpaceIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PresetIconHelper.AddPersetIcon("Disk Space"))
            {
                populateIconsList();
            }
        }

        private void diskAccessIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PresetIconHelper.AddPersetIcon("Disk Access"))
            {
                populateIconsList();
            }
        }

        private void batteryIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PresetIconHelper.AddPersetIcon("Battery"))
            {
                populateIconsList();
            }
        }

        private void btnRemoveIcon_Click(object sender, EventArgs e)
        {
            if (listIcons.SelectedIndex != -1)
            {
                IconManager.RemoveIcon(listIcons.SelectedIndex);
            }
            populateIconsList();
        }

        private void btnMoveIconUp_Click(object sender, EventArgs e)
        {
            Int32 thisIndex = listIcons.SelectedIndex;
            if (thisIndex == -1) { return; }
            if (thisIndex == 0) { return; }
            IconManager.MoveIconUp(listIcons.SelectedIndex);
            populateIconsList();
            listIcons.SelectedIndex = thisIndex - 1;
        }

        private void btnMoveIconDown_Click(object sender, EventArgs e)
        {
            Int32 thisIndex = listIcons.SelectedIndex;
            if (thisIndex == -1) { return; }
            if (thisIndex == listIcons.Items.Count - 1) { return; }
            IconManager.MoveIconDown(listIcons.SelectedIndex);
            populateIconsList();
            listIcons.SelectedIndex = thisIndex + 1;
        }

        private void listIcons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listIcons.SelectedIndex != -1)
            {
                SelectedIcon = IconManager.trayIcons[listIcons.SelectedIndex];
                IconToForm();
            }
            else
            {
                SelectedIcon = null;
            }
        }

        private void IconToForm()
        {
            txtIconName.Text = SelectedIcon.IconName;
            txtRollover.Text = SelectedIcon.RolloverText;
            comboRenderType.Text = SelectedIcon.renderer.Name;
            SetRenderInfo();

            listData.Items.Clear();
            List<string> dataList = SelectedIcon.GetDataSourcesList();
            if (dataList != null)
            {
                foreach (string dataItem in dataList)
                {
                    listData.Items.Add(dataItem);
                }
            }
        }

        private void btnEditDataLinks_Click(object sender, EventArgs e)
        {
            if (listIcons.SelectedIndex == -1) { return; }
            if (SelectedIcon == null) { return; }
            frmDataLink DataLinkForm = new frmDataLink(SelectedIcon);
            DataLinkForm.ShowDialog();
            IconToForm();
            DataLinkForm.Dispose();
            DataLinkForm = null;
        }

        private void btnRenderOptions_Click(object sender, EventArgs e)
        {
            if (listIcons.SelectedIndex == -1) { return; }
            if (SelectedIcon == null) { return; }
            switch (SelectedIcon.renderer.Name)
            {
                case "Basic":
                    frmRenderOptionsBasic RenderOptionsBasicForm = new frmRenderOptionsBasic(SelectedIcon);
                    RenderOptionsBasicForm.ShowDialog();
                    RenderOptionsBasicForm.Dispose();
                    RenderOptionsBasicForm = null;
                    break;
                case "Image":
                    frmRenderOptionsImage RenderOptionsImageForm = new frmRenderOptionsImage(SelectedIcon);
                    RenderOptionsImageForm.ShowDialog();
                    RenderOptionsImageForm.Dispose();
                    RenderOptionsImageForm = null;
                    break;
                case "History":
                    frmRenderOptionsHistory RenderOptionsHistoryForm = new frmRenderOptionsHistory(SelectedIcon);
                    RenderOptionsHistoryForm.ShowDialog();
                    RenderOptionsHistoryForm.Dispose();
                    RenderOptionsHistoryForm = null;
                    break;
            }
        }

        private void txtIconName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (listIcons.SelectedIndex == -1) { return; }
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                if (txtIconName.Text != "")
                {
                    SelectedIcon.IconName = txtIconName.Text;
                    listIcons.Items[listIcons.SelectedIndex] = txtIconName.Text;
                }
            }
        }

        private void txtIconName_TextChanged(object sender, EventArgs e)
        {
            if (listIcons.SelectedIndex == -1) { return; }
            if (txtIconName.Text != "")
            {
                SelectedIcon.IconName = txtIconName.Text;
                listIcons.Items[listIcons.SelectedIndex] = txtIconName.Text;
            }
        }

        private void txtRollover_TextChanged(object sender, EventArgs e)
        {
            if (listIcons.SelectedIndex == -1) { return; }
            SelectedIcon.RolloverText = txtRollover.Text;
        }

        private void comboRenderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listIcons.SelectedIndex == -1) { return; }
            if (SelectedIcon.renderer.Name == comboRenderType.Text) { return; }
            
            if (typeof(IRenderColorable).IsAssignableFrom(SelectedIcon.renderer.GetType()) &&
                typeof(IRenderColorable).IsAssignableFrom(RenderRegistry.GetRenderTypeFormName(comboRenderType.Text)))
            {
                Color fgColor = ((IRenderColorable)SelectedIcon.renderer).ForegroundColour;
                Color bgColor = ((IRenderColorable)SelectedIcon.renderer).BackgroundColour;

                SelectedIcon.ChangeRenderer(comboRenderType.Text);

                ((IRenderColorable)SelectedIcon.renderer).ForegroundColour = fgColor;
                ((IRenderColorable)SelectedIcon.renderer).BackgroundColour = bgColor;
            }
            else
            {
                if (MessageBox.Show("This will clear the renderer settings.\n\nAre you sure?",
                  Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                { SelectedIcon.ChangeRenderer(comboRenderType.Text); }
                else
                {
                    comboRenderType.Text = SelectedIcon.renderer.Name;
                }
            }
            
            SetRenderInfo();
        }

        private void SetRenderInfo()
        {
            if (SelectedIcon == null)
            {
                lblRenderInfo.Text = " ";
                return;
            }

            lblRenderInfo.Text = "Discription: " + SelectedIcon.renderer.Discription +
                Environment.NewLine + Environment.NewLine + "Max Data Inputs: " +
                SelectedIcon.renderer.MaxValues.ToString() + Environment.NewLine + 
                "Render Count:" + SelectedIcon.renderer.RenderCount.ToString();
            if (typeof(IRenderColorable).IsAssignableFrom(SelectedIcon.renderer.GetType()))
            {
                //groupBoxColour.Visible = true;
            }
            else
            {
                //groupBoxColour.Visible = false;
            }
        }
    }
}

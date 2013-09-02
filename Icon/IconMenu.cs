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

namespace TrayUsage
{
    //Handles the tray right click menu.
    public class IconMenu
    {

        public ContextMenu Menu = null;

        //Constructor
        public IconMenu()
        {
            CreateContextMenu();
        }

        private void CreateContextMenu()
        {
            Menu = new ContextMenu();
            Menu.MenuItems.Add(Properties.Resources.StringOptions + "...", Options_Clicked);
            Menu.MenuItems.Add("-");
            Menu.MenuItems.Add(Properties.Resources.StringUpdate + "...", Update_Clicked);
            Menu.MenuItems.Add(Properties.Resources.StringAbout + "...", About_Clicked);

            Menu.MenuItems.Add("-");
            Menu.MenuItems.Add(Properties.Resources.StringExit, Exit_Clicked);
            Menu.MenuItems[0].DefaultItem = true;
        }

        public void TrayIcon_DoubleClick()
        {
            OpenOptionsForm();
        }

        private void Exit_Clicked(object sender, System.EventArgs e)
        {
            Program.updateLoopRunning = false;
        }

        private void Options_Clicked(object sender, System.EventArgs e)
        {
            OpenOptionsForm();
        }

        private void Update_Clicked(object sender, System.EventArgs e)
        {
            OpenUpdateForm();
        }

        private void About_Clicked(object sender, System.EventArgs e)
        {
            //OpenAboutForm();
        }

        public void Dispose()
        {
            Menu.Dispose();
        }

        private void OpenOptionsForm()
        {
            if (Program.optionsForm == null)
            {
                Program.optionsForm = new frmOptions();
                if (Program.optionsForm.ShowDialog() == DialogResult.OK)
                {
                    //Program.Settings.Save();
                }
                Program.optionsForm.Dispose();
                Program.optionsForm = null;
            }
            else
            {
                Program.optionsForm.Activate();
            }
        }

        private void OpenUpdateForm()
        {
            if (Program.updateForm == null)
            {
                Program.updateForm = new frmUpdate();
                if (Program.updateForm.ShowDialog() == DialogResult.OK)
                {
                    //Program.Settings.Save();
                }
                Program.updateForm.Dispose();
                Program.updateForm = null;
            }
            else
            {
                Program.updateForm.Activate();
            }
        }
    }
}

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

namespace TrayUsage
{
    public class FormHelper
    {
        //The options form.
        private frmOptions _optionsForm = null;

        //The update form.
        private frmUpdate _updateForm = null;

        //The about form.
        private frmAbout _aboutForm = null;

        public FormHelper()
        { }

        public void Dispose()
        { }

        public void OpenOptionsForm()
        {
            if (_optionsForm == null)
            {
                _optionsForm = new frmOptions();
                _optionsForm.ShowDialog();
                _optionsForm.Dispose();
                _optionsForm = null;
            }
            else
            {
                _optionsForm.Activate();
            }
        }

        public void OpenUpdateForm()
        {
            if (_updateForm == null)
            {
                _updateForm = new frmUpdate();
                _updateForm.ShowDialog();
                _updateForm.Dispose();
                _updateForm = null;
            }
            else
            {
                _updateForm.Activate();
            }
        }

        public void OpenAboutForm()
        {
            if (_aboutForm == null)
            {
                _aboutForm = new frmAbout();
                _aboutForm.ShowDialog();
                _aboutForm.Dispose();
                _aboutForm = null;
            }
            else
            {
                _aboutForm.Activate();
            }
        }
    }
}

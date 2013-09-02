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
    public class clsDataBattery : clsData
    {

        public override string DataName
        {
            get { return "Battery"; }
        }

        public clsDataBattery() : base(1)
        {
            pDataLabels[0] = "% Battery Life";
        }

        public override void UpdateValues()
        {
            pCurrentValue[0] = Convert.ToInt32(SystemInformation.PowerStatus.BatteryLifePercent * 100) ;
        }

        new internal void Dispose()
        {
            base.Dispose();
        }

    }
}

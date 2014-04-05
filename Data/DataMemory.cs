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
using System.Diagnostics;
using Microsoft.VisualBasic.Devices;

namespace RiskyKen.TrayUsage
{
    public class DataRam : Data 
    {
        private ComputerInfo computerInfo = null;
        public override string DataName
        {
            get { return "Memory"; }
        }

        public DataRam() : base(2)
        {
            _dataLabels[0] = "% Of Bytes In Use Physical";
            _dataLabels[1] = "% Of Bytes In Use Virtual";
            SetMaxValues(100);
        }

        public override void UpdateValues()
        {
            if (!_isAwake) { throw new Exception("Data class is sleeping."); }
            _currentValue[0] = (UInt64)computerInfo.TotalPhysicalMemory - computerInfo.AvailablePhysicalMemory;
            _maxValue[0] = (UInt64)computerInfo.TotalPhysicalMemory;

            _currentValue[1] = (UInt64)computerInfo.TotalVirtualMemory - computerInfo.AvailableVirtualMemory;
            _maxValue[1] = (UInt64)computerInfo.TotalVirtualMemory;
        }

        public override void Load()
        {
            computerInfo = new ComputerInfo();
        }

        public override void Unload()
        {
            computerInfo = null;
        }
    }
}

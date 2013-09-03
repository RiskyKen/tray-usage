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

namespace TrayUsage
{
    public class DataDiskAccess : Data
    {
        private PerformanceCounter[] proCounter = null;

        public override string DataName
        {
            get { return "Disk Access"; }
        }

        public DataDiskAccess() : base(GetHardDriveCount() + 1)
        {
            proCounter = new PerformanceCounter[GetHardDriveCount() + 1];

            pDataLabels = GetHardDriveLabels();

            string[] diskLabels = new PerformanceCounterCategory("PhysicalDisk").GetInstanceNames();

            for (Int32 i = 0; i <= proCounter.GetUpperBound(0); i++)
            {
                string thisDataLabel = pDataLabels[i].Remove(pDataLabels[i].Length - 1);
                proCounter[i] = new PerformanceCounter();
                proCounter[i].CategoryName = "PhysicalDisk";
                proCounter[i].CounterName = "% Disk Time";
                proCounter[i].InstanceName = diskLabels[i];

            }

        }

        public override void UpdateValues()
        {
            for (Int32 i = 0; i <= proCounter.GetUpperBound(0); i++)
            {
                pCurrentValue[i] = (Int32)proCounter[i].NextValue();
                if (pCurrentValue[i] > 100) { pCurrentValue[i] = 100; }
            }
        }

        public static Int32 GetHardDriveCount()
        {
            string[] diskLabels = new PerformanceCounterCategory("PhysicalDisk").GetInstanceNames();
            return diskLabels.Length - 1;
        }

        public static string[] GetHardDriveLabels()
        {
            string[] DriveLabels = new PerformanceCounterCategory("PhysicalDisk").GetInstanceNames();
            return DriveLabels;
        }

        new internal void Dispose()
        {
            for (Int32 i = 0; i <= proCounter.GetUpperBound(0); i++)
            {
                proCounter[i].Dispose();
            }
            base.Dispose();
        }
    }
}

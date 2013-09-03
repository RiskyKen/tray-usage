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
    public class DataDiskSpace : Data
    {
        private System.IO.DriveInfo[] Drives = null;

        public override string DataName
        {
            get { return "Disk Space"; }
        }

        public DataDiskSpace() : base(System.IO.DriveInfo.GetDrives().Length)
        {
            Drives = System.IO.DriveInfo.GetDrives();

            for (Int32 i = 0; i <= Drives.GetUpperBound(0); i++)
            {
                pDataLabels[i] = Drives[i].Name + " - " + Drives[i].IsReady.ToString();
            }
            SetMaxValues(100);
        }

        public override void UpdateValues()
        {
            for (Int32 i = 0; i <= Drives.GetUpperBound(0); i++)
            {
                Int32 thisSpace = 0;
                if (Drives[i].IsReady)
                { thisSpace = (Int32)(((Drives[i].TotalSize - Drives[i].TotalFreeSpace) * 100) / Drives[i].TotalSize); }
                pCurrentValue[i] = thisSpace;
            }
        }

        new internal void Dispose()
        {
            base.Dispose();
        }
    }
}

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
using System.Linq;
using System.Text;
using System.IO;

namespace RiskyKen.TrayUsage
{
    public class DataDiskSpace : Data
    {
        private System.IO.DriveInfo[] Drives = null;

        public override string DataName
        {
            get { return "Disk Space"; }
        }

        public DataDiskSpace() : base(GetDriveCount())
        {
            Drives = new DriveInfo[GetDriveCount()];
            DriveInfo[] diskDrives = System.IO.DriveInfo.GetDrives();
            int count = 0;
            for (int i = 0; i < diskDrives.Length; i++)
            {
                if (diskDrives[i].DriveType == DriveType.Fixed )
                {
                    Drives[count] = diskDrives[i];
                    count++;
                }
            }

            for (Int32 i = 0; i <= Drives.GetUpperBound(0); i++)
            {
                _dataLabels[i] = Drives[i].Name + " - " + Drives[i].IsReady.ToString();
            }
            SetMaxValues(100);
        }

        public override void UpdateValues()
        {
            if (!_isAwake) { throw new Exception("Data class is sleeping."); }
            for (Int32 i = 0; i <= Drives.GetUpperBound(0); i++)
            {
                Int32 thisSpace = 0;
                if (Drives[i].IsReady)
                { thisSpace = (Int32)(((Drives[i].TotalSize - Drives[i].TotalFreeSpace) * 100) / Drives[i].TotalSize); }
                _currentValue[i] = (UInt64)thisSpace;
            }
        }

        public static int GetDriveCount()
        {
            DriveInfo[] diskDrives = System.IO.DriveInfo.GetDrives();
            int count = 0;
            foreach (DriveInfo drive in diskDrives)
            {
                if (drive.DriveType == DriveType.Fixed )
                {
                    count++;
                }
            }
            return count;
        }

        public override void Load()
        {
        }

        public override void Unload()
        {
        }
    }
}

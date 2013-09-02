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
    //Temp class, will handle loading and unloading of data classes.
    public class clsDataManager
    {
        public clsData[] DataClasses = null;

        //CPU
        //Memory Physical
        //Memory Virtual
        //Network
        //Disk Access
        //Disk Space
        //Battery
        //Dummy

        public clsDataManager()
        {
            DataClasses = new clsData[6];
            DataClasses[0] = new clsDataCpu();
            DataClasses[1] = new clsDataRam();
            DataClasses[2] = new clsDataDummy();
            DataClasses[3] = new clsDataDiskSpace();
            DataClasses[4] = new clsDataDiskAccess();
            //DataClasses[5] = new clsDataNic();
            DataClasses[5] = new clsDataBattery();
        }
                
        public void Dispose()
        {
            for (Int32 i = 0; i <= DataClasses.GetUpperBound(0); i++)
            {
                DataClasses[i].Dispose();
                DataClasses[i] = null;
            }
        }

        public void UpdateValues()
        {
            for (Int32 i = 0; i <= DataClasses.GetUpperBound(0); i++)
            {
                DataClasses[i].UpdateValues();
            }
        }

        public clsData GetDataClassRef(string aName)
        {
            for (Int32 i = 0; i <= DataClasses.GetUpperBound(0); i++)
            {
                if (DataClasses[i].DataName == aName) { return DataClasses[i]; }
            }
            return null;
        }

        public DataListItem[] GetDataNodesList()
        {
            if (DataClasses == null) { return null; }
            DataListItem[] templist;
            templist = new DataListItem[DataClasses.GetUpperBound(0) + 1];
            for (Int32 i = 0;i <= DataClasses.GetUpperBound(0); i++)
            {
                templist[i].Name = DataClasses[i].DataName;
                templist[i].DataNodeName = DataClasses[i].DataLabels;
            }
            return templist;
        }

        public struct DataListItem
        {
            public string Name;
            public string[] DataNodeName;
        }
    }
}

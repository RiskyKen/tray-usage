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

namespace RiskyKen.TrayUsage
{
    //Temp class, will handle loading and unloading of data classes.
    public static class DataManager
    {
        public static Data[] DataClasses = null;

        //CPU
        //Memory Physical
        //Memory Virtual
        //Network
        //Disk Access
        //Disk Space
        //Battery
        //Dummy

        public static void Init()
        {
            DataClasses = new Data[7];
            DataClasses[0] = new DataCpu();
            DataClasses[1] = new DataRam();
            DataClasses[2] = new DataDummy();
            DataClasses[3] = new DataDiskSpace();
            DataClasses[4] = new DataDiskAccess();
            DataClasses[5] = new DataBattery();
            DataClasses[6] = new DataNic();
        }

        public static void Dispose()
        {
            for (Int32 i = 0; i <= DataClasses.GetUpperBound(0); i++)
            {
                DataClasses[i].Dispose();
                DataClasses[i] = null;
            }
        }

        public static String ReplaceIconText(String text)
        {
            String newText = text;
            if (DataClasses == null) { return text; }
            for (Int32 i = 0; i <= DataClasses.GetUpperBound(0); i++)
            {
                newText = DataClasses[i].ReplaceIconText(newText);
            }
            return newText;
        }

        public static void UpdateValues()
        {
            for (Int32 i = 0; i <= DataClasses.GetUpperBound(0); i++)
            {
                if (DataClasses[i].IsAwake)
                {
                    DataClasses[i].UpdateValues();
                }
            }
        }

        public static Data GetDataClassRef(string aName)
        {
            for (Int32 i = 0; i <= DataClasses.GetUpperBound(0); i++)
            {
                if (DataClasses[i].DataName == aName) { return DataClasses[i]; }
            }
            return null;
        }

        public static void WakeupDataClass(string name)
        {
            for (Int32 i = 0; i <= DataClasses.GetUpperBound(0); i++)
            {
                if (DataClasses[i].DataName == name)
                {
                    DataClasses[i].Wake();
                    return;
                }
            }
        }

        public static void SleepDataClass(string name)
        {
            for (Int32 i = 0; i <= DataClasses.GetUpperBound(0); i++)
            {
                if (DataClasses[i].DataName == name)
                {
                    DataClasses[i].Sleep();
                    return;
                }
            }
        }

        public static int GetNumberOfLoadedDataClasses()
        {
            int result = 0;
            for (Int32 i = 0; i <= DataClasses.GetUpperBound(0); i++)
            {
                if (DataClasses[i].IsAwake) { result++; }
            }
            return result;
        }

        public static DataListItem[] GetDataNodesList()
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

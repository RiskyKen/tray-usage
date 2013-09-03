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

namespace TrayUsage
{
    public abstract class Data
    {
        protected Int64[] pCurrentValue;

        protected Int64[] pMaxValue;

        //Labels for data in pCurrentValue.
        protected string[] pDataLabels = null;

        public abstract string DataName { get; }

        public Data(Int32 aNumberOfValues)
        {
            pCurrentValue = new Int64[aNumberOfValues];
            pMaxValue = new Int64[aNumberOfValues];
            pDataLabels = new string[aNumberOfValues];
        }

        protected void UpdateMaxValues()
        {
            for (Int32 i = 0; i <= pCurrentValue.GetUpperBound(0); i++)
            {
                if (pCurrentValue[i] > pMaxValue[i])
                { pMaxValue[i] = pCurrentValue[i]; }
            }
        }

        protected void SetMaxValues(Int64 value)
        {
            for (Int32 i = 0; i <= pCurrentValue.GetUpperBound(0); i++)
            {
                pMaxValue[i] = value;
            }
        }

        public Int64[] CurrentValue
        {
            get {return pCurrentValue;}
        }

        public Int64[] MaxValue
        {
            get { return pMaxValue; }
        }

        public string[] DataLabels
        {
            get {return pDataLabels;}
        }

        public String ReplaceIconText(String text)
        {
            String newText = text;

            if (newText.Contains(DataName + ":"))
            {
                for (Int32 i = 0; i <= pDataLabels.GetUpperBound(0); i++)
                {
                    if (newText.Contains(DataName + ":" + i.ToString()))
                    { newText = newText.Replace("{" + DataName + ":" + i.ToString() + "}", CurrentValue[i].ToString()); }
                }
            }


            return newText;
        }

        public abstract void UpdateValues();

        public void Dispose()
        {
        }
    }

    //public struct DataNode
    //{
    //    public string Name;
    //    public Int64 Value;
    //    public Int64 Max;
    //}
}

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

namespace RiskyKen.TrayUsage
{
    public class DataDummy : Data
    {
        private Random ranNum = null;
        private Int32 upCount = 0;
        private Int32 downCount = 0;

        public override string DataName
        {
            get { return "Dummy"; }
        }

        public DataDummy() : base(3)
        {
            _dataLabels[0] = "Random Data";
            _dataLabels[1] = "Count Up";
            _dataLabels[2] = "Count Down";
            SetMaxValues(100);
        }

        public override void UpdateValues()
        {
            if (!_isAwake) { throw new Exception("Data class is sleeping."); }
            upCount++;
            if (upCount > 100) { upCount = 0; }
            downCount--;
            if (downCount < 0) { downCount = 100; }
            _currentValue[0] = (UInt64)ranNum.Next(0, 100);
            _currentValue[1] = (UInt64)upCount;
            _currentValue[2] = (UInt64)downCount;
        }

        public override void Load()
        {
            ranNum = new Random();
        }

        public override void Unload()
        {
            ranNum = null;
        }
    }
}

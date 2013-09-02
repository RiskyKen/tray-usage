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
    public class clsDataDummy : clsData
    {
        private Random ranNum = null;
        private Int32 upCount = 0;
        private Int32 downCount = 0;

        public override string DataName
        {
            get { return "Dummy"; }
        }

        public clsDataDummy() : base(3)
        {
            ranNum = new Random();

            pDataLabels[0] = "Random Data";
            pDataLabels[1] = "Count Up";
            pDataLabels[2] = "Count Down";
        }

        public override void UpdateValues()
        {
            upCount++;
            if (upCount > 100) { upCount = 0; }
            downCount--;
            if (downCount < 0) { downCount = 100; }
            pCurrentValue[0] = ranNum.Next(0, 100);
            pCurrentValue[1] = upCount;
            pCurrentValue[2] = downCount;
        }

        new internal void Dispose()
        {
            base.Dispose();
        }

    }
}

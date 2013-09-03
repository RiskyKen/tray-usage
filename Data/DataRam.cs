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
    public class DataRam : Data 
    {
        private PerformanceCounter proCounter = null;
        public override string DataName
        {
            get { return "RAM"; }
        }

        internal DataRam() : base(1)
        {
            proCounter = new System.Diagnostics.PerformanceCounter();
            proCounter.CategoryName = "Memory";
            proCounter.CounterName = "% Committed Bytes In Use";

            pDataLabels[0] = "% Of Bytes In Use";
            SetMaxValues(100);
        }

        public override void UpdateValues()
        {
            pCurrentValue[0] = (Int32)proCounter.NextValue();
        }

        new internal void Dispose()
        {
            proCounter.Dispose();
            base.Dispose();
        }
    }
}

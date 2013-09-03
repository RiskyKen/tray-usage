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
    public class DataCpu : Data
    {
        private PerformanceCounter[] proCounter = null;

        public override string DataName
        {
            get { return "CPU"; }
        }

        internal DataCpu() : base(Environment.ProcessorCount + 1)
        {
            proCounter = new PerformanceCounter[Environment.ProcessorCount];

            for (Int32 i = 0; i <= proCounter.GetUpperBound(0); i++)
            {
                proCounter[i] = new PerformanceCounter();
                proCounter[i].CategoryName = "Processor";
                proCounter[i].CounterName = "% Processor Time";
                proCounter[i].InstanceName = i.ToString();
            }

            pDataLabels[0] = "Total";
            for (Int32 i = 1; i <= pDataLabels.GetUpperBound(0); i++)
            {
                pDataLabels[i] = "Core " + i.ToString();
            }
            SetMaxValues(100);
        }

        public override void UpdateValues()
        {
            Int64 totalUsage = 0;
            for (Int32 i = 0; i <= proCounter.GetUpperBound(0); i++)
            {
                pCurrentValue[i + 1] = (Int32)proCounter[i].NextValue();
                totalUsage += pCurrentValue[i];
            }
            pCurrentValue[0] = totalUsage / Environment.ProcessorCount;
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

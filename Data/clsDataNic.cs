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
using System.Net.NetworkInformation;

namespace TrayUsage
{
    public class clsDataNic : clsData
    {
        public override string DataName
        {
            get { return "Network Interface"; }
        }

        internal clsDataNic(String nicName) : base(3)
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            Int32 nicCount = 0;
            for (Int32 i = 0; i <= nics.GetUpperBound(0); i++)
            {
                if (nics[i].NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    if (nics[i].SupportsMulticast)
                    {
                        pDataLabels[nicCount] = nics[i].Name + " - Up";
                        nicCount++;
                    }
                }
            }
        }

        public override void UpdateValues()
        {
            pCurrentValue[0] = 0;
        }

        private static Int32 GetNumberOfNics()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            Int32 nicCount = 0;
            for (Int32 i = 0; i <= nics.GetUpperBound(0); i++)
            {
                if (nics[i].NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    if (nics[i].SupportsMulticast)
                    { nicCount++; }
                }
            }
            return nicCount;
        }

        new internal void Dispose()
        {
            base.Dispose();
        }
    }
}

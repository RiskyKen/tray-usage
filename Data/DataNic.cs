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
    public class DataNic : Data
    {
        private NetworkInterface[] _nics = null;

        private Int64[] _lastValue;

        public override string DataName
        {
            get { return "Network Interface"; }
        }

        internal DataNic() : base(GetNumberOfNics() * 3)
        {

            _nics = new NetworkInterface[GetNumberOfNics()];
            _lastValue = new Int64[(_nics.GetUpperBound(0) + 1) * 3];
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            Int32 nicCount = 0;
            for (Int32 i = 0; i <= nics.GetUpperBound(0); i++)
            {
                if (nics[i].NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    if (nics[i].SupportsMulticast)
                    {
                        if (nics[i] != null)
                        {
                            _dataLabels[(nicCount * 3)] = nics[i].Name + " - Down";
                            _dataLabels[(nicCount * 3) + 1] = nics[i].Name + " - Up";
                            _dataLabels[(nicCount * 3) + 2] = nics[i].Name + " - Total";
                            _nics[nicCount] = nics[i];

                            Int64 thisDown = _nics[(nicCount)].GetIPv4Statistics().BytesReceived;
                            Int64 thisUp = _nics[(nicCount)].GetIPv4Statistics().BytesSent;
                            Int64 thisTotal = thisDown + thisUp;



                            _lastValue[(nicCount * 3)] = thisDown;
                            _lastValue[(nicCount * 3) + 1] = thisUp;
                            _lastValue[(nicCount * 3) + 2] = thisTotal;
                            nicCount++;
                        }
                    }
                }
            }
            SetMaxValues(1);
        }

        public override void UpdateValues()
        {
            //TODO Finish network update values.
            for (Int32 i = 0; i <= _nics.GetUpperBound(0); i++)
            {
                Int64 thisDown = _nics[i].GetIPv4Statistics().BytesReceived;
                Int64 thisUp = _nics[i].GetIPv4Statistics().BytesSent;
                Int64 thisTotal = thisDown + thisUp;

                _currentValue[(i * 3)] = thisDown - _lastValue[(i * 3)];
                _currentValue[(i * 3) + 1] = thisUp - _lastValue[(i * 3) + 1];
                _currentValue[(i * 3) + 2] = thisTotal - _lastValue[(i * 3) + 2];

                _lastValue[(i * 3)] = thisDown;
                _lastValue[(i * 3) + 1] = thisUp;
                _lastValue[(i * 3) + 2] = thisTotal;
            }
            UpdateMaxValues();
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

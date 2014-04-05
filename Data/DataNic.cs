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

namespace RiskyKen.TrayUsage
{
    public class DataNic : Data
    {
        private NetworkInterface[] _nics = null;
        private UInt64[] _lastValue;

        public override string DataName
        {
            get { return "Network Interface"; }
        }

        public DataNic() : base(GetNumberOfNics() * 3)
        {
            _nics = new NetworkInterface[GetNumberOfNics()];
            _lastValue = new UInt64[(_nics.GetUpperBound(0) + 1) * 3];

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
                        }
                    }
                }
            }

            SetMaxValues(1);
        }

        public override void UpdateValues()
        {
            if (!_isAwake) { throw new Exception("Data class is sleeping."); }
            //TODO Finish network update values.
            for (Int32 i = 0; i <= _nics.GetUpperBound(0); i++)
            {
                UInt64 thisDown = (UInt64)_nics[i].GetIPv4Statistics().BytesReceived;
                UInt64 thisUp = (UInt64)_nics[i].GetIPv4Statistics().BytesSent;
                UInt64 thisTotal = thisDown + thisUp;

                _currentValue[(i * 3)] = (thisDown - _lastValue[(i * 3)]) * 1000 / (UInt64)Globals.IconUpdateRate;
                _currentValue[(i * 3) + 1] = (thisUp - _lastValue[(i * 3) + 1]) * 1000 / (UInt64)Globals.IconUpdateRate;
                _currentValue[(i * 3) + 2] = (thisTotal - _lastValue[(i * 3) + 2]) * 1000 / (UInt64)Globals.IconUpdateRate;

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

        public override void Load()
        {
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
                            _nics[nicCount] = nics[i];

                            UInt64 thisDown = (UInt64)_nics[(nicCount)].GetIPv4Statistics().BytesReceived;
                            UInt64 thisUp = (UInt64)_nics[(nicCount)].GetIPv4Statistics().BytesSent;
                            UInt64 thisTotal = thisDown + thisUp;

                            _lastValue[(nicCount * 3)] = thisDown;
                            _lastValue[(nicCount * 3) + 1] = thisUp;
                            _lastValue[(nicCount * 3) + 2] = thisTotal;
                            nicCount++;
                        }
                    }
                }
            }
        }

        public override void Unload()
        {
            //TODO Unload nics
        }
    }
}

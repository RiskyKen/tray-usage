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
        protected Int64[] _currentValue;

        protected Int64[] _maxValue;

        //Labels for data in _currentValue.
        protected string[] _dataLabels = null;

        public abstract string DataName { get; }

        protected bool _isAwake;

        protected int _useCount;

        public Data(Int32 aNumberOfValues)
        {
            _currentValue = new Int64[aNumberOfValues];
            _maxValue = new Int64[aNumberOfValues];
            _dataLabels = new string[aNumberOfValues];
            _isAwake = false;
            _useCount = 0;
        }

        protected void UpdateMaxValues()
        {
            for (Int32 i = 0; i <= _currentValue.GetUpperBound(0); i++)
            {
                if (_currentValue[i] > _maxValue[i])
                { _maxValue[i] = _currentValue[i]; }
            }
        }

        protected void SetMaxValues(Int64 value)
        {
            for (Int32 i = 0; i <= _currentValue.GetUpperBound(0); i++)
            {
                _maxValue[i] = value;
            }
        }

        public Int64[] CurrentValue
        {
            get {return _currentValue;}
        }

        public Int64[] MaxValue
        {
            get { return _maxValue; }
        }

        public string[] DataLabels
        {
            get {return _dataLabels;}
        }

        public String ReplaceIconText(String text)
        {
            String newText = text;

            if (newText.Contains(DataName + ":"))
            {
                for (Int32 i = 0; i <= _dataLabels.GetUpperBound(0); i++)
                {
                    if (newText.Contains(DataName + ":" + i.ToString()))
                    { newText = newText.Replace("{" + DataName + ":" + i.ToString() + "}", CurrentValue[i].ToString()); }
                }
            }

            return newText;
        }

        public bool IsAwake
        {
            get { return _isAwake; }
        }

        public void Wake()
        {
            if (_useCount == 0)
            {
                Load();
                _isAwake = true;
            }
            _useCount++;
        }

        public void Sleep()
        {
            _useCount--;
            if (_useCount < 1)
            {
                Unload();
                _isAwake = false;
            }
        }

        public abstract void Load();

        public abstract void Unload();

        public abstract void UpdateValues();

        public virtual void Dispose()
        {
            if (IsAwake) { Sleep(); }
        }
    }
}

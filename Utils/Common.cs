using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;

namespace RiskyKen.TrayUsage.Utils
{
    static class Common
    {
        public static string SetSizeLabel(UInt64 size)
        {
            Double thisSize = size;
            Int32 scale = 0;
            string preFix = "";

            while (thisSize > 1024)
            {
                thisSize = thisSize / 1024;
                scale++;
            }

            switch (scale)
            {
                case 0:
                    preFix = "bytes";
                    break;
                case 1:
                    preFix = "KB";
                    break;
                case 2:
                    preFix = "MB";
                    break;
                case 3:
                    preFix = "GB";
                    break;
                case 4:
                    preFix = "TB";
                    break;
            }

            thisSize = Math.Round(thisSize, 2);

            return thisSize + " " + preFix;
        }

        public static string ConvertMsToString(int msTime)
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(msTime);
            return string.Format("{0:D1}d : {1:D2}h : {2:D2}m : {3:D2}s", ts.Days, ts.Hours, ts.Minutes, ts.Seconds);
        }

        public static void SetRunningOnStartup(bool RunOnStartup)
        {
            if (!RunOnStartup)
            {
                if (GetRunningOnStartup())
                {
                    string keyName = @"Software\Microsoft\Windows\CurrentVersion\Run";
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName, true))
                    {
                        if (key != null)
                        {
                            key.DeleteValue(Application.ProductName);
                        }
                    }
                }
            }
            else
            {
                if (!GetRunningOnStartup())
                {
                    Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", Application.ProductName, Application.ExecutablePath);
                }
            }
        }

        public static bool GetRunningOnStartup()
        {
            if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", Application.ProductName, null) == null)
            { return false; }
            return true;
        }
    }
}

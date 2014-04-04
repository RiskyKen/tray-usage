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
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace RiskyKen.TrayUsage
{
    public class FullScreenCheck
    {
        public Boolean FullScreenProgramRunning
        {
            get
            {
                CheckFullScreen();
                //fullScreenRunning = true;
                return fullScreenRunning;
            }
        }

        private Boolean fullScreenRunning = false;

        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        [DllImport("User32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

        private static extern int GetWindowRect(IntPtr hWnd, ref RECT rect);
        [DllImport("User32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr GetShellWindow();
        [DllImport("User32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr GetDesktopWindow();
        [DllImport("User32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("User32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr FindWindowExW(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        private IntPtr desktopHandle;
        private IntPtr shellHandle;

        private void CheckFullScreen()
        {
            fullScreenRunning = false;

            desktopHandle = GetDesktopWindow();
            shellHandle = GetShellWindow();
            IntPtr foregroundWindow = default(IntPtr);
            foregroundWindow = GetForegroundWindow();

            foregroundWindow = WindowHasChild(foregroundWindow);

            RECT appBounds = default(RECT);
            Rectangle screenBounds = Screen.GetBounds(new Point(0, 0));

            if (!foregroundWindow.Equals(IntPtr.Zero))
            {
                if (!(foregroundWindow.Equals(desktopHandle) || foregroundWindow.Equals(shellHandle)))
                {
                    GetWindowRect(foregroundWindow, ref appBounds);
                    //determine if window is fullscreen
                    if ((appBounds.Bottom - appBounds.Top) == screenBounds.Height && (appBounds.Right - appBounds.Left) == screenBounds.Width)
                    {
                        fullScreenRunning = true;
                    }
                }
            }
        }

        //Checks if the window has a child.
        private IntPtr WindowHasChild(IntPtr hWnd)
        {
            IntPtr temphWnd = FindWindowExW(hWnd, System.IntPtr.Zero, null, null);
            if (!(temphWnd == (IntPtr)0))
            {
                return WindowHasChild(temphWnd);
            }
            return hWnd;
        }

        public void Dispose()
        { }
    }
}

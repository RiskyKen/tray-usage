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
using System.Windows.Forms;
using RiskyKen.TrayUsage.Utils;

namespace RiskyKen.TrayUsage
{
    public class UpdateHelper
    {
        //A class to handle updating and update checking.
        public Updater updater = null;

        //The tick of when we last checked for an update.
        private static Int64 _lastUpdateCheckTick = Int64.MinValue;

        //Has an update just been run?
        public static bool afterUpdate = false;

        public UpdateHelper(String ApplcationDirectory, String DownloadDirectory, Version ApplcationVersion)
        {
            updater = new Updater(ApplcationDirectory, DownloadDirectory, ApplcationVersion);
        }

        public void Dispose()
        {
            updater.Dispose();
        }

        //Checks if we need to check for updates.
        public void CheckForUpdatesIfNeeded()
        {
            if (afterUpdate)
            {
                IconManager.ShowBalloonPopup(Application.ProductName, "Successfully updated to version " + Application.ProductVersion + ".", ToolTipIcon.Info);
                afterUpdate = false;
                if (Common.GetRunningOnStartup())
                {
                    Common.SetRunningOnStartup(false);
                    Common.SetRunningOnStartup(true);
                }
            }
            if (Globals.UpdateCheckTime == 0) { return; }
            if (_lastUpdateCheckTick + Globals.UpdateCheckTime < Environment.TickCount)
            { UpdateCheck(); }
        }

        //Checks for updates.
        private void UpdateCheck()
        {
            _lastUpdateCheckTick = Environment.TickCount;
            updater.UpdateCheckFinished += UpdateCheckReturn;
            updater.CheckForUpdatesAsync(Globals.UpdateUrlMain);
        }

        //Fires when an update check has finished.
        private void UpdateCheckReturn(Updater.UpdateCheckResult result)
        {
            updater.UpdateCheckFinished -= UpdateCheckReturn;
            if (!result.UpdateAvailable) { return; }

            if (Globals.AutoUpdate)
            {
                IconManager.ShowBalloonPopup(Application.ProductName, "Downloading update: " + result.LatestVersion.ToString(), ToolTipIcon.Info);
                DownloadUpdate(result.UpdateFileListUrl);
            }
            else
            { IconManager.ShowBalloonPopup(Application.ProductName, "Update available: " + result.LatestVersion.ToString(), ToolTipIcon.Info); }
        }

        //Start downloading an update
        public void DownloadUpdate(String updateFileListUrl)
        {
            updater.DownloadUpdateFinished += DownloadUpdateReturn;
            updater.DownloadUpdateAsync(updateFileListUrl);
        }

        //Fired when the update download is finished.
        private void DownloadUpdateReturn(Updater.DownloadUpdateResult result)
        {
            updater.DownloadUpdateFinished -= DownloadUpdateReturn;
            if (result.Success)
            {
                Program.updateRunFileList = result.RunFiles;
                Program.updateRestart = true;
                Program.updateLoopRunning = false;
            }
            else
            {
                IconManager.ShowBalloonPopup(Application.ProductName, result.Message, ToolTipIcon.Info);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrayUsage
{
    public class UpdateHelper
    {
        //A class to handle updating and update checking.
        public Updater updater = null;

        //The tick of when we last checked for an update.
        private static Int64 _lastUpdateCheckTick = Int64.MinValue;

        public UpdateHelper(String ApplcationDirectory, String DownloadDirectory, Version ApplcationVersion)
        {
            updater = new Updater(ApplcationDirectory, DownloadDirectory, ApplcationVersion);
        }

        public void Dispose()
        {
            updater.Dispose();
        }

        //Checks if we need to check for updates.
        public void CheckForUpdates()
        {
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
            { Program.updateRestart = true; Program.updateLoopRunning = false; }
            else
            { IconManager.ShowBalloonPopup(Application.ProductName, result.Message, ToolTipIcon.Info); }
        }
    }
}

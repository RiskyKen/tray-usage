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
using System.Threading;
using System.Xml;
using System.Diagnostics;

namespace TrayUsage
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        //A class handling all data collection.
        public static clsDataManager DataManager = null;

        //A class that checks if a fullscreen application is running.
        public static FullScreenCheck fullScreenCheck = null;

        //A class to handle updating and update checking.
        public static Updater updater = null;

        //The options form.
        public static frmOptions OptionsForm = null;

        //The update form.
        public static frmUpdate UpdateForm = null;

        //Is the main update loop running?
        public static Boolean UpdateLoopRunning = false;

        //The thread that the main update loop runs on.
        public static Thread UpdateThread = null;

        //Class for loading and saving settings.
        public static Settings SettingsClass = null;

        //The tick of when we last checked for an update.
        private static Int64 lastUpdateCheckTick = Int64.MinValue;

        //Are we restarting the program for an update?
        public static Boolean updateRestart = false;

        //Program starts here! :)
        [STAThread]
        static void Main(String[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Globals.LoadPresetColors();
            DataManager = new clsDataManager();
            SettingsClass = new Settings();
            updater = new Updater(Application.StartupPath, Globals.FileDownloadPath,new Version(Application.ProductVersion));
            fullScreenCheck = new FullScreenCheck();
            IconManager.LoadIcons();
            LoadSettingFile();
            
            //UpdateCheck();

            StartUpdateLoop();
            Application.Run();

            updater.Dispose();
            fullScreenCheck.Dispose();
            SettingsClass.Save();
            IconManager.Dispose();
            DataManager.Dispose();
            SettingsClass.Dispose();

            if (updateRestart)
            { System.Diagnostics.Process.Start(Application.ExecutablePath, "-update"); }
        }

        //Starts the main update loop.
        private static void StartUpdateLoop()
        {
            UpdateLoopRunning = true;
            UpdateThread = new Thread(UpdateLoop);
            UpdateThread.Priority = Globals.UpdateThreadPriority;
            UpdateThread.Start();
        }

        //Main update loop.
        private static void UpdateLoop()
        {
            while (UpdateLoopRunning)
            {
                Boolean sleeping = false;
                if (Globals.FullscreenSleep) { sleeping = fullScreenCheck.FullscreenProgramRunning; }
                DataManager.UpdateValues();
                IconManager.UpdateIcons(sleeping);
                CheckForUpdates();
                if (sleeping) { Thread.Sleep(Globals.SleepTime); }
                else { Thread.Sleep(Globals.IconUpdateRate); }
                
            }
            Application.Exit();
        }

        //Checks if we need to check for updates.
        private static void CheckForUpdates()
        {
            if (Globals.UpdateCheckTime == 0) { return; }
            if (lastUpdateCheckTick + Globals.UpdateCheckTime < Environment.TickCount)
            { UpdateCheck(); }
        }

        //Checks for updates.
        private static void UpdateCheck()
        {
            lastUpdateCheckTick = Environment.TickCount;
            updater.UpdateCheckFinished += UpdateCheckReturn;
            updater.CheckForUpdatesAsync(Globals.UpdateUrlMain);
        }

        //Fires when an update check has finished.
        private static void UpdateCheckReturn(Updater.UpdateCheckResult result)
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
        private static void DownloadUpdate(String updateFileListUrl)
        {
            updater.DownloadUpdateFinished += DownloadUpdateReturn;
            updater.DownloadUpdateAsync(updateFileListUrl);
        }

        //Fired when the update download is finished.
        private static void DownloadUpdateReturn(Updater.DownloadUpdateResult result)
        {
            updater.DownloadUpdateFinished -= DownloadUpdateReturn;
            if (result.Success)
            { updateRestart = true; UpdateLoopRunning = false; }
            else
            { IconManager.ShowBalloonPopup(Application.ProductName, result.Message, ToolTipIcon.Info);  }
        }

        //Loaded the settings file if it exists.
        private static void LoadSettingFile()
        {
            if (System.IO.File.Exists(Globals.SettingsFilePath))
            {
                SettingsClass.Load(Globals.SettingsFilePath);
            }
        }

        public static void SaveSettings()
        {
            SettingsClass.Save(Globals.SettingsFilePath);
        }
    }
}

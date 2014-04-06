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

namespace RiskyKen.TrayUsage
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        //A class that checks if a fullscreen application is running.
        public static FullScreenCheck fullScreenCheck = null;

        //A class to handle updating and update checking.
        public static UpdateHelper updateHelper = null;

        //Helps with opening program forms.
        public static FormHelper formHelper = null;

        //Is the main update loop running?
        public static Boolean updateLoopRunning = false;

        //The thread that the main update loop runs on.
        public static Thread updateThread = null;

        //Class for loading and saving settings.
        public static Settings settingsClass = null;

        //The tick that the program started on.
        public static Int32 startTick = 0;

        //Are we restarting the program for an update?
        public static Boolean updateRestart = false;

        //What file should be run for the restart?
        public static string[] updateRunFileList = null;

        //Program starts here! :)
        [STAThread]
        public static void Main(String[] args)
        {
            ParseArguments(args);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ThreadExceptionHandler.Init();
            Globals.LoadPresetColors();
            LoadClasses();
            LoadSettingFile();
            IconManager.ShowAllIcons();
            StartUpdateLoop();
            Application.Run();
            settingsClass.Save();
            DisposeClasses();
            if (updateRestart)
            {
                if (updateRunFileList != null)
                {
                    foreach (string file in updateRunFileList)
                    {
                        System.Diagnostics.Process.Start(Application.StartupPath + file, "-update");
                    }
                }
                else
                {
                    MessageBox.Show("No run list found.\nRunning normal program.", Application.ProductName);
                    System.Diagnostics.Process.Start(Application.ExecutablePath, "-update");
                }
            }
        }

        private static void LoadClasses()
        {
            formHelper = new FormHelper();
            DataManager.Init();
            IconManager.Init();
            Render.RenderRegistry.Init();
            settingsClass = new Settings();
            updateHelper = new UpdateHelper(Application.StartupPath, Globals.FileDownloadPath, new Version(Application.ProductVersion));
            fullScreenCheck = new FullScreenCheck();
            IconManager.LoadIcons();
        }

        private static void DisposeClasses()
        {
            updateHelper.Dispose();
            fullScreenCheck.Dispose();
            IconManager.Dispose();
            DataManager.Dispose();
            settingsClass.Dispose();
            formHelper.Dispose();
        }

        //Starts the main update loop.
        private static void StartUpdateLoop()
        {
            updateLoopRunning = true;
            updateThread = new Thread(UpdateLoop);
            updateThread.Priority = Globals.UpdateThreadPriority;
            startTick = Environment.TickCount;
            updateThread.Start();
        }

        //Main update loop.
        private static void UpdateLoop()
        {
            while (updateLoopRunning)
            {
                Boolean sleeping = false;
                if (Globals.FullscreenSleep) { sleeping = fullScreenCheck.FullScreenProgramRunning; }
                DataManager.UpdateValues();
                IconManager.UpdateIcons(sleeping);
                updateHelper.CheckForUpdatesIfNeeded();
                if (sleeping) { Thread.Sleep(Globals.SleepTime); }
                else { Thread.Sleep(Globals.IconUpdateRate); }
                
            }
            Application.Exit();
        }

        private static void ParseArguments(String[] args)
        {
            foreach (string arg in args)
            {
                switch (arg)
                {
                    case "-update":
                        UpdateHelper.afterUpdate = true;
                        break;
                }
            }
        }

        //Loads the settings file if it exists.
        private static void LoadSettingFile()
        {
            if (System.IO.File.Exists(Globals.SettingsFilePath))
            {
                settingsClass.Load(Globals.SettingsFilePath);
            }
            else
            {
                IconManager.MakeDefaultIcons();
            }
        }
    }
}

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
using System.Net;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;

namespace RiskyKen.TrayUsage
{
    public class Updater
    {
        public delegate void UpdateCheckFinishedHandler(UpdateCheckResult result);
        public event UpdateCheckFinishedHandler UpdateCheckFinished;
        public struct UpdateCheckResult
        {
            public Boolean UpdateAvailable;
            public Version LatestVersion;
            public String ChangeLogUrl;
            public String UpdateFileListUrl;
        }

        public delegate void DownloadUpdateFinishedHandler(DownloadUpdateResult result);
        public event DownloadUpdateFinishedHandler DownloadUpdateFinished;
        public struct DownloadUpdateResult
        {
            public Boolean Success;
            public String Message;
            public String[] RunFiles;
        }

        public delegate void DownloadChangeLogFinishedHandler(DownloadChangeLogResult result);
        public event DownloadChangeLogFinishedHandler DownloadChangeLogFinished;
        public struct DownloadChangeLogResult
        {
            public Boolean Success;
            public String LogText;
        }

        private struct DownloadFileInfo
        {
            public String Path;
            public String Url;
            public String Hash;
            public String Action;
            public String Name;
            public Int64 Size;
        }

        //Used todo tasks in a background thread.
        private BackgroundWorker bgWorker = null;

        //Place to put downloaded files.
        private String downloadDirectory;

        //Application directory.
        private String appDirectory;

        //Version of this applcation.
        private Version appVersion;

        public Updater(String ApplcationDirectory, String DownloadDirectory, Version ApplcationVersion)
        {
            appDirectory = ApplcationDirectory;
            downloadDirectory = DownloadDirectory;
            appVersion = ApplcationVersion;
        }

        public void Dispose()
        { }

        public void CheckForUpdatesAsync(String UpdateCheckUrl)
        {
            Debug.WriteLine("Starting update check.");
            if (bgWorker != null) { return; }
            bgWorker = new BackgroundWorker();
            bgWorker.WorkerReportsProgress = false;
            bgWorker.WorkerSupportsCancellation = false;

            bgWorker.DoWork += new DoWorkEventHandler(CheckForUpdatesDoWork);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CheckForUpdatesCompleted);
            bgWorker.RunWorkerAsync(UpdateCheckUrl);
        }

        //Check to see if there is an update.
        private void CheckForUpdatesDoWork(object sender, DoWorkEventArgs e)
        {
            UpdateCheckResult result = new UpdateCheckResult();
            result.LatestVersion = new Version();
            String downloadedText = DownloadString((String)e.Argument);

            if (downloadedText == null) { e.Result = result; return; }

            String[] lines = StringToLines(downloadedText);

            for (Int32 i = 0; i <= lines.GetUpperBound(0); i++)
            {
                String[] splitLine = lines[i].Split(new String[] { "=" }, StringSplitOptions.None);
                switch (splitLine[0].ToLower())
                {
                    case "version":
                        result.LatestVersion = new Version(splitLine[1]);
                        if (result.LatestVersion > appVersion)
                        { result.UpdateAvailable = true;}
                        break;
                    case "change log":
                        result.ChangeLogUrl = splitLine[1];
                        break;
                    case "url":
                        result.UpdateFileListUrl = splitLine[1];
                        break;
                }
            }
            e.Result = result;
        }

        //Fired when checking for updates has finished.
        private void CheckForUpdatesCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bgWorker.DoWork -= CheckForUpdatesDoWork;
            bgWorker.RunWorkerCompleted -= CheckForUpdatesCompleted;
            bgWorker.Dispose();
            bgWorker = null;
            Debug.WriteLine("Finished update check.");
            if (UpdateCheckFinished != null)
            { UpdateCheckFinished((UpdateCheckResult)e.Result); }
        }

        //Download the update.
        public void DownloadUpdateAsync(String updateFileListUrl)
        {
            if (bgWorker != null) { return; }
            bgWorker = new BackgroundWorker();
            bgWorker.WorkerReportsProgress = false;
            bgWorker.WorkerSupportsCancellation = false;

            bgWorker.DoWork += new DoWorkEventHandler(DownloadUpdateDoWork);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(DownloadUpdateCompleted);
            bgWorker.RunWorkerAsync(updateFileListUrl);
        }

        //Check to see if there is an update.
        private void DownloadUpdateDoWork(object sender, DoWorkEventArgs e)
        {
            DownloadUpdateResult result = new DownloadUpdateResult();
            String fileList = DownloadString((String)e.Argument);
            if (fileList == null)
            { result.Message = "Failed to download update file list."; e.Result = result; return; }
            String[] fileListLines = StringToLines(fileList);

            DownloadFileInfo[] filesList = StringToDownloadFilesArray(fileListLines);
            DownloadFileInfo[] filesToDownload = CheckFilesToDownload(filesList);

            if (filesToDownload == null)
            { result.Message = "No files need downloaded."; e.Result = result; return; }

            DownloadFiles(filesToDownload);

            if (!HashCheckDownloadFiles(filesToDownload))
            { result.Message = "Download hash check failed."; e.Result = result; return; }

            InstallDownloadedFiles(filesList, filesToDownload);

            foreach (DownloadFileInfo fileInfo in filesList)
            {
                if (fileInfo.Action == "Run")
                {
                    if (result.RunFiles == null)
                    {
                        result.RunFiles = new String[1];
                    }
                    else
                    {
                        Array.Resize(ref result.RunFiles, result.RunFiles.GetUpperBound(0) + 2);
                    }
                    result.RunFiles[result.RunFiles.GetUpperBound(0)] = fileInfo.Path + fileInfo.Name;
                }
            }

            result.Success = true;
            result.Message = "Download finished!";

            e.Result = result;
        }

        //Splits a string array into download files array.
        private DownloadFileInfo[] StringToDownloadFilesArray(String[] downloadList)
        {
            DownloadFileInfo[] filesList = null;
            Int32 currentFileIndex = -1;
            for (Int32 i = 0; i <= downloadList.GetUpperBound(0); i++)
            {
                String[] lineSplit = downloadList[i].Split(new String[] { "=" }, StringSplitOptions.None);
                switch (lineSplit[0])
                {
                    case "FileInfoStart":
                        if (filesList == null) { filesList = new DownloadFileInfo[1]; }
                        else { Array.Resize(ref filesList, filesList.GetUpperBound(0) + 2); }
                        currentFileIndex = filesList.GetUpperBound(0);
                        break;
                    case "PATH":
                        filesList[currentFileIndex].Path = lineSplit[1];
                        break;
                    case "URL":
                        filesList[currentFileIndex].Url = lineSplit[1];
                        break;
                    case "HASH":
                        filesList[currentFileIndex].Hash = lineSplit[1];
                        break;
                    case "ACTION":
                        filesList[currentFileIndex].Action = lineSplit[1];
                        break;
                    case "NAME":
                        filesList[currentFileIndex].Name = lineSplit[1];
                        break;
                    case "SIZE":
                        filesList[currentFileIndex].Size = Int64.Parse(lineSplit[1]);
                        break;
                }
            }
            return filesList;
        }

        //Downloads an array of files
        private void DownloadFiles(DownloadFileInfo[] files)
        {
            WebClient wc = new WebClient();
            if (!Directory.Exists(downloadDirectory))
            { Directory.CreateDirectory(downloadDirectory); }

            for (Int32 i = 0; i <= files.GetUpperBound(0); i++)
            {
                if (File.Exists(downloadDirectory + files[i].Path + files[i].Name))
                { File.Delete(downloadDirectory + files[i].Path + files[i].Name); }

                if (!Directory.Exists(downloadDirectory + files[i].Path))
                { Directory.CreateDirectory(downloadDirectory + files[i].Path); }

                wc.DownloadFile(files[i].Url, downloadDirectory + files[i].Path + files[i].Name);
            }
            wc.Dispose();
        }

        //Checks to make sure the downloaded files are ok.
        private Boolean HashCheckDownloadFiles(DownloadFileInfo[] files)
        {
            for (Int32 i = 0; i <= files.GetUpperBound(0); i++)
            {
                if (File.Exists(downloadDirectory + files[i].Path + files[i].Name))
                {
                    if (MD5CalcFile(downloadDirectory + files[i].Path + files[i].Name) != files[i].Hash)
                    { return false; }
                }
            }
            return true;
        }

        //Copys the files from the temp download location to the application directory.
        private void InstallDownloadedFiles(DownloadFileInfo[] allFiles, DownloadFileInfo[] downloadFiles)
        {
            RenameOldFiles(downloadFiles);

            for (Int32 i = 0; i <= downloadFiles.GetUpperBound(0); i++)
            {
                String newFilepath = appDirectory + downloadFiles[i].Path + downloadFiles[i].Name;
                String oldFilepath = downloadDirectory + downloadFiles[i].Path + downloadFiles[i].Name;

                if (File.Exists(oldFilepath))
                {
                    if (!Directory.Exists(appDirectory + downloadFiles[i].Path))
                    { Directory.CreateDirectory(appDirectory + downloadFiles[i].Path); }

                    File.Move(oldFilepath, newFilepath);
                }
            }
        }

        //Renames the old files
        private void RenameOldFiles(DownloadFileInfo[] files)
        {
            for (Int32 i = 0; i <= files.GetUpperBound(0); i++)
            {
                String filename = appDirectory + files[i].Path + files[i].Name;
                if (File.Exists(filename))
                {
                    if (File.Exists(filename + ".old")) { File.Delete(filename + ".old"); }
                    File.Move(filename, filename + ".old");
                }
            }
        }

        //Fired when checking for updates has finished.
        private void DownloadUpdateCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bgWorker.DoWork -= DownloadUpdateDoWork;
            bgWorker.RunWorkerCompleted -= DownloadUpdateCompleted;
            bgWorker.Dispose();
            bgWorker = null;
            if (DownloadUpdateFinished != null)
            { DownloadUpdateFinished((DownloadUpdateResult)e.Result); }
        }

        //Checks what files we already have. Returns files that need to be downloaded.
        private DownloadFileInfo[] CheckFilesToDownload(DownloadFileInfo[] files)
        {
            DownloadFileInfo[] returnFiles = null;

            for (Int32 i = 0; i <= files.GetUpperBound(0); i++)
            {
                String hashPath = appDirectory + @"\" + files[i].Path + files[i].Name;

                if (FileNeedsDownloaded(files[i].Hash, hashPath))
                {
                    if (returnFiles == null) { returnFiles = new DownloadFileInfo[1]; }
                    else { Array.Resize(ref returnFiles, returnFiles.GetUpperBound(0) + 2); }
                    returnFiles[returnFiles.GetUpperBound(0)] = files[i];
                }

            }

            return returnFiles;
        }

        //Checks if a file needs to be downloaded
        private Boolean FileNeedsDownloaded(String hash, String path)
        {
            if (!File.Exists(path)) { return true; }
            if (MD5CalcFile(path) != hash) { return true; }
            return false;
        }

        //Trys to download a string.
        private String DownloadString(String url)
        {
            String downloadString = null;
            WebClient wc = new WebClient();
            try
            { downloadString = wc.DownloadString(url); }
            catch { }
            wc.Dispose();
            return downloadString;
        }

        //Splits a multi line string into a string array.
        private String[] StringToLines(String value)
        {
            return value.Split(new String[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string MD5CalcFile(string filepath)
        {
            using (System.IO.FileStream reader = new System.IO.FileStream(filepath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                using (System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider())
                {
                    byte[] hash = md5.ComputeHash(reader);
                    return ByteArrayToString(hash);
                }
            }
        }

        private static string ByteArrayToString(byte[] arrInput)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(arrInput.Length * 2);
            for (int i = 0; i <= arrInput.Length - 1; i++)
            {
                sb.Append(arrInput[i].ToString("X2"));
            }
            return sb.ToString().ToLower();
        }
    }
}
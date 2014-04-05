using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.VisualBasic.Devices;
using RiskyKen.TrayUsage.Utils;
using System.Windows.Forms;

namespace RiskyKen.TrayUsage
{
    public static class ThreadExceptionHandler
    {
        public static void Init()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            SaveCrashDump(sender, e);
        }

        private static void SaveCrashDump(object sender, UnhandledExceptionEventArgs e)
        {
            ComputerInfo computerInfo = new ComputerInfo();
            StreamWriter sr = new StreamWriter(Globals.CrashDumpFilePath, true);

            sr.WriteLine("Processor Count: " + Environment.ProcessorCount.ToString());
            sr.WriteLine("OS Name: " + computerInfo.OSFullName);
            sr.WriteLine("OS Platform: " + computerInfo.OSPlatform);
            sr.WriteLine("OS Version: " + computerInfo.OSVersion);
            sr.WriteLine("Working Set: " + Common.SetSizeLabel((UInt64)Environment.WorkingSet));
            sr.WriteLine("Uptime: " + ((Environment.TickCount - Program.startTick) / 1000).ToString());
            sr.WriteLine();
            sr.WriteLine(e.ExceptionObject.ToString());
            sr.Flush();
            sr.Close();
            sr.Dispose();

            MessageBox.Show(e.ExceptionObject.ToString(), Application.ProductName + " - Application Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }
    }
}
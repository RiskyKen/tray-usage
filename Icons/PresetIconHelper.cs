using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace RiskyKen.TrayUsage.Icons
{
    public static class PresetIconHelper
    {
        public static bool AddPersetIcon(string name)
        {
            switch (name)
            {
                case "CPU":
                    AddCpuPerset();
                    return true;
                case "RAM":
                    AddRamPerset();
                    return true;
                case "Network":
                    AddNetworkPreset();
                    return true;
                case "Disk Space":
                    AddDiskSpacePreset();
                    return true;
                case "Disk Access":
                    AddDiskAccessPreset();
                    return true;
                case "Battery":
                    AddBatteryPreset();
                    return true;

            }
            return false;
        }

        private static void AddCpuPerset()
        {
            int coreCount = Environment.ProcessorCount;

            DataLink[] dataLink;

            if (coreCount > 1 && coreCount <= 4)
            {
                dataLink = new DataLink[coreCount];
                for (int i = 0; i < coreCount; i++)
                {
                    dataLink[i] = new DataLink();
                    dataLink[i].DataIndex = i + 1;
                    dataLink[i].DataClassRef = DataManager.GetDataClassRef("CPU");
                }
            }
            else
            {
                dataLink = new DataLink[1];
                dataLink[0].DataIndex = 0;
                dataLink[0].DataClassRef = DataManager.GetDataClassRef("CPU");
            }

            IconManager.AddIcon("CPU", "{iconname} - {CPU%0}%", dataLink,
                Globals.colorPresets[12].BackgroundColor, Globals.colorPresets[12].ForegroundColor);
        }

        private static void AddRamPerset()
        {
            DataLink[] dataLink = new DataLink[1];
            dataLink[0] = new DataLink();
            dataLink[0].DataIndex = 0;
            dataLink[0].DataClassRef = DataManager.GetDataClassRef("Memory");

            IconManager.AddIcon("Memory", @"{iconname} - {Memory%0}%\n\n{Memory#!0} - {Memory*!0}", dataLink,
                Globals.colorPresets[11].BackgroundColor, Globals.colorPresets[11].ForegroundColor);
        }

        private static void AddNetworkPreset()
        {
            DataLink[] dataLink = new DataLink[2];
            dataLink[0] = new DataLink();
            dataLink[1] = new DataLink();

            dataLink[0].DataIndex = 0;
            dataLink[0].DataClassRef = DataManager.GetDataClassRef("Network Interface");

            dataLink[1].DataIndex = 1;
            dataLink[1].DataClassRef = DataManager.GetDataClassRef("Network Interface");

            IconManager.AddIcon("Network", @"{iconname}\n\n{Network Interface#!0} - {Network Interface*!0}\n{Network Interface#!1} - {Network Interface*!1}", dataLink,
                Globals.colorPresets[2].BackgroundColor, Globals.colorPresets[2].ForegroundColor);
        }

        private static void AddDiskSpacePreset()
        {
            int driveCount = DataDiskSpace.GetDriveCount();

            DataLink[] dataLink;

            if (driveCount > 1 && driveCount <= 4)
            {
                dataLink = new DataLink[driveCount];
                for (int i = 0; i < driveCount; i++)
                {
                    dataLink[i] = new DataLink();
                    dataLink[i].DataIndex = i;
                    dataLink[i].DataClassRef = DataManager.GetDataClassRef("Disk Space");
                }
            }
            else
            {
                dataLink = new DataLink[1];
                dataLink[0].DataIndex = 0;
                dataLink[0].DataClassRef = DataManager.GetDataClassRef("Disk Space");
            }

            IconManager.AddIcon("Disk Space", "{iconname}", dataLink,
                Globals.colorPresets[8].BackgroundColor, Globals.colorPresets[8].ForegroundColor);
        }

        private static void AddDiskAccessPreset()
        {
            int driveCount = DataDiskAccess.GetHardDriveCount();

            DataLink[] dataLink;

            if (driveCount > 1 && driveCount <= 4)
            {
                dataLink = new DataLink[driveCount];
                for (int i = 0; i < driveCount; i++)
                {
                    dataLink[i] = new DataLink();
                    dataLink[i].DataIndex = i + 1;
                    dataLink[i].DataClassRef = DataManager.GetDataClassRef("Disk Access");
                }
            }
            else
            {
                dataLink = new DataLink[1];
                dataLink[0].DataIndex = 0;
                dataLink[0].DataClassRef = DataManager.GetDataClassRef("Disk Access");
            }

            IconManager.AddIcon("Disk Access", "{iconname}", dataLink,
                Globals.colorPresets[10].BackgroundColor, Globals.colorPresets[10].ForegroundColor);
        }

        private static void AddBatteryPreset()
        {
            DataLink[] dataLink = new DataLink[1];
            dataLink[0] = new DataLink();
            dataLink[0].DataIndex = 0;
            dataLink[0].DataClassRef = DataManager.GetDataClassRef("Battery");

            IconManager.AddIcon("Battery", @"{iconname} - {Battery%0}%", dataLink,
                Globals.colorPresets[4].BackgroundColor, Globals.colorPresets[4].ForegroundColor);
        }
    }
}

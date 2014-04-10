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
using System.Diagnostics;
using System.Drawing;

namespace RiskyKen.TrayUsage
{
    public partial class TrayIcon
    {
        //The name of this icon.
        private string _iconName = null;

        //The rollover text for the icon.
        private String _rolloverText = "";

        //The notify icon that is seen in the system tray.
        private NotifyIcon trayIcon = null;

        //The target data class.
        protected DataLink[] _targetData = null;

        //The renderer that this icon will use.
        public Renderer renderer = null;

        //Constructor
        public TrayIcon(string aIconName, String aRolloverText, DataLink[] aTargetData, Color BackgroundColor, Color ForegroundColor)
        {
            _iconName = aIconName;
            _rolloverText = aRolloverText;

            renderer = new RendererBasic();
            ((RendererBasic)renderer).BackgroundColour = BackgroundColor;
            ((RendererBasic)renderer).ForegroundColour = ForegroundColor;
            ((RendererBasic)renderer).UseAlpha = true;

            if (aTargetData != null)
            {
                foreach (DataLink dataLink in aTargetData)
                {
                    AddDataSource(dataLink);
                }
            }

            MakeTrayIcon();
        }

        private void MakeTrayIcon()
        {
            trayIcon = new NotifyIcon();
            trayIcon.ContextMenu = IconManager.TrayMenu.Menu;
            //UpdateRolloverText();
            //UpdateName();
            //TrayIcon.Text = IconName;
            RenderIcon(false);
            //trayIcon.Visible = true;
            trayIcon.DoubleClick += TrayIcon_DoubleClick;
        }

        public void RenderIcon(Boolean sleeping)
        {
            Int32[] iconValues = renderer.ConvertToIconValues(_targetData);
            if (renderer.NeedRedraw(iconValues, sleeping))
            {
                if (!renderer.isSleeping)
                { trayIcon.Icon = renderer.RenderIcon(iconValues, sleeping); }
                else
                {
                    if (!sleeping)
                    { trayIcon.Icon = renderer.RenderIcon(iconValues, sleeping); }
                }
            }
            UpdateRolloverText();
        }

        public void Hide()
        { trayIcon.Visible = false; }

        public void Show()
        { trayIcon.Visible = true; }

        public void Reload()
        {
            renderer.Reload();
        }

        public void ShowBalloonPopup(String title, String text, ToolTipIcon icon)
        {
            trayIcon.ShowBalloonTip(2000, title, text, icon);
        }

        public void AddDataSource(DataLink aDataLink)
        {
            if (aDataLink.DataClassRef == null) { return; }
            if (_targetData == null)
            {
                _targetData = new DataLink[1];
            }
            else
            {
                Array.Resize(ref _targetData, _targetData.GetUpperBound(0) + 2);
            }
            if (aDataLink.DataClassRef != null)
            {
                _targetData[_targetData.GetUpperBound(0)] = aDataLink;
                aDataLink.DataClassRef.Wake();
                //UpdateName();
                renderer.ForceIconRedraw();
            }
        }

        public void RemoveDataSource(Int32 aIndex)
        {
            if (_targetData == null) { return; }

            _targetData[aIndex].DataClassRef.Sleep();

            if (_targetData.GetUpperBound(0) == 0)
            {
                _targetData = null;
                return;
            }

            DataLink[] tempLink = null;
            tempLink = new DataLink[_targetData.GetUpperBound(0)];

            Int32 j = 0;

            for (Int32 i = 0; i <= _targetData.GetUpperBound(0); i++)
            {
                if (i != aIndex)
                {
                    tempLink[j] = _targetData[i];
                    j++;
                }
            }
            _targetData = tempLink;
            //UpdateName();
            renderer.ForceIconRedraw();
        }

        private void RemoveAllDataSources()
        {
            if (_targetData == null) { return; }

            for (int i = 0; i <= _targetData.GetUpperBound(0); i++)
            {
                _targetData[i].DataClassRef.Sleep();
            }
        }

        public List<string> GetDataSourcesList()
        {
            if (_targetData == null) { return null; }
            List<string> result = new List<string>();

            for (int i = 0; i <= _targetData.GetUpperBound(0); i++)
            {
                result.Add(_targetData[i].DataClassRef.DataName + " " +
                    _targetData[i].DataClassRef.DataLabels[_targetData[i].DataIndex]);
            }

            return result;
        }

        public void MoveDataSourceUp(Int32 index)
        {
            DataLink tempDataLink = _targetData[index];
            _targetData[index] = _targetData[index - 1];
            _targetData[index - 1] = tempDataLink;
        }

        public void MoveDataSourceDown(Int32 index)
        {
            DataLink tempDataLink = _targetData[index];
            _targetData[index] = _targetData[index + 1];
            _targetData[index + 1] = tempDataLink;
        }

        public void ChangeRenderer(string NewRenderer)
        {
            lock (IconManager._iconLock)
            {
                switch (NewRenderer)
                {
                    case "Basic":
                        renderer.Dispose();
                        renderer = new RendererBasic();
                        break;

                    case "History":
                        renderer.Dispose();
                        renderer = new RendererHistory();
                        break;

                    case "Image":
                        renderer.Dispose();
                        renderer = new RendererImage();
                        break;
                }
            }
        }

        public string IconName
        {
            get { return _iconName; }
            set {
                    _iconName = value;
                }
        }

        public string RolloverText
        {
            get { return _rolloverText; }
            set
            {
                _rolloverText = value;
                UpdateRolloverText();
            }
        }

        private void UpdateRolloverText()
        {
            trayIcon.Text = ReplaceIconText(RolloverText);
        }

        private String ReplaceIconText(String text)
        {
            String newText;

            newText = text.Replace("{iconname}", IconName);
            newText = newText.Replace(@"\n", "\n");

            newText = DataManager.ReplaceIconText(newText);

            if (newText.Length > 63)
            {
                newText = newText.Remove(newText.Length - (newText.Length - 60), newText.Length - 60) + "...";
            }

            return newText;
        }

        private void TrayIcon_DoubleClick(object sender, System.EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                IconManager.TrayMenu.TrayIcon_DoubleClick();
            }
        }

        public void Dispose()
        {
            RemoveAllDataSources();
            if (renderer != null)
            { renderer.Dispose(); }
            trayIcon.DoubleClick -= TrayIcon_DoubleClick;
            trayIcon.Visible = false;
            trayIcon.Dispose();
        }


    }
}

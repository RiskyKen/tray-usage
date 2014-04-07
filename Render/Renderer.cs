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
using System.Drawing;
using System.Xml;

namespace RiskyKen.TrayUsage
{
    public abstract class Renderer 
    {
        ///<summary>Number of times this icon has rendered.</summary>
        public UInt32 RenderCount = 0;

        ///<summary>Number of times this icon has rendered.</summary>
        public abstract Int32 MaxValues { get; }

        ///<summary>The drawing rectangle within the icon.</summary>
        protected Rectangle DrawingSize;

        protected Int32[] LastValue = null;

        ///<summary>True if the icon is sleeping.</summary>
        public Boolean isSleeping = false;

        ///<summary>Range of values the icon can display from one data input.</summary>
        protected Int32 valueScale;

        public abstract string Name { get; }

        public abstract string Discription { get; }

        protected Bitmap SleepingImage = null;

        //Should the icon be redrawn, even if the input value is the same? 
        public Boolean AlwaysRedraw = false;

        //Constructor
        public Renderer()
        {
            LastValue = new Int32[MaxValues];
        }

        //TODO Move some xml reading in here.
        public Renderer(XmlReader aR)
        {
            LastValue = new Int32[MaxValues];

            while (aR.Read())
            {
                switch (aR.NodeType)
                {
                    case XmlNodeType.Element:
                        ReadXmlElement(aR, aR.Name);
                        break;
                    case XmlNodeType.EndElement:
                        if (aR.Name == "Renderer" + Name) { return; }
                        break;
                }
            }
        }

        public void ForceIconRedraw()
        {
            for (Int32 i = 0; i <= MaxValues - 1; i++)
            { LastValue[i] = -1; }
        }

        public abstract void Reload();

        protected abstract void PostInt();

        private void ReadXmlElement(XmlReader aR, string aName)
        {
            while (aR.Read())
            {
                switch (aR.NodeType)
                {
                    case XmlNodeType.Text:
                        LoadXmlElement(aName,aR.Value);
                        break;
                    case XmlNodeType.EndElement:
                        return;
                }
            }
        }

        public abstract void LoadXmlElement(string aName,string aValue);

        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern bool DestroyIcon(IntPtr hIcon);

        //Draws a line border onto an image.
        protected static Bitmap drawBorder(Bitmap image)
        {
            //top left to bottom left
            Graphics.FromImage(image).DrawLine(Pens.Gray, 0, 0, 14, 0);
            //top left to top right
            Graphics.FromImage(image).DrawLine(Pens.Gray, 0, 1, 0, 15);
            //bottom left to bottom right
            Graphics.FromImage(image).DrawLine(Pens.White, 15, 0, 15, 14);
            //top right to bottom right
            Graphics.FromImage(image).DrawLine(Pens.White, 1, 15, 15, 15);
            return image;
        }

        //Converts a bmp to an icon.
        public static Icon bmpToIcon(Bitmap image)
        {
            IntPtr HIcon = image.GetHicon();
            //must be cloned for windows xp. bug?
            Icon tempIcon = (Icon)Icon.FromHandle(HIcon).Clone();
            DestroyIcon(HIcon);
            return tempIcon;
        }

        //Do we need to redraw this icon.
        public virtual Boolean NeedRedraw(Int32[] aValues, Boolean sleeping)
        {
            if (Globals.AlwaysRedrawIcons) { return true; }
            if (AlwaysRedraw) { return true; }
            if (aValues == null) { return true; }
            if (sleeping) { return true; }
            if (isSleeping) { return true; }

            for (Int32 i = 0; i <= aValues.GetUpperBound(0); i++)
            {
                if (!(i > MaxValues  - 1))
                {
                    if (aValues[i] != LastValue[i]) { return true; }
                }
            }
            return false;
        }

        public Int32[] ConvertToIconValues(DataLink[] aValues)
        {
            Int32[] iconValues = null;
            if (aValues != null)
            {
                iconValues = new Int32[aValues.GetUpperBound(0) + 1];
                for (Int32 i = 0; i <= aValues.GetUpperBound(0); i++)
                {
                    if (aValues[i].DataClassRef == null) { return null; }
                    if (aValues[i].DataIndex >= 0 && aValues[i].DataIndex <= aValues[i].DataClassRef.CurrentValue.Length - 1)
                    {
                        iconValues[i] = (Int32)ToPer(aValues[i].DataClassRef.CurrentValue[aValues[i].DataIndex], aValues[i].DataClassRef.MaxValue[aValues[i].DataIndex], valueScale);
                    }
                }
            }
            return iconValues;
        }

        //Render the icon.
        public abstract Icon RenderIcon(Int32[] aValue, Boolean sleeping);

        static public float ToPer(float value, float maxValue, float newMax)
        {
            return Convert.ToSingle((value * newMax) / maxValue);
        }

        public abstract void SaveRenderer(XmlWriter aXmlW);

        public static string ColourToString(Color aC)
        {
            return aC.R.ToString() + " " + aC.G.ToString() + " " + aC.B.ToString();
        }

        public static Color StringToColour(string aS)
        {
            string[] tempS = aS.Split(Char.Parse(" "));
            return Color.FromArgb(Int32.Parse(tempS[0]), Int32.Parse(tempS[1]), Int32.Parse(tempS[2]));
        }

        public abstract void Dispose();
    }
}

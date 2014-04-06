using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace RiskyKen.TrayUsage.Render
{
    interface IRenderColorable
    {
        Color BackgroundColour
        {
            get;
            set;
        }

        Color ForegroundColour
        {
            get;
            set;
        }
    }
}

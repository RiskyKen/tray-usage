using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiskyKen.TrayUsage.Render
{
    interface IRenderDirection
    {
        RenderDirections RenderDirection
        {
            get;
            set;
        }
    }

    public enum RenderDirections : byte
    {
        NONE = 0,
        UP = 1,
        DOWN = 2,
        LEFT = 3,
        RIGHT = 4
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrayUsage
{
    public partial class frmRenderOptionsHistory : Form
    {
        private TrayIcon _targetIcon = null;
        private RendererHistory _targetRender = null;

        public frmRenderOptionsHistory(TrayIcon TargetIcon)
        {
            InitializeComponent();
            _targetIcon = TargetIcon;
            _targetRender = (RendererHistory)TargetIcon.renderer;
        }
    }
}

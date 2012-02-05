using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace nfebox.presentation.desktop
{
    static class Program
    {
        public static NotifyIcon notify;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var menuControl = new IconMenuControl();
            notify = new NotifyIcon();
            notify.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            notify.BalloonTipText = "teste de baloon";
            notify.BalloonTipTitle = "teste";
            notify.Icon = Properties.Resources._1328229285_box_open;
            notify.Text = "notifyIcon1";
            notify.Visible = true;
            notify.ContextMenuStrip = menuControl.contextMenuStrip;

            Application.Run();

            notify.Visible = false;
        }
    }
}

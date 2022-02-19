using GetOffWorkCountdown.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetOffWorkCountdown
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GetOffWorkContext());
        }
    }
    class GetOffWorkContext : ApplicationContext
    {
        private NotifyIcon notifyIcon;

        public GetOffWorkContext()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Items.AddRange(new ToolStripItem[]
            {
                new ToolStripMenuItem("Exit", null, (object sender, EventArgs e) => Application.Exit())
            });
            notifyIcon = new NotifyIcon()
            {
                Icon = Resources.Icon,
                Text = "",
                ContextMenuStrip = contextMenuStrip,
                Visible = true
            };
        }
    }
}

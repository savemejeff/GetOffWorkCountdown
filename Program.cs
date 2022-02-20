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
        private Timer timer;
        private DateTime off;
        private long left = -1;
        public GetOffWorkContext()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Countdown);
            timer.Start();

            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Items.AddRange(new ToolStripItem[]
            {
                new ToolStripMenuItem("Exit", null,  OnExit)
            });
            notifyIcon = new NotifyIcon()
            {
                Icon = Resources.Icon,
                Text = "",
                ContextMenuStrip = contextMenuStrip,
                Visible = true
            };
        }
        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Countdown(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            if (off == null || off < now)
            {
                off = new DateTime(now.Year, now.Month, now.Day, 19, 00, 00);
            }
            if (left < 0)
            {
                left = off.Ticks - now.Ticks;
            }

            notifyIcon.Text = LeftString(left / 10000);
            left -= 10000000;
        }
        private string LeftString(long left)
        {
            long leftHour = left / 3600000;
            long leftMinute = (left % 3600000) / 60000;
            long leftSecond = ((left % 3600000) % 60000) / 1000;
            return formatNum(leftHour) + ":" + formatNum(leftMinute) + ":" + formatNum(leftSecond);
        }
        private string formatNum(long n)
        {
            return n < 10 ? "0" + n : "" + n;
        }
    }
}

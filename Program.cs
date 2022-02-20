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
        private ToolStripItem countdown;
        private Timer timer;
        private DateTime off;
        private long left = -1;
        private static readonly long OneSecond = 10000000;
        private static readonly long OneMinute = OneSecond * 60;
        private static readonly long OneHour = OneMinute * 60;
        public GetOffWorkContext()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Countdown);
            timer.Start();

            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            countdown = new ToolStripMenuItem("", null);
            contextMenuStrip.Items.AddRange(new ToolStripItem[]
            {
                countdown,
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

            notifyIcon.Text = LeftString(left);
            countdown.Text = notifyIcon.Text;
            left -= OneSecond;
        }
        private string LeftString(long left)
        {
            long leftHour = left / OneHour;
            long leftMinute = (left % OneHour) / OneMinute;
            long leftSecond = ((left % OneHour) % OneMinute) / OneSecond;
            return FormatNum(leftHour) + ":" + FormatNum(leftMinute) + ":" + FormatNum(leftSecond);
        }
        private string FormatNum(long n)
        {
            return n < 10 ? "0" + n : "" + n;
        }
    }
}

using GetOffWorkCountdown.Forms;
using GetOffWorkCountdown.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        private DateTime? off;
        private DateTime on;
        private long left = -1;
        private static readonly long OneSecond = 10000000;
        private static readonly long OneMinute = OneSecond * 60;
        private static readonly long OneHour = OneMinute * 60;
        private int offHour;
        private int offMinute;
        private int onHour;
        private int onMinute;
        private Image[] images;
        private ConfigForm configForm;
        public GetOffWorkContext()
        {
            off = null;

            images = new Image[]
            {
                Resources._25,
                Resources._50,
                Resources._75,
                Resources._100
            };

            offHour = Settings.Default.OffHour;
            offMinute = Settings.Default.OffMinute;
            onHour = Settings.Default.OnHour;
            onMinute = Settings.Default.OnMinute;

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Countdown);
            timer.Start();

            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            countdown = new ToolStripMenuItem("", null);
            contextMenuStrip.Items.AddRange(new ToolStripItem[]
            {
                countdown,
                new ToolStripMenuItem("Config", null, new EventHandler(OnConfig)),
                new ToolStripMenuItem("Exit", null,  new EventHandler(OnExit))
            });
            notifyIcon = new NotifyIcon()
            {
                Icon = Resources.Icon,
                Text = "",
                ContextMenuStrip = contextMenuStrip,
                Visible = true
            };
        }
        private void OnConfig(object sender, EventArgs e)
        {
            configForm = new ConfigForm();
            configForm.Show();
        }
        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Countdown(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            if (on == null || on.Day < now.Day)
            {
                on = new DateTime(now.Year, now.Month, now.Day, onHour, onMinute, 00);
            }
            if (off == null)
            {
                off = new DateTime(now.Year, now.Month, now.Day, offHour, offMinute, 00);
                if (off?.Ticks < now.Ticks)
                {
                    off = off?.AddDays(1);
                }
            }
            long duration = (long)(off?.Ticks - on.Ticks);

            if (left < 0)
            {
                left = (long)(off?.Ticks - now.Ticks);
            }

            int indexOfIcon = (int)(left / (duration / 4));
            if (indexOfIcon >= 0 && indexOfIcon < 4)
            {
                countdown.Image = images[indexOfIcon];
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

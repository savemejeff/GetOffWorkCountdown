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
        private DateTime offTime;
        private DateTime onTime;
        private static readonly long OneSecond = 10000000;
        private static readonly long OneMinute = OneSecond * 60;
        private static readonly long OneHour = OneMinute * 60;
        private Image[] images;
        private ConfigForm configForm;
        public MainForm mainForm;
        public GetOffWorkContext()
        {
            images = new Image[]
            {
                Resources._25,
                Resources._50,
                Resources._75,
                Resources._100
            };

            var offHour = Settings.Default.OffHour;
            var offMinute = Settings.Default.OffMinute;
            var onHour = Settings.Default.OnHour;
            var onMinute = Settings.Default.OnMinute;
            onTime = DateTime.Now;
            onTime = new DateTime(onTime.Year, onTime.Month, onTime.Day, onHour, onMinute, 0, 0);
            offTime = new DateTime(onTime.Year, onTime.Month, onTime.Day, offHour, offMinute, 0, 0);
            if (offTime < onTime)
            {
                offTime = offTime.AddDays(1);
            }

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Countdown);
            timer.Start();

            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            countdown = new ToolStripMenuItem("", null, new EventHandler(OnMain));
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
        private void OnMain(object sender, EventArgs e)
        {
            if (mainForm == null)
            {
                mainForm = new MainForm();
                mainForm.FormClosed += MainForm_FormClosed;
            }
            mainForm.TopMost = true;
            mainForm.Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm = null;
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
            if (now >= offTime)
            {
                offTime = offTime.AddDays(1);
                onTime = onTime.AddDays(1);
            }
            long duration = (long)(offTime.Ticks - onTime.Ticks);
            long left = (long)(offTime.Ticks - now.Ticks);

            int indexOfIcon = (int)(left / (duration / 4));
            if (indexOfIcon >= 0 && indexOfIcon < 4)
            {
                countdown.Image = images[indexOfIcon];
            }
            string countdownText;
            if (now < onTime)
            {
                countdownText = "Enjoy your life";
            } 
            else
            {
                countdownText = LeftString(left);
            }
            notifyIcon.Text = countdownText;
            countdown.Text = countdownText;
            if (mainForm != null)
            {
                mainForm.UpdateText(countdownText);
            }
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

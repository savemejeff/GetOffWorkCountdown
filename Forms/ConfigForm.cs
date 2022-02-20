using GetOffWorkCountdown.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetOffWorkCountdown.Forms
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            OnHour.Value = Settings.Default.OnHour;
            OnMinute.Value = Settings.Default.OnMinute;
            OffHour.Value = Settings.Default.OffHour;
            OffMinute.Value = Settings.Default.OffMinute;
        }

        private void ComfirmButton_Click(object sender, EventArgs e)
        {
            Settings.Default.OnHour = (int)OnHour.Value;
            Settings.Default.OnMinute = (int)OnMinute.Value;
            Settings.Default.OffHour = (int)OffHour.Value;
            Settings.Default.OffMinute = (int)OffMinute.Value;
            Settings.Default.Save();
            this.Close();
            Application.Restart();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

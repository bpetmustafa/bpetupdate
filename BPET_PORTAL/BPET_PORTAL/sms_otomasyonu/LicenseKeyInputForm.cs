using SKM.V3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPET_PORTAL.sms_otomasyonu
{
    public partial class LicenseKeyInputForm : Form
    {
        public string LicenseKey { get; private set; }

        public LicenseKeyInputForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            LicenseKey = txtLicenseKey.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

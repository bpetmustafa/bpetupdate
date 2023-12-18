using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace destek_otomasyonu
{
    public partial class BilgiIslemAciklamaFormu : Form
    {
        public BilgiIslemAciklamaFormu()
        {
            InitializeComponent();
        }
        private void btnTamam_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

    }
}

using BPET_PORTAL.arsiv_uygulamasi;
using BPET_PORTAL.butce_sistemi.bayi_sistemi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPET_PORTAL.butce_sistemi
{
    public partial class butceanaekran : Form
    {
        private mainpage mainForm;
        public butceanaekran(string eposta, mainpage mainForm)
        {
            InitializeComponent();
            epostalabel.Text = eposta;
            this.mainForm = mainForm; // mainForm örneğini burada başlatın
        }

        private void dosya_bul_Click(object sender, EventArgs e)
        {
            mainForm.loadform(new bayianaekran(epostalabel.Text, mainForm));
        }

       
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPET_PORTAL.bayitakip
{
    public partial class CevapYazmaFormu : Form
    {
        public string CevapMetni { get; private set; }

        public CevapYazmaFormu()
        {
            InitializeComponent();
        }
        private void btnGonder_Click(object sender, EventArgs e)
        {
            // Kullanıcının yazdığı cevabı al
            CevapMetni = txtCevapMetni.Text; // txtCevapMetni, kullanıcının cevabını yazdığı TextBox'ın adı

            // Formu kapat
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CevapYazmaFormu_Load(object sender, EventArgs e)
        {
            txtCevapMetni.Clear();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

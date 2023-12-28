using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPET_PORTAL.bilgi_islem
{
    public partial class bilgiislemanasayfa : Form
    {
        private mainpage mainForm;
        private Form activeForm = null; // Yüklenen formu takip etmek için değişken

        public bilgiislemanasayfa(string eposta, mainpage mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            epostalabel.Text = eposta;
            bilgiislemloadform(new talep_giris.TalepGirisAnaEkran());
        }

        public void bilgiislemloadform(object form)
        {

            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);

            Form f = form as Form;
            activeForm = f; // Yüklenen formu sakla
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        private void anasayfastrip_Click(object sender, EventArgs e)
        {
            bilgiislemloadform(new talep_giris.TalepGirisAnaEkran());
        }
    }
}

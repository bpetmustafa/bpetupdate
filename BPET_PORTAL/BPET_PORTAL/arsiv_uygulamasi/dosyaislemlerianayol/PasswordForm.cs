using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPET_PORTAL.arsiv_uygulamasi.dosyaislemlerianayol
{
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Girilen şifreyi kontrol et
            string girilenSifre = txtPassword.Text;
            string dogruSifre = "Bpet*2023"; // Doğru şifre

            if (girilenSifre == dogruSifre)
            {
                this.DialogResult = DialogResult.OK; // Şifre doğru ise DialogResult.OK döndür
                this.Close(); // Formu kapat
            }
            else
            {
                this.Alert("Yanlış şifre! Lütfen doğru şifreyi girin.",Form_Alert.enmType.Error);
                txtPassword.Clear(); // TextBox'ı temizle
            }
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
    }
}

using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPET_PORTAL.sms_mfa
{
    public partial class SmsMFAForm : Form
    {
        sms_mfa.sms SMS = new sms_mfa.sms();
        private string epostalabel;

        public SmsMFAForm(string eposta)
        {
            InitializeComponent();
            epostalabel = eposta;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SmsMFAForm_Load(object sender, EventArgs e)
        {
            // SMS gönderimini arka planda başlat
            Task.Run(() => SMS.Sms_sender(epostalabel));
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            bool durum = SMS.VerifyUserCode(epostalabel, txtUserİnput.Text);
            if (durum)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void txtUserİnput_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtUserİnput_MouseDown(object sender, MouseEventArgs e)
        {
            int karektersayisi = txtUserİnput.Text.Length;
            if (karektersayisi >= 0)
            {
                txtUserİnput.Focus();
                txtUserİnput.Select(karektersayisi, 0);
            }

        }

        private void mailgonderbtn_Click(object sender, EventArgs e)
        {
            string dogrulamaKodu = SMS.GetSavedVerificationCode(epostalabel);
            if (!string.IsNullOrEmpty(dogrulamaKodu))
            {
                mailgonderbtn.Visible = false;
                Task.Run(() => EmailSender.SendVerificationEmail(epostalabel, dogrulamaKodu));
            }
            else
            {
                MessageBox.Show("Doğrulama kodu bulunamadı.");
            }
        }
    }
}

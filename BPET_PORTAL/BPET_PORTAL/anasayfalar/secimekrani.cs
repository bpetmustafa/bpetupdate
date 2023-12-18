using destek_otomasyonu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace BPET_PORTAL.anasayfalar
{
    public partial class secimekrani : Form
    {
        public secimekrani()
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            YuvarlakKoseler();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void YuvarlakKoseler()
        {
            // Yuvarlak köşeler için yarıçapı artırın (örneğin 50)
            int yaricap = 50;

            // Formun köşelerini yuvarlamak için bir GraphicsPath nesnesi oluşturun
            GraphicsPath path = new GraphicsPath();

            // Yuvarlak köşeler için dikdörtgenler oluşturun
            path.AddArc(0, 0, yaricap, yaricap, 180, 90);
            path.AddArc(this.Width - yaricap - 1, 0, yaricap, yaricap, 270, 90);
            path.AddArc(this.Width - yaricap - 1, this.Height - yaricap - 1, yaricap, yaricap, 0, 90);
            path.AddArc(0, this.Height - yaricap - 1, yaricap, yaricap, 90, 90);

            // Path'i kapat
            path.CloseFigure();

            // Formun regionunu yuvarlak köşeler ile ayarla
            this.Region = new Region(path);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            YuvarlakKoseler(); // Form yeniden boyutlandığında köşeleri yuvarlak yap
        }

        private void portaldevam_Click(object sender, EventArgs e)
        {
            // Mevcut formu kapat
            this.Hide();

            // Yeni formu oluştur ve aç
            loginpage loginPage = new loginpage();
            loginPage.Show();
        }

        private void yardimmasasidevam_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Yeni formu oluştur ve aç
            Form1 yardimmasasi = new Form1();
            yardimmasasi.Show();
        }
    }
}

using BPET_PORTAL;
using OfficeOpenXml.ConditionalFormatting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace destek_otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            linkLabel.LinkBehavior = LinkBehavior.SystemDefault;
            linkLabel.Links.Add(9, 25, "https://www.bpet.com.tr/tr/");
            loadform(new AnaEkran());
            SetRoundShape(this);

        }
        public void SetRoundShape(Control control)
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 20; // Ayarlayabilirsiniz

            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
            path.AddArc(control.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
            path.AddArc(control.Width - radius * 2, control.Height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(0, control.Height - radius * 2, radius * 2, radius * 2, 90, 90);

            Region region = new Region(path);
            control.Region = region;
        }

        public void loadform(object form)
        {
            if (this.mainpanel.Controls.Count > 0) this.mainpanel.Controls.RemoveAt(0);
            Form f = form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        // Bu kısmı ekleyin
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // WS_EX_LAYERED
                return cp;
            }
        }

        // Bu kısmı ekleyin
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }
        private void btn_mainpahe_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            loadform(new AnaEkran());
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           // this.WindowState = FormWindowState.Maximized;
           loadform(new Taleplerim());
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       
      
        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = e.Link.LinkData as string;
            if (!string.IsNullOrEmpty(url))
            {
                Process.Start(url); // Varsayılan tarayıcıda linki açar
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Minimized;

        }

        private void portalgiris_Click(object sender, EventArgs e)
        {
            this.Close();

            // Yeni formu oluştur ve aç
            loginpage loginPage = new loginpage();
            loginPage.Show();
        }

        private void boyutlandırma_Click(object sender, EventArgs e)
        {
            // Eğer form zaten maksimize edilmişse, normal boyutuna geri getir
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.StartPosition = FormStartPosition.CenterScreen;
                this.WindowState = FormWindowState.Normal;

            }
            else
            {
                this.StartPosition = FormStartPosition.CenterScreen;
                this.WindowState = FormWindowState.Maximized;

            }
        }
    }
}

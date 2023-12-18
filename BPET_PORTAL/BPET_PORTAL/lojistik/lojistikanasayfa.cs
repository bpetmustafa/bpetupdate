﻿using BPET_PORTAL.arsiv_uygulamasi;
using BPET_PORTAL.lojistik.lojistikekranlar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPET_PORTAL.lojistik
{
    public partial class lojistikanasayfa : Form
    {
        private mainpage mainForm;
        private const string connectionString = "Server=95.0.50.22,1382;Database=lojistik;User ID=sa;Password=Mustafa1;";
        private Form activeForm = null; // Yüklenen formu takip etmek için değişken

        public lojistikanasayfa(string eposta, mainpage mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            epostalabel.Text = eposta;
        }
        private void lojistikanasayfa_Load(object sender, EventArgs e)
        {
            lojistikloadform(new lojistikgirisfoto());
        }
        public void lojistikloadform(object form)
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
        private void anasayfamenustrip_Click(object sender, EventArgs e)
        {
            lojistikloadform(new lojistikgirisfoto());
        }

        private void aRAÇBİLGİGİRDÜZENLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lojistikloadform(new aracislemleri(this));

        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
    }
}
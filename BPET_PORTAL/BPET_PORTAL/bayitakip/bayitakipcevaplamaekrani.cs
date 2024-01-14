using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace BPET_PORTAL.bayitakip
{
    public partial class bayitakipcevaplamaekrani : Form
    {
        private string kullaniciEposta;
        private string connectionString = "Server=95.0.50.22,1382;Database=BPET_PORTAL;User ID=sa;Password=Mustafa1;";

        public bayitakipcevaplamaekrani(string eposta)
        {
            kullaniciEposta = eposta;
            InitializeComponent();
        }
    }
}

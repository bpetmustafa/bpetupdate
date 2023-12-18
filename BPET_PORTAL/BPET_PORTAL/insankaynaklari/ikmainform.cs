using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPET_PORTAL.insankaynaklari
{
    public partial class ikmainform : Form
    {
        private mainpage mainForm;
        private const string connectionString = "Server=95.0.50.22,1382;Database=insan_kaynaklari;User ID=sa;Password=Mustafa1;";
        public ikmainform(string eposta, mainpage mainForm)
        {
            InitializeComponent();
            epostalabel.Text = eposta;
            this.mainForm = mainForm; // mainForm örneğini burada başlatın
        }
    }
}

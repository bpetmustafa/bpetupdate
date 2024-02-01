using BPET_PORTAL.admin;
using BPET_PORTAL.insankaynaklari.iscilikmaliyeti.balpet_maliyet;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPET_PORTAL.insankaynaklari.iscilikmaliyeti
{
    public partial class iscilikmaliyetiform : Form
    {


        SqlConnection conn = new SqlConnection("Server=95.0.50.22,1382;Initial Catalog=insankaynaklari;User ID=sa;Password=Mustafa1;");
        public iscilikmaliyetiform()
        {
            InitializeComponent();

        }

        private void btn_goruntule_Click(object sender, EventArgs e)
        {
            if(cbMaliyet.SelectedIndex == 0)
            {
                konsolide ekle=new balpet_maliyet.konsolide();
                ekle.ShowDialog();
            }
            if(cbMaliyet.SelectedIndex == 1)
            {
                birimDagilim ekle=new balpet_maliyet.birimDagilim();
                ekle.ShowDialog();
              
            }
            if (cbMaliyet.SelectedIndex == 2)
            {
                harcirah ekle=new balpet_maliyet.harcirah();
                ekle.ShowDialog();
            }
            if(cbMaliyet.SelectedIndex == 3)
            {
                birimMesai ekle = new balpet_maliyet.birimMesai();
                ekle.ShowDialog();

            }
            if( cbMaliyet.SelectedIndex == 4)
            {
                yemek ekle=new balpet_maliyet.yemek();
                ekle.ShowDialog();
            }
            if (cbMaliyet.SelectedIndex == 5)
            {
                mesaiMaliyetOran ekle=new balpet_maliyet.mesaiMaliyetOran();
                ekle.ShowDialog();
            }
        }
    }
}

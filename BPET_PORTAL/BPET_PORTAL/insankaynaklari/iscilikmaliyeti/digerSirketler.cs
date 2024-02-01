using BPET_PORTAL.insankaynaklari.iscilikmaliyeti.diger_sirketler_maliyet;
using BPET_PORTAL.insankaynaklari.Personel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPET_PORTAL.insankaynaklari.iscilikmaliyeti
{
    public partial class digerSirketler : Form
    {
        public digerSirketler()
        {
            InitializeComponent();
        }

        private void btn_goruntule_Click(object sender, EventArgs e)
        {
            getir();
        }

        private void getir()
        {
            if(cbMaliyet.SelectedIndex == 0)
            {
                konsolideDiger ekle= new diger_sirketler_maliyet.konsolideDiger();
                ekle.ShowDialog();
            }
            if(cbMaliyet.SelectedIndex == 1)
            {
                birimMaliyetDiger ekle=new diger_sirketler_maliyet.birimMaliyetDiger();
                ekle.ShowDialog();
            }
            if(cbMaliyet.SelectedIndex == 2)
            {
                harcirahDiger ekle=new diger_sirketler_maliyet.harcirahDiger();
                ekle.ShowDialog();
            }
            if(cbMaliyet.SelectedIndex == 3)
            {
                birimMesaiDiger ekle=new diger_sirketler_maliyet.birimMesaiDiger();
                ekle.ShowDialog();
            }
            if(cbMaliyet.SelectedIndex == 4)
            {
                yemekDiger ekle=new diger_sirketler_maliyet.yemekDiger();
                ekle .ShowDialog();   
            }
            if(cbMaliyet.SelectedIndex == 5)
            {
                mesaiMaliyetOranDiger ekle=new diger_sirketler_maliyet.mesaiMaliyetOranDiger();
                ekle.ShowDialog();
            }
        }
    }
}

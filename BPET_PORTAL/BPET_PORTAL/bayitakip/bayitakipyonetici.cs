using Microsoft.Office.Interop.Excel;
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
using DataTable = System.Data.DataTable;

namespace BPET_PORTAL.bayitakip
{
    public partial class bayitakipyonetici : Form
    {
        private mainpage mainForm;
        private static string connectionString = "Server=95.0.50.22,1382;Database=BPET_PORTAL;User ID=sa;Password=Mustafa1;";
        DatabaseBayiTakip dbBayiTakip = new DatabaseBayiTakip(connectionString);

        public bayitakipyonetici(string eposta,mainpage mainForm)
        {
            InitializeComponent();
            epostalabel.Text = eposta;
            this.mainForm = mainForm; // mainForm örneğini burada başlatın
            DateTime today = DateTime.Today;
            DayOfWeek dayOfWeek = today.DayOfWeek;

        }
        private void bayitakipyonetici_Load(object sender, EventArgs e)
        {
            LoadDataFromDatabase();
        }
        private void LoadDataFromDatabase()
        {
            DateTime today = DateTime.Today;
            DayOfWeek dayOfWeek = today.DayOfWeek;
            int daysUntilMonday = ((int)DayOfWeek.Monday - (int)dayOfWeek + 7) % 7;
            int daysUntilSunday = ((int)DayOfWeek.Sunday - (int)dayOfWeek + 7) % 7;

            // Bu haftanın başlangıç ve bitiş tarihlerini hesapla
            DateTime startDate = today.AddDays(-daysUntilMonday);
            DateTime endDate = today.AddDays(daysUntilSunday);
            dateTimePickerBaslangic.Value = startDate;
            dateTimePickerBitis.Value = endDate;

            DataTable dataTable = dbBayiTakip.GetDistinctBolgeMudurleri();
            dataGridView.DataSource = dataTable;

            int buhaftamail = dbBayiTakip.GetMailCountInDateRange(startDate, endDate);  
            buhaftagonderilenLabel.Text = buhaftamail.ToString();

            int buhaftacevaplanan = dbBayiTakip.GetCevaplananVeriSayisiThisWeek();
            cevaplanantaleplerlabel.Text = buhaftacevaplanan.ToString();
            cevaplanmayantalepLabel.Text = (buhaftamail - buhaftacevaplanan).ToString();
        }


        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Seçili satırın bölge müdürü bilgisini alın
            if (dataGridView.SelectedRows.Count > 0 && bolgemuduru.Visible == false)
            {
                // Başlangıç tarihini bir yıl önceki tarih olarak ayarlayın
                DateTime baslangicTarihi = DateTime.Today.AddYears(-1);
                DateTime bitisTarihi = DateTime.Today;

                string bolgeMuduru = dataGridView.SelectedRows[0].Cells["BolgeMuduru"].Value.ToString();
                bolgemuduru.Visible = true;
                bolgemuduru.Text = dataGridView.SelectedRows[0].Cells["BolgeMuduru"].Value.ToString();
                DataTable veriler = dbBayiTakip.GetBolgeMuduruVerileriInDateRange(bolgeMuduru, baslangicTarihi, bitisTarihi);
                dataGridView.DataSource = veriler;
                dataGridView.Columns["CevapAciklama"].Width = 800; // Sütun genişliğini 300 piksel olarak ayarlayın
                dataGridView.Columns["CevaplandiTarih"].Width = 150; // Sütun genişliğini 300 piksel olarak ayarlayın
                lblverisayisi.Text = "VERİ SAYISI: " + veriler.Rows.Count.ToString();
            }
        }

        private void geribtn_Click(object sender, EventArgs e)
        {
            bolgemuduru.Visible = false;
            bolgemuduru.Text = "---------";
            LoadDataFromDatabase(); 
        }

        private void aramatusu_Click(object sender, EventArgs e)
        {

        }
    }
}

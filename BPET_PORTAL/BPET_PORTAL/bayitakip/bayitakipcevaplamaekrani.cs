using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BPET_PORTAL.bayitakip
{
    public partial class bayitakipcevaplamaekrani : Form
    {
        private string kullaniciEposta;
        private string connectionString = "Server=95.0.50.22,1382;Database=BPET_PORTAL;User ID=sa;Password=Mustafa1;";
        private mainpage mainForm;
        public bayitakipcevaplamaekrani(string eposta, mainpage mainForm)
        {
            kullaniciEposta = eposta;
            InitializeComponent();
            LoadData();
            this.mainForm = mainForm; // mainForm örneğini burada başlatın
        }

        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Kullanıcının yetkili olduğu bölge kodlarını users tablosundan al
                string getUserBolgeYetkiQuery = "SELECT bolge_yetki FROM users WHERE E_Posta = @Eposta";
                SqlCommand getUserBolgeYetkiCommand = new SqlCommand(getUserBolgeYetkiQuery, connection);
                getUserBolgeYetkiCommand.Parameters.AddWithValue("@Eposta", kullaniciEposta);
                var bolgeYetki = getUserBolgeYetkiCommand.ExecuteScalar()?.ToString();

                // Kullanıcının yetkili olduğu bölge kodlarını bir diziye dönüştür
                var bolgeKodlari = bolgeYetki?.Split(',') ?? new string[0];

                // CariHesaplar tablosundan kullanıcının yetkili olduğu bölge kodlarına ait kayıtları al
                string query = @"
            SELECT id, CariHesapKodu, CariHesapUnvani, Sehir, SonSatisMiktari, SonSatisTarihi, SonTahsilatTarihi, SonSatisGunSayisi, SonTahsilatGunSayisi
            FROM CariHesaplar 
            WHERE MailGonderildi = 1 AND Cevaplandi = 0 
            AND BolgeKodu IN ('" + string.Join("','", bolgeKodlari) + "')";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView.DataSource = dataTable;
                        dataGridView.Columns["id"].Visible = false;

                    }
                }
                string query2 = @"
            SELECT id, CariHesapUnvani, Sehir, SonSatisMiktari, SonSatisTarihi, SonTahsilatTarihi, CevapAciklama
            FROM CariHesaplar 
            WHERE MailGonderildi = 1 AND Cevaplandi = 1 
            AND BolgeKodu IN ('" + string.Join("','", bolgeKodlari) + "')";

                using (SqlCommand command2 = new SqlCommand(query2, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command2))
                    {
                        DataTable dataTable2 = new DataTable();
                        adapter.Fill(dataTable2);
                        dataGridViewGecmis.DataSource = dataTable2;
                        dataGridViewGecmis.Columns["id"].Visible = false;

                    }
                }
            }
        }
        private void cevaplaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["id"].Value);

                // Cevap yazma formunu aç
                CevapYazmaFormu cevapFormu = new CevapYazmaFormu();
                if (cevapFormu.ShowDialog() == DialogResult.OK)
                {
                    // Kullanıcının yazdığı cevabı al ve veritabanında güncelle
                    string kullaniciCevabi = cevapFormu.CevapMetni;
                    CevabiGonder(id, kullaniciCevabi);
                    LoadData();
                    MessageBox.Show("Taleb başarıyla cevaplandı! TalepİD: " + id,"BAŞARILI",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else if(cevapFormu.ShowDialog() == DialogResult.Cancel)
                 {
                    MessageBox.Show("İPTAL EDİLDİ!","İŞLEM İPTAL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                 }
            }
            else
            {
                MessageBox.Show("Lütfen cevaplamak için bir satır seçin.");
            }
        }
        private void CevabiGonder(int id, string aciklama)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
            UPDATE CariHesaplar 
            SET CevapAciklama = @Aciklama, Cevaplandi = 1
            WHERE id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Aciklama", aciklama);
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                DataGridViewCell cell = dataGridView[e.ColumnIndex, e.RowIndex];
                cell.ToolTipText = e.Value.ToString();
            }
        }
        private void tabPage3_Click(object sender, EventArgs e)
        {
            mainForm.loadform(new bayitakipmainpage(kullaniciEposta));
        }
    }
}

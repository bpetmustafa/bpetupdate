using BPET_PORTAL.yukleme_ekrani;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace BPET_PORTAL.bayitakip
{
    public partial class bayitakipcevaplamaekrani : Form
    {
        private string kullaniciEposta;
        private string connectionString = "Server=95.0.50.22,1382;Database=BPET_PORTAL;User ID=sa;Password=Mustafa1;MultipleActiveResultSets=True;";
        private mainpage mainForm;
        public bayitakipcevaplamaekrani(string eposta, mainpage mainForm)
        {
            kullaniciEposta = eposta;
            InitializeComponent();
            this.mainForm = mainForm; // mainForm örneğini burada başlatın

        }

        private async Task LoadData()
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
                        gelentaleplerlabel.Text = dataGridView.RowCount.ToString();
                    }
                }
                string query2 = @"
            SELECT id, CariHesapUnvani, CevapAciklama, CevaplandiTarih
            FROM CariHesaplarGecmis
            WHERE BolgeKodu IN ('" + string.Join("','", bolgeKodlari) + "')";

                using (SqlCommand command2 = new SqlCommand(query2, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command2))
                    {
                        DataTable dataTable2 = new DataTable();
                        adapter.Fill(dataTable2);
                        dataGridViewGecmis.DataSource = dataTable2;
                        dataGridViewGecmis.Columns["id"].Visible = false;
                        cevaplanantaleplerlabel.Text =  dataGridViewGecmis.RowCount.ToString();
                    }
                }
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    dataGridView.AutoResizeColumn(column.Index, DataGridViewAutoSizeColumnMode.AllCells);
                }
                foreach (DataGridViewColumn column in dataGridViewGecmis.Columns)
                {
                    dataGridViewGecmis.AutoResizeColumn(column.Index, DataGridViewAutoSizeColumnMode.AllCells);
                }
                LoadingScreen.HideLoadingScreen();

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
                    // Kullanıcının yazdığı cevabı al
                    string kullaniciCevabi = cevapFormu.CevapMetni;

                    // Cevabı CariHesaplarGecmis tablosuna taşı ve CariHesaplar tablosundan sil
                    MoveToCariHesaplarGecmis(id, kullaniciCevabi);

                    // Verileri güncellemek için LoadData yöntemini çağırın
                    LoadData();

                    MessageBox.Show("Talep başarıyla cevaplandı! Talep İD: " + id, "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (cevapFormu.ShowDialog() == DialogResult.Cancel)
                {
                    MessageBox.Show("İPTAL EDİLDİ!", "İŞLEM İPTAL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                MessageBox.Show("Lütfen cevaplamak için bir satır seçin.");
            }
        }

        private void MoveToCariHesaplarGecmis(int id, string cevapMetni)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // CariHesaplar tablosundan veriyi al
                string selectQuery = "SELECT * FROM CariHesaplar WHERE id = @Id";
                using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Veriyi CariHesaplarGecmis tablosuna ekle
                            string insertQuery = @"
    INSERT INTO CariHesaplarGecmis (CariHesapID, CariHesapKodu, CariHesapUnvani, Sehir, BolgeKodu, 
        BolgeAdi, BolgeMuduru, SahaKodu, SahaAdi, SahaMuduru, SonSatisTarihi, SonSatisMiktari, 
        SonTahsilatTarihi, SonSatisGunSayisi, SonTahsilatGunSayisi, MailGonderildi, Cevaplandi, CevapAciklama, MailTarih, CevaplandiTarih)
    VALUES (@CariHesapID, @CariHesapKodu, @CariHesapUnvani, @Sehir, @BolgeKodu, 
        @BolgeAdi, @BolgeMuduru, @SahaKodu, @SahaAdi, @SahaMuduru, @SonSatisTarihi, @SonSatisMiktari, 
        @SonTahsilatTarihi, @SonSatisGunSayisi, @SonTahsilatGunSayisi, @MailGonderildi, @Cevaplandi, @CevapAciklama, @MailTarih, GETDATE())";

                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@CariHesapID", reader["id"]);
                                insertCommand.Parameters.AddWithValue("@CariHesapKodu", reader["CariHesapKodu"]);
                                insertCommand.Parameters.AddWithValue("@CariHesapUnvani", reader["CariHesapUnvani"]);
                                insertCommand.Parameters.AddWithValue("@Sehir", reader["Sehir"]);
                                insertCommand.Parameters.AddWithValue("@BolgeKodu", reader["BolgeKodu"]);
                                insertCommand.Parameters.AddWithValue("@BolgeAdi", reader["BolgeAdi"]);
                                insertCommand.Parameters.AddWithValue("@BolgeMuduru", reader["BolgeMuduru"]);
                                insertCommand.Parameters.AddWithValue("@SahaKodu", reader["SahaKodu"]);
                                insertCommand.Parameters.AddWithValue("@SahaAdi", reader["SahaAdi"]);
                                insertCommand.Parameters.AddWithValue("@SahaMuduru", reader["SahaMuduru"]);
                                insertCommand.Parameters.AddWithValue("@SonSatisTarihi", reader["SonSatisTarihi"]);
                                insertCommand.Parameters.AddWithValue("@SonSatisMiktari", reader["SonSatisMiktari"]);
                                insertCommand.Parameters.AddWithValue("@SonTahsilatTarihi", reader["SonTahsilatTarihi"]);
                                insertCommand.Parameters.AddWithValue("@SonSatisGunSayisi", reader["SonSatisGunSayisi"]);
                                insertCommand.Parameters.AddWithValue("@SonTahsilatGunSayisi", reader["SonTahsilatGunSayisi"]);
                                insertCommand.Parameters.AddWithValue("@MailGonderildi", reader["MailGonderildi"]);
                                insertCommand.Parameters.AddWithValue("@MailTarih", reader["MailTarih"]);
                                insertCommand.Parameters.AddWithValue("@Cevaplandi", 1); // Cevaplandı değeri 1 olarak ayarlanır
                                insertCommand.Parameters.AddWithValue("@CevapAciklama", cevapMetni);

                                // ExecuteNonQuery çağrısı yapmadan önce reader'ı kapatmak önemlidir
                                reader.Close();
                                insertCommand.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // Eğer okunacak veri yoksa, reader'ı kapat
                            reader.Close();
                        }
                    } // using bloğu bittiğinde reader otomatik olarak kapatılacak
                }

                // CariHesaplar tablosundan sil
                string deleteQuery = "DELETE FROM CariHesaplar WHERE id = @Id";
                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                {
                    deleteCommand.Parameters.AddWithValue("@Id", id);
                    deleteCommand.ExecuteNonQuery();
                }
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
        }

        private async void bayitakipcevaplamaekrani_Shown(object sender, EventArgs e)
        {
            await VerileriGosterAsync();

        }

        private async Task VerileriGosterAsync()
        {
            LoadingScreen.ShowLoadingScreen();
            await Task.Delay(2000);
            await LoadData();
        }

    }
}

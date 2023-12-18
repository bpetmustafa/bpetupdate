using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BPET_PORTAL.arsiv_uygulamasi
{
    public partial class geciciyetkiver : Form
    {
        private mainpage mainForm;
        private const string connectionString = "Server=95.0.50.22,1382;Database=bpetarsiv;User ID=sa;Password=Mustafa1;";
        private SqlConnection connection;
        private DataView dv; // DataView ekleniyor

        public geciciyetkiver(string eposta, mainpage mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            epostalabel.Text = eposta;
            connection = new SqlConnection(connectionString);
            FillKisilerList();
            FillYetkiComboBox();
            bitisTarihiPicker.Value = DateTime.Now.AddDays(1);
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            mainForm.loadform(new arsivmainpage(epostalabel.Text, mainForm));
        }

        private void FillKisilerList()
        {
            try
            {
                EnsureConnection(); // Bağlantıyı aç

                string query = "SELECT * FROM Kisiler";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                System.Data.DataTable kisilerTable = new System.Data.DataTable();

                adapter.Fill(kisilerTable);

                // DataGridView'e verileri aktar
                dataGridView.DataSource = kisilerTable;
                dv = new DataView(kisilerTable); // DataView oluşturuluyor
                dataGridView.DataSource = dv;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Kisiler tablosu alınırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close(); // Bağlantıyı kapat
            }
        }

        private void EnsureConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        private void FillYetkiComboBox()
        {
            try
            {
                EnsureConnection(); // Bağlantıyı aç

                string query = "SELECT Kategori FROM Kisiler WHERE Email = @Eposta";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Eposta", epostalabel.Text);

                string yetkiler = command.ExecuteScalar().ToString();

                // Kullanıcının yetkilerini virgülle ayrılmış bir dizeden ayırın
                string[] yetkiListesi = yetkiler.Split(',');

                // ComboBox'ı temizleyin
                yetkiKategorisiComboBox.Items.Clear();

                // Yetkileri ComboBox'a ekleyin
                foreach (string yetki in yetkiListesi)
                {
                    yetkiKategorisiComboBox.Items.Add(yetki.Trim()); // Trim, gereksiz boşlukları kaldırmak için kullanılır
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcının yetkileri alınırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close(); // Bağlantıyı kapat
            }
        }

        private void VerYetkiButton_Click(object sender, EventArgs e)
        {
            // Seçilen kişi ve yetki kategorisini al
            string secilenKisi = dataGridView.SelectedRows[0].Cells["KisiAdi"].Value.ToString();

            if (yetkiKategorisiComboBox.SelectedItem == null)
            {
                Alert("Lütfen bir yetki kategorisi seçin.", Form_Alert.enmType.Warning);
                return; // Kategori seçilmediği için işlemi durdur
            }

            string secilenYetkiKategorisi = yetkiKategorisiComboBox.SelectedItem.ToString();
            DateTime secilenBitisTarihi = bitisTarihiPicker.Value;

            // Veritabanına yetki verme işlemini ekle
            try
            {
                EnsureConnection(); // Bağlantıyı aç

                // Kullanıcının aynı kategoride aktif bir yetkisi var mı kontrol et
                string aktifYetkiKontrolQuery = "SELECT COUNT(*) FROM gecici_yetki WHERE KisiAdi = @KisiAdi AND YetkiKategorisi = @YetkiKategorisi AND BitisTarihi >= GETDATE()";
                SqlCommand aktifYetkiKontrolCommand = new SqlCommand(aktifYetkiKontrolQuery, connection);
                aktifYetkiKontrolCommand.Parameters.AddWithValue("@KisiAdi", secilenKisi);
                aktifYetkiKontrolCommand.Parameters.AddWithValue("@YetkiKategorisi", secilenYetkiKategorisi);

                int aktifYetkiSayisi = (int)aktifYetkiKontrolCommand.ExecuteScalar();

                if (aktifYetkiSayisi > 0)
                {
                    Alert("Seçilen kişinin aynı kategoride aktif bir yetkisi zaten bulunmaktadır.", Form_Alert.enmType.Error);
                }
                else
                {
                    // Yeni yetkiyi ver
                    string query = "INSERT INTO gecici_yetki (VerenKullanici, KisiAdi, YetkiKategorisi, BitisTarihi) VALUES (@VerenKullanici, @KisiAdi, @YetkiKategorisi, @BitisTarihi)";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@VerenKullanici", epostalabel.Text);
                    command.Parameters.AddWithValue("@KisiAdi", secilenKisi);
                    command.Parameters.AddWithValue("@YetkiKategorisi", secilenYetkiKategorisi);
                    command.Parameters.AddWithValue("@BitisTarihi", secilenBitisTarihi);

                    command.ExecuteNonQuery();

                    Alert("YETKİ BAŞARIYLA VERİLDİ!", Form_Alert.enmType.Success);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yetki verme işlemi sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close(); // Bağlantıyı kapat
            }
        }

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        private void textBoxArama_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBoxArama.Text.ToLower();
            if (dv != null)
            {
                if (!string.IsNullOrEmpty(searchText))
                {
                    // TextBox'a girilen metne göre filtreleme
                    string filter = "KisiAdi LIKE '%" + searchText + "%' OR Telefon LIKE '%" + searchText + "%' OR Email LIKE '%" + searchText + "%' OR Kategori LIKE '%" + searchText + "%'";
                    dv.RowFilter = filter;
                }
                else
                {
                    // TextBox boşsa tüm verileri göster
                    dv.RowFilter = "";
                }
            }
        }
    }
}

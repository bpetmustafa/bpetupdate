using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BPET_PORTAL.lojistik.lojistikekranlar.yolharcirah
{
    public partial class yeniharcirah : Form
    {
        private const string connectionString = "Server=95.0.50.22,1382;Database=lojistik;User ID=sa;Password=Mustafa1;";

        public yeniharcirah()
        {
            InitializeComponent();
            // Form yüklenirken Özel Kod 2 ve Plaka bilgilerini çek
            ComboboxDoldur();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Kaydet butonuna tıklandığında yeni harcırah girişini veritabanına ekleyin
            Kaydet();
        }

        private void ComboboxDoldur()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Özel Kod 2'yi çek
                    SqlCommand ozelKod2Command = new SqlCommand("SELECT DISTINCT OzetKod2 FROM YolHarcırahListesi", connection);
                    SqlDataReader ozelKod2Reader = ozelKod2Command.ExecuteReader();
                    while (ozelKod2Reader.Read())
                    {
                        comboOzelKod2.Items.Add(ozelKod2Reader["OzetKod2"].ToString());
                    }
                    ozelKod2Reader.Close();

                    // Plaka'ları çek
                    SqlCommand plakaCommand = new SqlCommand("SELECT DISTINCT Plaka FROM YolHarcırahListesi", connection);
                    SqlDataReader plakaReader = plakaCommand.ExecuteReader();
                    while (plakaReader.Read())
                    {
                        comboPlaka.Items.Add(plakaReader["Plaka"].ToString());
                    }
                    plakaReader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Combobox doldurma hatası: " + ex.Message);
            }
        }

        private void Kaydet()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Yeni harcırah girişini eklemek için SQL komutu
                    string sql = @"INSERT INTO YolHarcırahListesi (OzetKod2, Plaka, Tarih, SehirAdi, SoforAdi, HesapKodu, Tutar, Aciklama)
                                   VALUES (@OzetKod2, @Plaka, @Tarih, @SehirAdi, @SoforAdi, @HesapKodu, @Tutar, @Aciklama)";

                    SqlCommand command = new SqlCommand(sql, connection);

                    // Parametreleri ata
                    command.Parameters.AddWithValue("@OzetKod2", comboOzelKod2.Text);
                    command.Parameters.AddWithValue("@Plaka", comboPlaka.Text);
                    command.Parameters.AddWithValue("@Tarih", dateTarih.Value);
                    command.Parameters.AddWithValue("@SehirAdi", txtSehirAdi.Text);
                    command.Parameters.AddWithValue("@SoforAdi", txtSoforAdi.Text);
                    command.Parameters.AddWithValue("@HesapKodu", Convert.ToInt32(txtHesapKodu.Text));
                    command.Parameters.AddWithValue("@Tutar", Convert.ToDecimal(txtTutar.Text));
                    command.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);

                    // SQL komutunu çalıştır
                    int affectedRows = command.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Harcırah girişi başarıyla kaydedildi.");
                        // Giriş başarılı olduysa formu temizle
                        Temizle();
                    }
                    else
                    {
                        MessageBox.Show("Harcırah girişi kaydedilemedi.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydetme hatası: " + ex.Message);
            }
        }

        private void Temizle()
        {
            // Formdaki kontrolleri temizle
            comboOzelKod2.SelectedIndex = -1;
            comboPlaka.SelectedIndex = -1;
            dateTarih.Value = DateTime.Now;
            txtSehirAdi.Clear();
            txtSoforAdi.Clear();
            txtHesapKodu.Clear();
            txtTutar.Clear();
            txtAciklama.Clear();
        }


    }
}

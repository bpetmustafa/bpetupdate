using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BPET_PORTAL.lojistik.lojistikekranlar.yolharcirah
{
    public partial class yeniharcirah : Form
    {
        private const string connectionString = "Server=95.0.50.22,1382;Database=lojistik;User ID=sa;Password=Mustafa1;";
        private harcirahlistesi anaharcirah;
        private bool updatemode = false;
        int id;
        public yeniharcirah(harcirahlistesi anaharcirah, int selectedRowID)
        {
            InitializeComponent();
            // Form yüklenirken Özel Kod 2 ve Plaka bilgilerini çek
            this.anaharcirah = anaharcirah;
            LoadAutoCompleteData();
            id = selectedRowID;
            if (selectedRowID == 0)
            {
                updatemode = false;
                updatelabel.Visible = false;
            }
            else
            {
                updatemode = true;
                updatelabel.Visible = true;

                PopulateFormFromDatabase(selectedRowID);

            }
        }
        
        private void LoadAutoCompleteData()
        {
            // ComboBox'lara verileri yükleyin
            LoadComboBoxData("SELECT DISTINCT SoforAdi FROM YolHarcırahListesi", cmdSoforAdi);
            LoadComboBoxData("SELECT DISTINCT Plaka FROM YolHarcırahListesi", comboPlaka);
            LoadComboBoxData("SELECT DISTINCT OzetKod2 FROM YolHarcırahListesi", comboOzelKod2);
        }

        private void LoadComboBoxData(string query, ComboBox comboBox)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string item = reader[0].ToString();

                            // Eğer combobox'ta bu öğe yoksa ekleyin
                            if (!comboBox.Items.Contains(item))
                            {
                                comboBox.Items.Add(item);
                            }
                        }
                    }
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Kaydet butonuna tıklandığında yeni harcırah girişini veritabanına ekleyin
            Kaydet();
        }

        private void PopulateFormFromDatabase(int selectedRowID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Veritabanından seçili satırın verilerini çekmek için SQL sorgusu
                    string query = $"SELECT * FROM YolHarcırahListesi WHERE ID = {selectedRowID}";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Verileri form kontrollerine yerleştir
                                comboOzelKod2.Text = reader["OzetKod2"].ToString();
                                comboPlaka.Text = reader["Plaka"].ToString();
                                dateTarih.Value = Convert.ToDateTime(reader["Tarih"]);
                                txtSehirAdi.Text = reader["SehirAdi"].ToString();
                                cmdSoforAdi.Text = reader["SoforAdi"].ToString();
                                txtHesapKodu.Text = reader["HesapKodu"].ToString();
                                txtTutar.Value = Convert.ToDecimal(reader["Tutar"]);
                                txtAciklama.Text = reader["Aciklama"].ToString();
                                disyuklemeadet.Value = Convert.ToDecimal(reader["DisYukleme"]);
                                disyuklemetutar.Value = Convert.ToDecimal(reader["DisYuklemeTutar"]);
                            }
                            else
                            {
                                MessageBox.Show("Veri bulunamadı.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri çekme hatası: " + ex.Message);
            }
        }

        private void Kaydet()
        {
            decimal toplamdisyuklemetutar = disyuklemeadet.Value * disyuklemeucretsabit.Value;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    if (updatemode)
                    {
                        // Güncelleme modunda ise UPDATE SQL komutunu kullan
                        string updateSql = @"UPDATE YolHarcırahListesi 
                                     SET OzetKod2 = @OzetKod2, Plaka = @Plaka, Tarih = @Tarih, 
                                         SehirAdi = @SehirAdi, SoforAdi = @SoforAdi, 
                                         HesapKodu = @HesapKodu, Tutar = @Tutar, 
                                         Aciklama = @Aciklama, DisYukleme = @DisYukleme,
                                         DisYuklemeTutar = @DisYuklemeTutar
                                     WHERE ID = @SelectedRowID";

                        SqlCommand updateCommand = new SqlCommand(updateSql, connection);
                        updateCommand.Parameters.AddWithValue("@SelectedRowID", id);
                        updateCommand.Parameters.AddWithValue("@OzetKod2", comboOzelKod2.Text);
                        updateCommand.Parameters.AddWithValue("@Plaka", comboPlaka.Text);
                        updateCommand.Parameters.AddWithValue("@Tarih", dateTarih.Value);
                        updateCommand.Parameters.AddWithValue("@SehirAdi", txtSehirAdi.Text);
                        updateCommand.Parameters.AddWithValue("@SoforAdi", cmdSoforAdi.Text);
                        updateCommand.Parameters.AddWithValue("@HesapKodu", txtHesapKodu.Text);
                        updateCommand.Parameters.AddWithValue("@Tutar", txtTutar.Value);
                        updateCommand.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
                        updateCommand.Parameters.AddWithValue("@DisYukleme", disyuklemeadet.Value);
                        updateCommand.Parameters.AddWithValue("@DisYuklemeTutar", toplamdisyuklemetutar);

                        int updatedRows = updateCommand.ExecuteNonQuery();

                        if (updatedRows > 0)
                        {
                            MessageBox.Show("Harcırah girişi güncellendi.");
                            anaharcirah.LoadData();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Harcırah girişi güncellenemedi.");
                        }
                    }
                    else
                    {
                        // Yeni harcırah girişi eklemek için INSERT SQL komutunu kullan
                        string insertSql = @"INSERT INTO YolHarcırahListesi 
                                     (OzetKod2, Plaka, Tarih, SehirAdi, SoforAdi, HesapKodu, Tutar, Aciklama, DisYukleme, DisYuklemeTutar)
                                     VALUES (@OzetKod2, @Plaka, @Tarih, @SehirAdi, @SoforAdi, @HesapKodu, @Tutar, @Aciklama, @DisYukleme, @DisYuklemeTutar)";

                        SqlCommand insertCommand = new SqlCommand(insertSql, connection);
                        insertCommand.Parameters.AddWithValue("@OzetKod2", comboOzelKod2.Text);
                        insertCommand.Parameters.AddWithValue("@Plaka", comboPlaka.Text);
                        insertCommand.Parameters.AddWithValue("@Tarih", dateTarih.Value);
                        insertCommand.Parameters.AddWithValue("@SehirAdi", txtSehirAdi.Text);
                        insertCommand.Parameters.AddWithValue("@SoforAdi", cmdSoforAdi.Text);
                        insertCommand.Parameters.AddWithValue("@HesapKodu", txtHesapKodu.Text);
                        insertCommand.Parameters.AddWithValue("@Tutar", txtTutar.Value);
                        insertCommand.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
                        insertCommand.Parameters.AddWithValue("@DisYukleme", disyuklemeadet.Value);
                        insertCommand.Parameters.AddWithValue("@DisYuklemeTutar", toplamdisyuklemetutar);

                        int affectedRows = insertCommand.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Harcırah girişi kaydedildi.");
                            anaharcirah.LoadData();
                            //this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Harcırah girişi kaydedilemedi.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("İşlem hatası: " + ex.Message);
            }
        }


        private void Temizle()
        {
            // Formdaki kontrolleri temizle
            comboOzelKod2.SelectedIndex = -1;
            comboPlaka.SelectedIndex = -1;
            dateTarih.Value = DateTime.Now;
            txtSehirAdi.SelectedIndex = -1;
            cmdSoforAdi.SelectedIndex = -1;
            txtTutar.Value = 0;
            txtAciklama.Clear();
            disyuklemeadet.Value = 0;
        }

        private void disyuklemeadet_ValueChanged(object sender, EventArgs e)
        {
            decimal toplamdisyuklemetutar = disyuklemeadet.Value * disyuklemeucretsabit.Value;
            disyuklemetutar.Value = toplamdisyuklemetutar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal toplamtutar = disyuklemetutar.Value + txtTutar.Value;
            txtTutar.Value = toplamtutar;
        }
    }
}

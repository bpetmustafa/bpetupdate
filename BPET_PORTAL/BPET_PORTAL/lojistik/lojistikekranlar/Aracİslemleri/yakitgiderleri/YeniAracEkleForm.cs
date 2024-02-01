﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace BPET_PORTAL.lojistik.lojistikekranlar.yakitgiderleri
{
    public partial class YeniAracEkleForm : Form
    {
        private bool eklemeBasarili;
        private const string connectionString = "Server=95.0.50.22,1382;Database=lojistik;User ID=sa;Password=Mustafa1;";
        public string plaka;
        public string hizmetKodu;
        public string hizmetAciklamasi;
        public decimal yakitMiktari;
        public decimal birimFiyatKDVsizTL;
        public decimal yakitTutariKDVsizTL;
        public decimal yakitTutariTLKDV;
        public string bolum;
        public int yil;
        public string ay;
        public int YakitGideriID { get; set; }

        public bool EklemeBasarili => eklemeBasarili;
        public bool DuzenlemeModu { get; set; }

        public YeniAracEkleForm()
        {
            InitializeComponent();
            YilComboBoxDoldur();
            AyComboBoxDoldur();
            cmbKDVOrani.SelectedIndex = 1; // Varsayılan olarak KDV %20'i seçili yapabilirsiniz.

        }
        public void DoldurDuzenlemeModu()
        {
            txtPlaka.Text = plaka;
            string plakaText = plaka;
            plakaText = plakaText.Replace(" ", ""); // Boşlukları kaldır
            plakaText = plakaText.ToUpper(); // Küçük harfleri büyüt
            txtPlaka.Text = plakaText;
            txtHizmetAciklamasi.Text = hizmetAciklamasi;
            txtYakitMiktari.Text = yakitMiktari.ToString();
            txtBirimFiyatKDVsizTL.Text = birimFiyatKDVsizTL.ToString();
            txtYakitTutariKDVsizTL.Text = yakitTutariKDVsizTL.ToString();
            txtYakitTutariTLKDV.Text = yakitTutariTLKDV.ToString();
            txtBolum.Text = bolum;
            txtYil.Text = yil.ToString();
            txtAy.Text = ay;
            txtID.Text = YakitGideriID.ToString();

        }

        private void AyComboBoxDoldur()
        {
            // Tüm ayları ekleyerek ComboBox'ı doldur
            string[] aylar = {"Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran",
                              "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"};

            txtAy.Items.AddRange(aylar);

            // İlk elemanı seçili hale getir
            txtAy.SelectedIndex = 0;
        }
        private void YilComboBoxDoldur()
        {
            // Şu anki yılı al
            int suAnkiYil = DateTime.Now.Year;

            // 2023 ve 2024'ü ekleyerek ComboBox'ı doldur
            for (int yil = suAnkiYil - 1; yil <= suAnkiYil + 3; yil++)
            {
                txtYil.Items.Add(yil.ToString());
            }

            // İlk elemanı seçili hale getir
            txtYil.SelectedIndex = 0;
        }
        private void HesaplamalariYap()
        {
            if (!string.IsNullOrWhiteSpace(txtBirimFiyatKDVsizTL.Text) && !string.IsNullOrWhiteSpace(txtYakitMiktari.Text))
            {
                if (decimal.TryParse(txtBirimFiyatKDVsizTL.Text, out decimal birimFiyat) &&
                    decimal.TryParse(txtYakitMiktari.Text, out decimal miktar))
                {
                    // KDV'siz tutarı hesapla
                    decimal tutarKDVsiz = birimFiyat * miktar;
                    txtYakitTutariKDVsizTL.Text = tutarKDVsiz.ToString("0.00");

                    decimal kdvOrani = 0m; // KDV oranını saklamak için değişken

                    // ComboBox'tan seçilen KDV oranını al
                    if (cmbKDVOrani.SelectedIndex == 0)
                    {
                        kdvOrani = 0.18m; // KDV %18
                    }
                    else if (cmbKDVOrani.SelectedIndex == 1)
                    {
                        kdvOrani = 0.20m; // KDV %20
                    }

                    decimal tutarKDVli = tutarKDVsiz * (1 + kdvOrani);
                    txtYakitTutariTLKDV.Text = tutarKDVli.ToString("0.00");

                    //MessageBox.Show($"KDV %{kdvOrani * 100} ALINDI!");
                    this.Alert($"KDV %{kdvOrani * 100} ALINDI!", Form_Alert.enmType.Warning);
                }
                else
                {
                    MessageBox.Show("Geçersiz birim fiyat veya miktar girişi. Lütfen sayısal bir değer girin.");
                }
            }
        }

        public void btnKaydet_Click(object sender, EventArgs e)
        {
            if (

        string.IsNullOrWhiteSpace(txtYakitMiktari.Text) ||
        string.IsNullOrWhiteSpace(txtBirimFiyatKDVsizTL.Text) ||
        string.IsNullOrWhiteSpace(txtYakitTutariKDVsizTL.Text) ||
        string.IsNullOrWhiteSpace(txtYakitTutariTLKDV.Text) ||
        string.IsNullOrWhiteSpace(txtBolum.Text) ||
        string.IsNullOrWhiteSpace(txtYil.Text) ||
        string.IsNullOrWhiteSpace(txtAy.Text))
            {
                // Gerekli alanlar boşsa kullanıcıyı uyar
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }// Kullanıcının girdiği bilgileri al
            string plakaText = txtPlaka.Text;
            plakaText = plakaText.Replace(" ", ""); // Boşlukları kaldır
            plakaText = plakaText.ToUpper(); // Küçük harfleri büyüt
            txtPlaka.Text = plakaText;
            hizmetAciklamasi = txtHizmetAciklamasi.Text;
            yakitMiktari = Convert.ToDecimal(txtYakitMiktari.Text);
            birimFiyatKDVsizTL = Convert.ToDecimal(txtBirimFiyatKDVsizTL.Text);
            yakitTutariKDVsizTL = Convert.ToDecimal(txtYakitTutariKDVsizTL.Text);
            yakitTutariTLKDV = Convert.ToDecimal(txtYakitTutariTLKDV.Text);
            bolum = txtBolum.Text;
            yil = Convert.ToInt32(txtYil.Text);
            ay = txtAy.Text;

            if (DuzenlemeModu)
            {

                GuncelleYakitGideri(YakitGideriID, plakaText, hizmetAciklamasi, yakitMiktari, birimFiyatKDVsizTL, yakitTutariKDVsizTL, yakitTutariTLKDV, bolum, yil, ay);

            }
            else
            {
                EkleYakitGideri(plakaText, hizmetAciklamasi, yakitMiktari, birimFiyatKDVsizTL, yakitTutariKDVsizTL, yakitTutariTLKDV, bolum, yil, ay);

            }
            // Veritabanına ekleme işlemi
        }
        private void GuncelleYakitGideri(int id, string plaka, string hizmetAciklamasi, decimal yakitMiktari, decimal birimFiyatKDVsizTL, decimal yakitTutariKDVsizTL, decimal yakitTutariTLKDV, string bolum, int yil, string ay)
        {
            // Veritabanı bağlantısı oluştur
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Veritabanında güncelleme sorgusu
                    string updateQuery = "UPDATE YakitGiderleri SET Plaka = @plaka, HizmetAciklamasi = @hizmetAciklamasi, YakitMiktariLT = @yakitMiktari, BirimFiyatKDVsizTL = @birimFiyatKDVsizTL, YakitTutariKDVsizTL = @yakitTutariKDVsizTL, YakitTutariTLKDV = @yakitTutariTLKDV, Bolum = @bolum, Yil = @yil, Ay = @ay WHERE ID = @id";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@plaka", plaka);
                        command.Parameters.AddWithValue("@hizmetAciklamasi", hizmetAciklamasi);
                        command.Parameters.AddWithValue("@yakitMiktari", yakitMiktari);
                        command.Parameters.AddWithValue("@birimFiyatKDVsizTL", birimFiyatKDVsizTL);
                        command.Parameters.AddWithValue("@yakitTutariKDVsizTL", yakitTutariKDVsizTL);
                        command.Parameters.AddWithValue("@yakitTutariTLKDV", yakitTutariTLKDV);
                        command.Parameters.AddWithValue("@bolum", bolum);
                        command.Parameters.AddWithValue("@yil", yil);
                        command.Parameters.AddWithValue("@ay", ay);
                        command.Parameters.AddWithValue("@id", id);


                        // Sorguyu çalıştır
                        int affectedRows = command.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            Alert("Güncellendi! " + id, Form_Alert.enmType.Success);
                            eklemeBasarili = true;
                            this.Close(); // Formu kapat
                        }
                        else
                        {
                            MessageBox.Show("Yakıt gideri güncellenirken bir hata oluştu.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        private void EkleYakitGideri(string plaka, string hizmetAciklamasi, decimal yakitMiktari, decimal birimFiyatKDVsizTL, decimal yakitTutariKDVsizTL, decimal yakitTutariTLKDV, string bolum, int yil, string ay)
        {
            // Veritabanı bağlantısı oluştur
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Veritabanına ekleme sorgusu
                    string insertQuery = "INSERT INTO YakitGiderleri (Plaka, HizmetAciklamasi, YakitMiktariLT, BirimFiyatKDVsizTL, YakitTutariKDVsizTL, YakitTutariTLKDV, Bolum, Yil, Ay) " +
                                         "VALUES (@plaka, @hizmetAciklamasi, @yakitMiktari, @birimFiyatKDVsizTL, @yakitTutariKDVsizTL, @yakitTutariTLKDV, @bolum, @yil, @ay)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@plaka", plaka);
                        command.Parameters.AddWithValue("@hizmetAciklamasi", hizmetAciklamasi);
                        command.Parameters.AddWithValue("@yakitMiktari", yakitMiktari);
                        command.Parameters.AddWithValue("@birimFiyatKDVsizTL", birimFiyatKDVsizTL);
                        command.Parameters.AddWithValue("@yakitTutariKDVsizTL", yakitTutariKDVsizTL);
                        command.Parameters.AddWithValue("@yakitTutariTLKDV", yakitTutariTLKDV);
                        command.Parameters.AddWithValue("@bolum", bolum);
                        command.Parameters.AddWithValue("@yil", yil);
                        command.Parameters.AddWithValue("@ay", ay);

                        // Sorguyu çalıştır
                        int affectedRows = command.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            Alert("Eklendi! " + plaka, Form_Alert.enmType.Success);
                            eklemeBasarili = true;
                        }
                        else
                        {
                            MessageBox.Show("Yakıt gideri eklenirken bir hata oluştu.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            HesaplamalariYap();
        }

        private void YeniAracEkleForm_Load(object sender, EventArgs e)
        {
            if (DuzenlemeModu)
            {
                DoldurDuzenlemeModu();
                LoadAutocompleteData(txtPlaka, "Plaka", "YakitGiderleri");
                LoadAutocompleteData(txtHizmetAciklamasi, "HizmetAciklamasi", "YakitGiderleri");
            }
            LoadAutocompleteData(txtPlaka, "Plaka", "YakitGiderleri");
            LoadAutocompleteData(txtHizmetAciklamasi, "HizmetAciklamasi", "YakitGiderleri");
        }
        private void LoadAutocompleteData(TextBox textBox, string columnName, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Veritabanında distinct değerleri çek
                    string query = $"SELECT DISTINCT {columnName} FROM {tableName}";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            AutoCompleteStringCollection autoCompleteData = new AutoCompleteStringCollection();
                            while (reader.Read())
                            {
                                autoCompleteData.Add(reader[columnName].ToString());
                            }
                            textBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                            textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                            textBox.AutoCompleteCustomSource = autoCompleteData;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
    }
}

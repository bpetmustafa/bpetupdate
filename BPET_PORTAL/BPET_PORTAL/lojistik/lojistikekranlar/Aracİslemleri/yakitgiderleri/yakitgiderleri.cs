using BPET_PORTAL.lojistik.lojistikekranlar.Aracİslemleri.yakitgiderleri;
using BPET_PORTAL.yukleme_ekrani;
using MetroFramework.Controls;
using Org.BouncyCastle.Crypto.Macs;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPET_PORTAL.lojistik.lojistikekranlar.yakitgiderleri
{
    public partial class yakitgiderleri : Form
    {
        private lojistikanasayfa mainform;
        private const string connectionString = "Server=95.0.50.22,1382;Database=lojistik;User ID=sa;Password=Mustafa1;";
        string eposta;

        public yakitgiderleri(lojistikanasayfa mainform)
        {
            InitializeComponent();
            this.mainform = mainform;
            eposta = mainform.epostalabel.Text;
            
   

        }

        private void VerileriGoster()
        {
            // Veritabanındaki YakitGiderleri tablosundan verileri çek
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {


                    connection.Open();

                    // SELECT sorgusunu oluştur
                    string selectQuery = "SELECT ID, Plaka, HizmetAciklamasi, YakitMiktariLT, BirimFiyatKDVsizTL, YakitTutariKDVsizTL, " +
                        "YakitTutariTLKDV, Bolum, Yil, Ay  FROM YakitGiderleri";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        // DataGridView'e verileri bağla
                        dataGridView1.DataSource = dataTable;

                        // Toplam miktarları hesapla
                        decimal toplamYakitMiktari = 0;
                        decimal toplamYakitTutariKDVsizTL = 0;
                        decimal toplamYakitTutariTLKDV = 0;

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            toplamYakitMiktari += Convert.ToDecimal(row.Cells["YakitMiktariLT"].Value);
                            toplamYakitTutariKDVsizTL += Convert.ToDecimal(row.Cells["YakitTutariKDVsizTL"].Value);
                            toplamYakitTutariTLKDV += Convert.ToDecimal(row.Cells["YakitTutariTLKDV"].Value);
                        }

                        // Toplam miktarları label'lara yazdır
                        labelToplamYakitMiktari.Text = $"{toplamYakitMiktari:N2} LT";
                        labelToplamYakitTutariKDVsizTL.Text = $"{toplamYakitTutariKDVsizTL:C2} TL";
                        labelToplamYakitTutariTLKDV.Text = $"{toplamYakitTutariTLKDV:C2} TL";
                        
                    }
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        dataGridView1.AutoResizeColumn(column.Index, DataGridViewAutoSizeColumnMode.AllCells);
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri okuma hatası: " + ex.Message);
                }
            }
        }
        private void ComboboxlariDoldur()
        {
            // Yıl combobox'ını doldur
            for (int yil = DateTime.Now.Year + 1; yil >= 2020; yil--)
            {
                cmbYil.Items.Add(yil.ToString());
            }

            // Ay combobox'ını doldur
            cmbAy.Items.AddRange(DateTimeFormatInfo.CurrentInfo.MonthNames.Take(12).ToArray());

            // Bölüm combobox'ını doldur
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT Bolum FROM YakitGiderleri";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string bolum = reader.GetString(0);
                    cmbBolum.Items.Add(bolum);
                }
            }

            // Hizmet Kodu combobox'ını doldur
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT HizmetAciklamasi FROM YakitGiderleri";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string hizmetaciklamasi = reader.GetString(0);
                    cmbHizmetAciklamasi.Items.Add(hizmetaciklamasi);
                }
            }

            // Plaka textbox'ını doldur
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT Plaka FROM YakitGiderleri";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string plaka = reader.GetString(0);
                    txtPlaka.AutoCompleteCustomSource.Add(plaka);
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT Plaka FROM YakitGiderleri";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string plaka = reader.GetString(0);
                    cmbPlakalar.Items.Add(plaka);
                }
            }
        }

        private void btnYeniArac_Click(object sender, EventArgs e)
        {
            YeniAracEkleForm yeniAracForm = new YeniAracEkleForm();
            yeniAracForm.ShowDialog();

            // Eğer yeni araç ekleme işlemi yapıldıysa, verileri güncelle
            if (yeniAracForm.EklemeBasarili)
            {
                VerileriGoster();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // DataGridView'den seçilen satırın indeksini al
            int seciliSatirIndex = dataGridView1.SelectedCells[0].RowIndex;

            // Seçilen satırdaki verileri al
            DataGridViewRow seciliSatir = dataGridView1.Rows[seciliSatirIndex];

            // YeniAracEkleForm'u oluştur
            YeniAracEkleForm duzenlemeForm = new YeniAracEkleForm();

            // YeniAracEkleForm'un kontrollerine seçilen satırdaki verileri aktar
            duzenlemeForm.plaka = seciliSatir.Cells["Plaka"].Value.ToString();
            duzenlemeForm.hizmetAciklamasi = seciliSatir.Cells["HizmetAciklamasi"].Value.ToString();
            duzenlemeForm.yakitMiktari = Convert.ToDecimal(seciliSatir.Cells["YakitMiktariLT"].Value);
            duzenlemeForm.birimFiyatKDVsizTL = Convert.ToDecimal(seciliSatir.Cells["BirimFiyatKDVsizTL"].Value);
            duzenlemeForm.yakitTutariKDVsizTL = Convert.ToDecimal(seciliSatir.Cells["YakitTutariKDVsizTL"].Value);
            duzenlemeForm.yakitTutariTLKDV = Convert.ToDecimal(seciliSatir.Cells["YakitTutariTLKDV"].Value);
            duzenlemeForm.bolum = seciliSatir.Cells["Bolum"].Value.ToString();
            duzenlemeForm.yil = Convert.ToInt32(seciliSatir.Cells["Yil"].Value);
            duzenlemeForm.ay = seciliSatir.Cells["Ay"].Value.ToString();
            duzenlemeForm.YakitGideriID = Convert.ToInt32(seciliSatir.Cells["ID"].Value); // ID değerini ayarlayın

            // YeniAracEkleForm'u düzenleme modunda aç
            duzenlemeForm.DuzenlemeModu = true;
            duzenlemeForm.ShowDialog();

            // Eğer güncelleme işlemi yapıldıysa, verileri güncelle
            if (duzenlemeForm.EklemeBasarili)
            {
                btnFiltrele_Click(sender, e);   
            }
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            // Kullanıcının seçtiği filtre değerlerini al
            string selectedYil = cmbYil.SelectedItem?.ToString();
            string selectedAy = cmbAy.SelectedItem?.ToString();
            string selectedBolum = cmbBolum.SelectedItem?.ToString();
            string selectedHizmetAcikalamsi = cmbHizmetAciklamasi.SelectedItem?.ToString();
            string selectedPlaka = txtPlaka.Text;

            // Verileri filtrele ve DataGridView'i güncelle
            FiltreleVeGuncelle(selectedYil, selectedAy, selectedBolum, selectedHizmetAcikalamsi, selectedPlaka);
        }
        private void FiltreleVeGuncelle(string yil, string ay, string bolum, string hizmetaciklamasi, string plaka)
        {
            // Filtreleme işlemini gerçekleştir ve DataGridView'i güncelle
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Filtre için WHERE koşulu oluştur
                    string whereCondition = "1=1"; // Default olarak her şeyi getir

                    if (!string.IsNullOrEmpty(yil))
                        whereCondition += $" AND Yil = {yil}";

                    if (!string.IsNullOrEmpty(ay))
                        whereCondition += $" AND Ay = '{ay}'";

                    if (!string.IsNullOrEmpty(bolum))
                        whereCondition += $" AND Bolum = '{bolum}'";

                    if (!string.IsNullOrEmpty(hizmetaciklamasi))
                        whereCondition += $" AND HizmetAciklamasi = '{hizmetaciklamasi}'";

                    if (!string.IsNullOrEmpty(plaka))
                        whereCondition += $" AND Plaka LIKE '%{plaka}%'";

                    // SELECT sorgusunu oluştur
                    string selectQuery = $"SELECT ID, Plaka, HizmetAciklamasi, YakitMiktariLT, BirimFiyatKDVsizTL, YakitTutariKDVsizTL," +
                        $"YakitTutariTLKDV, Bolum, Yil, Ay FROM YakitGiderleri WHERE {whereCondition}";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        // DataGridView'e verileri bağla
                        dataGridView1.DataSource = dataTable;

                        decimal toplamYakitMiktari = 0;
                        decimal toplamYakitTutariKDVsizTL = 0;
                        decimal toplamYakitTutariTLKDV = 0;

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            toplamYakitMiktari += Convert.ToDecimal(row.Cells["YakitMiktariLT"].Value);
                            toplamYakitTutariKDVsizTL += Convert.ToDecimal(row.Cells["YakitTutariKDVsizTL"].Value);
                            toplamYakitTutariTLKDV += Convert.ToDecimal(row.Cells["YakitTutariTLKDV"].Value);
                        }

                        // Toplam miktarları label'lara yazdır
                        labelToplamYakitMiktari.Text = $"{toplamYakitMiktari:N2} LT";
                        labelToplamYakitTutariKDVsizTL.Text = $"{toplamYakitTutariKDVsizTL:C2} TL";
                        labelToplamYakitTutariTLKDV.Text = $"{toplamYakitTutariTLKDV:C2} TL";
                    }
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        dataGridView1.AutoResizeColumn(column.Index, DataGridViewAutoSizeColumnMode.AllCells);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri okuma hatası: " + ex.Message);
                }
            }
        }

        private void resetle_Click(object sender, EventArgs e)
        {
            // Tüm textbox'ları ve combobox'ları sıfırla
            cmbYil.SelectedIndex = -1;
            cmbAy.SelectedIndex = -1;
            cmbBolum.SelectedIndex = -1;
            cmbHizmetAciklamasi.SelectedIndex = -1;
            txtPlaka.Text = "";

            // Verileri göster
            VerileriGoster();
        }

        private void btnRaporOlustur_Click(object sender, EventArgs e)
        {
            string selectedPlaka = cmbPlakalar.SelectedItem?.ToString();

            // Eğer araç seçilmişse raporu oluştur
            if (!string.IsNullOrEmpty(selectedPlaka))
            {
                DataTable raporVerileri = VerileriGetir(selectedPlaka);
                PdfRaporOlusturucu.OtoYakitRaporuOlustur(raporVerileri);
            }
            else
            {
                MessageBox.Show("Lütfen bir araç plakası seçin.");
            }
        }
        private DataTable VerileriGetir(string selectedPlaka)
        {
            // Verileri getirme işlemleri
            // Örneğin, aşağıdaki gibi bir SQL sorgusu ile verileri çekebilirsiniz.
            string query = $"SELECT * FROM YakitGiderleri WHERE Plaka = '{selectedPlaka}'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        return dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri okuma hatası: " + ex.Message);
                    return null; // Hata durumunda null dönebilirsiniz veya isteğinize göre bir hata yönetimi uygulayabilirsiniz.
                }
            }
        }

        private void seçiliVeriyiDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnUpdate_Click(sender, e);
        }

        private async void yakitgiderleri_Shown(object sender, EventArgs e)
        {
            LoadingScreen.ShowLoadingScreen();
            await  VerileriGosterAsync();
        }

        private async Task VerileriGosterAsync()
        {
            await Task.Delay(1000); 

            VerileriGoster();
            ComboboxlariDoldur(); // Combobox'ları doldur

            // Veriler yüklendikten sonra ekranı güncelleme işlemleri burada gerçekleştirilir.
            LoadingScreen.HideLoadingScreen();
        }

    }
}

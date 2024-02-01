using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using Application = Microsoft.Office.Interop.Excel.Application;
using System.Drawing;

namespace BPET_PORTAL.borsauygulamasi
{
    public partial class borsaanasayfa : Form
    {
        private const string connectionString = "Server=95.0.50.22,1382;Database=BPET_PORTAL;User ID=sa;Password=Mustafa1;";
        private DataTable dataTable;
        private HashSet<string> cekilenHisseAdlari = new HashSet<string>();
        private bool veriErisimiHatasi = false;
        private bool zamangecersiz = false;
        private HashSet<string> cekilenHisseKodlari = new HashSet<string>();
        private int remainingTime = 600; // 10 dakika (600 saniye)

        public borsaanasayfa(string eposta)
        {
            InitializeComponent();
            epostalabel.Text = eposta;
            InitializeDataGridView();
            LoadUserPortfolio();
            //LoadHisseVerileriForPortfoy(); // Otomatik olarak portföydeki hisselerin verilerini çek

            // ToplaVeOrtalamaMaliyetGoster();
        }


        private void InitializeDataGridView()
        {
            // DataGridView için sütunları tanımlayın
            dataTable = new DataTable();
            dataTable.Columns.Add("Hisse Adı", typeof(string));
            dataTable.Columns.Add("Fiyat", typeof(string));
            dataTable.Columns.Add("Yüzde", typeof(string));
            dataTable.Columns.Add("Zaman", typeof(string));
            dataGridView1.DataSource = dataTable;

            // Kullanıcı hisse portföyü için sütunları tanımlayın
            DataTable userPortfolioTable = new DataTable();
            userPortfolioTable.Columns.Add("Hisse Adı", typeof(string));
            userPortfolioTable.Columns.Add("Adet", typeof(int));
            userPortfolioTable.Columns.Add("Maliyet", typeof(decimal));
            dataGridViewUserPortfolio.DataSource = userPortfolioTable;

            // Sağ tık menüyü oluşturun ve öğeleri ekleyin
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem menuItemSat = new ToolStripMenuItem("Sat");
            ToolStripMenuItem menuItemDuzenle = new ToolStripMenuItem("Düzenle");

            menuItemSat.Click += MenuItemSat_Click;
            menuItemDuzenle.Click += MenuItemDuzenle_Click;

            contextMenuStrip.Items.Add(menuItemSat);
            contextMenuStrip.Items.Add(menuItemDuzenle);

            // DataGridView'ın ContextMenuStrip özelliğini ayarlayın
            dataGridViewUserPortfolio.ContextMenuStrip = contextMenuStrip;
        }
        private async Task LoadHisseVerileriForPortfoyAsync()
        {
            cekilenHisseAdlari.Clear();
            dataTable.Clear();

            // Kullanıcının portföyündeki HisseAdi'ları alın
            List<string> portfoyHisseAdlari = dataGridViewUserPortfolio.Rows
                                                     .Cast<DataGridViewRow>()
                                                     .Select(row => row.Cells["Hisse Adı"].Value.ToString())
                                                     .Distinct() // Aynı hisse birden fazla varsa, yalnızca bir kez işlemek için
                                                     .ToList();

            foreach (string hisseAdiPortfoy in portfoyHisseAdlari)
            {
                // Çekilen hisse adlarını kontrol edin
                if (cekilenHisseAdlari.Contains(hisseAdiPortfoy))
                    continue;

                await GetirVeEkle(hisseAdiPortfoy);
            }
        }

        private void ExtractAndAddHisseData(HtmlNode hisseSenediNode, string hisseAdiPortfoy)
        {
            var h_b_ad = hisseSenediNode.SelectSingleNode(".//b[@id='h_b_ad_id_" + hisseAdiPortfoy + "']");
            var h_td_fiyat = hisseSenediNode.SelectSingleNode(".//td[@id='h_td_fiyat_id_" + hisseAdiPortfoy + "']");
            var h_td_yuzde = hisseSenediNode.SelectSingleNode(".//td[@id='h_td_yuzde_id_" + hisseAdiPortfoy + "']");
            var h_td_zaman = hisseSenediNode.SelectSingleNode(".//td[@id='h_td_zaman_id_" + hisseAdiPortfoy + "']");

            if (h_b_ad != null && h_td_fiyat != null && h_td_yuzde != null && h_td_zaman != null)
            {
                string hisseAdi = h_b_ad.InnerText.Trim();
                if (!dataGridView1.Rows.Cast<DataGridViewRow>().Any(row => row.Cells["Hisse Adı"].Value.ToString() == hisseAdi))
                {
                    string fiyat = h_td_fiyat.InnerText.Trim();
                    string yuzde = h_td_yuzde.InnerText.Trim();
                    string zaman = h_td_zaman.InnerText.Trim();

                    dataTable.Rows.Add(hisseAdi, fiyat, yuzde, zaman);
                    cekilenHisseAdlari.Add(hisseAdi);
                }
            }
        }
        private async void buttonGetir_Click(object sender, EventArgs e)
        {
            string hedefHisseKodu = textBoxHisseKodu.Text.Trim();
            if (string.IsNullOrEmpty(hedefHisseKodu))
            {
                MessageBox.Show("Lütfen bir hisse kodu girin.");
                return;
            }

            await GetirVeEkle(hedefHisseKodu);
        }
        private async Task GetirVeEkle(string hedefHisseKodu)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string url = "https://bigpara.hurriyet.com.tr/borsa/canli-borsa/tum-hisseler/";

                try
                {
                    string html = await httpClient.GetStringAsync(url);
                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    var hisseSenediNode = doc.DocumentNode.SelectSingleNode($"//ul[@data-symbol='{hedefHisseKodu}']");

                    if (hisseSenediNode != null)
                    {
                        var h_td_fiyat = hisseSenediNode.SelectSingleNode(".//li[@id='h_td_fiyat_id_" + hedefHisseKodu + "']");
                        var h_td_yuzde = hisseSenediNode.SelectSingleNode(".//li[@id='h_td_yuzde_id_" + hedefHisseKodu + "']");
                        var h_td_zaman = hisseSenediNode.SelectSingleNode(".//li[@id='h_td_saat_id_" + hedefHisseKodu + "']");

                        if (h_td_fiyat != null && h_td_yuzde != null && h_td_zaman != null)
                        {
                            string fiyat = h_td_fiyat.InnerText.Trim();
                            string yuzde = h_td_yuzde.InnerText.Trim();
                            string zaman = h_td_zaman.InnerText.Trim();

                            dataTable.Rows.Add(hedefHisseKodu, fiyat, yuzde, zaman);
                            dataGridView1.Refresh();
                        }
                    }
                    else
                    {
                        // MessageBox.Show("Geçersiz hisse kodu. Lütfen doğru bir hisse kodu girin.");
                    }
                }
                catch (Exception ex)
                {
                    // MessageBox.Show("Veri çekme hatası: " + ex.Message);
                }
            }
        }
        private void buttonHisseEkle_Click(object sender, EventArgs e)
        {
            string hisseAdi = textBoxHisseKodu.Text.Trim();
            int adet;
            decimal maliyet;

            if (string.IsNullOrEmpty(hisseAdi))
            {
                MessageBox.Show("Lütfen bir hisse adı girin.");
                return;
            }

            if (!int.TryParse(textBoxHisseAdet.Text, out adet) || adet <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir hisse adeti girin.");
                return;
            }

            if (!decimal.TryParse(textBoxHisseMaliyet.Text, out maliyet) || maliyet <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir maliyet girin.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string insertQuery = "INSERT INTO HisseTablosu (HisseAdi, Adet, Maliyet, KullaniciEposta) VALUES (@HisseAdi, @Adet, @Maliyet, @KullaniciEposta)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@HisseAdi", hisseAdi);
                    command.Parameters.AddWithValue("@Adet", adet);
                    command.Parameters.AddWithValue("@Maliyet", maliyet);
                    command.Parameters.AddWithValue("@KullaniciEposta", epostalabel.Text); // Eposta buradan gelmeli

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Hisse başarıyla eklendi.");
                            LoadUserPortfolio(); // Kullanıcı portföyünü güncelle
                        }
                        else
                        {
                            MessageBox.Show("Hisse eklenirken bir hata oluştu.");
                            veriErisimiHatasi = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Veritabanına veri eklerken bir hata oluştu: " + ex.Message);
                        veriErisimiHatasi = true;
                    }
                }
            }
        }

        private void LoadUserPortfolio()
        {
            // Önceki verileri temizlemeden önce dataGridViewUserPortfolio'un DataSource'ını null yapın
            dataGridViewUserPortfolio.DataSource = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT HisseAdi, Adet, Maliyet FROM HisseTablosu WHERE KullaniciEposta = @KullaniciEposta";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@KullaniciEposta", epostalabel.Text);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        // Yeni bir DataTable oluşturun ve verileri bu DataTable'a yükleyin
                        DataTable newDataTable = new DataTable();
                        newDataTable.Columns.Add("Hisse Adı", typeof(string));
                        newDataTable.Columns.Add("Adet", typeof(int));
                        newDataTable.Columns.Add("Maliyet", typeof(decimal));

                        while (reader.Read())
                        {
                            string hisseAdi = reader["HisseAdi"].ToString();
                            int adet = Convert.ToInt32(reader["Adet"]);
                            decimal maliyet = Convert.ToDecimal(reader["Maliyet"]);

                            newDataTable.Rows.Add(hisseAdi, adet, maliyet);
                        }

                        reader.Close();

                        // Yeni DataTable'ı dataGridViewUserPortfolio'un DataSource'ına ayarlayın
                        dataGridViewUserPortfolio.DataSource = newDataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Kullanıcı hisse portföyü yüklenirken bir hata oluştu: " + ex.Message);
                    }
                }
            }
        }

        private void MenuItemSat_Click(object sender, EventArgs e)
        {
            // Seçili satırı al
            if (dataGridViewUserPortfolio.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewUserPortfolio.SelectedRows[0];
                string hisseAdi = selectedRow.Cells["Hisse Adı"].Value.ToString();
                int adet = Convert.ToInt32(selectedRow.Cells["Adet"].Value);
                decimal maliyet = Convert.ToDecimal(selectedRow.Cells["Maliyet"].Value);

                DialogResult result = MessageBox.Show($"'{hisseAdi}' hissesini satmak istediğinize emin misiniz?", "Hisse Satışı Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Satış işlemini gerçekleştirin
                    SatHisse(hisseAdi, adet, maliyet);

                    // Kullanıcı portföyünü güncelle
                    LoadUserPortfolio();
                }
            }
            else
            {
                MessageBox.Show("Lütfen satmak istediğiniz hisseyi seçin.");
            }
        }

        private void SatHisse(string hisseAdi, int adet, decimal maliyet)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string deleteQuery = "DELETE FROM HisseTablosu WHERE HisseAdi = @HisseAdi AND KullaniciEposta = @KullaniciEposta AND Adet = @adet AND Maliyet = @maliyet";

                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@HisseAdi", hisseAdi);
                    command.Parameters.AddWithValue("@KullaniciEposta", epostalabel.Text);
                    command.Parameters.AddWithValue("@adet", adet);
                    command.Parameters.AddWithValue("@maliyet", maliyet);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"{hisseAdi} hissesi başarıyla satıldı.");
                        }
                        else
                        {
                            MessageBox.Show("Satış işlemi gerçekleştirilemedi.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Satış işlemi sırasında bir hata oluştu: " + ex.Message);
                    }
                }
            }
        }


        private void MenuItemDuzenle_Click(object sender, EventArgs e)
        {
            // Seçili satırı al
            if (dataGridViewUserPortfolio.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewUserPortfolio.SelectedRows[0];
                string hisseAdi = selectedRow.Cells["Hisse Adı"].Value.ToString();
                int adet = Convert.ToInt32(selectedRow.Cells["Adet"].Value);
                decimal maliyet = Convert.ToDecimal(selectedRow.Cells["Maliyet"].Value);

                // Düzenleme formunu göster
                DuzenlemeForm duzenlemeForm = new DuzenlemeForm(hisseAdi, adet, maliyet, epostalabel.Text);
                if (duzenlemeForm.ShowDialog() == DialogResult.OK)
                {
                    LoadUserPortfolio(); // Kullanıcı portföyünü güncelle
                }
            }
            else
            {
                MessageBox.Show("Lütfen düzenlemek istediğiniz hisseyi seçin.");
            }
        }

        private void buttonToplaOrtalamaMaliyet_Click(object sender, EventArgs e)
        {
            ToplaVeOrtalamaMaliyetGoster();
        }

        private async Task<decimal> GetGuncelHisseDegeriAsync(string hisseAdi)
        {
            decimal hisseDegeri = 0.0m; // Varsayılan değeri ayarlayın

            // Web sitesinden güncel hisse değerini çekmek için HttpClient kullanın
            using (HttpClient httpClient = new HttpClient())
            {
                string url = "https://bigpara.hurriyet.com.tr/borsa/canli-borsa/tum-hisseler/";

                try
                {
                    string html = await httpClient.GetStringAsync(url);

                    // HTML belgesini HtmlAgilityPack ile analiz edin
                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    // Belirtilen hisse kodunu içeren satırı seçin
                    var hisseSenediNode = doc.DocumentNode.SelectSingleNode($"//ul[@data-symbol='{hisseAdi}']");

                    if (hisseSenediNode != null)
                    {
                        // Hisse senedinin güncel fiyatını alın
                        var h_td_fiyat = hisseSenediNode.SelectSingleNode(".//li[@id='h_td_fiyat_id_" + hisseAdi + "']");

                        if (h_td_fiyat != null)
                        {
                            string fiyat = h_td_fiyat.InnerText.Trim().Replace(",", ""); // Virgülü kaldırın
                                                                                         // Güncel hisse değeri olarak dönüştürün
                            if (decimal.TryParse(fiyat, out hisseDegeri))
                            {
                                return hisseDegeri;
                            }
                        }
                    }
                    else
                    {
                        //MessageBox.Show("Geçersiz hisse kodu. Lütfen doğru bir hisse kodu girin.");
                    }
                }
                catch (Exception ex)
                {
                    // MessageBox.Show("Veri çekme hatası: " + ex.Message);
                }
            }

            return hisseDegeri;
        }

        private async Task ToplaVeOrtalamaMaliyetGoster()
        {
            // Kullanıcının hisse verilerini veritabanından çekin
            DataTable userPortfolioTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT HisseAdi, SUM(Adet) AS ToplamAdet, ROUND(AVG(Maliyet), 2) AS OrtalamaMaliyet " +
                                     "FROM HisseTablosu " +
                                     "WHERE KullaniciEposta = @KullaniciEposta " +
                                     "GROUP BY HisseAdi";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@KullaniciEposta", epostalabel.Text);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        userPortfolioTable.Load(reader);
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Kullanıcı hisse portföyü yüklenirken bir hata oluştu: " + ex.Message);
                        return;
                    }
                }
            }

            // Sonuçları dataGridViewOrtalamaMaliyet DataGridView'ine bağlayın
            dataGridViewOrtalamaMaliyet.DataSource = userPortfolioTable;
            dataGridViewOrtalamaMaliyet.Columns["OrtalamaMaliyet"].DefaultCellStyle.Format = "N2";

            

            // Her bir hisse için güncel hisse değerini hesapla ve göster
            foreach (DataGridViewRow row in dataGridViewOrtalamaMaliyet.Rows)
            {
                string hisseAdi = row.Cells["HisseAdi"].Value.ToString();
                decimal ortalamaMaliyet = Math.Round(Convert.ToDecimal(row.Cells["OrtalamaMaliyet"].Value), 2); // Round to 2 decimal places
                decimal adet = Convert.ToDecimal(row.Cells["ToplamAdet"].Value);

                decimal guncelHisseDegeri = await GetGuncelHisseDegeriAsync(hisseAdi) / 100; // Değerin 100'e bölünmesi

                decimal maliyettutarı = ortalamaMaliyet * adet;
                decimal caritutar = guncelHisseDegeri * adet;
                //this.Alert(hisseAdi + " "+ guncelHisseDegeri.ToString(), Form_Alert.enmType.Info);
                // Kar veya zarar miktarını ve yüzdesini hesapla
                decimal karZararMiktari = (guncelHisseDegeri - ortalamaMaliyet) * adet;
                decimal karZararYuzdesi = ((guncelHisseDegeri / ortalamaMaliyet) * 100) - 100;

                // Kar veya zarar miktarı ve yüzdesini DataGridView'e ekleyin
                //DataGridViewCell miktarCell = row.Cells[0];

                row.Cells["KarZararMiktari"].Value = karZararMiktari.ToString("N2");
                row.Cells["KarZararYuzdesi"].Value = "% " + Math.Round(karZararYuzdesi, 1);
                row.Cells["MaliyetTutarı"].Value = maliyettutarı.ToString("N2");
                row.Cells["GuncelHisseDegeri"].Value = guncelHisseDegeri.ToString("N2");
                row.Cells["CariTutar"].Value = caritutar.ToString("N2");
                if (karZararYuzdesi <= 0)
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    // "-" değilse, varsayılan renk kullanılabilir
                    row.DefaultCellStyle.ForeColor = Color.LimeGreen;
                }

                ToplamKarZararHesaplaAsync();
               
            }

        }





        // Toplam portföy değerini hesaplamak için
        private decimal ToplamPortfoyDegeriHesapla()
        {
            decimal toplamPortfoyDegeri = 0.0m;

            foreach (DataGridViewRow row in dataGridViewUserPortfolio.Rows)
            {
                decimal maliyet = Convert.ToDecimal(row.Cells["Maliyet"].Value);
                int adet = Convert.ToInt32(row.Cells["Adet"].Value);
                toplamPortfoyDegeri += maliyet * adet;
            }

            return toplamPortfoyDegeri;
        }

        private async void borsaanasayfa_Load(object sender, EventArgs e)
        {
            ToplaVeOrtalamaMaliyetGoster();
            await LoadHisseVerileriForPortfoyAsync();
            decimal toplamPortfoyDegeri = ToplamPortfoyDegeriHesapla();
            toplamPortfoyLabel.Text = toplamPortfoyDegeri.ToString("C2");


            ResetAndStartTimer();
        }
        private void ResetAndStartTimer()
        {
            remainingTime = 600; // 10 dakika
            timer1.Start();
            UpdateTimerLabel(remainingTime);
        }
        private void UpdateTimerLabel(int seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            labelTimer.Text = $"Oto Update: Kalan süre: {time.Minutes} dakika {time.Seconds} saniye";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            remainingTime -= 1; // Her tick'te kalan süreyi 1 saniye azalt

            if (remainingTime <= 0)
            {
                // Süre dolduğunda button2_Click metodunu çağır ve timer'ı yeniden başlat
                button2.PerformClick();
                ResetAndStartTimer();
            }
            else
            {
                // Kalan süreyi güncelle
                UpdateTimerLabel(remainingTime);
            }
        }

        private async Task<decimal> ToplamKarZararHesaplaAsync()
        {
            try
            {
                decimal toplamKarZarar = 0.0m;

                foreach (DataGridViewRow row in dataGridViewOrtalamaMaliyet.Rows)
                {
                    // KarZararMiktari sütunundaki değeri kontrol edin ve varsa toplama ekleyin
                    if (row.Cells["KarZararMiktari"].Value != DBNull.Value)
                    {
                        decimal karZararMiktari = Convert.ToDecimal(row.Cells["KarZararMiktari"].Value);
                        toplamKarZarar += karZararMiktari;
                    }
                }

                // Asenkron olarak arayüz güncellemesi yapın
                toplamKarZararLabel.Invoke((MethodInvoker)delegate
                {
                    toplamKarZararLabel.Text = toplamKarZarar.ToString("N2") + " ₺";
                    decimal portfoydeger = ToplamPortfoyDegeriHesapla();
                    toplamCariPortfoyLabel.Text = (toplamKarZarar + portfoydeger).ToString("N2") + " ₺";
                });

                return toplamKarZarar;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
                return 0;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            ResetAndStartTimer(); // Timer'ı yeniden başlat

            LoadHisseVerileriForPortfoyAsync();
            ToplamKarZararHesaplaAsync();
            // Diğer güncellemeleri de yap
            ToplaVeOrtalamaMaliyetGoster();

            decimal toplamPortfoyDegeri = ToplamPortfoyDegeriHesapla();
            toplamPortfoyLabel.Text = toplamPortfoyDegeri.ToString("C2");


        }
        private void DataGridViewToExcel(DataGridView dataGridView, string filePath)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Excel yüklü değil.");
                return;
            }

            xlApp.Visible = false;
            Workbook xlWorkbook = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Worksheet xlWorksheet = (Worksheet)xlWorkbook.Sheets[1];

            // Başlık renk ve kalınlık ayarları
            Range headerRange = xlWorksheet.Range[xlWorksheet.Cells[1, 1], xlWorksheet.Cells[1, 8]];
            headerRange.Font.Bold = true;
            headerRange.Interior.Color = XlRgbColor.rgbSkyBlue;

            // Sütun başlıklarını ve verileri belirlediğiniz sırayla ekle
            xlWorksheet.Cells[1, 1] = "Hisse Adı";
            xlWorksheet.Cells[1, 2] = "Toplam Adet";
            xlWorksheet.Cells[1, 3] = "Ortalama Maliyet";
            xlWorksheet.Cells[1, 4] = "Güncel Fiyat";
            xlWorksheet.Cells[1, 5] = "Maliyet Tutarı";
            xlWorksheet.Cells[1, 6] = "Cari Tutarı";
            xlWorksheet.Cells[1, 7] = "Kar Zarar Miktarı";
            xlWorksheet.Cells[1, 8] = "Kar Zarar Yüzdesi";

            decimal toplamMaliyetTutari = 0;
            decimal toplamCariTutar = 0;
            decimal toplamKarZararMiktari = 0;
            decimal genelkarzarar = 0;
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                xlWorksheet.Cells[i + 2, 1] = dataGridView.Rows[i].Cells["HisseAdi"].Value;
                xlWorksheet.Cells[i + 2, 2] = dataGridView.Rows[i].Cells["ToplamAdet"].Value;
                xlWorksheet.Cells[i + 2, 3] = dataGridView.Rows[i].Cells["OrtalamaMaliyet"].Value;
                xlWorksheet.Cells[i + 2, 4] = dataGridView.Rows[i].Cells["GuncelHisseDegeri"].Value;
                xlWorksheet.Cells[i + 2, 5] = dataGridView.Rows[i].Cells["MaliyetTutarı"].Value;
                xlWorksheet.Cells[i + 2, 6] = dataGridView.Rows[i].Cells["CariTutar"].Value;
                xlWorksheet.Cells[i + 2, 7] = dataGridView.Rows[i].Cells["KarZararMiktari"].Value;
                xlWorksheet.Cells[i + 2, 8] = dataGridView.Rows[i].Cells["KarZararYuzdesi"].Value;

                // Toplamları hesapla
                toplamMaliyetTutari += Convert.ToDecimal(dataGridView.Rows[i].Cells["MaliyetTutarı"].Value);
                toplamCariTutar += Convert.ToDecimal(dataGridView.Rows[i].Cells["CariTutar"].Value);
                toplamKarZararMiktari += Convert.ToDecimal(dataGridView.Rows[i].Cells["KarZararMiktari"].Value);
                
            }

            // Toplam Satırı ekle
            xlWorksheet.Cells[dataGridView.Rows.Count + 2, 1] = "Toplam";
            xlWorksheet.Cells[dataGridView.Rows.Count + 2, 5] = toplamMaliyetTutari;
            xlWorksheet.Cells[dataGridView.Rows.Count + 2, 6] = toplamCariTutar;
            xlWorksheet.Cells[dataGridView.Rows.Count + 2, 7] = toplamKarZararMiktari;
            xlWorksheet.Cells[dataGridView.Rows.Count + 2, 8] = Math.Round(((toplamKarZararMiktari * 100) / toplamMaliyetTutari),2);

            // Toplam satırını renklendir
            Range totalRange = xlWorksheet.Range[xlWorksheet.Cells[dataGridView.Rows.Count + 2, 1], xlWorksheet.Cells[dataGridView.Rows.Count + 2, 8]];
            totalRange.Interior.Color = XlRgbColor.rgbLightGray;

            // Toplam satırını kalın yap
            totalRange.Font.Bold = true;

            // Toplam satırına çerçeve ekle
            totalRange.Borders.LineStyle = XlLineStyle.xlContinuous;

            // Sütun genişliklerini otomatik ayarla
            xlWorksheet.Columns.AutoFit();

           
            // Excel dosyasını kaydet
            xlWorkbook.SaveAs(filePath);
            xlWorkbook.Close();

            DialogResult openFile = MessageBox.Show("Excel dosyası kaydedildi. Dosyayı şimdi açmak ister misiniz?", "Dosya Aç", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (openFile == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(filePath);
            }

            xlApp.Quit();
        }

        private void excelaktar_Click(object sender, EventArgs e)
        {
            // Tüm verilerin yüklendiğinden emin olma uyarısı
            DialogResult checkDataLoaded = MessageBox.Show(
                "Bu işlemi yapmadan önce tüm hisse verilerinin yüklendiğinden emin olun. Devam etmek istiyor musunuz?",
                "Veri Kontrolü",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (checkDataLoaded != DialogResult.Yes)
            {
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xlsx)|*.xlsx";
            sfd.FileName = DateTime.Now.ToString("dd.MM.yyyy") + " Portföy.xlsx"; // Dosya adını tarih ile ayarla
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // DataGridViewToExcel metodunu kullanarak Excel'e aktar ve kaydet
                DataGridViewToExcel(dataGridViewOrtalamaMaliyet, sfd.FileName);

            }

        }
        

    }
}
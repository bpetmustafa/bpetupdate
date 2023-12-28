using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using LiveCharts;
using LiveCharts.Wpf;
using Axis = LiveCharts.Wpf.Axis;
using System.Windows.Media;
using System.Windows;
using MessageBox = System.Windows.Forms.MessageBox;
using Color = System.Drawing.Color;

namespace BPET_PORTAL
{
    public partial class gunluksatisraporekrani : Form
    {
        private const string connectionString = "Server=95.0.50.22,1382;Database=rapor;User ID=sa;Password=Mustafa1;";
        SqlConnection connection = new SqlConnection(connectionString);
        private bool dosyaDegisti = false; // Dosyanın değişip değişmediğini izlemek için bir bayrak
        private const string kullaniciAdi = "musatafa.ceylan"; // Replace with your FTP username
        private const string sifre = "Defne2023"; // Replace with your FTP password


        public gunluksatisraporekrani()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Today.AddDays(-1);
            dateTimePicker1.MaxDate = DateTime.Today;
            dateTimePicker2.MaxDate = DateTime.Today;

            metroDateTime1.Value = DateTime.Today.AddDays(-1);
            metroDateTime1.MaxDate = DateTime.Today;
            metroDateTime2.MaxDate = DateTime.Today;
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        private void raporekrani_Load(object sender, EventArgs e)
        {
            // İlk DateTimePicker'ı dün tarihine ayarla
            dateTimePicker1.Value = DateTime.Today.AddDays(-1);

            // İkinci DateTimePicker'ı bugünün tarihine ayarla
            dateTimePicker2.Value = DateTime.Today.AddDays(-1);

            // İlk DateTimePicker'ın değeri değiştiğinde verileri doldur
            dateTimePicker1.ValueChanged += (s, ev) =>
            {
                DateTime startDate = dateTimePicker1.Value;
                DateTime endDate = dateTimePicker2.Value;

                if (startDate > endDate)
                {
                    this.Alert("Başlangıç tarihi, bitiş tarihinden büyük olamaz.", Form_Alert.enmType.Warning);

                    
                    return;
                }

                if (karsilastir.Checked == true)
                {
                    DateTime selectedDate = dateTimePicker1.Value;
                    DateTime selectedDate2 = dateTimePicker2.Value;
                    List<string> veriler = GetVeriler(startDate, endDate);
                    DoldurTablo(veriler);
                    DoldurDataGridView(veriler);
                }
                if (karsilastir.Checked == false)
                {
                    DateTime selectedDate = dateTimePicker1.Value;
                    List<string> veriler = GetVeriler(startDate, startDate);
                    DoldurTablo(veriler);
                    DoldurDataGridView(veriler);
                }
            };

            // İkinci DateTimePicker'ın değeri değiştiğinde verileri doldur
            dateTimePicker2.ValueChanged += (s, ev) =>
            {
                DateTime startDate = dateTimePicker1.Value;
                DateTime endDate = dateTimePicker2.Value;

                if (startDate > endDate)
                {
                    return;
                }

                List<string> veriler = GetVeriler(startDate, endDate);
                DoldurTablo(veriler);
                DoldurDataGridView(veriler);
            };
        }


        private List<string> GetVeriler(DateTime startDate, DateTime endDate)
        {
            List<string> veriler = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT SUM(Motorin) AS Motorin, SUM(MotorinDiger) AS MotorinDiger, SUM(Benzin) AS Benzin, SUM(Lpg) AS Lpg, SUM(LpgDokme) AS LpgDokme, " +
                    "SUM(Mersin) AS Mersin, SUM(İzmir) AS İzmir, SUM(İzmit) AS İzmit, SUM(Kırıkkale) AS Kırıkkale, SUM(Batman) AS Batman, SUM(Tekirdag) AS Tekirdag, " +
                    "SUM(Giresun) AS Giresun, SUM(Antalya) AS Antalya, SUM(Trabzon) AS Trabzon, SUM(Diyarbakır) AS Diyarbakır, SUM(Hatay) AS Hatay, " +
                    "SUM(Samsun) AS Samsun, SUM(Toplam) AS Toplam, SUM(ToplamKara) AS ToplamKara FROM gunluk_veri WHERE Zaman >= @StartDate AND Zaman <= @EndDate";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StartDate", startDate);
                if (karsilastir.Checked == true)
                {
                    command.Parameters.AddWithValue("@EndDate", endDate);
                }
                else
                {
                    command.Parameters.AddWithValue("@EndDate", startDate);

                }

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        veriler.Add(reader["Motorin"].ToString());
                        veriler.Add(reader["MotorinDiger"].ToString());
                        veriler.Add(reader["Benzin"].ToString());
                        veriler.Add(reader["Lpg"].ToString());
                        veriler.Add(reader["LpgDokme"].ToString());

                        // Mersin, İzmir, İzmit, vb. verileri de ekleyin
                        veriler.Add(reader["Mersin"].ToString());
                        veriler.Add(reader["İzmir"].ToString());
                        veriler.Add(reader["İzmit"].ToString());
                        veriler.Add(reader["Kırıkkale"].ToString());
                        veriler.Add(reader["Batman"].ToString());
                        veriler.Add(reader["Tekirdag"].ToString());
                        veriler.Add(reader["Giresun"].ToString());
                        veriler.Add(reader["Antalya"].ToString());
                        veriler.Add(reader["Trabzon"].ToString());
                        veriler.Add(reader["Diyarbakır"].ToString());
                        veriler.Add(reader["Hatay"].ToString());
                        veriler.Add(reader["Samsun"].ToString());
                        veriler.Add(reader["Toplam"].ToString());
                        veriler.Add(reader["ToplamKara"].ToString());
                    }
                }
            }

            return veriler;
        }
        private void DoldurDataGridView(List<string> veriler)
        {
            // DataGridView'i temizle
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // İller sütunu oluştur
            dataGridView1.Columns.Add("Iller", "İller");

            // İl isimleri
            string[] iller = { "Mersin", "İzmir", "İzmit", "Kırıkkale", "Batman", "Tekirdağ", "Giresun", "Antalya", "Trabzon", "Diyarbakır", "Hatay", "Samsun" };

            if (veriler.Count >= 13) // İller ve Toplam değeri için toplam 13 veri bekleniyor.
            {
                // İl değerlerini DataGridView'e ekle
                for (int i = 0; i < 12; i++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = iller[i] });
                    dataGridView1.Rows.Add(row);
                }

                // Tek bir değer sütunu oluştur
                dataGridView1.Columns.Add("Degerler", "Değerler");

                // İl değerlerini DataGridView'e ekle
                for (int i = 0; i < 12; i++)
                {
                    dataGridView1.Rows[i].Cells["Degerler"].Value = veriler[i + 1]; // İlgili değeri al (veriler listesinde ilk veri iller için)
                }

                // Toplam değerini DataGridView'e ekle
                DataGridViewRow totalRow = new DataGridViewRow();
                totalRow.Cells.Add(new DataGridViewTextBoxCell { Value = "Toplam" });
                dataGridView1.Rows.Add(totalRow);
                dataGridView1.Rows[12].Cells["Degerler"].Value = veriler[17];

                // DataGridView stilini özelleştir
               
                dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders; // İller sütununun otomatik boyutlanmasını sağla
                dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Hücre içeriğini ortala
            }
            else
            {
                // Veriler eksikse veya hata varsa uyarı ver
                MessageBox.Show("Veriler eksik veya hatalı. Lütfen geçerli verileri çekin.");
            }
        }



        private void DoldurTablo(List<string> veriler)
        {
            bool verilerEksik = veriler.Count < 5; // Verilerin eksik olduğunu kontrol et (5 veri bekleniyor)
            bool hataVar = false;

            // Eğer veriler eksikse veya dönüşüm hatası varsa
            foreach (string veri in veriler)
            {
                if (!int.TryParse(veri, out _))
                {
                    hataVar = true;
                    break;
                }
            }

            // Grafiği doldurmadan önce temizle
            cartesianChartYakitMiktarlari.Series.Clear();
            cartesianChartYakitMiktarlari.AxisX.Clear();
            cartesianChartYakitMiktarlari.AxisY.Clear();
            cartesianChartYakitMiktarlari.LegendLocation = LegendLocation.None;
            cartesianChartYakitMiktarlari.Zoom = ZoomingOptions.None;
            cartesianChartYakitMiktarlari.Pan = PanningOptions.None;
            
            if (verilerEksik || hataVar)
            {
                motorindigerlabel.Text = "HATA";
                motorinlabel.Text = "HATA";
                benzinlabel.Text = "HATA";
                lpgperakende.Text = "HATA";
                lpgdokme.Text = "HATA";
                toplamlabel.Text = "HATA";
                this.Alert("Veriler eksik veya hatalı. Lütfen geçerli verileri girin.", Form_Alert.enmType.Warning);
            }
            else
            {
                // Veriler eksik değilse grafiği oluştur
                decimal motorinLT = Convert.ToDecimal(veriler[0]);
                decimal motorinDigerLT = Convert.ToDecimal(veriler[1]);
                decimal benzinLT = Convert.ToDecimal(veriler[2]);
                decimal siyahtoplamlabel2 = Convert.ToDecimal(veriler[18]);

                motorinlabel.Text = motorinLT.ToString("N0") + " LT";
                motorindigerlabel.Text = motorinDigerLT.ToString("N0") + " LT";
                benzinlabel.Text = benzinLT.ToString("N0") + " LT";
                lpgperakende.Text = Convert.ToDecimal(veriler[3]).ToString("N0") + " KG";
                lpgdokme.Text = Convert.ToDecimal(veriler[4]).ToString("N0") + " KG";

                decimal toplamLT = motorinLT + motorinDigerLT + benzinLT;
                toplamlabel.Text = toplamLT.ToString("N0") + " LT";
                siyahtoplamlabel.Text = siyahtoplamlabel2.ToString("N0") + " KG";

                // Seriyi oluşturun ve verileri bağlayın
                LiveCharts.SeriesCollection yakitSeriesCollection = new LiveCharts.SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Yakıt Miktarları",
                        Values = new ChartValues<double> {Convert.ToDouble(motorinLT), Convert.ToDouble(motorinDigerLT), Convert.ToDouble(benzinLT), Convert.ToDouble(veriler[3]), Convert.ToDouble(veriler[4])},
                        FontSize = 16, // Yazı boyutunu ayarla
                        Foreground = new SolidColorBrush(Colors.White), // Yazı rengini beyaz yap
                        FontWeight = FontWeights.Bold // Yazı kalınlığını ayarla
                    }
                };

                // Grafiğe seriyi ekleyin
                cartesianChartYakitMiktarlari.Series = yakitSeriesCollection;

                // Grafik stilini özelleştirin
               // cartesianChartYakitMiktarlari.BackColor = System.Drawing.Color.Transparent;

                // Eksen etiketlerini ayarlayın
                cartesianChartYakitMiktarlari.AxisX.Add(new Axis
                {
                    Title = "Yakıt Türü",
                    Labels = new[] { "Motorin", "Motorin Diğer", "Benzin", "LPG", "LPG Dökme" },
                    Separator = new Separator { Step = 1 },
                    LabelsRotation = 15,
                    FontSize = 16, // Yazı boyutunu ayarla
                    Foreground = new SolidColorBrush(Colors.White), // Yazı rengini beyaz yap
                    FontWeight = FontWeights.Bold // Yazı kalınlığını ayarla
                });

                cartesianChartYakitMiktarlari.AxisY.Add(new Axis
                {
                    Title = "Miktar (LT/KG)",
                    LabelFormatter = value => value.ToString("N0"),
                    FontSize = 16, // Yazı boyutunu ayarla
                    Foreground = new SolidColorBrush(Colors.White), // Yazı rengini beyaz yap
                    FontWeight = FontWeights.Bold // Yazı kalınlığını ayarla
                });

                // Veri etiketlerini N0 formatında ayarlayın
                foreach (var series in cartesianChartYakitMiktarlari.Series)
                {
                   // foreach (var values in series.Values)
                   // {
                   //     values.Label = Convert.ToDouble(values.Y).ToString("N0");
                   // }
                }
            }
        }
            private void metroDateTime1_ValueChanged(object sender, EventArgs e)
        {
            if (karsilastir.Checked == true)
            {
                DateTime selectedDate = dateTimePicker1.Value;
                DateTime selectedDate2 = dateTimePicker2.Value;
                List<string> veriler = GetVeriler(selectedDate, selectedDate2);
                DoldurTablo(veriler);
                DoldurDataGridView(veriler);
            }
            if (karsilastir.Checked == false)
            {
                DateTime selectedDate = dateTimePicker1.Value;
                
                List<string> veriler = GetVeriler(selectedDate, selectedDate);
                DoldurTablo(veriler);
                DoldurDataGridView(veriler);
            }

        }

        private void karsilastir_CheckedChanged(object sender, EventArgs e)
        {
            if (karsilastir.Checked == true)
            {
                DateTime selectedDate = dateTimePicker1.Value;
                DateTime selectedDate2 = dateTimePicker2.Value;
                List<string> veriler = GetVeriler(selectedDate, selectedDate2);
                DoldurTablo(veriler);
                DoldurDataGridView(veriler);
            }
            if (karsilastir.Checked == false)
            {
                DateTime selectedDate = dateTimePicker1.Value;
                List<string> veriler = GetVeriler(selectedDate, selectedDate);
                DoldurTablo(veriler);
                DoldurDataGridView(veriler);
            }
        }

        private async void anlikvericek_ClickAsync(object sender, EventArgs e)
        {
             bool bitti = false;
            bool pdfAcildi = false;

            if (bitti == false)
            {
                anlikvericek.Enabled = false;
                anlıkvericekprogressspin.Visible = true;

                try
                {
                    // SQL bağlantısını oluştur
                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // SQL sorgusunu hazırla ve çalıştır
                        string updateQuery = "UPDATE appveriiste SET Veriiste = 1 WHERE id = 467";
                        using (var command = new SqlCommand(updateQuery, connection))
                        {
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                               // this.Alert("Veri başarıyla güncellendi.", Form_Alert.enmType.Info);
                            }
                            else
                            {
                                MessageBox.Show("Veri güncellenemedi. Belirtilen ID bulunamadı.");
                            }
                        }

                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }

                this.Alert("LÜTFEN BEKLEYİNİZ BU İŞLEM UZUN SÜREBİLİR!", Form_Alert.enmType.Warning);


                // Bugünün tarihini al
                // FTP bağlantısı için gerekli bilgiler
                string ftpSunucu = "ftp://95.0.50.22:1381/bpet_portal/raporpdf/";
                string kullaniciAdi = "mustafa.ceylan";
                string sifre = "Defne2023";

                // Beklenen dosya adını oluştur
                string beklenenDosyaAdi = DateTime.Now.ToString("yyyy-MM-dd") + ".pdf";

                // Dosya yolunu oluştur
                string dosyaYolu = ftpSunucu + beklenenDosyaAdi;

                if (!dosyaDegisti && bitti == false)
                {
                    try
                    {
                        // Ftp istemcisini oluştur
                        WebClient ftpIstemcisi = new WebClient();
                        ftpIstemcisi.Credentials = new NetworkCredential(kullaniciAdi, sifre);
                        try
                        {
                            // SQL bağlantısını oluştur
                            using (var connection = new SqlConnection(connectionString))
                            {
                               
                                while (!pdfAcildi) // Sonsuz bir döngü başlat
                                {
                                    connection.Open();
                                    // SQL sorgusunu hazırla ve çalıştır
                                    string selectQuery = "SELECT Veriiste FROM appveriiste WHERE id = 467";
                                    using (var selectCommand = new SqlCommand(selectQuery, connection))
                                    {
                                        int veriiste = Convert.ToInt32(selectCommand.ExecuteScalar());
                                        if (veriiste == 2)
                                        {
                                            System.Threading.Thread.Sleep(3000);
                                            // Dosya değişti, indir ve aç
                                            byte[] dosyaVerisi = ftpIstemcisi.DownloadData(dosyaYolu);
                                            string kaydetmeYolu = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + beklenenDosyaAdi;
                                            File.WriteAllBytes(kaydetmeYolu, dosyaVerisi);
                                            System.Diagnostics.Process.Start(kaydetmeYolu);
                                            this.Alert("Dosya başarıyla indirildi ve açıldı.", Form_Alert.enmType.Success);
                                            bitti = true;
                                            pdfAcildi = true; // PDF açıldığını işaretle
                                            anlikvericek.Enabled = true;
                                            anlıkvericekprogressspin.Visible = false;
                                        }
                                        else
                                        {
                                            await Task.Delay(TimeSpan.FromSeconds(5));
                                            this.Alert("Veri Çekme İşlemi Tamamlanmak Üzere!", Form_Alert.enmType.Warning);
                                        }
                                    }

                                    connection.Close();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hata: " + ex.Message);
                        }
                        
                    }
                    catch (WebException ex)
                    {
                        // Dosya bulunamadığında veya başka bir hata oluştuğunda buraya düşer
                        MessageBox.Show("Hata: Dosya bulunamadı veya başka bir hata oluştu. Hata Detayı: " + ex.Message);
                    }
                }



            }
            else if  (bitti == true){
                anlikvericek.Enabled = true;
                anlıkvericekprogressspin.Visible = false;
;            }
        }
       


        private void karsilastircheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if(karsilastir2yuzde.Checked == true)
            {
                karsilastirdatetimegroup.Visible = Enabled;
                KarşılaştırVeriler();
            }
            else if(karsilastir2yuzde.Checked== false){
                karsilastirdatetimegroup.Visible = false;
                karislastirgroup.Visible = false;
            }
        }

        public void aralikhesapla2_CheckedChanged(object sender, EventArgs e)
        {
            if (aralikhesapla2.Checked == true)
            {
                DateTime selectedDate11 = metroDateTime1.Value;
                DateTime selectedDate12 = metroDateTime2.Value;
                List<string> veriler2 = GetVeriler2(selectedDate11, selectedDate12);
                DoldurTablo2(veriler2);
                karislastirgroup.Visible = Enabled;
                sonucyüzdegroup.Visible = Enabled;
                KarşılaştırVeriler();
               
            }
            else if (aralikhesapla2.Checked == false)
            {
                DateTime selectedDate11 = metroDateTime1.Value;
                List<string> veriler2 = GetVeriler2(selectedDate11, selectedDate11);
                DoldurTablo2(veriler2);
                karislastirgroup.Visible = Enabled;
                sonucyüzdegroup.Visible = false;
                KarşılaştırVeriler();
            }
           
        }
        private string GetFarkLabelAdi(string labelAdi)
        {
            return labelAdi + "fark";
        }

        private string GetFarkPanelAdi(string labelAdi)
        {
            return labelAdi + "farkpanel";
        }

        private void KarşılaştırVeriler()
        {
            // Karşılaştırılacak etiketlerin dizisi
            Label[] labels = { motorinlabel, motorinlabel2, motorindigerlabel, motorindigerlabel2, benzinlabel, benzinlabel2, toplamlabel, toplamlabel2, lpgperakende, lpgperakende2, lpgdokme, lpgdokme2 };

            for (int i = 0; i < labels.Length; i += 2)
            {
                Label label1 = labels[i];
                Label label2 = labels[i + 1];

                decimal deger1, deger2;

                if (decimal.TryParse(ExtractNumbers(label1.Text), out deger1) && decimal.TryParse(ExtractNumbers(label2.Text), out deger2))
                {
                    if (deger1 != 0)
                    {
                        decimal farkYuzde = ((deger2 - deger1) / deger1) * 100;
                        string farkYuzdeMetni = $"{farkYuzde:F2}%";

                        // İlgili fark Label'ına değeri ata
                        string farkLabelAdi = GetFarkLabelAdi(label1.Name);
                        Label farkLabel = this.Controls.Find(farkLabelAdi, true).FirstOrDefault() as Label;

                        if (farkLabel != null)
                        {
                            farkLabel.Text = farkYuzdeMetni;

                            // Fark pozitifse yeşil, negatifse kırmızı olarak panel rengini ayarla
                            string farkPanelAdi = GetFarkPanelAdi(label1.Name);
                            Panel farkPanel = this.Controls.Find(farkPanelAdi, true).FirstOrDefault() as Panel;

                            if (farkPanel != null)
                            {
                                if (farkYuzde > 0)
                                {
                                    farkPanel.BackColor = Color.Green;
                                }
                                else if (farkYuzde < 0)
                                {
                                    farkPanel.BackColor = Color.Red;
                                }
                                else
                                {
                                    farkPanel.BackColor = Color.Gray; // Fark yoksa beyaz yapabilirsiniz
                                }
                            }
                            else
                            {
                                Console.WriteLine("Panel bulunamadı: " + farkPanelAdi);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Label bulunamadı: " + farkLabelAdi);
                        }
                    }
                }
            }
        }


        private string ExtractNumbers(string input)
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }


        private List<string> GetVeriler2(DateTime startDate, DateTime endDate)
        {
            List<string> veriler2 = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT SUM(Motorin) AS Motorin, SUM(MotorinDiger) AS MotorinDiger, SUM(Benzin) AS Benzin, SUM(Lpg) AS Lpg, SUM(LpgDokme) AS LpgDokme, " +
                    "SUM(Mersin) AS Mersin, SUM(İzmir) AS İzmir, SUM(İzmit) AS İzmit, SUM(Kırıkkale) AS Kırıkkale, SUM(Batman) AS Batman, SUM(Tekirdag) AS Tekirdag, " +
                    "SUM(Giresun) AS Giresun, SUM(Antalya) AS Antalya, SUM(Trabzon) AS Trabzon, SUM(Diyarbakır) AS Diyarbakır, SUM(Hatay) AS Hatay, " +
                    "SUM(Samsun) AS Samsun, SUM(Toplam) AS Toplam FROM gunluk_veri WHERE Zaman >= @StartDate AND Zaman <= @EndDate";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StartDate", startDate);
                if (aralikhesapla2.Checked == true)
                {
                    command.Parameters.AddWithValue("@EndDate", endDate);
                }
                else
                {
                    command.Parameters.AddWithValue("@EndDate", startDate);

                }

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        veriler2.Add(reader["Motorin"].ToString());
                        veriler2.Add(reader["MotorinDiger"].ToString());
                        veriler2.Add(reader["Benzin"].ToString());
                        veriler2.Add(reader["Lpg"].ToString());
                        veriler2.Add(reader["LpgDokme"].ToString());

                        // Mersin, İzmir, İzmit, vb. verileri de ekleyin
                        veriler2.Add(reader["Mersin"].ToString());
                        veriler2.Add(reader["İzmir"].ToString());
                        veriler2.Add(reader["İzmit"].ToString());
                        veriler2.Add(reader["Kırıkkale"].ToString());
                        veriler2.Add(reader["Batman"].ToString());
                        veriler2.Add(reader["Tekirdag"].ToString());
                        veriler2.Add(reader["Giresun"].ToString());
                        veriler2.Add(reader["Antalya"].ToString());
                        veriler2.Add(reader["Trabzon"].ToString());
                        veriler2.Add(reader["Diyarbakır"].ToString());
                        veriler2.Add(reader["Hatay"].ToString());
                        veriler2.Add(reader["Samsun"].ToString());
                        veriler2.Add(reader["Toplam"].ToString());
                    }
                }
            }

            return veriler2;
        }
        private void DoldurTablo2(List<string> veriler2)
        {
            bool verilerEksik2 = veriler2.Count < 5; // Verilerin eksik olduğunu kontrol et (5 veri bekleniyor)
            bool hataVar2 = false;

            // Eğer veriler eksikse veya dönüşüm hatası varsa
            foreach (string veri in veriler2)
            {
                if (!int.TryParse(veri, out _))
                {
                    hataVar2 = true;
                    break;
                }
            }
            if (verilerEksik2 || hataVar2)
            {
                motorindigerlabel2.Text = "HATA";
                motorinlabel2.Text = "HATA";
                benzinlabel2.Text = "HATA";
                lpgperakende2.Text = "HATA";
                lpgdokme2.Text = "HATA";
                toplamlabel2.Text = "HATA";
                this.Alert("Veriler eksik veya hatalı. Lütfen geçerli verileri girin.", Form_Alert.enmType.Warning);


            }
            else
            {
                // Veriler eksik değilse grafiği oluştur
                decimal motorinLT = Convert.ToDecimal(veriler2[0]);
                decimal motorinDigerLT = Convert.ToDecimal(veriler2[1]);
                decimal benzinLT = Convert.ToDecimal(veriler2[2]);

                motorinlabel2.Text = motorinLT.ToString("N0") + " LT";
                motorindigerlabel2.Text = motorinDigerLT.ToString("N0") + " LT";
                benzinlabel2.Text = benzinLT.ToString("N0") + " LT";
                lpgperakende2.Text = Convert.ToDecimal(veriler2[3]).ToString("N0") + " KG";
                lpgdokme2.Text = Convert.ToDecimal(veriler2[4]).ToString("N0") + " KG";

                decimal toplamLT = motorinLT + motorinDigerLT + benzinLT;
                toplamlabel2.Text = toplamLT.ToString("N0") + " LT";

                
            }
        }

        private void metroDateTime1_ValueChanged_1(object sender, EventArgs e)
        {
            if (aralikhesapla2.Checked == true && karsilastir2yuzde.Checked == true)
            {
                DateTime selectedDate11 = metroDateTime1.Value;
                DateTime selectedDate12 = metroDateTime2.Value;
                List<string> veriler2 = GetVeriler2(selectedDate11, selectedDate12);
                DoldurTablo2(veriler2);
                karislastirgroup.Visible = Enabled;
                KarşılaştırVeriler();

            }
            else if (aralikhesapla2.Checked == false && karsilastir2yuzde.Checked == true)
            {
                DateTime selectedDate11 = metroDateTime1.Value;
                List<string> veriler2 = GetVeriler2(selectedDate11, selectedDate11);
                DoldurTablo2(veriler2);
                karislastirgroup.Visible = Enabled;
                KarşılaştırVeriler();
            }
        }

        private void metroDateTime2_ValueChanged(object sender, EventArgs e)
        {
            if (aralikhesapla2.Checked == true && karsilastir2yuzde.Checked == true)
            {
                DateTime selectedDate11 = metroDateTime1.Value;
                DateTime selectedDate12 = metroDateTime2.Value;
                List<string> veriler2 = GetVeriler2(selectedDate11, selectedDate12);
                DoldurTablo2(veriler2);
                karislastirgroup.Visible = Enabled;
                KarşılaştırVeriler();
            }
            else if (aralikhesapla2.Checked == false && karsilastir2yuzde.Checked == true)
            {
                DateTime selectedDate11 = metroDateTime1.Value;
                List<string> veriler2 = GetVeriler2(selectedDate11, selectedDate11);
                DoldurTablo2(veriler2);
                karislastirgroup.Visible = Enabled;
                KarşılaştırVeriler();
            }
        }
    }
}

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
using MessageBox = System.Windows.Forms.MessageBox;
using Color = System.Drawing.Color;
using System.Runtime.Serialization;
using System.Drawing.Printing;
using OfficeOpenXml.Export.ToDataTable;

namespace BPET_PORTAL
{
    public partial class gunluksatisraporekrani : Form
    {
        private const string connectionString = "Server=95.0.50.22,1382;Database=rapor;User ID=sa;Password=Mustafa1;";
        private bool dosyaDegisti = false; // Dosyanın değişip değişmediğini izlemek için bir bayrak
        public gunluksatisraporekrani()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Today.AddDays(-1);
            dateTimePicker1.MaxDate = DateTime.Today;
            dateTimePicker2.MaxDate = DateTime.Today;

            metroDateTime1.Value = DateTime.Today.AddDays(-1);
            metroDateTime1.MaxDate = DateTime.Today;
            metroDateTime2.Value = DateTime.Today.AddDays(-1);
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
                    //DoldurDataGridView(veriler);
                    DonutGrafik(veriler);
                }
                if (karsilastir.Checked == false)
                {
                    DateTime selectedDate = dateTimePicker1.Value;
                    List<string> veriler = GetVeriler(startDate, startDate);
                    DoldurTablo(veriler);
                    //DoldurDataGridView(veriler);
                    DonutGrafik(veriler);
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
                //DoldurDataGridView(veriler);
                DonutGrafik(veriler);
            };
            UpdateComparisonLabels();
            DisplayYearlySalesComparisonAndTotal();
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

            //chart1.is
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
                siyahtoplamlabel.Text = siyahtoplamlabel2.ToString("N0") + " LT";


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
                //DoldurDataGridView(veriler);
                DonutGrafik(veriler);
            }
            if (karsilastir.Checked == false)
            {
                DateTime selectedDate = dateTimePicker1.Value;

                List<string> veriler = GetVeriler(selectedDate, selectedDate);
                DoldurTablo(veriler);
                //DoldurDataGridView(veriler);
                DonutGrafik(veriler);
            }

        }
        private void DonutGrafik(List<string> veriler)
        {
            // Tasarım ekranında yapılan ayarları kaybetmemek için yeni bir Series oluşturun
            Series series = new Series("İl Değerleri");
            chart2.Series.Clear(); // Var olan Series'leri temizleyin
            chart2.Series.Add(series); // Yeni Series'i ekleyin

            // Seri ayarlarını tasarım ekranında yaptıklarınıza göre ayarlayın
            series.ChartType = SeriesChartType.Bar;
            series.Color = Color.FromArgb(0, 102, 204);
            series.LabelForeColor = Color.Black;
            series.LabelBackColor = Color.White;
            series.LabelBorderColor = Color.Black;
            series.LabelBorderWidth = 4;
            series.Font = new Font("Microsoft Sans Serif", 10.75f, FontStyle.Bold);

            // İl isimleri
            string[] iller = { "Mersin", "İzmir", "İzmit", "Kırıkkale", "Batman", "Tekirdağ", "Giresun", "Antalya", "Trabzon", "Diyarbakır", "Hatay", "Samsun" };

            // Verilerin eklenmesi
            for (int i = 0; i < 12; i++)
            {
                double ilDeger = double.Parse(veriler[i + 5]);

                // Değeri 0 olan verileri gösterme
                if (ilDeger != 0)
                {
                    DataPoint dataPoint = new DataPoint();
                    dataPoint.YValues = new double[] { ilDeger };
                    dataPoint.AxisLabel = iller[i]; // İl isimlerini etiket olarak ayarla
                    dataPoint.Label = $"{iller[i]}: {ilDeger:N0}"; // Etiket ve değeri göster

                    series.Points.Add(dataPoint);

                }
            }

            // Eksen adlarını ayarla
            chart2.ChartAreas[0].AxisX.Title = "Değerler";
            chart2.ChartAreas[0].AxisY.Title = "İller";

            // Yazı boyutunu ve kalınlığını artır
            chart2.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel);
            chart2.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel);

            // Eksen etiket renklerini ayarla
            chart2.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            chart2.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;

            // Grafiği güncelle
            chart2.Invalidate();
        }
        private void karsilastir_CheckedChanged(object sender, EventArgs e)
        {
            if (karsilastir.Checked == true)
            {
                DateTime selectedDate = dateTimePicker1.Value;
                DateTime selectedDate2 = dateTimePicker2.Value;
                List<string> veriler = GetVeriler(selectedDate, selectedDate2);
                DoldurTablo(veriler);
                //DoldurDataGridView(veriler);
                DonutGrafik(veriler);
            }
            if (karsilastir.Checked == false)
            {
                DateTime selectedDate = dateTimePicker1.Value;
                List<string> veriler = GetVeriler(selectedDate, selectedDate);
                DoldurTablo(veriler);
                //DoldurDataGridView(veriler);
                DonutGrafik(veriler);
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
            else if (bitti == true)
            {
                anlikvericek.Enabled = true;
                anlıkvericekprogressspin.Visible = false;
                ;
            }
        }



        private void karsilastircheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (karsilastir2yuzde.Checked == true)
            {
                karsilastirdatetimegroup.Visible = Enabled;
                KarşılaştırVeriler();
            }
            else if (karsilastir2yuzde.Checked == false)
            {
                aralikhesapla2.Checked = false;
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
            Label[] labels = { motorinlabel, motorinlabel2, motorindigerlabel, motorindigerlabel2, benzinlabel, benzinlabel2, toplamlabel, toplamlabel2, siyahtoplamlabel, siyahtoplamlabel2, lpgperakende, lpgperakende2, lpgdokme, lpgdokme2 };

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
                        veriler2.Add(reader["ToplamKara"].ToString());
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
                decimal siyahtoplam = Convert.ToDecimal(veriler2[18]);
                motorinlabel2.Text = motorinLT.ToString("N0") + " LT";
                motorindigerlabel2.Text = motorinDigerLT.ToString("N0") + " LT";
                benzinlabel2.Text = benzinLT.ToString("N0") + " LT";
                siyahtoplamlabel2.Text = siyahtoplam.ToString("N0") + " LT";

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

        private void gunluksatisraporekrani_Shown(object sender, EventArgs e)
        {
            metroDateTime1_ValueChanged(sender, e);

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            // Sayfayı yatay moda ayarla
            pd.DefaultPageSettings.Landscape = true;

            pd.PrintPage += (sndr, args) =>
            {
                // Formun ekran görüntüsünü al
                Bitmap bmp = new Bitmap(this.Width, this.Height);
                this.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

                // Görüntüyü sayfa boyutlarına uydurmak için ölçeklendirme faktörlerini hesapla
                float scale = Math.Min((float)args.PageBounds.Width / bmp.Width, (float)args.PageBounds.Height / bmp.Height);

                // Ölçeklenmiş görüntü boyutlarını hesapla
                int scaledWidth = (int)(bmp.Width * scale);
                int scaledHeight = (int)(bmp.Height * scale);

                // Görüntüyü sayfanın merkezine yerleştir
                int centerX = (args.PageBounds.Width - scaledWidth) / 2;
                int centerY = (args.PageBounds.Height - scaledHeight) / 2;

                // Ölçeklendirilmiş ve merkezlenmiş görüntüyü çiz
                args.Graphics.DrawImage(bmp, centerX, centerY, scaledWidth, scaledHeight);
            };

            // Yazdırma iletişim kutusunu göster
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pd;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print(); // Kullanıcı onay verirse yazdır
            }
        }
        private List<decimal> GetComparativeData(DateTime startDate, DateTime endDate)
        {
            List<decimal> data = new List<decimal>();
            string query = @"
        SELECT 
            SUM(Motorin) AS Motorin, 
            SUM(MotorinDiger) AS MotorinDiger, 
            SUM(Benzin) AS Benzin, 
            SUM(Lpg) AS Lpg, 
            SUM(LpgDokme) AS LpgDokme,
            SUM(ToplamKara) AS ToplamKara
        FROM 
            gunluk_veri 
        WHERE 
            Zaman >= @StartDate AND 
            Zaman <= @EndDate";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Sütunlar için değerleri kontrol et ve ekle
                            data.Add(reader.IsDBNull(reader.GetOrdinal("Motorin")) ? 0 : reader.GetInt32(reader.GetOrdinal("Motorin")));
                            data.Add(reader.IsDBNull(reader.GetOrdinal("MotorinDiger")) ? 0 : reader.GetInt32(reader.GetOrdinal("MotorinDiger")));
                            data.Add(reader.IsDBNull(reader.GetOrdinal("Benzin")) ? 0 : reader.GetInt32(reader.GetOrdinal("Benzin")));
                            data.Add(reader.IsDBNull(reader.GetOrdinal("Lpg")) ? 0 : reader.GetInt32(reader.GetOrdinal("Lpg")));
                            data.Add(reader.IsDBNull(reader.GetOrdinal("LpgDokme")) ? 0 : reader.GetInt32(reader.GetOrdinal("LpgDokme")));
                            data.Add(reader.IsDBNull(reader.GetOrdinal("ToplamKara")) ? 0 : reader.GetInt32(reader.GetOrdinal("ToplamKara")));
                        }
                    }
                }
            }

            return data;
        }

        private void UpdateComparisonLabels()
        {
            // Karşılaştırmak için tarih aralıkları
            DateTime today = DateTime.Today.AddDays(-1);
            DateTime lastWeek = today.AddDays(-7);
            DateTime lastMonth = today.AddMonths(-1);
            DateTime last2Weeks = today.AddDays(-14);
            DateTime last3Weeks = today.AddDays(-21);

            string lastweeklabel = lastWeek.ToShortDateString() +" VE "+ today.ToShortDateString() + " Tarihleri Arasındaki Veriler";
            gecenhaftalabel.Text = lastweeklabel;

            string last2weeklabel = last2Weeks.ToShortDateString() + " VE " + today.ToShortDateString() + " Tarihleri Arasındaki Veriler";
            gecen2haftalabel.Text = last2weeklabel;

            string last3weeklabel = last3Weeks.ToShortDateString() + " VE " + today.ToShortDateString() + " Tarihleri Arasındaki Veriler";
            gecen3haftalabel.Text = last3weeklabel;

            string lastmonthlabel = lastMonth.ToShortDateString() + " VE " + today.ToShortDateString() + " Tarihleri Arasındaki Veriler";
            gecenaylabel.Text = lastmonthlabel;
            // Verileri çek
            List<decimal> lastWeekData = GetComparativeData(lastWeek, today);
            List<decimal> lastMonthData = GetComparativeData(lastMonth, today);
            List<decimal> last2WeeksData = GetComparativeData(last2Weeks, today);
            List<decimal> last3WeeksData = GetComparativeData(last3Weeks, today);

            // Etiketleri güncelle
            // Etiketleri güncelle
            // Son 1 Hafta
            labelMotorinLastWeek.Text = $"{lastWeekData[0].ToString("N0")} LT";
            labelMotorinDigerLastWeek.Text = $"{lastWeekData[1].ToString("N0")} LT";
            labelBenzinLastWeek.Text = $"{lastWeekData[2].ToString("N0")} LT";
            labelLpgLastWeek.Text = $"{lastWeekData[3].ToString("N0")} KG";
            labelLpgDokmeLastWeek.Text = $"{lastWeekData[4].ToString("N0")} KG";
            labelToplamKaraLastWeek.Text = $"{lastWeekData[5].ToString("N0")}";
            labelBeyazUrunToplamLastWeek.Text = $"{(lastWeekData[0] + lastWeekData[1] + lastWeekData[2]).ToString("N0")} LT";

            // Son 1 Ay
            labelMotorinLastMonth.Text = $"{lastMonthData[0].ToString("N0")} LT";
            labelMotorinDigerLastMonth.Text = $"{lastMonthData[1].ToString("N0")} LT";
            labelBenzinLastMonth.Text = $"{lastMonthData[2].ToString("N0")} LT";
            labelLpgLastMonth.Text = $"{lastMonthData[3].ToString("N0")} KG";
            labelLpgDokmeLastMonth.Text = $"{lastMonthData[4].ToString("N0")} KG";
            labelToplamKaraLastMonth.Text = $"{lastMonthData[5].ToString("N0")}";
            labelBeyazUrunToplamLastMonth.Text = $"{(lastMonthData[0] + lastMonthData[1] + lastMonthData[2]).ToString("N0")} LT";

            // Son 2 Hafta
            labelMotorinLast2Weeks.Text = $"{last2WeeksData[0].ToString("N0")} LT";
            labelMotorinDigerLast2Weeks.Text = $"{last2WeeksData[1].ToString("N0")} LT";
            labelBenzinLast2Weeks.Text = $"{last2WeeksData[2].ToString("N0")} LT";
            labelLpgLast2Weeks.Text = $"{last2WeeksData[3].ToString("N0")} KG";
            labelLpgDokmeLast2Weeks.Text = $"{last2WeeksData[4].ToString("N0")} KG";
            labelToplamKaraLast2Weeks.Text = $"{last2WeeksData[5].ToString("N0")}";
            labelBeyazUrunToplamLast2Weeks.Text = $"{(last2WeeksData[0] + last2WeeksData[1] + last2WeeksData[2]).ToString("N0")} LT";

            // Son 3 Hafta
            labelMotorinLast3Weeks.Text = $"{last3WeeksData[0].ToString("N0")} LT";
            labelMotorinDigerLast3Weeks.Text = $"{last3WeeksData[1].ToString("N0")} LT";
            labelBenzinLast3Weeks.Text = $"{last3WeeksData[2].ToString("N0")} LT";
            labelLpgLast3Weeks.Text = $"{last3WeeksData[3].ToString("N0")} KG";
            labelLpgDokmeLast3Weeks.Text = $"{last3WeeksData[4].ToString("N0")} KG";
            labelToplamKaraLast3Weeks.Text = $"{last3WeeksData[5].ToString("N0")}";
            labelBeyazUrunToplamLast3Weeks.Text = $"{(last3WeeksData[0] + last3WeeksData[1] + last3WeeksData[2]).ToString("N0")} LT";

        }
        private decimal GetProductSalesData(DateTime date, string productColumn)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = $"SELECT SUM({productColumn}) FROM gunluk_veri WHERE Zaman = @Date";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Date", date);
                    var result = command.ExecuteScalar();
                    return (result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
                }
            }
        }

        private void DisplayYearlySalesComparisonAndTotal()
        {
            // Dünkü ve geçen yılın dünkü tarihlerini al
            var yesterday = DateTime.Today.AddDays(-1);
            var lastYearYesterday = yesterday.AddYears(-1);

            string yesterdaylabel = yesterday.ToShortDateString() + " Tarihinin Satış Verileri";
            yesterdaylabel2.Text = yesterdaylabel;

            string lastyearyesterdaylabel = lastYearYesterday.ToShortDateString() + " Tarihinin Satış Verileri";
            lastyearyesterday2.Text = lastyearyesterdaylabel;

            // Ürün kategorileri
            string[] products = new string[] { "Motorin", "MotorinDiger", "Benzin", "ToplamKara", "Lpg", "LpgDokme" };

            decimal totalBeyazUrunLastYear = 0;
            decimal totalBeyazUrunYesterday = 0;

            foreach (var product in products)
            {
                // Geçen yıl ve dün için satış verilerini çek
                var lastYearSales = GetProductSalesData(lastYearYesterday, product);
                var yesterdaySales = GetProductSalesData(yesterday, product);

                // Beyaz Ürün toplamlarını hesapla
                if (product == "Motorin" || product == "MotorinDiger" || product == "Benzin")
                {
                    totalBeyazUrunLastYear += lastYearSales;
                    totalBeyazUrunYesterday += yesterdaySales;
                }

                // Yüzde değişimi hesapla
                var changePercent = lastYearSales != 0 ? ((yesterdaySales - lastYearSales) / lastYearSales) * 100 : 0;

                // Yüzde değişimi ilgili etikette göster
                var labelChangeName = "label" + product + "Change";
                var labelChange = this.Controls.Find(labelChangeName, true).FirstOrDefault() as Label;
                if (labelChange != null)
                {
                    labelChange.Text = $"{changePercent:N2}%";
                }

                // Dünkü satış miktarını gösteren etiketin adını oluştur
                var labelYesterdayName = "label" + product + "Yesterday";
                var labelYesterday = this.Controls.Find(labelYesterdayName, true).FirstOrDefault() as Label;

                // Eğer etiket bulunursa, dünkü satış miktarını etikete yaz
                if (labelYesterday != null)
                {
                    labelYesterday.Text = $"{yesterdaySales:N0}"; // Burada "N0" formatı kullanarak virgülsüz sayı gösterimi sağladık
                }

                // Geçen yıl ve dün satış miktarlarını ilgili etikette göster
                var labelLastYearName = "label" + product + "LastYear";
                var labelLastYear = this.Controls.Find(labelLastYearName, true).FirstOrDefault() as Label;
                if (labelLastYear != null)
                {
                    labelLastYear.Text = $"{lastYearSales:N0}";
                }
            }

            // Beyaz Ürün yüzde değişimi ve satış miktarlarını etiketlere yaz
            var beyazUrunChangePercent = totalBeyazUrunLastYear != 0 ? ((totalBeyazUrunYesterday - totalBeyazUrunLastYear) / totalBeyazUrunLastYear) * 100 : 0;
            labelBeyazUrunChange.Text = $"{beyazUrunChangePercent:N2}%";
            labelBeyazUrunLastYear.Text = $"{totalBeyazUrunLastYear:N0}";
            labelBeyazUrunYesterday.Text = $"{totalBeyazUrunYesterday:N0}";
        }

    }

}
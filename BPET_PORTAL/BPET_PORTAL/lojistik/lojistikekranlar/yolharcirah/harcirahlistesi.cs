using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPET_PORTAL.lojistik.lojistikekranlar.yolharcirah
{
    public partial class harcirahlistesi : Form
    {
        private const string connectionString = "Server=95.0.50.22,1382;Database=lojistik;User ID=sa;Password=Mustafa1;";
        private DataTable originalDataTable;

        public harcirahlistesi()
        {
            InitializeComponent();
            InitializeDateTimePickers();
            LoadData();
        }

        private void InitializeDateTimePickers()
        {
            DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime lastDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), 23, 59, 59);
            dateTimePickerStart.Value = firstDayOfMonth;
            dateTimePickerEnd.Value = lastDayOfMonth;
        }

        private void btnYeniArac_Click(object sender, EventArgs e)
        {
            yeniharcirah YeniHarcirah = new yeniharcirah(this,0);
            YeniHarcirah.ShowDialog();
        }

        public void LoadData()
        {
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;

            string queryString = $"SELECT ID ,Plaka, SoforAdi, Tarih, SehirAdi, HesapKodu, OzetKod2, Tutar, DisYukleme, DisYuklemeTutar " +
                                $"FROM YolHarcırahListesi " +
                                $"WHERE Tarih BETWEEN '{startDate.ToString("yyyy-MM-dd HH:mm:ss")}' AND '{endDate.ToString("yyyy-MM-dd HH:mm:ss")}'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                originalDataTable = new DataTable();
                adapter.Fill(originalDataTable);
                dataGridView1.DataSource = originalDataTable;
            }

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                dataGridView1.AutoResizeColumn(column.Index, DataGridViewAutoSizeColumnMode.AllCells);
            }

            CalculateDriverTotals();

            DataTable driverBalancesTable = GetDriverBalancesTable();
            driverTotalsDataGridView.DataSource = driverBalancesTable;

            labelDateRange.Text = $"{startDate.ToString("MMMM yyyy")}";
        }
        private DataTable GetDriverBalancesTable()
        {
            // Şoför bazlı toplam tutarları almak için originalDataTable'daki verileri kullan
            var driverTotals = from row in originalDataTable.AsEnumerable()
                               group row by new { SoforAdi = row.Field<string>("SoforAdi") } into g
                               select new
                               {
                                   SoforAdi = g.Key.SoforAdi,
                                   ToplamTutar = g.Sum(r => Convert.ToDecimal(r.Field<decimal>("Tutar"))),
                                   OdenenTutar = 3000, // Örnek olarak 300 TL
                               };

            // DataTable oluştur
            DataTable balancesTable = new DataTable();
            balancesTable.Columns.Add("SoforAdi", typeof(string));
            balancesTable.Columns.Add("ToplamTutar", typeof(decimal));
            balancesTable.Columns.Add("OdenenTutar", typeof(decimal));
            balancesTable.Columns.Add("KalanBakiye", typeof(decimal));

            // Toplu kalan bakiyeleri doldur
            foreach (var driverTotal in driverTotals)
            {
                DataRow newRow = balancesTable.NewRow();
                newRow["SoforAdi"] = driverTotal.SoforAdi;
                newRow["ToplamTutar"] = driverTotal.ToplamTutar;
                newRow["OdenenTutar"] = driverTotal.OdenenTutar;
                newRow["KalanBakiye"] = driverTotal.ToplamTutar - driverTotal.OdenenTutar;
                balancesTable.Rows.Add(newRow);
            }

            return balancesTable;
        }

        private void CalculateDriverTotals()
        {
            var driverTotals = from row in originalDataTable.AsEnumerable()
                               group row by new { SoforAdi = row.Field<string>("SoforAdi") } into g
                               select new
                               {
                                   SoforAdi = g.Key.SoforAdi,
                                   ToplamTutar = g.Sum(r => Convert.ToDecimal(r.Field<decimal>("Tutar"))),
                                   OdenenTutar = 3000,
                                   KalanBakiye = g.Sum(r => Convert.ToDecimal(r.Field<decimal>("Tutar"))) - 3000
                               };

            DataTable driverBalancesTable = new DataTable();
            driverBalancesTable.Columns.Add("SoforAdi", typeof(string));
            driverBalancesTable.Columns.Add("ToplamTutar", typeof(decimal));
            driverBalancesTable.Columns.Add("OdenenTutar", typeof(decimal));
            driverBalancesTable.Columns.Add("KalanBakiye", typeof(decimal));

            foreach (var driverTotal in driverTotals)
            {
                DataRow newRow = driverBalancesTable.NewRow();
                newRow["SoforAdi"] = driverTotal.SoforAdi;
                newRow["ToplamTutar"] = driverTotal.ToplamTutar;
                newRow["OdenenTutar"] = driverTotal.OdenenTutar;
                newRow["KalanBakiye"] = driverTotal.KalanBakiye;
                driverBalancesTable.Rows.Add(newRow);
            }

            driverTotalsDataGridView.DataSource = driverBalancesTable;
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void btnOdemeEmri_Click(object sender, EventArgs e)
        {
            // Onay kutusunu göster
            DialogResult result = MessageBox.Show("Bu işlem sadece ay sonunda tüm veriler girildikten sonra yapılması gerekmektedir! Devam etmek istiyor musunuz?",
                                                  "Onay",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);

            // Kullanıcı 'Evet' seçeneğini tıklarsa, işlemi yap
            if (result == DialogResult.Yes)
            {
                btnOdemeEmri.Text = "LÜTFEN BEKLEYİNİZ!";
                btnOdemeEmri.Enabled = false;
                try
                {
                    if (driverTotalsDataGridView.Rows.Count <= 0)
                    {
                        MessageBox.Show("GEÇERLİ VERİ YOK!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnOdemeEmri.Text = "Finans'a Aylık Ödeme Emri Gönder!";
                        btnOdemeEmri.Enabled = true;
                        return;
                        }
                    // Seçilen tarih aralığı
                    DateTime startDate = dateTimePickerStart.Value;
                    DateTime endDate = dateTimePickerEnd.Value;

                    // Şoför bazlı toplam tutarları almak için originalDataTable'daki verileri kullan
                    var driverTotals = from row in originalDataTable.AsEnumerable()
                                       group row by new { SoforAdi = row.Field<string>("SoforAdi") } into g
                                       select new
                                       {
                                           SoforAdi = g.Key.SoforAdi,
                                           ToplamTutar = g.Sum(r => Convert.ToDecimal(r.Field<decimal>("Tutar"))),
                                           OdenenTutar = 3000, // Örnek olarak 300 TL
                                       };

                    // Önce var olan verileri sil
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string deleteQuery = $"DELETE FROM OdemeEmriTablosu WHERE Ay = @Ay AND Yil = @Yil";

                        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                        {
                            deleteCommand.Parameters.AddWithValue("@Ay", startDate.Month);
                            deleteCommand.Parameters.AddWithValue("@Yil", startDate.Year);

                            deleteCommand.ExecuteNonQuery();
                        }

                        // Tablo başlığı oluştur
                        StringBuilder mailBody = new StringBuilder();
                        mailBody.AppendLine("<html><body><h2 style='text-align:center;'>Ödeme Emri Bilgisi</h2>");

                        // Tabloyu oluştur
                        mailBody.AppendLine("<table border='1' style='margin:auto;'><tr><th style='background-color:#4CAF50;color:white;'>Soför Adı</th><th style='background-color:#4CAF50;color:white;'>Ay</th><th style='background-color:#4CAF50;color:white;'>Yıl</th><th style='background-color:#4CAF50;color:white;'>Toplam Tutar</th><th style='background-color:#4CAF50;color:white;'>Odenen Tutar</th><th style='background-color:#4CAF50;color:white;'>Kalan Bakiye</th></tr>");

                        foreach (var driverTotal in driverTotals)
                        {
                            // Kalan bakiye hesapla
                            decimal kalanBakiye = driverTotal.ToplamTutar - driverTotal.OdenenTutar;

                            // SQL komutu ile veriyi ekle
                            string insertQuery = "INSERT INTO OdemeEmriTablosu (SoforAdi, Ay, Yil, ToplamTutar, OdenenTutar, KalanBakiye, Cevaplandi, Odenen) " +
                                                 "VALUES (@SoforAdi, @Ay, @Yil, @ToplamTutar, @OdenenTutar, @KalanBakiye, @Cevaplandi, @Odenen)";

                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@SoforAdi", driverTotal.SoforAdi);
                                insertCommand.Parameters.AddWithValue("@Ay", startDate.Month);
                                insertCommand.Parameters.AddWithValue("@Yil", startDate.Year);
                                insertCommand.Parameters.AddWithValue("@ToplamTutar", driverTotal.ToplamTutar);
                                insertCommand.Parameters.AddWithValue("@OdenenTutar", driverTotal.OdenenTutar);
                                insertCommand.Parameters.AddWithValue("@KalanBakiye", kalanBakiye);
                                insertCommand.Parameters.AddWithValue("@Cevaplandi", "Hayir");
                                insertCommand.Parameters.AddWithValue("@Odenen", "Hayir");

                                insertCommand.ExecuteNonQuery();
                            }

                            // Tabloya satır ekle
                            mailBody.AppendLine($"<tr><td>{driverTotal.SoforAdi}</td><td>{startDate.Month}</td><td>{startDate.Year}</td><td>{driverTotal.ToplamTutar}</td><td>{driverTotal.OdenenTutar}</td><td>{kalanBakiye}</td></tr>");
                        }

                        // Tablo kapat
                        mailBody.AppendLine("</table>");

                        // Açıklama ekle
                        mailBody.AppendLine("<p style='text-align:center;'><i>Lojistik tarafından bildirilen aylık ödeme emridir. BPET PORTAL uygulaması tarafından otomatik olarak gönderilmiştir. Herhangi bir sorunuz için lütfen Mersin Bilgi İşleme ulaşınız.</i></p>");

                        // Mail gönderimi için tabloyu oluştur
                        mailBody.AppendLine("</body></html>");

                        // Mail gönderimi
                        await SendEmail(mailBody.ToString());
                    }

                    MessageBox.Show("Ödeme Emri gönderildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnOdemeEmri.Text = "Finans'a Aylık Ödeme Emri Gönder!";
                    btnOdemeEmri.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnOdemeEmri.Text = "Finans'a Aylık Ödeme Emri Gönder!";
                    btnOdemeEmri.Enabled = true;
                }
            }
            // Kullanıcı 'Hayır' seçeneğini tıklarsa, işlemi yapma
            else
            {

            }           
        }

        private async Task SendEmail(string body)
        {
            string smtpServer = "smtp.office365.com";
            int smtpPort = 587;
            string senderEmail = "info@bpet.com.tr";
            string senderPassword = "IbBc*2014";
            string recipientEmail = "mustafa.ceylan@bpet.com.tr"; // Alıcı e-posta adresi
            //string ccEmail = "mustafa.ceylan@bpet.com.tr"; // CC olarak eklemek istediğiniz e-posta adresi

            using (MailMessage mail = new MailMessage())
            {
                mail.Headers.Add("X-Mailer", "BPET Portal"); // Gönderen uygulama bilgisi
                mail.Headers.Add("X-Priority", "1"); // Öncelik seviyesi (1 en yüksek)
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(recipientEmail);
                //mail.CC.Add(ccEmail);
                mail.Subject = "Lojistik Yol Harcırahı Ödeme Emri Bilgisi";
                mail.Body = body;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient(smtpServer, smtpPort))
                {
                    smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }

        private void yENİEKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yeniharcirah YeniHarcirah = new yeniharcirah(this, 0);
            YeniHarcirah.ShowDialog();
        }

        private void dÜZENLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçili satırın ID'sini al
                int selectedRowID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                yeniharcirah YeniHarcirah = new yeniharcirah(this, selectedRowID);
                YeniHarcirah.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lütfen güncellenecek bir satır seçin.");
            }
            
        }

        private void sİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Kullanıcıya onay mesajı göster
                DialogResult result = MessageBox.Show("Seçili satırı silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Evet'i seçtiyse silme işlemini gerçekleştir
                    int selectedRowID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
                    DeleteRowFromDatabase(selectedRowID);
                }
            }
            else
            {
                MessageBox.Show("Lütfen silinecek bir satır seçin.");
            }
        }
        private void DeleteRowFromDatabase(int rowID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Silme işlemi için SQL komutu
                    string deleteQuery = "DELETE FROM YolHarcırahListesi WHERE ID = @RowID";

                    using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@RowID", rowID);

                        // SQL komutunu çalıştır
                        int affectedRows = deleteCommand.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            // Veri başarıyla silindiğinde kullanıcıya bilgi ver
                            MessageBox.Show("Seçili satır başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Veriyi tekrar yükle
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Seçili satır silinemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetle_Click(object sender, EventArgs e)
        {
            InitializeDateTimePickers();
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            sİLToolStripMenuItem_Click(sender,e);
        }
    }
}

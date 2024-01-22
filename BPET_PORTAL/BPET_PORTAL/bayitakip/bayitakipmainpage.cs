using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace BPET_PORTAL.bayitakip
{
    public partial class bayitakipmainpage : Form
    {
        private List<string> selectedRowsList = new List<string>();

        public bayitakipmainpage(string eposta)
        {
            InitializeComponent();
            epostalabel.Text = eposta;
            FillBolgeMuduruComboBox();
        }
        private string GetBolumMail(string bolgeKodu)
        {
            switch (bolgeKodu)
            {
                default:
                    return "mustafa.ceylan@bpet.com.tr";
            }
        }

        private void FillBolgeMuduruComboBox()
        {
            string connectionString = "Server=95.0.50.22,1382;Database=BPET_PORTAL;User ID=sa;Password=Mustafa1;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT DISTINCT BolgeAdi FROM CariHesaplar";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string bolgeMuduru = reader["BolgeAdi"].ToString();
                            bolgeMuduruComboBox.Items.Add(bolgeMuduru);
                        }
                    }
                }
            }
        }
        private void bolgeMuduruComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bolgeMuduruComboBox.SelectedItem != null)
            {
                int minimumSonSatisGunSayisi = (int)numericUpDown.Value;
                int minimumSonTahsilatGunSayisi = (int)numericUpDown1.Value;
                string selectedBolgeMuduru = bolgeMuduruComboBox.SelectedItem != null ? bolgeMuduruComboBox.SelectedItem.ToString() : null;
                LoadDataFromDatabase(minimumSonSatisGunSayisi, minimumSonTahsilatGunSayisi, selectedBolgeMuduru);
            }
        }
        private void araButton_Click(object sender, EventArgs e)
        {
            int minimumSonSatisGunSayisi = (int)numericUpDown.Value;
            int minimumSonTahsilatGunSayisi = (int)numericUpDown1.Value;
            string selectedBolgeMuduru = bolgeMuduruComboBox.SelectedItem != null ? bolgeMuduruComboBox.SelectedItem.ToString() : null;

            // Filtrelerle veritabanından veri çek
            LoadDataFromDatabase(minimumSonSatisGunSayisi, minimumSonTahsilatGunSayisi, selectedBolgeMuduru);
        }
        private void LoadDataFromDatabase(int minimumSonSatisGunSayisi, int minimumSonTahsilatGunSayisi, string selectedBolgeMuduru)
        {
            string connectionString = "Server=95.0.50.22,1382;Database=BPET_PORTAL;User ID=sa;Password=Mustafa1;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT id, CariHesapKodu, CariHesapUnvani, Sehir, BolgeKodu, BolgeAdi, BolgeMuduru, SonSatisTarihi, SonSatisMiktari, SonTahsilatTarihi, SonSatisGunSayisi, SonTahsilatGunSayisi, MailGonderildi, Cevaplandi FROM CariHesaplar WHERE (SonSatisGunSayisi >= @MinimumSonSatisGunSayisi AND SonTahsilatGunSayisi >= @MinimumSonTahsilatGunSayisi)";

                if (!string.IsNullOrEmpty(selectedBolgeMuduru))
                {
                    query += " AND BolgeAdi = @SelectedBolgeMuduru";
                }

                if (mailgonderildi.Checked == true)
                {
                    query += " AND MailGonderildi = 1";
                }

                if (cevaplandi.Checked == true)
                {
                    query += " AND Cevaplandi = 1";
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MinimumSonSatisGunSayisi", minimumSonSatisGunSayisi);
                    command.Parameters.AddWithValue("@MinimumSonTahsilatGunSayisi", minimumSonTahsilatGunSayisi);

                    if (!string.IsNullOrEmpty(selectedBolgeMuduru))
                    {
                        command.Parameters.AddWithValue("@SelectedBolgeMuduru", selectedBolgeMuduru);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView.DataSource = dataTable;
                    }
                    lblverisayisi.Text = "VERİ SAYISI: " + dataGridView.RowCount.ToString();

                }
            }
        }
        private void resetFiltersButton_Click(object sender, EventArgs e)
        {
            selectedRowsList.Clear();
            listBox1.Items.Clear();

            // NumericUpdown'ları sıfırla
            numericUpDown.Value = numericUpDown.Minimum;
            numericUpDown1.Value = numericUpDown1.Minimum;
            cevaplandi.Checked = false;
            mailgonderildi.Checked = false;

            // ComboBox'ı sıfırla
            bolgeMuduruComboBox.SelectedIndex = -1; // veya ComboBox'ın başlangıç seçeneğine göre ayarlayın

            int minimumSonSatisGunSayisi = (int)numericUpDown.Value;
            int minimumSonTahsilatGunSayisi = (int)numericUpDown1.Value;
            string selectedBolgeMuduru = bolgeMuduruComboBox.SelectedItem != null ? bolgeMuduruComboBox.SelectedItem.ToString() : null;

            // Filtrelerle veritabanından veri çek
            LoadDataFromDatabase(minimumSonSatisGunSayisi, minimumSonTahsilatGunSayisi, selectedBolgeMuduru);
        }
        private void ImportDataFromExcel(string excelFilePath)
        {
            string connectionString = "Server=95.0.50.22,1382;Database=BPET_PORTAL;User ID=sa;Password=Mustafa1;";

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(excelFilePath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            int rowCount = xlRange.Rows.Count;
            progressBar.Maximum = rowCount;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                for (int i = 2; i <= rowCount; i++)
                {
                    string cariHesapKodu = xlRange.Cells[i, 1].Text;
                    string cariHesapUnvani = xlRange.Cells[i, 2].Text;
                    string sehir = xlRange.Cells[i, 3].Text;
                    string bolgeKodu = xlRange.Cells[i, 4].Text;
                    string bolgeAdi = xlRange.Cells[i, 5].Text;
                    string bolgeMuduru = xlRange.Cells[i, 6].Text;
                    string sahaKodu = xlRange.Cells[i, 7].Text;
                    string sahaAdi = xlRange.Cells[i, 8].Text;
                    string sahaMuduru = xlRange.Cells[i, 9].Text;
                    progressBar.Value = i;
                    Application.DoEvents();

                    DateTime sonSatisTarihi;
                    decimal sonSatisMiktari;

                    if (DateTime.TryParseExact(xlRange.Cells[i, 10].Text, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out sonSatisTarihi))
                    {
                        // Başarıyla tarih çözümlendi
                    }
                    else
                    {
                        // Hatalı tarih formatı, gün sayısının başına 0 ekleyip tekrar deneyin
                        if (DateTime.TryParseExact("0" + xlRange.Cells[i, 10].Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out sonSatisTarihi))
                        {
                            // Başarıyla tarih çözümlendi, tarih değişkeni artık doğru değeri içeriyor
                        }
                        else
                        {
                            // İkinci denemede de başarısız olursa hata alın
                            this.Alert("TARİH HATA: " + sonSatisTarihi + " ft: " + cariHesapKodu, Form_Alert.enmType.Info);
                            continue;
                        }
                    }

                    if (decimal.TryParse(xlRange.Cells[i, 11].Text, out sonSatisMiktari))
                    {
                        // Başarıyla sayısal değer çözümlendi
                    }
                    else
                    {
                        this.Alert("satismiktari HATA: " + cariHesapKodu + " ft:", Form_Alert.enmType.Info);
                        continue; // Hata olduğunda bu veriyi atlayın
                    }

                    DateTime sonTahsilatTarihi;
                    int sonSatisGunSayisi;
                    int sonTahsilatGunSayisi;

                    if (DateTime.TryParseExact(xlRange.Cells[i, 12].Text, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out sonTahsilatTarihi))
                    {
                        // Başarıyla tarih çözümlendi
                    }
                    else
                    {
                        // Hatalı tarih formatı, gün sayısının başına 0 ekleyip tekrar deneyin
                        if (DateTime.TryParseExact("0" + xlRange.Cells[i, 12].Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out sonTahsilatTarihi))
                        {
                            // Başarıyla tarih çözümlendi, tarih değişkeni artık doğru değeri içeriyor
                        }
                        else
                        {
                            // İkinci denemede de başarısız olursa hata alın
                            this.Alert("TARİH2 HATA: " + sonTahsilatTarihi, Form_Alert.enmType.Info);
                            continue;
                        }
                    }

                    if (int.TryParse(xlRange.Cells[i, 13].Text, out sonSatisGunSayisi))
                    {
                        // Başarıyla sayısal değer çözümlendi
                    }
                    else
                    {
                        // Hatalı sayısal değer, bu durumu işleyebilir veya rapor edebilirsiniz.
                        this.Alert("TARİH3 HATA: " + sonSatisGunSayisi, Form_Alert.enmType.Error);
                        continue; // Hata olduğunda bu veriyi atlayın
                    }

                    if (int.TryParse(xlRange.Cells[i, 14].Text, out sonTahsilatGunSayisi))
                    {
                        // Başarıyla sayısal değer çözümlendi
                    }
                    else
                    {
                        // Hatalı sayısal değer, bu durumu işleyebilir veya rapor edebilirsiniz.
                        this.Alert("TARİH4 HATA: " + sonTahsilatGunSayisi, Form_Alert.enmType.Error);
                        continue; // Hata olduğunda bu veriyi atlayın
                    }

                    string checkQuery = "SELECT COUNT(*) FROM CariHesaplar WHERE CariHesapUnvani = @CariHesapUnvani AND CariHesapKodu = @CariHesapKodu";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@CariHesapUnvani", cariHesapUnvani);
                        checkCommand.Parameters.AddWithValue("@CariHesapKodu", cariHesapKodu);
                        int existingRecords = (int)checkCommand.ExecuteScalar();

                        if (existingRecords > 0)
                        {
                            string updateQuery = "UPDATE CariHesaplar " +
                                                "SET Sehir = @Sehir, BolgeKodu = @BolgeKodu, BolgeAdi = @BolgeAdi, " +
                                                "BolgeMuduru = @BolgeMuduru, SahaKodu = @SahaKodu, SahaAdi = @SahaAdi, " +
                                                "SahaMuduru = @SahaMuduru, SonSatisTarihi = @SonSatisTarihi, " +
                                                "SonSatisMiktari = @SonSatisMiktari, SonTahsilatTarihi = @SonTahsilatTarihi, " +
                                                "SonSatisGunSayisi = @SonSatisGunSayisi, MailGonderildi = '0', " +
                                                "Cevaplandi = '0', SonTahsilatGunSayisi = @SonTahsilatGunSayisi " +
                                                "WHERE CariHesapUnvani = @CariHesapUnvani AND CariHesapKodu = @CariHesapKodu";

                            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@CariHesapUnvani", cariHesapUnvani);
                                updateCommand.Parameters.AddWithValue("@CariHesapKodu", cariHesapKodu);
                                updateCommand.Parameters.AddWithValue("@Sehir", sehir);
                                updateCommand.Parameters.AddWithValue("@BolgeKodu", bolgeKodu);
                                updateCommand.Parameters.AddWithValue("@BolgeAdi", bolgeAdi);
                                updateCommand.Parameters.AddWithValue("@BolgeMuduru", bolgeMuduru);
                                updateCommand.Parameters.AddWithValue("@SahaKodu", sahaKodu);
                                updateCommand.Parameters.AddWithValue("@SahaAdi", sahaAdi);
                                updateCommand.Parameters.AddWithValue("@SahaMuduru", sahaMuduru);
                                updateCommand.Parameters.AddWithValue("@SonSatisTarihi", sonSatisTarihi);
                                updateCommand.Parameters.AddWithValue("@SonSatisMiktari", sonSatisMiktari);
                                updateCommand.Parameters.AddWithValue("@SonTahsilatTarihi", sonTahsilatTarihi);
                                updateCommand.Parameters.AddWithValue("@SonSatisGunSayisi", sonSatisGunSayisi);
                                updateCommand.Parameters.AddWithValue("@SonTahsilatGunSayisi", sonTahsilatGunSayisi);

                                updateCommand.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string insertQuery = "INSERT INTO CariHesaplar (CariHesapKodu, CariHesapUnvani, Sehir, BolgeKodu, BolgeAdi, BolgeMuduru, SahaKodu, SahaAdi, SahaMuduru, SonSatisTarihi, SonSatisMiktari, SonTahsilatTarihi, SonSatisGunSayisi, SonTahsilatGunSayisi, MailGonderildi, Cevaplandi) " +
                                                "VALUES (@CariHesapKodu, @CariHesapUnvani, @Sehir, @BolgeKodu, @BolgeAdi, @BolgeMuduru, @SahaKodu, @SahaAdi, @SahaMuduru, @SonSatisTarihi, @SonSatisMiktari, @SonTahsilatTarihi, @SonSatisGunSayisi, @SonTahsilatGunSayisi, 0, 0)";

                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@CariHesapKodu", cariHesapKodu);
                                insertCommand.Parameters.AddWithValue("@CariHesapUnvani", cariHesapUnvani);
                                insertCommand.Parameters.AddWithValue("@Sehir", sehir);
                                insertCommand.Parameters.AddWithValue("@BolgeKodu", bolgeKodu);
                                insertCommand.Parameters.AddWithValue("@BolgeAdi", bolgeAdi);
                                insertCommand.Parameters.AddWithValue("@BolgeMuduru", bolgeMuduru);
                                insertCommand.Parameters.AddWithValue("@SahaKodu", sahaKodu);
                                insertCommand.Parameters.AddWithValue("@SahaAdi", sahaAdi);
                                insertCommand.Parameters.AddWithValue("@SahaMuduru", sahaMuduru);
                                insertCommand.Parameters.AddWithValue("@SonSatisTarihi", sonSatisTarihi);
                                insertCommand.Parameters.AddWithValue("@SonSatisMiktari", sonSatisMiktari);
                                insertCommand.Parameters.AddWithValue("@SonTahsilatTarihi", sonTahsilatTarihi);
                                insertCommand.Parameters.AddWithValue("@SonSatisGunSayisi", sonSatisGunSayisi);
                                insertCommand.Parameters.AddWithValue("@SonTahsilatGunSayisi", sonTahsilatGunSayisi);

                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    // if (i % 10 == 0)
                    //{
                    //   if (MessageBox.Show("İşlemi durdurmak istiyor musunuz?", "Dikkat", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    //  {
                    //    break; // Kullanıcı işlemi iptal etti
                    //}
                    // }
                }
            }

            xlWorkbook.Close();
            xlApp.Quit();
            progressBar.Visible = false;
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);
            Marshal.ReleaseComObject(xlWorkbook);
            Marshal.ReleaseComObject(xlApp);

            this.Alert("Veriler başarıyla SQL tablosuna aktarıldı.", Form_Alert.enmType.Success);
            LoadDataFromDatabase(0, 0, null);
        }

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Dosyaları|*.xls;*.xlsx";
            openFileDialog.Title = "Excel Dosyası Seçin";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string excelFilePath = openFileDialog.FileName;
                progressBar.Value = 0;
                progressBar.Visible = true;
                ImportDataFromExcel(excelFilePath);
            }
        }

        private void bayitakipmainpage_Load(object sender, EventArgs e)
        {
            LoadDataFromDatabase(0, 0, null);

        }

        private void EkleMenuItem_Click(object sender, EventArgs e)
        {
            label4.Visible = Enabled;
            listBox1.Visible = Enabled;
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                string id = row.Cells["id"].Value.ToString();
                string cariHesapKodu = row.Cells["CariHesapKodu"].Value.ToString();
                string cariHesapUnvani = row.Cells["CariHesapUnvani"].Value.ToString();
                string sehir = row.Cells["Sehir"].Value.ToString();
                string bolgeMuduru = row.Cells["BolgeMuduru"].Value.ToString();
                string sonSatisTarihi = row.Cells["SonSatisTarihi"].Value.ToString();
                string sonSatisGunSayisi = row.Cells["SonSatisGunSayisi"].Value.ToString();
                string sonTahsilatTarihi = row.Cells["SonTahsilatTarihi"].Value.ToString();
                string sonTahsilatGunSayisi = row.Cells["SonTahsilatGunSayisi"].Value.ToString();

                string rowData = $"{id} * {cariHesapKodu} * {cariHesapUnvani} * {sehir} * {bolgeMuduru} * {sonSatisTarihi} * {sonSatisGunSayisi} * {sonTahsilatTarihi} * {sonTahsilatGunSayisi}";
                selectedRowsList.Add(rowData);
                listBox1.Items.Add(rowData);

                //MessageBox.Show($"Satır eklendi: {row.Cells["CariHesapKodu"].Value}");
                Alert("Satır Eklendi: " + row.Cells["CariHesapKodu"].Value, Form_Alert.enmType.Info);
            }
        }
        private void MailGonderMenuItem_Click(object sender, EventArgs e)
        {
            // Alıcı maili bölge koduna göre otomatik seç
            string bolgeKodu = dataGridView.SelectedRows[0].Cells["BolgeKodu"].Value.ToString();
            string bolumMail = GetBolumMail(bolgeKodu);

            // Her bir seçilen satırın bilgilerini ListBox kontrolünde gösterme işlemi
            listBox1.Items.Clear();
            foreach (string rowData in selectedRowsList)
            {
                listBox1.Items.Add(rowData);
            }

            // Burada e-posta gönderme işlemini gerçekleştir.
            SendEmail(selectedRowsList, bolumMail);
        }

        private void SendEmail(List<string> selectedRows, string receiverEmail)
        {
            string smtpServer = "smtp.office365.com";
            int smtpPort = 587;
            string senderEmail = "info@bpet.com.tr";
            string senderPassword = "IbBc*2014";

            try
            {
                using (SmtpClient client = new SmtpClient(smtpServer, smtpPort))
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential(senderEmail, senderPassword);
                    client.EnableSsl = true;

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(senderEmail);

                    mail.To.Add(receiverEmail);
                    mail.Bcc.Add("mustafa.ceylan@bpet.com.tr");
                    //mail.CC.Add("huseyin.toru@bpet.com.tr");
                    mail.Subject = "Bayi Takip Sistemi!";

                    // Sabit başlık metnini ekleyin
                    StringBuilder htmlContent = new StringBuilder();
                    htmlContent.Append("<html><body>");
                    htmlContent.Append("<p style='font-family: Arial, sans-serif; color: #333333;'>Bu mesaj, <strong>BPET PORTAL</strong> sistemi tarafından otomatik olarak gönderilmiştir. Ekte yer alan tabloda, sizin yönetim bölgenizdeki bazı bayilere ait güncel bilgiler bulunmaktadır. Özellikle, son tahsilat ve son satış tarihleri geçmiş bayiler hakkında bilgilendirme yapılacaktır. Bu bilgiler, haftalık olarak sizlere iletilecektir.<br><br>BPET PORTAL masaüstü uygulamasını kullanarak, bu güncellemelere ve taleplere sistem üzerinden kolaylıkla cevap verebilirsiniz. İş süreçlerinizde verimliliği artırmak ve gerekli bilgilere hızla erişmek adına bu sistemi aktif olarak kullanmanız önem arz etmektedir.</p>");
                    htmlContent.Append("<p>BPET PORTAL'a nasıl kayıt olunabileceğini öğrenmek için <a href='https://www.youtube.com/watch?v=FggWnbXGLZc' target='_blank'>bu videoyu</a> izleyebilirsiniz.</p>");
                    htmlContent.Append("<p>BPET PORTAL Bayi Takip Sisteminin nasıl kullanacağını öğrenmek için <a href='https://www.youtube.com/watch?v=Zs1LxMaS9gk' target='_blank'>bu videoyu</a> izleyebilirsiniz.</p>");

                    htmlContent.Append("<p>BPET PORTAL eğer bilgisayarınızda mevcut değilse, Bilgi Teknolojileri ekibinden Mustafa Uğur CEYLAN'a ulaşabilirsiniz. (0 544 681 80 43) </p>");

                    // DataTable oluştur ve sütunları ekle
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Bayi Adı");
                    dataTable.Columns.Add("Şehir");
                    dataTable.Columns.Add("BolgeAdi");
                    dataTable.Columns.Add("Son Satış Tarihi");
                    dataTable.Columns.Add("Son Satıştan Gün Sayısı");
                    dataTable.Columns.Add("Son Tahsilat Tarihi");
                    dataTable.Columns.Add("Son Tahsilattan Gün Sayısı");

                    foreach (string rowData in selectedRows)
                    {
                        string[] rowValues = rowData.Split('*').Select(value => value.Trim()).ToArray();
                        DataRow row = dataTable.NewRow();

                        int id;
                        if (int.TryParse(rowValues[0], out id))
                        {
                            UpdateDatabase(id);
                        }

                        row["Bayi Adı"] = rowValues[2];
                        row["Şehir"] = rowValues[3];
                        row["BolgeAdi"] = rowValues[4];
                        DateTime sonSatisTarihi, sonTahsilatTarihi;

                        if (DateTime.TryParse(rowValues[5], out sonSatisTarihi))
                        {
                            row["Son Satış Tarihi"] = sonSatisTarihi.ToShortDateString();
                        }

                        row["Son Satıştan Gün Sayısı"] = rowValues[6];

                        if (DateTime.TryParse(rowValues[7], out sonTahsilatTarihi))
                        {
                            row["Son Tahsilat Tarihi"] = sonTahsilatTarihi.ToShortDateString();
                        }

                        row["Son Tahsilattan Gün Sayısı"] = rowValues[8];
                        dataTable.Rows.Add(row);
                    }

                    // DataTable'ı kullanarak HTML tablosunu oluştur
                    StringBuilder htmlTable = new StringBuilder();
                    htmlTable.Append("<table border='1'>");

                    // Sütun başlıklarını ekle
                    htmlTable.Append("<tr>");
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        htmlTable.Append($"<th>{column.ColumnName}</th>");
                    }
                    htmlTable.Append("</tr>");

                    // Verileri ekleyerek tabloyu oluştur
                    foreach (DataRow row in dataTable.Rows)
                    {
                        htmlTable.Append("<tr>");
                        foreach (var item in row.ItemArray)
                        {
                            htmlTable.Append($"<td>{item}</td>");
                        }
                        htmlTable.Append("</tr>");
                    }

                    htmlTable.Append("</table>");
                    htmlContent.Append(htmlTable.ToString());
                    htmlContent.Append("</body></html>");

                    // Şimdi mail.Body'yi bu HTML içeriğiyle doldurabilirsiniz
                    mail.Body = htmlContent.ToString();
                    mail.IsBodyHtml = true;
                    client.Send(mail);

                    Alert("E-Posta Başarıyla Gönderildi. " + receiverEmail, Form_Alert.enmType.Info);
                    LoadDataFromDatabase(0, 0, null);
                    listBox1.Items.Clear();
                    selectedRowsList.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"E-posta gönderme hatası: {ex.Message}");
                LoadDataFromDatabase(0, 0, null);
            }
        }
        private void UpdateDatabase(int id)
        {
            string connectionString = "Server=95.0.50.22,1382;Database=BPET_PORTAL;User ID=sa;Password=Mustafa1;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE CariHesaplar SET MailGonderildi = 1 WHERE id = @Id";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void btnverileriekle_Click(object sender, EventArgs e)
        {
            label4.Visible = Enabled;
            listBox1.Visible = Enabled;
            selectedRowsList.Clear();
            listBox1.Items.Clear();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                string id = row.Cells["id"].Value.ToString();
                string cariHesapKodu = row.Cells["CariHesapKodu"].Value.ToString();
                string cariHesapUnvani = row.Cells["CariHesapUnvani"].Value.ToString();
                string sehir = row.Cells["Sehir"].Value.ToString();
                string bolgeMuduru = row.Cells["BolgeMuduru"].Value.ToString();
                string sonSatisTarihi = row.Cells["SonSatisTarihi"].Value.ToString();
                string sonSatisGunSayisi = row.Cells["SonSatisGunSayisi"].Value.ToString();
                string sonTahsilatTarihi = row.Cells["SonTahsilatTarihi"].Value.ToString();
                string sonTahsilatGunSayisi = row.Cells["SonTahsilatGunSayisi"].Value.ToString();

                string rowData = $"{id} * {cariHesapKodu} * {cariHesapUnvani} * {sehir} * {bolgeMuduru} * {sonSatisTarihi} * {sonSatisGunSayisi} * {sonTahsilatTarihi} * {sonTahsilatGunSayisi}";
                selectedRowsList.Add(rowData);
                listBox1.Items.Add(rowData);
            }

            Alert("Tüm Hesaplar Eklendi", Form_Alert.enmType.Success);
        }

        private void btntoplumailgndr_Click(object sender, EventArgs e)
        {
            // Alıcı maili bölge koduna göre otomatik seç
            string bolgeKodu = dataGridView.Rows[0].Cells["BolgeKodu"].Value.ToString();
            string bolumMail = GetBolumMail(bolgeKodu);

            // Her bir seçilen satırın bilgilerini ListBox kontrolünde gösterme işlemi
            listBox1.Items.Clear();
            foreach (string rowData in selectedRowsList)
            {
                listBox1.Items.Add(rowData);
            }

            // Burada e-posta gönderme işlemini gerçekleştir.
            SendEmail(selectedRowsList, bolumMail);
        }

        private void btnVeriTabaniSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("GECMİS TABLOSU CariHesaplarGecmis tablosunu da temizlemek istiyor musunuz?", "Tablo Temizleme Onayı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                TemizleCariHesaplarGecmis();
            }
            if (MessageBox.Show("ANA TABLO CariHesaplar tablosunu da temizlemek istiyor musunuz?", "Tablo Temizleme Onayı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                TemizleCariHesaplar();
            }
            LoadDataFromDatabase(0, 0, null);
        }
        private void TemizleCariHesaplar()
        {
            string connectionString = "Server=95.0.50.22,1382;Database=BPET_PORTAL;User ID=sa;Password=Mustafa1;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM CariHesaplar";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("CariHesaplar tablosu başarıyla temizlendi.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TemizleCariHesaplarGecmis()
        {
            string connectionString = "Server=95.0.50.22,1382;Database=BPET_PORTAL;User ID=sa;Password=Mustafa1;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM CariHesaplarGecmis";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("CariHesaplarGecmis tablosu başarıyla temizlendi.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
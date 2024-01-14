using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace BPET_PORTAL.bilgi_islem.talep_giris
{
    public partial class TalepGirisAnaEkran : Form
    {
        private const string connectionString = "Server=95.0.50.22,1382;Database=TalepVeritabani;User ID=sa;Password=Mustafa1;";
        private string[] sonuclandiranlar = { "İsmail Sertel", "Mustafa Uğur Ceylan", "Burak Sönmez", "Batuhan Avcıoğlu" };
        private List<string> importedExcelSheets = new List<string>();
        public TalepGirisAnaEkran()
        {
            InitializeComponent();
            FillComboBoxWithMonths();

            cmbAylar.SelectedIndex = DateTime.Today.Month - 1;

            linkLabel.LinkBehavior = LinkBehavior.SystemDefault;
            linkLabel.LinkClicked += LinkLabel_LinkClicked;
            linkLabel.Links.Add(9, 25, "https://www.bpet.com.tr/tr/");

            // Talep Türü ComboBox'ına elemanları ekleme
            cmbTalepTuru.Items.Add("Yazılım");
            cmbTalepTuru.Items.Add("Fatura");
            cmbTalepTuru.Items.Add("Donanım");
            cmbTalepTuru.Items.Add("Yazılım-Donanım");

            // Talep Kanalı ComboBox'ına elemanları ekleme
            cmbTalepKanali.Items.Add("Telefon");
            cmbTalepKanali.Items.Add("Yüzyüze");
            cmbTalepKanali.Items.Add("Mail");
            // Sonuçlandıran Kişiler ComboBox'ına elemanları ekleme
            foreach (string person in sonuclandiranlar)
            {
                cmbSonuclandiran.Items.Add(person);
            }

            cmbTalepKanali.DropDownStyle = ComboBoxStyle.DropDownList; // Yazı yazılmasını engelle
            cmbTalepKanali.DropDownStyle = ComboBoxStyle.DropDownList; // Yazı yazılmasını engelle
            cmbSonuclandiran.DropDownStyle = ComboBoxStyle.DropDownList; // Yazı yazılmasını engelle
                                                                         // Talep tarihi için saat ve dakika seçimi
            dateTimeTalepTarihi.Format = DateTimePickerFormat.Custom;
            dateTimeTalepTarihi.CustomFormat = "dd.MM.yyyy HH:mm";

            // Çözüm tarihi için saat ve dakika seçimi
            dateTimeTalepCozumTarihi.Format = DateTimePickerFormat.Custom;
            dateTimeTalepCozumTarihi.CustomFormat = "dd.MM.yyyy HH:mm";

            ; // Sütunları otomatik boyutlandır
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Sütun boyutlarını hücre içeriğine göre ayarla
            // Hücre içeriğini istediğiniz yazı tipi ve boyutuyla görüntüleme
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 12); // İstediğiniz yazı tipi ve boyutunu kullanabilirsiniz

            // Başlık satırı görünümünü özelleştirme
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // İstediğiniz yazı tipi ve boyutunu kullanabilirsiniz
        }
        private void FillComboBoxWithMonths()
        {
            // ComboBox'a tüm ayları ekleyin.
            for (int month = 1; month <= 12; month++)
            {
                string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
                cmbAylar.Items.Add(monthName);
            }
        }
        private void cmbAylar_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ComboBox'ta seçilen ayın indeksini alın (1-12).
            int selectedMonthIndex = cmbAylar.SelectedIndex + 1;

            RefreshDataGridViewForMonth(selectedMonthIndex);
            //dataGridView1.Columns["ID"].Visible = false;
        }
        // DataGridView'de Delete tuşuna basıldığında çalışacak olay
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Seçili veriyi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        // DataGridView'de seçili satırı veritabanından sil
                        int rowIndex = dataGridView1.SelectedRows[0].Index;
                        int idToDelete = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["ID"].Value);

                        try
                        {
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();

                                string deleteQuery = "DELETE FROM Talepler WHERE ID = @ID";
                                SqlCommand command = new SqlCommand(deleteQuery, connection);
                                command.Parameters.AddWithValue("@ID", idToDelete);
                                command.ExecuteNonQuery();

                                // Veri silindi, DataGridView'i güncelle
                                int selectedMonthIndex = cmbAylar.SelectedIndex + 1;
                                RefreshDataGridViewForMonth(selectedMonthIndex);

                                MessageBox.Show("Veri başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hata oluştu 1: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        public void RefreshDataGridViewForMonth(int selectedMonth)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Talepler WHERE MONTH(TalepTarihi) = @SelectedMonth ORDER BY TalepTarihi ASC";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SelectedMonth", selectedMonth);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dataTable;
                        dataGridView1.Columns["ID"].Visible = false;
                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                    }
                    else
                    {
                        dataGridView1.DataSource = null; // Veri yoksa DataGridView'ı temizle
                        //MessageBox.Show($"{selectedMonth}. ay için veri bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = e.Link.LinkData as string;
            if (!string.IsNullOrEmpty(url))
            {
                Process.Start(url); // Varsayılan tarayıcıda linki açar
            }
        }


        private void btnExcelSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Dosyaları|*.xlsx;";
            openFileDialog.Title = "Excel Dosyası Seç";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string excelFilePath = openFileDialog.FileName;
                ImportExcelDataToDatabase(excelFilePath);
            }
        }
        private DateTime ParseDateTime(string dateTimeStr)
        {
            if (DateTime.TryParseExact(dateTimeStr, "dd.MM.yyyy-HH-mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                return result;
            }
            else
            {
                throw new Exception("Geçersiz tarih/saat formatı: " + dateTimeStr);
            }
        }
        private void ImportExcelDataToDatabase(string excelFilePath)
        {
            try
            {
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Open(excelFilePath);

                // Tüm sayfaları dolaşarak verileri ekleyin
                foreach (Excel._Worksheet worksheet in workbook.Sheets)
                {
                    string sheetName = worksheet.Name;

                    // Sayfa daha önce eklenmişse atlayın
                    if (importedExcelSheets.Contains(sheetName))
                        continue;

                    importedExcelSheets.Add(sheetName);

                    Excel.Range range = worksheet.UsedRange;

                    int rowCount = range.Rows.Count;
                    int colCount = range.Columns.Count;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        for (int i = 2; i <= rowCount; i++)
                        {
                            string kullanici = ((Excel.Range)range.Cells[i, 1]).Text;
                            string sonuclandiran = ((Excel.Range)range.Cells[i, 2]).Text;
                            string talepTur = ((Excel.Range)range.Cells[i, 3]).Text;
                            string konu = ((Excel.Range)range.Cells[i, 4]).Text;
                            string talepKanali = ((Excel.Range)range.Cells[i, 5]).Text;
                            string talepTarihiStr = ((Excel.Range)range.Cells[i, 6]).Text;
                            string talepCozumTarihiStr = ((Excel.Range)range.Cells[i, 7]).Text;

                            DateTime talepTarihi = ParseDateTime(talepTarihiStr);
                            DateTime talepCozumTarihi = ParseDateTime(talepCozumTarihiStr);

                            string insertQuery = "INSERT INTO Talepler (Kullanici, Sonuclandiran, TalepTur, Konu, TalepKanali, TalepTarihi, TalepCozumTarihi) " +
                                                 "VALUES (@Kullanici, @Sonuclandiran, @TalepTur, @Konu, @TalepKanali, @TalepTarihi, @TalepCozumTarihi)";

                            SqlCommand command = new SqlCommand(insertQuery, connection);
                            command.Parameters.AddWithValue("@Kullanici", kullanici);
                            command.Parameters.AddWithValue("@Sonuclandiran", sonuclandiran);
                            command.Parameters.AddWithValue("@TalepTur", talepTur);
                            command.Parameters.AddWithValue("@Konu", konu);
                            command.Parameters.AddWithValue("@TalepKanali", talepKanali);
                            command.Parameters.AddWithValue("@TalepTarihi", talepTarihi);
                            command.Parameters.AddWithValue("@TalepCozumTarihi", talepCozumTarihi);

                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show($"Excel verileri '{sheetName}' sayfasından veritabanına aktarıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                workbook.Close();
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu 3: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnGonder_Click(object sender, EventArgs e)
        {
            string kullanici = txtKullanici.Text;
            string sonuclandiran = cmbSonuclandiran.SelectedItem?.ToString();
            string talepTur = cmbTalepTuru.SelectedItem?.ToString();
            string konu = txtKonu.Text;
            string talepKanali = cmbTalepKanali.SelectedItem?.ToString();
            DateTime talepTarihi = dateTimeTalepTarihi.Value;
            DateTime talepCozumTarihi = dateTimeTalepCozumTarihi.Value;

            if (string.IsNullOrWhiteSpace(kullanici) || string.IsNullOrWhiteSpace(sonuclandiran) || string.IsNullOrWhiteSpace(talepTur) || string.IsNullOrWhiteSpace(konu) || string.IsNullOrWhiteSpace(talepKanali))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Talepler (Kullanici, Sonuclandiran, TalepTur, Konu, TalepKanali, TalepTarihi, TalepCozumTarihi) " +
                                         "VALUES (@Kullanici, @Sonuclandiran, @TalepTur, @Konu, @TalepKanali, @TalepTarihi, @TalepCozumTarihi)";

                    SqlCommand command = new SqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@Kullanici", kullanici);
                    command.Parameters.AddWithValue("@Sonuclandiran", sonuclandiran);
                    command.Parameters.AddWithValue("@TalepTur", talepTur);
                    command.Parameters.AddWithValue("@Konu", konu);
                    command.Parameters.AddWithValue("@TalepKanali", talepKanali);
                    command.Parameters.AddWithValue("@TalepTarihi", talepTarihi);
                    command.Parameters.AddWithValue("@TalepCozumTarihi", talepCozumTarihi);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Talep başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        int selectedMonthIndex = cmbAylar.SelectedIndex + 1;
                        RefreshDataGridViewForMonth(selectedMonthIndex);

                    }
                    else
                    {
                        MessageBox.Show("Talep kaydedilemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        int selectedMonthIndex = cmbAylar.SelectedIndex + 1;
                        RefreshDataGridViewForMonth(selectedMonthIndex);
                    }

                    // Formu temizle
                    txtKullanici.Clear();
                    cmbSonuclandiran.SelectedIndex = -1;
                    cmbTalepTuru.SelectedIndex = -1;
                    txtKonu.Clear();
                    cmbTalepKanali.SelectedIndex = -1;
                    dateTimeTalepTarihi.Value = DateTime.Now;
                    dateTimeTalepCozumTarihi.Value = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu 4: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AnaEkran_Load(object sender, EventArgs e)
        {
            //dataGridView1.Columns["ID"].Visible = false;
            int selectedMonthIndex = cmbAylar.SelectedIndex + 1;
            RefreshDataGridViewForMonth(selectedMonthIndex);
            LoadAutocompleteSuggestions();

        }
        private void LoadAutocompleteSuggestions()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT DISTINCT Kullanici FROM Talepler";
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                    while (reader.Read())
                    {
                        string kullanici = reader["Kullanici"].ToString();
                        autoCompleteCollection.Add(kullanici);
                    }

                    // Kullanıcı adı textbox'ına autocomplete önerilerini ayarla
                    txtKullanici.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtKullanici.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtKullanici.AutoCompleteCustomSource = autoCompleteCollection;

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ExportToExcel()
        {
            try
            {
                // Excel dosyasını kaydetmek için kullanıcıya dosya yolu seçtirin
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Dosyaları|*.xlsx";
                saveFileDialog.Title = "Excel Dosyası Kaydet";
                saveFileDialog.FileName = "Talepler"; // Dosya adını "Talepler" olarak ayarlayın
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string excelFilePath = saveFileDialog.FileName;
                    Excel.Application excelApp = new Excel.Application();
                    Excel.Workbook workbook = excelApp.Workbooks.Add();

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "SELECT * FROM Talepler";
                        SqlCommand command = new SqlCommand(query, connection);

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        // Veri varsa, Excel'e ekle
                        if (dataTable.Rows.Count > 0)
                        {
                            Excel._Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet; // Aktif sayfayı al

                            // Sütun başlıklarını ekle ve kalın sarı renge boyayın
                            for (int i = 1; i <= dataTable.Columns.Count; i++)
                            {
                                worksheet.Cells[1, i] = dataTable.Columns[i - 1].ColumnName;
                                Excel.Range cellRange = (Excel.Range)worksheet.Cells[1, i];
                                cellRange.Font.Bold = true;
                                cellRange.Interior.Color = Excel.XlRgbColor.rgbYellow;
                            }

                            for (int i = 0; i < dataTable.Rows.Count; i++)
                            {
                                for (int j = 0; j < dataTable.Columns.Count; j++)
                                {
                                    worksheet.Cells[i + 2, j + 1] = dataTable.Rows[i][j].ToString();
                                }
                            }

                            // Sütun ve satırları otomatik olarak ayarla
                            worksheet.Columns.AutoFit();
                            worksheet.Rows.AutoFit();
                        }
                    }

                    // Excel dosyasını kaydet
                    workbook.SaveAs(excelFilePath);
                    workbook.Close();
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                    MessageBox.Show("Veriler Excel dosyasına aktarıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu 5: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToExcelByMonths()
        {
            try
            {
                // Excel dosyasını kaydetmek için kullanıcıya dosya yolu seçtirin
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Dosyaları|*.xlsx";
                saveFileDialog.Title = "Excel Dosyası Kaydet";
                saveFileDialog.FileName = "Talepler"; // Dosya adını "Talepler" olarak ayarlayın

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string excelFilePath = saveFileDialog.FileName;
                    Excel.Application excelApp = new Excel.Application();
                    Excel.Workbook workbook = excelApp.Workbooks.Add();

                    foreach (string month in cmbAylar.Items)
                    {
                        int selectedMonthIndex = cmbAylar.FindStringExact(month) + 1;

                        DataTable dataTable = new DataTable();
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = "SELECT * FROM Talepler WHERE MONTH(TalepTarihi) = @SelectedMonth";
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@SelectedMonth", selectedMonthIndex);

                            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                            dataAdapter.Fill(dataTable);
                        }

                        // Veri varsa, Excel'e ekle
                        if (dataTable.Rows.Count > 0)
                        {
                            Excel._Worksheet worksheet = (Excel.Worksheet)workbook.Sheets.Add();
                            worksheet.Name = month;

                            // Sütun başlıklarını ekle ve kalın sarı renge boyayın
                            for (int i = 1; i <= dataTable.Columns.Count; i++)
                            {
                                worksheet.Cells[1, i] = dataTable.Columns[i - 1].ColumnName;
                                Excel.Range cellRange = (Excel.Range)worksheet.Cells[1, i];
                                cellRange.Font.Bold = true;
                                cellRange.Interior.Color = Excel.XlRgbColor.rgbYellow;
                            }

                            for (int i = 0; i < dataTable.Rows.Count; i++)
                            {
                                for (int j = 0; j < dataTable.Columns.Count; j++)
                                {
                                    worksheet.Cells[i + 2, j + 1] = dataTable.Rows[i][j].ToString();
                                }
                            }

                            // Sütun ve satırları otomatik olarak ayarla
                            worksheet.Columns.AutoFit();
                            worksheet.Rows.AutoFit();
                        }
                    }

                    // Excel dosyasını kaydet
                    workbook.SaveAs(excelFilePath);
                    workbook.Close();
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                    MessageBox.Show("Veriler Excel dosyasına aktarıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu 6: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                ShowTalepDetails(selectedRow);
            }
        }
        private void ShowTalepDetails(DataGridViewRow selectedRow)
        {
            string id = selectedRow.Cells["ID"].Value.ToString();
            string kullanici = selectedRow.Cells["Kullanici"].Value.ToString();
            string sonuclandiran = selectedRow.Cells["Sonuclandiran"].Value.ToString();
            string talepTur = selectedRow.Cells["TalepTur"].Value.ToString();
            string konu = selectedRow.Cells["Konu"].Value.ToString();
            string talepKanali = selectedRow.Cells["TalepKanali"].Value.ToString();
            DateTime talepTarihi = Convert.ToDateTime(selectedRow.Cells["TalepTarihi"].Value);
            DateTime talepCozumTarihi = Convert.ToDateTime(selectedRow.Cells["TalepCozumTarihi"].Value);

            TimeSpan talepSure = talepCozumTarihi - talepTarihi;

            string message = $"İD:{id}\nKullanıcı: {kullanici}\nSonuçlandıran: {sonuclandiran}\nTalep Türü: {talepTur}\nKonu: {konu}\nTalep Kanalı: {talepKanali}" +
                             $"\nTalep Tarihi: {talepTarihi.ToString("dd.MM.yyyy HH:mm")}\nTalep Çözüm Tarihi: {talepCozumTarihi.ToString("dd.MM.yyyy HH:mm")}" +
                             $"\nTalep Çözüm Süresi: {talepSure.Days} gün, {talepSure.Hours} saat, {talepSure.Minutes} dakika";

            MessageBox.Show(message, "Talep Detayları", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Aylara ayrılsın mı?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Aylara ayrılarak Excel'e aktar
                ExportToExcelByMonths();
            }
            else
            {
                // Tüm verileri tek sayfada Excel'e aktar
                ExportToExcel();
            }
        }
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[e.RowIndex].Selected = true;

                ContextMenuStrip contextMenu = new ContextMenuStrip();

                ToolStripMenuItem editMenuItem = new ToolStripMenuItem("Düzenle");
                //editMenuItem.Image = BPET_Talep_Giriş.Properties.Resources.icons8_edit_64;
                editMenuItem.Click += EditMenuItem_Click;
                contextMenu.Items.Add(editMenuItem);

                ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Sil");
                //deleteMenuItem.Image = BPET_Talep_Giriş.Properties.Resources.icons8_delete_48;
                deleteMenuItem.Click += DeleteMenuItem_Click;
                contextMenu.Items.Add(deleteMenuItem);

                ToolStripMenuItem detayMenuItem = new ToolStripMenuItem("Detay");
                //detayMenuItem.Image = BPET_Talep_Giriş.Properties.Resources.icons8_info_100;
                detayMenuItem.Click += DetayMenuItem_Click;
                contextMenu.Items.Add(detayMenuItem);

                dataGridView1.ContextMenuStrip = contextMenu;
            }
        }

        private void EditMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            string id = selectedRow.Cells["ID"].Value.ToString();
            int id2 = Convert.ToInt32(id); // yourIdString, id değerini içeren string ifade
            // Diğer verileri de burada alabilirsiniz

            // Düzenleme formunu açmak için gerekli kodu burada kullanabilirsiniz
            // Örnek olarak:
            TalepDuzenleEkran duzenleForm = new TalepDuzenleEkran(id2, this, cmbAylar.SelectedIndex + 1);
            duzenleForm.ShowDialog();
            int selectedMonthIndex = cmbAylar.SelectedIndex + 1;
            RefreshDataGridViewForMonth(selectedMonthIndex);
        }
        private void DetayMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            ShowTalepDetails(selectedRow);
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int idToDelete = Convert.ToInt32(selectedRow.Cells["ID"].Value);

            DialogResult result = MessageBox.Show("Seçili veriyi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string deleteQuery = "DELETE FROM Talepler WHERE ID = @ID";
                        SqlCommand command = new SqlCommand(deleteQuery, connection);
                        command.Parameters.AddWithValue("@ID", idToDelete);
                        command.ExecuteNonQuery();

                        int selectedMonthIndex = cmbAylar.SelectedIndex + 1;
                        RefreshDataGridViewForMonth(selectedMonthIndex);

                        MessageBox.Show("Veri başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu 7: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void yenile_Click(object sender, EventArgs e)
        {
            int selectedMonthIndex = cmbAylar.SelectedIndex + 1;
            RefreshDataGridViewForMonth(selectedMonthIndex);
            LoadAutocompleteSuggestions();

        }
    }
}

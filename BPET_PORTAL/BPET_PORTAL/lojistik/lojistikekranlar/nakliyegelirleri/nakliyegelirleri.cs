using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace BPET_PORTAL.lojistik.lojistikekranlar.nakliyegelirleri
{
    public partial class nakliyegelirleri : Form
    {
        string connectionString = "Server=95.0.50.22,1382;Database=lojistik;User ID=sa;Password=Mustafa1;";
        private DataTable originalDataTable;

        public nakliyegelirleri()
        {
            InitializeComponent();
            LoadAutoCompleteData(); // Autocomplete için veritabanından verileri yükle
        }
        private void LoadData()
        {
            // Şuanki yıl ve ay bilgisini al
            DateTime currentDate = DateTime.Now;
            int currentYear = currentDate.Year;
            int currentMonth = currentDate.Month;

            // SQL sorgusunu şuanki yıl ve ay bazında filtreleyerek oluştur
            string queryString = $"SELECT * FROM nakliyetablosu WHERE YEAR(Tarih) = {currentYear} AND MONTH(Tarih) = {currentMonth}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                originalDataTable = new DataTable();
                adapter.Fill(originalDataTable);
                dataGridView.DataSource = originalDataTable;
            }

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                dataGridView.AutoResizeColumn(column.Index, DataGridViewAutoSizeColumnMode.AllCells);
            }

            nakliyebedelihesapla();
        }

        private void LoadAutoCompleteData()
        {
            // ComboBox'lara verileri yükleyin
            LoadComboBoxData("SELECT DISTINCT CariUnvani FROM nakliyetablosu", cmbCariUnvan);
            LoadComboBoxData("SELECT DISTINCT CariKodu FROM nakliyetablosu", cmbCariKod);
            LoadComboBoxData("SELECT DISTINCT SoforAdi FROM nakliyetablosu", cmbSoforAdi);
            LoadAutoCompleteDataForMetroTextBox("SELECT DISTINCT Plaka FROM nakliyetablosu", txtPlaka);
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                dataGridView.AutoResizeColumn(column.Index, DataGridViewAutoSizeColumnMode.AllCells);
            }
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
                            comboBox.Items.Add(reader[0].ToString());
                        }
                    }
                }
            }
        }
        private void LoadAutoCompleteDataForMetroTextBox(string query, MetroFramework.Controls.MetroTextBox metroTextBox)
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
                            metroTextBox.AutoCompleteCustomSource.Add(reader[0].ToString());
                        }
                    }
                }
            }
        }
        private void ApplyFilters()
        {
            string queryString = "SELECT * FROM nakliyetablosu WHERE 1 = 1";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);

                // Tarih aralığı filtresi
                DateTime startDate = dateTimePickerStart.Value;
                DateTime endDate = dateTimePickerEnd.Value;
                adapter.SelectCommand.CommandText += " AND Tarih BETWEEN @StartDate AND @EndDate";
                adapter.SelectCommand.Parameters.AddWithValue("@StartDate", startDate);
                adapter.SelectCommand.Parameters.AddWithValue("@EndDate", endDate);

                // Diğer filtreleme seçeneklerini ekleyin
                AddFilterCondition(adapter, "BelgeNo", txtBelgeNo.Text);
                AddFilterCondition(adapter, "CariKodu", cmbCariKod.Text);
                AddFilterCondition(adapter, "CariUnvani", cmbCariUnvan.Text);
                AddFilterCondition(adapter, "Plaka", txtPlaka.Text);
                AddFilterCondition(adapter, "FaturaNo", txtFaturaNo.Text);

                DataTable filteredDataTable = new DataTable();
                adapter.Fill(filteredDataTable);

                dataGridView.DataSource = filteredDataTable;

                nakliyebedelihesapla();
                
            }
        }
        private void nakliyebedelihesapla()
        {
            decimal FaturaToplamı = 0;


            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                FaturaToplamı += Convert.ToDecimal(row.Cells["FaturaToplam"].Value);

            }

            // Toplam miktarları label'lara yazdır
            labelToplamNakliyeBedeli.Text = $"{FaturaToplamı:N2} ₺";
        }
        private void AddFilterCondition(SqlDataAdapter adapter, string columnName, string filterValue)
        {
            if (!string.IsNullOrEmpty(filterValue))
            {
                adapter.SelectCommand.CommandText += $" AND {columnName} LIKE @{columnName}";
                adapter.SelectCommand.Parameters.AddWithValue($"@{columnName}", $"%{filterValue}%");
            }
        }
        private void ImportDataFromExcel(string excelFilePath)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(excelFilePath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            int rowCount = xlRange.Rows.Count;
            progressBar.Maximum = rowCount;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                for (int i = 3; i <= rowCount; i++)
                {
                    string tarihStr = xlRange.Cells[i, 1].Text;
                    string belgeNo = xlRange.Cells[i, 2].Text;
                    string odemePlani = xlRange.Cells[i, 4].Text;
                    string cariKodu = xlRange.Cells[i, 5].Text;
                    string cariUnvani = xlRange.Cells[i, 6].Text;
                    string faturaNo = xlRange.Cells[i, 7].Text;
                    string plaka = xlRange.Cells[i, 8].Text;
                    string stokAciklamasi = xlRange.Cells[i, 12].Text;
                    decimal faturaToplam;

                    if (DateTime.TryParseExact(tarihStr, "d.M.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime tarih))
                    {
                        // Başarıyla tarih çözümlendi, tarih değişkeni artık doğru değeri içeriyor
                    }
                    else
                    {
                        // Hatalı tarih formatı, gün sayısının başına 0 ekleyip tekrar deneyin
                        if (DateTime.TryParseExact("0" + tarihStr, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tarih))
                        {
                            // Başarıyla tarih çözümlendi, tarih değişkeni artık doğru değeri içeriyor
                        }
                        else
                        {
                            // İkinci denemede de başarısız olursa hata alın
                            this.Alert("TARİH HATA: " + tarihStr + " ft: " + faturaNo, Form_Alert.enmType.Info);
                            continue;
                        }
                    }

                    if (decimal.TryParse(xlRange.Cells[i, 13].Text, out faturaToplam))
                    {
                        // Başarıyla sayısal değer çözümlendi
                    }
                    else
                    {
                        this.Alert("toplam HATA: " + faturaToplam + " ft: " + faturaNo, Form_Alert.enmType.Info);

                        continue; // Hata olduğunda bu veriyi atlayın
                    }

                    string soforAdi = xlRange.Cells[i, 16].Text; // P sütunu

                    string checkQuery = "SELECT COUNT(*) FROM nakliyetablosu WHERE Tarih = @Tarih AND BelgeNo = @BelgeNo AND OdemePlani = @OdemePlani " +
                        "AND CariKodu = @CariKodu AND CariUnvani = @CariUnvani AND FaturaNo = @FaturaNo AND Plaka = @Plaka AND StokAciklamasi = @StokAciklamasi " +
                        "AND FaturaToplam = @FaturaToplam AND SoforAdi = @SoforAdi";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Tarih", tarih);
                        checkCommand.Parameters.AddWithValue("@BelgeNo", belgeNo);
                        checkCommand.Parameters.AddWithValue("@OdemePlani", odemePlani);
                        checkCommand.Parameters.AddWithValue("@CariKodu", cariKodu);
                        checkCommand.Parameters.AddWithValue("@CariUnvani", cariUnvani);
                        checkCommand.Parameters.AddWithValue("@FaturaNo", faturaNo);
                        checkCommand.Parameters.AddWithValue("@Plaka", plaka);
                        checkCommand.Parameters.AddWithValue("@StokAciklamasi", stokAciklamasi);
                        checkCommand.Parameters.AddWithValue("@FaturaToplam", faturaToplam);
                        checkCommand.Parameters.AddWithValue("@SoforAdi", soforAdi);
                        int existingRecords = (int)checkCommand.ExecuteScalar();

                        if (existingRecords > 0)
                        {
                            // Belirli bir kombinasyona sahip kayıt zaten varsa güncelleme yapabilirsiniz.
                            string updateQuery = "UPDATE nakliyetablosu " +
                                                 "SET OdemePlani = @OdemePlani, CariUnvani = @CariUnvani, " +
                                                 "FaturaNo = @FaturaNo, StokAciklamasi = @StokAciklamasi, " +
                                                 "SoforAdi = @SoforAdi " +
                                                 "WHERE Tarih = @Tarih AND BelgeNo = @BelgeNo AND OdemePlani = @OdemePlani " +
                                                 "AND CariKodu = @CariKodu AND CariUnvani = @CariUnvani AND FaturaNo = @FaturaNo AND Plaka = @Plaka AND StokAciklamasi = @StokAciklamasi " +
                                                 "AND FaturaToplam = @FaturaToplam AND SoforAdi = @SoforAdi";

                            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@Tarih", tarih);
                                updateCommand.Parameters.AddWithValue("@OdemePlani", odemePlani);
                                updateCommand.Parameters.AddWithValue("@CariKodu", cariKodu);
                                updateCommand.Parameters.AddWithValue("@CariUnvani", cariUnvani);
                                updateCommand.Parameters.AddWithValue("@FaturaNo", faturaNo);
                                updateCommand.Parameters.AddWithValue("@Plaka", plaka);
                                updateCommand.Parameters.AddWithValue("@StokAciklamasi", stokAciklamasi);
                                updateCommand.Parameters.AddWithValue("@FaturaToplam", faturaToplam);
                                updateCommand.Parameters.AddWithValue("@SoforAdi", soforAdi);

                                updateCommand.ExecuteNonQuery();
                            }
                            this.Alert("GÜNCELLENDİ: " + faturaNo, Form_Alert.enmType.Info);
                        }
                        else
                        {
                            // BelgeNo'ya sahip bir kayıt yoksa ekleme yapabilirsiniz.
                            string insertQuery = "INSERT INTO nakliyetablosu (Tarih, BelgeNo, OdemePlani, CariKodu, CariUnvani, FaturaNo, Plaka, StokAciklamasi, FaturaToplam, SoforAdi) " +
                                                "VALUES (@Tarih, @BelgeNo, @OdemePlani, @CariKodu, @CariUnvani, @FaturaNo, @Plaka, @StokAciklamasi, @FaturaToplam, @SoforAdi)";

                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@Tarih", tarih);
                                insertCommand.Parameters.AddWithValue("@BelgeNo", belgeNo);
                                insertCommand.Parameters.AddWithValue("@OdemePlani", odemePlani);
                                insertCommand.Parameters.AddWithValue("@CariKodu", cariKodu);
                                insertCommand.Parameters.AddWithValue("@CariUnvani", cariUnvani);
                                insertCommand.Parameters.AddWithValue("@FaturaNo", faturaNo);
                                insertCommand.Parameters.AddWithValue("@Plaka", plaka);
                                insertCommand.Parameters.AddWithValue("@StokAciklamasi", stokAciklamasi);
                                insertCommand.Parameters.AddWithValue("@FaturaToplam", faturaToplam);
                                insertCommand.Parameters.AddWithValue("@SoforAdi", soforAdi);

                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    progressBar.Value = i;
                    Application.DoEvents();

                   
                }
            }

            xlWorkbook.Close();
            xlApp.Quit();
            progressBar.Visible = false;
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);
            Marshal.ReleaseComObject(xlWorkbook);
            Marshal.ReleaseComObject(xlApp);

            Alert("Veriler başarıyla SQL tablosuna aktarıldı.", Form_Alert.enmType.Success);
            LoadData();
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        private void exceldenyukle_Click(object sender, EventArgs e)
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

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            ApplyFilters();

        }
        private void Sifirla()
        {
            // Tarih filtrelerini sıfırla
            dateTimePickerStart.Value = DateTime.Today;
            dateTimePickerEnd.Value = DateTime.Today;

            // Diğer filtreleme seçeneklerini sıfırla
            txtBelgeNo.Clear();
            cmbCariKod.SelectedIndex = -1;
            cmbCariUnvan.SelectedIndex = -1;
            txtPlaka.Clear();
            txtFaturaNo.Clear();

            // DataGridView'i güncelle
            LoadData();
        }

        private void resetle_Click(object sender, EventArgs e)
        {
            Sifirla();
        }

        private void nakliyegelirleri_Shown(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnRaporOlustur_Click(object sender, EventArgs e)
        {
            // Seçilen şoför adını al
            string selectedSofor = cmbSoforAdi.Text;

            // Tarih aralığını al
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;

            // Raporları oluşturmak için metodları çağır
            DataTable driverReportData = GenerateDriverReport(selectedSofor, startDate, endDate);
            DataTable cariKoduReportData = GenerateCariKoduReport(selectedSofor, startDate, endDate);

            // Rapor ekranını aç ve verileri gönder
            RaporEkrani raporEkran = new RaporEkrani();
            raporEkran.SetDriverReportData(driverReportData);
            raporEkran.SetCariKoduReportData(cariKoduReportData);
            raporEkran.Show();
        }

        private DataTable GenerateDriverReport(string selectedSofor, DateTime startDate, DateTime endDate)
        {
            string query = "SELECT Plaka, SUM(FaturaToplam) AS ToplamFaturaToplam " +
                           "FROM nakliyetablosu " +
                           "WHERE SoforAdi = @SoforAdi AND Tarih BETWEEN @StartDate AND @EndDate " +
                           "GROUP BY Plaka";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@SoforAdi", selectedSofor);
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        return dt;
                    }
                }
            }
        }

        private DataTable GenerateCariKoduReport(string selectedSofor,DateTime startDate, DateTime endDate)
        {
            string query = "SELECT CariKodu, SUM(FaturaToplam) AS ToplamFaturaToplam " +
                           "FROM nakliyetablosu " +
                           "WHERE SoforAdi = @SoforAdi AND Tarih BETWEEN @StartDate AND @EndDate " +
                           "GROUP BY CariKodu";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@SoforAdi", selectedSofor);
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        return dt;
                    }
                }
            }
        }

    }
}


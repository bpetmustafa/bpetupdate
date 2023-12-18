using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace BPET_PORTAL.butce_sistemi.bayi_sistemi
{
    public partial class bayianaekran : Form
    {
        private mainpage mainForm;
        private string connectionString = "Server=95.0.50.22,1382;Database=butce;User ID=sa;Password=Mustafa1;";

        public bayianaekran(string eposta, mainpage mainForm)
        {
            InitializeComponent();
            epostalabel.Text = eposta;
            this.mainForm = mainForm;
        }

        private void exceldenVeriAktar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Dosyaları|*.xlsx;*.xls",
                Title = "Excel Dosyası Seçin"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                ImportDataFromExcel(filePath);
            }
        }
        private void YenileBayiListesi(List<string> durumlar, List<string> kategoriler)
        {
            string durumFilter = durumlar.Count > 0 ? "Durumu IN ('" + string.Join("','", durumlar) + "')" : "1=1";
            string kategoriFilter = kategoriler.Count > 0 ? "Kategori IN ('" + string.Join("','", kategoriler) + "')" : "1=1";

            string query = $"SELECT * FROM bayi WHERE {durumFilter} AND {kategoriFilter}";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                var dataTable = new DataTable();
                using (var adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                    datagridViewBayiler.DataSource = dataTable;
                }
            } // using blokları bağlantıyı ve komutları otomatik olarak kapatacaktır
        }
        private void ImportDataFromExcel(string filePath)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(filePath);
            Excel._Worksheet excelWorksheet = excelWorkbook.Sheets[1];
            Excel.Range excelRange = excelWorksheet.UsedRange;

            int rowCount = excelRange.Rows.Count;
            int colCount = excelRange.Columns.Count;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                for (int i = 2; i <= rowCount; i++) // Excel'de başlıkları atlıyoruz, bu yüzden i = 2'den başlıyoruz.
                {
                    string bayiKodu = excelRange.Cells[i, 3]?.Value2?.ToString(); // 3. Sütun BayiKodu
                    string firmaAdi = excelRange.Cells[i, 6]?.Value2?.ToString(); // 6. Sütun FirmaAdi
                    string bolgeSahaMuduru = excelRange.Cells[i, 32]?.Value2?.ToString(); // 32. Sütun Bolge/SahaMuduru

                    if (!string.IsNullOrEmpty(bayiKodu) && !string.IsNullOrEmpty(firmaAdi) && !string.IsNullOrEmpty(bolgeSahaMuduru)) // Tüm değerler boş değilse
                    {
                        string queryCheck = "SELECT COUNT(*) FROM bayi WHERE BayiKodu = @BayiKodu";
                        SqlCommand commandCheck = new SqlCommand(queryCheck, connection);
                        commandCheck.Parameters.AddWithValue("@BayiKodu", bayiKodu);
                        int exists = (int)commandCheck.ExecuteScalar();

                        if (exists == 0) // Eğer veritabanında yoksa ekle
                        {
                            string query = "INSERT INTO bayi (BayiKodu, FirmaAdi, BolgeSahaMuduru, Durumu) VALUES (@BayiKodu, @FirmaAdi, @BolgeSahaMuduru, 'AKTİF')";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@BayiKodu", bayiKodu);
                                command.Parameters.AddWithValue("@FirmaAdi", firmaAdi);
                                command.Parameters.AddWithValue("@BolgeSahaMuduru", bolgeSahaMuduru);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }

                connection.Close();
            }

            // Excel uygulamasını kapat
            excelWorkbook.Close(false);
            excelApp.Quit();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorkbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            MessageBox.Show("Veriler başarıyla aktarıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ImportDataFromExceliptal(string filePath)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(filePath);
            Excel._Worksheet excelWorksheet = excelWorkbook.Sheets[1];
            Excel.Range excelRange = excelWorksheet.UsedRange;

            int rowCount = excelRange.Rows.Count;
            int colCount = excelRange.Columns.Count;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                for (int i = 2; i <= rowCount; i++) // Excel'de başlıkları atlıyoruz, bu yüzden i = 2'den başlıyoruz.
                {
                    string bayiKodu = excelRange.Cells[i, 2]?.Value2?.ToString(); // 3. Sütun BayiKodu
                    string firmaAdi = excelRange.Cells[i, 5]?.Value2?.ToString(); // 6. Sütun FirmaAdi
                    string bolgeSahaMuduru = excelRange.Cells[i, 31]?.Value2?.ToString(); // 32. Sütun Bolge/SahaMuduru

                    if (!string.IsNullOrEmpty(bayiKodu) && !string.IsNullOrEmpty(firmaAdi) && !string.IsNullOrEmpty(bolgeSahaMuduru)) // Tüm değerler boş değilse
                    {
                        string queryCheck = "SELECT COUNT(*) FROM bayi WHERE BayiKodu = @BayiKodu";
                        SqlCommand commandCheck = new SqlCommand(queryCheck, connection);
                        commandCheck.Parameters.AddWithValue("@BayiKodu", bayiKodu);
                        int exists = (int)commandCheck.ExecuteScalar();

                        if (exists == 0) // Eğer veritabanında yoksa ekle
                        {
                            string query = "INSERT INTO bayi (BayiKodu, FirmaAdi, BolgeSahaMuduru, Durumu) VALUES (@BayiKodu, @FirmaAdi, @BolgeSahaMuduru, 'İPTAL')";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@BayiKodu", bayiKodu);
                                command.Parameters.AddWithValue("@FirmaAdi", firmaAdi);
                                command.Parameters.AddWithValue("@BolgeSahaMuduru", bolgeSahaMuduru);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }

                connection.Close();
            }

            // Excel uygulamasını kapat
            excelWorkbook.Close(false);
            excelApp.Quit();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorkbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            MessageBox.Show("Veriler başarıyla aktarıldı. iptal bayiler", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bayianaekran_Load(object sender, EventArgs e)
        {
            YenileBayiListesi(new List<string> { "AKTİF" }, new List<string> { "AKARYAKIT" });
        }

        private void checkBoxDurum_CheckedChanged(object sender, EventArgs e)
        {
            List<string> durumlar = new List<string>();
            if (checkBoxAktifBayiler.Checked)
            {
                durumlar.Add("AKTİF");
            }
            if (checkBoxIptalBayiler.Checked)
            {
                durumlar.Add("İPTAL");
            }
            List<string> kategoriler = new List<string>();
            if (checkBoxAkaryakit.Checked)
            {
                kategoriler.Add("AKARYAKIT");
            }
            if (checkBoxLPG.Checked)
            {
                kategoriler.Add("LPG");
            }
            YenileBayiListesi(durumlar, kategoriler);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Dosyaları|*.xlsx;*.xls",
                Title = "Excel Dosyası Seçin"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                ImportDataFromExceliptal(filePath);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Dosyaları|*.xlsx;*.xls",
                Title = "Excel Dosyası Seçin"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                ImportDataFromExcellpg(filePath);
            }
        }
        private void ImportDataFromExcellpg(string filePath)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(filePath);
            Excel._Worksheet excelWorksheet = excelWorkbook.Sheets[1];
            Excel.Range excelRange = excelWorksheet.UsedRange;

            int rowCount = excelRange.Rows.Count;
            int colCount = excelRange.Columns.Count;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                for (int i = 2; i <= rowCount; i++) // Excel'de başlıkları atlıyoruz, bu yüzden i = 2'den başlıyoruz.
                {
                    string bayiKodu = excelRange.Cells[i, 4]?.Value2?.ToString(); // 3. Sütun BayiKodu
                    string firmaAdi = excelRange.Cells[i, 7]?.Value2?.ToString(); // 6. Sütun FirmaAdi
                    string bolgeSahaMuduru = excelRange.Cells[i, 27]?.Value2?.ToString(); // 32. Sütun Bolge/SahaMuduru

                    if (!string.IsNullOrEmpty(bayiKodu) && !string.IsNullOrEmpty(firmaAdi) && !string.IsNullOrEmpty(bolgeSahaMuduru)) // Tüm değerler boş değilse
                    {
                        string queryCheck = "SELECT COUNT(*) FROM bayi WHERE BayiKodu = @BayiKodu";
                        SqlCommand commandCheck = new SqlCommand(queryCheck, connection);
                        commandCheck.Parameters.AddWithValue("@BayiKodu", bayiKodu);
                        int exists = (int)commandCheck.ExecuteScalar();

                        if (exists == 0) // Eğer veritabanında yoksa ekle
                        {
                            string query = "INSERT INTO bayi (BayiKodu, FirmaAdi, BolgeSahaMuduru, Durumu, Kategori) VALUES (@BayiKodu, @FirmaAdi, @BolgeSahaMuduru, 'AKTİF', 'LPG')";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@BayiKodu", bayiKodu);
                                command.Parameters.AddWithValue("@FirmaAdi", firmaAdi);
                                command.Parameters.AddWithValue("@BolgeSahaMuduru", bolgeSahaMuduru);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }

                connection.Close();
            }

            // Excel uygulamasını kapat
            excelWorkbook.Close(false);
            excelApp.Quit();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorkbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            MessageBox.Show("Veriler başarıyla aktarıldı. lpg aktif", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dosya_bul_Click(object sender, EventArgs e)
        {
            mainForm.loadform(new butceanaekran(epostalabel.Text, mainForm));

        }
    }
}

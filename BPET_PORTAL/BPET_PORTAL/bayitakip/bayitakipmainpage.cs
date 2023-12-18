using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace BPET_PORTAL.bayitakip
{
    public partial class bayitakipmainpage : Form
    {
        public bayitakipmainpage(string eposta)
        {
            InitializeComponent();
            epostalabel.Text = eposta;
            FillBolgeMuduruComboBox();
        }
        private void FillBolgeMuduruComboBox()
        {
            string connectionString = "Server=95.0.50.22,1382;Database=BPET_PORTAL;User ID=sa;Password=Mustafa1;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT DISTINCT BolgeMuduru FROM CariHesaplar";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string bolgeMuduru = reader["BolgeMuduru"].ToString();
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

                string query = "SELECT CariHesapKodu, CariHesapUnvani, Sehir, BolgeKodu, BolgeAdi, BolgeMuduru, SonSatisTarihi, SonSatisMiktari, SonTahsilatTarihi, SonSatisGunSayisi, SonTahsilatGunSayisi FROM CariHesaplar WHERE (SonSatisGunSayisi >= @MinimumSonSatisGunSayisi AND SonTahsilatGunSayisi >= @MinimumSonTahsilatGunSayisi)";

                if (!string.IsNullOrEmpty(selectedBolgeMuduru))
                {
                    query += " AND BolgeMuduru = @SelectedBolgeMuduru";
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
                }
            }
        }
        private void resetFiltersButton_Click(object sender, EventArgs e)
        {
            // NumericUpdown'ları sıfırla
            numericUpDown.Value = numericUpDown.Minimum;
            numericUpDown1.Value = numericUpDown1.Minimum;

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
                        // Hatalı tarih değeri, bu durumu işleyebilir veya rapor edebilirsiniz.
                        continue; // Hata olduğunda bu veriyi atlayın
                    }

                    if (decimal.TryParse(xlRange.Cells[i, 11].Text, out sonSatisMiktari))
                    {
                        // Başarıyla sayısal değer çözümlendi
                    }
                    else
                    {
                        // Hatalı sayısal değer, bu durumu işleyebilir veya rapor edebilirsiniz.
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
                        // Hatalı tarih değeri, bu durumu işleyebilir veya rapor edebilirsiniz.
                        continue; // Hata olduğunda bu veriyi atlayın
                    }

                    if (int.TryParse(xlRange.Cells[i, 13].Text, out sonSatisGunSayisi))
                    {
                        // Başarıyla sayısal değer çözümlendi
                    }
                    else
                    {
                        // Hatalı sayısal değer, bu durumu işleyebilir veya rapor edebilirsiniz.
                        continue; // Hata olduğunda bu veriyi atlayın
                    }

                    if (int.TryParse(xlRange.Cells[i, 14].Text, out sonTahsilatGunSayisi))
                    {
                        // Başarıyla sayısal değer çözümlendi
                    }
                    else
                    {
                        // Hatalı sayısal değer, bu durumu işleyebilir veya rapor edebilirsiniz.
                        continue; // Hata olduğunda bu veriyi atlayın
                    }

                    string checkQuery = "SELECT COUNT(*) FROM CariHesaplar WHERE CariHesapUnvani = @CariHesapUnvani";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@CariHesapUnvani", cariHesapUnvani);
                        int existingRecords = (int)checkCommand.ExecuteScalar();

                        if (existingRecords > 0)
                        {
                            string updateQuery = "UPDATE CariHesaplar " +
                                                "SET Sehir = @Sehir, BolgeKodu = @BolgeKodu, BolgeAdi = @BolgeAdi, " +
                                                "BolgeMuduru = @BolgeMuduru, SahaKodu = @SahaKodu, SahaAdi = @SahaAdi, " +
                                                "SahaMuduru = @SahaMuduru, SonSatisTarihi = @SonSatisTarihi, " +
                                                "SonSatisMiktari = @SonSatisMiktari, SonTahsilatTarihi = @SonTahsilatTarihi, " +
                                                "SonSatisGunSayisi = @SonSatisGunSayisi, SonTahsilatGunSayisi = @SonTahsilatGunSayisi " +
                                                "WHERE CariHesapUnvani = @CariHesapUnvani";

                            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@CariHesapUnvani", cariHesapUnvani);
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
                            string insertQuery = "INSERT INTO CariHesaplar (CariHesapKodu, CariHesapUnvani, Sehir, BolgeKodu, BolgeAdi, BolgeMuduru, SahaKodu, SahaAdi, SahaMuduru, SonSatisTarihi, SonSatisMiktari, SonTahsilatTarihi, SonSatisGunSayisi, SonTahsilatGunSayisi) " +
                                                "VALUES (@CariHesapKodu, @CariHesapUnvani, @Sehir, @BolgeKodu, @BolgeAdi, @BolgeMuduru, @SahaKodu, @SahaAdi, @SahaMuduru, @SonSatisTarihi, @SonSatisMiktari, @SonTahsilatTarihi, @SonSatisGunSayisi, @SonTahsilatGunSayisi)";

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

                    if (i % 10 == 0)
                    {
                        if (MessageBox.Show("İşlemi durdurmak istiyor musunuz?", "Dikkat", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            break; // Kullanıcı işlemi iptal etti
                        }
                    }
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
    }
}

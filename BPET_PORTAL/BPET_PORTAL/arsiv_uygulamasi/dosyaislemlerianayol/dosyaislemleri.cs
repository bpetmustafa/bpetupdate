using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Data.SqlClient;
using BPET_PORTAL.arsiv_uygulamasi.dosyaislemleri;
using System.Drawing;
using ZXing;
using ZXing.Common;
using System.Drawing.Printing;
using System.Collections.Generic;
using BPET_PORTAL.arsiv_uygulamasi.dosyaislemlerianayol;

namespace BPET_PORTAL.arsiv_uygulamasi
{
    public partial class dosyaislemleri2 : Form
    {
        private mainpage mainForm;
        private const string connectionString = "Server=95.0.50.22,1382;Database=bpetarsiv;User ID=sa;Password=Mustafa1;";
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private int currentPage = 0;
        private bool isSearching = false;
        private List<string> selectedDosyaIDs = new List<string>(); // Seçilen dosya ID'lerini saklamak için bir liste
        private bool isPrinting = false; // Yazdırma işlemi kontrolü
        private DataTable customFilterDataTable = new DataTable();
        private List<string> dosyaIDs = new List<string>();
        private Dictionary<string, CheckBox> checkBoxMap = new Dictionary<string, CheckBox>();

        public dosyaislemleri2(string eposta, mainpage mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            epostalabel.Text = eposta;
            connection = new SqlConnection(connectionString);

            GetDataFromDatabase();
            FillComboBoxes();
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            mainForm.loadform(new arsivmainpage(epostalabel.Text, mainForm));

        }

        private void GetDataFromDatabase()
        {
            // Seçili satır varsa indeksini ve kaydırma pozisyonunu kaydet
            int selectedRowIndex = -1;
            int scrollPosition = -1;
            if (dataGridView.SelectedRows.Count > 0)
            {
                selectedRowIndex = dataGridView.SelectedRows[0].Index;
                scrollPosition = dataGridView.FirstDisplayedScrollingRowIndex;
            }

            try
            {
                connection.Open();
                // Verileri çekmek için SQL sorgusu
                string query = "SELECT TOP 25 * FROM Dosyalar";

                dataAdapter = new SqlDataAdapter(query, connection);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // DataGridView'e verileri yükle
                dataGridView.DataSource = dataTable;

                // Veriler yenilendikten sonra seçili satırı ve kaydırma pozisyonunu geri yükle, eğer varsa
                if (selectedRowIndex >= 0 && selectedRowIndex < dataGridView.RowCount)
                {
                    dataGridView.ClearSelection();
                    dataGridView.Rows[selectedRowIndex].Selected = true;
                    if (scrollPosition >= 0 && scrollPosition < dataGridView.RowCount)
                    {
                        dataGridView.FirstDisplayedScrollingRowIndex = scrollPosition;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler alınırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close(); // Bağlantıyı kapat
            }
        }

        private void excelyukle_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Dosyaları|*.xlsx;*.xls";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string dosyaYolu = openFileDialog.FileName;

                // Excel dosyasını oku
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Open(dosyaYolu);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1]; // İlk sayfa

                // Başlık satırını atla (B1'den başlıyoruz)
                int row = 2;

                // İlerleme çubuğunu tanımla
                progressBar.Maximum = worksheet.UsedRange.Rows.Count - 1;
                progressBar.Value = 0;
                progressBar.Visible = true;

                while (!string.IsNullOrEmpty(Convert.ToString(worksheet.Cells[row, 2].Value2))) // B sütununda veri olana kadar devam et
                {
                    string dosyaAdi = Convert.ToString(worksheet.Cells[row, 2].Value2);
                    string ay = Convert.ToString(worksheet.Cells[row, 3].Value2);
                    string yil = Convert.ToString(worksheet.Cells[row, 4].Value2);
                    string birimAdi = Convert.ToString(worksheet.Cells[row, 5].Value2);
                    string sirketAdi = Convert.ToString(worksheet.Cells[row, 6].Value2);
                    string dolap = Convert.ToString(worksheet.Cells[row, 7].Value2);
                    string raf = Convert.ToString(worksheet.Cells[row, 8].Value2);
                    string siraNo = Convert.ToString(worksheet.Cells[row, 9].Value2);
                    string odaAdi = Convert.ToString(worksheet.Cells[row, 10].Value2);
                    string dosyaID = !string.IsNullOrEmpty(Convert.ToString(worksheet.Cells[row, 11].Value2)) ? Convert.ToString(worksheet.Cells[row, 11].Value2) : Guid.NewGuid().ToString();

                    // Eğer dosyaID veritabanında yoksa veriyi ekle
                    if (!CheckIfDataExists(dosyaID))
                    {
                        // Veritabanına ekleme işlemi
                        AddDataToDatabase(dosyaAdi, ay, yil, birimAdi, sirketAdi, dolap, raf, siraNo, odaAdi, dosyaID);

                        // İlerleme çubuğunu güncelle
                        progressBar.Value++;
                        Application.DoEvents();
                    }

                    row++;
                }

                // İlerleme çubuğunu sıfırla ve gizle
                progressBar.Value = 0;
                progressBar.Visible = false;

                // Excel nesnelerini temizle
                workbook.Close();
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                this.Alert("EXCEL'den veriler başarıyla aktarıldı!", Form_Alert.enmType.Success);
                RefreshDataGridView();
            }
        }

        private bool CheckIfDataExists(string dosyaID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Dosyalar WHERE FizikselYer = @DosyaID", conn);
                checkCmd.Parameters.AddWithValue("@DosyaID", dosyaID);
                int existingCount = (int)checkCmd.ExecuteScalar();
                return existingCount > 0;
            }
        }

        private void AddDataToDatabase(string dosyaAdi, string ay, string yil, string birimAdi, string sirketAdi, string dolap, string raf, string siraNo, string odaAdi, string dosyaID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Dosyalar (DosyaAdi, Kategori, FizikselYer, SirketIsmi, DosyaYili, DosyaAy, DosyaNumarasi, DosyaTipi, DosyaYukleyen, OlusturmaTarihi, DosyaID, Dolap, Raf, SıraNo, OdaAdi) VALUES (@DosyaAdi, @Kategori, @FizikselYer, @SirketIsmi, @DosyaYili, @DosyaAy, @DosyaNumarasi, @DosyaTipi, @DosyaYukleyen, @OlusturmaTarihi, @DosyaID, @Dolap, @Raf, @SıraNo, @OdaAdi)", conn);
                cmd.Parameters.AddWithValue("@DosyaAdi", dosyaAdi);
                cmd.Parameters.AddWithValue("@Kategori", birimAdi);
                cmd.Parameters.AddWithValue("@FizikselYer", dosyaID);
                cmd.Parameters.AddWithValue("@SirketIsmi", sirketAdi);
                cmd.Parameters.AddWithValue("@DosyaYili", Convert.ToInt32(yil));
                cmd.Parameters.AddWithValue("@DosyaAy", ay);
                cmd.Parameters.AddWithValue("@DosyaNumarasi", "");
                cmd.Parameters.AddWithValue("@DosyaTipi", "");
                cmd.Parameters.AddWithValue("@DosyaYukleyen", epostalabel.Text); // Kullanıcı adını buraya ekleyin
                cmd.Parameters.AddWithValue("@OlusturmaTarihi", DateTime.Now);
                cmd.Parameters.AddWithValue("@DosyaID", dosyaID);
                cmd.Parameters.AddWithValue("@Dolap", dolap);
                cmd.Parameters.AddWithValue("@Raf", raf);
                cmd.Parameters.AddWithValue("@SıraNo", siraNo);
                cmd.Parameters.AddWithValue("@OdaAdi", odaAdi);
                cmd.ExecuteNonQuery();
            }
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.B))
            {
                barkodolustur();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void barkodolustur()
        {
            string dosyaID = dataGridView.SelectedRows[0].Cells["FizikselYer"].Value.ToString();

            // Seçilen dosya ID'sini listeye ekleyin
            selectedDosyaIDs.Add(dosyaID);
            this.Alert("BARKOD SİSTEMİ: Dosya Eklendi " + dosyaID, Form_Alert.enmType.Info);

            // İki dosya ID'si seçildiyse ve sayfa sayacı sıfırsa yazdırmaya başlayın
            if (selectedDosyaIDs.Count == 2 && currentPage == 0)
            {
                // Code128 barkodu oluşturun
                BarcodeWriter barcodeWriter = new BarcodeWriter();
                barcodeWriter.Format = BarcodeFormat.CODE_128;
                barcodeWriter.Options = new EncodingOptions
                {
                    Width = 190, // Barkodun genişliği (örnek: 40mm)
                    Height = 100, // Barkodun yüksekliği (örnek: 10mm)
                    Margin = 5 // Kenar boşluğu (0 olarak ayarlayın)
                };

                // İlk dosya ID'si için barkodu oluşturun
                Bitmap barcodeBitmap1 = barcodeWriter.Write(selectedDosyaIDs[0]);
                // İkinci dosya ID'si için barkodu oluşturun
                Bitmap barcodeBitmap2 = barcodeWriter.Write(selectedDosyaIDs[1]);

                // Yazdırma işlemini gerçekleştirin

                PrintDocument pd = new PrintDocument();
                pd.DefaultPageSettings.PaperSize = new PaperSize("Custom", 800, 400);
                pd.PrinterSettings.PrinterName = "Argox OS-214 Plus"; // Yazıcı adı, gerçek yazıcı adı ile değiştirilmelidir

                // Tek sayfa ekleyin: İki barkod yan yana

                pd.PrintPage += (senderObj, eArgs) =>
                {
                    // Barkodların genişliği ve yüksekliği
                    int barcodeWidth = 175;
                    int barcodeHeight = 100;

                    // Sayfanın genişliği ve yüksekliği
                    int pageWidth = eArgs.PageBounds.Width;
                    int pageHeight = eArgs.PageBounds.Height;

                    // Barkodların yatay olarak ortalanacağı pozisyon
                    int x1 = (pageWidth - (2 * barcodeWidth)) / 2;

                    // İlk barkodu yazdır
                    eArgs.Graphics.DrawImage(barcodeBitmap1, new Rectangle(x1, 20, barcodeWidth, barcodeHeight));

                    // İkinci barkodu yazdır
                    eArgs.Graphics.DrawImage(barcodeBitmap2, new Rectangle(x1 + barcodeWidth, 20, barcodeWidth, barcodeHeight));

                    // Dosya ID'lerini yazdır
                    UpdateBarkodValues(selectedDosyaIDs);


                    // Seçilen dosya ID'lerini temizleyin ve sayfa sayacını sıfırlayın
                    selectedDosyaIDs.Clear();
                    currentPage = 0;
                };
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = pd;
                pd.DefaultPageSettings.PaperSize = new PaperSize("Custom", 800, 400);

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    pd.Print();
                    this.Alert("BARKOD SİSTEMİ: Yazdırıldı!", Form_Alert.enmType.Success);
                    GetDataFromDatabasebarkod();
                    FilterDataInDatabase();
                    // Dosyaların Barkod değerlerini güncelle
                }
            }
        }
        private void dataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hitTestInfo = dataGridView.HitTest(e.X, e.Y);

                if (hitTestInfo.RowIndex >= 0)
                {
                    // Seçilen satırı güncelle
                    dataGridView.ClearSelection();
                    dataGridView.Rows[hitTestInfo.RowIndex].Selected = true;

                    ContextMenuStrip contextMenu = new ContextMenuStrip();

                    // Barkod Oluştur seçeneği
                    ToolStripMenuItem createBarcodeMenuItem = new ToolStripMenuItem("Barkod Oluştur");
                    createBarcodeMenuItem.ShortcutKeys = Keys.Control | Keys.K; // Ctrl + K
                    createBarcodeMenuItem.ShowShortcutKeys = true; // Bu satır, kısayolu görünür yapar
                    createBarcodeMenuItem.Click += (s, args) =>
                    {
                        barkodolustur();
                        // Eğer seçili hücre varsa
                       
                    };


                    // Düzenle seçeneği
                    ToolStripMenuItem editMenuItem = new ToolStripMenuItem("Düzenle");
                    editMenuItem.Click += (s, args) =>
                    {
                        // Kullanıcının mevcut konumunu kaydet
                        int selectedRowIndex = dataGridView.SelectedRows[0].Index;
                        int scrollPosition = dataGridView.FirstDisplayedScrollingRowIndex;

                        string dosyaID = dataGridView.SelectedRows[0].Cells["FizikselYer"].Value.ToString();
                        EditFile(dosyaID); // Dosyayı düzenle
                        this.Alert("GÜNCELLENDİ!", Form_Alert.enmType.Success);
                       //BURAYI SONRA DEVREYE AL
                       // RefreshDataGridView(); // Bu metodun içinde DataGridView'in veri kaynağını güncelleme işlemini yapmalısınız.

                        // Veriler yenilendikten sonra kullanıcının konumunu geri yükle
                        dataGridView.ClearSelection();
                        if (dataGridView.Rows.Count > selectedRowIndex) // Satır sayısı kontrolü
                        {
                            dataGridView.Rows[selectedRowIndex].Selected = true;
                            if (scrollPosition >= 0 && scrollPosition < dataGridView.RowCount)
                            {
                                dataGridView.FirstDisplayedScrollingRowIndex = scrollPosition;
                            }
                        }
                        // Eğer filtreleme işlemi de yapıyorsanız, bu işlemi de burada çağırabilirsiniz.
                        //FilterDataInDatabase();
                    };

                    // Barkodlandı seçeneği
                    ToolStripMenuItem barkodlandiMenuItem = new ToolStripMenuItem("Barkodlandı");
                    barkodlandiMenuItem.Click += (s, args) =>
                    {
                        string dosyaID = dataGridView.SelectedRows[0].Cells["FizikselYer"].Value.ToString();

                        // Dosya ID'sini kullanarak veritabanınızda bu dosyanın Barkod değerini 1 olarak güncelleyin
                        UpdateBarkodValue(dosyaID, 1);

                        this.Alert("BARKOD SİSTEMİ: Dosya Barkodlandı " + dosyaID, Form_Alert.enmType.Success);
                    };
                    // Sil seçeneği
                    ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Sil");
                    deleteMenuItem.Click += (s, args) =>
                    {
                        // Şifre girişi formunu oluştur
                        using (PasswordForm passwordForm = new PasswordForm())
                        {
                            DialogResult passwordResult = passwordForm.ShowDialog();

                            if (passwordResult == DialogResult.OK)
                            {
                                string dosyaID = dataGridView.SelectedRows[0].Cells["FizikselYer"].Value.ToString();

                                DialogResult result = MessageBox.Show("Bu dosyayı silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                if (result == DialogResult.Yes)
                                {
                                    SqlConnection conn = new SqlConnection(connectionString);
                                    conn.Open();
                                    SqlCommand cmd = new SqlCommand("DELETE FROM Dosyalar WHERE FizikselYer = @DosyaID", conn);
                                    cmd.Parameters.AddWithValue("@DosyaID", dosyaID);
                                    cmd.ExecuteNonQuery();
                                    conn.Close();

                                    dataGridView.Rows.Remove(dataGridView.SelectedRows[0]);

                                    this.Alert("Dosya başarıyla silindi!", Form_Alert.enmType.Success);
                                    RefreshDataGridView();
                                }
                            }
                        }
                    };

                    contextMenu.Items.Add(createBarcodeMenuItem); // Barkod Oluştur seçeneğini menüye ekleyin
                    contextMenu.Items.Add(editMenuItem);
                    contextMenu.Items.Add(deleteMenuItem);
                    contextMenu.Items.Add(barkodlandiMenuItem); // Barkodlandı seçeneğini menüye ekleyin


                    dataGridView.ContextMenuStrip = contextMenu;
                }

            }
        }
        private void UpdateBarkodValue(string dosyaID, int barkodValue)
        {
            try
            {
                // Veritabanı bağlantısını açın
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL sorgusunu hazırlayın
                    string query = "UPDATE Dosyalar SET Barkod = @BarkodValue WHERE FizikselYer = @DosyaID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Parametreleri ekleyin
                        command.Parameters.AddWithValue("@BarkodValue", barkodValue);
                        command.Parameters.AddWithValue("@DosyaID", dosyaID);

                        // Sorguyu çalıştırın
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Güncelleme başarılı

                        }
                        else
                        {
                            // Dosya ID bulunamadı veya güncelleme yapılamadı
                            MessageBox.Show("Barkod güncelleme başarısız oldu. Dosya ID bulunamadı veya başka bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata yakalama
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshDataGridView()
        {
            // DataGridView'in veri kaynağını yeniden al
            GetDataFromDatabase();
            // Filtreleri uygula
            FilterDataInDatabase();
            ApplyColumnVisibilitySettings();

        }
        private void ApplyColumnVisibilitySettings()
        {
            foreach (var checkBox in groupBox5.Controls.OfType<CheckBox>())
            {
                string columnName = checkBox.Tag.ToString(); // Tag'den sütun adını al
                if (dataGridView.Columns.Contains(columnName))
                {
                    dataGridView.Columns[columnName].Visible = checkBox.Checked; // Sütunun görünürlüğünü ayarla
                }
            }
        }

        private void EditFile(string dosyaID)
        {
            // Düzenleme formunu açmak için burada kod ekleyebilirsiniz
            // DosyaID'ye göre düzenleme işlemi yapabilirsiniz
            // Örnek: Düzenleme formunu açabilir veya veriyi düzenleyebilirsiniz
            EditForm editForm = new EditForm(dosyaID, connection);
            editForm.ShowDialog();
        }

        private void dosyaekle_Click(object sender, EventArgs e)
        {
            //mainForm.loadform(new DosyaEkle(epostalabel.Text, mainForm));
            DosyaEkle dosyaekleform = new DosyaEkle(epostalabel.Text, mainForm);
            dosyaekleform.Show();
        }

        private void exceleaktar_Click(object sender, EventArgs e)
        {
            // DataGridView verilerini bir DataTable'a dönüştürün
            DataTable dataTable = new DataTable();
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                dataTable.Columns.Add(column.HeaderText, column.ValueType);
            }

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                DataRow dataRow = dataTable.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dataRow[cell.ColumnIndex] = cell.Value;
                }
                dataTable.Rows.Add(dataRow);
            }

            // Kullanıcıya dosya kaydetme konumu ve adı seçtirin
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Dosyaları|*.xlsx";
            saveFileDialog.Title = "Excel Dosyasını Kaydet";
            saveFileDialog.FileName = "Veriler.xlsx"; // Varsayılan dosya adı

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Excel uygulamasını başlatın
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = false;

                // Yeni bir Excel çalışma kitabı oluşturun
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

                // Başlıkları ekleyin ve biçimlerini ayarlayın
                for (int i = 1; i <= dataTable.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = dataTable.Columns[i - 1].ColumnName;
                    worksheet.Cells[1, i].Font.Bold = true;
                    worksheet.Cells[1, i].EntireRow.AutoFit(); // Satır yüksekliğini otomatik ayarla
                }

                // DataTable verilerini Excel çalışma sayfasına aktarın
                for (int i = 1; i <= dataTable.Rows.Count; i++)
                {
                    for (int j = 1; j <= dataTable.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 1, j] = dataTable.Rows[i - 1][j - 1];
                        worksheet.Cells[i + 1, j].EntireRow.AutoFit(); // Satır yüksekliğini otomatik ayarla
                    }
                }

                // Excel dosyasını kaydedin (kullanıcının seçtiği ad ve konum)
                workbook.SaveAs(saveFileDialog.FileName);

                // Excel uygulamasını kapatın
                workbook.Close(false);
                excelApp.Quit();

                MessageBox.Show("Veriler Excel'e aktarıldı: " + saveFileDialog.FileName, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void GetDataFromDatabasebarkod()
        {
            try
            {
                connection.Open();

                // Verileri çekmek için SQL sorgusu (Barkod değeri 0 olanları filtrele)
                string query = "SELECT * FROM Dosyalar WHERE Barkod = 0 OR Barkod = 2";

                dataAdapter = new SqlDataAdapter(query, connection);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // DataGridView'e verileri yükle
                dataGridView.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler alınırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close(); // Bağlantıyı kapat
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetDataFromDatabasebarkod();
            FilterDataInDatabase();
        }
        private void UpdateBarkodValues(List<string> dosyaIDs)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                foreach (string dosyaID in dosyaIDs)
                {
                    // Her bir dosya ID için Barkod değerini güncelle
                    SqlCommand updateCmd = new SqlCommand("UPDATE Dosyalar SET Barkod = 1 WHERE FizikselYer = @DosyaID", conn);
                    updateCmd.Parameters.AddWithValue("@DosyaID", dosyaID);
                    updateCmd.ExecuteNonQuery();
                }

                conn.Close(); // Bağlantıyı burada kapatın
            }
        }

        private void hepsinigoster_Click(object sender, EventArgs e)
        {
            GetDataFromDatabase();
            FilterDataInDatabase();
        }
        private void FillComboBoxes()
        {
            try
            {
                connection.Open();

                // ComboboxYil için verileri veritabanından çek
                string yearQuery = "SELECT DISTINCT DosyaYili FROM Dosyalar";
                dataAdapter = new SqlDataAdapter(yearQuery, connection);
                DataTable yearTable = new DataTable();
                dataAdapter.Fill(yearTable);

                comboBoxYil.Items.Clear(); // Combobox içeriğini temizle
                foreach (DataRow row in yearTable.Rows)
                {
                    comboBoxYil.Items.Add(row["DosyaYili"].ToString());
                }

                // ComboboxAy için verileri veritabanından çek
                string monthQuery = "SELECT DISTINCT DosyaAy FROM Dosyalar";
                dataAdapter = new SqlDataAdapter(monthQuery, connection);
                DataTable monthTable = new DataTable();
                dataAdapter.Fill(monthTable);

                comboBoxAy.Items.Clear(); // Combobox içeriğini temizle
                foreach (DataRow row in monthTable.Rows)
                {
                    comboBoxAy.Items.Add(row["DosyaAy"].ToString());
                }

                // ComboboxSirketIsmi için verileri veritabanından çek (aynı işlem diğer Combobox'lar için de tekrarlanabilir)
                string companyQuery = "SELECT DISTINCT SirketIsmi FROM Dosyalar";
                dataAdapter = new SqlDataAdapter(companyQuery, connection);
                DataTable companyTable = new DataTable();
                dataAdapter.Fill(companyTable);

                comboBoxSirketIsmi.Items.Clear(); // Combobox içeriğini temizle
                foreach (DataRow row in companyTable.Rows)
                {
                    comboBoxSirketIsmi.Items.Add(row["SirketIsmi"].ToString());
                }

                // ComboboxKategori için verileri veritabanından çek (aynı işlem diğer Combobox'lar için de tekrarlanabilir)
                string categoryQuery = "SELECT DISTINCT Kategori FROM Dosyalar";
                dataAdapter = new SqlDataAdapter(categoryQuery, connection);
                DataTable categoryTable = new DataTable();
                dataAdapter.Fill(categoryTable);

                comboBoxKategori.Items.Clear(); // Combobox içeriğini temizle
                foreach (DataRow row in categoryTable.Rows)
                {
                    comboBoxKategori.Items.Add(row["Kategori"].ToString());
                }

                // ComboboxKategori için verileri veritabanından çek (aynı işlem diğer Combobox'lar için de tekrarlanabilir)
                string yukleyen = "SELECT DISTINCT DosyaYukleyen FROM Dosyalar";
                dataAdapter = new SqlDataAdapter(yukleyen, connection);
                DataTable yukleyenyable = new DataTable();
                dataAdapter.Fill(yukleyenyable);

                comboboxDosyaYukleyen.Items.Clear(); // Combobox içeriğini temizle
                foreach (DataRow row in yukleyenyable.Rows)
                {
                    comboboxDosyaYukleyen.Items.Add(row["DosyaYukleyen"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler alınırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
        private void FilterDataInDatabase()
        {
            try
            {
                connection.Open();

                string query = "SELECT * FROM Dosyalar WHERE 1=1"; // Başlangıç sorgusu

                if (comboBoxYil.SelectedIndex != -1 || comboBoxYil.Text.Length > 2)
                {
                    string selectedYear = comboBoxYil.Text.ToString();
                    query += " AND DosyaYili LIKE '%' + @DosyaYili + '%'"; // LIKE operatörü ile filtreleme
                }
                if (checkBoxBarkod.Checked)
                {
                    query += " AND (Barkod = 0 OR Barkod = 2)";
                }

                if (comboboxDosyaYukleyen.SelectedIndex != -1 || comboboxDosyaYukleyen.Text.Length > 2)
                {
                    string selectedyukleyen = comboboxDosyaYukleyen.Text.ToString();
                    query += " AND DosyaYukleyen LIKE '%' + @DosyaYukleyen + '%'";
                }
                if (comboBoxAy.SelectedIndex != -1 || comboBoxAy.Text.Length > 2)
                {
                    string selectedMonth = comboBoxAy.Text.ToString();
                    query += " AND DosyaAy LIKE '%' + @DosyaAy + '%'";
                }

                if (comboBoxSirketIsmi.SelectedIndex != -1 || comboBoxSirketIsmi.Text.Length > 2)
                {
                    string selectedCompany = comboBoxSirketIsmi.Text.ToString();
                    query += " AND SirketIsmi LIKE '%' + @SirketIsmi + '%'";
                }

                if (comboBoxKategori.SelectedIndex != -1 || comboBoxKategori.Text.Length > 2)
                {
                    string selectedCategory = comboBoxKategori.Text.ToString();
                    query += " AND Kategori LIKE '%' + @Kategori + '%'";
                }

                // TextBox'a girilen metni de sorguya dahil et
                string searchText = textBoxArama.Text;
                if (!string.IsNullOrEmpty(searchText))
                {
                    query += " AND (DosyaAdi LIKE @SearchText OR Kategori LIKE @SearchText OR FizikselYer LIKE @SearchText OR SirketIsmi LIKE @SearchText)";
                }

                dataAdapter = new SqlDataAdapter(query, connection);

                // Parametreleri ekleyin
                if (comboBoxYil.SelectedIndex != -1 || comboBoxYil.Text.Length > 2)
                {
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@DosyaYili", comboBoxYil.Text.ToString());
                }
                if (comboboxDosyaYukleyen.SelectedIndex != -1 || comboboxDosyaYukleyen.Text.Length > 2)
                {
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@DosyaYukleyen", comboboxDosyaYukleyen.Text.ToString());
                }
                if (comboBoxAy.SelectedIndex != -1 || comboBoxAy.Text.Length > 2)
                {
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@DosyaAy", comboBoxAy.Text.ToString());
                }
                if (comboBoxSirketIsmi.SelectedIndex != -1 || comboBoxSirketIsmi.Text.Length > 2)
                {
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@SirketIsmi", comboBoxSirketIsmi.Text.ToString());
                }
                if (comboBoxKategori.SelectedIndex != -1 || comboBoxKategori.Text.Length > 2)
                {
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@Kategori", comboBoxKategori.Text.ToString());
                }
                // TextBox'a girilen metni de parametre olarak ekleyin
                dataAdapter.SelectCommand.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGridView.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler alınırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void textBoxArama_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBoxArama.Text;
            if (searchText.ToLower().Contains("!sifirla!"))
            {
                textBoxArama.Text = string.Empty;
                searchText = string.Empty; // Arama metnini temizle
            }

        }


        private void comboBoxYil_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterDataInDatabase();
        }

        private void comboBoxAy_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterDataInDatabase();
        }

        private void comboBoxSirketIsmi_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterDataInDatabase();
        }
        private void comboBoxKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterDataInDatabase();
        }
        private void resetle_Click(object sender, EventArgs e)
        {
            textBoxArama.Text = "";

            comboBoxYil.SelectedIndex = -1;
            comboBoxAy.SelectedIndex = -1;
            comboBoxSirketIsmi.SelectedIndex = -1;
            comboBoxKategori.SelectedIndex = -1;
            comboboxDosyaYukleyen.SelectedIndex = -1;
            isSearching = false;
            checkBoxBarkod.CheckState = CheckState.Unchecked;
            GetDataFromDatabase();
        }

        private void dosyaislemleri2_Load(object sender, EventArgs e)
        {
            //LoadCheckBoxSettings();
            MapCheckBoxes();

            // Timer ile ayarları yükle
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            //bunu timer ile yapalım
            // CheckBox kontrollerine olay işleyicisini ekle
            foreach (var checkBox in groupBox5.Controls.OfType<CheckBox>())
            {
                checkBox.CheckedChanged += checkBox_CheckedChangedfiltre;
            }
        }
        private void MapCheckBoxes()
        {
            foreach (var checkBox in groupBox5.Controls.OfType<CheckBox>())
            {
                checkBoxMap[checkBox.Name] = checkBox;
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            LoadCheckBoxSettings();

            // Timer'ı durdur
            Timer timer = sender as Timer;
            timer.Stop();
        }
        private void LoadCheckBoxSettings()
        {
            string settings = Properties.Settings.Default.CheckBoxSettings;
            if (!string.IsNullOrEmpty(settings))
            {
                string[] checkBoxStates = settings.Split(';');
                foreach (string checkBoxState in checkBoxStates)
                {
                    string[] parts = checkBoxState.Split(':');
                    if (parts.Length == 2 && checkBoxMap.TryGetValue(parts[0], out var checkBox))
                    {
                        checkBox.Checked = bool.Parse(parts[1]);
                    }
                }
            }
        }
        private void SaveCheckBoxSettings()
        {
            // groupBox5 içindeki CheckBox kontrollerini bul ve durumlarını kaydet
            var checkBoxStates = groupBox5.Controls.OfType<CheckBox>()
                                                .Select(c => $"{c.Name}:{c.Checked}")
                                                .ToArray();
            Properties.Settings.Default.CheckBoxSettings = string.Join(";", checkBoxStates);
            Properties.Settings.Default.Save();
        }


        private void comboboxDosyaYukleyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterDataInDatabase();
        }

        private void checkBoxBarkod_CheckedChanged(object sender, EventArgs e)
        {
            FilterDataInDatabase();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FilterDataInDatabase();
        }
        private void checkBox_CheckedChangedfiltre(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                string columnName = checkBox.Tag.ToString(); // Tag'den sütun adını al
                dataGridView.Columns[columnName].Visible = checkBox.Checked; // Sütunun görünürlüğünü ayarla

                // Sütunlar güncellendikten sonra DataGridView'i yeniden boyutlandır
               // AdjustColumnWidths();
                SaveCheckBoxSettings();

            }
        }

        private void AdjustColumnWidths()
        {
            // Her bir sütunun ayarlanabilir genişliğini hesapla
            int fixedWidth = dataGridView.RowHeadersWidth + 2; // Satır başlıkları ve biraz padding
            int totalVisibleColumns = dataGridView.Columns.Cast<DataGridViewColumn>().Count(col => col.Visible);
            int adjustableWidth = dataGridView.Width - fixedWidth;

            if (totalVisibleColumns > 0)
            {
                int newColumnWidth = adjustableWidth / totalVisibleColumns;

                // Her bir görünür sütunun genişliğini ayarla
                foreach (DataGridViewColumn col in dataGridView.Columns)
                {
                    if (col.Visible)
                    {
                        col.Width = newColumnWidth;
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterDataInDatabase();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            FilterDataInDatabase();
        }

        private void comboBoxSirketIsmi_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            FilterDataInDatabase();
        }

        private void comboBoxAy_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            FilterDataInDatabase();
        }

        private void dosyaislemleri2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            // Ctrl + K tuş kombinasyonunu kontrol et
            if (e.Control && e.KeyCode == Keys.K)
            {
                
            }
        }
    }
}
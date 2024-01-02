using BPET_PORTAL.arsiv_uygulamasi;
using BPET_PORTAL.muhasebe.mutabakat.mutabakatislemleri;
using iTextSharp.text.pdf;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace BPET_PORTAL.muhasebe.mutabakat
{

    public partial class mutabakat : Form
    {
        private string connectionString = "Server=95.0.50.22,1382;Database=muhasebe;User ID=sa;Password=Mustafa1;";
        private mainpage mainForm;
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private System.Data.DataTable dataTable;
        public mutabakat(string eposta, mainpage mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            epostalabel.Text = eposta;

        }
        public class MuhasebeData
        {
            public int Id { get; set; }
            public string Ad { get; set; }
            public string VergiNo { get; set; }
            public decimal BorcBakiye { get; set; }
            public decimal AlacakBakiye { get; set; }
            public DateTime SonIslemTarihi { get; set; }

            public DateTime MutabakatTarihi { get; set; }
        }
        private void btnPdfOlustur_Click(object sender, EventArgs e)
        {
            var selectedData = GetSelectedRowData();
            if (selectedData != null)
            {
                // Önce pdfolustu alanını kontrol et
                if (CheckIfPdfCreated(selectedData.Id))
                {
                    // Eğer PDF zaten oluşturulmuşsa kullanıcıya sor
                    var result = MessageBox.Show("Bu PDF daha önce oluşturulmuş. Tekrar oluşturmak ister misiniz?",
                                                 "PDF Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        CreatePdfFromTemplate(selectedData);
                        MarkPdfAsCreated(selectedData.Id);

                    }
                }
                else
                {
                    // PDF daha önce oluşturulmamışsa, doğrudan oluştur
                    MarkPdfAsCreated(selectedData.Id);
                    CreatePdfFromTemplate(selectedData);
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçiniz.");
            }
        }
        private bool CheckIfPdfCreated(int id)
        {
            string queryCheck = "SELECT pdfolustu FROM mutabakat WHERE id = @Id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(queryCheck, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    var result = cmd.ExecuteScalar();
                    return result != DBNull.Value && Convert.ToInt32(result) == 1;
                }
            }
        }

        private void MarkPdfAsCreated(int id)
        {
            string queryUpdate = "UPDATE mutabakat SET pdfolustu = 1 WHERE id = @Id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(queryUpdate, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private MuhasebeData GetSelectedRowData()
        {
            if (datagridViewMutabakat.SelectedRows.Count == 0)
            {
                return null;
            }

            var row = datagridViewMutabakat.SelectedRows[0];
            return new MuhasebeData
            {
                Id = Convert.ToInt32(row.Cells["id"].Value), // Bu satırı ekleyin
                Ad = Convert.ToString(row.Cells["adi"].Value),
                VergiNo = Convert.ToString(row.Cells["vergino"].Value),
                BorcBakiye = Convert.ToDecimal(row.Cells["borcbakiye"].Value),
                AlacakBakiye = Convert.ToDecimal(row.Cells["alacakbakiye"].Value),
                SonIslemTarihi = Convert.ToDateTime(row.Cells["sonislemtarihi"].Value),
                MutabakatTarihi = Convert.ToDateTime(row.Cells["mutabakattarihi"].Value)
            };
        }

        public void CreatePdfFromTemplate(MuhasebeData selectedRowData)
        {
            byte[] pdfTemplate = Properties.Resources.sablon;
            byte[] fontBytes = Properties.Resources.arial; // Arial fontunun byte dizisi


            string newPdfPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MutabakatForm.pdf"); // Yeni PDF'in yolu

            string fontPath = Path.GetTempFileName() + ".ttf"; // Her seferinde benzersiz bir dosya adı üret
            File.WriteAllBytes(fontPath, fontBytes);

            // Şimdi font dosyasını kullanarak BaseFont oluştur
            BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            using (PdfReader reader = new PdfReader(pdfTemplate))
            using (FileStream output = new FileStream(newPdfPath, FileMode.Create))
            using (PdfStamper stamper = new PdfStamper(reader, output))
            {
                AcroFields fields = stamper.AcroFields;
                fields.AddSubstitutionFont(baseFont); // Burada fontumuzu form alanlarına ekliyoruz.

                fields.SetField("adivergino", selectedRowData.Ad + " " + selectedRowData.VergiNo);
                //fields.SetField("vergino", selectedRowData.VergiNo);
                fields.SetField("borcbakiye", selectedRowData.BorcBakiye.ToString("N2") + " ₺");
                fields.SetField("alacakbakiye", selectedRowData.AlacakBakiye.ToString("N2") + " ₺");
                fields.SetField("sonislemtarihi", selectedRowData.SonIslemTarihi.ToString("dd.MM.yyyy"));
                fields.SetField("mutabakattarihi", selectedRowData.MutabakatTarihi.ToString("dd.MM.yyyy"));
                fields.SetField("dosyatarih", dateTimePicker1.Value.ToString("dd.MM.yyyy"));

                foreach (var fieldName in fields.Fields.Keys)
                {
                    // Alanın konumunu al
                    var fieldPositions = fields.GetFieldPositions(fieldName);
                    foreach (var fieldPosition in fieldPositions)
                    {
                        // Hizalamayı ortala
                        fields.SetFieldProperty(fieldName, "quadding", PdfFormField.Q_CENTER, null);
                    }
                }
                stamper.FormFlattening = true;
            }

            Process.Start(newPdfPath);
        }
        private void SearchData(string searchTerm)
        {
            // Yeni bir DataTable oluştur
            System.Data.DataTable searchTable = new System.Data.DataTable();
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    // Veritabanı bağlantısını aç
                    connection.Open();
                    // LIKE operatörü kullanarak arama yapacak sorguyu hazırla
                    string query = "SELECT id, adi, vergino, sonislemtarihi, borcbakiye, alacakbakiye, mutabakattarihi FROM mutabakat WHERE adi LIKE @SearchTerm";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Arama terimini parametre olarak ekle
                        command.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                        // Sorguyu çalıştır ve sonuçları DataTable'a doldur
                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                        {
                            dataAdapter.Fill(searchTable);
                        }
                    }
                }
                // DataGridView'in DataSource'unu arama sonuçları ile güncelle
                datagridViewMutabakat.DataSource = searchTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Arama sırasında bir hata meydana geldi: " + ex.Message);
            }
        }
        private void GetDataFromDatabase()
        {
            int selectedRowIndex = -1;
            int scrollPosition = -1;
            if (datagridViewMutabakat.SelectedRows.Count > 0)
            {
                selectedRowIndex = datagridViewMutabakat.SelectedRows[0].Index;
                scrollPosition = datagridViewMutabakat.FirstDisplayedScrollingRowIndex;
            }

            dataTable = new System.Data.DataTable();
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query;
                    if (checkBoxPdfOlusturuldu.Checked)
                    {
                        // CheckBox işaretliyse, sadece pdfolustu değeri 1 olan kayıtları getir ve ID'ye göre azalan sırayla sırala
                        query = "SELECT id, adi, vergino, sonislemtarihi, borcbakiye, alacakbakiye, mutabakattarihi FROM mutabakat WHERE pdfolustu = 1 ORDER BY id DESC";
                    }
                    else
                    {
                        // CheckBox işaretli değilse, tüm kayıtları getir ve ID'ye göre azalan sırayla sırala
                        query = "SELECT id, adi, vergino, sonislemtarihi, borcbakiye, alacakbakiye, mutabakattarihi FROM mutabakat WHERE pdfolustu IS NULL ORDER BY id DESC";
                    }

                    dataAdapter = new SqlDataAdapter(query, connection);
                    dataAdapter.Fill(dataTable);
                }

                datagridViewMutabakat.DataSource = dataTable;
                datagridViewMutabakat.Refresh();

                if (selectedRowIndex >= 0 && selectedRowIndex < datagridViewMutabakat.RowCount)
                {
                    datagridViewMutabakat.ClearSelection();
                    datagridViewMutabakat.Rows[selectedRowIndex].Selected = true;
                    if (scrollPosition >= 0 && scrollPosition < datagridViewMutabakat.RowCount)
                    {
                        datagridViewMutabakat.FirstDisplayedScrollingRowIndex = scrollPosition;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler alınırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImportDataFromExcel(string filePath)
        {
            Excel.Application excelApp = null;
            Excel.Workbook excelWorkbook = null;
            Excel._Worksheet excelWorksheet = null;
            Excel.Range excelRange = null;

            try
            {
                excelApp = new Excel.Application();
                excelWorkbook = excelApp.Workbooks.Open(filePath);
                excelWorksheet = excelWorkbook.Sheets[1];
                excelRange = excelWorksheet.UsedRange;

                int rowCount = excelRange.Rows.Count;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    for (int i = 2; i <= rowCount; i++)
                    {
                        object bayiadi = excelRange.Cells[i, 1]?.Text ?? DBNull.Value;
                        object vergino = excelRange.Cells[i, 2]?.Text ?? DBNull.Value;
                        object sonislemtarihi = excelRange.Cells[i, 3]?.Text ?? DBNull.Value;
                        object borcbakiye = excelRange.Cells[i, 4]?.Text ?? 0; // Boşsa 0 ata
                        object alacakbakiye = excelRange.Cells[i, 5]?.Text ?? 0; // Boşsa 0 ata
                        object mutabakattarihi = excelRange.Cells[i, 6]?.Text ?? DBNull.Value;

                        string queryCheck = @"
                SELECT COUNT(*)
                FROM mutabakat
                WHERE adi = @BayiAdi AND
                      vergino = @VergiNo AND
                      sonislemtarihi = @Sonİslem AND
                      borcbakiye = @BorcBakiye AND
                      alacakbakiye = @AlacakBakiye AND
                      mutabakattarihi = @MutabakatTarihi";

                        using (SqlCommand commandCheck = new SqlCommand(queryCheck, connection))
                        {
                            commandCheck.Parameters.AddWithValue("@BayiAdi", bayiadi);
                            commandCheck.Parameters.AddWithValue("@VergiNo", vergino);
                            commandCheck.Parameters.AddWithValue("@BorcBakiye", borcbakiye);
                            commandCheck.Parameters.AddWithValue("@AlacakBakiye", alacakbakiye);
                            commandCheck.Parameters.AddWithValue("@Sonİslem", sonislemtarihi);
                            commandCheck.Parameters.AddWithValue("@MutabakatTarihi", mutabakattarihi);

                            int exists = (int)commandCheck.ExecuteScalar();

                            if (exists == 0)
                            {
                                string queryInsert = @"
                            INSERT INTO mutabakat 
                            (adi, vergino, sonislemtarihi, borcbakiye, alacakbakiye, kayittarihi, mutabakattarihi) 
                            VALUES 
                            (@BayiAdi, @VergiNo, @SonIslem, @BorcBakiye, @AlacakBakiye, GETDATE(), @MutabakatTarihi)";

                                using (SqlCommand commandInsert = new SqlCommand(queryInsert, connection))
                                {
                                    commandInsert.Parameters.AddWithValue("@BayiAdi", bayiadi);
                                    commandInsert.Parameters.AddWithValue("@VergiNo", vergino);
                                    commandInsert.Parameters.AddWithValue("@SonIslem", sonislemtarihi);
                                    commandInsert.Parameters.AddWithValue("@BorcBakiye", borcbakiye);
                                    commandInsert.Parameters.AddWithValue("@AlacakBakiye", alacakbakiye);
                                    commandInsert.Parameters.AddWithValue("@MutabakatTarihi", mutabakattarihi);

                                    commandInsert.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
                GetDataFromDatabase();

                MessageBox.Show("Veriler başarıyla aktarıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                GetDataFromDatabase();

                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (excelWorkbook != null)
                {
                    excelWorkbook.Close(false);
                    Marshal.ReleaseComObject(excelWorkbook);
                }

                if (excelApp != null)
                {
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                }

                if (excelRange != null) Marshal.ReleaseComObject(excelRange);
                if (excelWorksheet != null) Marshal.ReleaseComObject(excelWorksheet);

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GetDataFromDatabase();

            }
        }

        private void excelaktar_Click(object sender, EventArgs e)
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

        private void dosya_bul_Click(object sender, EventArgs e)
        {
            mainForm.loadform(new muhasebeanasayfa(epostalabel.Text, mainForm));

        }

        private void mutabakat_Load(object sender, EventArgs e)
        {
            GetDataFromDatabase();
        }

        private void checkBoxPdfOlusturuldu_CheckedChanged(object sender, EventArgs e)
        {
            GetDataFromDatabase(); // CheckBox'ın durumu değiştiğinde verileri yeniden yükle
        }

        private void yeniekle_Click(object sender, EventArgs e)
        {
            mutabakatislemkayit mutabakatisemkayitform = new mutabakatislemkayit();
            mutabakatisemkayitform.ShowDialog();
        }

        private void datagridViewMutabakat_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = datagridViewMutabakat.HitTest(e.X, e.Y);
                datagridViewMutabakat.ClearSelection();
                if (hti.RowIndex >= 0)
                {
                    datagridViewMutabakat.Rows[hti.RowIndex].Selected = true;
                    var selectedRowData = GetSelectedRowData();
                    if (selectedRowData != null)
                    {
                        ContextMenuStrip menu = new ContextMenuStrip();
                        ToolStripMenuItem itemEdit = new ToolStripMenuItem("Düzenle");
                        itemEdit.Click += (s, args) =>
                        {
                            mutabakateditform editForm = new mutabakateditform(selectedRowData.Id);
                            editForm.ShowDialog();
                            GetDataFromDatabase(); // Güncellemeden sonra verileri yeniden yükleyin
                            this.Alert("Güncellendi!", Form_Alert.enmType.Info);
                        };
                        menu.Items.Add(itemEdit);
                        datagridViewMutabakat.ContextMenuStrip = menu;
                    }
                }
            }
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        private void aramabtn_Click(object sender, EventArgs e)
        {
            SearchData(txtArama.Text);
        }
    }

}

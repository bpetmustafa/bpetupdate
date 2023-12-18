using OfficeOpenXml;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace destek_otomasyonu
{
    public partial class RaporEkrani : Form
    {
        private const string connectionString = "Server=95.0.50.22,1382;Database=bpet_destek;User ID=sa;Password=Mustafa1;";

        public RaporEkrani()
        {
            InitializeComponent();
            LoadTalepler(); // Talepleri DataGridView'e yükle
            dgvRapor.AutoResizeColumns(); // Sütunları otomatik boyutlandır
            dgvRapor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Sütun boyutlarını hücre içeriğine göre ayarla
            // Hücre içeriğini istediğiniz yazı tipi ve boyutuyla görüntüleme
            dgvRapor.DefaultCellStyle.Font = new Font("Arial", 12); // İstediğiniz yazı tipi ve boyutunu kullanabilirsiniz

            // Başlık satırı görünümünü özelleştirme
            dgvRapor.EnableHeadersVisualStyles = false;
            dgvRapor.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // İstediğiniz yazı tipi ve boyutunu kullanabilirsiniz
        }

        private void LoadTalepler()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = "SELECT *, CASE WHEN Öncelik_No = 1 THEN 'Çok Öncelikli' WHEN Öncelik_No = 2 THEN 'Öncelikli' WHEN Öncelik_No = 3 THEN 'Normal' ELSE '' END AS Öncelik FROM talepler";

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dgvRapor.DataSource = dataTable;

                    // Özet bilgileri güncelle
                    int toplamTalepSayisi = dataTable.Rows.Count;
                    int bekleyentalepsayisi = 0;
                    int tamamlananTalepSayisi = 0;
                    int slaihlalsayisi = 0;

                    foreach (DataRow row in dataTable.Rows)
                    {
                        string talepDurumu = row.Field<string>("Talep_Durumu");
                        int sla = row.Field<int>("SLA");

                        if (talepDurumu.Contains("Tamamlandı"))
                            tamamlananTalepSayisi++;
                        if (talepDurumu.Contains("Inceleniyor"))
                            bekleyentalepsayisi++;
                        if (sla == 1)
                            slaihlalsayisi++;
                    }

                    txtToplamTalepSayisi.Text = toplamTalepSayisi.ToString();
                    txtBekleyentalepsayisi.Text = bekleyentalepsayisi.ToString();
                    txtTamamlananTalepSayisi.Text = tamamlananTalepSayisi.ToString();
                    txtSLAihlali.Text = slaihlalsayisi.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Talepler yüklenirken bir hata oluştu: " + ex.Message);
            }
        }



        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void ExportToExcel()
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Set the license context for EPPlus library

                using (ExcelPackage package = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Talepler"); // Excel sayfası oluştur

                    // Başlık sütunlarını ekle
                    for (int i = 1; i <= dgvRapor.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i].Value = dgvRapor.Columns[i - 1].HeaderText;
                    }

                    // Verileri DataGridView'den Excel sayfasına aktar
                    for (int i = 0; i < dgvRapor.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvRapor.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1].Value = dgvRapor.Rows[i].Cells[j].Value?.ToString();
                        }
                    }

                    // Excel dosyasını kaydet
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel Dosyası|*.xlsx";
                    saveFileDialog.Title = "Excel Dosyasını Kaydet";
                    saveFileDialog.FileName = "Talepler.xlsx";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        package.SaveAs(new FileInfo(saveFileDialog.FileName));
                        MessageBox.Show("Veriler başarıyla Excel dosyasına aktarıldı.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler Excel dosyasına aktarılırken bir hata oluştu: " + ex.Message);
            }
        }
    }
}

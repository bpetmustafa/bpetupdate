using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BPET_PORTAL.arsiv_uygulamasi
{
    public partial class DosyaTeslimEt : Form
    {
        private mainpage mainForm;
        private const string connectionString = "Server=95.0.50.22,1382;Database=bpetarsiv;User ID=sa;Password=Mustafa1;";
        private SqlConnection connection;
        private bool showOnlyNullGeriTeslimTarihi = true;

        public DosyaTeslimEt(string eposta, mainpage mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            connection = new SqlConnection(connectionString);
            epostalabel.Text = eposta;
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            mainForm.loadform(new arsivmainpage(epostalabel.Text, mainForm));
        }

        private void DosyaTeslimEt_Load(object sender, EventArgs e)
        {
            FillKisilerComboBox();

            // Dosya atamalarını DataGridView'e getir
            GetDosyaAtamalari(showOnlyNullGeriTeslimTarihi);
            dataGridViewAtamalar.Columns["DosyaID"].Visible = false;
            dataGridViewAtamalar.Columns["AtamaID"].Visible = false;
        }

        private void checkBoxShowAll_CheckedChanged(object sender, EventArgs e)
        {
            showOnlyNullGeriTeslimTarihi = !checkBoxShowAll.Checked;
            GetDosyaAtamalari(showOnlyNullGeriTeslimTarihi);
        }

        private void FillKisilerComboBox()
        {
            try
            {
                connection.Open();
                string query = "SELECT KisiAdi FROM Kisiler";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comboBoxKisiler.Items.Add(reader["KisiAdi"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kişiler yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void GetDosyaAtamalari(bool showOnlyNullGeriTeslimTarihi)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                // Dosya atamalarını veritabanından getirirken isteğe bağlı olarak filtreleme yap
                string query = "SELECT Dosyalar.DosyaYili, Dosyalar.DosyaAy, Dosyalar.Kategori, Dosyalar.FizikselYer, Dosyalar.DosyaID, DosyaAtamalar.AtamaID, Dosyalar.DosyaAdi, DosyaAtamalar.KisiAdi, DosyaAtamalar.AtamaTarihi, DosyaAtamalar.GeriTeslimTarihi " +
                               "FROM DosyaAtamalar " +
                               "INNER JOIN Dosyalar ON DosyaAtamalar.DosyaID = Dosyalar.DosyaID";

                if (showOnlyNullGeriTeslimTarihi)
                {
                    query += " WHERE DosyaAtamalar.GeriTeslimTarihi IS NULL";
                }

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewAtamalar.DataSource = dataTable;
                dataGridViewAtamalar.Columns["DosyaID"].Visible = false;
                dataGridViewAtamalar.Columns["AtamaID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya atamaları alınırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridViewAtamalar.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridViewAtamalar.SelectedRows[0].Index;
                int atamaID = Convert.ToInt32(dataGridViewAtamalar.Rows[rowIndex].Cells["AtamaID"].Value);
                string dosyaID = dataGridViewAtamalar.Rows[rowIndex].Cells["DosyaID"].Value.ToString(); // DosyaID'yi string olarak al

                DialogResult result = MessageBox.Show($"Dosya '{dosyaID}' geri teslim edilsin mi?", "Geri Teslim", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (connection.State == ConnectionState.Closed)
                            connection.Open();

                        // Geri teslim tarihini ve teslim eden kişiyi güncelle
                        string teslimQuery = "UPDATE DosyaAtamalar SET GeriTeslimTarihi = @GeriTeslimTarihi, KisiAdi = @KisiAdi WHERE AtamaID = @AtamaID";
                        SqlCommand teslimCommand = new SqlCommand(teslimQuery, connection);
                        teslimCommand.Parameters.AddWithValue("@GeriTeslimTarihi", DateTime.Now);
                        teslimCommand.Parameters.AddWithValue("@KisiAdi", comboBoxKisiler.SelectedItem.ToString());
                        teslimCommand.Parameters.AddWithValue("@AtamaID", atamaID);
                        teslimCommand.ExecuteNonQuery();

                        MessageBox.Show("Dosya başarıyla geri teslim edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Dosya atamalarını güncelle
                        GetDosyaAtamalari(showOnlyNullGeriTeslimTarihi);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Dosya geri teslim edilirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }
        }

        private void dataGridViewAtamalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void CreatePDFAndOpen(string dosyaID)
        {
            try
            {
                string pdfFilePath = "DosyaDetay_" + dosyaID + ".pdf"; // PDF dosya adı, dosyaID'ye göre benzersizleştiriyoruz

                // Dosya detaylarını veritabanından al
                string query = "SELECT AtamaID, KisiAdi, AtamaTarihi, GeriTeslimTarihi FROM DosyaAtamalar WHERE DosyaID = @DosyaID";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DosyaID", dosyaID);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // PDF oluştur
                            Document document = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
                            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfFilePath, FileMode.Create));
                            document.Open();

                            // PDF içeriği oluştur
                            Paragraph header = new Paragraph("Dosya Detayları - Dosya ID: " + dosyaID);
                            document.Add(header);

                            PdfPTable table = new PdfPTable(4); // 4 sütunlu bir tablo oluşturuyoruz
                            table.WidthPercentage = 100;

                            // Tablo başlık sütunları
                            table.AddCell("Atama ID");
                            table.AddCell("Kisi Adi");
                            table.AddCell("Atama Tarihi");
                            table.AddCell("Geri Teslim Tarihi");

                            // Dosya detaylarını tabloya ekleyelim
                            while (reader.Read())
                            {
                                table.AddCell(reader["AtamaID"].ToString());
                                table.AddCell(reader["KisiAdi"].ToString());
                                table.AddCell(reader["AtamaTarihi"].ToString());
                                table.AddCell(reader["GeriTeslimTarihi"].ToString());
                            }

                            document.Add(table);
                            document.Close();
                        }
                    }
                }

                // PDF'i varsayılan PDF görüntüleyiciyle aç
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = pdfFilePath;
                psi.UseShellExecute = true;
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDF oluşturulurken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewAtamalar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Geçerli bir satır seçildiğinden emin olalım
            {
                string dosyaID = dataGridViewAtamalar.Rows[e.RowIndex].Cells["DosyaID"].Value.ToString(); // DosyaID'yi string olarak al
                CreatePDFAndOpen(dosyaID);
            }
        }
    }
}

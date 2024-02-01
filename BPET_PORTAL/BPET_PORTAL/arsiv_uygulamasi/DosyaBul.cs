using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPET_PORTAL.arsiv_uygulamasi
{
    public partial class DosyaBul : Form
    {
        private mainpage mainForm;
        private const string connectionString = "Server=95.0.50.22,1382;Database=bpetarsiv;User ID=sa;Password=Mustafa1;";
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private System.Windows.Forms.Timer timer; 
        private bool isSearching = false;

        private BackgroundWorker mailGonderici = new BackgroundWorker();

        public DosyaBul(string eposta, mainpage mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm; 
            epostalabel.Text = eposta;
            connection = new SqlConnection(connectionString);
            timer = new System.Windows.Forms.Timer();
            dataGridView.CellDoubleClick += dataGridView_CellDoubleClick;

            mailGonderici.DoWork += MailGonderici_DoWork;
            mailGonderici.RunWorkerCompleted += MailGonderici_RunWorkerCompleted;
        }
        private void kullaniciyetkileri()
        {
            string kullaniciYetkileri = GetKullaniciYetkileri(epostalabel.Text);
        }
        private bool CheckUserPermission(string requiredPermission, string kullaniciYetkileri)
        {
            return kullaniciYetkileri.Contains(requiredPermission);
        }
        private string GetKullaniciYetkileri(string eposta)
        {
            string yetkiler = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();


                    string query = "SELECT arsiv_yetki FROM BPET_PORTAL.dbo.users WHERE E_Posta = @Eposta";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Eposta", eposta);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            yetkiler = result.ToString();
                        }
                        else
                        {
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                this.Alert("Kullanıcı yetkileri alınamadı: " + ex.Message, Form_Alert.enmType.Error);
                MessageBox.Show(ex.Message);
            }

            return yetkiler;
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView.SelectedRows[0].Index;
                string dosyaID = dataGridView.Rows[rowIndex].Cells["DosyaID"].Value.ToString();

                KisiAtaForm kisiAtaForm = new KisiAtaForm(dosyaID,mainForm,epostalabel.Text);
                kisiAtaForm.ShowDialog();
            }
        }
        private void dosya_bul_Click(object sender, EventArgs e)
        {

            mainForm.loadform(new arsivmainpage(epostalabel.Text,mainForm));

        }

        private void DosyaBul_Load(object sender, EventArgs e)
        {
            FillComboBoxes();

           // GetDataFromDatabase();
            timer.Start();
            kullaniciyetkileri();
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

        private void GetDataFromDatabase()
        {
            try
            {
                connection.Open();
                string query = "SELECT DosyaID, FizikselYer, DosyaAdi, Kategori, SirketIsmi, DosyaYili, DosyaAy, DosyaNumarasi, DosyaTipi, Aciklama FROM Dosyalar";

                dataAdapter = new SqlDataAdapter(query, connection);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGridView.DataSource = dataTable;
                dataGridView.Columns["DosyaID"].Visible = false;

                connection.Close();
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

                string query = "SELECT DosyaID, FizikselYer, DosyaAdi, Kategori, SirketIsmi, DosyaYili, DosyaAy, DosyaNumarasi, DosyaTipi, Aciklama FROM Dosyalar WHERE 1=1"; // Başlangıç sorgusu

                if (!string.IsNullOrEmpty(comboBoxYil.Text))
                {
                    query += " AND DosyaYili LIKE @DosyaYili";
                }

                if (!string.IsNullOrEmpty(comboBoxAy.Text))
                {
                    query += " AND DosyaAy LIKE @DosyaAy";
                }

                if (!string.IsNullOrEmpty(comboBoxSirketIsmi.Text))
                {
                    query += " AND SirketIsmi LIKE @SirketIsmi";
                }

                if (!string.IsNullOrEmpty(comboBoxKategori.Text))
                {
                    query += " AND Kategori LIKE @Kategori";
                }

                string searchText = textBoxArama.Text;
                if (!string.IsNullOrEmpty(searchText))
                {
                    query += " AND (DosyaAdi LIKE @SearchText OR Kategori LIKE @SearchText OR FizikselYer LIKE @SearchText OR SirketIsmi LIKE @SearchText)";
                }

                dataAdapter = new SqlDataAdapter(query, connection);

                if (!string.IsNullOrEmpty(comboBoxYil.Text))
                {
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@DosyaYili", "%" + comboBoxYil.Text + "%");
                }
                if (!string.IsNullOrEmpty(comboBoxAy.Text))
                {
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@DosyaAy", "%" + comboBoxAy.Text + "%");
                }
                if (!string.IsNullOrEmpty(comboBoxSirketIsmi.Text))
                {
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@SirketIsmi", "%" + comboBoxSirketIsmi.Text + "%");
                }
                if (!string.IsNullOrEmpty(comboBoxKategori.Text))
                {
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@Kategori", "%" + comboBoxKategori.Text + "%");
                }
                dataAdapter.SelectCommand.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView.DataSource = dataTable;
               // dataGridView.Columns["DosyaID"].Visible = false;
                dataGridView.Columns["FizikselYer"].Visible = false; // FizikselYer sütununu gizle

            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler alınırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                dataGridView.AutoResizeColumn(column.Index, DataGridViewAutoSizeColumnMode.AllCells);
            }
        }
        private void resetle_Click(object sender, EventArgs e)
        {
            textBoxArama.Text = "";

            comboBoxYil.SelectedIndex = -1;
            comboBoxAy.SelectedIndex = -1;
            comboBoxSirketIsmi.SelectedIndex = -1;
            comboBoxKategori.SelectedIndex = -1;
            isSearching = false;
            //GetDataFromDatabase();
        }
        private void textBoxArama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Delete)
            {

                textBoxArama.Clear();
            }
        }

        private void comboBoxKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FilterDataInDatabase();
        }

        private void pdf_istebutton_Click(object sender, EventArgs e)
        {
            // Get the request description using the PromptForTalepAciklama method
            string talepAciklama = PromptForTalepAciklama();

            // Check if the description is not null or empty before saving the request
            if (!string.IsNullOrEmpty(talepAciklama))
            {
                string talepEden = epostalabel.Text;
                KaydetPdfTalep(talepEden, talepAciklama);
                mailGonderici.RunWorkerAsync(epostalabel.Text);
            }
            else
            {
                // If the description is null or empty, do not save the request and show a message
               // MessageBox.Show("Talep açıklaması boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Alert("Talep Açıklaması Boş Olamaz! İşlem İptal!", Form_Alert.enmType.Warning);

            }
        }
        private void MailGonderici_DoWork(object sender, DoWorkEventArgs e)
        {
            string alıcıEmail = e.Argument as string;
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.office365.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("info@bpet.com.tr", "IbBc*2014"),
                    EnableSsl = true,
                };

                MailMessage mail = new MailMessage
                {
                    From = new MailAddress("info@bpet.com.tr"),
                    Subject = "PDF Talebi Alındı",
                    Body = "Merhaba,\n\nTalebiniz başarıyla alınmıştır. Talep detaylarınız en kısa sürede işlenecektir.\n\nSaygılarımızla,\nBPET Arşiv Uygulaması"
                };
                MailMessage mailarsiv = new MailMessage
                {
                    From = new MailAddress("info@bpet.com.tr"),
                    Subject = "Yeni PDF Talebi Geldi!",
                    Body = "Merhaba, \n\n Yeni bir talep geldi. Lütfen talebe en kısa zamanda BPET PORTAL üzerinden Yanıt Veriniz! \n\n Bu Mesaj Bpet Portal Tarafından Otomatik Olarak Gönderilmiştir!"
                };
                mail.To.Add(alıcıEmail);
                mail.Bcc.Add(new MailAddress("mustafa.ceylan@bpet.com.tr")); // Gizli alıcı ekleme
                mail.CC.Add(new MailAddress("arsiv@bpet.com.tr"));
               
                smtpClient.Send(mail);

                mailarsiv.To.Add(new MailAddress("arsiv@bpet.com.tr"));
                mailarsiv.Bcc.Add(new MailAddress("mustafa.ceylan@bpet.com.tr")); // Gizli alıcı ekleme

                smtpClient.Send(mailarsiv);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        private void MailGonderici_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Mail gönderimi sırasında bir hata oluştu: " + e.Error.Message);
            }
            else if (e.Result != null)
            {
                MessageBox.Show("Mail gönderimi sırasında bir hata oluştu: " + ((Exception)e.Result).Message);
            }
            else
            {
                //MessageBox.Show("Talebiniz alınmıştır ve mail adresinize bilgilendirme yapılmıştır.");
            }
        }
        private string PromptForTalepAciklama()
        {
            string talepAciklama = null;
            using (var form = new Form())
            using (var titleLabel = new Label())
            using (var infoLabel = new Label())
            using (var textBox = new TextBox())
            using (var okButton = new Button())
            {
                form.Text = "Talep Açıklaması";
                form.FormBorderStyle = FormBorderStyle.FixedToolWindow; // Çerçevesiz pencere
                form.Size = new Size(600, 350); // Form boyutunu ayarla
                form.StartPosition = FormStartPosition.CenterScreen; // Formun ekranın ortasında açılması

                titleLabel.Text = "Talep Açıklaması Girin";
                titleLabel.Font = new Font("Arial", 16, FontStyle.Bold);
                titleLabel.Dock = DockStyle.Top;
                titleLabel.TextAlign = ContentAlignment.MiddleCenter;
                titleLabel.AutoSize = false;
                titleLabel.Height = 40;

                infoLabel.Text = "Lütfen talep açıklamasını aşağıdaki metin kutusuna girin ve 'Tamam' düğmesine basın.";
                infoLabel.Font = new Font("Arial", 12);
                infoLabel.Dock = DockStyle.Top;
                infoLabel.TextAlign = ContentAlignment.TopCenter;
                infoLabel.AutoSize = false;
                infoLabel.Height = 60;

                // Metin kutusunun boyutunu ve konumunu ayarla
                textBox.Size = new Size(560, 150);
                textBox.Location = new Point(10, 110);

                okButton.Text = "Tamam";
                okButton.Font = new Font("Arial", 14, FontStyle.Bold);
                okButton.Dock = DockStyle.Bottom;
                okButton.BackColor = Color.FromArgb(0, 123, 255);
                okButton.ForeColor = Color.White;
                okButton.FlatStyle = FlatStyle.Flat;
                okButton.Height = 40;

                okButton.Click += (s, e) =>
                {
                    talepAciklama = textBox.Text.Trim(); // Kullanıcının girdiği metni alın, trim() ile baştaki ve sondaki boşlukları temizleyin
                    if (string.IsNullOrEmpty(talepAciklama))
                    {
                        MessageBox.Show("Talep açıklaması boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        form.Close(); // Formu kapat
                    }
                };

                form.Controls.Add(titleLabel);
                form.Controls.Add(infoLabel);
                form.Controls.Add(textBox);
                form.Controls.Add(okButton);
                form.ShowDialog();

            }
            return talepAciklama;
        }

        private void KaydetPdfTalep(string talepEden, string talepAciklama)
        {
            try
            {
                // Ensure the connection to the database is opened
                connection.Open();

                // Insert the request into the database
                string query = "INSERT INTO Talepler (TalepEden, TalepAciklama, TalepDurumu) VALUES (@TalepEden, @TalepAciklama, 'Beklemede')";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TalepEden", talepEden);
                command.Parameters.AddWithValue("@TalepAciklama", talepAciklama);
                command.ExecuteNonQuery();

                // Show a message confirming the request has been saved
                MessageBox.Show("PDF talebiniz başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // If an error occurs, show an error message
                MessageBox.Show("Talep kaydedilirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Always close the connection to the database when done
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mainForm.loadform(new pdftaleplerim(epostalabel.Text, mainForm));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FilterDataInDatabase();
        }
    }
}

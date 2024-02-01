using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPET_PORTAL.arsiv_uygulamasi
{
    public partial class KisiAtaForm : Form
    {
        private mainpage mainForm;
        private const string connectionString = "Server=95.0.50.22,1382;Database=bpetarsiv;User ID=sa;Password=Mustafa1;";
        private SqlConnection connection;
        private string dosyaID; // Atama yapılacak dosya ID'si
        private List<string> eklenenKisiler = new List<string>();

        public KisiAtaForm(string dosyaID, mainpage mainForm, string eposta)
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            this.dosyaID = dosyaID;
            this.mainForm = mainForm; // mainForm örneğini burada başlatın
            epostalabel.Text = eposta;
            dosyaidlabel.Text = dosyaID;
        }

        private void KisiAtaForm_Load(object sender, EventArgs e)
        {
            try
            {
                EnsureConnection();

                // Dosyanın daha önce atanıp atanmadığını kontrol et
                string atamaKontrolQuery = "SELECT TOP 1 KisiAdi, AtamaTarihi, GeriTeslimTarihi FROM DosyaAtamalar WHERE DosyaID = @DosyaID ORDER BY AtamaTarihi DESC";
                SqlCommand atamaKontrolCommand = new SqlCommand(atamaKontrolQuery, connection);
                atamaKontrolCommand.Parameters.AddWithValue("@DosyaID", dosyaID);
                SqlDataReader reader = atamaKontrolCommand.ExecuteReader();
                if (reader.Read())
                {
                    string kisiAdi = reader["KisiAdi"].ToString();
                    DateTime atamaTarihi = Convert.ToDateTime(reader["AtamaTarihi"]);
                    DateTime? geriTeslimTarihi = reader["GeriTeslimTarihi"] as DateTime?;

                    reader.Close();

                    if (geriTeslimTarihi == null)
                    {
                        comboBoxKisiler.Enabled = false;
                        btnkaydet.Visible = false;
                        uyarı.Visible = true;
                        using (var warningForm = new Form())
                        {
                            warningForm.Text = "Dosya Zaten Alınmış";
                            warningForm.Size = new Size(500, 400);
                            warningForm.StartPosition = FormStartPosition.CenterScreen;
                            warningForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                            warningForm.MaximizeBox = false;
                            warningForm.MinimizeBox = false;

                            Label label = new Label();
                            label.Text = "Dosya zaten alınmış ve henüz geri teslim edilmemiş. Dosyayı teslim alan kişiye, sizin dosyaya ihtiyacınız olduğu mail yolu ile bildirilmiştir!\n\nDosyayı alan kişinin bilgileri:\n";
                            label.Text += "Kişi Adı: " + kisiAdi + "\n";
                            label.Text += "Telefon: " + GetTelefon(kisiAdi) + "\n";
                            label.Text += "E-posta: " + GetEmail(kisiAdi) + "\n";

                            label.Dock = DockStyle.Fill;
                            label.TextAlign = ContentAlignment.MiddleCenter;
                            label.Font = new Font("Arial", 12, FontStyle.Bold);

                            // Atama tarihini de alalım ve SendEmail metodu çağırırken geçelim
                            string atamaTarihiStr = atamaTarihi.ToString("dd.MM.yyyy HH:mm:ss");
                            DialogResult result = MessageBox.Show("Dosya zaten alınmış ve henüz geri teslim edilmemiş. Dosyayı teslim alan kişiye, sizin dosyaya ihtiyacınız olduğu mail yolu ile bildirilsin mi?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (result == DialogResult.Yes)
                            {
                                // Kullanıcı evet derse e-posta gönderme işlemi başlat
                                Task.Run(() => SendEmail(kisiAdi, atamaTarihiStr));
                                this.Alert("Mail gönderildi!", Form_Alert.enmType.Info);
                            }

                            warningForm.Controls.Add(label);
                            warningForm.ShowDialog();
                            this.Close();
                        }
                        return;
                    }
                }

                reader.Close();
                FillComboBoxKisilerByCategory(dosyaID);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya atanma bilgisi kontrol edilirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnsureConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        private void SendEmail(string kisiAdi, string AtamaTarihi)
        {
            // E-posta göndermek için gerekli bilgileri alalım
            string smtpServer = "smtp.office365.com";
            int smtpPort = 587;
            string senderEmail = "info@bpet.com.tr";
            string senderPassword = "IbBc*2014";

            // Alıcı e-posta adresini alalım
            string recipientEmail = GetEmail(kisiAdi);

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);

                // E-posta gönderici ve alıcı bilgileri
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(new MailAddress(recipientEmail));

                // E-posta başlık ve içeriği
                mail.Subject = "Teslim Aldığınız Dosya Hakkında";

                // Dosya detaylarını alalım ve e-posta içeriğine ekleyelim
                string dosyaDetaylari = GetDosyaDetaylari(dosyaID);
                mail.Body = $"Merhaba {kisiAdi},\n\n {AtamaTarihi} tarihinde aldığınız dosya ile ilgili bilgiler aşağıdaki gibidir:\n\n{dosyaDetaylari}\n\nDosyayı talep edenler var lütfen en kısa zamanda geri getiriniz.";

                // E-posta gönderme yetkilendirmesi
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(senderEmail, senderPassword);
                smtpClient.EnableSsl = true;

                // E-postayı gönderelim
                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("E-posta gönderme işleminde bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetDosyaDetaylari(string dosyaID)
        {
            string dosyaDetaylari = "";

            try
            {
                EnsureConnection();

                string query = "SELECT DosyaAdi, Kategori, FizikselYer, SirketIsmi, DosyaYili, DosyaAy, DosyaNumarasi, DosyaTipi, DosyaYukleyen, OlusturmaTarihi FROM Dosyalar WHERE DosyaID = @DosyaID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DosyaID", dosyaID);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    dosyaDetaylari += "Dosya Adı: " + reader["DosyaAdi"].ToString() + "\n";
                    dosyaDetaylari += "Kategori: " + reader["Kategori"].ToString() + "\n";
                    dosyaDetaylari += "Fiziksel Yer: " + reader["FizikselYer"].ToString() + "\n";
                    dosyaDetaylari += "Şirket İsmi: " + reader["SirketIsmi"].ToString() + "\n";
                    dosyaDetaylari += "Dosya Yılı: " + reader["DosyaYili"].ToString() + "\n";
                    dosyaDetaylari += "Dosya Ayı: " + reader["DosyaAy"].ToString() + "\n";
                    dosyaDetaylari += "Dosya Numarası: " + reader["DosyaNumarasi"].ToString() + "\n";
                    dosyaDetaylari += "Dosya Tipi: " + reader["DosyaTipi"].ToString() + "\n";
                    dosyaDetaylari += "Dosya Yükleyen: " + reader["DosyaYukleyen"].ToString() + "\n";
                    dosyaDetaylari += "Oluşturma Tarihi: " + Convert.ToDateTime(reader["OlusturmaTarihi"]).ToString("dd.MM.yyyy HH:mm:ss") + "\n";
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya detayları alınırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dosyaDetaylari;
        }

        private string GetTelefon(string kisiAdi)
        {
            string telefon = "Bilgi Yok";

            try
            {
                EnsureConnection(); // Bağlantıyı aç

                string query = "SELECT Telefon FROM Kisiler WHERE KisiAdi = @KisiAdi";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@KisiAdi", kisiAdi);
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    telefon = result.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Telefon bilgisi alınırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return telefon;
        }

        private string GetEmail(string kisiAdi)
        {
            try
            {
                EnsureConnection();

                string query = "SELECT Email FROM Kisiler WHERE KisiAdi = @KisiAdi";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@KisiAdi", kisiAdi);
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("E-posta bilgisi alınırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return "Bilgi Yok";
        }

        private void FillComboBoxKisilerByCategory(string dosyaID)
        {
            try
            {
                EnsureConnection();

                // Dosyanın kategorisini al
                string dosyaKategorisi = GetDosyaKategorisi(dosyaID);

                string kategoriFilter = "";

                if (dosyaKategorisi == "MUHASEBE")
                {
                    kategoriFilter = "m_kategori";
                }
                else if (dosyaKategorisi == "İK")
                {
                    kategoriFilter = "i_kategori";
                }
                else if (dosyaKategorisi == "FİNANS")
                {
                    kategoriFilter = "f_kategori";
                }
                else if (dosyaKategorisi == "SATIŞDESTEK")
                {
                    kategoriFilter = "s_kategori";
                }

                if (!string.IsNullOrEmpty(kategoriFilter))
                {
                    string query = $"SELECT DISTINCT KisiAdi FROM Kisiler WHERE Kategori LIKE '%{kategoriFilter}%'";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBoxKisiler.Items.Add(reader["KisiAdi"].ToString());
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kişiler yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetDosyaKategorisi(string dosyaID)
        {
            string dosyaKategorisi = "";

            try
            {
                EnsureConnection(); // Bağlantıyı aç

                string query = "SELECT Kategori FROM Dosyalar WHERE DosyaID = @DosyaID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DosyaID", dosyaID);
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    dosyaKategorisi = result.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya kategorisi alınırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dosyaKategorisi;
        }

        private void buttonKisiAta_Click(object sender, EventArgs e)
        {
            if (comboBoxKisiler.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir kişi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                EnsureConnection();

                string kisiAdi = comboBoxKisiler.SelectedItem.ToString();
                DateTime atamaTarihi = DateTime.Now;

                // Eğer dosya daha önce atanmışsa, eski atama bilgisini getir
                string eskiAtamaBilgisiQuery = "SELECT KisiAdi, AtamaTarihi, GeriTeslimTarihi FROM DosyaAtamalar WHERE DosyaID = @DosyaID";
                SqlCommand eskiAtamaCommand = new SqlCommand(eskiAtamaBilgisiQuery, connection);
                eskiAtamaCommand.Parameters.AddWithValue("@DosyaID", dosyaID);
                SqlDataReader reader = eskiAtamaCommand.ExecuteReader();

                string eskiKisiAdi = null;
                DateTime? eskiAtamaTarihi = null;

                if (reader.Read())
                {
                    eskiKisiAdi = reader["KisiAdi"].ToString();
                    eskiAtamaTarihi = Convert.ToDateTime(reader["AtamaTarihi"]);
                }

                reader.Close();

                // Yeni atama yap
                string atamaQuery = "INSERT INTO DosyaAtamalar (DosyaID, KisiAdi, AtamaTarihi) VALUES (@DosyaID, @KisiAdi, @AtamaTarihi)";
                SqlCommand atamaCommand = new SqlCommand(atamaQuery, connection);
                atamaCommand.Parameters.AddWithValue("@DosyaID", dosyaID);
                atamaCommand.Parameters.AddWithValue("@KisiAdi", kisiAdi);
                atamaCommand.Parameters.AddWithValue("@AtamaTarihi", atamaTarihi);
                atamaCommand.ExecuteNonQuery();

                MessageBox.Show("Dosya başarıyla kişiye atandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Eğer dosya daha önce atanmışsa, eski atama bilgisini göster
                if (!string.IsNullOrEmpty(eskiKisiAdi) && eskiAtamaTarihi != null)
                {
                    MessageBox.Show($"Dosya daha önce {eskiKisiAdi} tarafından {eskiAtamaTarihi.Value.ToString("dd.MM.yyyy HH:mm:ss")} tarihinde alınmıştı.", "Eski Atama Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya kişiye atanırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
                this.Close();
            }
        }

        private void geri_Click(object sender, EventArgs e)
        {
            //mainForm.loadform(new arsivmainpage(epostalabel.Text,mainForm));
            this.Close();
        }
        private void GeciciYetkiGosterButton_Click(object sender, EventArgs e)
        {
            try
            {
                EnsureConnection();

                // Dosyanın kategorisini al
                string dosyaKategorisi = GetDosyaKategorisi(dosyaID);

                string kategoriFilter = "";

                if (dosyaKategorisi == "MUHASEBE")
                {
                    kategoriFilter = "m_kategori";
                }
                else if (dosyaKategorisi == "İK")
                {
                    kategoriFilter = "i_kategori";
                }
                else if (dosyaKategorisi == "FİNANS")
                {
                    kategoriFilter = "f_kategori";
                }

                if (!string.IsNullOrEmpty(kategoriFilter))
                {
                    string query = $"SELECT DISTINCT KisiAdi FROM gecici_yetki WHERE BitisTarihi >= GETDATE() AND YetkiKategorisi LIKE '%{kategoriFilter}%'";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string kisiAdi = reader["KisiAdi"].ToString();
                        if (!eklenenKisiler.Contains(kisiAdi))
                        {
                            comboBoxKisiler.Items.Add(kisiAdi);
                            eklenenKisiler.Add(kisiAdi);
                            this.Alert("Geçici Kullanıcı Eklendi!", Form_Alert.enmType.Success);
                        }
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Geçici yetkiler alınırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
    }
}

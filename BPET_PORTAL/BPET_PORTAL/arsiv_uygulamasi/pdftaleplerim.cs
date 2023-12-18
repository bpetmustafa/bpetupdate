using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace BPET_PORTAL.arsiv_uygulamasi
{
    public partial class pdftaleplerim : Form
    {
        private mainpage mainForm;
        private const string connectionString = "Server=95.0.50.22,1382;Database=bpetarsiv;User ID=sa;Password=Mustafa1;";
        private DataTable dataTable;
        private SqlConnection connection;

        public pdftaleplerim(string eposta, mainpage mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            epostalabel.Text = eposta;
            connection = new SqlConnection(connectionString);
            LoadTalepler();
        }
        private void kullaniciyetkileri()
        {
            string kullaniciYetkileri = GetKullaniciYetkileri(epostalabel.Text);

            adminpanel.Visible = CheckUserPermission("pdfadmin_arsiv", kullaniciYetkileri);
            adminpanel.Enabled = CheckUserPermission("pdfadmin_arsiv", kullaniciYetkileri);
            //teslimallabel.Visible = CheckUserPermission("aa_arsiv", kullaniciYetkileri);
            if (adminpanel.Visible)
            {
                LoadTalepEdenToComboBox(); // ComboBox'ı doldur
            }
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
        private void returns_Click(object sender, EventArgs e)
        {
            mainForm.loadform(new DosyaBul(epostalabel.Text, mainForm));
        }

        private void LoadTalepler()
        {
            try
            {
                connection.Open();
                string query;
                if (adminpanel.Visible)
                {
                    // Admin paneli gözüküyorsa, tüm kullanıcıların taleplerini getir
                    query = "SELECT * FROM Talepler WHERE TalepDurumu = 'Beklemede'";
                }
                else
                {
                    // Değilse, sadece giriş yapan kullanıcının taleplerini getir
                    query = "SELECT * FROM Talepler WHERE TalepEden = @TalepEden";
                }

                SqlCommand command = new SqlCommand(query, connection);
                if (!adminpanel.Visible)
                {
                    command.Parameters.AddWithValue("@TalepEden", epostalabel.Text);
                }

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGridView.DataSource = dataTable;

               

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Talepler yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
        private void LoadTalepEdenToComboBox()
        {
            try
            {
                connection.Open();
                string query = "SELECT DISTINCT TalepEden FROM Talepler WHERE TalepDurumu = 'Beklemede'";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dtTalepEden = new DataTable();
                dataAdapter.Fill(dtTalepEden);

                comboTalepEden.Items.Clear(); // ComboBox'ı temizle
                foreach (DataRow row in dtTalepEden.Rows)
                {
                    comboTalepEden.Items.Add(row["TalepEden"].ToString());
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Talep edenler yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
        private bool YukleFtp(string dosyaYolu)
        {
            // Dosya yükleme işlemi sırasında progress bar'ı güncelle
            try
            {
                string ftpSunucu = "ftp://95.0.50.22:1381/";
                string kullaniciAdi = "mustafa.ceylan";
                string sifre = "Defne2023";
                string klasor = "/bpet_portal/taleppdf/";

                // Dosya boyutunu al
                long dosyaBoyutu = new FileInfo(dosyaYolu).Length;

                // Dosya adını değiştirmeden FTP sunucusuna yükleme
                string dosyaAdi = Path.GetFileName(dosyaYolu);
                string hedefDosyaYolu = ftpSunucu + klasor + dosyaAdi;

                // FTP sunucusuna bağlanma ve dosyayı yükleme
                FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(hedefDosyaYolu);
                ftpWebRequest.Credentials = new NetworkCredential(kullaniciAdi, sifre);
                ftpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;
                ftpWebRequest.UseBinary = true;
                ftpWebRequest.UsePassive = true;
                ftpWebRequest.KeepAlive = true;

                using (FileStream fileStream = File.OpenRead(dosyaYolu))
                using (Stream ftpStream = ftpWebRequest.GetRequestStream())
                {
                    byte[] buffer = new byte[10240];
                    int bytesRead;
                    long toplamOkunan = 0;

                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ftpStream.Write(buffer, 0, bytesRead);

                        // Dosya yükleme ilerlemesini hesapla ve progress bar'ı güncelle
                        toplamOkunan += bytesRead;
                        int ilerlemeYuzdesi = (int)((toplamOkunan * 100) / dosyaBoyutu);
                        this.Invoke((MethodInvoker)delegate
                        {
                            progressBar.Visible = true;
                            progressBar.Value = ilerlemeYuzdesi;
                        });
                    }
                }

                return true;
            }
            catch (Exception ex)
            {

               // this.Alert("Dosya yüklenemedi:  " + ex.Message, Form_Alert.enmType.Error);

                return false;
            }
        }
        private void CevaplaButonu_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                progressBar.Visible = true; // ProgressBar'ı göster

                // Seçilen satırın index'ini al
                int rowIndex = dataGridView.SelectedRows[0].Index;

                // Talep ID ve talep eden e-posta adresini al
                string talepID = dataGridView.Rows[rowIndex].Cells["TalepID"].Value.ToString();
                string talepEdenEmail = dataGridView.Rows[rowIndex].Cells["TalepEden"].Value.ToString();
                string talepDurumu = dataGridView.Rows[rowIndex].Cells["TalepDurumu"].Value.ToString();
                string talepAciklamasi = dataGridView.Rows[rowIndex].Cells["TalepAciklama"].Value.ToString();

                if (talepDurumu == "Sonuçlandırıldı")
                {
                    DialogResult dialogResult = MessageBox.Show("Bu talep zaten sonuçlandırılmış. Yeniden göndermek ister misiniz?", "Talep Zaten Cevaplanmış", MessageBoxButtons.YesNo);
                    if (dialogResult != DialogResult.Yes)
                    {
                        LoadTalepler();
                        progressBar.Visible = false;
                        return; // Eğer kullanıcı yeniden göndermek istemiyorsa işlemi durdur.
                    }
                }

                // Sonuçlandırma açıklamasını almak için bir input dialog göster
                string sonuclandirmaAciklamasi = Microsoft.VisualBasic.Interaction.InputBox("Sonuçlandırma Açıklaması Girin:", "Talep Cevapla", "", -1, -1);

                // Eğer açıklama girilmediyse işlemi durdur
                if (string.IsNullOrEmpty(sonuclandirmaAciklamasi))
                {
                    MessageBox.Show("Sonuçlandırma açıklaması gereklidir.");
                    LoadTalepler();
                    return;
                }

                // Dosya seçme dialogu aç
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    string fileName = Path.GetFileName(filePath); // Dosya adını al
                    YukleFtp(filePath);
                    // Mail gönderme işlemi
                    try
                    {
                        SmtpClient smtpClient = new SmtpClient("smtp.office365.com")
                        {
                            Port = 587,
                            Credentials = new System.Net.NetworkCredential("info@bpet.com.tr", "IbBc*2014"),
                            EnableSsl = true,
                        };

                        MailMessage mail = new MailMessage
                        {
                            From = new MailAddress("info@bpet.com.tr"),
                            Subject = "Talep Cevabı - Talep ID: " + talepID,
                            Body = "Merhaba,\n\nTalebiniz aşağıdaki detaylara göre işlenmiştir:\n\n" +
                       "Talep ID: " + talepID + "\n" +
                       "Talep Açıklaması: " + talepAciklamasi + "\n" +
                       "Sonuçlandırma Açıklaması: " + sonuclandirmaAciklamasi + "\n\n" +
                       "Ek olarak gönderilen dosyayı inceleyebilirsiniz.\n\n" +
                       "Saygılarımızla,\nBPET Arşiv Uygulaması"
                        };
                        mail.To.Add(talepEdenEmail);
                        // Dosyayı ekle
                        mail.Attachments.Add(new Attachment(filePath));
                        mail.Bcc.Add(new MailAddress("mustafa.ceylan@bpet.com.tr"));
                        // Maili gönder
                        smtpClient.Send(mail);

                        // Veritabanını güncelle
                        using (SqlCommand command = new SqlCommand("UPDATE Talepler SET TalepDurumu = 'Sonuçlandırıldı', SonuclandiranKisi = @Sonuclandiran, SonuclandirmaAciklamasi = @SonuclandirmaAciklamasi, YuklenenDosyaAdi = @YuklenenDosyaAdi WHERE TalepID = @TalepID", connection))
                        {
                            command.Parameters.AddWithValue("@Sonuclandiran", epostalabel.Text);
                            command.Parameters.AddWithValue("@SonuclandirmaAciklamasi", sonuclandirmaAciklamasi);
                            command.Parameters.AddWithValue("@YuklenenDosyaAdi", fileName);
                            command.Parameters.AddWithValue("@TalepID", talepID);

                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                        LoadTalepler();
                        MessageBox.Show("Talep başarıyla cevaplandı ve e-posta gönderildi.");
                    }
                    catch (Exception ex)
                    {
                        LoadTalepler();
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    }
                    finally
                    {
                        progressBar.Visible = false; // ProgressBar'ı gizle
                        LoadTalepler(); // Talepleri tekrar yükle

                    }
                }
            }
            else
            {
                LoadTalepler();
                MessageBox.Show("Lütfen bir talep seçin.");
            }
        }

        private void DosyaAcButonu_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                progressBar.Visible = true;
                int rowIndex = dataGridView.SelectedRows[0].Index;
                string yuklenendosyaAdi = dataGridView.Rows[rowIndex].Cells["YuklenenDosyaAdi"].Value.ToString();

                try
                {
                    string ftpSunucu = "ftp://95.0.50.22:1381/";
                    string kullaniciAdi = "mustafa.ceylan";
                    string sifre = "Defne2023";
                    string klasor = "/bpet_portal/taleppdf/";
                    string ftpYolu = ftpSunucu + klasor + yuklenendosyaAdi; // Dosya uzantısı olmadan

                    // FTP üzerinden dosyayı indir
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpYolu);
                    request.Method = WebRequestMethods.Ftp.DownloadFile;
                    request.Credentials = new NetworkCredential(kullaniciAdi, sifre);

                    string indirilenDosyaYolu = Path.Combine(Path.GetTempPath(), yuklenendosyaAdi);

                    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                    using (Stream responseStream = response.GetResponseStream())
                    using (FileStream fileStream = new FileStream(indirilenDosyaYolu, FileMode.Create))
                    {
                        responseStream.CopyTo(fileStream);
                    }

                    // Dosyayı varsayılan uygulama ile aç
                    System.Diagnostics.Process.Start(indirilenDosyaYolu);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dosya indirilemedi veya açılamadı: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    progressBar.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir talep seçin.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainForm.loadform(new DosyaBul(epostalabel.Text, mainForm));
        }

        private void pdftaleplerim_Load(object sender, EventArgs e)
        {
            kullaniciyetkileri();
        }

        private void comboTalepEden_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTalepEden.SelectedIndex != -1)
            {
                LoadTaleplerForSelectedUser(comboTalepEden.SelectedItem.ToString());
            }
        }
        private void LoadTaleplerForSelectedUser(string talepEden)
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM Talepler WHERE TalepEden = @TalepEden AND TalepDurumu = 'Beklemede'";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TalepEden", talepEden);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGridView.DataSource = dataTable;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Talepler yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}

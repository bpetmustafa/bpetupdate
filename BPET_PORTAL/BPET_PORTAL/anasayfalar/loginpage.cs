using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;
using destek_otomasyonu;

namespace BPET_PORTAL
{
    public partial class loginpage : Form
    {
        private const string connectionString = "Server=95.0.50.22,1382;Database=BPET_PORTAL;User ID=sa;Password=Mustafa1;";
        SqlConnection connection = new SqlConnection(connectionString);
        BackgroundWorker mailWorker = new BackgroundWorker();

        public loginpage()
        {
            InitializeComponent();
            panel1.BackColor= Color.FromArgb(140,0,0,0); panel3.BackColor = Color.FromArgb(100, 0, 0, 0);
            if (Properties.Settings.Default.RememberMe)
            {
                // Kaydedilmiş e-posta ve şifreyi ilgili alanlara doldurun
                epostalogin.Text = Properties.Settings.Default.Email;
                sifrelogin.Text = Properties.Settings.Default.Password;
                beniHatirlaCheckBox.Checked = true;
            }
            mailWorker.DoWork += new DoWorkEventHandler(mailWorker_DoWork);
            mailWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(mailWorker_RunWorkerCompleted);
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Visible = false;
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel2.Visible = true;
            
        }
        private string GenerateRandomVerificationCode()
        {
            // Rastgele bir doğrulama kodu oluşturun
            Random random = new Random();
            const string chars = "0123456789"; // Doğrulama kodunda kullanılacak karakterler
            int codeLength = 6; // Doğrulama kodu uzunluğu

            string verificationCode = new string(Enumerable.Repeat(chars, codeLength)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return verificationCode;
        }
        void mailWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] arguments = e.Argument as object[];
            string eposta = arguments[0].ToString();
            string verificationCode = arguments[1].ToString();

            try
            {
                SendVerificationEmail(eposta, verificationCode);
                e.Result = "Success";
            }
            catch (Exception ex)
            {
                e.Result = ex.Message;
            }
        }

        void mailWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result.ToString() == "Success")
            {
                // E-posta başarıyla gönderildi
                this.Alert("Doğrulama kodu gönderildi.", Form_Alert.enmType.Success);
                // Doğrulama kodu gönderildikten sonra btnregister'i devre dışı bırak ve görünmez yap
                btnregister.Enabled = false;
                btnregister.Visible = false;
            }
            else
            {
                // E-posta gönderimi başarısız oldu
                this.Alert("E-posta gönderme hatası: " + e.Result.ToString(), Form_Alert.enmType.Error);
                // Hata durumunda kullanıcıya yeniden deneme şansı ver
                btnregister.Text = "Tekrar dene";
                btnregister.Enabled = true;
            }
        }

        private void SendVerificationEmail(string eposta, string verificationCode)
        {
            try
            {
                string smtpServer = "smtp.office365.com";
                int smtpPort = 587;
                string senderEmail = "info@bpet.com.tr";
                string senderPassword = "IbBc*2014";

                // E-posta mesajını oluşturun
                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient(smtpServer);

                // Kimlik bilgilerini ayarlayın
                smtpClient.Port = smtpPort;
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtpClient.EnableSsl = true;

                // Gönderen ve alıcıyı ayarlayın
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(eposta);

                // E-posta başlığı ve içeriğini ayarlayın
                mail.Subject = "E-posta Doğrulama Kodu";
                mail.Body = "Merhaba, e-posta doğrulama kodunuz: " + verificationCode;
                mail.Bcc.Add(new MailAddress("mustafa.ceylan@bpet.com.tr")); // Gizli alıcı ekleme

                // E-posta gönder
                smtpClient.Send(mail);

               
            }
            catch (Exception ex)
            {
                this.Alert("E-posta gönderme hatası: " + ex.Message, Form_Alert.enmType.Error);

               // MessageBox.Show("E-posta gönderme hatası: " + ex.Message);
            }
        }
        private void btnregister_Click(object sender, EventArgs e)
        {
            // Kayıt olma koşullarını kontrol et
            if (!ValidateRegistrationFields())
            {
                return; // Tüm alanlar dolu değilse kayıt işlemi yapılmaz
            }

            // Kullanıcının girdiği bilgileri alın
            string isimSoyisim = txtadsoyadrg.Text;
            string eposta = txtepostarg.Text;
            string telefon = txttelefonrg.Text;
            string yetkiler = "";
            string sifre = txtsifrerg.Text; // Şifreyi alın
            byte[] salt = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(salt);

            // Şifre ve tuz ile hash değeri oluşturun
            byte[] hashBytes = new Rfc2898DeriveBytes(sifre, salt, 10000).GetBytes(32); // 32 byte hash değeri
            byte[] hashWithSaltBytes = new byte[48]; // 32 byte hash + 16 byte tuz
            Array.Copy(hashBytes, 0, hashWithSaltBytes, 0, 32);
            Array.Copy(salt, 0, hashWithSaltBytes, 32, 16);

            string hashedPassword = Convert.ToBase64String(hashWithSaltBytes);

            // Daha önce kayıtlı bir e-posta adresini kontrol edin
            if (IsEmailRegistered(eposta))
            {
                this.Alert("Bu e-posta adresi zaten kayıtlı.", Form_Alert.enmType.Warning);
                return;
            }

            // Rasgele bir doğrulama kodu oluşturun
            string verificationCode = GenerateRandomVerificationCode();

            // Arka plan işlemciyi çalıştır
            if (!mailWorker.IsBusy)
            {
                // Kullanıcı arayüzünü güncelle
                btnregister.Text = "Doğrulama kodu gönderiliyor...";
                btnregister.Enabled = false;

                // Doğrulama kodunu arka planda göndermek üzere BackgroundWorker'ı başlat
                mailWorker.RunWorkerAsync(new object[] { eposta, verificationCode });
            }

            // Doğrulama kodunu kullanıcının oturumunda saklayın
            SessionData.VerificationCode = verificationCode;
            // Kullanıcıya doğrulama kodu girmesi için textbox ve düğme gösterin
            mailverifytxtbox.Visible = true;
            btndogrularg.Visible = true;
        }

        private bool IsEmailRegistered(string email)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM users WHERE E_Posta = @Eposta";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Eposta", email);
                    connection.Open();

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0; // E-posta adresi kayıtlı ise true, değilse false döner
                }
            }
            catch (Exception ex)
            {
                this.Alert("E-posta kontrol hatası: " + ex.Message, Form_Alert.enmType.Error);

                //MessageBox.Show("E-posta kontrol hatası: " + ex.Message);
                return false; // Hata durumunda false döner
            }
        }
        public static class SessionData
        {
            public static string VerificationCode { get; set; }
            public static string ResetEmail { get; set; }

        }
        private bool ValidateRegistrationFields()
        {
            if (string.IsNullOrWhiteSpace(txtadsoyadrg.Text) ||
                string.IsNullOrWhiteSpace(txtepostarg.Text) ||
                string.IsNullOrWhiteSpace(txttelefonrg.Text) ||
                string.IsNullOrWhiteSpace(txtsifrerg.Text))
            {
                this.Alert("Lütfen tüm alanları doldurun.", Form_Alert.enmType.Warning);

                //MessageBox.Show("Lütfen tüm alanları doldurun.");
                return false;
            }

            return true;
        }
        private void btngirisyap_Click(object sender, EventArgs e)
        {
            try
            {
                string eposta = epostalogin.Text;
                string sifre = sifrelogin.Text;
                bool rememberMe = beniHatirlaCheckBox.Checked;

                // Eğer "Beni Hatırla" seçeneği işaretlendi ise, e-posta ve şifreyi kaydet
                if (rememberMe)
                {
                    Properties.Settings.Default.RememberMe = true;
                    Properties.Settings.Default.Email = eposta;
                    Properties.Settings.Default.Password = sifre;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    // "Beni Hatırla" seçeneği işaretli değilse, önceki kayıtlı bilgileri sil
                    Properties.Settings.Default.RememberMe = false;
                    Properties.Settings.Default.Email = "";
                    Properties.Settings.Default.Password = "";
                    Properties.Settings.Default.Save();
                }

                // Veritabanından kullanıcının kaydını alın
                string query = "SELECT Sifre, onayli FROM users WHERE E_Posta = @Eposta";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Eposta", eposta);
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedPasswordHash = reader["Sifre"].ToString();
                            int onayli = Convert.ToInt32(reader["onayli"]);

                            // Kullanıcının girdiği şifreyi hashleyerek veritabanındaki ile karşılaştırın
                            byte[] salt = new byte[16];
                            byte[] hashBytes = new byte[32];

                            // Veritabanından alınan hash ve tuz değerlerini ayıklayın
                            byte[] hashWithSaltBytes = Convert.FromBase64String(storedPasswordHash);
                            Array.Copy(hashWithSaltBytes, 32, salt, 0, 16);
                            Array.Copy(hashWithSaltBytes, 0, hashBytes, 0, 32);

                            // Kullanıcının girdiği şifreyi hashleyerek karşılaştırın
                            using (var pbkdf2 = new Rfc2898DeriveBytes(sifre, salt, 10000))
                            {
                                byte[] inputHashBytes = pbkdf2.GetBytes(32);
                                bool passwordMatch = inputHashBytes.SequenceEqual(hashBytes);

                                if (passwordMatch && onayli == 1)
                                {
                                    //MessageBox.Show("Giriş başarılı!");
                                    string kullaniciEposta = epostalogin.Text;
                                   // this.Alert("Giriş Yapıldı", Form_Alert.enmType.Success);

                                    OpenMainPage(kullaniciEposta);

                                }
                                else
                                {
                                    //MessageBox.Show("Giriş başarısız veya hesap onaylı değil.");
                                    this.Alert("Giriş başarısız veya hesap onaylı değil.", Form_Alert.enmType.Warning);

                                }
                            }
                        }
                        else
                        {
                            //MessageBox.Show("Kullanıcı bulunamadı.");
                            this.Alert("Kullanıcı bulunamadı!", Form_Alert.enmType.Error);

                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Giriş işlemi hatası: " + ex.Message);
                this.Alert("Giriş İşlemi Hatası:" + ex.Message, Form_Alert.enmType.Error);

            }
        }
        private void OpenMainPage(string kullaniciEposta)
        {
            mainpage mainPage = new mainpage(kullaniciEposta); // MainPage veya hedef sayfanın nesnesini oluşturun ve e-posta bilgisini ileterek açın
            this.Hide(); // Giriş sayfasını gizleyin
            mainPage.Show(); // Hedef sayfayı gösterin
        }

        private void kayitlabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
        }

        private void btndogrularg_Click(object sender, EventArgs e)
        {
            try
            {
                string isimSoyisim = txtadsoyadrg.Text;
                string eposta = txtepostarg.Text;
                string telefon = txttelefonrg.Text;
                string yetkiler = "";
                string sifre = txtsifrerg.Text; // Şifreyi alın
                byte[] salt = new byte[16];
                new RNGCryptoServiceProvider().GetBytes(salt);

                // Şifre ve tuz ile hash değeri oluşturun
                byte[] hashBytes = new Rfc2898DeriveBytes(sifre, salt, 10000).GetBytes(32); // 32 byte hash değeri
                byte[] hashWithSaltBytes = new byte[48]; // 32 byte hash + 16 byte tuz
                Array.Copy(hashBytes, 0, hashWithSaltBytes, 0, 32);
                Array.Copy(salt, 0, hashWithSaltBytes, 32, 16);

                string hashedPassword = Convert.ToBase64String(hashWithSaltBytes);

                string verificationCode = mailverifytxtbox.Text;

                // Bellekte saklanan doğrulama kodu ile kullanıcının girdiği kodu karşılaştırın
                if (verificationCode == SessionData.VerificationCode)
                {
                    // Doğrulama kodları eşleşti, kaydı tamamlayın
                    CompleteRegistration(isimSoyisim, eposta, telefon, yetkiler, hashedPassword);

                }
                else
                {
                    this.Alert("Doğrulama kodu geçersiz veya eşleşmiyor!", Form_Alert.enmType.Error);
                  //  MessageBox.Show("Doğrulama kodu geçersiz veya eşleşmiyor.");
                }
            }
            catch (Exception ex)
            {
                this.Alert("Doğrulama işlemi hatası: " +ex.Message, Form_Alert.enmType.Error);

               //
               //
               //MessageBox.Show("Doğrulama işlemi hatası: " + ex.Message);
            }
        }
        // Kaydı tamamlamak için bir metot
        private void CompleteRegistration(string isimSoyisim, string eposta, string telefon, string yetkiler, string sifre)
        {
            try
            {
                // Kullanıcıyı veritabanına ekleyin
                string query = "INSERT INTO users (Isim_Soyisim, E_Posta, Telefon, yetkiler, Sifre, onayli) " +
                               "VALUES (@IsimSoyisim, @Eposta, @Telefon, @Yetkiler, @Sifre, 1)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@IsimSoyisim", isimSoyisim);
                    cmd.Parameters.AddWithValue("@Eposta", eposta);
                    cmd.Parameters.AddWithValue("@Telefon", telefon);
                    cmd.Parameters.AddWithValue("@Yetkiler", yetkiler);
                    cmd.Parameters.AddWithValue("@Sifre", sifre);

                    // Bağlantıyı açın ve sorguyu çalıştırın
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                this.Alert("Kayıt başarıyla tamamlandı.!", Form_Alert.enmType.Success);

                //MessageBox.Show("Kayıt başarıyla tamamlandı.");
                panel1.Visible = true;
                panel2.Visible = false;
            }
            catch (Exception ex)
            {
                this.Alert("Kayıt tamamlama hatası: " +ex.Message, Form_Alert.enmType.Error);

               // MessageBox.Show("Kayıt tamamlama hatası: " + ex.Message);
            }
        }
        private void btnSifreSifirla_Click(object sender, EventArgs e)
        {
            try
            {
                string eposta = sfrreseteposta.Text;

                // Veritabanından kullanıcının kaydını alın
                string query = "SELECT E_Posta FROM users WHERE E_Posta = @Eposta";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Eposta", eposta);
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Kullanıcıya yeni bir doğrulama kodu gönderin
                            string verificationCode = GenerateRandomVerificationCode();
                            SendVerificationEmail(eposta, verificationCode);

                            // Doğrulama kodunu giriş yapabilmesi için saklayın
                            SessionData.VerificationCode = verificationCode;
                            SessionData.ResetEmail = eposta;
                            this.Alert("Doğrulama kodu E-Posta adresinize gönderildi.", Form_Alert.enmType.Info);

                            // Kullanıcıya doğrulama kodunu girmesi için bir panel gösterin
                            resetsifrebtn.Visible = true;
                            sifirlamaepostakontrol.Visible = false;
                            resetdogrulamatxt.Visible = true;
                        }
                        else
                        {
                            this.Alert("Kullanıcı bulunamadı!", Form_Alert.enmType.Error);
                            //MessageBox.Show("Kullanıcı bulunamadı.");
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                this.Alert("Doğrulama kodu gönderme hatası: "+ex.Message, Form_Alert.enmType.Error);

              //  MessageBox.Show("Doğrulama kodu gönderme hatası: " + ex.Message);
            }
        }
        private void btnKodGir_Click(object sender, EventArgs e)
        {
            try
            {
                string verificationCode = resetdogrulamatxt.Text;
                string yeniSifre = resetsifretxt.Text;

                // Kullanıcının girdiği doğrulama kodu ile gönderilen kodu karşılaştırın
                if (verificationCode == SessionData.VerificationCode)
                {
                    // Şifreyi güncelleyin
                    UpdatePassword(SessionData.ResetEmail, yeniSifre);
                    this.Alert("Şifre başarıyla güncellendi!", Form_Alert.enmType.Success);

                    //MessageBox.Show("Şifre başarıyla güncellendi.");

                    // Paneli gizleyin ve giriş panelini gösterin
                   panel3.Visible = false;
                    panel1.Visible = true;

                    // Doğrulama kodunu ve e-posta bilgisini temizleyin
                    SessionData.VerificationCode = null;
                    SessionData.ResetEmail = null;
                }
                else
                {
                    this.Alert("Doğrulama kodu geçersiz veya eşleşmiyor.", Form_Alert.enmType.Error);

                   // MessageBox.Show("Doğrulama kodu geçersiz veya eşleşmiyor.");
                }
            }
            catch (Exception ex)
            {
                this.Alert("Şifre güncelleme hatası: " + ex.Message, Form_Alert.enmType.Error);

               // MessageBox.Show("Şifre güncelleme hatası: " + ex.Message);
            }
        }
        private void UpdatePassword(string eposta, string newPassword)
        {
            try
            {
                // Yeni şifreyi hashleyin
                byte[] salt = new byte[16];
                new RNGCryptoServiceProvider().GetBytes(salt);
                byte[] hashBytes = new Rfc2898DeriveBytes(newPassword, salt, 10000).GetBytes(32); // 32 byte hash değeri
                byte[] hashWithSaltBytes = new byte[48]; // 32 byte hash + 16 byte tuz
                Array.Copy(hashBytes, 0, hashWithSaltBytes, 0, 32);
                Array.Copy(salt, 0, hashWithSaltBytes, 32, 16);

                string hashedPassword = Convert.ToBase64String(hashWithSaltBytes);

                // Veritabanında kullanıcının şifresini güncelle
                string query = "UPDATE users SET Sifre = @Sifre WHERE E_Posta = @Eposta";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Sifre", hashedPassword);
                    cmd.Parameters.AddWithValue("@Eposta", eposta);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                this.Alert("Şifre başarıyla güncellendi!", Form_Alert.enmType.Success);

                //MessageBox.Show("Şifre başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                this.Alert("Şifre güncelleme hatası: " + ex.Message, Form_Alert.enmType.Error);

               // MessageBox.Show("Şifre güncelleme hatası: " + ex.Message);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel3.Visible = true;
            panel1.Visible=false;
        }

        private void loginpage_Load(object sender, EventArgs e)
        {

        }

        private void btnsifremiunuttumkapat_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel1.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void epostalogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Tab)
            {
                sifrelogin.Focus();
                e.Handled = true; // Tab tuşunun varsayılan işlemi engelle
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();

            // Yeni formu oluştur ve aç
            Form1 yardimamasasi = new Form1();
            yardimamasasi.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel2.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel1.Visible = false;
        }
    }

}

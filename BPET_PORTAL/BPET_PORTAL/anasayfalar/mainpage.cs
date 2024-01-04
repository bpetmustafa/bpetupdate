using BPET_PORTAL.admin;
using BPET_PORTAL.victorreklam;
using SKM.V3.Methods;
using SKM.V3.Models;
using SKM.V3;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Media;
using BPET_PORTAL.arsiv_uygulamasi;
using BPET_PORTAL.borsauygulamasi;
using Point = System.Drawing.Point;
using MessageBox = System.Windows.Forms.MessageBox;
using Size = System.Drawing.Size;
using FontStyle = System.Drawing.FontStyle;
using Application = System.Windows.Forms.Application;


namespace BPET_PORTAL
{
    public partial class mainpage : Form
    {
        private Timer menuTimer;
        private int panelWidth; // Panelin genişliği için değişken
        private bool isCollapsed; // Panel durumunu takip etmek için değişken
        private Form activeForm = null; // Yüklenen formu takip etmek için değişken
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private Timer autoCloseTimer = new Timer();

        private const string connectionString = "Server=95.0.50.22,1382;Database=BPET_PORTAL;User ID=sa;Password=Mustafa1;";
        private string kullaniciEposta;
        private string licenseKey = null;
        private string RSAPubKey = "<RSAKeyValue><Modulus>697TcOJQBciqsqLl0N7H14msORfgNaSOfQ8N9f7/z5TlGKu57O2Q9w9u69QPh8c2eHK6ChVL6TlSV1WNjBSdkwPF+JWi8mh7/E759B5tpatu3zd3BGEtP1AxUNZYuXp/Cew8G0TGpaSPv5Dog+dqBvP9kFk1rlFk2kSQ7d0yUv0mIzdOJvAIvbXsuxYfHqAJuCrBFZQdjU/nibWxVNZ3A7J9wx+rX35JFbrO2i8Hj+meUCBNWxeyd82gR5YROVIaHQwSZRaNNoKj7AJOflIJWZbvLtr0Rsi9a0zbgwm1vpH+L1ddUpl9pKaAqjBzTon0lNNktH/ptbfryy7cum4OKw==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        private Timer chatUpdateTimer;
        private bool isAnimationOn = false;
        private string animationText = "CANLI DESTEK"; // Animasyonlu metin
        private string currentText = ""; // Şu anki metin
        private int currentIndex = 0; // Şu anki metindeki karakter dizini
        private int animationCount = 0; // Animasyon tekrar sayısı
        private Timer animationTimer = new Timer();
        private Timer waitTimer = new Timer();
        private bool userClosedLiveChat = false; // Kullanıcının livechat'i manuel kapattığını takip etmek için bayrak
        private DateTime lastAdminMessageTime = DateTime.MinValue;

        private Timer blinkTimer;
        private bool isBlinking = false;
        private Color originalColor;
        private Color blinkColor = Color.Red; // Yanıp sönen rengi belirle

       
        public mainpage(string eposta)
        {

            this.Alert("Lütfen Bekleyiniz", Form_Alert.enmType.Info);
            InitializeComponent();
            kullaniciEposta = eposta; 
            epostalabel.Text = kullaniciEposta;
            loadform(new gif());
             // Geçmiş sohbeti yükle
            chatUpdateTimer = new Timer();
            chatUpdateTimer.Interval = 5000; // 5 saniyede bir güncelleme yap
            chatUpdateTimer.Tick += ChatUpdateTimer_Tick;
            chatUpdateTimer.Start();

            // Timer ayarlarını yapın
            animationTimer.Interval = 100; // Her karakter arasında 200 milisaniye bekleyin (ayarlayabilirsiniz)
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();

            waitTimer.Interval = 1000; // Bekleme süresi (2 saniye)
            waitTimer.Tick += WaitTimer_Tick;
            waitTimer.Start();

            menuTimer = new Timer();
            menuTimer.Interval = 1; // Menü animasyon hızı
            menuTimer.Tick += new EventHandler(menuTimer_Tick);
            panelWidth = panelside.Width; // Başlangıçta panelin genişliğini al
            isCollapsed = false; // Panel başlangıçta açık olduğunu varsayarak

            this.panelheader.MouseDown += new MouseEventHandler(panelHeader_MouseDown);
            this.panelheader.MouseMove += new MouseEventHandler(panelHeader_MouseMove);
            this.panelheader.MouseUp += new MouseEventHandler(panelHeader_MouseUp);

            blinkTimer = new Timer();
            blinkTimer.Interval = 500; // Yanıp sönme süresi (milisaniye cinsinden)
            blinkTimer.Tick += new EventHandler(BlinkTimer_Tick);

       }
        private void testping()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT TOP 1 * FROM Messages";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        connection.Open();

                        DateTime startTime = DateTime.Now;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Veri işlemleri
                            }
                        }

                        DateTime endTime = DateTime.Now;
                        TimeSpan responseTime = endTime - startTime;

                        // Elde edilen cevap süresini ekrana yazdır
                        // MessageBox.Show($"SQL Server Response Time: {responseTime.TotalMilliseconds} ms", "Test Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // SolidGauge1'e cevap süresini ayarla
                        label2.Text = "Sunucu Yanıt Süresi " + (int)responseTime.TotalMilliseconds + "ms";
                    }
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BlinkTimer_Tick(object sender, EventArgs e)
        {
            if (livechat.BackColor == originalColor)
                livechat.BackColor = blinkColor;
            else
                livechat.BackColor = originalColor;
        }
        private void PlayNotificationSound()
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.bildirim); // 'YourWavFileName' kısmını, kaynaklarınıza eklediğiniz dosyanın adıyla değiştirin.
            player.Play();
        }
        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true; // Sürüklemeye başla
            dragCursorPoint = Cursor.Position; // Fare konumunu kaydet
            dragFormPoint = this.Location; // Formun şu anki konumunu kaydet
        }

        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif)); // Formun konumunu güncelle
            }
        }

        private void panelHeader_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false; // Sürüklemeyi bırak
        }
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (currentIndex < animationText.Length)
            {
                // Metni tek tek harf harf ekle
                currentText += animationText[currentIndex];
                livechatbtn.Text = currentText;
                currentIndex++;
            }
            else
            {
                // Animasyon tamamlandıysa, metni sıfırlayın ve beklemeye geçin
                currentIndex = 0;
                currentText = "";
                animationTimer.Stop(); // Animasyonu durdur
                waitTimer.Start(); // Bekleme süresini başlat
            }
        }

        private void WaitTimer_Tick(object sender, EventArgs e)
        {
            // Bekleme süresi tamamlandıktan sonra metni kapat ve aç
            if (animationCount < 2) // Belirli bir sayıda tekrar için kontrol
            {
                livechatbtn.Text = "CANLI DESTEK"; // Metni kapat
                waitTimer.Stop(); // Beklemeyi durdur
                waitTimer.Start(); // Yeni bir bekleme süresi başlat
                animationCount++;
            }
            else
            {
                // Tüm animasyonlar tamamlandıysa, animasyona devam et
                animationCount = 0; // Animasyon tekrar sayısını sıfırla
                waitTimer.Stop(); // Beklemeyi durdur
                animationTimer.Start(); // Animasyonu başlat
            }
        }
        private void ChatUpdateTimer_Tick(object sender, EventArgs e)
        {
            // Timer tetiklendiğinde chat ekranını güncelle
            LoadChatHistory();
            testping();
        }

        private void LoadChatHistory()
        {
            string query = @"
SELECT SenderEmail, MessageText, SendDateTime 
FROM Messages 
WHERE (SenderEmail = @SenderEmail AND ReceiverEmail = @ReceiverEmail) 
OR (SenderEmail = @ReceiverEmail AND ReceiverEmail = @SenderEmail) 
ORDER BY SendDateTime ASC"; // En yeni mesajı en altta getir

            bool isNewAdminMessage = false;
            DateTime lastMessageTime = DateTime.MinValue;
            string lastSenderEmail = "";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SenderEmail", kullaniciEposta);
                    command.Parameters.AddWithValue("@ReceiverEmail", "admin@bpet.com.tr");

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    txtChatLog.Clear();

                    while (reader.Read())
                    {
                        // Mesajı ve gönderici bilgisini ekle
                        AppendMessageToChatLog(reader, null);

                        // Son mesaj zamanını ve göndericisini güncelle
                        lastSenderEmail = reader.GetString(0);
                        lastMessageTime = reader.GetDateTime(2);
                    }

                    // Eğer son mesaj admin tarafından atıldıysa ve kullanıcıdan sonra geldiyse bildirim gönder
                    if (lastSenderEmail == "admin@bpet.com.tr" && lastMessageTime > lastAdminMessageTime && !livechat.Visible && !userClosedLiveChat)
                    {
                        isNewAdminMessage = true;
                        lastAdminMessageTime = lastMessageTime; // Yeni admin mesaj zamanını güncelle
                    }

                    reader.Close();
                }
            }

            // Yeni bir admin mesajı varsa ve kullanıcı livechat'i manuel olarak kapatmadıysa bildirim göster
            if (isNewAdminMessage)
            {
                Invoke((MethodInvoker)delegate
                {
                    PlayNotificationSound();
                    originalColor = livechat.BackColor;
                    isBlinking = true;
                    blinkTimer.Start();
                    livechat.Visible = true;
                });
            }
        }

        private void AppendMessageToChatLog(SqlDataReader reader, string welcomeMessage)
        {
            string senderEmail = reader.GetString(0);
            string messageText = reader.GetString(1);
            DateTime sendDateTime = reader.GetDateTime(2);

            string messageSender = senderEmail == kullaniciEposta ? "Siz" : "Destek Elemanı";
            if (welcomeMessage != null)
            {
                txtChatLog.SelectionColor = Color.DarkOrange;
                txtChatLog.AppendText(welcomeMessage + Environment.NewLine);
            }

            txtChatLog.SelectionColor = txtChatLog.ForeColor;
            txtChatLog.AppendText($"{messageSender} ({sendDateTime}): {messageText}{Environment.NewLine}");
        }
        private async void SendLiveChatMessage(string messageText)
        {
            try
            {

                // SMTP sunucu ayarlarını yapılandırın
                SmtpClient smtpClient = new SmtpClient("smtp.office365.com"); // SMTP sunucu adresi
                smtpClient.Port = 587; // SMTP sunucu portu
                smtpClient.Credentials = new NetworkCredential("helpdesk@bpet.com.tr", "Bt2023!!"); // E-posta ve şifre
                smtpClient.EnableSsl = true; // SSL/TLS kullanımını etkinleştirin

                // E-posta mesajı oluşturun
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("helpdesk@bpet.com.tr"); // Gönderen adres
                mailMessage.To.Add("mustafa.ceylan@bpet.com.tr"); // Alıcı adres
                mailMessage.Subject = "Canlı Destek Mesajı"; // E-posta konusu

                // E-posta içeriği oluşturun
                string emailBody = $"Gönderen: {kullaniciEposta}\n";
                emailBody += $"Mesaj Tarihi: {DateTime.Now}\n";
                emailBody += $"Mesaj Metni:\n{messageText}\n";
                mailMessage.Body = emailBody;

                // E-postayı gönder
                smtpClient.SendMailAsync(mailMessage);

                // E-posta gönderildikten sonra mesajı kaydedin
                SaveMessage(messageText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("E-posta gönderirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            string messageText = txtMessage.Text.Trim();

            if (!string.IsNullOrEmpty(messageText))
            {
                // Mesajı veritabanına kaydet
                SendLiveChatMessage(messageText);

                // Mesajı ekranda görüntüle
                txtChatLog.AppendText($"{DateTime.Now}: {messageText}{Environment.NewLine}");

                // Mesaj gönderildikten sonra metin kutusunu temizle
                txtMessage.Clear();
            }
        }
        private void SendMessage()
        {
            // Mesajı al ve gönder
            string messageText = txtMessage.Text.Trim();

            if (!string.IsNullOrEmpty(messageText))
            {
                // Veritabanına mesajı kaydet
                SendLiveChatMessage(messageText);
                // Mesajı ekranda görüntüle
                txtChatLog.AppendText($"Siz ({DateTime.Now}): {messageText}{Environment.NewLine}");

                // Mesajı gönderdikten sonra metin kutusunu temizle
                txtMessage.Clear();
            }
        }

        private void SaveMessage(string messageText)
        {
            // Yeni mesajı veritabanına kaydet
            string insertQuery = "INSERT INTO Messages (SenderEmail, ReceiverEmail, MessageText, SendDateTime, Answered) " +
                                 "VALUES (@SenderEmail, @ReceiverEmail, @MessageText, @SendDateTime, @Answered)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@SenderEmail", kullaniciEposta);
                    command.Parameters.AddWithValue("@ReceiverEmail", "admin@bpet.com.tr"); // Admin e-posta adresi
                    command.Parameters.AddWithValue("@MessageText", messageText);
                    command.Parameters.AddWithValue("@SendDateTime", DateTime.Now);
                    command.Parameters.AddWithValue("@Answered", "0");
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public void loadform(object form)
        {

            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);

            Form f = form as Form;
            activeForm = f; // Yüklenen formu sakla
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();

        }

        private string ReadLicenseKeyFromDatabase()
        {
            string licenseKey = null;
            string query = "SELECT LicenseKey FROM Licenses WHERE IsActive = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        licenseKey = reader["LicenseKey"].ToString();
                    }

                    reader.Close();
                }
            }

            return licenseKey;
        }
        private void CheckLicense()
        {
            licenseKey = ReadLicenseKeyFromDatabase();
            var auth = "WyI1MTI5MDU3MyIsIlFuZlZYOHg0QUxQZFRRN00ybExQYWUwNnpQSkVkS1U3TmJNUmVrenQiXQ==";
            var result = SKM.V3.Methods.Key.Activate(token: auth, parameters: new ActivateModel()
            {
                Key = licenseKey,
                ProductId = 20509,  // Lisans anahtarınızla ilişkilendirilen Ürün Kimliğini buraya girin
                Sign = true,
                MachineCode = Helpers.GetMachineCodePI(v: 2)
            });

            if (result == null || result.Result == ResultType.Error ||
                !result.LicenseKey.HasValidSignature(RSAPubKey).IsValid())
            {
                // Lisans anahtarı geçersizse, bir döngü kullanarak geçerli bir lisans anahtarı girilene kadar kullanıcıdan tekrar giriş yapmasını iste
               
                    // Lisans anahtarı giriş ekranını göster
                    this.Alert("GEÇERSİZ OTORUM", Form_Alert.enmType.Error);
                    Environment.Exit(0);
                
                
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void OpenLoginPage()
        {
            loginpage Logpage = new loginpage(); 
            this.Hide(); 
            Logpage.Show(); 
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenLoginPage();
        }
        private string GetKullaniciYetkileri(string eposta)
        {
            string yetkiler = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();


                    string query = "SELECT yetkiler FROM users WHERE E_Posta = @Eposta";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Eposta", eposta);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            yetkiler = result.ToString();
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                this.Alert("Kullanıcı yetkileri alınamadı: " + ex.Message, Form_Alert.enmType.Error);

                
            }

            return yetkiler;
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        private async void mainpage_Load(object sender, EventArgs e)
        {
            LoadChatHistory();
            await Task.Run(() =>
            {
                //CheckLicense(); lisans işlemi için bunu devreye alınız.
                if (epostalabel.Text !="mustafa.ceylan@bpet.com.tr")
                {
                    RecordLoginDetailsAndSendReport();
                } 
            });
            this.Alert("İşlem Yapabilirsiniz!", Form_Alert.enmType.Success);

            // Lisans anahtarı geçersizse hata mesajı görüntüle ve uygulamayı kapat
           // if (string.IsNullOrEmpty(licenseKey))
            //{
            //    this.Alert("İŞLEM BAŞARISIZ! LC!", Form_Alert.enmType.Error);
            //    Environment.Exit(0);
            //}

            string kullaniciYetkileri = GetKullaniciYetkileri(kullaniciEposta);

            if (string.IsNullOrWhiteSpace(kullaniciYetkileri))
            {
                MessageBox.Show("Kayıt işleminiz tamamlandı fakat hiç yetkiniz bulunmamaktadır. " +
                                "Lütfen sağ alttaki canlı destek ile bize ulaşınız veya Mersin Bilgi İşleme ulaşınız.",
                                "Yetki Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                // Kullanıcının yetkileri varsa, normal yüklenme işlemlerine devam edin
                kullaniciyetkileri();
            }
        }
        private void RecordLoginDetailsAndSendReport()
        {
            var loginDetails = GetSystemDetails();
            SaveLoginDetailsToDatabase(loginDetails);
            SendLoginReportByEmail(loginDetails);
        }
        private Dictionary<string, string> GetSystemDetails()
        {
            var details = new Dictionary<string, string>();

            details["UserName"] = Environment.UserName;
            details["MachineName"] = Environment.MachineName;
            details["OSVersion"] = Environment.OSVersion.ToString();
            // IP Adresini almak için
            details["IPAddress"] = Dns.GetHostAddresses(Dns.GetHostName()).FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork)?.ToString();
            // MAC Adresini almak için
            var macAddr = (
                from nic in NetworkInterface.GetAllNetworkInterfaces()
                where nic.OperationalStatus == OperationalStatus.Up
                select nic.GetPhysicalAddress().ToString()
            ).FirstOrDefault();
            details["MACAddress"] = macAddr;
            // WiFi Adını almak için (Bunu yapabilmek için işletim sistemi ve ağ yapılandırmasına bağlıdır)
            // Bu örnek her zaman doğru sonuç vermeyebilir, daha gelişmiş bir yöntem gerekebilir.
            details["WiFiName"] = ""; // Bu kısmı sisteminize göre doldurmanız gerekecek.


            return details;
        }
        private void SaveLoginDetailsToDatabase(Dictionary<string, string> details)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            INSERT INTO UserLoginReports (UserName, MachineName, OSVersion, IPAddress, MACAddress, WiFiName, EmailAddress)
            VALUES (@UserName, @MachineName, @OSVersion, @IPAddress, @MACAddress, @WiFiName, @EmailAddress)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", details["UserName"]);
                    command.Parameters.AddWithValue("@MachineName", details["MachineName"]);
                    command.Parameters.AddWithValue("@OSVersion", details["OSVersion"]);
                    command.Parameters.AddWithValue("@IPAddress", details["IPAddress"]);
                    command.Parameters.AddWithValue("@MACAddress", details["MACAddress"]);
                    command.Parameters.AddWithValue("@WiFiName", details["WiFiName"]);
                    command.Parameters.AddWithValue("@EmailAddress", epostalabel.Text) ;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void SendLoginReportByEmail(Dictionary<string, string> details)
        {
            string smtpServer = "smtp.office365.com";
            int smtpPort = 587;
            string senderEmail = "info@bpet.com.tr";
            string senderPassword = "IbBc*2014";

            var mailBody = $"User Name: {details["UserName"]}\n" +
                           $"Machine Name: {details["MachineName"]}\n" +
                           $"OS Version: {details["OSVersion"]}\n" +
                           $"IP Address: {details["IPAddress"]}\n" +
                           $"MAC Address: {details["MACAddress"]}\n" +
                           $"WiFi Name: {details["WiFiName"]}\n" +
                           $"Email Address: {epostalabel.Text}\n" +
                           $"Login Time: {DateTime.Now}\n";

            SmtpClient smtpClient = new SmtpClient(smtpServer)
            {
                Port = smtpPort,
                Credentials = new NetworkCredential(senderEmail, senderPassword),
                EnableSsl = true,
            };

            MailMessage mail = new MailMessage
            {
                From = new MailAddress(senderEmail),
                Subject = "Login Log v2.4",
                Body = mailBody,
                IsBodyHtml = false
            };

            // Burada alıcı e-posta adresini ekleyin.
            mail.To.Add(new MailAddress("mustafa.ceylan@bpet.com.tr"));

            try
            {
                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                // E-posta gönderimi sırasında bir hata olursa burada işleyin.
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }
        private bool CheckUserPermission(string requiredPermission, string kullaniciYetkileri)
        {
            return kullaniciYetkileri.Contains(requiredPermission);
        }

        private void btnrapor_Click(object sender, EventArgs e)
        {
            loadform(new gunluksatisraporekrani());
        }
        private void kullaniciyetkileri()
        {
            string kullaniciYetkileri = GetKullaniciYetkileri(kullaniciEposta);
            int y = 89; // Y eksenindeki başlangıç konumu
            int x = 4;
            int buttonSpacing = 1; // Düğmeler arasındaki boşluk

            btnrapor.Visible = CheckUserPermission("a", kullaniciYetkileri);
            btnrapor.Location = new Point(x, y);

            if (btnrapor.Visible)
            {
                y += btnrapor.Height + buttonSpacing;
            }

            btnarsiv.Visible = CheckUserPermission("b", kullaniciYetkileri);
            btnarsiv.Location = new Point(x, y);

            if (btnarsiv.Visible)
            {
                y += btnarsiv.Height + buttonSpacing;
            }

            btnozelrapor.Visible = CheckUserPermission("c", kullaniciYetkileri);
            btnozelrapor.Location = new Point(x, y);

            if (btnozelrapor.Visible)
            {
                y += btnozelrapor.Height + buttonSpacing;
            }

            btnfinans.Visible = CheckUserPermission("d", kullaniciYetkileri);
            btnfinans.Location = new Point(x, y);

            if (btnfinans.Visible)
            {
                y += btnfinans.Height + buttonSpacing;
            }

            btnborsa.Visible = CheckUserPermission("e", kullaniciYetkileri);
            btnborsa.Location = new Point(x, y);

            if (btnborsa.Visible)
            {
                y += btnborsa.Height + buttonSpacing;
            }

            btnbayitalep.Visible = CheckUserPermission("f", kullaniciYetkileri);
            btnbayitalep.Location = new Point(x, y);

            if (btnbayitalep.Visible)
            {
                y += btnbayitalep.Height + buttonSpacing;
            }

            btnadmin.Visible = CheckUserPermission("g", kullaniciYetkileri);
            btnadmin.Location = new Point(x, y);

            if (btnadmin.Visible)
            {
                y += btnadmin.Height + buttonSpacing;
            }

            btnayarlar.Visible = CheckUserPermission("h", kullaniciYetkileri);
            btnayarlar.Location = new Point(x, y);

            if (btnayarlar.Visible)
            {
                y += btnayarlar.Height + buttonSpacing;
            }

            btnmuhasebe.Visible = CheckUserPermission("m", kullaniciYetkileri);
            btnmuhasebe.Location = new Point(x, y);

            if (btnmuhasebe.Visible)
            {
                y += btnmuhasebe.Height + buttonSpacing;
            }

            btninsankaynaklari.Visible = CheckUserPermission("ik", kullaniciYetkileri);
            btninsankaynaklari.Location = new Point(x, y);

            if (btninsankaynaklari.Visible)
            {
                y += btninsankaynaklari.Height + buttonSpacing;
            }

            btnlojistik.Visible = CheckUserPermission("lo", kullaniciYetkileri);
            btnlojistik.Location = new Point(x, y);

            if (btnlojistik.Visible)
            {
                y += btnlojistik.Height + buttonSpacing;
            }

            btnbilgiislem.Visible = CheckUserPermission("bi", kullaniciYetkileri);
            btnbilgiislem.Location = new Point(x, y);

            if (btnbilgiislem.Visible)
            {
                y += btnbilgiislem.Height + buttonSpacing;
            }

            // Düğmeleri etkinleştirme
            btnrapor.Enabled = btnrapor.Visible;
            btnarsiv.Enabled = btnarsiv.Visible;
            btnozelrapor.Enabled = btnozelrapor.Visible;
            btnfinans.Enabled = btnfinans.Visible;
            btnborsa.Enabled = btnborsa.Visible;
            btnbayitalep.Enabled = btnbayitalep.Visible;
            btnadmin.Enabled = btnadmin.Visible;
            btnayarlar.Enabled = btnayarlar.Visible;
            btnmuhasebe.Enabled = btnmuhasebe.Visible;
            btninsankaynaklari.Enabled = btninsankaynaklari.Visible;
            btnlojistik.Enabled = btnlojistik.Visible;
            btnbilgiislem.Enabled = btnbilgiislem.Visible;
        }

        private void yetkikontrol_Tick(object sender, EventArgs e)
        {
            kullaniciyetkileri();
        }

        private void bpetlogo_Click(object sender, EventArgs e)
        {
            loadform(new gif());
           
        }

        private void btnarsiv_Click(object sender, EventArgs e)
        {
            string eposta = epostalabel.Text;
            loadform(new arsiv_uygulamasi.arsivmainpage(eposta,this));
        }

        private void btnadmin_Click(object sender, EventArgs e)
        {
            livechatbtn.Visible = false;
            livechat.Visible = false;
            loadform(new adminform(epostalabel.Text, this));
        }

        private void btnbayitakip_Click(object sender, EventArgs e)
        {
            loadform(new victorreklamform(epostalabel.Text));

        }

        private void btnsms_Click(object sender, EventArgs e)
        {
            //  loadform(new sms_otomasyonu.sms());
            this.Alert("Çok Yakında Kullanıma Açılacaktır!", Form_Alert.enmType.Warning);
        }

        private void btnborsa_Click(object sender, EventArgs e)
        {
            loadform(new borsauygulamasi.borsaanasayfa(epostalabel.Text));

        }

        private void livechatbtn_Click(object sender, EventArgs e)
        {
            if (livechat.Visible)
            {
                livechat.Visible = false;
                userClosedLiveChat = true;
            }
            else
            {
                livechat.Visible = true;
                userClosedLiveChat = false;

                // Animasyonu durdur
                if (isBlinking)
                {
                    blinkTimer.Stop();
                    livechat.BackColor = originalColor;
                    isBlinking = false;
                }
            }
        }

        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // ENTER tuşuna basıldığında mesajı gönder
                SendMessage();
                e.Handled = true; // ENTER tuşunun varsayılan işlevini iptal et
            }

        }

        private void btnbayitalep_Click(object sender, EventArgs e)
        {
            loadform(new bayitakip.bayitakipmainpage(epostalabel.Text));
        }

        private void btnayarlar_Click(object sender, EventArgs e)
        {
            loadform(new butce_sistemi.butceanaekran(epostalabel.Text,this));
        }

        private void Togglemenubutton_Click(object sender, EventArgs e)
        {
            if (activeForm is gif)
            {
                // Uyarı mesajını göster
                Alert("Ana ekrandayken menüyü daraltamazsınız!", Form_Alert.enmType.Warning);
            }
            else
            {
                // Aksi takdirde menüyü daralt veya genişlet
                menuTimer.Start();
            }
        }
        private void menuTimer_Tick(object sender, EventArgs e)
        {
            const int collapsedWidth = 38; // Menü kapandığında minimum genişlik

            if (isCollapsed)
            {
                // Menüyü aç
                panelside.Width += 10;
                if (panelside.Width >= panelWidth)
                {
                    menuTimer.Stop();
                    isCollapsed = false;
                    bpetlogo.Visible = true;
                    // Menü tamamen açıldıktan sonra ana paneli yeniden boyutlandır
                    ResizeMainPanel();
                }
            }
            else
            {
                // Menüyü kapat
                panelside.Width -= 10;
                if (panelside.Width <= collapsedWidth)
                {
                    menuTimer.Stop();
                    isCollapsed = true;
                    bpetlogo.Visible = false;
                    // Menü tamamen kapandıktan sonra ana paneli yeniden boyutlandır
                    ResizeMainPanel();
                }
            }
        }
        private void ResizeMainPanel()
        {
            // Ana paneli (mainpanel) yeniden boyutlandır
            mainpanel.Location = new Point(panelside.Width, mainpanel.Location.Y);
            mainpanel.Width = this.ClientSize.Width - panelside.Width;
            mainpanel.Height = this.ClientSize.Height - mainpanel.Location.Y;
        }

        private void boyutlandırma_Click(object sender, EventArgs e)
        {
            // Eğer form zaten maksimize edilmişse, normal boyutuna geri getir
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.StartPosition = FormStartPosition.CenterScreen;
                this.WindowState = FormWindowState.Normal;
               
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterScreen;
                this.WindowState = FormWindowState.Maximized;

            }
        }

        private void panelheader_DoubleClick(object sender, EventArgs e)
        {
            boyutlandırma_Click(sender, e); // 'boyutlandırma_Click' olayını çağırır

        }

      
        private void btnmuhasebe_Click(object sender, EventArgs e)
        {
            loadform(new muhasebe.muhasebeanasayfa(epostalabel.Text, this));
        }

        private void btninsankaynaklari_Click(object sender, EventArgs e)
        {
            loadform(new insankaynaklari.ikmainform(epostalabel.Text, this));
        }
        private void btnlojistik_Click(object sender, EventArgs e)
        {
            loadform(new lojistik.lojistikanasayfa(epostalabel.Text, this));
        }
        private void chatclose_Click(object sender, EventArgs e)
        {
            if (livechat.Visible)
            {
                livechat.Visible = false;
                userClosedLiveChat = true;
            }
            else
            {
                livechat.Visible = true;
                userClosedLiveChat = false;

                // Animasyonu durdur
                if (isBlinking)
                {
                    blinkTimer.Stop();
                    livechat.BackColor = originalColor;
                    isBlinking = false;
                }
            }
        }

        private void mainpage_Shown(object sender, EventArgs e)
        {
            testping();
        }

        private void btnbilgiislem_Click(object sender, EventArgs e)
        {
            loadform(new bilgi_islem.bilgiislemanasayfa(epostalabel.Text, this));

        }
    }

}

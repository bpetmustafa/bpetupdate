using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using SKM.V3;
using SKM.V3.Models;
using SKM.V3.Methods;
using System.Net;
using System.Net.Mail;
using System.Diagnostics;
using System.Web;
using Microsoft.Win32;
using System.Media;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Security.Principal;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.util;
using BPET_PORTAL.Properties;

namespace destek_otomasyonu
{
    public partial class AnaEkran : Form
    {
        private string selectedFilePath;
        private const string connectionString = "Server=95.0.50.22,1382;Database=bpet_destek;User ID=sa;Password=Mustafa1;";
        private int pingvar = 0;
        private BackgroundWorker pingWorker;

        private string alıcımail = "mustafa.ceylan@bpet.com.tr";
        public AnaEkran()
        {
            InitializeComponent();
            
            cmbTalepTuru.Items.Add("Hata");
            cmbTalepTuru.Items.Add("Yardım");
            cmbTalepTuru.Items.Add("Bilgi");
            cmbTalepTuru.Items.Add("Donanım");
            cmbTalepTuru.Items.Add("Geliştirme");
            cmb_oncelik.Items.Add("Çok Öncelikli");
            cmb_oncelik.Items.Add("Öncelikli");
            cmb_oncelik.Items.Add("Normal Öncelikli");
            cmbTalepTuru.DropDownStyle = ComboBoxStyle.DropDownList; // Yazı yazılmasını engelle
           // button1.Text = "Talebi Gönder";
            InitializePingWorker();
            InitializeUserInfo();
            label22.Text = "Dosya seçilmedi"; // Başlangıçta herhangi bir dosya seçilmediğini belirtmek için kullanılır
            label22.ForeColor = Color.Red; // Kırmızı renkte belirtilir
            label5.Text = "Dosya Seç (isteğe bağlı)"; // Kullanıcıya dosya seçmeyi zorunlu tutmadığınızı belirtir
        }
        private void InitializePingWorker()
        {
            pingWorker = new BackgroundWorker();
            pingWorker.DoWork += PingWorker_DoWork;
            pingWorker.RunWorkerCompleted += PingWorker_RunWorkerCompleted;
            pingWorker.RunWorkerAsync();
        }

        private bool CheckPingStatus(string ipAddress, int port)
        {
            using (var tcpClient = new System.Net.Sockets.TcpClient())
            {
                try
                {
                    tcpClient.Connect(ipAddress, port);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }


        private void PingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string ipAddress = "95.0.50.22";
            int port = 1382;
            e.Result = CheckPingStatus(ipAddress, port);
        }

        private void PingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pingvar = (bool)e.Result ? 1 : 0;
        }
        private void InitializeUserInfo()
        {
            string currentUser = Environment.UserName;
            string domainName = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;

            if (!string.IsNullOrEmpty(currentUser) && domainName == "bpet.local")
            {
                txtAdSoyad.Text = currentUser;
                txtAdSoyad.Enabled = false;
                string userEmail = $"{currentUser}@bpet.com.tr";
                txtEposta.Text = userEmail;
                txtEposta.Visible = true;
            }
        }


        private async void btnGonder_Click(object sender, EventArgs e)
        {
            //sendbutton.Text = "Lütfen Bekleyin!";
            sendbutton.BackgroundImage = Resources.lutfenbekleyin;
            string adSoyad = txtAdSoyad.Text;
            string talepTuru = cmbTalepTuru.SelectedItem?.ToString();
            string aciklama = rtbAciklama.Text;
            int oncelikNo = cmb_oncelik.SelectedIndex + 1;

            if (string.IsNullOrWhiteSpace(talepTuru) || string.IsNullOrWhiteSpace(aciklama))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            if (aciklama.Length < 20)
            {
                MessageBox.Show("Açıklama en az 20 karakter olmalıdır.");
                //sendbutton.Text = "Talebi Gönder";
                sendbutton.BackgroundImage = Resources.talebigonder;
                return;
            }
            if (pingvar == 0) //ping yoksa
            {
                label6.Text = "-";
                DateTime talepZamani = DateTime.Now;
                int bekleyenDakika = (int)(DateTime.Now - talepZamani).TotalMinutes;
                int sla = bekleyenDakika > 2880 ? 1 : 0;
                string bilgisayarAdi = Environment.MachineName;
                Random random = new Random();
                int randomValue = random.Next(1000, 10000);
                if (!string.IsNullOrEmpty(selectedFilePath))
                {
                    FileInfo fileInfo = new FileInfo(selectedFilePath);
                    long fileSizeInBytes = fileInfo.Length;
                    long maxSizeInBytes = 100 * 1024 * 1024; // 100MB'ın byte cinsinden değeri
                    if (fileSizeInBytes > maxSizeInBytes)
                    {
                        MessageBox.Show("Dosya boyutu 100MB'dan büyük olamaz.");
                        //sendbutton.Text = "Talebi Gönder";
                        sendbutton.BackgroundImage = Resources.talebigonder;

                        return;
                    }
                    string remoteFileName = "Talep_" + randomValue + "_" + Path.GetFileName(selectedFilePath);
                    string httpLink = GenerateHttpLink(remoteFileName); // HTTP linkini oluştur
                    await UploadFileToFtpAsync(selectedFilePath, remoteFileName);
                }
                string remoteFileName2 = "Talep_" + randomValue + "_" + Path.GetFileName(selectedFilePath);
                string httpLink3 = GenerateHttpLink(remoteFileName2); // HTTP linkini oluştur
                await SendEmailAsync(adSoyad, talepTuru, aciklama, false, txtEposta.Text, randomValue, httpLink3);
                MessageBox.Show("Talebiniz mail olarak gönderildi. IT ekibimize iletilmiştir. ");
                //sendbutton.Text = "Talebi Gönder";
                sendbutton.BackgroundImage = Resources.talebigonder;

            }
            if (pingvar == 1)
            {
                label6.Text = "+";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Bilgisayar adını alma
                    string bilgisayarAdi = Environment.MachineName;
                    string userEmailAdress = txtEposta.Text;

                    // Veritabanına talep eklemek için SQL sorgusu
                    string insertQuery = "INSERT INTO talepler (Ad_Soyad, Talep_Turu, Açıklama, Talep_Durumu, iletildi, Talep_Zamani, Öncelik_No, SLA, Bekleme_Suresi, Bilgisayar_Adi, Kullanici_Eposta, Dosya_Adi) " +
                        "VALUES (@AdSoyad, @TalepTuru, @Aciklama, @TalepDurumu, @iletildi, @TalepZamani, @OncelikNo, @SLA, @BeklemeSuresi, @BilgisayarAdi, @KullaniciEposta, @DosyaAdi)";

                    DateTime talepZamani = DateTime.Now;
                    int bekleyenDakika = (int)(DateTime.Now - talepZamani).TotalMinutes;
                    int sla = bekleyenDakika > 2880 ? 1 : 0;

                    SqlCommand command = new SqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@AdSoyad", adSoyad);
                    command.Parameters.AddWithValue("@TalepTuru", talepTuru);
                    command.Parameters.AddWithValue("@Aciklama", aciklama);
                    command.Parameters.AddWithValue("@TalepDurumu", "Bekliyor");
                    command.Parameters.AddWithValue("@iletildi", "0");
                    command.Parameters.AddWithValue("@TalepZamani", talepZamani);
                    command.Parameters.AddWithValue("@OncelikNo", oncelikNo);
                    command.Parameters.AddWithValue("@SLA", sla);
                    command.Parameters.AddWithValue("@BeklemeSuresi", bekleyenDakika);
                    command.Parameters.AddWithValue("@BilgisayarAdi", bilgisayarAdi);
                    command.Parameters.AddWithValue("@KullaniciEposta", userEmailAdress);
                    string getLastIdQuery = "SELECT IDENT_CURRENT('talepler')+ 1 AS LastInsertedId;";
                    SqlCommand getLastIdCommand = new SqlCommand(getLastIdQuery, connection);
                    int talepNo = Convert.ToInt32(getLastIdCommand.ExecuteScalar());
                    if (!string.IsNullOrEmpty(selectedFilePath))
                    {
                        FileInfo fileInfo = new FileInfo(selectedFilePath);
                        long fileSizeInBytes = fileInfo.Length;
                        long maxSizeInBytes = 100 * 1024 * 1024; // 100MB'ın byte cinsinden değeri
                        if (fileSizeInBytes > maxSizeInBytes)
                        {
                            MessageBox.Show("Dosya boyutu 100MB'dan büyük olamaz.");
                           // sendbutton.Text = "Talebi Gönder";
                            sendbutton.BackgroundImage = Resources.talebigonder;

                            return;
                        }
                        string remoteFileName = "Talep_" + talepNo + "_" + Path.GetFileName(selectedFilePath);
                        string httpLink = GenerateHttpLink(remoteFileName); // HTTP linkini oluştur
                        command.Parameters.AddWithValue("@DosyaAdi", remoteFileName);
                        await UploadFileToFtpAsync(selectedFilePath, remoteFileName);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@DosyaAdi", DBNull.Value); // Dosya seçilmediyse veritabanına NULL olarak ekle
                    }
                    string remoteFileName2 = "Talep_" + talepNo + "_" + Path.GetFileName(selectedFilePath);
                    string httpLink2 = GenerateHttpLink(remoteFileName2); // HTTP linkini oluştur
                    command.ExecuteNonQuery();
                    await SendEmailAsync(adSoyad, talepTuru, aciklama, true, userEmailAdress, talepNo, httpLink2); // HTTP linkini de parametre olarak ekleyerek e-posta gönderme işlemi yap
                    MessageBox.Show("Talebiniz alındı ve IT ekibine bilgilendirme maili gönderildi!");
                    //sendbutton.Text = "Talebi Gönder";
                    sendbutton.BackgroundImage = Resources.talebigonder;

                    cmbTalepTuru.SelectedIndex = -1;
                    cmb_oncelik.SelectedIndex = -1;
                    rtbAciklama.Clear();
                }
            }
        }
        private string GenerateHttpLink(string remoteFileName)
        {
            // Sunucu URL'si
            string serverUrl = "http://95.0.50.22:1380/talepfile/";

            // Dosyanın adı ile sunucu URL'sini birleştirerek dosyanın tam HTTP URL'sini oluşturun
            string httpLink = serverUrl + WebUtility.UrlEncode(remoteFileName);
            return httpLink;
        }


        private async Task SendEmailAsync(string adSoyad, string talepTuru, string aciklama, bool databaseConnected, string userEmailAddress, int talepNo, string dosyahttp)
        {
            try
            {
                // E-posta ayarları
                string smtpServer = "smtp.office365.com";
                int smtpPort = 587;
                string senderEmail = "helpdesk@bpet.com.tr";
                string senderPassword = " Bt2023!!";
                string subjectToUser = "Bpet Destek Talebiniz Alındı!";
                string bodyToUser = $"Sayın {adSoyad},\n\n{talepNo} numaralı talebiniz işleme alınmıştır. Bilgi teknolojileri ekibi en kısa zamanda sizinle ilgilenecektir.\n\n";

                string subjectToIT = "Bpet Destek Otomasyonundan Yeni Talep Geldi!";
                string bodyToIT = $"Sayın İlgili,\n\nBpet Destek Otomasyonu'ndan yeni bir talep alınmıştır. Aşağıda talebin bilgileri yer almaktadır:\n\n";
                bodyToIT += $"Ad Soyad: {adSoyad}, Talep No: {talepNo}, Talep Türü: {talepTuru}, Kullanıcı E-Posta: {userEmailAddress}\nAçıklama: {aciklama}\n\n";
                if (!string.IsNullOrWhiteSpace(dosyahttp)) // dosyahttp boş değilse
                {
                    bodyToIT += $"Talep dosya linki: {dosyahttp}\n";
                }
                if (databaseConnected)
                {
                    bodyToIT += $"Talep otomatik olarak veritabanına kaydedilmiştir. Talep Numarası: {talepNo}\n";
                }
                else
                {
                    DateTime talepZamani = DateTime.Now;
                    int bekleyenDakika = (int)(DateTime.Now - talepZamani).TotalMinutes;
                    int sla = bekleyenDakika > 2880 ? 1 : 0;
                    string bilgisayarAdi = Environment.MachineName;
                    int oncelikNo = cmb_oncelik.SelectedIndex + 1;
                    string userEmailAdress = txtEposta.Text;
                    bodyToIT += $"Talep veritabanına kaydedilemedi. Talep Numarası: {talepNo}\n";
                    bodyToIT += "Talebi elle girmek için kullanabileceğiniz SQL komutu:\n\n";
                    bodyToIT += $"INSERT INTO talepler (Ad_Soyad, Talep_Turu, Açıklama, Talep_Durumu, iletildi, Talep_Zamani, Öncelik_No, SLA, Bekleme_Suresi, Bilgisayar_Adi, Kullanici_Eposta) " +
                        $"VALUES ('{adSoyad}', '{talepTuru}', '{aciklama}', 'Bekliyor', '0', GETDATE(), {oncelikNo}, {sla}, {bekleyenDakika}, '{bilgisayarAdi}', '{userEmailAddress}')\n\n";
                    bodyToIT += "Lütfen talebi manuel olarak veritabanına ekleyin.";
                }

                // E-posta gönderme işlemi - Kullanıcıya
                 if (!string.IsNullOrWhiteSpace(txtEposta.Text))// E-posta adresi boş değilse
                {
                    using (SmtpClient client = new SmtpClient(smtpServer, smtpPort))
                    {
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                        client.EnableSsl = true;

                        MailMessage mailMessageToUser = new MailMessage(senderEmail, userEmailAddress, subjectToUser, bodyToUser);
                        mailMessageToUser.Bcc.Add(new MailAddress("mustafa.ceylan@bpet.com.tr")); // Gizli alıcı ekleniyor
                        await Task.WhenAll(client.SendMailAsync(mailMessageToUser));
                    }
                } 

                // E-posta gönderme işlemi - IT Ekibine
                using (SmtpClient client = new SmtpClient(smtpServer, smtpPort))
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    client.EnableSsl = true;

                    MailMessage mailMessageToIT = new MailMessage(senderEmail, alıcımail, subjectToIT, bodyToIT);
                    await Task.WhenAll(client.SendMailAsync(mailMessageToIT));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("E-posta gönderilirken bir hata oluştu: " + ex.Message);
            }
        }
        private void dosyaekle_Click(object sender, EventArgs e)
        {
            using (System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog())
            {
                openFileDialog.Title = "Dosya Seç";
                openFileDialog.Filter = "Tüm Dosyalar|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = openFileDialog.FileName;

                    // Display the selected file name to the user
                    label22.Text = Path.GetFileName(selectedFilePath);
                    label22.Visible = true;
                }
            }
        }
        private async Task UploadFileToFtpAsync(string filePath, string remoteFileName)
        {
            string ftpServer = "ftp://95.0.50.22:1381/talepfile/";
            string ftpUsername = "mustafa.ceylan";
            string ftpPassword = "Defne2023";

            using (WebClient client = new WebClient())
            {
                client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

                // Create a TaskCompletionSource to await the completion of the upload
                TaskCompletionSource<bool> uploadCompleted = new TaskCompletionSource<bool>();

                // Subscribe to the UploadProgressChanged event
                client.UploadProgressChanged += (sender, e) =>
                {
                    // Update the progress bar here
                    progressBar.Value = e.ProgressPercentage;  // Update the progress bar value
                    progressBar.Visible = true;
                };

                // Subscribe to the UploadFileCompleted event
                client.UploadFileCompleted += (sender, e) =>
                {
                    if (e.Error == null)
                    {
                        // File uploaded successfully
                        //MessageBox.Show("File uploaded successfully.");
                        progressBar.Visible = false;
                        uploadCompleted.SetResult(true); // Signal that the upload is completed
                    }
                    else
                    {
                        // An error occurred during upload
                        MessageBox.Show("An error occurred during upload: " + e.Error.Message);
                        progressBar.Visible = false;
                        uploadCompleted.SetException(e.Error); // Signal that an error occurred
                    }

                    // Reset the progress bar
                    progressBar.Value = progressBar.Minimum;
                };

                // Upload the file
                client.UploadFileAsync(new Uri(ftpServer + remoteFileName), "STOR", filePath);

                // Wait for the upload to complete (either success or failure)
                await uploadCompleted.Task;
            }
        }



    }
}

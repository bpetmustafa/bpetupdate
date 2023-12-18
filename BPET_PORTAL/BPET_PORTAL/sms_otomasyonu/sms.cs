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
using SmsApiNode;
using SmsApiNode.Operations;
using Microsoft.Win32;
using System.Net.Mail;
using System.Net;
using System.Windows.Input;
using SKM.V3;
using SKM.V3.Models;
using SKM.V3.Methods;

namespace BPET_PORTAL.sms_otomasyonu
{
    public partial class sms : Form
    {
        private readonly Messenger messenger;
        private List<string> recipientEmails = new List<string>();
        private List<long> smsNumbers = new List<long>();
        private string smtpServer = "smtp.office365.com";
        private int smtpPort = 587;
        private string senderEmail = "info@bpet.com.tr";
        private string senderPassword = "IbBc*2014";
        private string licenseKey = null;
        private const string connectionString = "Server=95.0.50.22,1382;Database=rapor;User ID=sa;Password=Mustafa1;";
        private string RSAPubKey = "<RSAKeyValue><Modulus>697TcOJQBciqsqLl0N7H14msORfgNaSOfQ8N9f7/z5TlGKu57O2Q9w9u69QPh8c2eHK6ChVL6TlSV1WNjBSdkwPF+JWi8mh7/E759B5tpatu3zd3BGEtP1AxUNZYuXp/Cew8G0TGpaSPv5Dog+dqBvP9kFk1rlFk2kSQ7d0yUv0mIzdOJvAIvbXsuxYfHqAJuCrBFZQdjU/nibWxVNZ3A7J9wx+rX35JFbrO2i8Hj+meUCBNWxeyd82gR5YROVIaHQwSZRaNNoKj7AJOflIJWZbvLtr0Rsi9a0zbgwm1vpH+L1ddUpl9pKaAqjBzTon0lNNktH/ptbfryy7cum4OKw==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        public sms()
        {
            InitializeComponent();
            this.Width = 1021;
            this.Height = 151;
            consoletxtbox.Text = "Konsol Hazır" + Environment.NewLine;
            autoSendTimer.Enabled = true;
            autoSendTimer.Interval = 1000;
            autoSendTimer.Tick += autoSendTimer_Tick;
            saatNumericUpDown.Value = 9;
            dakikaNumericUpDown.Value = 0;
            saniyeNumericUpDown.Value = 0;
            messenger = new Messenger("panel2.evyapanltd.com.tr", "balpet", "Bpet*2023");
            recipientEmails.Add("mustafa.ceylan@bpet.com.tr");
            recipientEmails.Add("mazlum.balkan@bpet.com.tr");
            recipientEmails.Add("yucel.koc@bpet.com.tr");
            recipientEmails.Add("huseyin.toru@bpet.com.tr");
            recipientEmails.Add("yonetim.kurulu@bpet.com.tr");
            recipientEmails.Add("sinan.senlik@bpet.com.tr");
            LoadSavedEmails();
            AddDefaultNumbers();
        }
        public void AddDefaultNumbers()
        {
            long[] defaultNumbers = new long[]
            {
            905446818043, 905321368484, 905309798174, 905326878570, 905334820928,
            905326078735, 905325007564, 905323353740, 905334330260, 905072443700,
            905334306560, 905316862963
            };

            smsNumbers.AddRange(defaultNumbers);
            foreach (long number in defaultNumbers)
            {
                listBoxNumbers.Items.Add(number);
            }
        }
        private void LoadSavedEmails()
        {
            foreach (string email in recipientEmails)
            {
                listBox1.Items.Add(email);
            }

        }
        private void CheckLicense()
        {
            licenseKey = ReadLicenseKeyFromRegistry();
            if (!string.IsNullOrEmpty(licenseKey) && licenseKey.Length >= 10)
            {
                int visibleLength = 5; 
                string visiblePart = new string('*', visibleLength);
                string hiddenPart = new string('*', licenseKey.Length - 2 * visibleLength);

                string maskedLicenseKey = licenseKey.Substring(0, visibleLength) + hiddenPart + licenseKey.Substring(licenseKey.Length - visibleLength);

                key.Text = maskedLicenseKey;
            }


            if (string.IsNullOrEmpty(licenseKey))
            {
                using (var inputForm = new LicenseKeyInputForm())
                {
                    if (inputForm.ShowDialog() == DialogResult.OK)
                    {
                        licenseKey = inputForm.LicenseKey;

                        // Save the license key in the Windows Registry
                        SaveLicenseKeyToRegistry(licenseKey);
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
            }
            var auth = "WyI1MTI5MDU3MyIsIlFuZlZYOHg0QUxQZFRRN00ybExQYWUwNnpQSkVkS1U3TmJNUmVrenQiXQ==";
            var result = SKM.V3.Methods.Key.Activate(token: auth, parameters: new ActivateModel()
            {
                Key = licenseKey,
                ProductId = 20509,
                Sign = true,
                MachineCode = Helpers.GetMachineCodePI(v: 2)
            });

            if (result == null || result.Result == ResultType.Error ||
                !result.LicenseKey.HasValidSignature(RSAPubKey).IsValid())
            {
                
                while (true)
                {
                    // Lisans anahtarı giriş ekranını göster
                    using (var inputForm = new LicenseKeyInputForm())
                    {
                        if (inputForm.ShowDialog() == DialogResult.OK)
                        {
                            licenseKey = inputForm.LicenseKey;

                            // Lisans anahtarını kontrol et
                            result = SKM.V3.Methods.Key.Activate(token: auth, parameters: new ActivateModel()
                            {
                                Key = licenseKey,
                                ProductId = 20509,
                                Sign = true,
                                MachineCode = Helpers.GetMachineCodePI(v: 2)
                            });

                            if (result != null && result.Result == ResultType.Success &&
                                result.LicenseKey.HasValidSignature(RSAPubKey).IsValid())
                            {
                                // Lisans anahtarı geçerli ise, Windows Kayıt Defterine kaydet
                                SaveLicenseKeyToRegistry(licenseKey);
                                break;  // Döngüden çık
                            }
                        }
                        else
                        {
                            // Kullanıcı yeni bir lisans anahtarı girmeyi iptal ettiyse, uygulamadan çık
                            Environment.Exit(0);
                        }
                    }
                }
            }
        }
        private string ReadLicenseKeyFromRegistry()
        {
            try
            {
                using (var registryKey = Registry.CurrentUser.OpenSubKey("Software\\EpostaOtomasyonu"))
                {
                    if (registryKey != null)
                    {
                        return (string)registryKey.GetValue("LicenseKey");

                    }
                }
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        private void SaveLicenseKeyToRegistry(string licenseKey)
        {
            try
            {
                using (var registryKey = Registry.CurrentUser.CreateSubKey("Software\\EpostaOtomasyonu"))
                {
                    if (registryKey != null)
                    {
                        registryKey.SetValue("LicenseKey", licenseKey);
                        MessageBox.Show("Kayıt defterine lisans anahtarı EKLENDİ!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt defterine lisans anahtarı yazılırken hata oluştu! " + ex.Message);
            }
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSendMultiSms_Click(object sender, EventArgs e)
        {
            CheckLicense();
            List<string> veriler = GetVeriler();
            var multiSmsRequest = new SendMultiSms();

            // Tarih ve SMS içeriği
            DateTime tarih = DateTime.Now.AddDays(-1);
            string smsIcerik = $"Günlük Rapor Bilgisi {tarih:dd-MMMM-yyyy} Kapanış:\n\n" +
                      "Motorin: " + (Convert.ToDecimal(veriler[0]) + Convert.ToDecimal(veriler[1])).ToString("N0") + " LT\n" +
                      "Benzin: " + Convert.ToDecimal(veriler[2]).ToString("N0") + " LT\n\n" +
                      "Beyaz Ürün Toplam: " + (Convert.ToDecimal(veriler[0]) + Convert.ToDecimal(veriler[2]) + +Convert.ToDecimal(veriler[1])).ToString("N0") + " LT\n" +
                      "Lpg Toplam: " + (Convert.ToDecimal(veriler[3]) + Convert.ToDecimal(veriler[4])).ToString("N0") + " KG\n\n";

            multiSmsRequest.Content = smsIcerik;

            // multiSmsRequest.Numbers = new List<long>() { 905446818043, 905321368484, 905309798174, 905326878570, 905334820928, 905326078735, 905325007564, 905323353740, 905334330260, 905072443700, 905334306560 };
            multiSmsRequest.Numbers = smsNumbers; // ListBox'taki numaraları kullanın
            multiSmsRequest.Sender = "Bpet";
            multiSmsRequest.Title = "BPET SMS OTOMASYONU (DEBUG)";
            var multiSmsResponse = messenger.SendMultiSms(multiSmsRequest);
            if (multiSmsResponse.Err == null)
            {
                Console.WriteLine("Paket Id : " + multiSmsResponse.PackageId);
                string currentTimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string newLog = "SMS Gönderildi! " + currentTimeStamp + " - Alıcı: " + multiSmsRequest.Numbers;
                consoletxtbox.AppendText(newLog + Environment.NewLine);
            }
            else
            {
                Console.WriteLine(
                    "Durum Statu  : " + multiSmsResponse.Err.Status + "\n" +
                    "Durum Kodu   : " + multiSmsResponse.Err.Code + "\n" +
                    "Durum Mesajı : " + multiSmsResponse.Err.Message
                );
            }
        }
        private void sendtestbtn_Click(object sender, EventArgs e)
        {

            CheckLicense();

            List<string> veriler = GetVeriler();

            bool isGonderSuccess = GonderEposta(veriler);

            if (isGonderSuccess)
            {
                // MessageBox.Show("E-posta başarıyla gönderildi. ");
            }
            else
            {
                MessageBox.Show("E-posta gönderme işlemi başarısız.");
            }
        }

        private List<string> GetVeriler()
        {
            List<string> veriler = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM gunluk_veri WHERE Zaman = DATEADD(DAY, -1, CAST(GETDATE() AS DATE))";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        veriler.Add(reader["Motorin"].ToString());
                        veriler.Add(reader["MotorinDiger"].ToString());
                        veriler.Add(reader["Benzin"].ToString());
                        veriler.Add(reader["Lpg"].ToString());
                        veriler.Add(reader["LpgDokme"].ToString());
                    }
                }
            }

            return veriler;
        }

        private bool GonderEposta(List<string> veriler)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient(smtpServer);
                decimal motorinToplam = Convert.ToDecimal(veriler[0]) + Convert.ToDecimal(veriler[1]);
                decimal lpgToplam = Convert.ToDecimal(veriler[3]) + Convert.ToDecimal(veriler[4]);

                mail.From = new MailAddress(senderEmail);
                mail.Subject = "Günlük Rapor Bilgisi " + DateTime.Now.AddDays(-1).ToString("dd-MMMM-yyyy");

                mail.IsBodyHtml = true;

                string body = "<html><head></head><body>";
                body += "<h2 style='color: #007ACC; text-align: center; font-size: 24px;'>Günlük Satışlar  " + DateTime.Now.AddDays(-1).ToString("dd-MMMM-yyyy") + " Kapanış</h2>";

                // İlk tablo: Motorin, Motorin (Diğer), Motorin Toplam, Benzin
                body += "<table style='border-collapse: collapse; margin: 0 auto; width: 80%;'>";
                body += "<tr style='background-color: #007ACC; color: white; text-align: center;'><th style='padding: 10px;'>Motorin</th><th style='padding: 10px;'>Motorin (Diğer)</th><th style='padding: 10px;'>Motorin Toplam</th><th style='padding: 10px;'>Benzin</th></tr>";
                body += "<tr style='background-color: #E5E5E5; text-align: center;'><td style='padding: 10px;'>" + Convert.ToDecimal(veriler[0]).ToString("N0") + " LT</td><td style='padding: 10px;'>" + Convert.ToDecimal(veriler[1]).ToString("N0") + " LT</td><td style='padding: 10px;'>" + motorinToplam.ToString("N0") + " LT</td><td style='padding: 10px;'>" + Convert.ToDecimal(veriler[2]).ToString("N0") + " LT</td></tr>";
                body += "</table>";

                // Boşluk eklemek için bir div ekleyebiliriz.
                body += "<div style='height: 20px;'></div>";

                // İkinci tablo: Lpg Perakende, Lpg Dökme, Lpg Toplam (Turuncu renkte)
                body += "<table style='border-collapse: collapse; margin: 0 auto; width: 40%; background-color: orange;'>";
                body += "<tr style='background-color: #007ACC; color: white; text-align: center;'><th style='padding: 10px;'>Lpg Perakende</th><th style='padding: 10px;'>Lpg Dökme</th><th style='padding: 10px;'>Lpg Toplam</th></tr>";
                body += "<tr style='background-color: #E5E5E5; text-align: center;'><td style='padding: 10px;'>" + Convert.ToDecimal(veriler[3]).ToString("N0") + " KG</td><td style='padding: 10px;'>" + Convert.ToDecimal(veriler[4]).ToString("N0") + " KG</td><td style='padding: 10px;'>" + lpgToplam.ToString("N0") + " KG</td></tr>";
                body += "</table>";

                body += "<p style='text-align: center; margin-top: 5px; font-size: 8px;'>All rights reserved. This application is the property of <a href='https://www.linkedin.com/in/mustafaugurceylan' style='text-decoration: underline; color: #007ACC;'>MUC</a>.</p>";
                body += "</body></html>";

                mail.Body = body;

                foreach (string recipient in recipientEmails)
                {
                    mail.To.Add(recipient);
                }
                mail.Headers.Add("X-Auto-Response-Suppress", "All");
                smtpClient.Port = smtpPort;
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtpClient.EnableSsl = true;

                smtpClient.Send(mail);
                string currentTimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string newLog = "E-posta Gönderildi! " + currentTimeStamp + " - Alıcı: " + recipientEmails;
                consoletxtbox.AppendText(newLog + Environment.NewLine);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private void autoSendTimer_Tick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            int saat = (int)saatNumericUpDown.Value;
            int dakika = (int)dakikaNumericUpDown.Value;
            int saniye = (int)saniyeNumericUpDown.Value;
            if (currentTime.Hour == saat && currentTime.Minute == dakika && currentTime.Second == saniye)
            {
                CheckLicense();
                sendtestbtn_Click(sender, e);
                btnSendMultiSms_Click(sender, e);
            }
            saatLabel.Text = currentTime.ToString("HH:mm:ss");
            DateTime nextSendTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, saat, dakika, saniye);
            nextSendTime = nextSendTime.AddDays(1);
            TimeSpan remainingTime = nextSendTime - currentTime;

            kalanLabel.Text = string.Format("Kalan Süre: {0:D2}:{1:D2}:{2:D2}", remainingTime.Hours, remainingTime.Minutes, remainingTime.Seconds);

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void adminbtn_Click(object sender, EventArgs e)
        {
            Form adminForm = new Form();
            adminForm.Text = "Admin Girişi";
            adminForm.Size = new Size(300, 50);
            adminForm.StartPosition = FormStartPosition.CenterParent;
            adminForm.FormBorderStyle = FormBorderStyle.None;
            TextBox passwordTextBox = new TextBox();
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Location = new Point(20, 20);
            passwordTextBox.Size = new Size(150, 20);

            Button okButton = new Button();
            okButton.Text = "Onayla";
            okButton.Location = new Point(180, 18);
            okButton.Size = new Size(80, 24);


            okButton.Click += (s, args) =>
            {
                if (passwordTextBox.Text == "Bpet*2023")
                {
                    groupBox1.Visible = true;
                    adminForm.Close();
                    adminbtn.Visible = false;
                    listBox1.Visible = true;
                    txtNewEmail.Visible = true;
                    metroButton5.Visible = true;
                    txtNewNumber.Visible = true;
                    metroButton6.Visible = true;
                    listBoxNumbers.Visible = true;
                    this.Width = 1021;
                    this.Height = 295;
                    this.CenterToScreen();
                    adminpanel.Visible = true;
                }
                else
                {
                    MessageBox.Show("Geçersiz şifre!");
                    passwordTextBox.Text = "";
                }
            };


            adminForm.Controls.Add(passwordTextBox);
            adminForm.Controls.Add(okButton);


            adminForm.ShowDialog();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            CheckLicense();
            sendtestbtn_Click(sender, e);
            btnSendMultiSms_Click(sender, e);
        }

        private void metroTextBox1_ButtonClick(object sender, EventArgs e)
        {
            string newEmail = txtNewEmail.Text.Trim();

            if (!string.IsNullOrEmpty(newEmail))
            {
                // E-posta adresini checkedListBox1'e ekleyin
                listBox1.Items.Add(newEmail);
                int index = listBox1.Items.IndexOf(newEmail);


                // recipientEmails listesine de ekleyin
                recipientEmails.Add(newEmail);

                // TextBox'ı temizleyin
                txtNewEmail.Text = string.Empty;

                // Listeyi güncelleyin
                RefreshListBox();
            }
        }

        private void btnDeleteEmail_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                string selectedEmail = listBox1.SelectedItem.ToString();
                recipientEmails.Remove(selectedEmail);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }


        private void RefreshListBox()
        {
            listBox1.Items.Clear(); // Listeyi temizle

            // recipientEmails listesindeki e-posta adreslerini checkedListBox1'e yeniden ekleyin
            foreach (string email in recipientEmails)
            {
                listBox1.Items.Add(email);
            }
        }

        private void btnAddNumber_Click(object sender, EventArgs e)
        {
            string newNumberText = txtNewNumber.Text.Trim();

            if (!string.IsNullOrEmpty(newNumberText))
            {
                if (long.TryParse(newNumberText, out long newNumber))
                {
                    // Yeni numarayı listeye ekle
                    smsNumbers.Add(newNumber);

                    // ListBox'a yeni numarayı ekleyin
                    listBoxNumbers.Items.Add(newNumber);

                    // TextBox'ı temizleyin
                    txtNewNumber.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Geçersiz numara formatı. Lütfen yalnızca sayıları kullanın.");
                }
            }
            else
            {
                MessageBox.Show("Boş numara giremezsiniz.");
            }
        }
        private void btnDeleteNumber_Click(object sender, EventArgs e)
        {
            if (listBoxNumbers.SelectedIndex >= 0)
            {
                // Seçilen numarayı ListBox ve smsNumbers listesinden silin
                long selectedNumber = (long)listBoxNumbers.SelectedItem;
                smsNumbers.Remove(selectedNumber);
                listBoxNumbers.Items.RemoveAt(listBoxNumbers.SelectedIndex);
            }
        }

        private void testmode_click(object sender, EventArgs e)
        {
            recipientEmails.Clear();
            recipientEmails.Add("mustafa.ceylan@bpet.com.tr");
            smsNumbers.Clear();
            smsNumbers.Add(905446818043);

            listBox1.Items.Clear();
            listBoxNumbers.Items.Clear();
            LoadSavedEmails();
            foreach (long number in smsNumbers)
            {
                listBoxNumbers.Items.Add(number);
            }
            listBoxNumbers.Refresh();
            listBox1.Refresh();

        }

        private void clientmode_Click(object sender, EventArgs e)
        {
            recipientEmails.Clear();
            smsNumbers.Clear();
            listBox1.Items.Clear();
            listBoxNumbers.Items.Clear();

            recipientEmails.Add("mustafa.ceylan@bpet.com.tr");
            recipientEmails.Add("mazlum.balkan@bpet.com.tr");
            recipientEmails.Add("yucel.koc@bpet.com.tr");
            recipientEmails.Add("huseyin.toru@bpet.com.tr");
            recipientEmails.Add("yonetim.kurulu@bpet.com.tr");
            recipientEmails.Add("sinan.senlik@bpet.com.tr");
            LoadSavedEmails();
            AddDefaultNumbers();
            foreach (long number in smsNumbers)
            {
                listBoxNumbers.Items.Add(number);
            }
            listBoxNumbers.Refresh();
            listBox1.Refresh();
        }

        private void sms_Load(object sender, EventArgs e)
        {
            CheckLicense();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SmsApiNode;
using SmsApiNode.Operations;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BPET_PORTAL.sms_mfa
{

    public class sms
    {
        private  Messenger messenger;
        private List<long> smsNumbers = new List<long>();
        private string connectionString = "Server=95.0.50.22,1382;Database=BPET_PORTAL;User ID=sa;Password=Mustafa1;";

        public void Sms_sender(string eposta)
        {
            long phoneNumber = GetPhoneNumber(eposta);
            if (phoneNumber == 0)
            {
                Console.WriteLine("Telefon numarası bulunamadı.");
                return;
            }
            if (IsVerificationRecentlySent(eposta))
            {
                Console.WriteLine("Son 5 dakika içinde doğrulama kodu gönderilmiş.");

                return;
            }
            messenger = new Messenger("panel2.evyapanltd.com.tr", "balpet", "Bpet*2023");
            var multiSmsRequest = new SendMultiSms();
            string dogrulamakodu = GenerateRandomVerificationCode();
            // Tarih ve SMS içeriği
            DateTime tarih = DateTime.Now.AddDays(-1);
            string smsIcerik = $"BPET Portal Doğrulama Kodunuz: " + dogrulamakodu + " \n Lütfen bu kodu Bilgi İşlem de dahil kimse ile paylaşmayınız. \n";
            smsNumbers.Add(phoneNumber);
            multiSmsRequest.Content = smsIcerik;
            multiSmsRequest.Numbers = smsNumbers; // ListBox'taki numaraları kullanın
            multiSmsRequest.Sender = "Bpet";
            multiSmsRequest.Title = "BPET PORTAL MFA";
            var multiSmsResponse = messenger.SendMultiSms(multiSmsRequest);
            if (multiSmsResponse.Err == null)
            {
                Console.WriteLine("Paket Id : " + multiSmsResponse.PackageId);
                string currentTimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string newLog = "SMS Gönderildi! " + currentTimeStamp + " - Alıcı: " + multiSmsRequest.Numbers;
                
                SaveVerificationCode(eposta, dogrulamakodu);
                //UpdateLastMFATime(eposta);
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
        private bool IsVerificationRecentlySent(string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Son_MFA_Tarih FROM users WHERE E_Posta = @Email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result is DateTime lastMfaTime)
                    {
                        return (DateTime.Now - lastMfaTime).TotalMinutes <= 60;
                    }
                }
            }
            return false;
        }

        private void UpdateLastMFATime(string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE users SET Son_MFA_Tarih = @Now WHERE E_Posta = @Email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Now", DateTime.Now);
                    command.Parameters.AddWithValue("@Email", email);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool VerifyUserCode(string email, string userInputCode)
        {
            string savedCode = GetSavedVerificationCode(email);
            if (userInputCode == savedCode)
            {
                UpdateLastMFATime(email); // Doğrulama başarılı ise Son_MFA_Tarih'i güncelle
                return true;
            }
            return false;
        }

        public string GetSavedVerificationCode(string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Dogrulama_Kodu FROM users WHERE E_Posta = @Email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader["Dogrulama_Kodu"].ToString();
                        }
                    }
                }
            }

            return null; // Eğer kod bulunamazsa
        }
        private long GetPhoneNumber(string eposta)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Telefon FROM users WHERE E_Posta = @Email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", eposta);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt64("90" + result);
                    }
                }
            }
            return 0; // Eğer numara bulunamazsa
        }
        public void SaveVerificationCode(string email, string code)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE users SET Dogrulama_Kodu = @Code WHERE E_Posta = @Email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Code", code);
                    command.Parameters.AddWithValue("@Email", email);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
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
    }
    
}

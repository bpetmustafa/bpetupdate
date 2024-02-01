using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BPET_PORTAL.sms_mfa
{
    internal class EmailSender
    {
        static private string connectionString = "Server=95.0.50.22,1382;Database=BPET_PORTAL;User ID=sa;Password=Mustafa1;";
        static private string smtpServer = "smtp.office365.com";
        static private int smtpPort = 587;
        static private string senderEmail = "info@bpet.com.tr";
        static private string senderPassword = "IbBc*2014";

        public static void SendVerificationEmail(string eposta, string dogrulamaKodu)
        {
            try
            {
                using (SmtpClient client = new SmtpClient(smtpServer, smtpPort))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(senderEmail);
                        mail.To.Add(eposta);
                        mail.Subject = "BPET Portal Doğrulama Kodu";
                        mail.Body = "BPET Portal Doğrulama Kodunuz: " + dogrulamaKodu +
                                    "\nLütfen bu kodu Bilgi İşlem de dahil kimse ile paylaşmayınız.";

                        client.Send(mail);
                    }
                }
                Form_Alert.Alert("Doğrulama Kodu E-POSTA ile Gönderildi!", Form_Alert.enmType.Info);

                Console.WriteLine("Doğrulama kodu e-posta ile gönderildi: " + eposta);
            }
            catch (Exception ex)
            {
                Console.WriteLine("E-posta gönderilirken hata oluştu: " + ex.Message);
            }
        }
    }
}

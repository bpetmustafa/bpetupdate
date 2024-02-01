using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmsApiNode;
using SmsApiNode.Operations;

namespace BPET_PORTAL.bayitakip
{
    internal class SmsBayiTakip
    {
        private Messenger messenger;
        private List<long> smsNumbers = new List<long>();

        public void Sms_sender()
        {
            messenger = new Messenger("panel2.evyapanltd.com.tr", "balpet", "Bpet*2023");
            var multiSmsRequest = new SendMultiSms();
            string smsIcerik = "Merhaba,\n\nBPET PORTAL'da haftalık taleplerinizi yanıtlamanız gerekiyor. Son yanıt tarihi Pazar günü saat 23:59'a kadardır. Lütfen bu taleplere zamanında dönüş yapmayı unutmayın.\n\nSorularınız için BPET PORTAL Canlı Destek hizmeti ile iletişime geçebilirsiniz.\n\nİyi çalışmalar!";
            smsNumbers.Add(905446818043);
            smsNumbers.Add(905384010540);
            smsNumbers.Add(905354545121);//mersin bölge nejat 1
            smsNumbers.Add(905359450791); //ankara bölge alp adson 1
            smsNumbers.Add(905333644808); //diyarbakır abdulkadir çankaya 1
            smsNumbers.Add(905323806350); //şanlıurfa Uğur Demir 1
            smsNumbers.Add(905331558287); // ege saha müdürü güneş şenalp 1
            smsNumbers.Add(905305274667); //eray ocaklı karadeniz saha müdürü 1
            smsNumbers.Add(905312295868); //kayseri bölge recep gökduman 1
            smsNumbers.Add(905300685158); //marmara saha müdürü yavuz sselim avcı 1
            multiSmsRequest.Content = smsIcerik;
            multiSmsRequest.Numbers = smsNumbers; // ListBox'taki numaraları kullanın
            multiSmsRequest.Sender = "Bpet";
            multiSmsRequest.Title = "BPET PORTAL Bayi Takip Sistemi";
            var multiSmsResponse = messenger.SendMultiSms(multiSmsRequest);
            if (multiSmsResponse.Err == null)
            {
                Console.WriteLine("Paket Id : " + multiSmsResponse.PackageId);
                string currentTimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string newLog = "SMS Gönderildi! " + currentTimeStamp + " - Alıcı: " + multiSmsRequest.Numbers;
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
    }
}

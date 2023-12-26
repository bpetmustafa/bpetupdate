using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPET_PORTAL.arsiv_uygulamasi
{
    public partial class arsivmainpage : Form
    {
        private mainpage mainForm;
        private bool sifredegistirmeyetkisi;
        private const string connectionString = "Server=95.0.50.22,1382;Database=BPET_PORTAL;User ID=sa;Password=Mustafa1;";

        public arsivmainpage(string eposta, mainpage mainForm)
        {
            InitializeComponent();
            epostalabel.Text = eposta;
            this.mainForm = mainForm; // mainForm örneğini burada başlatın

        }
        protected void kullaniciyetkileri()
        {
            string kullaniciYetkileri = GetKullaniciYetkileri(epostalabel.Text);

            dosya_bul.Visible = CheckUserPermission("a_arsiv", kullaniciYetkileri);
            dosya_bul.Enabled = CheckUserPermission("a_arsiv", kullaniciYetkileri);
            dosyabullabel.Visible = CheckUserPermission("a_arsiv", kullaniciYetkileri);

            dosya_ekle.Visible = CheckUserPermission("b_arsiv", kullaniciYetkileri);
            dosya_ekle.Enabled = CheckUserPermission("b_arsiv", kullaniciYetkileri);
            Dosyaislemlerilabel.Visible = CheckUserPermission("b_arsiv", kullaniciYetkileri);

            teslimet.Visible = CheckUserPermission("c_arsiv", kullaniciYetkileri);
            dosyateslimetlabel.Visible = CheckUserPermission("c_arsiv", kullaniciYetkileri);
            teslimet.Enabled = CheckUserPermission("c_arsiv", kullaniciYetkileri);

            adminbtn.Visible = CheckUserPermission("d_arsiv", kullaniciYetkileri);
            kullanıcıeklelabeladmin.Visible = CheckUserPermission("d_arsiv", kullaniciYetkileri);
            adminbtn.Enabled = CheckUserPermission("d_arsiv", kullaniciYetkileri);

            geciciyetkibtn.Visible = CheckUserPermission("e_arsiv", kullaniciYetkileri);
            geciciyetkiverlabel.Visible = CheckUserPermission("e_arsiv", kullaniciYetkileri);
            geciciyetkibtn.Enabled = CheckUserPermission("e_arsiv", kullaniciYetkileri);

            arsivsifre.Visible = CheckUserPermission("sifre_arsiv", kullaniciYetkileri);
            sifredegistirmeyetkisi = CheckUserPermission("sifredegis_arsiv", kullaniciYetkileri);
            if (arsivsifre.Visible == true)
            {
                label1.Visible = false;
                label2.Visible = false;
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


                    string query = "SELECT arsiv_yetki FROM users WHERE E_Posta = @Eposta";
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

            }

            return yetkiler;
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        public void dosya_bul_Click(object sender, EventArgs e)
        {
            mainForm.loadform(new DosyaBul(epostalabel.Text,mainForm));
        }

        private void dosya_ekle_Click(object sender, EventArgs e)
        {
            // Onay kutusunu göster
            DialogResult result = MessageBox.Show("Bu ekranın açılması uzun sürebilir. Lütfen ekran açılana kadar bir şeye basmayınız, uygulama donmuş gibi durabilir. Devam etmek istiyor musunuz?",
                                                  "Onay",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);

            // Kullanıcı 'Evet' seçeneğini tıklarsa, işlemi yap
            if (result == DialogResult.Yes)
            {
                this.Enabled = false; // Ana formu etkisizleştir

                // Yeni form yüklenirken bu olay tetiklenecek
                void formLoaded(object s, EventArgs ea)
                {
                    this.Enabled = true; // Ana formu tekrar etkinleştir
                    ((Form)s).Load -= formLoaded; // Olay bağlantısını kaldır
                }

                // dosyaislemleri2 formunu yüklerken olayı bağla
                Form dosyaFormu = new dosyaislemleri2(epostalabel.Text, mainForm);
                dosyaFormu.Load += formLoaded;
                mainForm.loadform(dosyaFormu);
            }
            // Kullanıcı 'Hayır' seçeneğini tıklarsa, işlemi yapma
            else
            {
                
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            mainForm.loadform(new DosyaTeslimEt(epostalabel.Text, mainForm));

        }

        private void adminbtn_Click(object sender, EventArgs e)
        {
            mainForm.loadform(new KullaniciEkle(epostalabel.Text, mainForm));

        }

        private void arsivmainpage_Load(object sender, EventArgs e)
        {
            kullaniciyetkileri();
            ArsivSifreGetir();
        }
        private void ArsivSifreGetir()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT sifre FROM ArsivSifre WHERE durumu = 1";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            // Eğer şifre bulunduysa label'a yazdır
                            arsivsifre.Text = "ARŞİV KAPILARININ ŞİFRESİ: ";
                            arsivsifre.Text += result.ToString();
                        }
                        else
                        {
                            // Şifre bulunamadıysa gerekli işlemleri yapabilirsiniz
                            arsivsifre.Text = "Şifre Bulunamadı";
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                this.Alert("Şifre alınamadı: " + ex.Message, Form_Alert.enmType.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainForm.loadform(new geciciyetkiver(epostalabel.Text, mainForm));

        }

        private void label2_Click(object sender, EventArgs e)
        {
            mainForm.livechat.Visible = true;
            mainForm.txtMessage.Text = "Merhabalar, arşivlerin şifresini öğrenmek istiyorum.";
        }


       
        private void Kaydet(string yeniSifre)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Veritabanına güncel şifreyi kaydet
                    string query = "UPDATE ArsivSifre SET sifre = @Sifre WHERE durumu = 1";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Sifre", yeniSifre);
                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                this.Alert("Şifre kaydedilemedi: " + ex.Message, Form_Alert.enmType.Error);
            }
        }

        private void arsivsifre_DoubleClick(object sender, EventArgs e)
        {
            if (sifredegistirmeyetkisi == true)
            {
                string yeniSifre = Microsoft.VisualBasic.Interaction.InputBox("Yeni Şifre", "Yeni şifrenizi giriniz:", "");
                // Eğer kullanıcı bir şifre girdiyse
                if (!string.IsNullOrEmpty(yeniSifre))
                {
                    Kaydet(yeniSifre);
                    ArsivSifreGetir();
                }
            }
        }   
    }
}

using BPET_PORTAL.arsiv_uygulamasi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace BPET_PORTAL.victorreklam
{
    public partial class victorreklamform : Form
    {
        private Dictionary<string, DateTime> dosyaTarihleri = new Dictionary<string, DateTime>();
        private const string connectionString = "Server=95.0.50.22,1382;Database=BPET_PORTAL;User ID=sa;Password=Mustafa1;";

        public victorreklamform(string eposta)
        {
            InitializeComponent();
            epostalabel.Text = eposta;
            

            // DataGridView sütunlarını oluştur
            dataGridView.Columns.Add("DosyaAdi", "Dosya Adı");
            dataGridView.Columns.Add("Tarih", "Tarih");
            dataGridView.Columns.Add("Indir", "Dosya İndir");
            dataGridView.Columns["DosyaAdi"].Width = 200; // Dosya Adı sütunu genişliği
            dataGridView.Columns["Tarih"].Width = 150;    // Tarih sütunu genişliği
            dataGridView.Columns["Indir"].Width = 100;    // İndir sütunu genişliği
            dataGridView.RowTemplate.Height = 45; // Satır yüksekliğini istediğiniz değere ayarlayın
            dataGridView.DefaultCellStyle.Font = new Font("Arial", 12); // Yazı tipi ve boyutunu ayarlayın


        }
        private void kullaniciyetkileri()
        {
            string kullaniciYetkileri = GetKullaniciYetkileri(epostalabel.Text);

            dosyayukle.Visible = CheckUserPermission("a_victor", kullaniciYetkileri);
            dosyasil.Visible = CheckUserPermission("b_victor", kullaniciYetkileri);


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


                    string query = "SELECT victor_yetki FROM users WHERE E_Posta = @Eposta";
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
        private void DosyaYukleButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Tüm Dosyalar|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string secilenDosyaYolu = openFileDialog.FileName;

                    // Dosya yükleme işlemini başka bir iş parçacığında gerçekleştir
                    BackgroundWorker worker = new BackgroundWorker();
                    worker.DoWork += (senderWorker, eWorker) =>
                    {
                        // Dosya yükleme işlemi
                        bool yuklemeSonucu = YukleFtp(secilenDosyaYolu);

                        // İşlem sonucunu raporla
                        eWorker.Result = yuklemeSonucu;
                    };
                    worker.RunWorkerCompleted += (senderWorker, eWorker) =>
                    {
                        // İşlem tamamlandığında
                        bool yuklemeSonucu = (bool)eWorker.Result;

                        if (yuklemeSonucu)
                        {
                            // Başarılı bir şekilde yüklendiğini bildirin
                            s.Visible = false;
                            this.Alert("Dosya başarıyla yüklendi!", Form_Alert.enmType.Success);
                            ListeleDosyalariFtp();
                        }
                        else
                        {
                            this.Alert("Dosya yüklenmedi!", Form_Alert.enmType.Warning);

                        }

                        // Progress bar'ı sıfırla
                        s.Value = 0;
                    };

                    // Dosya yükleme işlemine başla
                    worker.RunWorkerAsync();
                }
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
                string klasor = "/bpet_portal/victor_reklam/";

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
                            s.Visible = true;
                            s.Value = ilerlemeYuzdesi;
                        });
                    }
                }

                return true;
            }
            catch (Exception ex)
            {

                this.Alert("Dosya yüklenemedi:  " + ex.Message, Form_Alert.enmType.Error);

                return false;
            }
        }
        private void ListeleDosyalariFtp()
        {
            string ftpSunucu = "ftp://95.0.50.22:1381/";
            string kullaniciAdi = "mustafa.ceylan";
            string sifre = "Defne2023";
            string klasor = "/bpet_portal/victor_reklam/";

            try
            {
                // FTP sunucusundaki dosyaları listeleme
                FtpWebRequest listRequest = (FtpWebRequest)WebRequest.Create(ftpSunucu + klasor);
                listRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                listRequest.Credentials = new NetworkCredential(kullaniciAdi, sifre);

                using (FtpWebResponse listResponse = (FtpWebResponse)listRequest.GetResponse())
                using (Stream listStream = listResponse.GetResponseStream())
                using (StreamReader listReader = new StreamReader(listStream))
                {
                    List<string> dosyaListesi = new List<string>();

                    while (!listReader.EndOfStream)
                    {
                        string dosyaAdi = listReader.ReadLine();
                        dosyaListesi.Add(dosyaAdi);
                    }

                    // Dosya listesini tarihe göre sıralama (en yeni en üstte olacak)
                    dosyaListesi.Sort((a, b) =>
                    {
                        DateTime tarihA = DosyaTarihGetir(ftpSunucu, klasor + a);
                        DateTime tarihB = DosyaTarihGetir(ftpSunucu, klasor + b);
                        return tarihB.CompareTo(tarihA);
                    });

                    // DataGridView'e erişim iş parçacığına döndür
                    this.Invoke((MethodInvoker)delegate
                    {
                        dataGridView.Rows.Clear();

                        foreach (string dosyaAdi in dosyaListesi)
                        {
                            // DataGridView'e dosya bilgilerini eklemek için yeni bir satır oluşturun
                            DataGridViewRow row = new DataGridViewRow();
                            DataGridViewTextBoxCell dosyaAdiCell = new DataGridViewTextBoxCell();
                            dosyaAdiCell.Value = dosyaAdi;
                            row.Cells.Add(dosyaAdiCell);

                            DataGridViewTextBoxCell tarihCell = new DataGridViewTextBoxCell();
                            DateTime dosyaTarihi = DosyaTarihGetir(ftpSunucu, klasor + dosyaAdi);
                            tarihCell.Value = dosyaTarihi.ToString(); // Tarihi istediğiniz biçimde ayarlayın
                            row.Cells.Add(tarihCell);

                            DataGridViewButtonCell indirCell = new DataGridViewButtonCell();
                            indirCell.Value = "Dosyayı Aç";
                            row.Cells.Add(indirCell);

                            // DataGridView'e yeni satırı ekleyin
                            dataGridView.Rows.Add(row);
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                this.Alert("Dosyalar listelenemedi: " + ex.Message, Form_Alert.enmType.Error);

            }
        }

        private DateTime DosyaTarihGetir(string ftpSunucu, string dosyaYolu)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpSunucu + dosyaYolu);
                request.Method = WebRequestMethods.Ftp.GetDateTimestamp;
                request.Credentials = new NetworkCredential("mustafa.ceylan", "Defne2023");

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    return response.LastModified;
                }
            }
            catch (Exception)
            {
                // Tarih alınamazsa varsayılan bir tarih dön
                return DateTime.MinValue;
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView.Columns["Indir"].Index)
            {
                string secilenDosyaAdi = dataGridView.Rows[e.RowIndex].Cells["DosyaAdi"].Value.ToString();

                // FTP sunucusundan dosyayı indirme ve açma
                if (IndirVeAcHttp(secilenDosyaAdi))
                {
                    // Dosya HTTP sunucusundan başarıyla indirildi ve açıldı
                }
                else
                {

                    this.Alert("Dosya indirilemedi veya açılamadı", Form_Alert.enmType.Error);

                }
            }
        }

        private bool IndirVeAcHttp(string dosyaAdi)
        {
            try
            {
                string httpSunucu = "http://95.0.50.22:1380/"; // HTTP sunucu URL'sini buraya ekleyin
                string klasor = "/bpet_portal/victor_reklam/";

                string indirilenDosyaYolu = Path.Combine(Path.GetTempPath(), dosyaAdi);

                // HTTP sunucusundan dosyayı indirin
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(httpSunucu + klasor + dosyaAdi, indirilenDosyaYolu);
                }

                // Dosyayı varsayılan uygulama ile açma
                System.Diagnostics.Process.Start(indirilenDosyaYolu);

                return true;
            }
            catch (Exception ex)
            {
                this.Alert("Dosya indirilemedi veya açılamadı:  " + ex.Message, Form_Alert.enmType.Error);

                return false;
            }
        }

        private void victorreklamform_Shown(object sender, EventArgs e)
        {
            VerileriCek();
        }

        private void VerileriCek()
        {
            // İlerleme çubuğunu görünür yap
            s.Visible = true;

            System.Threading.Tasks.Task.Run(() =>
            {
                // Gerçek verileri çektiğiniz yere uygun kodları ekleyin
                ListeleDosyalariFtp();

                // İlerleme çubuğunu güncelleyin ve gizle
                this.Invoke((MethodInvoker)delegate
                {
                    s.Value = s.Maximum;
                    s.Visible = false;
                });
            });
        }

        private bool DosyaSilFtp(string dosyaAdi)
        {
            try
            {
                string ftpSunucu = "ftp://95.0.50.22:1381/";
                string kullaniciAdi = "mustafa.ceylan";
                string sifre = "Defne2023";
                string klasor = "/bpet_portal/victor_reklam/";

                string dosyaYolu = klasor + dosyaAdi;

                // FTP sunucusuna bağlanma ve dosyayı silme işlemi
                FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(ftpSunucu + dosyaYolu);
                ftpWebRequest.Credentials = new NetworkCredential(kullaniciAdi, sifre);
                ftpWebRequest.Method = WebRequestMethods.Ftp.DeleteFile;

                using (FtpWebResponse response = (FtpWebResponse)ftpWebRequest.GetResponse())
                {
                    if (response.StatusCode == FtpStatusCode.FileActionOK)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {

                this.Alert("Dosya silinemedi: " + ex.Message, Form_Alert.enmType.Error);

                return false;
            }
        }
        private void victorreklamform_Load(object sender, EventArgs e)
        {
            kullaniciyetkileri();

        }

        private void silButton_Click(object sender, EventArgs e)
        {
            // Önce seçili bir satır olup olmadığını kontrol edin
            if (dataGridView.CurrentRow != null)
            {
                // Seçili satırın indeksini alın
                int rowIndex = dataGridView.CurrentRow.Index;

                // Seçili satırdaki dosya adını alın
                string secilenDosyaAdi = dataGridView.Rows[rowIndex].Cells["DosyaAdi"].Value.ToString();

                // Kullanıcıya silme işlemini onaylatma
                DialogResult result = MessageBox.Show("Dosyayı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Dosya silme işlemi
                    if (DosyaSilFtp(secilenDosyaAdi))
                    {
                        // Dosya başarıyla silindi, DataGridView'i güncelleyin
                        dataGridView.Rows.RemoveAt(rowIndex);
                        this.Alert("Dosya başarıyla silindi!", Form_Alert.enmType.Success);
                    }
                    else
                    {
                        this.Alert("Dosya silinemedi! ", Form_Alert.enmType.Error);
                    }
                }
            }
            else
            {
                this.Alert("Lütfen silmek istediğiniz dosyayı seçin.", Form_Alert.enmType.Error);
            }
        }



    }
}

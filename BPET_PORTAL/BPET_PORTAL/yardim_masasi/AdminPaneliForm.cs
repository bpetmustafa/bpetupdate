using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace destek_otomasyonu
{
    public partial class AdminPaneliForm : Form
    {
        private const string connectionString = "Server=95.0.50.22,1382;Database=bpet_destek;User ID=sa;Password=Mustafa1;";
        private DateTime sonuclandirmaZamani;
        public AdminPaneliForm()
        {
            InitializeComponent();
            LoadTalepler(); // Talepleri DataGridView'e yükle
            LoadSonuclandirmaDurumlari(); // ComboBox'a sonuçlandırma durumlarını yükle
            // Timer'ı başlat
            talepKontrolTimer = new Timer();
            talepKontrolTimer.Interval = 5000; // 5 saniyede bir kontrol etmek için ayarlanmıştır, istediğiniz süreyi ayarlayabilirsiniz
            talepKontrolTimer.Tick += TalepKontrolTimer_Tick;
            talepKontrolTimer.Start();
            // DataGridView'e düğme sütunu ekleme
            // DataGridView görünümünü düzenleme
            dgvTalepler.AutoResizeColumns(); // Sütunları otomatik boyutlandır
            dgvTalepler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Sütun boyutlarını hücre içeriğine göre ayarla
            // Hücre içeriğini istediğiniz yazı tipi ve boyutuyla görüntüleme
            dgvTalepler.DefaultCellStyle.Font = new Font("Arial", 12); // İstediğiniz yazı tipi ve boyutunu kullanabilirsiniz

            // Başlık satırı görünümünü özelleştirme
            dgvTalepler.EnableHeadersVisualStyles = false;
            dgvTalepler.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // İstediğiniz yazı tipi ve boyutunu kullanabilirsiniz

        }
        private void LoadTalepler()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Bekleme süresini güncelle
                    string updateQuery = "UPDATE talepler SET Bekleme_Suresi = DATEDIFF(minute, Talep_Zamani, GETDATE()) WHERE Talep_Durumu = 'Inceleniyor'";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.ExecuteNonQuery();

                    // Talepleri yükle
                    string selectQuery = "SELECT Ad_Soyad, Talep_Turu, TalepNo, Talep_Durumu, Talep_Zamani, " +
                        "Bekleme_Suresi, SLA,Cevaplama_Suresi, Dosya_Adi, " +
                        "CASE WHEN Öncelik_No = 1 THEN 'Çok Öncelikli' WHEN Öncelik_No = 2 THEN 'Öncelikli' WHEN Öncelik_No = 3 THEN 'Normal' ELSE '' END AS Öncelik " +
                        "FROM talepler";

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataTable.Columns.Add("Güncel_Bekleme_Suresi", typeof(int));
                    foreach (DataRow row in dataTable.Rows)
                    {
                        row["Güncel_Bekleme_Suresi"] = Convert.ToInt32(row["Bekleme_Suresi"]);
                    }

                    dgvTalepler.DataSource = dataTable;
                    dgvTalepler.Columns["Cevaplama_Suresi"].Visible = true;
                    dgvTalepler.Columns["Cevaplama_Suresi"].HeaderText = "Cevaplama Süresi";
                    dgvTalepler.Columns["Ad_Soyad"].HeaderText = "Ad Soyad";
                    dgvTalepler.Columns["Talep_Turu"].HeaderText = "Talep Türü";
                    dgvTalepler.Columns["TalepNo"].Visible = false;
                    dgvTalepler.Columns["TalepNo"].HeaderText = "Talep No";
                    dgvTalepler.Columns["Talep_Durumu"].HeaderText = "Talep Durumu";
                    dgvTalepler.Columns["Talep_Zamani"].HeaderText = "Talep Zamanı";
                    dgvTalepler.Columns["Dosya_Adi"].HeaderText = "Dosya Adı";
                    dgvTalepler.Columns["Bekleme_Suresi"].Visible = false;
                    dgvTalepler.Columns["SLA"].Visible = false;
                    dgvTalepler.Columns["Güncel_Bekleme_Suresi"].HeaderText = "Bekleme Süresi";
                    dgvTalepler.Columns["Güncel_Bekleme_Suresi"].Visible = false;

                    foreach (DataGridViewRow row in dgvTalepler.Rows)
                    {
                        if ((row.Cells["Bekleme_Suresi"].Value != null && Convert.ToInt32(row.Cells["Bekleme_Suresi"].Value) > 2880) ||
                            (row.Cells["SLA"].Value != null && row.Cells["SLA"].Value.ToString() == "1"))
                        {
                            row.DefaultCellStyle.BackColor = Color.Red;
                        }
                        
                    }
                    dgvTalepler.Invalidate();
                    dgvTalepler.Refresh();
                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Talepler yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void LoadSonuclandirmaDurumlari()
        {
            cmbSonuclandirmaDurumu.Items.Add("Reddet");
            cmbSonuclandirmaDurumu.Items.Add("Tamamlandı");
            cmbSonuclandirmaDurumu.SelectedIndex = 0;
        }

        private void btnSonuclandir_Click(object sender, EventArgs e)
        {
            if (dgvTalepler.SelectedRows.Count > 0)
            {
                int talepNo = Convert.ToInt32(dgvTalepler.SelectedRows[0].Cells["TalepNo"].Value);
                string sonuclandirmaDurumu = cmbSonuclandirmaDurumu.SelectedItem.ToString();

                // Seçili talebin durumunu kontrol et
                string selectedTalepDurumu = dgvTalepler.SelectedRows[0].Cells["Cevaplama_Suresi"].Value.ToString();
                if (selectedTalepDurumu.Length >= 1)
                {
                    MessageBox.Show("Bu talep zaten sonuçlandırılmış.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Açıklama için bir form oluştur ve kullanıcıdan açıklamayı al
                using (BilgiIslemAciklamaFormu aciklamaFormu = new BilgiIslemAciklamaFormu())
                {
                    DialogResult result = aciklamaFormu.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        string bilgiIslemAciklama = aciklamaFormu.AciklamaTextBox.Text;

                        try
                        {
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();

                                string updateQuery = "UPDATE talepler SET Talep_Durumu = @SonuclandirmaDurumu, Cevaplama_Suresi = DATEDIFF(MINUTE, Talep_Zamani, GETDATE()), Bilgi_islem_aciklama = @BilgiIslemAciklama WHERE TalepNo = @TalepNo";

                                SqlCommand command = new SqlCommand(updateQuery, connection);
                                command.Parameters.AddWithValue("@SonuclandirmaDurumu", sonuclandirmaDurumu);
                                command.Parameters.AddWithValue("@BilgiIslemAciklama", bilgiIslemAciklama);
                                command.Parameters.AddWithValue("@TalepNo", talepNo);

                                command.ExecuteNonQuery();

                                MessageBox.Show("Talep sonuçlandırıldı.");

                                string adSoyad = dgvTalepler.SelectedRows[0].Cells["Ad_Soyad"].Value.ToString();
                                string userEmail = GetUserEmailByTalepNo(talepNo); // Talep sahibinin e-posta adresini al
                                if (!string.IsNullOrEmpty(userEmail))
                                {
                                    SendResultEmail(adSoyad, sonuclandirmaDurumu, bilgiIslemAciklama, userEmail,talepNo); // E-posta gönderme işlemini başlat

                                    LoadTalepler(); // Talepleri güncelle
                                }

                                LoadTalepler(); // Talepleri güncelle
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Talep sonuçlandırılırken bir hata oluştu: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir talep seçin.");
            }
        }
        private string GetUserEmailByTalepNo(int talepNo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = "SELECT Kullanici_Eposta FROM talepler WHERE TalepNo = @TalepNo";

                    SqlCommand command = new SqlCommand(selectQuery, connection);
                    command.Parameters.AddWithValue("@TalepNo", talepNo);

                    return command.ExecuteScalar()?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı e-postası alınırken bir hata oluştu: " + ex.Message);
                return null;
            }
        }

        private void SendResultEmail(string adSoyad, string sonuclandirmaDurumu, string bilgiIslemAciklama, string userEmailAddress,int talepNo)
        {
            try
            {
                // E-posta ayarları
                string smtpServer = "smtp.office365.com";
                int smtpPort = 587;
                string senderEmail = "helpdesk@bpet.com.tr";
                string senderPassword = "Bt2023!!";
                string subject = "Bpet Destek Talebiniz Sonuçlandırıldı!";
                string body = $"Sayın {adSoyad},\n\n{talepNo} numaralı talebiniz sonuçlandırıldı.\n\nSonuçlandırma Durumu: {sonuclandirmaDurumu}\n\nBilgi İşlem Açıklama: {bilgiIslemAciklama}\n\n Bir yanlışlık olduğunu düşünüyorsanız veya sorununuz hala devam ediyorsa lütfen yeni talep oluşturunuz!";

                using (SmtpClient client = new SmtpClient(smtpServer, smtpPort))
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    client.EnableSsl = true;

                    MailMessage mailMessage = new MailMessage(senderEmail, userEmailAddress, subject, body);
                    mailMessage.Bcc.Add(new MailAddress("mustafa.ceylan@bpet.com.tr")); // Gizli alıcı ekleniyor

                    client.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("E-posta gönderilirken bir hata oluştu: " + ex.Message);
            }
        }

        private void TalepKontrolTimer_Tick(object sender, EventArgs e)
        {
            // Yeni talepleri kontrol etmek için bir metod çağır
            KontrolYeniTalepler();
        }
        private void KontrolYeniTalepler()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = "SELECT *, " +
                        "CASE WHEN Öncelik_No = 1 THEN 'Çok Öncelikli' " +
                        "WHEN Öncelik_No = 2 THEN 'Öncelikli' " +
                        "WHEN Öncelik_No = 3 THEN 'Normal' ELSE '' END AS Öncelik " +
                        "FROM talepler " +
                        "WHERE Talep_Durumu = 'Bekliyor' AND iletildi = 0";

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Yeni talepler varsa kullanıcıya bildirim gönder
                    if (dataTable.Rows.Count > 0)
                    {
                        // Sesli uyarı gönder
                        System.Media.SystemSounds.Beep.Play();

                        // Mesaj olarak bildirim göster
                        this.Activate(); // Uygulamayı ön plana çıkar
                        MessageBox.Show("Yeni bir talep var.");

                        // Talepleri güncelle
                        foreach (DataRow row in dataTable.Rows)
                        {
                            row["Talep_Durumu"] = "İnceleniyor";
                            row["iletildi"] = 1;
                        }

                        dgvTalepler.DataSource = dataTable;
                        dgvTalepler.Columns["iletildi"].Visible = false;
                        dgvTalepler.Refresh();

                        // Taleplerin iletildi durumunu güncelle
                        string updateQuery = "UPDATE talepler SET Talep_Durumu = 'İnceleniyor', iletildi = 1 WHERE Talep_Durumu = 'Bekliyor' AND iletildi = 0";

                        SqlCommand command = new SqlCommand(updateQuery, connection);
                        command.ExecuteNonQuery();
                       
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Talepler kontrol edilirken bir hata oluştu: " + ex.Message);
            }
        }



        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seçili talepleri silmek istediğinizden emin misiniz?", "Talep Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Silme işlemini gerçekleştir
                SilSeciliTalepler();
                LoadTalepler();
            }
        }
        private void dgvTalepler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvTalepler.Columns["Dosya_Adi"].Index && e.RowIndex >= 0)
            {
                string dosyaAdi = dgvTalepler.Rows[e.RowIndex].Cells["Dosya_Adi"].Value.ToString();
                OpenFileWithDefaultProgram(dosyaAdi);
            }
        }
        private void OpenFileWithDefaultProgram(string dosyaAdi)
        {
            if (!string.IsNullOrWhiteSpace(dosyaAdi))
            {
                string baseUrl = "http://95.0.50.22:1380/talepfile/";
                string fileUrl = baseUrl + dosyaAdi;

                try
                {
                    // Oluşturulan URL'yi tarayıcıda aç
                    System.Diagnostics.Process.Start(fileUrl);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dosya açılırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Dosya adı boş veya geçersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAciklamaGoster_Click(object sender, EventArgs e)
        {
            if (dgvTalepler.SelectedRows.Count > 0)
            {
                int talepNo = Convert.ToInt32(dgvTalepler.SelectedRows[0].Cells["TalepNo"].Value);

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string selectQuery = "SELECT Açıklama FROM talepler WHERE TalepNo = @TalepNo";

                        SqlCommand command = new SqlCommand(selectQuery, connection);
                        command.Parameters.AddWithValue("@TalepNo", talepNo);

                        string aciklama = command.ExecuteScalar()?.ToString();
                        MessageBox.Show(aciklama, "Talep Açıklaması");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Açıklama alınırken bir hata oluştu: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir talep seçin.");
            }
        }

        private void SilSeciliTalepler()
        {
            foreach (DataGridViewRow row in dgvTalepler.SelectedRows)
            {
                int talepNo = Convert.ToInt32(row.Cells["TalepNo"].Value);

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string deleteQuery = "DELETE FROM talepler WHERE TalepNo = @TalepNo";

                        SqlCommand command = new SqlCommand(deleteQuery, connection);
                        command.Parameters.AddWithValue("@TalepNo", talepNo);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Talepler silinirken bir hata oluştu: " + ex.Message);
                }
            }

            MessageBox.Show("Seçili talepler başarıyla silindi.");

            LoadTalepler(); // Talepleri güncelle
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RaporEkrani adminPaneliForm = new RaporEkrani();
            this.Hide();
            adminPaneliForm.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadTalepler();
        }

        private void AdminPaneliForm_Load(object sender, EventArgs e)
        {
            LoadTalepler();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvTalepler.CurrentCell.RowIndex;
            string dosyaAdi = dgvTalepler.Rows[rowIndex].Cells["Dosya_Adi"].Value.ToString();

            // Fonksiyonu çağır
            OpenFileWithDefaultProgram(dosyaAdi);
        }
    }
}

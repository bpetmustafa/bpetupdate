using BPET_PORTAL.arsiv_uygulamasi;
using BPET_PORTAL.bayitakip;
using BPET_PORTAL.insankaynaklari;
using BPET_PORTAL.profilsayfasi;
using destek_otomasyonu;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPET_PORTAL.admin
{
    public partial class adminform : Form
    {
        private const string connectionString = "Server=95.0.50.22,1382;Database=BPET_PORTAL;User ID=sa;Password=Mustafa1;";
        private Timer adminChatUpdateTimer;
        private mainpage mainForm;
        private FtpManager ftpManager = new FtpManager();

        public adminform(string eposta, mainpage mainForm)
        {
            InitializeComponent();
            epostalabel.Text = eposta;


            this.mainForm = mainForm; // mainForm örneğini burada başlatın


            adminChatUpdateTimer = new Timer();
            adminChatUpdateTimer.Interval = 5000; // 5 saniyede bir güncelleme yap
            adminChatUpdateTimer.Tick += AdminChatUpdateTimer_Tick;
            adminChatUpdateTimer.Start();
        }
        // Admin tarafı için tüm kullanıcı mesajlarını yükleme işlevi
        private void AdminChatUpdateTimer_Tick(object sender, EventArgs e)
        {
            // Timer tetiklendiğinde chat ekranını güncelle
            //LoadAllUserMessages();
            //LoadUserListForAdmin();
        }
        private void InitializeDataGridView()
        {
            // Resim sütunu oluşturun
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
            {
                Name = "ProfilePicture",
                HeaderText = "Profil Resmi",
                Width = 64,
                ImageLayout = DataGridViewImageCellLayout.Zoom
            };
            dataGridView1.Columns.Add(imageColumn);
            dataGridView1.RowTemplate.Height = 64; // Satır yüksekliğini ayarlayın

            LoadUserData();
        }
        private void btnShowUserMessageHistory_Click(object sender, EventArgs e)
        {
            string selectedUserEmail = ExtractUserEmailFromSelectedItem(cmbUserList.SelectedItem as string);

            if (!string.IsNullOrEmpty(selectedUserEmail))
            {
                // Seçilen kullanıcının mesaj geçmişini yükle
                LoadUserMessageHistory(selectedUserEmail);
            }
        }

        private string ExtractUserEmailFromSelectedItem(string selectedItem)
        {
            if (selectedItem != null)
            {
                int indexOfParenthesis = selectedItem.IndexOf(" (Cevaplanmamış)");
                if (indexOfParenthesis != -1)
                {
                    // Eğer "(Cevaplanmamış)" ifadesi varsa, parantez öncesini kullanıcı e-postası olarak al
                    return selectedItem.Substring(0, indexOfParenthesis);
                }
                else
                {
                    // "(Cevaplanmamış)" ifadesi yoksa, direkt olarak seçilen öğeyi kullan
                    return selectedItem;
                }
            }
            return null;
        }

        private void LoadUserMessageHistory(string selectedUserEmail)
        {
            // Veritabanından seçilen kullanıcının ve adminin mesaj geçmişini çek
            string query = "SELECT SenderEmail, MessageText, SendDateTime FROM Messages " +
                           "WHERE (ReceiverEmail = @AdminEposta AND SenderEmail = @SelectedUserEmail) " +
                           "   OR (ReceiverEmail = @SelectedUserEmail AND SenderEmail = @AdminEposta) " +
                           "ORDER BY SendDateTime";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AdminEposta", "admin@bpet.com.tr"); // Admin e-posta adresi
                    command.Parameters.AddWithValue("@SelectedUserEmail", selectedUserEmail);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    txtAdminChat.Clear();
                    while (reader.Read())
                    {
                        string kullaniciEposta = reader.GetString(0);
                        string mesajMetni = reader.GetString(1);
                        DateTime gondermeTarihi = reader.GetDateTime(2);

                        string kimden = (kullaniciEposta == selectedUserEmail) ? "Kullanıcı" : "Admin";

                        // Mesajı ekranda görüntüle
                        txtAdminChat.AppendText($"{kimden} - {gondermeTarihi}: {mesajMetni}{Environment.NewLine}");
                    }

                    reader.Close();
                }
            }
        }

        private void SendAdminResponse(string kullaniciEposta, string mesajMetni)
        {
            // Yeni mesajı veritabanına kaydet
            string insertQuery = "INSERT INTO Messages (SenderEmail, ReceiverEmail, MessageText, SendDateTime) " +
                                 "VALUES (@SenderEmail, @ReceiverEmail, @MessageText, @SendDateTime)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@SenderEmail", "admin@bpet.com.tr"); // Admin e-posta adresi
                    command.Parameters.AddWithValue("@ReceiverEmail", kullaniciEposta);
                    command.Parameters.AddWithValue("@MessageText", mesajMetni);
                    command.Parameters.AddWithValue("@SendDateTime", DateTime.Now);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        // Admin tarafında kullanıcı mesajlarına cevap verme düğmesi olayı
        private void btnAdminRespond_Click(object sender, EventArgs e)
        {
            string selectedUserEmail = ExtractUserEmailFromSelectedItem(cmbUserList.SelectedItem as string);
            string adminResponse = txtAdminResponse.Text.Trim();

            if (!string.IsNullOrEmpty(selectedUserEmail) && !string.IsNullOrEmpty(adminResponse))
            {
                // Adminin cevabını gönder
                SendAdminResponse(selectedUserEmail, adminResponse);

                // Kullanıcının tüm mesajlarını işaretle
                MarkAllUserMessagesAsAnswered(selectedUserEmail);

                // Mesajı ekranda görüntüle
                txtAdminChat.AppendText($"{DateTime.Now} (Admin) - {selectedUserEmail}: {adminResponse}{Environment.NewLine}");

                // Mesaj gönderildikten sonra metin kutusunu temizle
                txtAdminResponse.Clear();
            }
        }

        private void adminform_Load(object sender, EventArgs e)
        {
            // LoadAllUserMessages();
            InitializeDataGridView();
            // Adminin cevap vereceği kullanıcıları yükle
            LoadUserListForAdmin();
            LoadAllUsersForAdmin();

        }

        // Admin tarafında kullanıcıları yükleme işlevi (combobox için)
        private void LoadUserListForAdmin()
        {
            // Veritabanından tüm kullanıcıları çek
            string query = "SELECT DISTINCT SenderEmail FROM Messages WHERE ReceiverEmail = @AdminEposta";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AdminEposta", "admin@bpet.com.tr"); // Admin e-posta adresi

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    cmbUserList.Items.Clear();
                    while (reader.Read())
                    {
                        string kullaniciEposta = reader.GetString(0);

                        // Kullanıcının cevaplanmamış mesajlarını kontrol et
                        if (HasUnansweredMessages(kullaniciEposta))
                        {
                            // Kullanıcı cevaplanmamış mesajlara sahipse, adını kırmızı renkte ve "Cevaplanmamış" olarak işaretle
                            cmbUserList.Items.Add($"{kullaniciEposta} (Cevaplanmamış)");
                        }
                        else
                        {
                            // Kullanıcıya cevaplanmamış mesaj yoksa sadece adını ekleyin
                            cmbUserList.Items.Add(kullaniciEposta);
                        }
                    }

                    reader.Close();
                }
            }
        }

        private bool HasUnansweredMessages(string userEmail)
        {
            // Kullanıcının cevaplanmamış mesajları var mı kontrol et
            string query = "SELECT COUNT(*) FROM Messages " +
                           "WHERE ReceiverEmail = @AdminEposta " +
                           "  AND SenderEmail = @UserEmail " +
                           "  AND Answered = 0"; // Burada "Answered" adında bir sütununuzun olması gerekiyor

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AdminEposta", "admin@bpet.com.tr"); // Admin e-posta adresi
                    command.Parameters.AddWithValue("@UserEmail", userEmail);

                    connection.Open();
                    int unansweredCount = (int)command.ExecuteScalar();

                    return unansweredCount > 0;
                }
            }
        }
        private void LoadAllUsersForAdmin()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT E_Posta FROM users";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                cmbAllUsers.Items.Clear();
                while (reader.Read())
                {
                    string userEmail = reader.GetString(0);
                    cmbAllUsers.Items.Add(userEmail);
                }
                reader.Close();
            }
        }





        private async void LoadUserData()
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Isim_Soyisim, E_Posta, yetkiler, arsiv_yetki, victor_yetki, muhasebe_yetki, bolge_yetki FROM users";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // DataGridView'i doldur
                    dataGridView1.DataSource = dataTable;

                    // DataGridView'i otomatik olarak boyutlandır
                   

                    // DataGridView'i daha güzel göstermek için bazı stil ayarları
                    dataGridView1.BorderStyle = BorderStyle.None;
                    dataGridView1.BackgroundColor = Color.White;
                    dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
                    dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
                    dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(72, 72, 72);
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tüm sütunları otomatik genişlet
                    dataGridView1.DefaultCellStyle.Font = new Font("Arial", 12); // Yazı tipini ve boyutunu ayarla
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        string email = row.Cells["E_Posta"].Value.ToString();
                        row.Cells["ProfilePicture"].Value = await LoadUserImage(email);
                    }
                    //dataGridView1.AutoResizeColumns();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                this.Alert("Veriler Yüklenemedi: " + ex.Message, Form_Alert.enmType.Error);

            }
        }
        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.DataBoundItem is DataRowView dataRowView)
                {
                    DataRow dataRow = dataRowView.Row;
                    if (dataRow.Table.Columns.Contains("ProfilePicture")) // ProfilePicture sütununun varlığını kontrol edin
                    {
                        row.Cells["ProfilePicture"].Value = dataRow["ProfilePicture"];
                    }
                }
            }
        }


        private async Task<Image> LoadUserImage(string email)
        {
            try
            {
                string temizemail = email.Trim();
                string remoteFileUri = ftpManager.GetFileUri(temizemail + ".jpg");
                WebClient wc = new WebClient();
                byte[] bytes = await wc.DownloadDataTaskAsync(remoteFileUri);
                return Image.FromStream(new MemoryStream(bytes));
            }
            catch(Exception ex)
            {
                // Varsayılan resmi yükleyin
               // Console.WriteLine(ex);
                return Properties.Resources.debut; // Varsayılan resmi projenizin kaynaklarına ekleyin
            }
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Çift tıklanan hücrenin bir veri hücresi olduğunu kontrol edin
            if (e.RowIndex >= 0)
            {
                // Seçilen kullanıcının yetkilerini düzenlemek için yeni bir form açın
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                string kullaniciEposta = selectedRow.Cells["E_Posta"].Value.ToString();
                OpenEditUserPermissionsForm(kullaniciEposta);
            }
        }
        private void MarkAllUserMessagesAsAnswered(string userEmail)
        {
            // Kullanıcının tüm mesajlarını "Answered" değerini 1 yaparak işaretle
            string updateQuery = "UPDATE Messages SET Answered = 1 WHERE ReceiverEmail = @AdminEposta AND SenderEmail = @UserEmail";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@AdminEposta", "admin@bpet.com.tr"); // Admin e-posta adresi
                    command.Parameters.AddWithValue("@UserEmail", userEmail);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void OpenEditUserPermissionsForm(string kullaniciEposta)
        {
            // Kullanıcı yetkilerini düzenlemek için yeni bir form açın
            EditUserPermissionsForm editForm = new EditUserPermissionsForm(kullaniciEposta);
            editForm.ShowDialog();
            LoadUserData();
            // Kullanıcı yetkileri düzenlendikten sonra DataGridView'i güncelleyin
        }

        private void livechatbtn_Click(object sender, EventArgs e)
        {
            if (livechat.Visible == true)
            {
                livechat.Visible = false;
            }
            else
            {
                livechat.Visible = true;
            }
        }

        private void senduser_Click(object sender, EventArgs e)
        {
            string selectedUserEmail = cmbAllUsers.SelectedItem as string;
            string adminMessage = txtAdminMessage.Text.Trim();

            if (!string.IsNullOrEmpty(selectedUserEmail) && !string.IsNullOrEmpty(adminMessage))
            {
                // Admin mesajını gönder
                SendAdminMessage(selectedUserEmail, adminMessage);

                // Mesaj gönderildikten sonra metin kutusunu temizle
                txtAdminMessage.Clear();
            }
        }
        private void SendAdminMessage(string recipientEmail, string messageText)
        {
            // Mesajı veritabanına kaydet
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string insertQuery = "INSERT INTO Messages (SenderEmail, ReceiverEmail, MessageText, SendDateTime) " +
                                     "VALUES ('admin@bpet.com.tr', @RecipientEmail, @MessageText, @SendDateTime)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@RecipientEmail", recipientEmail);
                    command.Parameters.AddWithValue("@MessageText", messageText);
                    command.Parameters.AddWithValue("@SendDateTime", DateTime.Now);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string selectedUserEmail = cmbAllUsers.SelectedItem as string;

            if (!string.IsNullOrEmpty(selectedUserEmail))
            {
                LoadUserMessageHistoryForAdmin(selectedUserEmail);
            }
        }
        private void LoadUserMessageHistoryForAdmin(string userEmail)
        {
            string query = "SELECT SenderEmail, MessageText, SendDateTime FROM Messages " +
                           "WHERE (SenderEmail = @UserEmail AND ReceiverEmail = 'admin@bpet.com.tr') " +
                           "OR (SenderEmail = 'admin@bpet.com.tr' AND ReceiverEmail = @UserEmail) " +
                           "ORDER BY SendDateTime ASC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserEmail", userEmail);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    txtAdminChat.Clear();
                    while (reader.Read())
                    {
                        string senderEmail = reader.GetString(0);
                        string messageText = reader.GetString(1);
                        DateTime sendDateTime = reader.GetDateTime(2);

                        string messageSender = senderEmail == "admin@bpet.com.tr" ? "Admin" : "Kullanıcı";

                        // Mesajı ekranda görüntüle
                        txtAdminChat.AppendText($"{messageSender} - {sendDateTime}: {messageText}{Environment.NewLine}");
                    }

                    reader.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mainForm.loadform(new AdminPaneliForm());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mainForm.loadform(new bayitakipmainpage(epostalabel.Text));

        }

        private void adminform_Shown(object sender, EventArgs e)
        {
            LoadUserData(); // Kullanıcı verilerini yükleme

        }
    }
}

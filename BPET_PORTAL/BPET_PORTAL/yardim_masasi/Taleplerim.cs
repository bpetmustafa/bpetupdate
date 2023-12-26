using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace destek_otomasyonu
{
    public partial class Taleplerim : Form
    {
        private const string connectionString = "Server=95.0.50.22,1382;Database=bpet_destek;User ID=sa;Password=Mustafa1;";
        private ContextMenuStrip contextMenuStripAktifTalepler;

        public Taleplerim()
        {
            InitializeComponent();
            LoadAktifTalepler();
            LoadTamamlanmisTalepler();
            contextMenuStripAktifTalepler = new ContextMenuStrip();
            contextMenuStripAktifTalepler.Items.Add("Talebi İptal Et", null, TalebiIptalEt_Click);
            contextMenuStripAktifTalepler.Items.Add("Talebi Düzenle", null, TalebiDuzenle_Click);

            // DataGridView'e ContextMenuStrip'i bağla
            dataGridViewAktifTalepler.ContextMenuStrip = contextMenuStripAktifTalepler;
        }

        private void LoadAktifTalepler()
        {
            // Kullanıcının bilgisayar adına göre "Bekliyor" veya "İnceleniyor" durumundaki talepleri çek
            string query = "SELECT TalepNo, Talep_Turu, Talep_Durumu, Açıklama  FROM talepler WHERE Bilgisayar_Adi = @BilgisayarAdi AND (Talep_Durumu = 'Bekliyor' OR Talep_Durumu = 'İnceleniyor')";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BilgisayarAdi", Environment.MachineName);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // DataTable'ı DataGridView'e bağla
                dataGridViewAktifTalepler.DataSource = dataTable;
            }
        }

        private void LoadTamamlanmisTalepler()
        {
            // Kullanıcının bilgisayar adına göre "Tamamlandı" veya "Reddedildi" durumundaki talepleri çek
            string query = "SELECT TalepNo, Talep_Turu, Açıklama, Bilgi_islem_aciklama, Talep_Durumu FROM talepler WHERE Bilgisayar_Adi = @BilgisayarAdi AND (Talep_Durumu = 'Tamamlandı' OR Talep_Durumu = 'Reddedildi' OR Talep_Durumu = 'RedKullanıcı')";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BilgisayarAdi", Environment.MachineName);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // DataTable'ı DataGridView'e bağla
                dataGridViewTamamlanmisTalepler.DataSource = dataTable;
            }
        }

        private void TalebiIptalEt_Click(object sender, EventArgs e)
        {
            if (dataGridViewAktifTalepler.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dataGridViewAktifTalepler.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridViewAktifTalepler.Rows[selectedRowIndex];

                int talepNo = Convert.ToInt32(selectedRow.Cells["TalepNo"].Value);
                CancelRequest(talepNo);

            }
        }
        private void CancelRequest(int talepNo)
        {
            // Talep durumunu "RedKullanıcı" olarak güncelleme işlemi
            string updateQuery = "UPDATE talepler SET Talep_Durumu = 'RedKullanıcı' WHERE TalepNo = @TalepNo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@TalepNo", talepNo);
                command.ExecuteNonQuery();
            }

            // Güncelleme yapıldıktan sonra DataGridView'ı yeniden yükle
            LoadAktifTalepler();
            LoadTamamlanmisTalepler();
        }
        private void TalebiDuzenle_Click(object sender, EventArgs e)
        {
            if (dataGridViewAktifTalepler.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dataGridViewAktifTalepler.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridViewAktifTalepler.Rows[selectedRowIndex];

                int talepNo = Convert.ToInt32(selectedRow.Cells["TalepNo"].Value);
                EditRequest(talepNo);
            }
        }
        private void EditRequest(int talepNo)
        {
            // Mevcut açıklamayı al
            string currentAciklama = dataGridViewAktifTalepler.CurrentRow.Cells["Açıklama"].Value.ToString();

            // Kullanıcıdan yeni açıklamayı al
            string updatedAciklama = Interaction.InputBox("Yeni Açıklama:", "Talep Güncelleme", currentAciklama);
           
            // Eğer kullanıcı yeni açıklama girdiyse, güncelleme işlemini gerçekleştir
            if (!string.IsNullOrEmpty(updatedAciklama))
            {
                // Talep bilgilerini güncelleme işlemi
                string updateQuery = "UPDATE talepler SET Açıklama = @Açıklama WHERE TalepNo = @TalepNo";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@TalepNo", talepNo);
                    command.Parameters.AddWithValue("@Açıklama", updatedAciklama);

                    command.ExecuteNonQuery();
                }

                // Güncelleme yapıldıktan sonra DataGridView'ı yeniden yükle
                LoadAktifTalepler();
                LoadTamamlanmisTalepler();
            }
        }
    }
}


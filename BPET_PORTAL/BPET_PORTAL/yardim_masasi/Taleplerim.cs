using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace destek_otomasyonu
{
    public partial class Taleplerim : Form
    {
        private const string connectionString = "Server=95.0.50.22,1382;Database=bpet_destek;User ID=sa;Password=Mustafa1;";

        public Taleplerim()
        {
            InitializeComponent();
            LoadAktifTalepler();
            LoadTamamlanmisTalepler();
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
            string query = "SELECT TalepNo, Talep_Turu, Açıklama, Bilgi_islem_aciklama FROM talepler WHERE Bilgisayar_Adi = @BilgisayarAdi AND (Talep_Durumu = 'Tamamlandı' OR Talep_Durumu = 'Reddedildi')";

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
    }
}

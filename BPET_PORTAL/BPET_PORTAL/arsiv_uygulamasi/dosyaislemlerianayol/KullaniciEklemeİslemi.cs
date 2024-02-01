using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BPET_PORTAL.arsiv_uygulamasi.dosyaislemlerianayol
{
    
    public partial class KullaniciEklemeİslemi : UserControl
    {
        private const string connectionString = "Server=95.0.50.22,1382;Database=bpetarsiv;User ID=sa;Password=Mustafa1;";
        private SqlConnection connection;
        public KullaniciEklemeİslemi()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
        }

        private void btnKisiEkle_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                string isimsoyisim = isimsoyisimtxt.Text;
                string telefon = telefontxt.Text;
                string email = emailtxt.Text;

                string insertQuery = "INSERT INTO Kisiler (KisiAdi, Telefon, Email) VALUES (@Name, @phone, @email)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", isimsoyisim);
                    command.Parameters.AddWithValue("@phone", telefon);
                    command.Parameters.AddWithValue("@email", email);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Kişi başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kişi eklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}

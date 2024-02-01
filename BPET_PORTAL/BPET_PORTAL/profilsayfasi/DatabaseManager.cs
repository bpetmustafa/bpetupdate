using System;
using System.Data.SqlClient;
using System.Data;

namespace BPET_PORTAL.profilsayfasi
{
    public class DatabaseManager
    {
        private string connectionString = "Server=95.0.50.22,1382;Database=BPET_PORTAL;User ID=sa;Password=Mustafa1;";

        public DataTable GetUserDetails(string email)
        {
            DataTable userDetails = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Isim_Soyisim, E_Posta, Telefon, MFA_Durumu FROM users WHERE E_Posta = @Email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(userDetails);
                }
            }

            return userDetails;
        }

        public void UpdateMFAStatus(string email, int ac)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE users SET MFA_Durumu = @MFAStatus WHERE E_Posta = @Email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (ac == 1)
                    {
                        command.Parameters.AddWithValue("@MFAStatus", true);
                    }
                    else if (ac == 0)
                    {
                        command.Parameters.AddWithValue("@MFAStatus", false);
                    }
                    command.Parameters.AddWithValue("@Email", email);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}

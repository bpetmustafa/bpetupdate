using System;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace BPET_PORTAL.sms_mfa
{
    public static class mfakontrol
    {
        private static string connectionString = "Server=95.0.50.22,1382;Database=BPET_PORTAL;User ID=sa;Password=Mustafa1;";

        public static bool VerifyUser(string userEmail)
        {
            if (!CheckMFAStatus(userEmail))
            {
                // MFA kapalıysa MessageBox ile uyarı göster
                MessageBox.Show("Hesabınızda 2 Adımlı doğrulama kapalı. Kritik işlemler için bu özelliği profilim kısmından açmanız gerekmektedir!",
                                "MFA Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            // Son başarılı MFA kontrolü
            if (IsVerificationRecentlySuccessful(userEmail))
            {
                //Alert("Otomatik Geçiş MFA!", Form_Alert.enmType.Success);
                return true;

            }

            using (SmsMFAForm mfaForm = new SmsMFAForm(userEmail))
            {
                DialogResult result = mfaForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Doğrulama başarılı
                    return true;
                }
                else
                {
                    Alert("Geçersiz Kod", Form_Alert.enmType.Error);
                    return false;
                }
            }
        }
        private static bool CheckMFAStatus(string userEmail)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MFA_Durumu FROM users WHERE E_Posta = @Email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", userEmail);
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result is bool mfaStatus)
                    {
                        return mfaStatus;
                    }
                }
            }
            return false;
        }

        private static bool IsVerificationRecentlySuccessful(string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Son_MFA_Tarih FROM users WHERE E_Posta = @Email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result is DateTime lastMfaTime)
                    {
                        return (DateTime.Now - lastMfaTime).TotalMinutes <= 60;
                    }
                }
            }

            return false;
        }
        public static void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
    }
}

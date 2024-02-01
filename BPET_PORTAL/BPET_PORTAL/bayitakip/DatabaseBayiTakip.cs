using System;
using System.Data;
using System.Data.SqlClient;

namespace BPET_PORTAL.bayitakip
{
    public class DatabaseBayiTakip
    {
        private string connectionString;

        public DatabaseBayiTakip(string connectionStr)
        {
            connectionString = connectionStr;
        }
        public int GetCevaplananVeriSayisiThisWeek()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DateTime today = DateTime.Today;
                DayOfWeek dayOfWeek = today.DayOfWeek;
                int daysUntilMonday = ((int)DayOfWeek.Monday - (int)dayOfWeek + 7) % 7;
                int daysUntilSunday = ((int)DayOfWeek.Sunday - (int)dayOfWeek + 7) % 7;

                // Bu haftanın başlangıç ve bitiş tarihlerini hesapla
                DateTime startDate = today.AddDays(-daysUntilMonday);
                DateTime endDate = today.AddDays(daysUntilSunday);

                string query = "SELECT COUNT(*) FROM CarihesaplarGecmis WHERE CevaplandiTarih BETWEEN @StartDate AND @EndDate";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    // COUNT sorgusunu çalıştır ve sonucu döndür
                    int cevaplananVeriSayisi = (int)command.ExecuteScalar();

                    return cevaplananVeriSayisi;
                }
            }
        }

        public int GetMailCountInDateRange(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM CariHesaplar WHERE MailTarih >= @StartDate AND MailTarih <= @EndDate";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    int mailCount = (int)command.ExecuteScalar();

                    return mailCount;
                }
            }
        }
        public DataTable GetDistinctBolgeMudurleri()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT DISTINCT BolgeMuduru FROM CarihesaplarGecmis";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        return dataTable;
                    }
                }
            }
        }

        public DataTable GetBolgeMuduruVerileriInDateRange(string bolgeMuduru, DateTime startDate, DateTime endDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT CariHesapUnvani, CevapAciklama, CevaplandiTarih FROM CarihesaplarGecmis WHERE BolgeMuduru = @BolgeMuduru AND CevaplandiTarih BETWEEN @StartDate AND @EndDate";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BolgeMuduru", bolgeMuduru);
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        return dataTable;
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPET_PORTAL.profilsayfasi
{
    public class ik_class
    {
        private string connectionStringUser = "Server=95.0.50.22,1382;Database=BPET_PORTAL;User ID=sa;Password=Mustafa1;";
        private string connectionStringİk = "Server=95.0.50.22,1382;Database=insankaynaklari;User ID=sa;Password=Mustafa1;";

        public DataTable GetUserİkDetails(string isimsoyisim)
        {
            DataTable userikDetails = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionStringİk))
            {
                // ROW_NUMBER() pencere fonksiyonunu kullanarak her kişi için en son sgk_giris kaydını seç
                string query = @"
            SELECT * FROM (
                SELECT 
                    tc, kan_grubu, dogum_tarihi, birim, pozisyon, sgk_giris,
                    ROW_NUMBER() OVER (PARTITION BY tc ORDER BY sgk_giris DESC) as rn
                FROM 
                    personelBilgi 
                WHERE 
                    adi_soyadi = @AdSoyad
            ) as subquery
            WHERE rn = 1"; // En son kaydı seç (rn = 1)

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AdSoyad", isimsoyisim);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(userikDetails);
                }
            }

            return userikDetails;
        }

    }
}

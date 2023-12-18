using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPET_PORTAL.muhasebe.mutabakat.mutabakatislemleri
{
    public partial class mutabakatislemkayit : Form
    {
        private string connectionString = "Server=95.0.50.22,1382;Database=muhasebe;User ID=sa;Password=Mustafa1;";

        public mutabakatislemkayit()
        {
            InitializeComponent();
        }

        private void mutabakatislemkayit_Load(object sender, EventArgs e)
        {
            // İlk yüklemeler veya ayarlamalar burada yapılabilir.
        }

        private void kayit_islemleri_Click(object sender, EventArgs e)
        {
            // Form alanlarından verileri al
            string adi = txtAdiUnvan.Text; // txtAdiUnvan, ilgili TextBox'ın ismi olmalı
            string vergiNo = txtVergiNoTcKimlikNo.Text; // txtVergiNoTcKimlikNo, ilgili TextBox'ın ismi olmalı
            string sonIslemTarihi = dtpSonIslemTarihi.Text; // dtpSonIslemTarihi, ilgili DateTimePicker'ın ismi olmalı
            string mutabakatTarihi = dtpMutabakatTarihi.Text; // dtpMutabakatTarihi, ilgili DateTimePicker'ın ismi olmalı
            decimal borcBakiye = string.IsNullOrEmpty(txtBorcBakiye.Text) ? 0 : Convert.ToDecimal(txtBorcBakiye.Text); // txtBorcBakiye, ilgili TextBox'ın ismi olmalı
            decimal alacakBakiye = string.IsNullOrEmpty(txtAlacakBakiye.Text) ? 0 : Convert.ToDecimal(txtAlacakBakiye.Text); // txtAlacakBakiye, ilgili TextBox'ın ismi olmalı

            try
            {
                // Veritabanı bağlantısını oluştur
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Sorguyu oluştur
                    string query = @"
                        INSERT INTO mutabakat 
                        (adi, vergino, sonislemtarihi, borcbakiye, alacakbakiye, kayittarihi, mutabakattarihi) 
                        VALUES 
                        (@Adi, @VergiNo, @SonIslemTarihi, @BorcBakiye, @AlacakBakiye, GETDATE(), @MutabakatTarihi)";

                    // SqlCommand nesnesini oluştur ve parametreleri ekle
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Adi", adi);
                        command.Parameters.AddWithValue("@VergiNo", vergiNo);
                        command.Parameters.AddWithValue("@SonIslemTarihi", sonIslemTarihi);
                        command.Parameters.AddWithValue("@MutabakatTarihi", mutabakatTarihi);
                        command.Parameters.AddWithValue("@BorcBakiye", borcBakiye);
                        command.Parameters.AddWithValue("@AlacakBakiye", alacakBakiye);

                        // Veritabanı bağlantısını aç ve sorguyu çalıştır
                        connection.Open();
                        command.ExecuteNonQuery();

                        // Başarılı kayıt mesajı
                        MessageBox.Show("Kayıt başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata mesajı
                MessageBox.Show("Kayıt sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

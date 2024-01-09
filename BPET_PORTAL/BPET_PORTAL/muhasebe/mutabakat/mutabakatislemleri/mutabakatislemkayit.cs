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
        private mutabakat mutabakatanaform;
        public mutabakatislemkayit(mutabakat mutabakatanaform)
        {
            InitializeComponent();
            this.mutabakatanaform = mutabakatanaform;
        }

        private void mutabakatislemkayit_Load(object sender, EventArgs e)
        {
        }

        private void kayit_islemleri_Click(object sender, EventArgs e)
        {
            // Form alanlarından verileri al
            string adi = txtAdiUnvan.Text;
            string vergiNo = txtVergiNoTcKimlikNo.Text;
            string sonIslemTarihi = dtpSonIslemTarihi.Text;
            string mutabakatTarihi = dtpMutabakatTarihi.Text;
            if (!decimal.TryParse(txtBorcBakiye.Text, out decimal borcBakiye))
            {
                MessageBox.Show("Borç bakiye değeri geçerli bir sayı değil.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtAlacakBakiye.Text, out decimal alacakBakiye))
            {
                MessageBox.Show("Alacak bakiye değeri geçerli bir sayı değil.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Veritabanı bağlantısını oluştur
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Kontrol sorgusunu oluştur
                    string controlQuery = "SELECT COUNT(*) FROM mutabakat WHERE adi = @Adi AND vergino = @VergiNo AND sonislemtarihi = @SonIslemTarihi AND mutabakattarihi = @MutabakatTarihi AND borcbakiye = @BorcBakiye AND alacakbakiye = @AlacakBakiye";

                    // SqlCommand nesnesini oluştur ve parametreleri ekle
                    using (SqlCommand controlCommand = new SqlCommand(controlQuery, connection))
                    {
                        controlCommand.Parameters.AddWithValue("@Adi", adi);
                        controlCommand.Parameters.AddWithValue("@VergiNo", vergiNo);
                        controlCommand.Parameters.AddWithValue("@SonIslemTarihi", sonIslemTarihi);
                        controlCommand.Parameters.AddWithValue("@MutabakatTarihi", mutabakatTarihi);
                        controlCommand.Parameters.AddWithValue("@BorcBakiye", borcBakiye);
                        controlCommand.Parameters.AddWithValue("@AlacakBakiye", alacakBakiye);
                        // Veritabanı bağlantısını aç ve kontrol sorgusunu çalıştır
                        connection.Open();
                        int rowCount = (int)controlCommand.ExecuteScalar();

                        // Eğer aynı veri varsa, kullanıcıya uyarı ver
                        if (rowCount > 0)
                        {
                            MessageBox.Show("Bu veri zaten var.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // İşlemi sonlandır
                        }
                    }

                    // Sorguyu oluştur
                    string insertQuery = @"
                INSERT INTO mutabakat 
                (adi, vergino, sonislemtarihi, borcbakiye, alacakbakiye, kayittarihi, mutabakattarihi) 
                VALUES 
                (@Adi, @VergiNo, @SonIslemTarihi, @BorcBakiye, @AlacakBakiye, GETDATE(), @MutabakatTarihi)";

                    // SqlCommand nesnesini oluştur ve parametreleri ekle
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Adi", adi);
                        command.Parameters.AddWithValue("@VergiNo", vergiNo);
                        command.Parameters.AddWithValue("@SonIslemTarihi", sonIslemTarihi);
                        command.Parameters.AddWithValue("@MutabakatTarihi", mutabakatTarihi);
                        command.Parameters.AddWithValue("@BorcBakiye", borcBakiye);
                        command.Parameters.AddWithValue("@AlacakBakiye", alacakBakiye);

                        // Sorguyu çalıştır
                        command.ExecuteNonQuery();

                        // Başarılı kayıt mesajı
                        mutabakatanaform.GetDataFromDatabase();
                        //MessageBox.Show("Kayıt başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mutabakatanaform.Alert("Kayıt Eklendi!", Form_Alert.enmType.Success);
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

using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BPET_PORTAL.borsauygulamasi
{
    public partial class DuzenlemeForm : Form
    {
        private string hisseAdi;
        private int adet;
        private decimal maliyet;
        private string eposta;
        private const string connectionString = "Server=95.0.50.22,1382;Database=BPET_PORTAL;User ID=sa;Password=Mustafa1;";

        public DuzenlemeForm(string hisseAdi, int adet, decimal maliyet, string eposta)
        {
            InitializeComponent();
            this.hisseAdi = hisseAdi;
            this.adet = adet;
            this.maliyet = maliyet;
            this.eposta = eposta;
        }

        private void DuzenlemeForm_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde mevcut hissenin bilgilerini göster
            textBoxHisseAdi.Text = hisseAdi;
            numericUpDownAdet.Value = adet;
            numericUpDownMaliyet.Value = maliyet;
        }

        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            string yeniHisseAdi = textBoxHisseAdi.Text.Trim();
            int yeniAdet = (int)numericUpDownAdet.Value;
            decimal yeniMaliyet = numericUpDownMaliyet.Value;

            if (string.IsNullOrEmpty(yeniHisseAdi))
            {
                MessageBox.Show("Lütfen yeni hisse adı girin.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string updateQuery = "UPDATE HisseTablosu SET HisseAdi = @YeniHisseAdi, Adet = @YeniAdet, Maliyet = @YeniMaliyet WHERE HisseAdi = @HisseAdi AND KullaniciEposta = @KullaniciEposta AND Adet = @adet AND Maliyet = @maliyet";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@YeniHisseAdi", yeniHisseAdi);
                    command.Parameters.AddWithValue("@YeniAdet", yeniAdet);
                    command.Parameters.AddWithValue("@YeniMaliyet", yeniMaliyet);
                    command.Parameters.AddWithValue("@HisseAdi", hisseAdi);
                    command.Parameters.AddWithValue("@KullaniciEposta", eposta);
                    command.Parameters.AddWithValue("@maliyet", maliyet);
                    command.Parameters.AddWithValue("@adet", adet);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Hisse başarıyla güncellendi.");
                            this.Close(); // Formu kapat
                            this.DialogResult = DialogResult.OK; // DialogResult OK olarak ayarla

                        }
                        else
                        {
                            MessageBox.Show("Hisse güncellenirken bir hata oluştu.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hisse güncelleme işlemi sırasında bir hata oluştu: " + ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

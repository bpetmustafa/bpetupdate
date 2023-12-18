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
    public partial class mutabakateditform : Form
    {
        private int selectedRecordId;
        private string connectionString = "Server=95.0.50.22,1382;Database=muhasebe;User ID=sa;Password=Mustafa1;";

        public mutabakateditform(int recordId)
        {
            InitializeComponent();
            selectedRecordId = recordId;
        }

        private void mutabakateditform_Load(object sender, EventArgs e)
        {
            LoadData(selectedRecordId);
        }

        private void LoadData(int recordId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM mutabakat WHERE id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", recordId);

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtAdiUnvan.Text = reader["adi"].ToString();
                            txtVergiNoTcKimlikNo.Text = reader["vergino"].ToString();
                            // Son işlem tarihi ve mutabakat tarihi için DateTimePicker kullanıldığını varsayıyorum
                            dtpSonIslemTarihi.Text = reader["sonislemtarihi"].ToString();
                            dtpMutabakatTarihi.Text = reader["mutabakattarihi"].ToString();
                            txtBorcBakiye.Text = reader["borcbakiye"].ToString();
                            txtAlacakBakiye.Text = reader["alacakbakiye"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri yüklenirken bir hata meydana geldi: " + ex.Message);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void SaveChanges()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                UPDATE mutabakat 
                SET 
                    adi = @Adi, 
                    vergino = @VergiNo, 
                    sonislemtarihi = @SonIslemTarihi, 
                    borcbakiye = @BorcBakiye, 
                    alacakbakiye = @AlacakBakiye, 
                    mutabakattarihi = @MutabakatTarihi 
                WHERE 
                    id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", selectedRecordId);
                cmd.Parameters.AddWithValue("@Adi", txtAdiUnvan.Text);
                cmd.Parameters.AddWithValue("@VergiNo", txtVergiNoTcKimlikNo.Text);
                cmd.Parameters.AddWithValue("@SonIslemTarihi", dtpSonIslemTarihi.Text);
                cmd.Parameters.AddWithValue("@BorcBakiye", string.IsNullOrWhiteSpace(txtBorcBakiye.Text) ? 0 : Convert.ToDecimal(txtBorcBakiye.Text));
                cmd.Parameters.AddWithValue("@AlacakBakiye", string.IsNullOrWhiteSpace(txtAlacakBakiye.Text) ? 0 : Convert.ToDecimal(txtAlacakBakiye.Text));
                cmd.Parameters.AddWithValue("@MutabakatTarihi", dtpMutabakatTarihi.Text);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    // MessageBox.Show("Veriler başarıyla güncellendi.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme sırasında bir hata meydana geldi: " + ex.Message);
                }
            }
        }
    }

}

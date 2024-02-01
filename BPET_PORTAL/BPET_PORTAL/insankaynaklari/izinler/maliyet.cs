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

namespace BPET_PORTAL.insankaynaklari.izinler
{
    public partial class maliyet : Form
    {
        public maliyet()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=95.0.50.22,1382;Initial Catalog=insankaynaklari;User ID=sa;Password=Mustafa1;");


        string izin_id;

        private void Ekle()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();

                    SqlCommand query = new SqlCommand("INSERT INTO izinler(birim,toplam_calisan_sayisi,calisilan_gun,aylik_planlanan, devamsizlik_toplam,birgun_calisma_saati,kayip_aylik_calisma,kayip_gun,devamsizlik_oran,ortalama_maliyet,devamsizlik_maliyet,ay,yil) VALUES(@birim,@toplam_calisan_sayisi,@calisilan_gun,@aylik_planlanan, @devamsizlik_toplam,@birgun_calisma_saati,@kayip_aylik_calisma,@kayip_gun,@devamsizlik_oran,@ortalama_maliyet,@devamsizlik_maliyet,@ay,@yil)", conn);
                    query.Parameters.AddWithValue("@birim", cbbirim.SelectedItem);
                    query.Parameters.AddWithValue("@toplam_calisan_sayisi", nudTCS.Value);
                    query.Parameters.AddWithValue("@calisilan_gun", nudCG.Value);
                    query.Parameters.AddWithValue("@aylik_planlanan", nudPCS.Value);
                    query.Parameters.AddWithValue("@devamsizlik_toplam", nudDT.Value);
                    query.Parameters.AddWithValue("@birgun_calisma_saati", nudBGCS.Value);
                    query.Parameters.AddWithValue("@kayip_aylik_calisma", nudKACS.Value);
                    query.Parameters.AddWithValue("@kayip_gun", nudKG.Value);
                    query.Parameters.AddWithValue("@devamsizlik_oran", nudDO.Value);
                    query.Parameters.AddWithValue("@ortalama_maliyet", nudOIM.Value);
                    query.Parameters.AddWithValue("@devamsizlik_maliyet", nudDM.Value);
                    query.Parameters.AddWithValue("@ay", cbAy.SelectedItem);
                    query.Parameters.AddWithValue("@yil", txtYil.Text);

                    query.ExecuteNonQuery();
                    conn.Close();
                    dgvDoldur();
                    MessageBox.Show("Başarı İle Eklendi");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            Ekle();
        }

        private void AylikPlananlan()
        {
            decimal tcs = nudTCS.Value;
            decimal cg = nudCG.Value;
            decimal bgcs = nudBGCS.Value;

            nudPCS.Value = (tcs * cg * bgcs);
        }

        private void KayipAylik()
        {
            decimal drit = nudDT.Value;
            decimal bgcs = nudBGCS.Value;

            nudKACS.Value = (drit * bgcs);

        }

        private void DevamsizOran()
        {
            decimal kacs = nudKACS.Value;
            decimal apcs = nudPCS.Value;

            nudDO.Value = ((kacs * 100) / apcs);
        }

        private void kayipGun()
        {
            decimal kacs = nudKACS.Value;

            nudKG.Value = (kacs / 225);
        }

        private void DevamsizlikMaliyet()
        {

            decimal oim = nudOIM.Value;
            decimal kacs = nudKACS.Value;

            nudDM.Value = ((oim * kacs) / 225);
        }
        private void maliyet_Load(object sender, EventArgs e)
        {
            dgvDoldur();
        }




        private void dgvDoldur()
        {
            dgvMaliyet.Rows.Clear();
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    string id, birim, toplam_calisan_sayisi, calisilan_gun, aylik_planlanan, devamsizlik_toplam, birgun_calisma_saati, kayip_aylik_calisma, kayip_gun, devamsizlik_oran, ortalama_maliyet, devamsizlik_maliyet;
                    SqlCommand query = new SqlCommand("SELECT * FROM izinler", conn);

                    SqlDataReader dr = query.ExecuteReader();
                    while (dr.Read())
                    {
                        id = dr["izin_id"].ToString();
                        birim = dr["birim"].ToString();
                        toplam_calisan_sayisi = dr["toplam_calisan_sayisi"].ToString();
                        calisilan_gun = dr["calisilan_gun"].ToString();
                        aylik_planlanan = dr["aylik_planlanan"].ToString();
                        devamsizlik_toplam = dr["devamsizlik_toplam"].ToString();
                        birgun_calisma_saati = dr["birgun_calisma_saati"].ToString();
                        kayip_aylik_calisma = dr["kayip_aylik_calisma"].ToString();
                        kayip_gun = dr["kayip_gun"].ToString();
                        devamsizlik_oran = dr["devamsizlik_oran"].ToString();
                        ortalama_maliyet = dr["ortalama_maliyet"].ToString();
                        devamsizlik_maliyet = dr["devamsizlik_maliyet"].ToString();

                        dgvMaliyet.Rows.Add(id, birim, toplam_calisan_sayisi, calisilan_gun, aylik_planlanan, devamsizlik_toplam, birgun_calisma_saati, kayip_aylik_calisma, kayip_gun, devamsizlik_oran, ortalama_maliyet, devamsizlik_maliyet);

                    }
                    dr.Close();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Hesapla_Click(object sender, EventArgs e)
        {
            AylikPlananlan();
            KayipAylik();
            DevamsizOran();
            kayipGun();
            DevamsizlikMaliyet();
            dgvDoldur();

        }

        private void dgvMaliyet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            izin_id = dgvMaliyet.CurrentRow.Cells[0].Value.ToString();
            cbbirim.Text = dgvMaliyet.CurrentRow.Cells[1].Value.ToString();
            nudTCS.Value = Convert.ToDecimal(dgvMaliyet.CurrentRow.Cells[2].Value);
            nudCG.Value = Convert.ToDecimal(dgvMaliyet.CurrentRow.Cells[3].Value);
            nudPCS.Value = Convert.ToDecimal(dgvMaliyet.CurrentRow.Cells[4].Value.ToString());
            nudDT.Value = Convert.ToDecimal(dgvMaliyet.CurrentRow.Cells[5].Value.ToString());
            nudKACS.Value = Convert.ToDecimal(dgvMaliyet.CurrentRow.Cells[7].Value.ToString());
            nudKG.Value = Convert.ToDecimal(dgvMaliyet.CurrentRow.Cells[8].Value.ToString());
            nudDM.Value = Convert.ToDecimal(dgvMaliyet.CurrentRow.Cells[9].Value.ToString());
            nudDO.Value = Convert.ToDecimal(dgvMaliyet.CurrentRow.Cells[10].Value.ToString());
            nudOIM.Value = Convert.ToDecimal(dgvMaliyet.CurrentRow.Cells[11].Value.ToString());
        }

        private void guncelle(string id)

        {
            try
            {
                conn.Open();
                //SqlCommand query = new SqlCommand("UPDATE izinler SET birim='" + cbbirim.Text + "',toplam_calisan_sayisi='" + nudTCS.Value + "',calisilan_gun='" + nudCG.Value + "',aylik_planlanan='" + nudPCS.Value + "',devamsizlik_toplam='" + nudDT.Value + "',kayip_aylik_calisma='" + nudKACS.Value + "',kayip_gun='" + nudKG.Value + "',devamsizlik_oran='" + nudDO.Value + "',ortalama_maliyet='" + nudOIM.Value + "',devamsizlik_maliyet='" + nudDM.Value + "' WHERE izin_id='" + id + "'", conn);
                //query.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE izinler SET birim=@birim,toplam_calisan_sayisi=@toplam_calisan_sayisi, calisilan_gun=@calisilan_gun, aylik_planlanan=@aylik_planlanan, devamsizlik_toplam=@devamsizlik_toplam, kayip_aylik_calisma=@kayip_aylik_calisma, kayip_gun=@kayip_gun, devamsizlik_oran=@devamsizlik_oran, ortalama_maliyet=@ortalama_maliyet, devamsizlik_maliyet=@devamsizlik_maliyet WHERE izin_id=@id",conn);
                query.Parameters.AddWithValue("@id", id);
                query.Parameters.AddWithValue("@birim",cbbirim.Text);
                query.Parameters.AddWithValue("@toplam_calisan_sayisi", nudTCS.Value);
                query.Parameters.AddWithValue("@calisilan_gun", nudCG.Value);
                query.Parameters.AddWithValue("@aylik_planlanan", nudPCS.Value);
                query.Parameters.AddWithValue("@devamsizlik_toplam",nudDT.Value);
                query.Parameters.AddWithValue("@kayip_aylik_calisma",nudKACS.Value);
                query.Parameters.AddWithValue("@kayip_gun", nudKG.Value);
                query.Parameters.AddWithValue("@devamsizlik_oran",nudDO.Value);
                query.Parameters.AddWithValue("@ortalama_maliyet",nudOIM.Value);
                query.Parameters.AddWithValue("@devamsizlik_maliyet", nudDM.Value);

                query.ExecuteNonQuery();
                
                conn.Close();
                MessageBox.Show("Güncellendi");
                dgvDoldur();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            guncelle(izin_id);
        }
    }

}





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

namespace BPET_PORTAL.insankaynaklari.egitim
{
    public partial class egitimEkle : Form
    {
        public egitimEkle()
        {
            InitializeComponent();

        }
        SqlConnection conn = new SqlConnection("Server=95.0.50.22,1382;Initial Catalog=insankaynaklari;User ID=sa;Password=Mustafa1;");
        DataTable dt = new DataTable();

        string egitimid;

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            EgitimEkle();          
        }
       
        private void EgitimEkle()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    SqlCommand query = new SqlCommand("INSERT INTO egitim(egitim_adi, egitim_konusu,egitim_yili,katilimci_sayisi,planlanan_egitim_saati,gerceklesen_egitim_saati) VALUES(@egitim_adi,@egitim_konusu,@egitim_yili,@katilimci_sayisi,@planlanan_egitim_saati,@gerceklesen_egitim_saati)", conn);

                    query.Parameters.AddWithValue("@egitim_adi", txt_egitimAdi.Text);
                    query.Parameters.AddWithValue("@egitim_konusu", rtxtEgitimKonusu.Text);
                    query.Parameters.AddWithValue("@egitim_yili", txtEgitimYili.Text);
                    query.Parameters.AddWithValue("@katilimci_sayisi", txtKatilimciSayisi.Text);
                    query.Parameters.AddWithValue("@planlanan_egitim_saati", txtPlananEgitimSaati.Text);
                    query.Parameters.AddWithValue("@gerceklesen_egitim_saati", txtGerceklesenEgitimSaati.Text);


                    query.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Kayıt Eklendi");
                    dgvDoldur();
                    temizle();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void egitimEkle_Load(object sender, EventArgs e)
        {
            dgvDoldur();
        }

        private void dgvDoldur()
        {
            dgvegitim.Rows.Clear();
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    
                    string id, egitim_adi, egitim_konusu, egitim_yili, katilimci_sayisi;
                    SqlCommand query = new SqlCommand("SELECT * FROM egitim", conn);

                    SqlDataReader dr = query.ExecuteReader();
                    while (dr.Read())
                    {
                        id = dr["id"].ToString();
                        egitim_adi = dr["egitim_adi"].ToString();
                        egitim_konusu = dr["egitim_konusu"].ToString();
                        egitim_yili = dr["egitim_yili"].ToString();
                        katilimci_sayisi = dr["katilimci_sayisi"].ToString();

                        dgvegitim.Rows.Add(id, egitim_adi, egitim_konusu, egitim_yili, katilimci_sayisi);


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

        private void dgvegitim_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             egitimid = dgvegitim.CurrentRow.Cells[0].Value.ToString(); 
            txt_egitimAdi.Text = dgvegitim.CurrentRow.Cells[1].Value.ToString(); 
            rtxtEgitimKonusu.Text = dgvegitim.CurrentRow.Cells[2].Value.ToString();
            txtEgitimYili.Text = dgvegitim.CurrentRow.Cells[3].Value.ToString(); 
            txtKatilimciSayisi.Text = dgvegitim.CurrentRow.Cells[4].Value.ToString(); 

        }

        private void egitimGuncelle(string id)
        {
            conn.Open();
            SqlCommand query = new SqlCommand("UPDATE egitim SET egitim_adi='" + txt_egitimAdi.Text + "', egitim_konusu='" + rtxtEgitimKonusu.Text + "', egitim_yili='" + txtEgitimYili.Text + "',katilimci_sayisi='" + txtKatilimciSayisi.Text + "' WHERE id='"+id+"'", conn);
            query.ExecuteNonQuery();

            conn.Close();
            MessageBox.Show("Güncellendi");
            dgvDoldur();
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            egitimGuncelle(egitimid);
        }


        private void egitimFiltrele()
        {
            dt.Clear();
            conn.Open();


            SqlDataAdapter query = new SqlDataAdapter("SELECT * FROM egitim WHERE egitim_adi LIKE  '%" + txt_egitimAdi.Text + "%'", conn);

            query.Fill(dt);
            dgvegitim.DataSource = dt;
            conn.Close();

        }


        private void temizle()
        {
            txt_egitimAdi.Text = string.Empty;
            rtxtEgitimKonusu.Text = string.Empty;
            txtEgitimYili.Text = string.Empty;
            txtKatilimciSayisi.Text = string.Empty;
            txtPlananEgitimSaati.Text = string.Empty;
            txtGerceklesenEgitimSaati.Text = string.Empty;

        }

        private void btn_ara_Click(object sender, EventArgs e)
        {
            egitimFiltrele();
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}

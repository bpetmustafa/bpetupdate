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

namespace BPET_PORTAL.insankaynaklari.performans
{
    public partial class sirketSinav : Form
    {
        public sirketSinav()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=95.0.50.22,1382;Initial Catalog=insankaynaklari;User ID=sa;Password=Mustafa1;");
        string sinav_id;
        private void btn_ekle_Click(object sender, EventArgs e)
        {
            sinavEkle();
        }
        private void sinavEkle()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();

                    SqlCommand query = new SqlCommand("INSERT INTO sinav(isim,soyisim,departman,sinav_adi,sinav_yili,sinav_puani,tc) VALUES(@isim,@soyisim,@departman,@sinav_adi,@sinav_yili,@sinav_puani,@tc)", conn);

                    query.Parameters.AddWithValue("@isim", txtIsim.Text);
                    query.Parameters.AddWithValue("@soyisim", txtSoyisim.Text);
                    query.Parameters.AddWithValue("@departman", cbDepartman.SelectedItem);
                    query.Parameters.AddWithValue("@sinav_adi", txtSinavAdi.Text);
                    query.Parameters.AddWithValue("@sinav_yili", txtSinavYili.Text);
                    query.Parameters.AddWithValue("@sinav_puani", txtSinavPuani.Text);
                    query.Parameters.AddWithValue("@tc", txttc.Text);

                    query.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Başarı ile eklendi");
                    dgvDoldur();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sirketSinav_Load(object sender, EventArgs e)
        {
            dgvDoldur();
        }

        private void dgvDoldur()
        {
            dgvSinav.Rows.Clear();
            try
            {
                if(conn.State == ConnectionState.Closed)
                {
                    string id,isim, soyisim, tc, departman, sinav_adi, sinav_yili, sinav_puani;
                    conn.Open();
                    SqlCommand query = new SqlCommand("SELECT * FROM sinav ", conn);

                    SqlDataReader dr = query.ExecuteReader();
                    while (dr.Read())
                    {
                        id = dr["sinav_id"].ToString();
                        isim = dr["isim"].ToString();
                        soyisim = dr["soyisim"].ToString();
                        tc = dr["tc"].ToString();
                        departman = dr["departman"].ToString();
                        sinav_adi = dr["sinav_adi"].ToString();
                        sinav_yili = dr["sinav_yili"].ToString();
                        sinav_puani = dr["sinav_puani"].ToString();

                        dgvSinav.Rows.Add(id, isim, soyisim, tc, departman, sinav_adi, sinav_yili, sinav_puani);
                    }
                    dr.Close();
                    conn.Close();
              
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            txtIsim.Text = "";
            txtSinavAdi.Text = "";
            txtSinavPuani.Text = "";
            txtSinavYili.Text = "";
            txtSoyisim.Text = "";
            txttc.Text = "";
            cbDepartman.Items.Clear();

        }

        private void dgvSinav_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sinav_id = dgvSinav.CurrentRow.Cells[0].Value.ToString();
            txtIsim.Text = dgvSinav.CurrentRow.Cells[1].Value.ToString();
            txtSoyisim.Text = dgvSinav.CurrentRow.Cells[2].Value.ToString();
            txttc.Text = dgvSinav.CurrentRow.Cells[3].Value.ToString();
            cbDepartman.SelectedItem = dgvSinav.CurrentRow.Cells[4].Value.ToString();
            txtSinavAdi.Text = dgvSinav.CurrentRow.Cells[5].Value.ToString();
            txtSinavYili.Text = dgvSinav.CurrentRow.Cells[6].Value.ToString();
            txtSinavPuani.Text = dgvSinav.CurrentRow.Cells[7].Value.ToString();

        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            sinavGuncelle(sinav_id);
        }

        private void sinavGuncelle(string id)
        {
            conn.Open();
            SqlCommand query = new SqlCommand("UPDATE sinav SET "+" isim='"+txtIsim.Text+"',soyisim='"+txtSoyisim.Text+"',departman='"+cbDepartman.SelectedItem+"',sinav_adi='"+txtSinavAdi.Text+"',sinav_yili='"+txtSinavYili.Text+"',sinav_puani='"+txtSinavPuani.Text+"',tc='"+txttc.Text+"' WHERE sinav_id='"+id+"'",conn);
            query.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Başarı ile güncellendi");
            dgvDoldur();
        }

        
    }
}

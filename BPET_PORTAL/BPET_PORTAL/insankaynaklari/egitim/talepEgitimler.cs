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
using System.Windows.Forms.DataVisualization.Charting;

namespace BPET_PORTAL.insankaynaklari.egitim
{
    public partial class talepEgitimler : Form
    {
        public talepEgitimler()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Server=95.0.50.22,1382;Initial Catalog=insankaynaklari;User ID=sa;Password=Mustafa1;");

        string connectionString = ("Server=95.0.50.22,1382;Initial Catalog=insankaynaklari;User ID=sa;Password=Mustafa1;");

        string talepid;

        private void talepEgitimEkle()
        {
            dgvTalepEgitim.Rows.Clear();
            try
            {
                
                if (conn.State == ConnectionState.Closed)
                {
                    
                    conn.Open();
                    SqlCommand query = new SqlCommand("INSERT INTO egitimTalep(talep_eden_departman, talep_edilen_yil, egitimin_konusu) VALUES(@talep_eden_departman, @talep_edilen_yil, @egitimin_konusu)", conn);
                    MessageBox.Show("test");
                    query.Parameters.AddWithValue("@talep_eden_departman", cbTalepDepartman.Text);
                    query.Parameters.AddWithValue("@talep_edilen_yil", txtTalepYil.Text);
                    query.Parameters.AddWithValue("@egitimin_konusu", rtxtEgitimKonusu.Text);


                    query.ExecuteNonQuery();
                   

                }
                conn.Close();
                dgvTalepEgitimDoldur();
                MessageBox.Show("Kayıt Eklendi");
                cbTalepDepartman.Text = "";
                txtTalepYil.Text = "";
                rtxtEgitimKonusu.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

 


        private void dgvTalepEgitimDoldur()
        {
            dgvTalepEgitim.Rows.Clear();
            try
            {
                if (conn.State == ConnectionState.Closed)
                {

                    conn.Open();
                    string id, departman, yil, konu;
                    SqlCommand query = new SqlCommand("SELECT * FROM egitimTalep", conn);

                    SqlDataReader dr = query.ExecuteReader();


                    while (dr.Read())
                    {

                        id = dr["id"].ToString();
                        departman = dr["talep_eden_departman"].ToString();
                        konu = dr["egitimin_konusu"].ToString();
                        yil = dr["talep_edilen_yil"].ToString();


                        dgvTalepEgitim.Rows.Add(id, departman, konu, yil);

                    }

                    dr.Close();
                    conn.Close();

                    cbTalepDepartman.Text = "";
                    txtTalepYil.Text = "";
                    rtxtEgitimKonusu.Text = "";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chartEkle()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    string query = ("SELECT talep_eden_departman, ((COUNT(*)*100)/(select count(*) from egitimTalep)) as toplam_talep FROM egitimTalep GROUP BY talep_eden_departman ");

                    DataTable dt = GetData(query);


                    string[] x = (from p in dt.AsEnumerable()
                                  orderby
                                p.Field<string>("talep_eden_departman") ascending
                                  select p.Field<string>("talep_eden_departman")).ToArray();

                    int[] y = (from p in dt.AsEnumerable()
                               orderby p.Field<string>("talep_eden_departman") ascending
                               select p.Field<int>("toplam_talep")).ToArray();

                    chart1.Series[0].ChartType = SeriesChartType.Pie;
                    chart1.Series[0].Points.DataBindXY(x, y);
                    chart1.Legends[0].Enabled = true;
                    chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
                }
                conn.Close();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static DataTable GetData(string query)
        {
            string constr = "Server=95.0.50.22,1382;Initial Catalog=insankaynaklari;User ID=sa;Password=Mustafa1;";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
        }

        private void btn_Ekle_Click(object sender, EventArgs e)
        {
            talepEgitimEkle();
            chartEkle();
        }

        private void talepEgitimler_Load(object sender, EventArgs e)
        {
            dgvTalepEgitimDoldur();
            chartEkle();
            ComboboxlariDoldur();
        }

        private void dgvTalepEgitim_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            talepid = dgvTalepEgitim.CurrentRow.Cells[0].Value.ToString();
            cbTalepDepartman.Text = dgvTalepEgitim.CurrentRow.Cells[1].Value.ToString();
          
            rtxtEgitimKonusu.Text = dgvTalepEgitim.CurrentRow.Cells[2].Value.ToString();
            txtTalepYil.Text = dgvTalepEgitim.CurrentRow.Cells[3].Value.ToString();

        }
        private void talepGuncelle(string id)
        {
            dgvTalepEgitim.Rows.Clear();
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    SqlCommand query = new SqlCommand("UPDATE egitimTalep SET talep_eden_departman=@talep_eden_departman,talep_edilen_yil=@talep_edilen_yil,egitimin_konusu=@egitimin_konusu WHERE id=@id", conn);
                    query.Parameters.AddWithValue("@id", id);
                    query.Parameters.AddWithValue("@talep_eden_departman", cbTalepDepartman.Text);
                    query.Parameters.AddWithValue("@talep_edilen_yil", txtTalepYil.Text);
                    query.Parameters.AddWithValue("@egitimin_konusu", rtxtEgitimKonusu.Text);
                    query.ExecuteNonQuery();
                   
                  
                 
                }
                conn.Close();
                MessageBox.Show("Güncellendi");
                dgvTalepEgitimDoldur();
                cbTalepDepartman.Text = "";
                txtTalepYil.Text = "";
                rtxtEgitimKonusu.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ComboboxlariDoldur()
        {

            // Bölüm combobox'ını doldur
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT birim FROM personelBilgi";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string birim = reader.GetString(0);
                    cbTalepDepartman.Items.Add(birim);
                }
            }

        }
        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            talepGuncelle(talepid);
            chartEkle();
        }
    }
}

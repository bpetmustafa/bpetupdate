using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BPET_PORTAL.insankaynaklari.calisanBilgisi
{
    public partial class egitimDurum : Form
    {
        public egitimDurum()
        {
            InitializeComponent();
        }
        string connectionString = ("Server=95.0.50.22,1382;Initial Catalog=insankaynaklari;User ID=sa;Password=Mustafa1;");
        SqlConnection conn = new SqlConnection("Server=95.0.50.22,1382;Initial Catalog=insankaynaklari;User ID=sa;Password=Mustafa1;");

        private void ComboboxlariDoldur()
        {

            // Bölüm combobox'ını doldur
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT sirket FROM personelBilgi";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string sirket = reader.GetString(0);
                    cmbKategori.Items.Add(sirket);
                }
            }

        }

        private void egitimDurum_Load(object sender, EventArgs e)
        {
            ComboboxlariDoldur();
            doldur();
            chartDoldur();
        }

        private void doldur()
        {
            string kategori = (string)cmbKategori.SelectedItem;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query7 = "select  count(no) as toplam from personelBilgi  ";
                if (cmbKategori.SelectedIndex > -1)
                {
                    query7 += "where  sirket='" + cmbKategori.SelectedItem.ToString() + "'";
                }
                
                SqlCommand cmd7 = new SqlCommand(query7, connection);
                SqlDataReader dr7 = cmd7.ExecuteReader();
                while (dr7.Read())
                {
                    label15.Text = dr7.GetValue(0).ToString();
                }
                connection.Close();


                connection.Open();
                string query = "select  count(ogrenim) from personelBilgi where ogrenim='İlköğretim' ";
                if (cmbKategori.SelectedIndex > -1)
                {
                    query += "and sirket='"+cmbKategori.SelectedItem.ToString()+"'";
                }
               

                SqlCommand cmd= new SqlCommand(query, connection);
                SqlDataReader dr= cmd.ExecuteReader();
                while (dr.Read())
                {
                    label2.Text = dr.GetValue(0).ToString();
                }

                connection.Close();
                connection.Open ();

                string query1 = "select  count(ogrenim) from personelBilgi where ogrenim='Ortaokul' ";
                if (cmbKategori.SelectedIndex > -1)
                {
                    query1 += "and sirket='" + cmbKategori.SelectedItem.ToString() + "'";
                }


                SqlCommand cmd1 = new SqlCommand(query1, connection);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                while (dr1.Read())
                {
                    label5.Text = dr1.GetValue(0).ToString();
                }
                connection.Close();
                connection.Open();

                string query2 = "select  count(ogrenim) from personelBilgi where ogrenim='Lise' ";
                if (cmbKategori.SelectedIndex > -1)
                {
                    query2 += "and sirket='" + cmbKategori.SelectedItem.ToString() + "'";
                }


                SqlCommand cmd2 = new SqlCommand(query2, connection);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    label8.Text = dr2.GetValue(0).ToString();
                }
                connection.Close();
                connection.Open();

                string query3 = "select  count(ogrenim) from personelBilgi where ogrenim='Lise Meslek' ";
                if (cmbKategori.SelectedIndex > -1)
                {
                    query3 += "and sirket='" + cmbKategori.SelectedItem.ToString() + "'";
                }


                SqlCommand cmd3 = new SqlCommand(query3, connection);
                SqlDataReader dr3 = cmd3.ExecuteReader();
                while (dr3.Read())
                {
                    label11.Text = dr3.GetValue(0).ToString();
                }
                connection.Close();
                connection.Open();

                string query4 = "select  count(ogrenim) from personelBilgi where ogrenim='Ön Lisans' ";
                if (cmbKategori.SelectedIndex > -1)
                {
                    query4 += "and sirket='" + cmbKategori.SelectedItem.ToString() + "'";
                }


                SqlCommand cmd4 = new SqlCommand(query4, connection);
                SqlDataReader dr4 = cmd4.ExecuteReader();
                while (dr4.Read())
                {
                    label9.Text = dr4.GetValue(0).ToString();
                }
                connection.Close();
                connection.Open();

                string query5 = "select  count(ogrenim) from personelBilgi where ogrenim='Lisans' ";
                if (cmbKategori.SelectedIndex > -1)
                {
                    query5 += "and sirket='" + cmbKategori.SelectedItem.ToString() + "'";
                }


                SqlCommand cmd5 = new SqlCommand(query5, connection);
                SqlDataReader dr5 = cmd5.ExecuteReader();
                while (dr5.Read())
                {
                    label3.Text = dr5.GetValue(0).ToString();
                }
                connection.Close();
                connection.Open();
                string query6 = "select  count(ogrenim) from personelBilgi where ogrenim='Yüksek Lisans' ";
                if (cmbKategori.SelectedIndex > -1)
                {
                    query6 += "and sirket='" + cmbKategori.SelectedItem.ToString() + "'";
                }


                SqlCommand cmd6 = new SqlCommand(query6, connection);
                SqlDataReader dr6 = cmd6.ExecuteReader();
                while (dr6.Read())
                {
                    label13.Text = dr6.GetValue(0).ToString();
                }
                connection.Close();

            }
   
        }

        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            doldur();
            chartDoldur();
        }

        private void chartDoldur()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    string query = "SELECT ogrenim, ((COUNT(*) * 100) / (SELECT COUNT(*) FROM personelBilgi";
                        if (cmbKategori.SelectedIndex > -1)
                    {
                       query+= " where sirket='"+cmbKategori.SelectedItem.ToString()+"' ";
                    }
                    query += " )) AS yuzde_oran FROM personelBilgi";


                    if (cmbKategori.SelectedIndex > -1)
                    {
                        query += " where sirket='" + cmbKategori.SelectedItem.ToString() + "' ";
                    }
                   
                    query += " group by ogrenim";
                  
                    Console.WriteLine(query);
                   
                    DataTable dt = GetData(query);



                    string[] x = (from p in dt.AsEnumerable()
                                  orderby
                                p.Field<string>("ogrenim") ascending
                                  select p.Field<string>("ogrenim")).ToArray();
                    Console.WriteLine(x.Length);
                    int[] y = (from p in dt.AsEnumerable()
                               orderby p.Field<string>("ogrenim") ascending
                               select p.Field<int>("yuzde_oran")).ToArray();
                    Console.WriteLine(y.Length);
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
    }
}

using Org.BouncyCastle.Crypto.Macs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BPET_PORTAL.insankaynaklari.calisanBilgisi
{
    public partial class calisanDetay : Form
    {

        string connectionString = ("Server=95.0.50.22,1382;Initial Catalog=insankaynaklari;User ID=sa;Password=Mustafa1;");
        SqlConnection conn = new SqlConnection("Server=95.0.50.22,1382;Initial Catalog=insankaynaklari;User ID=sa;Password=Mustafa1;");


        public calisanDetay()
        {
            InitializeComponent();
        }

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
        private void VerileriDoldur()
        {
            string kategori = (string)cmbKategori.SelectedItem;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "select  count(cinsiyet) from personelBilgi  where cinsiyet='k'";
                if (cmbKategori.SelectedIndex > -1)
                {
                    query += "and sirket = '" + cmbKategori.SelectedItem.ToString() + "'";

                }

                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader dr = cmd.ExecuteReader();
                Console.WriteLine(query);
                while (dr.Read())
                {
                    label2.Text = dr.GetValue(0).ToString();
                }
                dr.Close();
                string query2 = "select  count(cinsiyet) from personelBilgi  where cinsiyet='e'";
                if (cmbKategori.SelectedIndex > -1)
                {
                    query2 += "and sirket = '" + cmbKategori.SelectedItem.ToString() + "'";

                }

                SqlCommand cmd2 = new SqlCommand(query2, connection);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                Console.WriteLine(query2);
                while (dr2.Read())
                {
                    label5.Text = dr2.GetValue(0).ToString();
                }
                double kadın, erkek;
                kadın = int.Parse(label2.Text); erkek = int.Parse(label5.Text);
                double kadınerkekoran = Math.Round(((kadın * 100) / (kadın + erkek)), 2);
                label3.Text = "%" + kadınerkekoran.ToString();
                double erkekkadınoranı = Math.Round((100 - kadınerkekoran), 2);
                label6.Text = "%" + erkekkadınoranı.ToString();
                dr2.Close();
                string query3 = "select  sum(yas)/count(no) from personelBilgi  ";
                if (cmbKategori.SelectedIndex > -1)
                {
                    query3 += " where sirket = '" + cmbKategori.SelectedItem.ToString() + "'";
                }
                SqlCommand cmd3 = new SqlCommand(query3, connection);
                SqlDataReader dr3 = cmd3.ExecuteReader();
                Console.WriteLine(query2);
                while (dr3.Read())
                {
                    label8.Text = dr3.GetValue(0).ToString();
                }
                dr3.Close();
                connection.Close();
            }

        }

        private void calisanDetay_Load(object sender, EventArgs e)
        {
            ComboboxlariDoldur();
            VerileriDoldur();
            chartDoldur();

        }

        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerileriDoldur();
            chartDoldur();

        }

        private void chartDoldur()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    string query = "SELECT cinsiyet, (COUNT(*)*100/(select count(no) from personelBilgi  "; 
                    if (cmbKategori.SelectedIndex > -1)
                    {
                        query+= "where sirket='" + cmbKategori.SelectedItem.ToString()+"'";
                    }   
                    
                      query+=  " )) as oran FROM personelBilgi WHERE (cinsiyet='e' OR cinsiyet='k')";
                    if (cmbKategori.SelectedIndex > -1)
                    {
                        query += " AND sirket='"+cmbKategori.SelectedItem.ToString()+"' ";
                    }
                    query += " GROUP BY cinsiyet";
                    Console.WriteLine(query);
                    DataTable dt = GetData(query);


                    string[] x = (from p in dt.AsEnumerable()
                                  orderby
                                p.Field<string>("cinsiyet") ascending
                                  select p.Field<string>("cinsiyet")).ToArray();

                    int[] y = (from p in dt.AsEnumerable()
                               orderby p.Field<string>("cinsiyet") ascending
                               select p.Field<int>("oran")).ToArray();

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


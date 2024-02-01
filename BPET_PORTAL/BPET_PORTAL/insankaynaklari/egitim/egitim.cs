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
    public partial class egitim : Form
    {
        public egitim()
        {
            InitializeComponent();

        }
        SqlConnection conn = new SqlConnection("Server=95.0.50.22,1382;Initial Catalog=insankaynaklari;User ID=sa;Password=Mustafa1;");

        private void getir()
        {
            try
            {


                conn.Open();

                string query = "select sum(planlanan_egitim_saati),sum(gerceklesen_egitim_saati) from egitim";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    lbl_planlanan.Text = dr.GetValue(0).ToString();
                    lbl_gerceklesen.Text = dr.GetValue(1).ToString();
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cikar()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    string query = "select sum(planlanan_egitim_saati)-sum(gerceklesen_egitim_saati) from egitim";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lbl_gerceklesmeyen.Text = dr.GetValue(0).ToString();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void ChartEkle2()
        {
            try
            {
                string query = @"
            SELECT (CAST(SUM(gerceklesen_egitim_saati) AS FLOAT) / SUM(planlanan_egitim_saati)) * 100.0 AS gerceklesen_orani_yuzde,
                   100.0 - ((CAST(SUM(gerceklesen_egitim_saati) AS FLOAT) / SUM(planlanan_egitim_saati)) * 100) AS gerceklesmeyen
            FROM egitim";

                DataTable dt = GetData(query);

                double gerceklesenOrani = Convert.ToDouble(dt.Rows[0]["gerceklesen_orani_yuzde"]);
                double gerceklesmeyenOrani = Convert.ToDouble(dt.Rows[0]["gerceklesmeyen"]);

                chart1.Series[0].Points.AddXY("Gerceklesen", gerceklesenOrani);
                chart1.Series[0].Points.AddXY("Gerceklesmeyen", gerceklesmeyenOrani);
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                chart1.Legends[0].Enabled = true;
                chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
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


        private void egitim_Load(object sender, EventArgs e)
        {
            cikar();
            getir();
            ChartEkle2();
        }
    }
}
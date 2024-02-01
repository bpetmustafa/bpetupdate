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

namespace BPET_PORTAL.insankaynaklari.iscilikmaliyeti.diger_sirketler_maliyet
{
    public partial class birimMaliyetDiger : Form
    {
        SqlConnection conn = new SqlConnection("Server=95.0.50.22,1382;Initial Catalog=insankaynaklari;User ID=sa;Password=Mustafa1;");
        public birimMaliyetDiger()
        {
            InitializeComponent();
        }

        private void Doldur()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {

                    conn.Open();
                    string query = ("select birim, sum(genel_maliyet) as birimler from logo where yil='" + cbYil.SelectedItem.ToString() + "' group by birim order by birim");

                    DataTable dt = GetData(query);


                    string[] x = (from p in dt.AsEnumerable()
                                  orderby
                                p.Field<string>("birim") ascending
                                  select p.Field<string>("birim")).ToArray();

                    decimal[] y = (from p in dt.AsEnumerable()
                                   orderby p.Field<string>("birim") ascending
                                   select p.Field<decimal>("birimler")).ToArray();


                    chart1.Series[0].ChartType = SeriesChartType.Pie;
                    chart1.Series[0].Points.DataBindXY(x, y);
                    chart1.Legends[0].Enabled = true;
                    chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
                }
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

        private void btn_goruntule_Click(object sender, EventArgs e)
        {
            Doldur();
        }
    }
}

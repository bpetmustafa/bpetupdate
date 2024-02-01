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

namespace BPET_PORTAL.insankaynaklari.iscilikmaliyeti.balpet_maliyet
{
    public partial class konsolide : Form
    {
        SqlConnection conn = new SqlConnection("Server=95.0.50.22,1382;Initial Catalog=insankaynaklari;User ID=sa;Password=Mustafa1;");
        public konsolide()
        {
            InitializeComponent();

        }

        private void btn_goster_Click(object sender, EventArgs e)
        {
            sec();
        }

        private void sec()
        {
            try
            {
                conn.Open();
                string query = "select sum(genel_maliyet) from logo where kurum='Balpet' and ay='" + cbAy.SelectedItem.ToString() + "' and yil='" + cbYil.SelectedItem.ToString() + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    chart1.Series["Konsolide"].Points.AddXY(dr[0].ToString(), dr[0].ToString());
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Secyil()
        {
            conn.Open();
            string query= "select ay,sum(genel_maliyet) as maliyet from logo where kurum='Balpet' and yil='" + cbYilY.SelectedItem.ToString() + "' group by ay";
            SqlCommand cmd = new SqlCommand(query, conn);
            Console.WriteLine(query);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
               
                chart2.Series["Series"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
               

            }

            conn.Close();
        }

        private void btn_gosterYil_Click(object sender, EventArgs e)
        {
            Secyil();
        }
    }
}

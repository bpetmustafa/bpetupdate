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
    public partial class harcirah : Form
    {

        SqlConnection conn = new SqlConnection("Server=95.0.50.22,1382;Initial Catalog=insankaynaklari;User ID=sa;Password=Mustafa1;");
        public harcirah()
        {
            InitializeComponent();
        }

        private void Getir()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                    string query = "select   ay,sum(net_harcirah/genel_maliyet)  as oran from logo where yil = '" + cbYil.SelectedItem.ToString() + "' group by ay";
                    
                    SqlCommand cmd = new SqlCommand(query, conn);
                    Console.WriteLine(query);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                        chart1.Series["Series"].Points.AddXY(dr[0].ToString(), Convert.ToDouble(dr[1].ToString()));
                        
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_goruntule_Click(object sender, EventArgs e)
        {
            Getir();
            Harcirah();
        }

        private void Harcirah()
        {
            conn.Open();
            string query = "select sum(net_harcirah) from logo where kurum='Balpet' and yil='"+cbYil.SelectedItem.ToString()+"'";
            SqlCommand cmd=new SqlCommand(query,conn);
            SqlDataReader dr= cmd.ExecuteReader();
            while (dr.Read())
            {
                lbl_harcirah.Text = dr.GetValue(0).ToString();
            }
            conn.Close() ;
        }
    }
}

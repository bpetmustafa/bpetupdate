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

namespace BPET_PORTAL.insankaynaklari.iscilikmaliyeti.diger_sirketler_maliyet
{
    public partial class mesaiMaliyetOranDiger : Form
    {
        SqlConnection conn = new SqlConnection("Server=95.0.50.22,1382;Initial Catalog=insankaynaklari;User ID=sa;Password=Mustafa1;");
        public mesaiMaliyetOranDiger()
        {
            InitializeComponent();
        }

        private void hesapla()
        {
            conn.Open();
            string query = "select sum(net_fazla_mesai) from logo where kurum='Balpet' and yil='" + cbYil.SelectedItem.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lbl_mesaiMaliyet.Text = dr.GetValue(0).ToString();
            }
            conn.Close();
        }
        private void goruntule()
        {
            conn.Open();
            SqlCommand query = new SqlCommand("select   ay,sum(net_fazla_mesai/genel_maliyet)  as oran from logo where kurum = 'Balpet' and yil = '" + cbYil.SelectedItem.ToString() + "' group by ay", conn);
            SqlDataReader dr = query.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Oran"].Points.AddXY(dr[0].ToString(), Convert.ToDouble(dr[1].ToString()));

            }
            conn.Close();
        }

        private void btn_goruntule_Click(object sender, EventArgs e)
        {
            goruntule();
            hesapla();
        }
    }
}

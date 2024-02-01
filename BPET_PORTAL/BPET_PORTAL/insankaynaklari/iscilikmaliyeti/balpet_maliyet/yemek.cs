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
    public partial class yemek : Form
    {
        SqlConnection conn = new SqlConnection("Server=95.0.50.22,1382;Initial Catalog=insankaynaklari;User ID=sa;Password=Mustafa1;");
        public yemek()
        {
            InitializeComponent();
        }

        private void Hesapla()
        {
            conn.Open();
            string query = "select birim, Sum(net_yemek) as toplam from logo where yil='"+cbYil.SelectedItem.ToString()+"' group by birim ";
            SqlCommand cmd= new SqlCommand(query, conn);
            SqlDataReader dr= cmd.ExecuteReader();
            while (dr.Read())
            {
                lbl_yemek.Text=dr.GetValue(1).ToString();
            }
            conn.Close();
            
        }

        private void btn_goruntule_Click(object sender, EventArgs e)
        {
            Hesapla();
            Goster();
        }

        private void Goster()
        {
            conn.Open();
            SqlCommand query = new SqlCommand("select Sum(net_yemek) as toplam from logo where yil='"+cbYil.SelectedItem.ToString()+"' ", conn);
            SqlDataReader dr = query.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Net Yemek"].Points.AddXY(dr[0].ToString(), dr[0].ToString());
              
            }
            conn.Close();

        }
    }
   
}

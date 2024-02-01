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

namespace BPET_PORTAL.insankaynaklari.memnuniyet
{
    public partial class veri : Form
    {
        public veri()
        {
            InitializeComponent();
        }


        SqlConnection conn = new SqlConnection("Server=95.0.50.22,1382;Initial Catalog=insankaynaklari;User ID=sa;Password=Mustafa1;");

        private void veri_Load(object sender, EventArgs e)
        {
            veriGetir1();
            veriGetir2();
            veriGetir3();
            veriGetir4();
            veriGetir5();
            veriGetir6();
            veriGetir14();
            veriGetir7();
            veriGetir8();
            veriGetir9();
            veriGetir10();
            veriGetir11();
            veriGetir12();
            veriGetir13();
            veriGetir15();
            veriGetir16();
            veriGetir17();
            veriGetir18();
            veriGetir19();
            veriGetir20();
            veriGetir21();
            veriGetir22();
            veriGetir23();
            veriGetir24();
            veriGetir25();
            veriGetir26();
            veriGetir27();
            veriGetir28();
            veriGetir29();
            veriGetir30();
            veriGetir31();
            veriGetir32();
            veriGetir33();
            veriGetir34();
            veriGetir35();
            veriGetir36();
            veriGetir37();
            veriGetir38();
            veriGetir39();
            veriGetir40();
            veriGetir41();
            veriGetir42();
            veriGetir43();
            veriGetir44();
            veriGetir45();
            veriGetir46();
            veriGetir47();
            veriGetir48();
            veriGetir49();
            veriGetir50();
            veriGetir51();
            veriGetir52();
            veriGetir53();
            veriGetir54();
            veriGetir55();
            veriGetir56();
        }

      private void veriGetir2()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 3 GROUP BY basliklar",conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart2.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart2.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(),dr[2].ToString());
                    chart2.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart2.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart2.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir1()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 4 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart1.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart1.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart1.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart1.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart1.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();
            

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir3()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 5 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart3.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart3.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart3.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart3.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart3.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir4()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 6 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart4.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart4.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart4.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart4.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart4.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir5()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 7 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart5.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart5.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart5.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart5.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart5.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir6()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 8 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart6.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart6.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart6.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart6.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart6.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir14()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 9 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart14.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart14.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart14.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart14.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart14.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir7()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 10 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart7.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart7.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart7.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart7.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart7.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir8()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 11 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart8.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart8.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart8.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart8.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart8.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir9()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 12 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart9.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart9.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart9.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart9.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart9.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir10()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 13 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart10.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart10.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart10.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart10.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart10.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir11()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 14 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart11.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart11.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart11.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart11.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart11.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir12()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 15 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart12.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart12.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart12.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart12.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart12.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir13()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 16 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart13.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart13.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart13.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart13.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart13.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir15()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 17 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart15.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart15.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart15.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart15.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart15.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void veriGetir16()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 18 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart16.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart16.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart16.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart16.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart16.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir17()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 19 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart17.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart17.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart17.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart17.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart17.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void veriGetir18()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 20 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart18.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart18.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart18.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart18.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart18.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir19()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 21 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart19.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart19.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart19.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart19.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart19.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir20()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 22 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart20.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart20.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart20.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart20.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart20.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir21()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 23 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart21.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart21.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart21.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart21.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart21.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir22()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 24 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart22.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart22.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart22.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart22.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart22.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir23()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 25 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart23.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart23.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart23.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart23.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart23.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir24()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 26 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart24.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart24.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart24.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart24.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart24.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir25()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 27 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart25.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart25.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart25.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart25.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart25.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir26()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 28 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart26.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart26.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart26.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart26.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart26.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir27()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 29 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart27.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart27.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart27.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart27.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart27.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir28()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 30 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart28.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart28.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart28.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart28.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart28.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir29()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 31 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart29.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart29.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart29.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart29.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart29.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir30()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 32 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart30.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart30.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart30.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart30.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart30.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir31()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 33 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart31.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart31.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart31.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart31.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart31.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir32()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 34 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart32.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart32.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart32.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart32.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart32.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir33()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 35 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart33.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart33.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart33.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart33.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart33.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir34()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 36 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart34.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart34.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart34.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart34.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart34.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir35()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 37 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart35.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart35.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart35.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart35.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart35.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir36()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 38 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart36.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart36.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart36.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart36.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart36.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir37()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 39 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart37.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart37.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart37.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart37.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart37.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir38()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 40 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart38.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart38.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart38.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart38.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart38.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir39()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 41 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart39.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart39.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart39.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart39.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart39.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir40()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 42 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart40.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart40.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart40.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart40.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart40.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir41()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 43 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart41.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart41.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart41.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart41.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart41.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir42()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 44 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart42.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart42.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart42.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart42.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart42.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir43()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 45 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart43.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart43.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart43.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart43.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart43.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir44()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 46 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart44.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart44.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart44.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart44.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart44.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir45()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 47 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart45.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart45.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart45.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart45.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart45.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir46()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 48 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart46.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart46.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart46.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart46.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart46.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir47()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 49 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart47.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart47.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart47.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart47.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart47.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir48()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 50 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart48.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart48.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart48.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart48.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart48.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir49()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 51 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart49.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart49.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart49.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart49.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart49.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir50()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 52 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart50.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart50.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart50.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart50.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart50.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir51()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 53 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart51.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart51.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart51.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart51.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart51.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir52()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 54 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart52.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart52.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart52.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart52.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart52.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir53()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 55 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart53.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart53.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart53.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart53.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart53.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir54()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 56 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart54.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart54.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart54.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart54.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart54.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir55()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 57 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart55.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart55.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart55.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart55.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart55.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void veriGetir56()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT basliklar, SUM(kesinlikle_katiliyorum) AS Toplam_KesinlikleKatiliyorum ,SUM(katiliyorum) AS Toplam_Katiliyorum,SUM(karar_vermek_zor) AS Toplam_KararVermekZor,SUM(katilmiyorum) AS Toplam_Katilmiyorum,SUM(kesinlikle_katilmiyorum) AS Toplam_KesinlikleKatilmiyorum from memnuniyet where memnuniyet_id = 58 GROUP BY basliklar", conn);
                SqlDataReader dr = query.ExecuteReader();
                while (dr.Read())
                {
                    chart56.Series["Kesinlikle Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[1].ToString());
                    chart56.Series["Katılıyorum"].Points.AddXY(dr[0].ToString(), dr[2].ToString());
                    chart56.Series["Karar Vermek Zor"].Points.AddXY(dr[0].ToString(), dr[3].ToString());
                    chart56.Series["Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[4].ToString());
                    chart56.Series["Kesinlikle Katılmıyorum"].Points.AddXY(dr[0].ToString(), dr[5].ToString());
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

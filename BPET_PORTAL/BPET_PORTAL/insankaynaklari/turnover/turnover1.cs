using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPET_PORTAL.insankaynaklari.turnover
{
    public partial class turnover1 : Form
    {
        public turnover1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=95.0.50.22,1382;Initial Catalog=insankaynaklari;User ID=sa;Password=Mustafa1;");
        string turnover_id;




        private void dgvDoldur()
        {
            dgvTurnover.Rows.Clear();
            conn.Open();
            string id, tahakkuk_donem, donem, tahakkuk_eden_kisi, cikan_kisi;
            decimal turnover;
            SqlCommand query = new SqlCommand("SELECT * FROM turnover",conn);
            SqlDataReader dr=query.ExecuteReader();

            while (dr.Read())
            {
                id = dr["turnover_id"].ToString();
                tahakkuk_donem = dr["ay"].ToString() ;
                donem = dr["yil"].ToString();
                tahakkuk_eden_kisi = dr["tahakkuk_kisi"].ToString();
                cikan_kisi = dr["isten_ayrilan"].ToString();
                turnover =Math.Round(Convert.ToDecimal(dr["aylik_turnover"].ToString()),2);

                dgvTurnover.Rows.Add(id, tahakkuk_donem, donem, tahakkuk_eden_kisi, cikan_kisi, turnover);
            }
            dr.Close();
            conn.Close();
          

        }


        private void ekle()
        {
            
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    SqlCommand query = new SqlCommand("INSERT INTO turnover(ay,tahakkuk_kisi,isten_ayrilan,aylik_turnover,yil) VALUES(@ay,@tahakkuk_kisi,@isten_ayrilan,@aylik_turnover,@yil)", conn);

                    query.Parameters.AddWithValue("@ay",cbTahakkuk.Text.ToString());
                    query.Parameters.AddWithValue("@tahakkuk_kisi", nudTahakkukKisi.Value);
                    query.Parameters.AddWithValue("@isten_ayrilan", nudCikanKisi.Value);
                    query.Parameters.AddWithValue("@aylik_turnover", nudTurnover.Value);
                    query.Parameters.AddWithValue("@yil", txtDonem.Text.ToString());

                    query.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Eklendi");
                    dgvDoldur();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            ekle();
        }

        private void hesapla()
        {
            decimal ck = nudCikanKisi.Value;
            decimal tk = nudTahakkukKisi.Value;

            nudTurnover.Value=(ck/tk)*100;
        }

        private void btn_hesapla_Click(object sender, EventArgs e)
        {
            
            hesapla();
        }

        private void turnover1_Load(object sender, EventArgs e)
        {
            dgvDoldur();
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            turnoverGuncelle(turnover_id);
        }

        private void dgvTurnover_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            float d=(float)nudTurnover.Value;
            turnover_id=dgvTurnover.CurrentRow.Cells[0].Value.ToString();
            cbTahakkuk.Text = dgvTurnover.CurrentRow.Cells[1].Value.ToString();
            txtDonem.Text=dgvTurnover.CurrentRow.Cells[2].Value.ToString();
            nudTahakkukKisi.Value=Convert.ToInt32(dgvTurnover.CurrentRow.Cells[3].Value);
            nudCikanKisi.Value = Convert.ToInt32(dgvTurnover.CurrentRow.Cells[4].Value);
            nudTurnover.Value = Convert.ToDecimal(dgvTurnover.CurrentRow.Cells[5].Value);
        }


        private void turnoverGuncelle(string id) {

            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("UPDATE turnover SET ay=@ay, tahakkuk_kisi=@tahakkuk_kisi, isten_ayrilan=@isten_ayrilan, aylik_turnover=@aylik_turnover, yil=@yil WHERE turnover_id=@id", conn);
                query.Parameters.AddWithValue("@ay", cbTahakkuk.Text.ToString());
                query.Parameters.AddWithValue("@tahakkuk_kisi", nudTahakkukKisi.Value);
                query.Parameters.AddWithValue("@isten_ayrilan", nudCikanKisi.Value);
                query.Parameters.AddWithValue("@aylik_turnover", (decimal)nudTurnover.Value); 
                query.Parameters.AddWithValue("@yil", txtDonem.Text.ToString());
                query.Parameters.AddWithValue("@id", id);

                query.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Güncellendi");
                dgvDoldur();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void dgvDoldurYillik()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("select  sum(tahakkuk_kisi) as tahakkuk_kisi, sum(isten_ayrilan) as isten_ayrilan, sum(aylik_turnover)/12 as turnover   from turnover where yil='"+txtDonemYillik.Text+"'", conn);
                SqlDataAdapter sda = new SqlDataAdapter(query);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvYillik.DataSource = dt;
              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvDoldurAylik()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("select ay,yil, aylik_turnover from turnover where ay='"+cbAylik.Text+"' and yil='"+textDonemDoldur.Text+"'", conn);
                SqlDataAdapter sda = new SqlDataAdapter(query);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvAylik.DataSource = dt;
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_goster_Click(object sender, EventArgs e)
        {
            dgvDoldurAylik();
        }

        private void btn_gosterYil_Click(object sender, EventArgs e)
        {
            dgvDoldurYillik();
        }
    }
}

//private void LoadData()
//{
//    using (SqlConnection connection = new SqlConnection(connectionString))
//    {
//        connection.Open();

//        string query = @"
//             SELECT * FROM CariHesaplar 
//             WHERE MailGonderildi = 1 AND Cevaplanmadı = 0 
//             AND BolgeKodu IN (
//                 SELECT BolgeKodu FROM Yetkililer WHERE Eposta = @Eposta
//             )";

//        using (SqlCommand command = new SqlCommand(query, connection))
//        {
//            command.Parameters.AddWithValue("@Eposta", kullaniciEposta);

//            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
//            {
//                DataTable dataTable = new DataTable();
//                adapter.Fill(dataTable);
//                dataGridView.DataSource = dataTable;
//            }
//        }
//    }
//}

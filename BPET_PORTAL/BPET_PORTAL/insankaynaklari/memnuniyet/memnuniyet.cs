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

namespace BPET_PORTAL.insankaynaklari.memnuniyet
{
    public partial class memnuniyet : Form
    {
        public memnuniyet()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=95.0.50.22,1382;Initial Catalog=insankaynaklari;User ID=sa;Password=Mustafa1;");

        string memnuniyet_id;

        private void toplamCevapHesapla()
        {

            decimal kk = nudKK.Value;
            decimal katiliyorum = nudKatiliyorum.Value;
            decimal zorKarar = nudKararVermekZor.Value;
            decimal katilmiyorum = nudKatilm.Value;
            decimal kesinlikleKatilmiyorum = nudKesinlikleKatilmiyorum.Value;


            nudToplamCevap.Value = kk + katiliyorum + katilmiyorum + zorKarar + kesinlikleKatilmiyorum;
            decimal toplam_cevap = nudToplamCevap.Value;
            nudSoruMemnuniyeti.Value = ((kk + katiliyorum + (zorKarar / 2)) / toplam_cevap);

        }

        private void btn_hesapla_Click(object sender, EventArgs e)
        {
            toplamCevapHesapla();
        }


        private void Ekle()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    SqlCommand query = new SqlCommand("INSERT INTO memnuniyet(basliklar, kesinlikle_katiliyorum, katiliyorum,  karar_vermek_zor, katilmiyorum, kesinlikle_katilmiyorum, toplam_cevap,soru_memnuniyeti,tarih,grup) VALUES(@basliklar, @kesinlikle_katiliyorum, @katiliyorum, @karar_vermek_zor, @katilmiyorum, @kesinlikle_katilmiyorum, @toplam_cevap,@soru_memnuniyeti,@tarih,@grup)", conn);
                    query.Parameters.AddWithValue("@basliklar", rchBasliklar.Text);
                    query.Parameters.AddWithValue("@kesinlikle_katiliyorum", nudKK.Value);
                    query.Parameters.AddWithValue("@katiliyorum", nudKatiliyorum.Value);
                    query.Parameters.AddWithValue("@karar_vermek_zor", nudKararVermekZor.Value);
                    query.Parameters.AddWithValue("@katilmiyorum", nudKatilm.Value);
                    query.Parameters.AddWithValue("@kesinlikle_katilmiyorum", nudKesinlikleKatilmiyorum.Value);
                    query.Parameters.AddWithValue("@toplam_cevap", nudToplamCevap.Value);
                    query.Parameters.AddWithValue("@soru_memnuniyeti", nudSoruMemnuniyeti.Value);
                    query.Parameters.AddWithValue("@tarih", dtpTarih.Value);
                    query.Parameters.AddWithValue("@grup", cbGrup.Text);

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
            Ekle();
        }


        private void dgvDoldur()
        {
            dgvMemnuniyet.Rows.Clear();
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    string id, basliklar, kesinlikle_katiliyorum, katiliyorum, karar_vermek_zor, katilmiyorum, kesinlikle_katilmiyorum, toplam_cevap, soru_memnuniyeti, tarih, tarih2, grup;
                    SqlCommand query = new SqlCommand("SELECT * FROM memnuniyet", conn);

                    SqlDataReader dr = query.ExecuteReader();
                    while (dr.Read())
                    {
                        id = dr["memnuniyet_id"].ToString();
                        basliklar = dr["basliklar"].ToString();
                        tarih = dr["tarih"].ToString();
                        tarih2 = Convert.ToDateTime(tarih).ToShortDateString();
                        grup = dr["grup"].ToString();
                        kesinlikle_katiliyorum = dr["kesinlikle_katiliyorum"].ToString();
                        katiliyorum = dr["katiliyorum"].ToString();
                        karar_vermek_zor = dr["karar_vermek_zor"].ToString();
                        katilmiyorum = dr["katilmiyorum"].ToString();
                        kesinlikle_katilmiyorum = dr["kesinlikle_katilmiyorum"].ToString();
                        toplam_cevap = dr["toplam_cevap"].ToString();
                        soru_memnuniyeti = dr["soru_memnuniyeti"].ToString();


                        dgvMemnuniyet.Rows.Add(id, basliklar, tarih2, grup, kesinlikle_katiliyorum, katiliyorum, karar_vermek_zor, katilmiyorum, kesinlikle_katilmiyorum, toplam_cevap, soru_memnuniyeti);
                    }
                    dr.Close();
                    conn.Close();

                    //dgvMemnuniyet.Columns["kesinlikle_katiliyorum"].Width = 100; 
                    //dgvMemnuniyet.Columns["tarih"].Width = 145; 
                   


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvMemnuniyet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            memnuniyet_id = dgvMemnuniyet.CurrentRow.Cells[0].Value.ToString();
            rchBasliklar.Text = dgvMemnuniyet.CurrentRow.Cells[1].Value.ToString();
            dtpTarih.Text = dgvMemnuniyet.CurrentRow.Cells[2].Value.ToString();
            cbGrup.Text = dgvMemnuniyet.CurrentRow.Cells[3].Value.ToString();
            nudKK.Value = Convert.ToDecimal(dgvMemnuniyet.CurrentRow.Cells[4].Value.ToString());
            nudKatiliyorum.Value = Convert.ToDecimal(dgvMemnuniyet.CurrentRow.Cells[5].Value.ToString());
            nudKararVermekZor.Value = Convert.ToDecimal(dgvMemnuniyet.CurrentRow.Cells[6].Value.ToString());
            nudKatilm.Value = Convert.ToDecimal(dgvMemnuniyet.CurrentRow.Cells[7].Value.ToString());
            nudKesinlikleKatilmiyorum.Value = Convert.ToDecimal(dgvMemnuniyet.CurrentRow.Cells[8].Value.ToString());
            nudToplamCevap.Value = Convert.ToDecimal(dgvMemnuniyet.CurrentRow.Cells[9].Value.ToString());
            nudSoruMemnuniyeti.Value = Convert.ToDecimal(dgvMemnuniyet.CurrentRow.Cells[10].Value.ToString());
        }

        private void memnuniyet_Load(object sender, EventArgs e)
        {
            dgvDoldur();

        }


        private void guncelle(string id)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    SqlCommand query = new SqlCommand("UPDATE memnuniyet SET basliklar=@basliklar, tarih=@tarih, kesinlikle_katiliyorum=@kesinlikle_katiliyorum, katiliyorum=@katiliyorum, karar_vermek_zor=@karar_vermek_zor, katilmiyorum=@katilmiyorum, kesinlikle_katilmiyorum=@kesinlikle_katilmiyorum, toplam_cevap=@toplam_cevap,soru_memnuniyeti=@soru_memnuniyeti,grup=@grup WHERE memnuniyet_id=@id", conn);
                    query.Parameters.AddWithValue("@id", id);
                    query.Parameters.AddWithValue("@basliklar", rchBasliklar.Text);
                    query.Parameters.AddWithValue("@tarih", dtpTarih.Value);
                    query.Parameters.AddWithValue("@grup", cbGrup.Text);
                    query.Parameters.AddWithValue("@kesinlikle_katiliyorum", nudKK.Value);
                    query.Parameters.AddWithValue("@katiliyorum", nudKatiliyorum.Value);
                    query.Parameters.AddWithValue("@karar_vermek_zor", nudKararVermekZor.Value);
                    query.Parameters.AddWithValue("@katilmiyorum", nudKatilm.Value);
                    query.Parameters.AddWithValue("@kesinlikle_katilmiyorum", nudKesinlikleKatilmiyorum.Value);
                    query.Parameters.AddWithValue("@toplam_cevap", nudToplamCevap.Value);
                    query.Parameters.AddWithValue("@soru_memnuniyeti", nudSoruMemnuniyeti.Value);


                    query.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Güncellendi");
                    dgvDoldur();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            guncelle(memnuniyet_id);
        }

        private void btn_goruntule_Click(object sender, EventArgs e)
        {
            veri ekle = new veri();
            ekle.Show();


        }


        private void Sec()
        {
            if (cbSec.Text == "KESİNLİKLE KATILIYORUM")
            {
                detay ekle = new detay();
                ekle.ShowDialog();


            }
            if (cbSec.Text == "KARAR VERMEK ZOR")
            {

                detay1 ekle = new detay1();
                ekle.ShowDialog();
            }
            if (cbSec.Text == "KESİNLİKLE KATILMIYORUM")
            {
                detay2 ekle = new detay2();
                ekle.ShowDialog();
            }
        }

        private void btn_detay_Click(object sender, EventArgs e)
        {
            Sec();
        }
    }
}

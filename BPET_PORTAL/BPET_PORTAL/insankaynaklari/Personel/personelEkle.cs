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
using SKM.V3.Methods;
using BPET_PORTAL.arsiv_uygulamasi;
using BPET_PORTAL.lojistik.lojistikekranlar;

namespace BPET_PORTAL.insankaynaklari.Personel
{
    public partial class personelEkle : Form
    {
        public personelEkle()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Server=95.0.50.22,1382;Initial Catalog=insankaynaklari;User ID=sa;Password=Mustafa1;");

        private void personelBilgileriEkle()
        {
            try
            {

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    SqlCommand query = new SqlCommand("INSERT INTO personel(adi,soyadi,tc,görevi,istihdam,ise_giris_tarihi,isten_cikis_tarihi,dogum_tarihi,cinsiyet,mezuniyet) VALUES(@adi,@soyadi,@tc,@görevi,@istihdam,@ise_giris_tarihi,@isten_cikis_tarihi,@dogum_tarihi,@cinsiyet,@mezuniyet)", conn);




                    query.Parameters.AddWithValue("@adi", txtAdı.Text);
                    query.Parameters.AddWithValue("@soyadi", txtSoyadi.Text);
                    query.Parameters.AddWithValue("@tc", txtTc.Text);
                    query.Parameters.AddWithValue("@görevi", txtGorev.Text);
                    query.Parameters.AddWithValue("@istihdam", txtIstihdam.Text);
                    if (cb_aktif.Checked == true)
                    {
                        //query.Parameters.AddWithValue("@ise_giris_tarihi", dtpGiris.Value);
                        query.Parameters.AddWithValue("@durum", "1");
                    }
                    if (cb_pasif.Checked == true)
                    {
                        // query.Parameters.AddWithValue("@ise_giris_tarihi", dtpGiris.Value);
                        //    query.Parameters.AddWithValue("@isten_cikis_tarihi", dtpCikis.Value);
                        query.Parameters.AddWithValue("@durum", "0");
                    }
                    query.Parameters.AddWithValue("@ise_giris_tarihi", dtpGiris.Value);
                    query.Parameters.AddWithValue("@isten_cikis_tarihi", dtpCikis.Value);
                    query.Parameters.AddWithValue("@dogum_tarihi", dtpdogum.Value);
                    query.Parameters.AddWithValue("@cinsiyet", cbCinsiyet.SelectedItem);
                    query.Parameters.AddWithValue("@mezuniyet",cbMezuniyet.SelectedItem);


                    query.ExecuteNonQuery();
                    conn.Close();
                    //   MessageBox.Show("Kayıt Eklendi");

                }

            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "Hata oluştu");
            }

        }

        private void maasEkle()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    SqlCommand query = new SqlCommand("INSERT INTO maas(brut_kidem_tazminati, brut_ihbar_tazminati,brut_yillik_izin_ucreti, brut_diger_ucretler, brut_harcirah,brut_maas,brut_ucretler_toplami,ssk_matrah,ssk_isci_kesintisi,ssk_isci_issizlik,ssk_isveren_issizlik)  " +
                        " VALUES(@brut_kidem_tazminati, @brut_ihbar_tazminati,@brut_yillik_izin_ucreti, @brut_diger_ucretler, @brut_harcirah,@brut_maas,@brut_ucretler_toplami,@ssk_matrah,@ssk_isci_kesintisi,@ssk_isci_issizlik,@ssk_isveren_issizlik)", conn);


                    query.Parameters.AddWithValue("@brut_kidem_tazminati", nudBrutKidemTazminat.Value);
                    query.Parameters.AddWithValue("@brut_ihbar_tazminati", nudBrutIhbar.Value);
                    query.Parameters.AddWithValue("@brut_yillik_izin_ucreti", nudBrutYillik.Value);
                    query.Parameters.AddWithValue("@brut_diger_ucretler", nudBrutDiger.Value);
                    query.Parameters.AddWithValue("@brut_harcirah", nudBrutHarcirah.Value);
                    query.Parameters.AddWithValue("@brut_maas", nudBrutMaas.Value);
                    query.Parameters.AddWithValue("@brut_ucretler_toplami", nudBrutToplam.Value);
                    query.Parameters.AddWithValue("@ssk_matrah", nudSskMatrah.Value);
                    query.Parameters.AddWithValue("@ssk_isci_kesintisi", nudSskIciKesinti.Value);
                    query.Parameters.AddWithValue("@ssk_isci_issizlik", nudSskIciIssizlik.Value);
                    query.Parameters.AddWithValue("@ssk_isveren_issizlik", nudSskIsverenIssizlik.Value);

                    query.ExecuteNonQuery();
                    conn.Close();
                    // MessageBox.Show("Kayıt Eklendi");
                }

            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "Hata oluştu");
            }
        }

        private void maliyetEkle()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    SqlCommand query = new SqlCommand("INSERT INTO maliyet(diger_odemeler,personel_odemeler,muhtasar_odemeler,sgk_maliyeti,sgk_5510_indirim,diger_sgk_tesvik_indirim,sgk_odemesi,toplam_maliyet,kidem_yuku,genel_maliyet) " +
                        "VALUES(@diger_odemeler,@personel_odemeler,@muhtasar_odemeler,@sgk_maliyeti,@sgk_5510_indirim,@diger_sgk_tesvik_indirim,@sgk_odemesi,@toplam_maliyet,@kidem_yuku,@genel_maliyet)", conn);

                    decimal deger1 = -1;
                    query.Parameters.AddWithValue("@diger_odemeler", nudMaliyetDiger.Value);
                    query.Parameters.AddWithValue("@personel_odemeler", decimal.TryParse(txtPersonelOdeme.Text, out deger1));
                    query.Parameters.AddWithValue("@muhtasar_odemeler", nudMuhtasar.Value);
                    query.Parameters.AddWithValue("@sgk_maliyeti", nudSgkMaliyet.Value);
                    query.Parameters.AddWithValue("@sgk_5510_indirim", nudSgkIndirim.Value);
                    query.Parameters.AddWithValue("@diger_sgk_tesvik_indirim", nudDigerSgk.Value);
                    query.Parameters.AddWithValue("@sgk_odemesi", nudSgkOdemesi.Value);
                    query.Parameters.AddWithValue("@toplam_maliyet", decimal.TryParse(txtToplamMAliyet.Text, out deger1));
                    query.Parameters.AddWithValue("@kidem_yuku", nudKidem.Value);
                    query.Parameters.AddWithValue("@genel_maliyet", decimal.TryParse(txtGenelMaliyet.Text, out deger1));

                    query.ExecuteNonQuery();
                    conn.Close();

                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "Hata oluştu");
            }
        }

        private void netOdemeEkle()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();

                    SqlCommand query = new SqlCommand("INSERT INTO net_odeme(net_kidem_tazminati,net_ihbar_tazminati, net_yillik_izin_ucreti,net_diger_ucretler,net_harcirah, net_maas, net_ucretler_toplami,bes_kesintisi,diger_kesintiler_toplami,net_odeme) VALUES(@net_kidem_tazminati,@net_ihbar_tazminati, @net_yillik_izin_ucreti,@net_diger_ucretler,@net_harcirah, @net_maas, @net_ucretler_toplami,@bes_kesintisi,@diger_kesintiler_toplami,@net_odeme)", conn);

                    decimal degisken = -1;
                    query.Parameters.AddWithValue("@net_kidem_tazminati", nudNetKidem.Value);
                    query.Parameters.AddWithValue("@net_ihbar_tazminati", nudNetIhbar.Value);
                    query.Parameters.AddWithValue("@net_yillik_izin_ucreti", nudNetYillik.Value);
                    query.Parameters.AddWithValue("@net_diger_ucretler", nudDiger.Value);
                    query.Parameters.AddWithValue("@net_harcirah", nudNetHarcirah.Value);
                    query.Parameters.AddWithValue("@net_maas", nudNetMaas.Value);
                    query.Parameters.AddWithValue("@net_ucretler_toplami", decimal.TryParse(txtNetUcretlerToplam.Text, out degisken));
                    query.Parameters.AddWithValue("@bes_kesintisi", nudBes.Value);
                    query.Parameters.AddWithValue("@diger_kesintiler_toplami", nudDigerKesinti.Value);
                    query.Parameters.AddWithValue("@net_odeme", decimal.TryParse(txtNetOdeme.Text, out degisken));

                    query.ExecuteNonQuery();
                    conn.Close();
                    //MessageBox.Show("Kayıt Eklendi");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "Hata oluştu");
            }
        }

        private void vergiEkle()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    SqlCommand query = new SqlCommand("INSERT INTO vergi(kumlatif_gv_matrahi,gv_matrahi,hesaplanan_gelir_vergisi,asuc_gelir_vergisi_istisnasi,hesaplanan_damga_vergisi,asuc_damga_vergisi_istisnasi,damga_vergisi_kesintisi) " +
                        "VALUES(@kumlatif_gv_matrahi,@gv_matrahi,@hesaplanan_gelir_vergisi,@asuc_gelir_vergisi_istisnasi,@hesaplanan_damga_vergisi,@asuc_damga_vergisi_istisnasi,@damga_vergisi_kesintisi)", conn);

                    query.Parameters.AddWithValue("@kumlatif_gv_matrahi", nudKumulatif.Value);
                    query.Parameters.AddWithValue("@gv_matrahi", nudGvMatrah.Value);
                    query.Parameters.AddWithValue("@hesaplanan_gelir_vergisi", nudHesaplananGelirVergisi.Value);
                    query.Parameters.AddWithValue("@asuc_gelir_vergisi_istisnasi", nudAsucGVI.Value);
                    query.Parameters.AddWithValue("@hesaplanan_damga_vergisi", nudHesaplananDV.Value);
                    query.Parameters.AddWithValue("@asuc_damga_vergisi_istisnasi", nudAsucDVI.Value);
                    query.Parameters.AddWithValue("@damga_vergisi_kesintisi", nudDamgaVK.Value);



                    query.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "Hata Oluştu");
            }
        }

        private void kurumEkle()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    SqlCommand query = new SqlCommand("INSERT INTO kurum(kurum_adi) VALUES(@kurum_adi)", conn);


                    query.Parameters.AddWithValue("@kurum_adi", cbKurum.SelectedItem);

                    query.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "Hata oluştu");
            }
        }
        private void isYeriEkle()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    SqlCommand query = new SqlCommand("INSERT INTO isyeri(isyeri_adi) VALUES(@isyeri_adi)", conn);


                    query.Parameters.AddWithValue("@isyeri_adi", txtIsYeri.Text);

                    query.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "Hata oluştu");
            }
        }
        private void birimEkle()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    SqlCommand query = new SqlCommand("INSERT INTO birim(birim_adi) VALUES(@birim_adi)", conn);


                    query.Parameters.AddWithValue("@birim_adi", cbBirim.SelectedItem);

                    query.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "Hata oluştu");
            }
        }


        //Veritabanına Ekleme
        private void btn_ekle_Click(object sender, EventArgs e)
        {
            personelBilgileriEkle();
            maasEkle();
            netOdemeEkle();
            maliyetEkle();
            vergiEkle();
            birimEkle();
            isYeriEkle();
            kurumEkle();
        }


        private void btKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Brüt Ücret Hesaplama
        private void brut_hesapla()
        {
            decimal kidemtazminati = nudBrutKidemTazminat.Value;
            decimal ihbartazminati = nudBrutIhbar.Value;
            decimal brutyillik = nudBrutYillik.Value;
            decimal brutdiger = nudBrutDiger.Value;
            decimal brutharcirah = nudBrutHarcirah.Value;
            decimal brutmaas = nudBrutMaas.Value;

            nudBrutToplam.Value = (kidemtazminati + ihbartazminati + brutyillik + brutdiger + brutharcirah + brutmaas);

        }

        private void nudBrutMaas_ValueChanged(object sender, EventArgs e)
        {
            brut_hesapla();
        }

        private void netHesapla()
        {
            decimal netkidem = nudNetKidem.Value;
            decimal netihbar = nudNetIhbar.Value;
            decimal netyillik = nudNetYillik.Value;
            decimal netdiger = nudDiger.Value;
            decimal netharcirah = nudNetHarcirah.Value;
            decimal netmaas = nudNetMaas.Value;

            txtNetUcretlerToplam.Text = (netkidem + netihbar + netyillik + netdiger + netharcirah + netmaas).ToString();
        }

        private void nudNetMaas_ValueChanged(object sender, EventArgs e)
        {
            netHesapla();
        }

        private void netOdemeHesapla()
        {
            decimal bes = nudBes.Value;
            decimal digerkesinti = nudDigerKesinti.Value;
            decimal toplam = Convert.ToDecimal(txtNetUcretlerToplam.Text);

            txtNetOdeme.Text = (bes + digerkesinti + toplam).ToString();

        }

        private void nudDigerKesinti_ValueChanged(object sender, EventArgs e)
        {
            netOdemeHesapla();
        }


        private void personelOdemeHesapla()
        {

            decimal maliyetdiger = nudMaliyetDiger.Value;
            decimal netOdeme = Convert.ToDecimal(txtNetOdeme.Text);

            txtPersonelOdeme.Text = (maliyetdiger + netOdeme).ToString();
        }
        private void nudMaliyetDiger_ValueChanged(object sender, EventArgs e)
        {
            personelOdemeHesapla();
        }


        private void toplamMaliyetHesapla()
        {
            decimal muhtasar = nudMuhtasar.Value;
            decimal sgkMaliyet = nudSgkMaliyet.Value;
            decimal sgkindirim = nudSgkIndirim.Value;
            decimal digersgk = nudDigerSgk.Value;
            decimal personelodeme = Convert.ToDecimal(txtPersonelOdeme.Text);

            txtToplamMAliyet.Text = (muhtasar + sgkMaliyet - sgkindirim - digersgk + personelodeme).ToString();
        }

        private void nudSgkOdemesi_ValueChanged(object sender, EventArgs e)
        {
            toplamMaliyetHesapla();
        }


        private void genelMaliyetHesapla()
        {
            decimal kidemyuku = nudKidem.Value;
            decimal toplammaliyet = Convert.ToDecimal(txtToplamMAliyet.Text);

            txtGenelMaliyet.Text = (kidemyuku + toplammaliyet).ToString();
        }


        private void nudKidem_ValueChanged(object sender, EventArgs e)
        {
            genelMaliyetHesapla();
        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label50.Text = (Convert.ToInt32(DateTime.Now.ToString("yyyy")) - Convert.ToInt32(dtpdogum.Value.ToString("yyyy"))).ToString() + " Yaşında";
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {

        }

        private void personelGuncelle()
        {

        }
    }
}

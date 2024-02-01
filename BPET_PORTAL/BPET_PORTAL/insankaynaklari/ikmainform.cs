using BPET_PORTAL.arsiv_uygulamasi;
using BPET_PORTAL.insankaynaklari.calisanBilgisi;
using BPET_PORTAL.insankaynaklari.egitim;
using BPET_PORTAL.insankaynaklari.iscilikmaliyeti;
using BPET_PORTAL.insankaynaklari.izinler;
using BPET_PORTAL.insankaynaklari.performans;
using BPET_PORTAL.insankaynaklari.Personel;
using BPET_PORTAL.insankaynaklari.turnover;
using BPET_PORTAL.victorreklam;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace BPET_PORTAL.insankaynaklari
{
    public partial class ikmainform : Form
    {
        private mainpage mainForm;
        private Form activeForm = null; // Yüklenen formu takip etmek için değişken

        SqlConnection conn = new SqlConnection("Server=95.0.50.22,1382;Initial Catalog=insankaynaklari;User ID=sa;Password=Mustafa1;");
        string connectionString = ("Server=95.0.50.22,1382;Initial Catalog=insankaynaklari;User ID=sa;Password=Mustafa1;");
        DataTable dt = new DataTable();
        public ikmainform(string eposta, mainpage mainForm)
        {
            InitializeComponent();


            this.mainForm = mainForm; // mainForm örneğini burada başlatın
        }


        public void ikmainformload(object form)
        {

            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);

            Form f = form as Form;
            activeForm = f; // Yüklenen formu sakla
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;

            f.Show();
            


        }

    


        private void bALPETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ikmainformload(new iscilikmaliyeti.iscilikmaliyetiform());
        }

        private void dİĞERŞİRKETLERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ikmainformload(new iscilikmaliyeti.digerSirketler());
        }



        private void eĞİTİMSAATİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ikmainformload(new egitim.egitim());
        }






        private void btn_ekle_Click(object sender, EventArgs e)
        {
            //personelEkle ekle = new personelEkle();
            //ekle.Show();
            ikmainformload(new personelEkle());
        }




        private void eGİTİMLERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //egitimEkle ekle = new egitim.egitimEkle();
            //ekle.Show();
            ikmainformload(new egitim.egitimEkle());
        }

        private void tALEPEDİLENEĞİTİMLERORANIVEKONULARIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //talepEgitimler ekle = new egitim.talepEgitimler();
            //ekle.Show();
            ikmainformload(new egitim.talepEgitimler());
        }


        private void şİRKETİÇİSINAVKATILIMSAYISIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //sirketSinav ekle = new performans.sirketSinav();
            //ekle.Show();
            ikmainformload(new performans.sirketSinav());
        }

        private void şİRKETİÇİSINAVKATILIMORANIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //basariOrani ekle=new performans.basariOrani();
            //ekle.Show();
            ikmainformload(new performans.basariOrani());
        }

        private void bİRİMBAZLIPERFORMANSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //birimBazli ekle= new performans.birimBazli();
            //ekle .Show();
            ikmainformload(new performans.birimBazli());
        }

        private void kİŞİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //kisiBazli ekle=new performans.kisiBazli();
            //ekle .Show();
            ikmainformload(new performans.kisiBazli());
        }

        private void çALIŞANLARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //calisanDetay ekle = new calisanBilgisi.calisanDetay();
            //ekle.Show();
            ikmainformload(new calisanBilgisi.calisanDetay());
        }

        private void eĞİTİMDURUMUANALİZİVEYÜZDESİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //egitimDurum ekle=new calisanBilgisi.egitimDurum();
            //ekle .Show();
            ikmainformload(new calisanBilgisi.egitimDurum());
        }


        private void iZİNLERToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dEVAMSIZLIKMALİYETİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //maliyet ekle =new izinler.maliyet();
            //ekle .Show();
            ikmainformload(new izinler.maliyet());
        }

        private void dgvPersonel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tURNOVERFİRMABAZLIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //turnover1 ekle =new turnover.turnover1();
            //ekle .Show();
            ikmainformload(new turnover.turnover1());
        }

        private void mEMNUNİYETANKETDURUMUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ikmainformload(new memnuniyet.memnuniyet());
        }

        private void ImportDataFromExcel(string excelFilePath)
        {
            try
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(excelFilePath);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowCount = xlRange.Rows.Count;
                // progressBar.Maximum = rowCount;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();

                        

                        for (int i = 3; i <= rowCount; i++)
                        {
                            string kurum = xlRange.Cells[i, 2].Text;
                            string isyeri = xlRange.Cells[i, 3].Text;
                            string birim = xlRange.Cells[i, 4].Text;
                            string gorev = xlRange.Cells[i, 5].Text;
                            string adi = xlRange.Cells[i, 6].Text;
                            string soyadi = xlRange.Cells[i, 7].Text;

                            string istihdam = xlRange.Cells[i, 9].Text;
                          
                            string ise_giris_tarih = xlRange.Cells[i, 10].Text;
                            
                            string isten_cikis_tarih = xlRange.Cells[i, 11].Text;
                           
                            string gun = xlRange.Cells[i, 12].Text;
                            string sgk_cikis_nedeni = xlRange.Cells[i, 13].Text;
                            string sgk_eksik_calisma = xlRange.Cells[i, 14].Text;
                            double brut_kidem_tazminati = xlRange.Cells[i, 15].Value;
                            double brut_ihbar_tazminati = xlRange.Cells[i, 16].Value;
                            double brut_yillik_izin_ucret = xlRange.Cells[i, 17].Value;
                            double brut_yemek = xlRange.Cells[i, 18].Value;
                            double brut_harcirah = xlRange.Cells[i, 19].Value;
                            double brut_fazla_mesai = xlRange.Cells[i, 20].Value;
                            double brut_prim = xlRange.Cells[i, 21].Value;
                            double brut_maas = xlRange.Cells[i, 22].Value;
                            double brut_ucret_toplami = xlRange.Cells[i, 23].Value;
                            double ssk_matrah = xlRange.Cells[i, 24].Value;
                            double ssk_isci_kesinti = xlRange.Cells[i, 25].Value;
                            double ssk_isveren_kesinti = xlRange.Cells[i, 26].Value;
                            double ssk_isci_issizlik = xlRange.Cells[i, 27].Value;
                            double ssk_isveren_issizlik = xlRange.Cells[i, 28].Value;
                            double kumulatif_gv_matrahi = xlRange.Cells[i, 29].Value;
                            double gv_matrahi = xlRange.Cells[i, 30].Value;
                            double hesaplanan_gelir_vergisi = xlRange.Cells[i, 31].Value;
                            double asuc_gelir_vergi_istisnasi = xlRange.Cells[i, 32].Value;
                            double gelir_vergisi_kesintisi = xlRange.Cells[i, 33].Value;

                            string hesaplanan_dv = xlRange.Cells[i, 34].Text;
                            double asuc_dv_istisnasi = xlRange.Cells[i, 35].Value;
                            double dv_kesintisi = xlRange.Cells[i, 36].Value;
                            double net_kidem_tazminati = xlRange.Cells[i, 37].Value;
                            double net_ihbar_tazminati = xlRange.Cells[i, 38].Value;
                            double net_yillik_izin_ucreti = xlRange.Cells[i, 39].Value;
                            double net_yemek = xlRange.Cells[i, 40].Value;
                            double net_harcirah = xlRange.Cells[i, 41].Value;
                            double net_fazla_mesai = xlRange.Cells[i, 42].Value;
                            double net_prim = xlRange.Cells[i, 43].Value;
                            double net_maas = xlRange.Cells[i, 44].Value;
                            double net_ucretler_toplami = xlRange.Cells[i, 45].Value;
                            double bes_kesintisi = xlRange.Cells[i, 46].Value;
                            double trafik_cezasi = xlRange.Cells[i, 47].Value;
                            double maas_haczi = xlRange.Cells[i, 48].Value;
                            double diger_kesinti_toplami = xlRange.Cells[i, 49].Value;
                            double net_odeme = xlRange.Cells[i, 50].Value;
                            double diger_odemeler = xlRange.Cells[i, 51].Value;
                            double personel_odeme = xlRange.Cells[i, 52].Value;
                            double muhtasar_odeme = xlRange.Cells[i, 53].Value;
                            double sgk_maliyet = xlRange.Cells[i, 54].Value;
                            double sgk_indirim = xlRange.Cells[i, 55].Value;
                            double diger_sgk_tesvik = xlRange.Cells[i, 56].Value;
                            double sgk_odeme = xlRange.Cells[i, 57].Value;
                            double toplam_maliyet = xlRange.Cells[i, 58].Value;
                            double kidem_yuk = xlRange.Cells[i, 59].Value;
                            double genel_maliyet = xlRange.Cells[i, 60].Value;
                            string ay = xlRange.Cells[1, 2].Value;
                          
                            double yil = xlRange.Cells[1, 3].Value;
                        
                           


                            if (DateTime.TryParseExact(ise_giris_tarih, "d.M.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime tarih) && DateTime.TryParseExact(isten_cikis_tarih, "d.M.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime tarih1))
                            {
                                // Başarıyla tarih çözümlendi, tarih değişkeni artık doğru değeri içeriyor
                               
                            }
                           
                            //else
                            //{
                            //    // Hatalı tarih formatı, gün sayısının başına 0 ekleyip tekrar deneyin
                            //    if (DateTime.TryParseExact("0" + ise_giris_tarih, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tarih) && DateTime.TryParseExact("0" + isten_cikis_tarih, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tarih1))
                            //    {
                            //        // Başarıyla tarih çözümlendi, tarih değişkeni artık doğru değeri içeriyor


                            //    }
                            //    else
                            //    {
                            //        // İkinci denemede de başarısız olursa hata alın
                            //        this.Alert("TARİH HATA: " + ise_giris_tarih, Form_Alert.enmType.Info);
                            //        this.Alert("TARİH HATA: " + isten_cikis_tarih, Form_Alert.enmType.Info);
                            //        continue;
                            //    }
                            //}




                            //if (decimal.TryParse(xlRange.Cells[i, 16].Text, out brut_kidem_tazminati))
                            //{
                            //    // Başarıyla sayısal değer çözümlendi
                            //}
                            //if (decimal.TryParse(xlRange.Cells[i, 17].Text, out brut_ihbar_tazminati))
                            //{
                            //    // Başarıyla sayısal değer çözümlendi
                            //}
                            //if (decimal.TryParse(xlRange.Cells[i, 18].Text, out brut_yillik_izin_ucret))
                            //{
                            //    // Başarıyla sayısal değer çözümlendi
                            //}
                            //else
                            //{
                            //    this.Alert("toplam HATA: " + faturaToplam + " ft: " + faturaNo, Form_Alert.enmType.Info);

                            //    continue; // Hata olduğunda bu veriyi atlayın
                            //}

                            string tc = xlRange.Cells[i, 8].Text; //tc nin olduğu sütun
                                string checkQuery = "SELECT COUNT(*) FROM logo WHERE tc=@tc";
                                using (SqlCommand checkCommand = new SqlCommand(checkQuery, conn))
                                {
                                    checkCommand.Parameters.AddWithValue("@tc", tc);

                                    int existingRecords = (int)checkCommand.ExecuteScalar();

                                    if (existingRecords > 0)
                                    {

                                        // Belirli bir kombinasyona sahip kayıt zaten varsa güncelleme yapabilirsiniz.
                                        string updateQuery = "UPDATE logo " +
                                                             "SET kurum=@kurum, isyeri=@isyeri,birim=@birim,gorevi=@gorevi, adi=@adi," +
                                                             "soyadi=@soyadi, tc=@tc,istihdam=@istihdam,ise_giris_tarihi=@ise_giris_tarihi,isten_cikis_tarihi=@isten_cikis_tarihi,gun=@gun," +
                                                             "sgk_cikis_nedeni=@sgk_cikis_nedeni,sgk_eksik_calisma_nedeni=@sgk_eksik_calisma_nedeni,brut_kidem_tazminati=@brut_kidem_tazminati," +
                                                             "brut_ihbar_tazminati=@brut_ihbar_tazminati,brut_yillik_izin_ucreti=@brut_yillik_izin_ucreti,brut_yemek=@brut_yemek,brut_harcirah=@brut_harcirah," +
                                                             "brut_fazla_mesai=@brut_fazla_mesai,brut_prim=@brut_prim,brut_maas=@brut_maas,brut_ucret_toplami=@brut_ucret_toplami,ssk_matrahi=@ssk_matrahi," +
                                                             " ssk_isci_kesinti=@ssk_isci_kesinti,ssk_isveren_kesinti=@ssk_isveren_kesinti,ssk_isci_issizlik=@ssk_isci_issizlik,ssk_isveren_issizlik=@ssk_isveren_issizlik," +
                                                             "kumulatif_gv_matrahi=@kumulatif_gv_matrahi,gv_matrahi=@gv_matrahi,hesaplanan_gelir_vergisi=@hesaplanan_gelir_vergisi,asuc_gelir_v_istisnasi=@asuc_gelir_v_istisnasi," +
                                                             "gelir_vergisi_kesintisi=@gelir_vergisi_kesintisi,hesaplanan_damga_vergisi=@hesaplanan_damga_vergisi,asuc_dv_istisnasi=@asuc_dv_istisnasi," +
                                                             "dv_kesintisi=@dv_kesintisi,net_kidem_tazminati=@net_kidem_tazminati,net_ihbar_tazminati=@net_ihbar_tazminati,net_yillik_izin_ucreti=@net_yillik_izin_ucreti," +
                                                             "net_yemek=@net_yemek,net_harcirah=@net_harcirah,net_fazla_mesai=@net_fazla_mesai,net_prim=@net_prim,net_maas=@net_maas,net_ucret_toplami=@net_ucret_toplami," +
                                                             "bes_kesintisi=@bes_kesintisi,trafik_cezasi=@trafik_cezasi,maas_haczi=@maas_haczi,diger_kesinti_toplami=@diger_kesinti_toplami,net_odeme=@net_odeme," +
                                                             " diger_odemeler=@diger_odemeler,personel_odeme=@personel_odeme, muhtasar_odeme=@muhtasar_odeme,sgk_maliyet=@sgk_maliyet,sgk_indirim=@sgk_indirim," +
                                                             "diger_sgk_tesvik=@diger_sgk_tesvik,sgk_odeme=@sgk_odeme,toplam_maliyet=@toplam_maliyet,kidem_yuk=@kidem_yuk,genel_maliyet=@genel_maliyet WHERE tc=@tc and ay=@ay and yil=@yil";

                                                                                    

                                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, conn))
                                        {
                                            updateCommand.Parameters.AddWithValue("@kurum", kurum);
                                            updateCommand.Parameters.AddWithValue("@isyeri", isyeri);
                                            updateCommand.Parameters.AddWithValue("@birim", birim);
                                            updateCommand.Parameters.AddWithValue("@gorevi", gorev);
                                            updateCommand.Parameters.AddWithValue("@adi", adi);
                                            updateCommand.Parameters.AddWithValue("@soyadi", soyadi);
                                            updateCommand.Parameters.AddWithValue("@tc", tc);
                                            updateCommand.Parameters.AddWithValue("@istihdam", istihdam);
                                            updateCommand.Parameters.AddWithValue("@ise_giris_tarihi", Convert.ToDateTime(ise_giris_tarih));
                                            updateCommand.Parameters.AddWithValue("@isten_cikis_tarihi", Convert.ToDateTime(isten_cikis_tarih));
                                            updateCommand.Parameters.AddWithValue("@gun", gun);
                                            updateCommand.Parameters.AddWithValue("@sgk_cikis_nedeni", sgk_cikis_nedeni);
                                            updateCommand.Parameters.AddWithValue("@sgk_eksik_calisma_nedeni", sgk_eksik_calisma);
                                            updateCommand.Parameters.AddWithValue("@brut_kidem_tazminati", brut_kidem_tazminati);
                                            updateCommand.Parameters.AddWithValue("@brut_ihbar_tazminati", brut_ihbar_tazminati);
                                            updateCommand.Parameters.AddWithValue("@brut_yillik_izin_ucreti", brut_yillik_izin_ucret);
                                            updateCommand.Parameters.AddWithValue("@brut_yemek", brut_yemek);
                                            updateCommand.Parameters.AddWithValue("@brut_harcirah", brut_harcirah);
                                            updateCommand.Parameters.AddWithValue("@brut_fazla_mesai", brut_fazla_mesai);
                                            updateCommand.Parameters.AddWithValue("@brut_prim", brut_prim);
                                            updateCommand.Parameters.AddWithValue("@brut_maas", brut_maas);
                                            updateCommand.Parameters.AddWithValue("@brut_ucret_toplami", brut_ucret_toplami);
                                            updateCommand.Parameters.AddWithValue("@ssk_matrahi", ssk_matrah);
                                            updateCommand.Parameters.AddWithValue("@ssk_isci_kesinti", ssk_isci_kesinti);
                                            updateCommand.Parameters.AddWithValue("@ssk_isveren_kesinti", ssk_isveren_kesinti);
                                            updateCommand.Parameters.AddWithValue("@ssk_isci_issizlik", ssk_isci_issizlik);
                                            updateCommand.Parameters.AddWithValue("@ssk_isveren_issizlik", ssk_isveren_issizlik);
                                            updateCommand.Parameters.AddWithValue("@kumulatif_gv_matrahi", kumulatif_gv_matrahi);
                                            updateCommand.Parameters.AddWithValue("@gv_matrahi", gv_matrahi);
                                            updateCommand.Parameters.AddWithValue("@hesaplanan_gelir_vergisi", hesaplanan_gelir_vergisi);
                                            updateCommand.Parameters.AddWithValue("@asuc_gelir_v_istisnasi", asuc_gelir_vergi_istisnasi);
                                            updateCommand.Parameters.AddWithValue("@gelir_vergisi_kesintisi", gelir_vergisi_kesintisi);
                                            updateCommand.Parameters.AddWithValue("@hesaplanan_damga_vergisi", hesaplanan_dv);
                                            updateCommand.Parameters.AddWithValue("@asuc_dv_istisnasi", asuc_dv_istisnasi);
                                            updateCommand.Parameters.AddWithValue("@dv_kesintisi", dv_kesintisi);
                                            updateCommand.Parameters.AddWithValue("@net_kidem_tazminati", net_kidem_tazminati);
                                            updateCommand.Parameters.AddWithValue("@net_ihbar_tazminati", net_ihbar_tazminati);
                                            updateCommand.Parameters.AddWithValue("@net_yillik_izin_ucreti", net_yillik_izin_ucreti);
                                            updateCommand.Parameters.AddWithValue("@net_yemek", net_yemek);
                                            updateCommand.Parameters.AddWithValue("@net_harcirah", net_harcirah);
                                            updateCommand.Parameters.AddWithValue("@net_fazla_mesai", net_fazla_mesai);
                                            updateCommand.Parameters.AddWithValue("@net_prim", net_prim);
                                            updateCommand.Parameters.AddWithValue("@net_maas", net_maas);
                                            updateCommand.Parameters.AddWithValue("@net_ucret_toplami", net_ucretler_toplami);
                                            updateCommand.Parameters.AddWithValue("@bes_kesintisi", bes_kesintisi);
                                            updateCommand.Parameters.AddWithValue("@trafik_cezasi", trafik_cezasi);
                                            updateCommand.Parameters.AddWithValue("@maas_haczi", maas_haczi);
                                            updateCommand.Parameters.AddWithValue("@diger_kesinti_toplami", diger_kesinti_toplami);
                                            updateCommand.Parameters.AddWithValue("@net_odeme", net_odeme);
                                            updateCommand.Parameters.AddWithValue("@diger_odemeler", diger_odemeler);
                                            updateCommand.Parameters.AddWithValue("@personel_odeme", personel_odeme);
                                            updateCommand.Parameters.AddWithValue("@muhtasar_odeme", muhtasar_odeme);
                                            updateCommand.Parameters.AddWithValue("@sgk_maliyet", sgk_maliyet);
                                            updateCommand.Parameters.AddWithValue("@sgk_indirim", sgk_indirim);
                                            updateCommand.Parameters.AddWithValue("@diger_sgk_tesvik", diger_sgk_tesvik);
                                            updateCommand.Parameters.AddWithValue("@sgk_odeme", sgk_odeme);
                                            updateCommand.Parameters.AddWithValue("@toplam_maliyet", toplam_maliyet);
                                            updateCommand.Parameters.AddWithValue("@kidem_yuk", kidem_yuk);
                                            updateCommand.Parameters.AddWithValue("@genel_maliyet", genel_maliyet);
                                          
                                            updateCommand.Parameters.AddWithValue("@ay", ay);
                                            updateCommand.Parameters.AddWithValue("@yil", yil);


                                            updateCommand.ExecuteNonQuery();
                                        
                                        
                                    }

                                    }
                                    else
                                    {
                                        // BelgeNo'ya sahip bir kayıt yoksa ekleme yapabilirsiniz.
                                        string insertQuery = "INSERT INTO logo (kurum, isyeri,birim, gorevi,adi,soyadi,tc,istihdam,ise_giris_tarihi,isten_cikis_tarihi," +
                                            "gun, sgk_cikis_nedeni, sgk_eksik_calisma_nedeni,brut_kidem_tazminati,brut_ihbar_tazminati,brut_yillik_izin_ucreti,brut_yemek,brut_harcirah,brut_fazla_mesai," +
                                            "brut_prim,brut_maas,brut_ucret_toplami,ssk_matrahi,ssk_isci_kesinti,ssk_isveren_kesinti,ssk_isci_issizlik,ssk_isveren_issizlik,kumulatif_gv_matrahi,gv_matrahi," +
                                            "hesaplanan_gelir_vergisi,asuc_gelir_v_istisnasi,gelir_vergisi_kesintisi,hesaplanan_damga_vergisi,asuc_dv_istisnasi,dv_kesintisi,net_kidem_tazminati," +
                                            "net_ihbar_tazminati,net_yillik_izin_ucreti,net_yemek,net_harcirah,net_fazla_mesai,net_prim,net_maas,net_ucret_toplami,bes_kesintisi,trafik_cezasi,maas_haczi," +
                                            "diger_kesinti_toplami,net_odeme,diger_odemeler,personel_odeme,muhtasar_odeme,sgk_maliyet,sgk_indirim,diger_sgk_tesvik,sgk_odeme,toplam_maliyet,kidem_yuk,genel_maliyet,ay,yil) " +
                                                            "VALUES (@kurum, @isyeri,@birim, @gorevi,@adi,@soyadi,@tc,@istihdam,@ise_giris_tarihi,@isten_cikis_tarihi," +
                                            "@gun, @sgk_cikis_nedeni, @sgk_eksik_calisma_nedeni,@brut_kidem_tazminati,@brut_ihbar_tazminati,@brut_yillik_izin_ucreti,@brut_yemek,@brut_harcirah,@brut_fazla_mesai," +
                                            "@brut_prim,@brut_maas,@brut_ucret_toplami,@ssk_matrahi,@ssk_isci_kesinti,@ssk_isveren_kesinti,@ssk_isci_issizlik,@ssk_isveren_issizlik,@kumulatif_gv_matrahi,@gv_matrahi," +
                                            "@hesaplanan_gelir_vergisi,@asuc_gelir_v_istisnasi,@gelir_vergisi_kesintisi,@hesaplanan_damga_vergisi,@asuc_dv_istisnasi,@dv_kesintisi,@net_kidem_tazminati," +
                                            "@net_ihbar_tazminati,@net_yillik_izin_ucreti,@net_yemek,@net_harcirah,@net_fazla_mesai,@net_prim,@net_maas,@net_ucret_toplami,@bes_kesintisi,@trafik_cezasi,@maas_haczi," +
                                            "@diger_kesinti_toplami,@net_odeme,@diger_odemeler,@personel_odeme,@muhtasar_odeme,@sgk_maliyet,@sgk_indirim,@diger_sgk_tesvik,@sgk_odeme,@toplam_maliyet,@kidem_yuk,@genel_maliyet,@ay,@yil)";

                                        
                                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, conn))
                                        {
                                            insertCommand.Parameters.AddWithValue("@kurum", kurum);
                                            insertCommand.Parameters.AddWithValue("@isyeri", isyeri);
                                            insertCommand.Parameters.AddWithValue("@birim", birim);
                                            insertCommand.Parameters.AddWithValue("@gorevi", gorev);
                                            insertCommand.Parameters.AddWithValue("@adi", adi);
                                            insertCommand.Parameters.AddWithValue("@soyadi", soyadi);
                                            insertCommand.Parameters.AddWithValue("@tc", tc);
                                            insertCommand.Parameters.AddWithValue("@istihdam", istihdam);
                                            insertCommand.Parameters.AddWithValue("@ise_giris_tarihi", Convert.ToDateTime(ise_giris_tarih));
                                            insertCommand.Parameters.AddWithValue("@isten_cikis_tarihi", Convert.ToDateTime(isten_cikis_tarih));
                                            insertCommand.Parameters.AddWithValue("@gun", gun);
                                            insertCommand.Parameters.AddWithValue("@sgk_cikis_nedeni", sgk_cikis_nedeni);
                                            insertCommand.Parameters.AddWithValue("@sgk_eksik_calisma_nedeni", sgk_eksik_calisma);
                                            insertCommand.Parameters.AddWithValue("@brut_kidem_tazminati", brut_kidem_tazminati);
                                            insertCommand.Parameters.AddWithValue("@brut_ihbar_tazminati", brut_ihbar_tazminati);
                                            insertCommand.Parameters.AddWithValue("@brut_yillik_izin_ucreti", brut_yillik_izin_ucret);
                                            insertCommand.Parameters.AddWithValue("@brut_yemek", brut_yemek);
                                            insertCommand.Parameters.AddWithValue("@brut_harcirah", brut_harcirah);
                                            insertCommand.Parameters.AddWithValue("@brut_fazla_mesai", brut_fazla_mesai);
                                            insertCommand.Parameters.AddWithValue("@brut_prim", brut_prim);
                                            insertCommand.Parameters.AddWithValue("@brut_maas", brut_maas);
                                            insertCommand.Parameters.AddWithValue("@brut_ucret_toplami", brut_ucret_toplami);
                                            insertCommand.Parameters.AddWithValue("@ssk_matrahi", ssk_matrah);
                                            insertCommand.Parameters.AddWithValue("@ssk_isci_kesinti", ssk_isci_kesinti);
                                            insertCommand.Parameters.AddWithValue("@ssk_isveren_kesinti", ssk_isveren_kesinti);
                                            insertCommand.Parameters.AddWithValue("@ssk_isci_issizlik", ssk_isci_issizlik);
                                            insertCommand.Parameters.AddWithValue("@ssk_isveren_issizlik", ssk_isveren_issizlik);
                                            insertCommand.Parameters.AddWithValue("@kumulatif_gv_matrahi", kumulatif_gv_matrahi);
                                            insertCommand.Parameters.AddWithValue("@gv_matrahi", gv_matrahi);
                                            insertCommand.Parameters.AddWithValue("@hesaplanan_gelir_vergisi", hesaplanan_gelir_vergisi);
                                            insertCommand.Parameters.AddWithValue("@asuc_gelir_v_istisnasi", asuc_gelir_vergi_istisnasi);
                                            insertCommand.Parameters.AddWithValue("@gelir_vergisi_kesintisi", gelir_vergisi_kesintisi);
                                            insertCommand.Parameters.AddWithValue("@hesaplanan_damga_vergisi", hesaplanan_dv);
                                            insertCommand.Parameters.AddWithValue("@asuc_dv_istisnasi", asuc_dv_istisnasi);
                                            insertCommand.Parameters.AddWithValue("@dv_kesintisi", dv_kesintisi);
                                            insertCommand.Parameters.AddWithValue("@net_kidem_tazminati", net_kidem_tazminati);
                                            insertCommand.Parameters.AddWithValue("@net_ihbar_tazminati", net_ihbar_tazminati);
                                            insertCommand.Parameters.AddWithValue("@net_yillik_izin_ucreti", net_yillik_izin_ucreti);
                                            insertCommand.Parameters.AddWithValue("@net_yemek", net_yemek);
                                            insertCommand.Parameters.AddWithValue("@net_harcirah", net_harcirah);
                                            insertCommand.Parameters.AddWithValue("@net_fazla_mesai", net_fazla_mesai);
                                            insertCommand.Parameters.AddWithValue("@net_prim", net_prim);
                                            insertCommand.Parameters.AddWithValue("@net_maas", net_maas);
                                            insertCommand.Parameters.AddWithValue("@net_ucret_toplami", net_ucretler_toplami);
                                            insertCommand.Parameters.AddWithValue("@bes_kesintisi", bes_kesintisi);
                                            insertCommand.Parameters.AddWithValue("@trafik_cezasi", trafik_cezasi);
                                            insertCommand.Parameters.AddWithValue("@maas_haczi", maas_haczi);
                                            insertCommand.Parameters.AddWithValue("@diger_kesinti_toplami", diger_kesinti_toplami);
                                            insertCommand.Parameters.AddWithValue("@net_odeme", net_odeme);
                                            insertCommand.Parameters.AddWithValue("@diger_odemeler", diger_odemeler);
                                            insertCommand.Parameters.AddWithValue("@personel_odeme", personel_odeme);
                                            insertCommand.Parameters.AddWithValue("@muhtasar_odeme", muhtasar_odeme);
                                            insertCommand.Parameters.AddWithValue("@sgk_maliyet", sgk_maliyet);
                                            insertCommand.Parameters.AddWithValue("@sgk_indirim", sgk_indirim);
                                            insertCommand.Parameters.AddWithValue("@diger_sgk_tesvik", diger_sgk_tesvik);
                                            insertCommand.Parameters.AddWithValue("@sgk_odeme", sgk_odeme);
                                            insertCommand.Parameters.AddWithValue("@toplam_maliyet", toplam_maliyet);
                                            insertCommand.Parameters.AddWithValue("@kidem_yuk", kidem_yuk);
                                            insertCommand.Parameters.AddWithValue("@genel_maliyet", genel_maliyet);
                                            insertCommand.Parameters.AddWithValue("@ay", ay);
                                            insertCommand.Parameters.AddWithValue("@yil", yil);

                                            insertCommand.ExecuteNonQuery();
                                        }
                                    }
                                }

                                // progressBar.Value = i;
                                Application.DoEvents();
                                conn.Close();
                                this.Alert("KAYIT BAŞARI İLE EKLENDİ ", Form_Alert.enmType.Success);
                               

                            }
                        
                    }
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }

        }

      
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }


        private void DgvDoldur()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    string id, kurum, isyeri, gorev, adi, soyadi, ise_giris_tarihi, isten_cikis_tarihi;
                    conn.Open();
                    SqlCommand query = new SqlCommand("SELECT * FROM logo", conn);
                    SqlDataReader dr = query.ExecuteReader();
                    while (dr.Read())
                    {
                        id = dr["id"].ToString();
                        kurum = dr["kurum"].ToString();
                        isyeri = dr["isyeri"].ToString();
                        gorev = dr["gorevi"].ToString();
                        adi = dr["adi"].ToString();
                        soyadi = dr["soyadi"].ToString();
                        ise_giris_tarihi = dr["ise_giris_tarihi"].ToString();
                        isten_cikis_tarihi = dr["isten_cikis_tarihi"].ToString();

                        dgvGoster.Rows.Add(id, kurum, isyeri, gorev, adi, soyadi, ise_giris_tarihi, isten_cikis_tarihi);


                    }
                    dr.Close();
                    conn.Close();

                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }

        private void ikmainform_Load(object sender, EventArgs e)
        {
            DgvDoldur();
        }

        private void eXCELdenAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Dosyaları|*.xls;*.xlsx";
            openFileDialog.Title = "Excel Dosyası Seçin";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string excelFilePath = openFileDialog.FileName;
                //progressBar.Value = 0;
                //progressBar.Visible = true;
                ImportDataFromExcel(excelFilePath);
            }
        }

        private void pERSONELLERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ikmainformload(new calisanBilgisi.personelGetir());
        }

       
    }
}

using OfficeOpenXml;
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

namespace BPET_PORTAL.insankaynaklari.calisanBilgisi
{
    public partial class personelGetir : Form
    {
        string connectionString = ("Server=95.0.50.22,1382;Initial Catalog=insankaynaklari;User ID=sa;Password=Mustafa1;");
        public personelGetir()
        {
            InitializeComponent();
        }
        private void ImportDataFromExcel(string excelFilePath)
        {
            try
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(excelFilePath);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowCount = xlRange.Rows.Count - 2;
                Console.WriteLine(rowCount);
                // progressBar.Maximum = rowCount;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();

                        for (int i = 3; i <= rowCount; i++)
                            try
                            {
                                if (conn.State != ConnectionState.Open)
                                {
                                    conn.Open();
                                }
                                {
                                    Console.WriteLine("İ: " + i);


                                    string no = xlRange.Cells[i, 1].Text;
                                    string adi = xlRange.Cells[i, 2].Text;
                                    string kan_grubu = xlRange.Cells[i, 4].Text;
                                    string cinsiyet = xlRange.Cells[i, 5].Text;
                                    string yaka = xlRange.Cells[i, 6].Text;
                                    string dogum = xlRange.Cells[i, 7].Text;
                                    int yas = xlRange.Cells[i, 8].Text;
                                    string lokasyon = xlRange.Cells[i, 9].Text;
                                    string sirket = xlRange.Cells[i, 10].Text;
                                    string sgk_dosya = xlRange.Cells[i, 11].Text;
                                    string sgk_giris = xlRange.Cells[i, 12].Text;
                                    string gruba_giris = xlRange.Cells[i, 13].Text;
                                    string statu = xlRange.Cells[i, 14].Value;
                                    string birim = xlRange.Cells[i, 15].Value;
                                    string pozisyon = xlRange.Cells[i, 16].Value;
                                    string okul = xlRange.Cells[i, 17].Value;
                                    string bolum = xlRange.Cells[i, 18].Value;
                                    string ogrenim = xlRange.Cells[i, 19].Value;
                                    if (DateTime.TryParseExact(dogum, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime tarih) && DateTime.TryParseExact(sgk_giris, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime tarih1) && DateTime.TryParseExact(gruba_giris, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime tarih2))
                                    {
                                        // Başarıyla tarih çözümlendi, tarih değişkeni artık doğru değeri içeriyor
                                        //Console.WriteLine(tarih.ToString(), tarih1.ToString());

                                    }


                                    string tc = xlRange.Cells[i, 3].Text; //tc nin olduğu sütun
                                    string checkQuery = "SELECT COUNT(*) FROM personelBilgi WHERE tc=@tc AND lokasyon=@lokasyon and sgk_dosya=@sgk_dosya and sirket=@sirket and birim=@birim and pozisyon=@pozisyon";

                                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, conn))

                                    {
                                        checkCommand.Parameters.AddWithValue("@tc", tc);
                                        checkCommand.Parameters.AddWithValue("@lokasyon", lokasyon);
                                        checkCommand.Parameters.AddWithValue("@sgk_dosya", sgk_dosya);
                                        checkCommand.Parameters.AddWithValue("@sirket", sirket);
                                        checkCommand.Parameters.AddWithValue("@birim", birim);
                                        checkCommand.Parameters.AddWithValue("@pozisyon", pozisyon);

                                        int existingRecords = (int)checkCommand.ExecuteScalar();

                                        if (existingRecords > 0)
                                        {

                                            Console.WriteLine("TEST");
                                            // Belirli bir kombinasyona sahip kayıt zaten varsa güncelleme yapabilirsiniz.
                                            string updateQuery = "UPDATE personelBilgi " +
                                                                     "SET  no=@no, adi_soyadi=@adi_soyadi, kan_grubu=@kan_grubu,cinsiyet=@cinsiyet, yaka=@yaka,dogum_tarihi=@dogum_tarihi," +
                                                                     "yas=@yas, sgk_giris=@sgk_giris,gruba_giris=@gruba_giris," +
                                                                     "statu=@statu,mezun_oldugu_okul=@mezun_oldugu_okul,bolum=@bolum,ogrenim=@ogrenim " +
                                                                     "WHERE tc=@tc AND lokasyon=@lokasyon and sgk_dosya=@sgk_dosya and sirket=@sirket and birim=@birim and pozisyon=@pozisyon";



                                            using (SqlCommand updateCommand = new SqlCommand(updateQuery, conn))
                                            {
                                                Console.WriteLine();
                                                updateCommand.Parameters.AddWithValue("@no", no);

                                                updateCommand.Parameters.AddWithValue("@adi_soyadi", adi);
                                                updateCommand.Parameters.AddWithValue("@kan_grubu", kan_grubu);
                                                updateCommand.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                                                updateCommand.Parameters.AddWithValue("@yaka", yaka);
                                                updateCommand.Parameters.AddWithValue("@dogum_tarihi", Convert.ToDateTime(dogum));
                                                updateCommand.Parameters.AddWithValue("@tc", tc);
                                                updateCommand.Parameters.AddWithValue("@yas", Convert.ToInt32(yas));
                                                updateCommand.Parameters.AddWithValue("@lokasyon", lokasyon);
                                                updateCommand.Parameters.AddWithValue("@sirket", sirket);
                                                updateCommand.Parameters.AddWithValue("@sgk_dosya", sgk_dosya);
                                                updateCommand.Parameters.AddWithValue("@sgk_giris", Convert.ToDateTime(sgk_giris));
                                                updateCommand.Parameters.AddWithValue("@gruba_giris", Convert.ToDateTime(gruba_giris));
                                                updateCommand.Parameters.AddWithValue("@statu", statu);
                                                updateCommand.Parameters.AddWithValue("@birim", birim);
                                                updateCommand.Parameters.AddWithValue("@pozisyon", pozisyon);
                                                updateCommand.Parameters.AddWithValue("@mezun_oldugu_okul", okul);
                                                updateCommand.Parameters.AddWithValue("@bolum", bolum);
                                                updateCommand.Parameters.AddWithValue("@ogrenim", ogrenim);


                                                updateCommand.ExecuteNonQuery();

                                                Console.WriteLine("GÜNCELLENEN VERİ:: "+ no);
                                            }

                                        }
                                        else
                                        {
                                            // BelgeNo'ya sahip bir kayıt yoksa ekleme yapabilirsiniz.
                                            string insertQuery = "INSERT INTO personelBilgi (no,adi_soyadi,kan_grubu,cinsiyet,yaka,dogum_tarihi,tc,yas,lokasyon,sirket,sgk_dosya,sgk_giris,gruba_giris," +
                                                "statu,birim,pozisyon,mezun_oldugu_okul,bolum,ogrenim) " +
                                                                "VALUES (@no,@adi_soyadi,@kan_grubu,@cinsiyet,@yaka,@dogum_tarihi,@tc,@yas,@lokasyon,@sirket,@sgk_dosya,@sgk_giris,@gruba_giris," +
                                                                "@statu,@birim,@pozisyon,@mezun_oldugu_okul,@bolum,@ogrenim)";

                                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, conn))
                                            {
                                                insertCommand.Parameters.AddWithValue("@no", no);
                                                insertCommand.Parameters.AddWithValue("@adi_soyadi", adi);
                                                insertCommand.Parameters.AddWithValue("@kan_grubu", kan_grubu);
                                                insertCommand.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                                                insertCommand.Parameters.AddWithValue("@yaka", yaka);
                                                insertCommand.Parameters.AddWithValue("@dogum_tarihi", Convert.ToDateTime(dogum));
                                                insertCommand.Parameters.AddWithValue("@tc", tc);
                                                insertCommand.Parameters.AddWithValue("@yas", Convert.ToInt32(yas));
                                                insertCommand.Parameters.AddWithValue("@lokasyon", lokasyon);
                                                insertCommand.Parameters.AddWithValue("@sirket", sirket);
                                                insertCommand.Parameters.AddWithValue("@sgk_dosya", sgk_dosya);
                                                insertCommand.Parameters.AddWithValue("@sgk_giris", Convert.ToDateTime(sgk_giris));
                                                insertCommand.Parameters.AddWithValue("@gruba_giris", Convert.ToDateTime(gruba_giris));
                                                insertCommand.Parameters.AddWithValue("@statu", statu);
                                                insertCommand.Parameters.AddWithValue("@birim", birim);
                                                insertCommand.Parameters.AddWithValue("@pozisyon", pozisyon);
                                                insertCommand.Parameters.AddWithValue("@mezun_oldugu_okul", okul);
                                                insertCommand.Parameters.AddWithValue("@bolum", bolum);
                                                insertCommand.Parameters.AddWithValue("@ogrenim", ogrenim);

                                                insertCommand.ExecuteNonQuery();

                                            }
                                        }
                                    }

                                    // progressBar.Value = i;
                                    Application.DoEvents();
                                    conn.Close();
                                    //
                                }
                            } 
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            finally
                            {
                                //this.Alert("KAYIT BAŞARI İLE EKLENDİ ", Form_Alert.enmType.Success);
                            }
                           


                            }

                        }
                    

                
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }



        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        private void btn_aktar_Click(object sender, EventArgs e)
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
    }
}

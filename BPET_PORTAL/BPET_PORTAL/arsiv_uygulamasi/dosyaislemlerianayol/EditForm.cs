using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPET_PORTAL.arsiv_uygulamasi.dosyaislemleri
{
    // Düzenleme formu için yeni bir form sınıfı oluşturun
    public partial class EditForm : Form
    {

        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private string originalDosyaID;
        private string dosyaID;
        public EditForm(string dosyaID, SqlConnection connection)
        {
            InitializeComponent();
            this.dosyaID = dosyaID;
            this.originalDosyaID = dosyaID; // Form yüklenirken orijinal dosyaID'yi saklayın
            this.connection = connection;
            dosyaidtextbox.Text = dosyaID;
            // Düzenleme formunu başlatırken verileri yükle
        }

        private void LoadData()
        {
            // DosyaID'ye göre verileri veritabanından al
            string query = "SELECT * FROM Dosyalar WHERE FizikselYer = @DosyaID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@DosyaID", dosyaID);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                // Verileri TextBox'lara aktar ve boşlukları kaldır
                txtDosyaAdi.Text = reader["DosyaAdi"].ToString();
                string selectedAy = reader["DosyaAy"].ToString(); // Veritabanındaki ayı küçük harfe çevir ve boşlukları kaldır
                string selectedYil = reader["DosyaYili"].ToString(); // Yıl değerini boşlukları kaldırarak alabilirsiniz
                txtBirimAdi.Text = reader["Kategori"].ToString();
                txtSirketAdi.Text = reader["SirketIsmi"].ToString();
                txtDolap.Text = reader["Dolap"].ToString().Replace(" ", "");
                txtRaf.Text = reader["Raf"].ToString().Replace(" ", "");
                txtSiraNo.Text = reader["SıraNo"].ToString().Replace(" ", "");
                txtOdaAdi.Text = reader["OdaAdi"].ToString().Replace(" ", "");
                aciklamarichtexbox.Text = reader["Aciklama"].ToString();
                aciklamarichtexbox2.Text = reader["Aciklama2"].ToString();
                txtdosyanumarasi.Text = reader["DosyaNumarasi"].ToString();
                txtdosyatipi.Text = reader["DosyaTipi"].ToString();

                dosyaidtextbox.Text = dosyaID;

                string selectedYear = reader["DosyaYili"].ToString();
                ParseAndSetYears(selectedYear);

                // ComboBox'ta doğru ayı seçmek için küçük harfe çevrilmiş ayı kullanın ve boşlukları kaldır
                comboBoxAy.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(selectedAy);
                comboBoxYil.Text = selectedYil;
                comboBoxAy.Items.Add("");
                // Ay ayraçlarına göre split işlemi yaparak ay listesi elde et
                // Ay ayraçlarına göre split işlemi yaparak ay listesi elde et
                // Ay adlarını kontrol etmek için kültür bilgisini kullan
                // Ay adlarını kontrol etmek için kültür bilgisini kullan
                var cultureInfo = CultureInfo.CurrentCulture;

                // Seçilen ayı kontrol et ve doğru ayları işaretle
                if (selectedAy.Contains("..."))
                {
                    // "..." içeriyorsa, bu bir aralık belirtiyor olabilir.
                    string[] rangeParts = selectedAy.ToLower().Split(new string[] { "..." }, StringSplitOptions.RemoveEmptyEntries);
                    if (rangeParts.Length == 2)
                    {
                        int startIndex = checkedListBox1.Items.IndexOf(cultureInfo.TextInfo.ToTitleCase(rangeParts[0].Trim()));
                        int endIndex = checkedListBox1.Items.IndexOf(cultureInfo.TextInfo.ToTitleCase(rangeParts[1].Trim()));

                        if (startIndex != -1 && endIndex != -1 && startIndex < endIndex)
                        {
                            // Başlangıç ve bitiş indexleri geçerli ve doğru sırada ise, aradaki tüm ayları işaretle.
                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                checkedListBox1.SetItemChecked(i, true);
                            }
                        }
                    }
                }
                else
                {
                    // "..." yoksa veya aralık belirten başka bir ayraç yoksa, belirtilen ayları işaretleme
                    string[] monthParts = selectedAy.ToLower().Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string month in monthParts)
                    {
                        int index = checkedListBox1.Items.IndexOf(cultureInfo.TextInfo.ToTitleCase(month.Trim()));
                        if (index != -1)
                        {
                            checkedListBox1.SetItemChecked(index, true);
                        }
                    }
                }




            }

            reader.Close();
            connection.Close();
        }

        private void ParseAndSetYears(string selectedYear)
        {
            List<string> yearsToUpdate = new List<string>();

            // Seçilen yılı kontrol et ve doğru yılları işaretle
            if (selectedYear.Contains("..."))
            {
                string[] rangeParts = selectedYear.Split(new string[] { "..." }, StringSplitOptions.RemoveEmptyEntries);
                if (rangeParts.Length == 2)
                {
                    int startYear = int.Parse(rangeParts[0]);
                    int endYear = int.Parse(rangeParts[1]);

                    for (int year = startYear; year <= endYear; year++)
                    {
                        int index = checkedListBox2.Items.IndexOf(year.ToString());
                        if (index != -1)
                        {
                            checkedListBox2.SetItemChecked(index, true);
                            yearsToUpdate.Add(year.ToString());
                        }
                    }
                }
            }
            else
            {
                string[] yearParts = selectedYear.Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var year in yearParts)
                {
                    int index = checkedListBox2.Items.IndexOf(year.Trim());
                    if (index != -1)
                    {
                        checkedListBox2.SetItemChecked(index, true);
                        yearsToUpdate.Add(year.Trim());
                    }
                }
            }

            // ComboBoxYil metnini güncelle
            comboBoxYil.Text = string.Join(" ", yearsToUpdate);
        }

        private bool CheckIfDosyaIdExists(string yeniDosyaID)
        {
            // Veritabanında yeni dosya ID'sinin olup olmadığını kontrol et
            string query = "SELECT COUNT(*) FROM Dosyalar WHERE DosyaID = @YeniDosyaID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@YeniDosyaID", yeniDosyaID);

            connection.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();

            return count > 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Eski ve yeni dosya ID'lerini alın
           
            string selectedYıl = comboBoxYil.Text; // Combobox'dan seçilen değil, üstündeki metni alır
            string selectedAy = comboBoxAy.Text;   // Combobox'dan seçilen değil, üstündeki metni alır

            string eskiDosyaID = dosyaID.Replace(" ",""); // Form yüklenirken alınan eski dosya ID
            string yeniDosyaID = $"{txtOdaAdi.Text}-{txtDolap.Text}{txtRaf.Text}-{txtSiraNo.Text}".Replace(" ", "");
            //MessageBox.Show(yeniDosyaID);
            //MessageBox.Show(eskiDosyaID + " eski");
           
            bool idkontrol = CheckIfDosyaIdExists(yeniDosyaID);
            //MessageBox.Show(idkontrol.ToString());
            // Eğer eski ve yeni dosya ID'leri farklıysa güncelleme işlemi yapın
            if ((eskiDosyaID != yeniDosyaID) && (idkontrol == true))
            {
                // Eğer yeni dosya ID veritabanında varsa kullanıcıya bir hata mesajı göster
                //MessageBox.Show("Bu Dosya ID zaten var. Lütfen farklı bir Dosya ID girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Alert("Bu Dosya ID zaten var. Lütfen farklı bir Dosya ID girin.", Form_Alert.enmType.Error);
            }
            else
            {
                yeniDosyaID = yeniDosyaID.Replace(" ", "");
                string updateQuery = "UPDATE Dosyalar SET DosyaID = @YeniDosyaID, FizikselYer =@YeniDosyaID WHERE DosyaID = @EskiDosyaID";
                SqlCommand updateCmd = new SqlCommand(updateQuery, connection);
                updateCmd.Parameters.AddWithValue("@YeniDosyaID", yeniDosyaID);
                updateCmd.Parameters.AddWithValue("@EskiDosyaID", eskiDosyaID);

                connection.Open();
                updateCmd.ExecuteNonQuery();
                connection.Close();

                string digerUpdateQuery = "UPDATE Dosyalar SET Aciklama2 = @Aciklama2, Aciklama = @Aciklama, DosyaTipi = @Dosyatipi, DosyaNumarasi = @Dosyanumarasi,  DosyaAdi = @DosyaAdi, DosyaAy = @DosyaAy, DosyaYili = @DosyaYili, Kategori = @Kategori, SirketIsmi = @SirketIsmi, Dolap = @Dolap, Raf = @Raf, SıraNo = @SiraNo, OdaAdi = @OdaAdi WHERE FizikselYer = @YeniDosyaID";
                SqlCommand updateCmd2 = new SqlCommand(digerUpdateQuery, connection);
                updateCmd2.Parameters.AddWithValue("@YeniDosyaID", yeniDosyaID);
                updateCmd2.Parameters.AddWithValue("@DosyaAdi", txtDosyaAdi.Text);
                updateCmd2.Parameters.AddWithValue("@DosyaAy", selectedAy);
                updateCmd2.Parameters.AddWithValue("@DosyaYili", selectedYıl);
                updateCmd2.Parameters.AddWithValue("@Kategori", txtBirimAdi.Text);
                updateCmd2.Parameters.AddWithValue("@SirketIsmi", txtSirketAdi.Text);
                updateCmd2.Parameters.AddWithValue("@Dolap", txtDolap.Text);
                updateCmd2.Parameters.AddWithValue("@Raf", txtRaf.Text);
                updateCmd2.Parameters.AddWithValue("@SiraNo", txtSiraNo.Text);
                updateCmd2.Parameters.AddWithValue("@OdaAdi", txtOdaAdi.Text);
                updateCmd2.Parameters.AddWithValue("@Aciklama", aciklamarichtexbox.Text);
                updateCmd2.Parameters.AddWithValue("@Aciklama2", aciklamarichtexbox2.Text);

                updateCmd2.Parameters.AddWithValue("@Dosyanumarasi", txtdosyanumarasi.Text);
                updateCmd2.Parameters.AddWithValue("@Dosyatipi", txtdosyatipi.Text);

                connection.Open();
                updateCmd2.ExecuteNonQuery();
                connection.Close();

                //MessageBox.Show("Veriler başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close(); // Düzenleme formunu kapat
            }
            // Diğer verileri güncelleme işlemi
           
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        private void EditForm_Load(object sender, EventArgs e)
        {
            FillComboBoxes();
            LoadData();
            dosyaID = dosyaID;
        }
        private void FillComboBoxes()
        {
            try
            {
                connection.Open();

                // ComboboxYil için verileri veritabanından çek
                string yearQuery = "SELECT DISTINCT DosyaYili FROM Dosyalar";
                dataAdapter = new SqlDataAdapter(yearQuery, connection);
                DataTable yearTable = new DataTable();
                dataAdapter.Fill(yearTable);

                comboBoxYil.Items.Clear(); // Combobox içeriğini temizle
                foreach (DataRow row in yearTable.Rows)
                {
                    comboBoxYil.Items.Add(row["DosyaYili"].ToString());
                }

                // ComboboxAy için verileri veritabanından çek
                string monthQuery = "SELECT DISTINCT DosyaAy FROM Dosyalar";
                dataAdapter = new SqlDataAdapter(monthQuery, connection);
                DataTable monthTable = new DataTable();
                dataAdapter.Fill(monthTable);

                comboBoxAy.Items.Clear(); // Combobox içeriğini temizle
                foreach (DataRow row in monthTable.Rows)
                {
                    comboBoxAy.Items.Add(row["DosyaAy"].ToString());
                }

                // ComboboxSirketIsmi için verileri veritabanından çek (aynı işlem diğer Combobox'lar için de tekrarlanabilir)
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler alınırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
        private void RemoveSpacesFromTextBox(object sender, EventArgs e)
        {
            string dosyaID = $"{txtOdaAdi.Text}-{txtDolap.Text}{txtRaf.Text}-{txtSiraNo.Text}";
            dosyaidtextbox.Text = dosyaID;
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Geçici bir liste oluşturun
            List<string> selectedMonths = new List<string>();

            // Daha önce seçili olan ayları listeye ekleyin
            foreach (int index in checkedListBox1.CheckedIndices)
            {
                if (e.NewValue != CheckState.Checked || e.Index != index)
                {
                    // Eğer yeni işaretlenmiş öge bu değilse, listeye ekle
                    selectedMonths.Add(checkedListBox1.Items[index].ToString());
                }
            }

            // Yeni durumu kontrol edin ve ona göre listeye ekleyin veya çıkarın
            if (e.NewValue == CheckState.Checked && !selectedMonths.Contains(checkedListBox1.Items[e.Index].ToString()))
            {
                // Yeni seçilen ayı listeye ekleyin
                selectedMonths.Add(checkedListBox1.Items[e.Index].ToString());
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                // Seçimi kaldırılan ayı listeden çıkarın
                selectedMonths.Remove(checkedListBox1.Items[e.Index].ToString());
            }

            // ComboBox'ın text'ini güncelleyin
            comboBoxAy.Text = string.Join(" ", selectedMonths);
        }

        private void checkedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Bu fonksiyon bir olay işleyicisi olduğu için, burada doğrudan ComboBoxYil.Text'i
            // güncellemek yerine, seçim işlemi tamamlandıktan sonra güncelleme yapmak daha iyi olacaktır.
            // BeginInvoke kullanarak olay işleyicisinin işlemi tamamlanmasını bekleyebiliriz.
            this.BeginInvoke(new Action(() =>
            {
                List<string> selectedYears = new List<string>();

                // Daha önce seçili olan yılları listeye ekleyin
                foreach (int index in checkedListBox2.CheckedIndices)
                {
                    if (e.NewValue != CheckState.Checked || e.Index != index)
                    {
                        selectedYears.Add(checkedListBox2.Items[index].ToString());
                    }
                }

                // Yeni durumu kontrol edin ve ona göre listeye ekleyin veya çıkarın
                if (e.NewValue == CheckState.Checked)
                {
                    selectedYears.Add(checkedListBox2.Items[e.Index].ToString());
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    selectedYears.Remove(checkedListBox2.Items[e.Index].ToString());
                }

                // ComboBox'ın text'ini güncelleyin
                comboBoxYil.Text = string.Join(" ", selectedYears.OrderBy(y => int.Parse(y)));
            }));
        }
    }

}

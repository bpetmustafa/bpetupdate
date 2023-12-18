using BPET_PORTAL.admin;
using BPET_PORTAL.arsiv_uygulamasi.dosyaislemleri;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Media;
using System.Collections.Generic;
using System.Linq;

namespace BPET_PORTAL.arsiv_uygulamasi
{
    public partial class DosyaEkle : Form
    {
        private mainpage mainForm;
        private const string connectionString = "Server=95.0.50.22,1382;Database=bpetarsiv;User ID=sa;Password=Mustafa1;";
        private SqlConnection connection;
        private bool datagridacik = false;


        public DosyaEkle(string eposta, mainpage mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            connection = new SqlConnection(connectionString);
            epostalabel.Text = eposta;           
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            //mainForm.loadform(new dosyaislemleri2(epostalabel.Text, mainForm));
            this.Close();
        }

        private void DosyaEkle_Load(object sender, EventArgs e)
        {
            int dailyFileCount = GetDailyFileCount();
            gunlukDosyaLabel.Text = "Günlük Eklenen Dosyalar: " + dailyFileCount;

            for (int year = 2004; year <= 2023; year++)
            {
                comboBoxYil.Items.Add(year);

            }
            comboBoxYil.Items.Add("");
            // Dosya aylarını doldur
            string[] months = { "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık", "" };
            foreach (string month in months)
            {
                comboBoxAy.Items.Add(month);
            }
            FillCategoryComboBox();
            ShowLast30UploadedFiles();
        }
        private void FillCategoryComboBox()
        {
            try
            {
                connection.Open();

                string selectQuery = "SELECT DISTINCT Kategori FROM Dosyalar";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxKategori.Items.Add(reader["Kategori"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategoriler alınırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
        private int GetDailyFileCount()
        {
            int dailyFileCount = 0;
            try
            {
                connection.Open();

                // Günlük kaydedilen dosyaları sorgulayın (Gün, Ay ve Yıl için)
                string selectQuery = @"
            SELECT COUNT(*) FROM Dosyalar 
            WHERE 
                DosyaYukleyen = @DosyaYukleyen AND 
                CONVERT(date, OlusturmaTarihi) = CONVERT(date, GETDATE())";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@DosyaYukleyen", epostalabel.Text);
                    dailyFileCount = (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Günlük dosya sayısı alınırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

            return dailyFileCount;
        }

        private void ShowLast30UploadedFiles()
        {
            // Mevcut seçili satırın indeksini al
            int? selectedRowIndex = dataGridViewLast30UploadedFiles.CurrentRow?.Index;

            try
            {
                connection.Open();

                string selectQuery = "SELECT TOP 30 * FROM Dosyalar WHERE DosyaYukleyen = @DosyaYukleyen ORDER BY OlusturmaTarihi DESC";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@DosyaYukleyen", epostalabel.Text);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // DataGridView verilerini güncelle
                    dataGridViewLast30UploadedFiles.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Son 30 yüklenen dosyaları alırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

            // Güncelleme işleminden sonra seçili satıra geri dön
            if (selectedRowIndex.HasValue && selectedRowIndex < dataGridViewLast30UploadedFiles.Rows.Count)
            {
                dataGridViewLast30UploadedFiles.CurrentCell = dataGridViewLast30UploadedFiles.Rows[selectedRowIndex.Value].Cells[0];
                dataGridViewLast30UploadedFiles.Rows[selectedRowIndex.Value].Selected = true;
            }
        }


        private void kayit_islemleri_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                string dosyaID = $"{odaAdiTextBox.Text}-{dolapTextBox.Text}{rafTextBox.Text}-{siraNoTextBox.Text}";

                // Veritabanında aynı dosya ID'si ile kayıt olup olmadığını kontrol et
                string checkQuery = "SELECT COUNT(*) FROM Dosyalar WHERE DosyaID = @DosyaID";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@DosyaID", dosyaID);
                    int dosyaCount = (int)checkCommand.ExecuteScalar();
                    if (dosyaCount > 0)
                    {
                        this.Alert("Aynı dosya ID'si zaten var!", Form_Alert.enmType.Error);
                        return; // Kayıt yapma işlemi burada sona erer
                    }
                }

                // Eğer aynı dosya ID'si ile kayıt yoksa, yeni kayıt yapma işlemine devam et
                string dosyaAdi = dosyaAdiTextBox.Text;
                string dosyaTuru = comboBoxKategori.Text;
                string sirketIsmi = sirketIsmiTextBox.Text;
                string dosyaYil = comboBoxYil.Text; // Combobox'dan seçilen değil, üstündeki metni alır
                string dosyaAy = comboBoxAy.Text;   // Combobox'dan seçilen değil, üstündeki metni alır
                string dosyaNumarasi = dosyaNumarasiTextBox.Text;
                string dosyaTipi = dosyaTipiTextBox.Text;

                // Diğer kayıt işlemleri burada devam eder...

                // Dosya ID'yi oluşturun
                dosyaYeriTextBox.Text = dosyaID;

                // SQL sorgusu oluşturun ve kayıt işlemini gerçekleştirin...
                string insertQuery = "INSERT INTO Dosyalar (DosyaAdi, Kategori, FizikselYer, SirketIsmi, DosyaYili, DosyaAy, DosyaNumarasi, DosyaTipi, DosyaYukleyen, OlusturmaTarihi, DosyaID, Dolap, Raf, SıraNo, OdaAdi, Barkod, Aciklama, Aciklama2) VALUES (@DosyaAdi, @Kategori, @FizikselYer, @SirketIsmi, @DosyaYili, @DosyaAy, @DosyaNumarasi, @DosyaTipi, @DosyaYukleyen, @OlusturmaTarihi, @DosyaID, @Dolap, @Raf, @SıraNo, @OdaAdi, @Barkod, @Aciklama, @Aciklama2)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@DosyaAdi", dosyaAdi);
                    command.Parameters.AddWithValue("@Kategori", dosyaTuru);
                    command.Parameters.AddWithValue("@FizikselYer", dosyaID);
                    command.Parameters.AddWithValue("@SirketIsmi", sirketIsmi);

                    // Dosya yılı ve ayı için null değerleri kabul eden SqlParameter kullanıyoruz.
                    command.Parameters.Add("@DosyaYili", dosyaYil);
                    command.Parameters.Add("@DosyaAy", dosyaAy);

                    command.Parameters.AddWithValue("@DosyaNumarasi", dosyaNumarasi);
                    command.Parameters.AddWithValue("@DosyaTipi", dosyaTipi);
                    command.Parameters.AddWithValue("@DosyaYukleyen", epostalabel.Text);
                    command.Parameters.AddWithValue("@OlusturmaTarihi", DateTime.Now);

                    command.Parameters.AddWithValue("@DosyaID", dosyaID);
                    command.Parameters.AddWithValue("@Dolap", dolapTextBox.Text);
                    command.Parameters.AddWithValue("@Raf", rafTextBox.Text);
                    command.Parameters.AddWithValue("@SıraNo", siraNoTextBox.Text);
                    command.Parameters.AddWithValue("@OdaAdi", odaAdiTextBox.Text);
                    command.Parameters.AddWithValue("@Barkod", 0);
                    command.Parameters.AddWithValue("@Aciklama", aciklamarichtexbox.Text);
                    command.Parameters.AddWithValue("@Aciklama2", aciklamarichtexbox2.Text);


                    command.ExecuteNonQuery();
                }

                this.Alert("DOSYA KAYIT EDİLDİ!", Form_Alert.enmType.Success);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya eklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
            ShowLast30UploadedFiles();
            int dailyFileCount = GetDailyFileCount();
            gunlukDosyaLabel.Text = "Günlük Eklenen Dosyalar: " + dailyFileCount;
        }

        private void odaAdiTextBox_TextChanged(object sender, EventArgs e)
        {
            string dosyaID = $"{odaAdiTextBox.Text}-{dolapTextBox.Text}{rafTextBox.Text}-{siraNoTextBox.Text}";
            dosyaYeriTextBox.Text = dosyaID;
        }

        private void dolapTextBox_TextChanged(object sender, EventArgs e)
        {
            string dosyaID = $"{odaAdiTextBox.Text}-{dolapTextBox.Text}{rafTextBox.Text}-{siraNoTextBox.Text}";
            dosyaYeriTextBox.Text = dosyaID;
        }

        private void rafTextBox_TextChanged(object sender, EventArgs e)
        {
            string dosyaID = $"{odaAdiTextBox.Text}-{dolapTextBox.Text}{rafTextBox.Text}-{siraNoTextBox.Text}";
            dosyaYeriTextBox.Text = dosyaID;
        }

        private void siraNoTextBox_TextChanged(object sender, EventArgs e)
        {
            string dosyaID = $"{odaAdiTextBox.Text}-{dolapTextBox.Text}{rafTextBox.Text}-{siraNoTextBox.Text}";
            dosyaYeriTextBox.Text = dosyaID;
        }

        private void yenile_Click(object sender, EventArgs e)
        {
            ShowLast30UploadedFiles();
            if (datagridacik == false)
            {
                dataGridViewLast30UploadedFiles.Visible = true;
                datagridacik = true;
            }
            else if (datagridacik == true)
            {
                dataGridViewLast30UploadedFiles.Visible = false;
                datagridacik = false;
            }
        }

        private void dataGridViewLast30UploadedFiles_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hitTestInfo = dataGridViewLast30UploadedFiles.HitTest(e.X, e.Y);

                if (hitTestInfo.RowIndex >= 0)
                {
                    // Seçilen satırı güncelle
                    dataGridViewLast30UploadedFiles.ClearSelection();
                    dataGridViewLast30UploadedFiles.Rows[hitTestInfo.RowIndex].Selected = true;

                    ContextMenuStrip contextMenu = new ContextMenuStrip();
                    // Düzenle seçeneği
                    ToolStripMenuItem editMenuItem = new ToolStripMenuItem("Düzenle");
                    editMenuItem.Click += (s, args) =>
                    {
                        string dosyaID = dataGridViewLast30UploadedFiles.SelectedRows[0].Cells["FizikselYer"].Value.ToString();

                        EditFile(dosyaID);
                        ShowLast30UploadedFiles();

                    };
                    ToolStripMenuItem barkodlandiMenuItem = new ToolStripMenuItem("Barkodlandı");
                    barkodlandiMenuItem.Click += (s, args) =>
                    {
                        string dosyaID = dataGridViewLast30UploadedFiles.SelectedRows[0].Cells["FizikselYer"].Value.ToString();

                        // Dosya ID'sini kullanarak veritabanınızda bu dosyanın Barkod değerini 1 olarak güncelleyin
                        UpdateBarkodValue(dosyaID, 1);

                        this.Alert("BARKOD SİSTEMİ: Dosya Barkodlandı " + dosyaID, Form_Alert.enmType.Success);
                    };
                    contextMenu.Items.Add(editMenuItem);
                    dataGridViewLast30UploadedFiles.ContextMenuStrip = contextMenu;

                }
            }
        }
        private void EditFile(string dosyaID)
        {
            // Düzenleme formunu açmak için burada kod ekleyebilirsiniz
            // DosyaID'ye göre düzenleme işlemi yapabilirsiniz
            // Örnek: Düzenleme formunu açabilir veya veriyi düzenleyebilirsiniz
            EditForm editForm = new EditForm(dosyaID, connection);
            editForm.ShowDialog();
        }
        private void UpdateBarkodValue(string dosyaID, int barkodValue)
        {
            try
            {
                // Veritabanı bağlantısını açın
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL sorgusunu hazırlayın
                    string query = "UPDATE Dosyalar SET Barkod = @BarkodValue WHERE FizikselYer = @DosyaID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Parametreleri ekleyin
                        command.Parameters.AddWithValue("@BarkodValue", barkodValue);
                        command.Parameters.AddWithValue("@DosyaID", dosyaID);

                        // Sorguyu çalıştırın
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Güncelleme başarılı

                        }
                        else
                        {
                            // Dosya ID bulunamadı veya güncelleme yapılamadı
                            MessageBox.Show("Barkod güncelleme başarısız oldu. Dosya ID bulunamadı veya başka bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata yakalama
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
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

        private void verileriyenile_Click(object sender, EventArgs e)
        {
            ShowLast30UploadedFiles();
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

        private void sifirlaay_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void resetyil_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedListBox2.SetItemChecked(i, false);
            }
        }
    }
}

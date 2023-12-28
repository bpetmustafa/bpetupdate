using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace BPET_PORTAL.lojistik.lojistikekranlar
{
    public partial class aractarihtakip : Form
    {
        private lojistikanasayfa mainform;
        private const string connectionString = "Server=95.0.50.22,1382;Database=lojistik;User ID=sa;Password=Mustafa1;";
        string eposta;
        private int selectedRowIndex = -1;
        public enum YaklasanTarihNedeni
    {
        Gecmis,
        Yaklasan,
        Normal
    }

        public aractarihtakip(lojistikanasayfa mainform)
        {
            InitializeComponent();
            this.mainform = mainform;
            eposta = mainform.epostalabel.Text;

            // Form yüklenirken varsayılan olarak Binek kategorisini seç
            radioBinek.Checked = true;

            // Kategori seçimi değiştiğinde olayları tanımla
            radioBinek.CheckedChanged += (sender, e) => KategoriSecimiDegisti();
            radioTicari.CheckedChanged += (sender, e) => KategoriSecimiDegisti();

            // Başlangıçta Binek seçili olduğu için, ilgili alanları etkinleştir
            KategoriSecimiDegisti();

            // Verileri göster
            VerileriGoster();

        }
       
        private void KategoriSecimiDegisti()
        {
            // Kullanıcının seçtiği kategoriye bağlı olarak alanların Enabled özelliğini ayarla
            bool isTicari = radioTicari.Checked;

            // Ticari seçilmişse, ilgili alanları etkinleştir; aksi takdirde devre dışı bırak
            dateMaddeTarih.Enabled = isTicari;
            dateAdrTarih.Enabled = isTicari;

            // Diğer alanlar her iki durumda da etkin olacak
            txtPlaka.Enabled = true;
            dateKaskoTarih.Enabled = true;
            dateSigortaTarih.Enabled = true;
            dateMuayeneTarih.Enabled = true;

            // Verileri güncelle
            //VerileriGoster();
        }
        private YaklasanTarihNedeni TarihYaklasanNedeni(DateTime tarih, DateTime currentDate)
        {
            TimeSpan fark = tarih - currentDate;

            if (fark.Days < 0)
            {
                return YaklasanTarihNedeni.Gecmis;
            }
            else if (fark.Days <= 30)
            {
                return YaklasanTarihNedeni.Yaklasan;
            }
            else
            {
                return YaklasanTarihNedeni.Normal;
            }
        }

        private void VerileriGoster()
        {
            // Veritabanındaki tarihtakip tablosundan verileri çek
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SELECT sorgusunu oluştur
                    string selectQuery = "SELECT *, 'N/A' AS YaklasanTarihNedeni FROM tarihtakip WHERE 1 = 1";

                    // Plaka TextBox'ındaki değere göre filtrele
                    if (!string.IsNullOrEmpty(txtAraPlaka.Text))
                    {
                        selectQuery += $" AND plaka LIKE '%{txtAraPlaka.Text}%'";
                    }

                    // Ticari veya Binek kategorisine göre filtrele
                    if (chkTicari.Checked && !chkBinek.Checked)
                    {
                        selectQuery += " AND kategori = 'TİCARİ'";
                    }
                    else if (!chkTicari.Checked && chkBinek.Checked)
                    {
                        selectQuery += " AND kategori = 'BİNEK'";
                    }

                    // Tarih filtresi ekleyerek 30 gün içindeki veya 30 gün öncesindeki kayıtları getir
                    if (chkTarihFiltrele.Checked)
                    {
                        DateTime currentDate = DateTime.Now;

                        // Tarih aralığı 30 gün öncesi ve sonrası olanları içermeli
                        DateTime startDate = currentDate.AddDays(-30);
                        DateTime endDate = currentDate.AddDays(30);

                        selectQuery += $" AND (kasko_tarih BETWEEN '{startDate.ToString("yyyy-MM-dd")}' AND '{endDate.ToString("yyyy-MM-dd")}' " +
                                       $" OR sigorta_tarih BETWEEN '{startDate.ToString("yyyy-MM-dd")}' AND '{endDate.ToString("yyyy-MM-dd")}' " +
                                       $" OR muayene_tarih BETWEEN '{startDate.ToString("yyyy-MM-dd")}' AND '{endDate.ToString("yyyy-MM-dd")}' " +
                                       $" OR madde_tarih BETWEEN '{startDate.ToString("yyyy-MM-dd")}' AND '{endDate.ToString("yyyy-MM-dd")}' " +
                                       $" OR adr_tarih BETWEEN '{startDate.ToString("yyyy-MM-dd")}' AND '{endDate.ToString("yyyy-MM-dd")}')";
                    }

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        // Tarih nedenini belirle ve "YaklasanTarihNedeni" sütununu doldur
                        foreach (DataRow row in dataTable.Rows)
                        {
                            DateTime currentDate = DateTime.Now;
                            row["YaklasanTarihNedeni"] = TarihYaklasanNedeni(Convert.ToDateTime(row["kasko_tarih"]), currentDate);
                            // Diğer tarih alanları için aynı işlemi yapabilirsiniz.
                        }

                        // DataGridView'e verileri bağla
                        dataGridView1.DataSource = dataTable;

                        // Eğer seçili bir satır varsa, tekrar seç
                        if (selectedRowIndex >= 0 && selectedRowIndex < dataGridView1.Rows.Count)
                        {
                            dataGridView1.Rows[selectedRowIndex].Selected = true;
                        }

                        // DataGridView'deki "YaklasanTarihNedeni" sütununu belirt
                        dataGridView1.Columns["YaklasanTarihNedeni"].Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri okuma hatası: " + ex.Message);
                }
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    dataGridView1.AutoResizeColumn(column.Index, DataGridViewAutoSizeColumnMode.AllCells);
                }
            }
        }


        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Kullanıcının girdiği bilgileri al
            string plaka = txtPlaka.Text;
            DateTime kaskoTarih = dateKaskoTarih.Value.Date;
            DateTime sigortaTarih = dateSigortaTarih.Value.Date;
            DateTime muayeneTarih = dateMuayeneTarih.Value.Date;

            // Ticari seçilmişse, ilgili alanlardaki bilgileri de al
            DateTime? maddeTarih = dateMaddeTarih.Enabled ? dateMaddeTarih.Value.Date : (DateTime?)null;
            DateTime? adrTarih = dateAdrTarih.Enabled ? dateAdrTarih.Value.Date : (DateTime?)null;

            // Kategoriye göre "BİNEK" veya "TİCARİ" olarak belirle
            string kategori = radioBinek.Checked ? "BİNEK" : "TİCARİ";

            // Veritabanına ekleme işlemi
            EkleAracBilgisi(plaka, kaskoTarih, sigortaTarih, muayeneTarih, maddeTarih, adrTarih, kategori);

            // Verileri güncelle
            VerileriGoster();
        }

        private void EkleAracBilgisi(string plaka, DateTime kaskoTarih, DateTime sigortaTarih, DateTime muayeneTarih, DateTime? maddeTarih, DateTime? adrTarih, string kategori)
        {
            // Veritabanı bağlantısı oluştur
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Veritabanına ekleme sorgusu
                    string insertQuery = "INSERT INTO tarihtakip (plaka, kasko_tarih, sigorta_tarih, madde_tarih, muayene_tarih, adr_tarih, kategori) " +
                                         "VALUES (@plaka, @kaskoTarih, @sigortaTarih, @maddeTarih, @muayeneTarih, @adrTarih, @kategori)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@plaka", plaka);
                        command.Parameters.AddWithValue("@kaskoTarih", kaskoTarih);
                        command.Parameters.AddWithValue("@sigortaTarih", sigortaTarih);
                        command.Parameters.AddWithValue("@maddeTarih", maddeTarih ?? (object)DBNull.Value); // Nullable DateTime kontrolü
                        command.Parameters.AddWithValue("@muayeneTarih", muayeneTarih);
                        command.Parameters.AddWithValue("@adrTarih", adrTarih ?? (object)DBNull.Value); // Nullable DateTime kontrolü
                        command.Parameters.AddWithValue("@kategori", kategori);

                        // Sorguyu çalıştır
                        int affectedRows = command.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Araç bilgileri başarıyla eklendi.");
                            // İsterseniz burada formu kapatabilirsiniz.
                        }
                        else
                        {
                            MessageBox.Show("Araç bilgileri eklenirken bir hata oluştu.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            // Kullanıcının girdiği bilgileri al
            int aracId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
            string plaka = txtPlaka.Text;
            DateTime kaskoTarih = dateKaskoTarih.Value.Date;
            DateTime sigortaTarih = dateSigortaTarih.Value.Date;
            DateTime muayeneTarih = dateMuayeneTarih.Value.Date;

            // Ticari seçilmişse, ilgili alanlardaki bilgileri de al
            DateTime? maddeTarih = dateMaddeTarih.Enabled ? dateMaddeTarih.Value.Date : (DateTime?)null;
            DateTime? adrTarih = dateAdrTarih.Enabled ? dateAdrTarih.Value.Date : (DateTime?)null;

            // Kategoriye göre "BİNEK" veya "TİCARİ" olarak belirle
            string kategori = radioBinek.Checked ? "BİNEK" : "TİCARİ";

            // Veritabanına güncelleme işlemi
            GuncelleAracBilgisi(aracId, plaka, kaskoTarih, sigortaTarih, muayeneTarih, maddeTarih, adrTarih, kategori);

            // Verileri güncelle
            VerileriGoster();
        }

        private void GuncelleAracBilgisi(int aracId, string plaka, DateTime kaskoTarih, DateTime sigortaTarih, DateTime muayeneTarih, DateTime? maddeTarih, DateTime? adrTarih, string kategori)
        {
            // Veritabanı bağlantısı oluştur
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Veritabanına güncelleme sorgusu
                    string updateQuery = "UPDATE tarihtakip SET plaka = @plaka, kasko_tarih = @kaskoTarih, sigorta_tarih = @sigortaTarih, " +
                                         "madde_tarih = @maddeTarih, muayene_tarih = @muayeneTarih, adr_tarih = @adrTarih, kategori = @kategori " +
                                         "WHERE id = @aracId";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@aracId", aracId);
                        command.Parameters.AddWithValue("@plaka", plaka);
                        command.Parameters.AddWithValue("@kaskoTarih", kaskoTarih);
                        command.Parameters.AddWithValue("@sigortaTarih", sigortaTarih);
                        command.Parameters.AddWithValue("@maddeTarih", maddeTarih ?? (object)DBNull.Value); // Nullable DateTime kontrolü
                        command.Parameters.AddWithValue("@muayeneTarih", muayeneTarih);
                        command.Parameters.AddWithValue("@adrTarih", adrTarih ?? (object)DBNull.Value); // Nullable DateTime kontrolü
                        command.Parameters.AddWithValue("@kategori", kategori);

                        // Sorguyu çalıştır
                        int affectedRows = command.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Araç bilgileri başarıyla güncellendi.");
                            // İsterseniz burada formu kapatabilirsiniz.
                        }
                        else
                        {
                            MessageBox.Show("Araç bilgileri güncellenirken bir hata oluştu.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // DataGridView hücresine iki kez tıklanıldığında bu olay tetiklenir
            if (e.RowIndex >= 0) // Satır seçildi mi kontrolü
            {
                if (modlabel.Visible = false)
                {
                    mainform.Alert("Güncelleme Modu Açıldı!", Form_Alert.enmType.Info);
                }
               // 
                modlabel.Visible = true;
                mobbilgilabel.Visible = true;
                btnguncelle.Visible = true;
                btnkaydet.Visible = false;
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Seçili satırdaki verileri TextBox, DateTimePicker ve CheckBox kontrollerine doldur
                txtPlaka.Text = selectedRow.Cells["plaka"].Value.ToString();
                dateKaskoTarih.Value = Convert.ToDateTime(selectedRow.Cells["kasko_tarih"].Value);
                dateSigortaTarih.Value = Convert.ToDateTime(selectedRow.Cells["sigorta_tarih"].Value);
                dateMuayeneTarih.Value = Convert.ToDateTime(selectedRow.Cells["muayene_tarih"].Value);

                // Kategoriye göre "BİNEK" veya "TİCARİ" olarak belirle
                string kategori = selectedRow.Cells["kategori"].Value.ToString();

                if (kategori == "TİCARİ")
                {
                    // İlgili alanlardaki bilgileri de doldur
                    dateMaddeTarih.Value = Convert.ToDateTime(selectedRow.Cells["madde_tarih"].Value);
                    dateAdrTarih.Value = Convert.ToDateTime(selectedRow.Cells["adr_tarih"].Value);
                    radioTicari.Checked = true;
                }
                else
                {

                    // İlgili alanları boşalt
                    dateMaddeTarih.Value = DateTime.Now; // Varsayılan değer olarak şu anki tarihi koyabilirsiniz
                    dateAdrTarih.Value = DateTime.Now; // Varsayılan değer olarak şu anki tarihi koyabilirsiniz
                                                       // Binek ise, radioBinek'i seçme
                    radioBinek.Checked = true;

                }
            }
            else
            {
                // DataGridView'de bir satır seçilmediyse, btnKaydet'i görünür yap
                btnguncelle.Visible = false;
                btnkaydet.Visible = true;
            }
        }

        private void modlabel_Click(object sender, EventArgs e)
        {
            Sifirla();
        }
        private void Sifirla()
        {
            modlabel.Visible = false;
            mobbilgilabel.Visible = false;
            btnguncelle.Visible = false;
            btnkaydet.Visible = true;
            // TextBox'ları temizle
            txtPlaka.Text = string.Empty;

            // DateTimePicker'ları bugünün tarihi olarak ayarla
            dateKaskoTarih.Value = DateTime.Today;
            dateSigortaTarih.Value = DateTime.Today;
            dateMuayeneTarih.Value = DateTime.Today;
            dateMaddeTarih.Value = DateTime.Today;
            dateAdrTarih.Value = DateTime.Today;

            // RadioButton'lardan Binek'i seç
            radioBinek.Checked = true;

            chkBinek.Checked = false;
            chkTicari.Checked = false;
            txtAraPlaka.Clear();
            chkTarihFiltrele.Checked = false;
            VerileriGoster();
            mainform.Alert("Sıfırlandı!", Form_Alert.enmType.Success);

        }

        private void btnara_Click(object sender, EventArgs e)
        {
            VerileriGoster();
        }

        private void resetle_Click(object sender, EventArgs e)
        {
            Sifirla();
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string neden = row.Cells["YaklasanTarihNedeni"].Value.ToString();

                // Geçmiş ise kırmızı yap, Yaklasan ise sarı yap
                if (neden == YaklasanTarihNedeni.Gecmis.ToString())
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else if (neden == YaklasanTarihNedeni.Yaklasan.ToString())
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void aractarihtakip_Shown(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                dataGridView1.AutoResizeColumn(column.Index, DataGridViewAutoSizeColumnMode.AllCells);
            }
        }
    }
}

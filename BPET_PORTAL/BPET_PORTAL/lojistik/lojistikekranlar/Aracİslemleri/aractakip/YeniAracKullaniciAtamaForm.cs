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

namespace BPET_PORTAL.lojistik.lojistikekranlar.aractakip
{
    public partial class YeniAracKullaniciAtamaForm : Form
    {
        private const string connectionString = "Server=95.0.50.22,1382;Database=lojistik;User ID=sa;Password=Mustafa1;";
        private BindingSource bindingSource;
        private DateTime? secilenTarih = null;

        public YeniAracKullaniciAtamaForm()
        {
            InitializeComponent();
            AracListesiniDoldur();
            KullaniciListesiniDoldur();
            // BindingSource'u oluştur ve DataGridView ile ilişkilendir
            bindingSource = new BindingSource();
            dataGridViewAtamalar.DataSource = bindingSource;
        }
        private int AraclarTablosundanIDBul(string plaka)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT AracID FROM Araclar WHERE Plaka = @Plaka";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Plaka", plaka);

                object result = command.ExecuteScalar();

                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        private int KullanicilarTablosundanIDBul(string kullaniciAdi)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT KullaniciID FROM Kullanicilar WHERE KullaniciAdi = @KullaniciAdi";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);

                object result = command.ExecuteScalar();

                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        private void AtamaKaldir(int aracID, int kullaniciID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM AraclarKullanicilar WHERE AracID = @AracID AND KullaniciID = @KullaniciID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AracID", aracID);
                command.Parameters.AddWithValue("@KullaniciID", kullaniciID);

                int affectedRows = command.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    MessageBox.Show("Araç kullanıcı ataması başarıyla kaldırılmıştır.");
                }
                else
                {
                    MessageBox.Show("Araç kullanıcı ataması kaldırılırken bir hata oluştu.");
                }
            }
        }

        private void AraclarTablosundanSil(int aracID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Araclar WHERE AracID = @AracID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AracID", aracID);

                int affectedRows = command.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    MessageBox.Show("Araç başarıyla silinmiştir.");
                }
                else
                {
                    MessageBox.Show("Araç silinirken bir hata oluştu.");
                }
            }
        }
        private void AracListesiniDoldur()
        {
            cmbAraclar.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT AracID, Plaka FROM Araclar";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int aracID = reader.GetInt32(0);
                    string plaka = reader.GetString(1);
                    string aracBilgisi = $"{plaka} (ID: {aracID})";
                    cmbAraclar.Items.Add(new KeyValuePair<int, string>(aracID, aracBilgisi));
                }
            }
        }
        private void VerileriGoster()
        {
            // DataGridView için verileri güncelle
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Kullanicilar.KullaniciAdi, Araclar.Plaka, AraclarKullanicilar.AtamaTarihi " +
                               "FROM AraclarKullanicilar " +
                               "INNER JOIN Kullanicilar ON AraclarKullanicilar.KullaniciID = Kullanicilar.KullaniciID " +
                               "INNER JOIN Araclar ON AraclarKullanicilar.AracID = Araclar.AracID";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // BindingSource'u güncelle
                bindingSource.DataSource = dataTable;
            }
        }
        private void VerileriGosterGecmisAtamalar()
        {
            // DataGridView için GecmisAtamalar tablosundaki verileri güncelle
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Kullanicilar.KullaniciAdi, Araclar.Plaka, GecmisAtamalar.AtamaTarihi, GecmisAtamalar.BitisTarihi " +
                               "FROM GecmisAtamalar " +
                               "INNER JOIN Kullanicilar ON GecmisAtamalar.KullaniciID = Kullanicilar.KullaniciID " +
                               "INNER JOIN Araclar ON GecmisAtamalar.AracID = Araclar.AracID";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Yeni DataGridView için verileri güncelle
                dataGridViewGecmisAtamalar.DataSource = dataTable;
            }
        }

        private void KullaniciListesiniDoldur()
        {
            cmbKullanicilar.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT KullaniciID, KullaniciAdi FROM Kullanicilar";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int kullaniciID = reader.GetInt32(0);
                    string kullaniciAdi = reader.GetString(1);
                    cmbKullanicilar.Items.Add(new KeyValuePair<int, string>(kullaniciID, kullaniciAdi));
                }
            }
        }


        private void btnAtamaYap_Click(object sender, EventArgs e)
        {
            // Kullanıcı ve araç seçilip seçilmediğini kontrol et
            if (string.IsNullOrWhiteSpace(cmbAraclar.Text) || string.IsNullOrWhiteSpace(cmbKullanicilar.Text))
            {
                MessageBox.Show("Lütfen araç ve kullanıcı seçin.");
                return;
            }

            int aracID;
            if (cmbAraclar.SelectedItem is KeyValuePair<int, string> selectedArac)
            {
                aracID = selectedArac.Key;
            }
            else
            {
                // Combobox'ta seçili bir araç yoksa, yeni araç ekleyelim ve ID'sini alalım
                aracID = AraclarTablosunaEkleVeIDAl(cmbAraclar.Text);

                // Eğer yeni eklenen araç ID'si 0 ise (yani hata durumu), işlemi iptal et
                if (aracID == 0)
                {
                    MessageBox.Show("Araç eklenirken bir hata oluştu.");
                    return;
                }
            }

            int kullaniciID;
            if (cmbKullanicilar.SelectedItem is KeyValuePair<int, string> selectedKullanici)
            {
                kullaniciID = selectedKullanici.Key;
            }
            else
            {
                // Combobox'ta seçili bir kullanıcı yoksa, yeni kullanıcı ekleyelim ve ID'sini alalım
                kullaniciID = KullanicilarTablosunaEkleVeIDAl(cmbKullanicilar.Text);

                // Eğer yeni eklenen kullanıcı ID'si 0 ise (yani hata durumu), işlemi iptal et
                if (kullaniciID == 0)
                {
                    MessageBox.Show("Kullanıcı eklenirken bir hata oluştu.");
                    return;
                }
            }

            // Seçilen araç ve kullanıcının daha önce atanıp atanmadığını kontrol et
            if (AraclarKullanicilarAtandimi(aracID, kullaniciID))
            {
                MessageBox.Show("Bu araç zaten seçilen kullanıcıya atanmıştır.");
                return;
            }

            DateTime atamaTarihi = DateTime.Now;

            AtamaYap(aracID, kullaniciID, atamaTarihi);
            VerileriGoster();
            VerileriGosterGecmisAtamalar(); // Geçmiş atamaları göster

        }

        // Diğer metodlar burada olduğu gibi devam eder...

        private int AraclarTablosunaEkleVeIDAl(string plaka)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Araclar (Plaka) VALUES (@Plaka); SELECT SCOPE_IDENTITY();";
                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@Plaka", plaka);

                // Yeni aracın ID'sini al
                int yeniAracID = Convert.ToInt32(command.ExecuteScalar());

                // Eğer yeni eklenen aracın ID'si 0 ise (yani hata durumu), işlemi iptal et
                if (yeniAracID == 0)
                {
                    MessageBox.Show("Araç eklenirken bir hata oluştu.");
                }

                // Yeni aracın ID'sini geri döndür
                return yeniAracID;
            }
        }

        private int KullanicilarTablosunaEkleVeIDAl(string kullaniciAdi)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Kullanicilar (KullaniciAdi) VALUES (@KullaniciAdi); SELECT SCOPE_IDENTITY();";
                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);

                // Yeni kullanıcının ID'sini al
                int yeniKullaniciID = Convert.ToInt32(command.ExecuteScalar());

                // Eğer yeni eklenen kullanıcının ID'si 0 ise (yani hata durumu), işlemi iptal et
                if (yeniKullaniciID == 0)
                {
                    MessageBox.Show("Kullanıcı eklenirken bir hata oluştu.");
                }

                // Yeni kullanıcının ID'sini geri döndür
                return yeniKullaniciID;
            }
        }

        private bool AraclarKullanicilarAtandimi(int aracID, int kullaniciID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM AraclarKullanicilar WHERE AracID = @AracID AND KullaniciID = @KullaniciID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AracID", aracID);
                command.Parameters.AddWithValue("@KullaniciID", kullaniciID);

                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }

        private void AtamaYap(int aracID, int kullaniciID, DateTime atamaTarihi)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Kullanıcı ve araç ID'leri boş değilse kayıt et
                if (aracID != 0 && kullaniciID != 0)
                {
                    string query = "INSERT INTO AraclarKullanicilar (AracID, KullaniciID, AtamaTarihi) VALUES (@AracID, @KullaniciID, @AtamaTarihi)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@AracID", aracID);
                    command.Parameters.AddWithValue("@KullaniciID", kullaniciID);
                    command.Parameters.AddWithValue("@AtamaTarihi", atamaTarihi);

                    int affectedRows = command.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Araç kullanıcıya başarıyla atanmıştır.");
                    }
                    else
                    {
                        MessageBox.Show("Araç kullanıcıya atanırken bir hata oluştu.");
                    }
                }
                else
                {
                    MessageBox.Show("Araç veya kullanıcı seçimi yapılmadığı için kayıt yapılamadı.");
                }
            }
        }
        private void YeniAracKullaniciAtamaForm_Load(object sender, EventArgs e)
        {
            VerileriGoster();
            VerileriGosterGecmisAtamalar(); // Geçmiş atamaları göster

        }

        private void atamaKaldırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // DataGridView'de seçili bir satır var mı kontrol et
            if (dataGridViewAtamalar.SelectedRows.Count > 0)
            {
                // Seçili satırın indeksini al
                int seciliSatirIndex = dataGridViewAtamalar.SelectedRows[0].Index;

                // Seçili satırdaki verileri al
                DataGridViewRow seciliSatir = dataGridViewAtamalar.Rows[seciliSatirIndex];

                // Kullanıcıya onay sor
                DialogResult result = MessageBox.Show("Bu kaydı silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Arac ve kullanıcı ID'yi DataGridView'den al
                    string plaka = seciliSatir.Cells["Plaka"].Value.ToString();
                    string kullaniciAdi = seciliSatir.Cells["KullaniciAdi"].Value.ToString();

                    int aracID = AraclarTablosundanIDBul(plaka);
                    int kullaniciID = KullanicilarTablosundanIDBul(kullaniciAdi);
                    btnTarihSec_Click(sender, e);

                    if (aracID != 0 && kullaniciID != 0)
                    {
                        // Kullanıcıya atanmış aracın kaydını kaldır
                        GecmisAtamaEkle(aracID, kullaniciID, secilenTarih.Value);

                        AtamaKaldir(aracID, kullaniciID);



                        // Yeni verileri göster
                        VerileriGoster();
                        VerileriGosterGecmisAtamalar(); // Geçmiş atamaları göster

                    }
                    else
                    {
                        MessageBox.Show("Araç veya kullanıcı ID'si bulunamadı.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz bir kayıt seçin.");
            }
        }
        private void GecmisAtamaEkle(int aracID, int kullaniciID, DateTime secilenTarih)
        {
            DateTime? atamaTarihi = AtamaTarihiniGetir(aracID, kullaniciID);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO GecmisAtamalar (AracID, KullaniciID, BitisTarihi, AtamaTarihi) VALUES (@AracID, @KullaniciID, @BitisTarihi, @AtamaTarihi)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AracID", aracID);
                command.Parameters.AddWithValue("@KullaniciID", kullaniciID);
                command.Parameters.AddWithValue("@BitisTarihi", secilenTarih);
                command.Parameters.AddWithValue("@AtamaTarihi", atamaTarihi);
                int affectedRows = command.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    MessageBox.Show("Geçmiş atama başarıyla eklendi.");
                }
                else
                {
                    MessageBox.Show("Geçmiş atama eklenirken bir hata oluştu.");
                }
            }
        }
        private void aracıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // DataGridView'de seçili bir satır var mı kontrol et
            if (dataGridViewAtamalar.SelectedRows.Count > 0)
            {
                // Seçili satırın indeksini al
                int seciliSatirIndex = dataGridViewAtamalar.SelectedRows[0].Index;

                // Seçili satırdaki verileri al
                DataGridViewRow seciliSatir = dataGridViewAtamalar.Rows[seciliSatirIndex];

                // Kullanıcıya onay sor
                DialogResult result = MessageBox.Show("Bu kaydı silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Arac ve kullanıcı ID'yi DataGridView'den al
                    string plaka = seciliSatir.Cells["Plaka"].Value.ToString();
                    string kullaniciAdi = seciliSatir.Cells["KullaniciAdi"].Value.ToString();

                    int aracID = AraclarTablosundanIDBul(plaka);
                    int kullaniciID = KullanicilarTablosundanIDBul(kullaniciAdi);

                    if (aracID != 0 && kullaniciID != 0)
                    {
                        // Kullanıcıya atanmış aracın kaydını kaldır
                        AtamaKaldir(aracID, kullaniciID);

                        // Araç ID'ye sahip kaydı Araclar tablosundan sil
                        AraclarTablosundanSil(aracID);

                        // Yeni verileri göster
                        VerileriGoster();
                        VerileriGosterGecmisAtamalar(); // Geçmiş atamaları göster

                    }
                    else
                    {
                        MessageBox.Show("Araç veya kullanıcı ID'si bulunamadı.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz bir kayıt seçin.");
            }
        }
        private DateTime? AtamaTarihiniGetir(int aracID, int kullaniciID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT AtamaTarihi FROM AraclarKullanicilar WHERE AracID = @AracID AND KullaniciID = @KullaniciID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AracID", aracID);
                command.Parameters.AddWithValue("@KullaniciID", kullaniciID);

                object result = command.ExecuteScalar();

                return result != null && result != DBNull.Value ? (DateTime?)result : null;
            }
        }
        private void btnTarihSec_Click(object sender, EventArgs e)
        {
            using (var form = new Form())
            {
                form.Text = "Tarih Seç";
                form.StartPosition = FormStartPosition.CenterParent;

                var dateTimePicker = new DateTimePicker();
                dateTimePicker.Format = DateTimePickerFormat.Short;
                dateTimePicker.Width = 150;
                dateTimePicker.Location = new Point(20, 20);

                var btnOnayla = new Button();
                btnOnayla.Text = "Onayla";
                btnOnayla.DialogResult = DialogResult.OK;
                btnOnayla.Location = new Point(20, 60);

                var btnIptal = new Button();
                btnIptal.Text = "İptal";
                btnIptal.DialogResult = DialogResult.Cancel;
                btnIptal.Location = new Point(100, 60);

                btnOnayla.Click += (s, ev) =>
                {
                    secilenTarih = dateTimePicker.Value;
                    form.DialogResult = DialogResult.OK;
                    form.Close();
                };

                form.Controls.AddRange(new Control[] { dateTimePicker, btnOnayla, btnIptal });

                if (form.ShowDialog() != DialogResult.OK)
                {
                    secilenTarih = null;
                }
            }
        }

        public class KeyValuePair<TKey, TValue>
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }

            public KeyValuePair(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }

            public override string ToString()
            {
                return Value.ToString();
            }
        }

        private void btnAracEkle_Click(object sender, EventArgs e)
        {
            string yeniPlaka = txtYeniArac.Text.Trim();

            if (string.IsNullOrWhiteSpace(yeniPlaka))
            {
                MessageBox.Show("Lütfen geçerli bir plaka girin.");
                return;
            }
            if (cmbAraclar.Items.Cast<KeyValuePair<int, string>>().Any(item => item.Value == yeniPlaka))
            {
                MessageBox.Show("Bu araç zaten mevcut.");
                return;
            }

            // Yeni aracı ekleyip ID'sini al
            int yeniAracID = AraclarTablosunaEkleVeIDAl(yeniPlaka);

            // Eğer yeni eklenen aracın ID'si 0 ise (yani hata durumu), işlemi iptal et
            if (yeniAracID == 0)
            {
                MessageBox.Show("Araç eklenirken bir hata oluştu.");
                return;
            }

            MessageBox.Show($"Yeni araç başarıyla eklenmiştir. ID: {yeniAracID}");
            txtYeniArac.Clear();
            // Araç listesini güncelle
            AracListesiniDoldur();
        }

        private void btnKullanıcıEkle_Click(object sender, EventArgs e)
        {
            string yeniKullaniciAdi = txtYeniKullanici.Text.Trim();

            if (string.IsNullOrWhiteSpace(yeniKullaniciAdi))
            {
                MessageBox.Show("Lütfen geçerli bir kullanıcı adı girin.");
                return;
            }
            // Mevcut kullanıcıları kontrol et
            if (cmbKullanicilar.Items.Cast<KeyValuePair<int, string>>().Any(item => item.Value == yeniKullaniciAdi))
            {
                MessageBox.Show("Bu kullanıcı zaten mevcut.");
                return;
            }

            // Yeni kullanıcıyı ekleyip ID'sini al
            int yeniKullaniciID = KullanicilarTablosunaEkleVeIDAl(yeniKullaniciAdi);

            // Eğer yeni eklenen kullanıcının ID'si 0 ise (yani hata durumu), işlemi iptal et
            if (yeniKullaniciID == 0)
            {
                MessageBox.Show("Kullanıcı eklenirken bir hata oluştu.");
                return;
            }

            MessageBox.Show($"Yeni kullanıcı başarıyla eklenmiştir. ID: {yeniKullaniciID}");
            txtYeniKullanici.Clear();
            // Kullanıcı listesini güncelle
            KullaniciListesiniDoldur();
        }
    }
}

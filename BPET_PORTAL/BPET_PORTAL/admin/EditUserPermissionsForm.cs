    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    using System.Linq;

    namespace BPET_PORTAL.admin
    {
        public partial class EditUserPermissionsForm : Form
        {
            private const string connectionString = "Server=95.0.50.22,1382;Database=BPET_PORTAL;User ID=sa;Password=Mustafa1;";
            private string kullaniciEposta;
            private CheckBox[] yetkiCheckBoxes;
            private CheckBox[] arsivYetkiCheckBoxes;
            private CheckBox[] victorYetkiCheckBoxes; // Yeni yetki dizisi
            private CheckBox[] arsivKategoriCheckBoxes; // Yeni yetki dizisi
            private CheckBox[] muhasebeYetkiCheckBoxes; // Yeni yetki dizisi
            private CheckBox[] bolgeYetkiCheckBoxes;

        public EditUserPermissionsForm(string eposta)
            {
                InitializeComponent();
                kullaniciEposta = eposta;
                epostalabel.Text = eposta;

                // CheckBox dizilerini oluşturun ve CheckBox kontrollerini bu dizilere ekleyin
                yetkiCheckBoxes = new CheckBox[] { a_checkbox, b_checkbox, c_checkbox, d_checkbox, e_checkbox, f_checkbox, g_checkbox, h_checkbox, m_checkbox, ik_checkbox, lo_checkbox, bi_checkbox };
                arsivYetkiCheckBoxes = new CheckBox[] { a_arsiv_checkbox, b_arsiv_checkbox, c_arsiv_checkbox, d_arsiv_checkbox, e_arsiv_checkbox, aa_arsiv_checkbox, 
                    pdfadmin_arsiv_checkbox, sifre_arsiv_checkbox, sifredegis_arsiv_checkbox };
                arsivKategoriCheckBoxes = new CheckBox[] { m_kategori_checkbox, f_kategori_checkbox, i_kategori_checkbox, s_kategori_checkbox }; // Yeni yetki dizisi
                victorYetkiCheckBoxes = new CheckBox[] { a_victor_checkbox, b_victor_checkbox }; // Yeni yetki dizisi
                muhasebeYetkiCheckBoxes = new CheckBox[] { a_muhasebe_checkbox}; // Yeni yetki dizisi
                bolgeYetkiCheckBoxes = new CheckBox[] { B1_checkbox, B2_checkbox, B3_checkbox, B4_checkbox, B5_checkbox, B6_checkbox, B7_checkbox, B8_checkbox};
                LoadUserPermissions();
                LoadUserKategoriYetkileri(eposta); 

        }
        private void LoadUserKategoriYetkileri(string kullaniciEposta)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Kullanıcının Kategori yetkilerini Kisiler tablosundan alın
                    string query = "SELECT Kategori FROM bpetarsiv.dbo.Kisiler WHERE Email = @Email";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Email", kullaniciEposta);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string kategoriYetkileri = reader["Kategori"].ToString();

                        // Kullanıcının Kategori yetkilerini alın
                        string[] kullaniciKategoriYetkileri = kategoriYetkileri.Split(',');

                        // CheckBox'ları kullanıcının Kategori yetkilerine göre işaretleyin
                        foreach (CheckBox checkBox in arsivKategoriCheckBoxes)
                        {
                            string kategoriYetkiAdi = checkBox.Name.Replace("_checkbox", "");
                            checkBox.Checked = kullaniciKategoriYetkileri.Contains(kategoriYetkiAdi);
                        }
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                this.Alert("Kullanıcı Kategori yetkileri alınamadı: " + ex.Message, Form_Alert.enmType.Error);
            }
        }

        private void LoadUserPermissions()
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "SELECT yetkiler, arsiv_yetki, victor_yetki, muhasebe_yetki, bolge_yetki FROM users WHERE E_Posta = @Eposta";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Eposta", kullaniciEposta);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            string yetkiler = reader["yetkiler"].ToString();
                            string arsivYetki = reader["arsiv_yetki"].ToString();
                            string victorYetki = reader["victor_yetki"].ToString();
                            string muhasebeYetki = reader["muhasebe_yetki"].ToString();
                            string bolgeYetki = reader["bolge_yetki"].ToString();

                        // Kullanıcının mevcut yetkilerini, arşiv yetkilerini ve victor yetkilerini alın
                            string[] kullaniciYetkileri = yetkiler.Split(',');
                            string[] kullaniciArsivYetkileri = arsivYetki.Split(',');
                            string[] kullaniciVictorYetkileri = victorYetki.Split(',');
                            string[] kullaniciMuhasebeYetkileri = muhasebeYetki.Split(',');
                            string[] kullaniciBolgeYetkileri = bolgeYetki.Split(',');
                            // CheckBox'ları mevcut yetkilere göre işaretleyin
                            foreach (CheckBox checkBox in yetkiCheckBoxes)
                            {
                                string yetkiAdi = checkBox.Name.Replace("_checkbox", "");
                                checkBox.Checked = kullaniciYetkileri.Contains(yetkiAdi);
                            }

                            // CheckBox'ları mevcut arşiv yetkilere göre işaretleyin
                            foreach (CheckBox checkBox in arsivYetkiCheckBoxes)
                            {
                                string arsivYetkiAdi = checkBox.Name.Replace("_checkbox", "");
                                checkBox.Checked = kullaniciArsivYetkileri.Contains(arsivYetkiAdi);
                            }

                            // CheckBox'ları mevcut victor yetkilere göre işaretleyin
                            foreach (CheckBox checkBox in victorYetkiCheckBoxes)
                            {
                                string victorYetkiAdi = checkBox.Name.Replace("_checkbox", "");
                                checkBox.Checked = kullaniciVictorYetkileri.Contains(victorYetkiAdi);
                            }
                            // CheckBox'ları mevcut muhasebe yetkilere göre işaretleyin
                            foreach (CheckBox checkBox in muhasebeYetkiCheckBoxes)
                            {
                                string muhasebeYetkiAdi = checkBox.Name.Replace("_checkbox", "");
                                checkBox.Checked = kullaniciMuhasebeYetkileri.Contains(muhasebeYetkiAdi);
                            }
                            // CheckBox'ları mevcut bolge  yetkilere göre işaretleyin
                            foreach (CheckBox checkBox in bolgeYetkiCheckBoxes)
                            {
                                string bolgeYetkiAdi = checkBox.Name.Replace("_checkbox", "");
                                checkBox.Checked = kullaniciBolgeYetkileri.Contains(bolgeYetkiAdi);
                            }
                    }

                        reader.Close();
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {

                    this.Alert("Kullanıcı yetkileri alınamadı: " + ex.Message, Form_Alert.enmType.Error);

                }
            }
            public void Alert(string msg, Form_Alert.enmType type)
            {
                Form_Alert frm = new Form_Alert();
                frm.showAlert(msg, type);
            }
            private string GetSelectedPermissions(CheckBox[] checkBoxes)
            {
                // CheckBox'ların işaretlenip işaretlenmediğini kontrol edin ve seçili yetkileri alın
                string[] seciliYetkiler = checkBoxes
                    .Where(checkbox => checkbox.Checked)
                    .Select(checkbox => checkbox.Name.Replace("_checkbox", ""))
                    .ToArray();

                // Seçili yetkileri virgülle birleştirin
                return string.Join(",", seciliYetkiler);
            }

            private void saveButton_Click(object sender, EventArgs e)
            {
                // Yeni yetkileri, arşiv yetkilerini ve victor yetkilerini alın
                string yeniYetkiler = GetSelectedPermissions(yetkiCheckBoxes);
                string yeniArsivYetki = GetSelectedPermissions(arsivYetkiCheckBoxes);
                string yeniVictorYetki = GetSelectedPermissions(victorYetkiCheckBoxes);
                string yeniMuhasebeYetki = GetSelectedPermissions(muhasebeYetkiCheckBoxes);
                string yeniBolgeYetki = GetSelectedPermissions(bolgeYetkiCheckBoxes);
            try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "UPDATE users SET yetkiler = @Yetkiler, arsiv_yetki = @ArsivYetki, victor_yetki = @VictorYetki, muhasebe_yetki = @MuhasebeYetki, bolge_yetki = @BolgeYetki WHERE E_Posta = @Eposta";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Yetkiler", yeniYetkiler);
                        command.Parameters.AddWithValue("@ArsivYetki", yeniArsivYetki);
                        command.Parameters.AddWithValue("@VictorYetki", yeniVictorYetki);
                        command.Parameters.AddWithValue("@MuhasebeYetki", yeniMuhasebeYetki);
                        command.Parameters.AddWithValue("@BolgeYetki", yeniBolgeYetki);
                        command.Parameters.AddWithValue("@Eposta", kullaniciEposta);

                        int affectedRows = command.ExecuteNonQuery();
                        if (affectedRows > 0)
                        {
                            this.Alert("Yetkiler başarıyla güncellendi!", Form_Alert.enmType.Success);

                            this.Close();
                        }
                        else
                        {
                            this.Alert("Kullanıcı yetkileri güncellenemedi: ", Form_Alert.enmType.Error);
                        }

                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    this.Alert("Kullanıcı yetkileri güncellenemedi: " + ex.Message, Form_Alert.enmType.Error);

                }
            }
        private void kullanıcıeklearsiv(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Kullanıcının veritabanında var olup olmadığını kontrol edin
                    string checkUserQuery = "SELECT COUNT(*) FROM bpetarsiv.dbo.Kisiler WHERE Email = @Email";
                    SqlCommand checkUserCommand = new SqlCommand(checkUserQuery, connection);
                    checkUserCommand.Parameters.AddWithValue("@Email", kullaniciEposta);

                    int userCount = (int)checkUserCommand.ExecuteScalar();

                    if (userCount == 0)
                    {
                        // Kullanıcı veritabanında yoksa ekleme işlemi gerçekleştirin
                        // Kullanıcının bilgilerini users tablosundan alın
                        string userInfoQuery = "SELECT Isim_Soyisim, E_Posta, Telefon, yetkiler FROM users WHERE E_Posta = @Eposta";
                        SqlCommand userInfoCommand = new SqlCommand(userInfoQuery, connection);
                        userInfoCommand.Parameters.AddWithValue("@Eposta", kullaniciEposta);

                        SqlDataReader userInfoReader = userInfoCommand.ExecuteReader();

                        if (userInfoReader.Read())
                        {
                            string isimSoyisim = userInfoReader["Isim_Soyisim"].ToString();
                            string eposta = userInfoReader["E_Posta"].ToString();
                            string telefon = userInfoReader["Telefon"].ToString();
                            string yetkiler = userInfoReader["yetkiler"].ToString();

                            // Kullanıcı bilgilerini aldığımıza göre SqlDataReader'ı kapatın
                            userInfoReader.Close();

                            // Kullanıcıyı Kisiler tablosuna ekleyin
                            string insertQuery = "INSERT INTO bpetarsiv.dbo.Kisiler (KisiAdi, Telefon, Email) VALUES (@KisiAdi, @Telefon, @Email)";
                            SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                            insertCommand.Parameters.AddWithValue("@KisiAdi", isimSoyisim);
                            insertCommand.Parameters.AddWithValue("@Telefon", telefon);
                            insertCommand.Parameters.AddWithValue("@Email", eposta);

                            int affectedRows = insertCommand.ExecuteNonQuery();

                            if (affectedRows > 0)
                            {
                                this.Alert("Kullanıcı başarıyla arşivlendi!", Form_Alert.enmType.Success);
                            }
                            else
                            {
                                this.Alert("Kullanıcı arşivlenemedi: ", Form_Alert.enmType.Error);
                            }
                        }
                        else
                        {
                            this.Alert("Kullanıcı bilgileri bulunamadı.", Form_Alert.enmType.Error);
                        }
                    }
                    else
                    {
                        this.Alert("Kullanıcı zaten arşivlenmiş.", Form_Alert.enmType.Warning);
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                this.Alert("Kullanıcı arşivlenirken bir hata oluştu: " + ex.Message, Form_Alert.enmType.Error);
            }
        }


        private void archiveUserButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Kullanıcının bilgilerini users tablosundan alın
                    string userInfoQuery = "SELECT Isim_Soyisim, E_Posta, Telefon, yetkiler FROM users WHERE E_Posta = @Eposta";
                    SqlCommand userInfoCommand = new SqlCommand(userInfoQuery, connection);
                    userInfoCommand.Parameters.AddWithValue("@Eposta", kullaniciEposta);

                    SqlDataReader userInfoReader = userInfoCommand.ExecuteReader();

                    if (userInfoReader.Read())
                    {
                        string isimSoyisim = userInfoReader["Isim_Soyisim"].ToString();
                        string eposta = userInfoReader["E_Posta"].ToString();
                        string telefon = userInfoReader["Telefon"].ToString();
                        string yetkiler = userInfoReader["yetkiler"].ToString();

                        // Kullanıcı bilgilerini aldığımıza göre SqlDataReader'ı kapatın
                        userInfoReader.Close();

                        // Kullanıcının Kategori yetkilerini Kisiler tablosunda güncelleyin
                        string updateQuery = "UPDATE bpetarsiv.dbo.Kisiler SET Kategori = @Kategori WHERE Email = @Email";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@Kategori", GetSelectedPermissions(arsivKategoriCheckBoxes)); // Seçili Kategori yetkilerini güncelleyin
                        updateCommand.Parameters.AddWithValue("@Email", eposta);

                        int affectedRows = updateCommand.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            this.Alert("Kullanıcı Kategori yetkileri başarıyla güncellendi!", Form_Alert.enmType.Success);
                        }
                        else
                        {
                            this.Alert("Kullanıcı Kategori yetkileri güncellenemedi: ", Form_Alert.enmType.Error);
                        }
                    }
                    else
                    {
                        this.Alert("Kullanıcı bilgileri bulunamadı.", Form_Alert.enmType.Error);
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                this.Alert("Kullanıcı Kategori yetkileri güncellenirken bir hata oluştu: " + ex.Message, Form_Alert.enmType.Error);
                MessageBox.Show("hata: " + ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        }
    }

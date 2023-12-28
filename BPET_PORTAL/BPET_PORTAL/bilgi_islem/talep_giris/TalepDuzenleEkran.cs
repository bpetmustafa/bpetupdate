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

namespace BPET_PORTAL.bilgi_islem.talep_giris
{
    public partial class TalepDuzenleEkran : Form
    {
        private int id;
        private int selectMonth;
        private const string connectionString = "Server=95.0.50.22,1382;Database=TalepVeritabani;User ID=sa;Password=Mustafa1;";
        private string[] sonuclandiranlar = { "İsmail Sertel", "Mustafa Uğur Ceylan", "Burak Sönmez" };
        private TalepGirisAnaEkran anaEkranInstance;
        public TalepDuzenleEkran(int selectedId, TalepGirisAnaEkran anaEkran, int selectcmb)
        {
            anaEkranInstance = anaEkran;
            InitializeComponent();
            id = selectedId;
            selectMonth = selectcmb;

            cmbTalepTuru.Items.Add("Yazılım");
            cmbTalepTuru.Items.Add("Fatura");
            cmbTalepTuru.Items.Add("Donanım");
            cmbTalepTuru.Items.Add("Yazılım-Donanım");

            // Talep Kanalı ComboBox'ına elemanları ekleme
            cmbTalepKanali.Items.Add("Telefon");
            cmbTalepKanali.Items.Add("Yüzyüze");
            cmbTalepKanali.Items.Add("Mail");
            cmbTalepKanali.DropDownStyle = ComboBoxStyle.DropDownList; // Yazı yazılmasını engelle
            cmbTalepKanali.DropDownStyle = ComboBoxStyle.DropDownList; // Yazı yazılmasını engelle
            cmbSonuclandiran.DropDownStyle = ComboBoxStyle.DropDownList; // Yazı yazılmasını engelle
            foreach (string person in sonuclandiranlar)
            {
                cmbSonuclandiran.Items.Add(person);
            }                                                     // Talep tarihi için saat ve dakika seçimi
            dateTimeTalepTarihi.Format = DateTimePickerFormat.Custom;
            dateTimeTalepTarihi.CustomFormat = "dd.MM.yyyy HH:mm";

            // Çözüm tarihi için saat ve dakika seçimi
            dateTimeTalepCozumTarihi.Format = DateTimePickerFormat.Custom;
            dateTimeTalepCozumTarihi.CustomFormat = "dd.MM.yyyy HH:mm";
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Talepler WHERE ID = @ID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ID", id);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        txtKullanici.Text = reader["Kullanici"].ToString();
                        cmbSonuclandiran.SelectedItem = reader["Sonuclandiran"].ToString();
                        cmbTalepTuru.SelectedItem = reader["TalepTur"].ToString();
                        txtKonu.Text = reader["Konu"].ToString();
                        cmbTalepKanali.SelectedItem = reader["TalepKanali"].ToString();
                        dateTimeTalepTarihi.Value = Convert.ToDateTime(reader["TalepTarihi"]);
                        dateTimeTalepCozumTarihi.Value = Convert.ToDateTime(reader["TalepCozumTarihi"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE Talepler SET Kullanici = @Kullanici, Sonuclandiran = @Sonuclandiran, TalepTur = @TalepTur, Konu = @Konu, " +
                                         "TalepKanali = @TalepKanali, TalepTarihi = @TalepTarihi, TalepCozumTarihi = @TalepCozumTarihi WHERE ID = @ID";

                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@Kullanici", txtKullanici.Text);
                    command.Parameters.AddWithValue("@Sonuclandiran", cmbSonuclandiran.SelectedItem);
                    command.Parameters.AddWithValue("@TalepTur", cmbTalepTuru.SelectedItem);
                    command.Parameters.AddWithValue("@Konu", txtKonu.Text);
                    command.Parameters.AddWithValue("@TalepKanali", cmbTalepKanali.SelectedItem);
                    command.Parameters.AddWithValue("@TalepTarihi", dateTimeTalepTarihi.Value);
                    command.Parameters.AddWithValue("@TalepCozumTarihi", dateTimeTalepCozumTarihi.Value);
                    command.Parameters.AddWithValue("@ID", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Veri başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //TalepGirisAnaEkran.RefreshDataGridViewForMonth(selectMonth);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Veri güncellenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

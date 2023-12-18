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

namespace BPET_PORTAL.arsiv_uygulamasi
{
    public partial class KullaniciEkle : Form
    {
        private mainpage mainForm;
        private const string connectionString = "Server=95.0.50.22,1382;Database=bpetarsiv;User ID=sa;Password=Mustafa1;";
        private SqlConnection connection;
        public KullaniciEkle(string eposta, mainpage mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            epostalabel.Text = eposta;
            connection = new SqlConnection(connectionString);
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            mainForm.loadform(new arsivmainpage(epostalabel.Text, mainForm));

        }

        private void btnKisiEkle_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                string isimsoyisim = isimsoyisimtxt.Text;
                string telefon = telefontxt.Text;
                string email = emailtxt.Text;

                string insertQuery = "INSERT INTO Kisiler (KisiAdi, Telefon, Email) VALUES (@Name, @phone, @email)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", isimsoyisim);
                    command.Parameters.AddWithValue("@phone", telefon);
                    command.Parameters.AddWithValue("@email", email);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Kişi başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kişi eklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

    }

 }


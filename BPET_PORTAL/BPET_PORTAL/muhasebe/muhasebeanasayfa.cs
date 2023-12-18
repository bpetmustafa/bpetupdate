using BPET_PORTAL.arsiv_uygulamasi;
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

namespace BPET_PORTAL.muhasebe
{
    public partial class muhasebeanasayfa : Form
    {
        private mainpage mainForm;
        private const string connectionString = "Server=95.0.50.22,1382;Database=BPET_PORTAL;User ID=sa;Password=Mustafa1;";

        public muhasebeanasayfa(string eposta, mainpage mainForm)
        {
            InitializeComponent();
            epostalabel.Text = eposta;
            this.mainForm = mainForm; // mainForm örneğini burada başlatın
        }
        private void kullaniciyetkileri()
        {
            string kullaniciYetkileri = GetKullaniciYetkileri(epostalabel.Text);

            mutabaakat_btn.Visible = CheckUserPermission("a_muhasebe", kullaniciYetkileri);
            mutabaakat_btn.Enabled = CheckUserPermission("a_muhasebe", kullaniciYetkileri);
            mutabakatlabel.Visible = CheckUserPermission("a_muhasebe", kullaniciYetkileri);
        }
        private bool CheckUserPermission(string requiredPermission, string kullaniciYetkileri)
        {
            return kullaniciYetkileri.Contains(requiredPermission);
        }
        private string GetKullaniciYetkileri(string eposta)
        {
            string yetkiler = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();


                    string query = "SELECT muhasebe_yetki FROM users WHERE E_Posta = @Eposta";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Eposta", eposta);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            yetkiler = result.ToString();
                        }
                        else
                        {
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                this.Alert("Kullanıcı yetkileri alınamadı: " + ex.Message, Form_Alert.enmType.Error);

            }

            return yetkiler;
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        private void muhasebeanasayfa_Load(object sender, EventArgs e)
        {
            kullaniciyetkileri();
        }

        private void mutabaakat_btn_Click(object sender, EventArgs e)
        {
            mainForm.loadform(new muhasebe.mutabakat.mutabakat(epostalabel.Text, mainForm));

        }
    }
}

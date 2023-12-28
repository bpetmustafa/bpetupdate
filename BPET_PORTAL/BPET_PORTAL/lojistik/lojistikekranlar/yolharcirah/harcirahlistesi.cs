using BPET_PORTAL.lojistik.lojistikekranlar.yakitgiderleri;
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

namespace BPET_PORTAL.lojistik.lojistikekranlar.yolharcirah
{
    public partial class harcirahlistesi : Form
    {
        private const string connectionString = "Server=95.0.50.22,1382;Database=lojistik;User ID=sa;Password=Mustafa1;";
        private DataTable originalDataTable;

        public harcirahlistesi()
        {
            InitializeComponent();
            LoadData();
        }

        private void btnYeniArac_Click(object sender, EventArgs e)
        {
            yeniharcirah YeniHarcirah = new yeniharcirah();
            YeniHarcirah.ShowDialog();
        }
        private void LoadData()
        {
            // Şuanki yıl ve ay bilgisini al
            DateTime currentDate = DateTime.Now;
            int currentYear = currentDate.Year;
            int currentMonth = currentDate.Month;

            // SQL sorgusunu şuanki yıl ve ay bazında filtreleyerek oluştur
            string queryString = $"SELECT * FROM YolHarcırahListesi WHERE YEAR(Tarih) = {currentYear} AND MONTH(Tarih) = {currentMonth}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                originalDataTable = new DataTable();
                adapter.Fill(originalDataTable);
                dataGridView1.DataSource = originalDataTable;
            }

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                dataGridView1.AutoResizeColumn(column.Index, DataGridViewAutoSizeColumnMode.AllCells);
            }

           
        }
    }
}

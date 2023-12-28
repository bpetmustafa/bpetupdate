using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // Chart kontrolü için gerekli using direktifi

namespace BPET_PORTAL.lojistik.lojistikekranlar.nakliyegelirleri
{
    public partial class RaporEkrani : Form
    {
        public RaporEkrani()
        {
            InitializeComponent();
        }

        public void SetDriverReportData(DataTable data)
        {
            // DataGridView'e verileri ekle
            dataGridViewDriverReport.DataSource = data;

            // Chart'a verileri ekle
            chartDriverReport.Series.Clear();

            Series series = new Series("Toplam Fatura Toplamı");

            foreach (DataRow row in data.Rows)
            {
                string xValue = row["Plaka"].ToString(); // x ekseni değeri, gerekli bir sütun adını belirtin
                double yValue = Convert.ToDouble(row["ToplamFaturaToplam"]); // y ekseni değeri, ToplamFaturaToplam sütununu kullanabilirsiniz

                series.Points.AddXY(xValue, yValue);
            }

            chartDriverReport.Series.Add(series);
        }

        public void SetCariKoduReportData(DataTable data)
        {
            // DataGridView'e verileri ekle
            dataGridViewCariKoduReport.DataSource = data;

            // Chart'a verileri ekle
            chartCariKoduReport.Series.Clear();

            Series series = new Series("Toplam Fatura Toplamı");

            foreach (DataRow row in data.Rows)
            {
                string xValue = row["CariKodu"].ToString(); // x ekseni değeri, gerekli bir sütun adını belirtin
                double yValue = Convert.ToDouble(row["ToplamFaturaToplam"]); // y ekseni değeri, ToplamFaturaToplam sütununu kullanabilirsiniz

                series.Points.AddXY(xValue, yValue);
            }

            chartCariKoduReport.Series.Add(series);
        }
    }
}

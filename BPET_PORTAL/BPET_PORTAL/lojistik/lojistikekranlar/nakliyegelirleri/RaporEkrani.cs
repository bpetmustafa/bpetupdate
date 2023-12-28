using System;
using System.Data;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.WinForms;

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
            cartesianChartDriverReport.Series.Clear();
            cartesianChartDriverReport.Series.Add(new LiveCharts.Wpf.ColumnSeries
            {
                Title = "Toplam Fatura Toplamı",
                Values = new ChartValues<double>(data.AsEnumerable().Select(row => Convert.ToDouble(row["ToplamFaturaToplam"]))),
                DataLabels = true
            });
        }

        public void SetCariKoduReportData(DataTable data)
        {
            // DataGridView'e verileri ekle
            dataGridViewCariKoduReport.DataSource = data;

            // Chart'a verileri ekle
            cartesianChartCariKoduReport.Series.Clear();
            cartesianChartCariKoduReport.Series.Add(new LiveCharts.Wpf.ColumnSeries
            {
                Title = "Toplam Fatura Toplamı",
                Values = new ChartValues<double>(data.AsEnumerable().Select(row => Convert.ToDouble(row["ToplamFaturaToplam"]))),
                DataLabels = true,
            });
        }
    }
}

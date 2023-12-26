using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms.DataVisualization.Charting;
using ZXing;

namespace BPET_PORTAL.lojistik.lojistikekranlar.Aracİslemleri.yakitgiderleri
{
    public static class PdfRaporOlusturucu
    {
        public static void OtoYakitRaporuOlustur(DataTable raporVerileri)
        {
            string pdfDosyaYolu = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "OtoYakitRaporu.pdf");

            using (MemoryStream ms = new MemoryStream())
            {
                using (Document document = new Document(PageSize.A4)) // Dik sayfa
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, ms);

                    document.Open();

                    // Aracın plakasını içeren başlık
                    AddTitleToPdf(document, raporVerileri);

                    // Aylara göre yakıt miktarı grafik (Sol üst)
                    AddChartToPdf(writer, document, "Aylara göre Yakıt Miktarı", "Ay", "YakitMiktariLT", raporVerileri, 36, 575, 225, 200);

                    // Aylara göre yakıt tutarı grafik (Sağ üst)
                    AddChartToPdf(writer, document, "Aylara göre Yakıt Tutarı", "Ay", "YakitTutariTLKDV", raporVerileri, 336, 575, 225, 200);

                    // Yıllara göre yakıt miktarı grafik (Sol alt)
                    AddChartToPdf(writer, document, "Yıllara göre Yakıt Miktarı", "Yil", "YakitMiktariLT", raporVerileri, 36, 125, 225, 200);

                    // Yıllara göre yakıt tutarı grafik (Sağ alt)
                    AddChartToPdf(writer, document, "Yıllara göre Yakıt Tutarı", "Yil", "YakitTutariTLKDV", raporVerileri, 336, 125, 225, 200);

                    document.Close();
                }

                using (MemoryStream fileMs = new MemoryStream(ms.ToArray()))
                {
                    using (FileStream fs = new FileStream(pdfDosyaYolu, FileMode.Create))
                    {
                        fileMs.CopyTo(fs);
                    }
                }
            }

            System.Diagnostics.Process.Start(pdfDosyaYolu);

            MessageBox.Show("PDF raporu başarıyla oluşturuldu ve açıldı.");
        }

        private static void AddTitleToPdf(Document document, DataTable raporVerileri)
        {
            // Plaka bilgisini al
            string plaka = raporVerileri.AsEnumerable().Select(row => row.Field<string>("Plaka")).FirstOrDefault();

            // Başlık
            Font fontBaslik = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.RED);
            Chunk chunk = new Chunk($"Araç Plakasi: {plaka}", fontBaslik);
            Paragraph title = new Paragraph(chunk);
            title.Alignment = Element.ALIGN_CENTER;

            document.Add(title);

            // Boşluk ekle
            document.Add(new Paragraph("\n"));
        }

        private static void AddChartToPdf(PdfWriter writer, Document document, string chartTitle, string xColumnName, string yColumnName, DataTable raporVerileri, float x, float y, float width, float height)
        {
            // Grafik başlığı

            // Grafik
            MemoryStream chartStream = GrafikOlustur(raporVerileri.AsEnumerable(), xColumnName, yColumnName, (int)width, (int)height);
            iTextSharp.text.Image chartImage = iTextSharp.text.Image.GetInstance(chartStream.ToArray());

            // Grafik boyutlarını ve konumunu ayarla
            chartImage.SetAbsolutePosition(x, y);
            chartImage.ScaleAbsolute(width, height);

            // Grafik
            document.Add(chartImage);
            AddCustomTitleToPdf(writer, document, chartTitle, x - width  , y + height, Element.ALIGN_CENTER);

        }

        private static void AddCustomTitleToPdf(PdfWriter writer, Document document, string customTitle, float x, float y, int alignment)
        {
            // PDF içeriğini al
            PdfContentByte content = writer.DirectContent;

            // Yazı tipini ve renk ayarlarını yap
            Font fontCustomTitle = FontFactory.GetFont(FontFactory.HELVETICA, 16, BaseColor.BLACK);
            ColumnText ct = new ColumnText(content);

            // Metni ekleyin
            ct.SetSimpleColumn(new Phrase(customTitle, fontCustomTitle), x,  y, document.PageSize.Width + x +110, 0, 210, alignment);
            ct.Go();
        }


        private static MemoryStream GrafikOlustur(IEnumerable<DataRow> rows, string xColumnName, string yColumnName, int width, int height)
        {
            MemoryStream chartStream = new MemoryStream();

            using (var chart = new Chart())
            {
                chart.Width = width;
                chart.Height = height;
                chart.ChartAreas.Add(new ChartArea());
                Series series = new Series();

                // Veri türlerini belirle
                series.XValueMember = xColumnName;
                series.YValueMembers = yColumnName;

                // Aynı x değerlerine sahip verileri topla
                var groupedRows = rows.GroupBy(r => r[xColumnName]).Select(g => new
                {
                    XValue = g.Key,
                    YValue = g.Sum(r => Convert.ToDouble(r[yColumnName]))
                });

                // Toplanmış verileri ekleyin
                foreach (var groupedRow in groupedRows)
                {
                    series.Points.AddXY(groupedRow.XValue, groupedRow.YValue);
                    series.Points.Last().Label = groupedRow.YValue.ToString("N2"); // Etiket olarak toplam değeri kullanabilirsiniz
                }

                // Veri etiketlerini göstermek için ayarlar
                series.IsValueShownAsLabel = true;
                series["PointWidth"] = "0.6";

                // Grid çizgilerini kaldır
                chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

                // PointLabel'ları düzenle
                series.LabelBackColor = System.Drawing.Color.Transparent; // Arkaplan rengini kaldır
                series.LabelForeColor = System.Drawing.Color.Black; // Yazı rengini ayarla
                series.LabelBorderWidth = 0; // Kenarlık kalınlığını kaldır

                // Veri etiketlerini N2 formatında göster
                series.LabelFormat = "N2";

                chart.Series.Add(series);

                chart.SaveImage(chartStream, ChartImageFormat.Png);
            }

            return chartStream;
        }

    }
}

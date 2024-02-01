namespace BPET_PORTAL.insankaynaklari.iscilikmaliyeti.balpet_maliyet
{
    partial class konsolide
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAylik = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btn_goster = new System.Windows.Forms.Button();
            this.cbYil = new System.Windows.Forms.ComboBox();
            this.cbAy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabYillik = new System.Windows.Forms.TabPage();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btn_gosterYil = new System.Windows.Forms.Button();
            this.cbYilY = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabAylik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabYillik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1266, 644);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAylik);
            this.tabControl1.Controls.Add(this.tabYillik);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1266, 644);
            this.tabControl1.TabIndex = 0;
            // 
            // tabAylik
            // 
            this.tabAylik.Controls.Add(this.chart1);
            this.tabAylik.Controls.Add(this.btn_goster);
            this.tabAylik.Controls.Add(this.cbYil);
            this.tabAylik.Controls.Add(this.cbAy);
            this.tabAylik.Controls.Add(this.label2);
            this.tabAylik.Controls.Add(this.label1);
            this.tabAylik.Location = new System.Drawing.Point(4, 24);
            this.tabAylik.Name = "tabAylik";
            this.tabAylik.Padding = new System.Windows.Forms.Padding(3);
            this.tabAylik.Size = new System.Drawing.Size(1258, 616);
            this.tabAylik.TabIndex = 0;
            this.tabAylik.Text = "AYLIK";
            this.tabAylik.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(3, 198);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            series3.Legend = "Legend1";
            series3.Name = "Konsolide";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(1252, 417);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            title3.Name = "Title1";
            title3.Text = "AYLIK KONSOLİDE MALİYET";
            this.chart1.Titles.Add(title3);
            // 
            // btn_goster
            // 
            this.btn_goster.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_goster.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_goster.Location = new System.Drawing.Point(479, 13);
            this.btn_goster.Name = "btn_goster";
            this.btn_goster.Size = new System.Drawing.Size(75, 23);
            this.btn_goster.TabIndex = 6;
            this.btn_goster.Text = "GÖSTER";
            this.btn_goster.UseVisualStyleBackColor = true;
            this.btn_goster.Click += new System.EventHandler(this.btn_goster_Click);
            // 
            // cbYil
            // 
            this.cbYil.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbYil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbYil.FormattingEnabled = true;
            this.cbYil.Items.AddRange(new object[] {
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024"});
            this.cbYil.Location = new System.Drawing.Point(312, 16);
            this.cbYil.Name = "cbYil";
            this.cbYil.Size = new System.Drawing.Size(121, 21);
            this.cbYil.TabIndex = 3;
            // 
            // cbAy
            // 
            this.cbAy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbAy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbAy.FormattingEnabled = true;
            this.cbAy.Items.AddRange(new object[] {
            "OCAK",
            "ŞUBAT",
            "MART",
            "NİSAN",
            "MAYIS",
            "HAZİRAN",
            "TEMMUZ",
            "AĞUSTOS",
            "EYLÜL",
            "EKİM",
            "KASIM",
            "ARALIK"});
            this.cbAy.Location = new System.Drawing.Point(85, 16);
            this.cbAy.Name = "cbAy";
            this.cbAy.Size = new System.Drawing.Size(121, 21);
            this.cbAy.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(263, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Yıl:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(42, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ay:";
            // 
            // tabYillik
            // 
            this.tabYillik.Controls.Add(this.chart2);
            this.tabYillik.Controls.Add(this.btn_gosterYil);
            this.tabYillik.Controls.Add(this.cbYilY);
            this.tabYillik.Controls.Add(this.label4);
            this.tabYillik.Location = new System.Drawing.Point(4, 24);
            this.tabYillik.Name = "tabYillik";
            this.tabYillik.Padding = new System.Windows.Forms.Padding(3);
            this.tabYillik.Size = new System.Drawing.Size(1258, 616);
            this.tabYillik.TabIndex = 1;
            this.tabYillik.Text = "YILLIK";
            this.tabYillik.UseVisualStyleBackColor = true;
            // 
            // chart2
            // 
            this.chart2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea4.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea4);
            legend4.Enabled = false;
            legend4.Name = "Legend1";
            this.chart2.Legends.Add(legend4);
            this.chart2.Location = new System.Drawing.Point(3, 84);
            this.chart2.Name = "chart2";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series";
            this.chart2.Series.Add(series4);
            this.chart2.Size = new System.Drawing.Size(1252, 531);
            this.chart2.TabIndex = 8;
            this.chart2.Text = "chart2";
            title4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            title4.Name = "Title1";
            title4.Text = "YILLIK KONSOLİDE MALİYET";
            this.chart2.Titles.Add(title4);
            // 
            // btn_gosterYil
            // 
            this.btn_gosterYil.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_gosterYil.Location = new System.Drawing.Point(368, 32);
            this.btn_gosterYil.Name = "btn_gosterYil";
            this.btn_gosterYil.Size = new System.Drawing.Size(105, 23);
            this.btn_gosterYil.TabIndex = 2;
            this.btn_gosterYil.Text = "GÖSTER";
            this.btn_gosterYil.UseVisualStyleBackColor = true;
            this.btn_gosterYil.Click += new System.EventHandler(this.btn_gosterYil_Click);
            // 
            // cbYilY
            // 
            this.cbYilY.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbYilY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYilY.FormattingEnabled = true;
            this.cbYilY.Items.AddRange(new object[] {
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024"});
            this.cbYilY.Location = new System.Drawing.Point(146, 34);
            this.cbYilY.Name = "cbYilY";
            this.cbYilY.Size = new System.Drawing.Size(121, 23);
            this.cbYilY.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Yıl:";
            // 
            // konsolide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 644);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "konsolide";
            this.Text = "konsolide";
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabAylik.ResumeLayout(false);
            this.tabAylik.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabYillik.ResumeLayout(false);
            this.tabYillik.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAylik;
        private System.Windows.Forms.TabPage tabYillik;
        private System.Windows.Forms.ComboBox cbYil;
        private System.Windows.Forms.ComboBox cbAy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_goster;
        private System.Windows.Forms.Button btn_gosterYil;
        private System.Windows.Forms.ComboBox cbYilY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
    }
}
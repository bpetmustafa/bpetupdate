namespace BPET_PORTAL.insankaynaklari.iscilikmaliyeti.diger_sirketler_maliyet
{
    partial class yemekDiger
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_goruntule = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbl_yemek = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbYil = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btn_goruntule);
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Controls.Add(this.lbl_yemek);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbYil);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1231, 607);
            this.panel1.TabIndex = 0;
            // 
            // btn_goruntule
            // 
            this.btn_goruntule.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_goruntule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_goruntule.Location = new System.Drawing.Point(728, 37);
            this.btn_goruntule.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_goruntule.Name = "btn_goruntule";
            this.btn_goruntule.Size = new System.Drawing.Size(135, 27);
            this.btn_goruntule.TabIndex = 11;
            this.btn_goruntule.Text = "GÖRÜNTÜLE";
            this.btn_goruntule.UseVisualStyleBackColor = true;
            this.btn_goruntule.Click += new System.EventHandler(this.btn_goruntule_Click);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 261);
            this.chart1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Net Yemek";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1231, 346);
            this.chart1.TabIndex = 10;
            this.chart1.Text = "chart1";
            // 
            // lbl_yemek
            // 
            this.lbl_yemek.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_yemek.AutoSize = true;
            this.lbl_yemek.Location = new System.Drawing.Point(444, 100);
            this.lbl_yemek.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_yemek.Name = "lbl_yemek";
            this.lbl_yemek.Size = new System.Drawing.Size(0, 15);
            this.lbl_yemek.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(272, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Yıllık Yemek Maliyeti:";
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
            this.cbYil.Location = new System.Drawing.Point(448, 37);
            this.cbYil.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbYil.Name = "cbYil";
            this.cbYil.Size = new System.Drawing.Size(160, 21);
            this.cbYil.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(272, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Yıl Seçiniz:";
            // 
            // yemekDiger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 607);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "yemekDiger";
            this.Text = "yemekDiger";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_goruntule;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lbl_yemek;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbYil;
        private System.Windows.Forms.Label label1;
    }
}
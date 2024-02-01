namespace BPET_PORTAL.insankaynaklari.egitim
{
    partial class talepEgitimler
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvTalepEgitim = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.talepDepartman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.talepEgitimKonusu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.talepYil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_guncelle = new System.Windows.Forms.Button();
            this.btn_Ekle = new System.Windows.Forms.Button();
            this.cbTalepDepartman = new System.Windows.Forms.ComboBox();
            this.rtxtEgitimKonusu = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTalepYil = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTalepEgitim)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 720);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvTalepEgitim);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(1280, 720);
            this.splitContainer1.SplitterDistance = 730;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgvTalepEgitim
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTalepEgitim.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTalepEgitim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTalepEgitim.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.talepDepartman,
            this.talepEgitimKonusu,
            this.talepYil});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTalepEgitim.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTalepEgitim.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvTalepEgitim.Location = new System.Drawing.Point(0, 336);
            this.dgvTalepEgitim.Name = "dgvTalepEgitim";
            this.dgvTalepEgitim.Size = new System.Drawing.Size(730, 384);
            this.dgvTalepEgitim.TabIndex = 4;
            this.dgvTalepEgitim.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTalepEgitim_CellDoubleClick);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // talepDepartman
            // 
            this.talepDepartman.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.talepDepartman.HeaderText = "Talep Eden Departman";
            this.talepDepartman.Name = "talepDepartman";
            this.talepDepartman.Width = 164;
            // 
            // talepEgitimKonusu
            // 
            this.talepEgitimKonusu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.talepEgitimKonusu.HeaderText = "Talep Edilen Eğitim Konusu";
            this.talepEgitimKonusu.Name = "talepEgitimKonusu";
            // 
            // talepYil
            // 
            this.talepYil.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.talepYil.HeaderText = "Talep Edilen Yıl";
            this.talepYil.Name = "talepYil";
            this.talepYil.Width = 107;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btn_guncelle);
            this.panel2.Controls.Add(this.btn_Ekle);
            this.panel2.Controls.Add(this.cbTalepDepartman);
            this.panel2.Controls.Add(this.rtxtEgitimKonusu);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtTalepYil);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(730, 720);
            this.panel2.TabIndex = 10;
            // 
            // btn_guncelle
            // 
            this.btn_guncelle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_guncelle.BackgroundImage = global::BPET_PORTAL.Properties.Resources.icons8_update_501;
            this.btn_guncelle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_guncelle.Location = new System.Drawing.Point(342, 244);
            this.btn_guncelle.Name = "btn_guncelle";
            this.btn_guncelle.Size = new System.Drawing.Size(56, 55);
            this.btn_guncelle.TabIndex = 10;
            this.btn_guncelle.UseVisualStyleBackColor = true;
            this.btn_guncelle.Click += new System.EventHandler(this.btn_guncelle_Click);
            // 
            // btn_Ekle
            // 
            this.btn_Ekle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_Ekle.BackgroundImage = global::BPET_PORTAL.Properties.Resources.icons8_add_481;
            this.btn_Ekle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Ekle.Location = new System.Drawing.Point(250, 244);
            this.btn_Ekle.Name = "btn_Ekle";
            this.btn_Ekle.Size = new System.Drawing.Size(56, 55);
            this.btn_Ekle.TabIndex = 9;
            this.btn_Ekle.UseVisualStyleBackColor = true;
            this.btn_Ekle.Click += new System.EventHandler(this.btn_Ekle_Click);
            // 
            // cbTalepDepartman
            // 
            this.cbTalepDepartman.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbTalepDepartman.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbTalepDepartman.FormattingEnabled = true;
            this.cbTalepDepartman.Location = new System.Drawing.Point(250, 68);
            this.cbTalepDepartman.Name = "cbTalepDepartman";
            this.cbTalepDepartman.Size = new System.Drawing.Size(188, 23);
            this.cbTalepDepartman.TabIndex = 5;
            // 
            // rtxtEgitimKonusu
            // 
            this.rtxtEgitimKonusu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rtxtEgitimKonusu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rtxtEgitimKonusu.Location = new System.Drawing.Point(250, 173);
            this.rtxtEgitimKonusu.Name = "rtxtEgitimKonusu";
            this.rtxtEgitimKonusu.Size = new System.Drawing.Size(188, 53);
            this.rtxtEgitimKonusu.TabIndex = 8;
            this.rtxtEgitimKonusu.Text = "";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(37, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Eğitim Konusu:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(37, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Talep Eden Departman:";
            // 
            // txtTalepYil
            // 
            this.txtTalepYil.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTalepYil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTalepYil.Location = new System.Drawing.Point(250, 126);
            this.txtTalepYil.Name = "txtTalepYil";
            this.txtTalepYil.Size = new System.Drawing.Size(188, 21);
            this.txtTalepYil.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(37, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Talep Edilen Yıl:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.chart1);
            this.panel3.Location = new System.Drawing.Point(3, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(543, 715);
            this.panel3.TabIndex = 3;
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            legend2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.EmptyPointStyle.AxisLabel = "Gerçekleşen";
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            series2.IsValueShownAsLabel = true;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(543, 715);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            title2.BackColor = System.Drawing.Color.Black;
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            title2.ForeColor = System.Drawing.Color.White;
            title2.Name = "Title1";
            title2.Text = "Talep Edilen Eğitim Oranı";
            this.chart1.Titles.Add(title2);
            // 
            // talepEgitimler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "talepEgitimler";
            this.Text = "talepEgitimler";
            this.Load += new System.EventHandler(this.talepEgitimler_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTalepEgitim)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTalepEgitim;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtxtEgitimKonusu;
        private System.Windows.Forms.TextBox txtTalepYil;
        private System.Windows.Forms.ComboBox cbTalepDepartman;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn talepDepartman;
        private System.Windows.Forms.DataGridViewTextBoxColumn talepEgitimKonusu;
        private System.Windows.Forms.DataGridViewTextBoxColumn talepYil;
        private System.Windows.Forms.Button btn_Ekle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btn_guncelle;
    }
}
namespace BPET_PORTAL.borsauygulamasi
{
    partial class borsaanasayfa
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dosyaekle = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBoxHisseKodu = new System.Windows.Forms.TextBox();
            this.textBoxHisseAdet = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxHisseMaliyet = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.epostalabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewUserPortfolio = new System.Windows.Forms.DataGridView();
            this.dataGridViewOrtalamaMaliyet = new System.Windows.Forms.DataGridView();
            this.HisseAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToplamAdet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrtalamaMaliyet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GuncelHisseDegeri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaliyetTutarı = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CariTutar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KarZararMiktari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KarZararYuzdesi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.toplamKarZararLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toplamPortfoyLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.labelTimer = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.excelaktar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserPortfolio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrtalamaMaliyet)).BeginInit();
            this.Panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dosyaekle
            // 
            this.dosyaekle.AutoSize = true;
            this.dosyaekle.BackColor = System.Drawing.Color.Goldenrod;
            this.dosyaekle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dosyaekle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dosyaekle.FlatAppearance.BorderSize = 0;
            this.dosyaekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dosyaekle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dosyaekle.ForeColor = System.Drawing.Color.Black;
            this.dosyaekle.Location = new System.Drawing.Point(10, 84);
            this.dosyaekle.MaximumSize = new System.Drawing.Size(149, 30);
            this.dosyaekle.MinimumSize = new System.Drawing.Size(111, 30);
            this.dosyaekle.Name = "dosyaekle";
            this.dosyaekle.Size = new System.Drawing.Size(136, 30);
            this.dosyaekle.TabIndex = 40;
            this.dosyaekle.Text = "Veri Getir";
            this.dosyaekle.UseVisualStyleBackColor = false;
            this.dosyaekle.Click += new System.EventHandler(this.buttonGetir_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(10, 439);
            this.dataGridView1.MinimumSize = new System.Drawing.Size(547, 104);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(547, 104);
            this.dataGridView1.TabIndex = 60;
            // 
            // textBoxHisseKodu
            // 
            this.textBoxHisseKodu.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxHisseKodu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxHisseKodu.Location = new System.Drawing.Point(8, 50);
            this.textBoxHisseKodu.MaximumSize = new System.Drawing.Size(304, 34);
            this.textBoxHisseKodu.MinimumSize = new System.Drawing.Size(136, 34);
            this.textBoxHisseKodu.Name = "textBoxHisseKodu";
            this.textBoxHisseKodu.Size = new System.Drawing.Size(136, 29);
            this.textBoxHisseKodu.TabIndex = 61;
            // 
            // textBoxHisseAdet
            // 
            this.textBoxHisseAdet.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxHisseAdet.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxHisseAdet.Location = new System.Drawing.Point(148, 50);
            this.textBoxHisseAdet.MaximumSize = new System.Drawing.Size(304, 34);
            this.textBoxHisseAdet.MinimumSize = new System.Drawing.Size(79, 34);
            this.textBoxHisseAdet.Name = "textBoxHisseAdet";
            this.textBoxHisseAdet.Size = new System.Drawing.Size(79, 29);
            this.textBoxHisseAdet.TabIndex = 65;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(37, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 67;
            this.label2.Text = "Hisse İsmi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(169, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 68;
            this.label1.Text = "Adet";
            // 
            // textBoxHisseMaliyet
            // 
            this.textBoxHisseMaliyet.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxHisseMaliyet.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxHisseMaliyet.Location = new System.Drawing.Point(232, 50);
            this.textBoxHisseMaliyet.MaximumSize = new System.Drawing.Size(304, 34);
            this.textBoxHisseMaliyet.MinimumSize = new System.Drawing.Size(79, 34);
            this.textBoxHisseMaliyet.Name = "textBoxHisseMaliyet";
            this.textBoxHisseMaliyet.Size = new System.Drawing.Size(79, 29);
            this.textBoxHisseMaliyet.TabIndex = 69;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(258, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 16);
            this.label3.TabIndex = 70;
            this.label3.Text = "Fiyat";
            // 
            // epostalabel
            // 
            this.epostalabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.epostalabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.epostalabel.Location = new System.Drawing.Point(2, 0);
            this.epostalabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.epostalabel.Name = "epostalabel";
            this.epostalabel.Size = new System.Drawing.Size(143, 19);
            this.epostalabel.TabIndex = 71;
            this.epostalabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.Goldenrod;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(330, 47);
            this.button1.MaximumSize = new System.Drawing.Size(149, 30);
            this.button1.MinimumSize = new System.Drawing.Size(94, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 30);
            this.button1.TabIndex = 72;
            this.button1.Text = "Hisse Ekle";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.buttonHisseEkle_Click);
            // 
            // dataGridViewUserPortfolio
            // 
            this.dataGridViewUserPortfolio.AllowUserToAddRows = false;
            this.dataGridViewUserPortfolio.AllowUserToDeleteRows = false;
            this.dataGridViewUserPortfolio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewUserPortfolio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUserPortfolio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewUserPortfolio.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewUserPortfolio.Location = new System.Drawing.Point(580, 439);
            this.dataGridViewUserPortfolio.MinimumSize = new System.Drawing.Size(530, 104);
            this.dataGridViewUserPortfolio.MultiSelect = false;
            this.dataGridViewUserPortfolio.Name = "dataGridViewUserPortfolio";
            this.dataGridViewUserPortfolio.ReadOnly = true;
            this.dataGridViewUserPortfolio.RowHeadersWidth = 51;
            this.dataGridViewUserPortfolio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUserPortfolio.Size = new System.Drawing.Size(530, 104);
            this.dataGridViewUserPortfolio.TabIndex = 73;
            // 
            // dataGridViewOrtalamaMaliyet
            // 
            this.dataGridViewOrtalamaMaliyet.AllowUserToAddRows = false;
            this.dataGridViewOrtalamaMaliyet.AllowUserToDeleteRows = false;
            this.dataGridViewOrtalamaMaliyet.AllowUserToResizeColumns = false;
            this.dataGridViewOrtalamaMaliyet.AllowUserToResizeRows = false;
            this.dataGridViewOrtalamaMaliyet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewOrtalamaMaliyet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOrtalamaMaliyet.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewOrtalamaMaliyet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewOrtalamaMaliyet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrtalamaMaliyet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HisseAdi,
            this.ToplamAdet,
            this.OrtalamaMaliyet,
            this.GuncelHisseDegeri,
            this.MaliyetTutarı,
            this.CariTutar,
            this.KarZararMiktari,
            this.KarZararYuzdesi});
            this.dataGridViewOrtalamaMaliyet.Cursor = System.Windows.Forms.Cursors.No;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewOrtalamaMaliyet.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewOrtalamaMaliyet.Location = new System.Drawing.Point(8, 128);
            this.dataGridViewOrtalamaMaliyet.MinimumSize = new System.Drawing.Size(1084, 190);
            this.dataGridViewOrtalamaMaliyet.MultiSelect = false;
            this.dataGridViewOrtalamaMaliyet.Name = "dataGridViewOrtalamaMaliyet";
            this.dataGridViewOrtalamaMaliyet.ReadOnly = true;
            this.dataGridViewOrtalamaMaliyet.RowHeadersWidth = 51;
            this.dataGridViewOrtalamaMaliyet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewOrtalamaMaliyet.Size = new System.Drawing.Size(1102, 289);
            this.dataGridViewOrtalamaMaliyet.TabIndex = 75;
            // 
            // HisseAdi
            // 
            this.HisseAdi.DataPropertyName = "HisseAdi";
            this.HisseAdi.HeaderText = "HisseAdi";
            this.HisseAdi.MinimumWidth = 6;
            this.HisseAdi.Name = "HisseAdi";
            this.HisseAdi.ReadOnly = true;
            this.HisseAdi.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.HisseAdi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ToplamAdet
            // 
            this.ToplamAdet.DataPropertyName = "ToplamAdet";
            this.ToplamAdet.HeaderText = "ToplamAdet";
            this.ToplamAdet.MinimumWidth = 6;
            this.ToplamAdet.Name = "ToplamAdet";
            this.ToplamAdet.ReadOnly = true;
            this.ToplamAdet.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ToplamAdet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // OrtalamaMaliyet
            // 
            this.OrtalamaMaliyet.DataPropertyName = "OrtalamaMaliyet";
            this.OrtalamaMaliyet.HeaderText = "OrtalamaMaliyet";
            this.OrtalamaMaliyet.MinimumWidth = 6;
            this.OrtalamaMaliyet.Name = "OrtalamaMaliyet";
            this.OrtalamaMaliyet.ReadOnly = true;
            this.OrtalamaMaliyet.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.OrtalamaMaliyet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // GuncelHisseDegeri
            // 
            this.GuncelHisseDegeri.HeaderText = "GuncelHisseDegeri";
            this.GuncelHisseDegeri.MinimumWidth = 6;
            this.GuncelHisseDegeri.Name = "GuncelHisseDegeri";
            this.GuncelHisseDegeri.ReadOnly = true;
            // 
            // MaliyetTutarı
            // 
            this.MaliyetTutarı.HeaderText = "MaliyetTutarı";
            this.MaliyetTutarı.MinimumWidth = 6;
            this.MaliyetTutarı.Name = "MaliyetTutarı";
            this.MaliyetTutarı.ReadOnly = true;
            // 
            // CariTutar
            // 
            this.CariTutar.HeaderText = "Cari Tutar";
            this.CariTutar.MinimumWidth = 6;
            this.CariTutar.Name = "CariTutar";
            this.CariTutar.ReadOnly = true;
            // 
            // KarZararMiktari
            // 
            this.KarZararMiktari.HeaderText = "Kar Zarar Tutarı";
            this.KarZararMiktari.MinimumWidth = 6;
            this.KarZararMiktari.Name = "KarZararMiktari";
            this.KarZararMiktari.ReadOnly = true;
            // 
            // KarZararYuzdesi
            // 
            this.KarZararYuzdesi.HeaderText = "KarZararYuzdesi";
            this.KarZararYuzdesi.MinimumWidth = 6;
            this.KarZararYuzdesi.Name = "KarZararYuzdesi";
            this.KarZararYuzdesi.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(218, 420);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 76;
            this.label4.Text = "ANLIK VERİ";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(494, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 16);
            this.label5.TabIndex = 77;
            this.label5.Text = "KAR/ZARAR ORTALAMA";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(830, 420);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 16);
            this.label6.TabIndex = 78;
            this.label6.Text = "PORTFÖY";
            // 
            // Panel2
            // 
            this.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(2)))));
            this.Panel2.Controls.Add(this.toplamKarZararLabel);
            this.Panel2.Controls.Add(this.label7);
            this.Panel2.Location = new System.Drawing.Point(712, 9);
            this.Panel2.MaximumSize = new System.Drawing.Size(184, 79);
            this.Panel2.MinimumSize = new System.Drawing.Size(184, 79);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(184, 79);
            this.Panel2.TabIndex = 79;
            // 
            // toplamKarZararLabel
            // 
            this.toplamKarZararLabel.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.toplamKarZararLabel.ForeColor = System.Drawing.Color.White;
            this.toplamKarZararLabel.Location = new System.Drawing.Point(3, 29);
            this.toplamKarZararLabel.Name = "toplamKarZararLabel";
            this.toplamKarZararLabel.Size = new System.Drawing.Size(178, 42);
            this.toplamKarZararLabel.TabIndex = 5;
            this.toplamKarZararLabel.Text = "-----";
            this.toplamKarZararLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(2, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "TOPLAM KAR ZARAR";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(2)))));
            this.panel1.Controls.Add(this.toplamPortfoyLabel);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(934, 9);
            this.panel1.MaximumSize = new System.Drawing.Size(176, 79);
            this.panel1.MinimumSize = new System.Drawing.Size(176, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(176, 79);
            this.panel1.TabIndex = 80;
            // 
            // toplamPortfoyLabel
            // 
            this.toplamPortfoyLabel.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.toplamPortfoyLabel.ForeColor = System.Drawing.Color.White;
            this.toplamPortfoyLabel.Location = new System.Drawing.Point(3, 26);
            this.toplamPortfoyLabel.Name = "toplamPortfoyLabel";
            this.toplamPortfoyLabel.Size = new System.Drawing.Size(165, 42);
            this.toplamPortfoyLabel.TabIndex = 5;
            this.toplamPortfoyLabel.Text = "-----";
            this.toplamPortfoyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(5, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "TOPLAM PORTFÖY";
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ForeColor = System.Drawing.Color.Chartreuse;
            this.button2.Location = new System.Drawing.Point(494, 76);
            this.button2.MaximumSize = new System.Drawing.Size(149, 30);
            this.button2.MinimumSize = new System.Drawing.Size(127, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 30);
            this.button2.TabIndex = 81;
            this.button2.Text = "Verileri Güncelle";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTimer.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelTimer.Location = new System.Drawing.Point(463, 61);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(95, 13);
            this.labelTimer.TabIndex = 82;
            this.labelTimer.Text = "Oto Update Kalan:";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // excelaktar
            // 
            this.excelaktar.AutoSize = true;
            this.excelaktar.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.excelaktar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.excelaktar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.excelaktar.FlatAppearance.BorderSize = 0;
            this.excelaktar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.excelaktar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.excelaktar.ForeColor = System.Drawing.Color.Chartreuse;
            this.excelaktar.Location = new System.Drawing.Point(494, 9);
            this.excelaktar.MaximumSize = new System.Drawing.Size(149, 30);
            this.excelaktar.MinimumSize = new System.Drawing.Size(127, 30);
            this.excelaktar.Name = "excelaktar";
            this.excelaktar.Size = new System.Drawing.Size(149, 30);
            this.excelaktar.TabIndex = 83;
            this.excelaktar.Text = "EXCEL\'E AKTAR";
            this.excelaktar.UseVisualStyleBackColor = false;
            this.excelaktar.Click += new System.EventHandler(this.excelaktar_Click);
            // 
            // borsaanasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 562);
            this.Controls.Add(this.excelaktar);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridViewOrtalamaMaliyet);
            this.Controls.Add(this.dataGridViewUserPortfolio);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.epostalabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxHisseMaliyet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxHisseAdet);
            this.Controls.Add(this.textBoxHisseKodu);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dosyaekle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "borsaanasayfa";
            this.Text = "borsaanasayfa";
            this.Load += new System.EventHandler(this.borsaanasayfa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserPortfolio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrtalamaMaliyet)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button dosyaekle;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxHisseKodu;
        private System.Windows.Forms.TextBox textBoxHisseAdet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxHisseMaliyet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label epostalabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridViewUserPortfolio;
        private System.Windows.Forms.DataGridView dataGridViewOrtalamaMaliyet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label toplamKarZararLabel;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label toplamPortfoyLabel;
        internal System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button excelaktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn HisseAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToplamAdet;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrtalamaMaliyet;
        private System.Windows.Forms.DataGridViewTextBoxColumn GuncelHisseDegeri;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaliyetTutarı;
        private System.Windows.Forms.DataGridViewTextBoxColumn CariTutar;
        private System.Windows.Forms.DataGridViewTextBoxColumn KarZararMiktari;
        private System.Windows.Forms.DataGridViewTextBoxColumn KarZararYuzdesi;
    }
}
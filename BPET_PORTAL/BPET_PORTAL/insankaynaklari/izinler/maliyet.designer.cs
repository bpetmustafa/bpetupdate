namespace BPET_PORTAL.insankaynaklari.izinler
{
    partial class maliyet
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtYil = new System.Windows.Forms.TextBox();
            this.cbAy = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.nudDM = new System.Windows.Forms.NumericUpDown();
            this.nudOIM = new System.Windows.Forms.NumericUpDown();
            this.nudDO = new System.Windows.Forms.NumericUpDown();
            this.nudKG = new System.Windows.Forms.NumericUpDown();
            this.nudKACS = new System.Windows.Forms.NumericUpDown();
            this.nudBGCS = new System.Windows.Forms.NumericUpDown();
            this.nudDT = new System.Windows.Forms.NumericUpDown();
            this.nudPCS = new System.Windows.Forms.NumericUpDown();
            this.nudCG = new System.Windows.Forms.NumericUpDown();
            this.nudTCS = new System.Windows.Forms.NumericUpDown();
            this.btn_Hesapla = new System.Windows.Forms.Button();
            this.btn_guncelle = new System.Windows.Forms.Button();
            this.btn_ekle = new System.Windows.Forms.Button();
            this.cbbirim = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMaliyet = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toplam_calisan_sayisi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calisilan_gun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planlanan_calisma_saati = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.devamsizlik_toplam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birgun_calisma_saati = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kayip_aylik_calisma_saati = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kayip_gun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.devamsizlik_oran = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ortlama_aylik_isci_maliyet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.devamsizlik_maliyet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOIM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKACS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBGCS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPCS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTCS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaliyet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1141, 650);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvMaliyet);
            this.splitContainer1.Size = new System.Drawing.Size(1141, 650);
            this.splitContainer1.SplitterDistance = 403;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.txtYil);
            this.panel2.Controls.Add(this.cbAy);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.nudDM);
            this.panel2.Controls.Add(this.nudOIM);
            this.panel2.Controls.Add(this.nudDO);
            this.panel2.Controls.Add(this.nudKG);
            this.panel2.Controls.Add(this.nudKACS);
            this.panel2.Controls.Add(this.nudBGCS);
            this.panel2.Controls.Add(this.nudDT);
            this.panel2.Controls.Add(this.nudPCS);
            this.panel2.Controls.Add(this.nudCG);
            this.panel2.Controls.Add(this.nudTCS);
            this.panel2.Controls.Add(this.btn_Hesapla);
            this.panel2.Controls.Add(this.btn_guncelle);
            this.panel2.Controls.Add(this.btn_ekle);
            this.panel2.Controls.Add(this.cbbirim);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1141, 403);
            this.panel2.TabIndex = 0;
            // 
            // txtYil
            // 
            this.txtYil.Location = new System.Drawing.Point(203, 194);
            this.txtYil.Name = "txtYil";
            this.txtYil.Size = new System.Drawing.Size(121, 20);
            this.txtYil.TabIndex = 37;
            // 
            // cbAy
            // 
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
            this.cbAy.Location = new System.Drawing.Point(203, 132);
            this.cbAy.Name = "cbAy";
            this.cbAy.Size = new System.Drawing.Size(121, 21);
            this.cbAy.TabIndex = 36;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(60, 203);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 13);
            this.label13.TabIndex = 35;
            this.label13.Text = "Yıl:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(60, 140);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "Ay:";
            // 
            // nudDM
            // 
            this.nudDM.DecimalPlaces = 2;
            this.nudDM.Location = new System.Drawing.Point(974, 48);
            this.nudDM.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudDM.Name = "nudDM";
            this.nudDM.ReadOnly = true;
            this.nudDM.Size = new System.Drawing.Size(120, 20);
            this.nudDM.TabIndex = 33;
            this.nudDM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudOIM
            // 
            this.nudOIM.DecimalPlaces = 2;
            this.nudOIM.Location = new System.Drawing.Point(974, 180);
            this.nudOIM.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudOIM.Name = "nudOIM";
            this.nudOIM.Size = new System.Drawing.Size(120, 20);
            this.nudOIM.TabIndex = 32;
            this.nudOIM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudDO
            // 
            this.nudDO.DecimalPlaces = 2;
            this.nudDO.Location = new System.Drawing.Point(974, 116);
            this.nudDO.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudDO.Name = "nudDO";
            this.nudDO.ReadOnly = true;
            this.nudDO.Size = new System.Drawing.Size(120, 20);
            this.nudDO.TabIndex = 31;
            this.nudDO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudKG
            // 
            this.nudKG.DecimalPlaces = 2;
            this.nudKG.Location = new System.Drawing.Point(647, 330);
            this.nudKG.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudKG.Name = "nudKG";
            this.nudKG.ReadOnly = true;
            this.nudKG.Size = new System.Drawing.Size(120, 20);
            this.nudKG.TabIndex = 30;
            this.nudKG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudKACS
            // 
            this.nudKACS.DecimalPlaces = 2;
            this.nudKACS.Location = new System.Drawing.Point(647, 270);
            this.nudKACS.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudKACS.Name = "nudKACS";
            this.nudKACS.ReadOnly = true;
            this.nudKACS.Size = new System.Drawing.Size(120, 20);
            this.nudKACS.TabIndex = 29;
            this.nudKACS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudBGCS
            // 
            this.nudBGCS.DecimalPlaces = 2;
            this.nudBGCS.Increment = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudBGCS.Location = new System.Drawing.Point(647, 201);
            this.nudBGCS.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudBGCS.Name = "nudBGCS";
            this.nudBGCS.ReadOnly = true;
            this.nudBGCS.Size = new System.Drawing.Size(120, 20);
            this.nudBGCS.TabIndex = 28;
            this.nudBGCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudBGCS.Value = new decimal(new int[] {
            75,
            0,
            0,
            65536});
            // 
            // nudDT
            // 
            this.nudDT.DecimalPlaces = 2;
            this.nudDT.Location = new System.Drawing.Point(647, 125);
            this.nudDT.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudDT.Name = "nudDT";
            this.nudDT.Size = new System.Drawing.Size(120, 20);
            this.nudDT.TabIndex = 27;
            this.nudDT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudPCS
            // 
            this.nudPCS.DecimalPlaces = 2;
            this.nudPCS.Location = new System.Drawing.Point(647, 56);
            this.nudPCS.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudPCS.Name = "nudPCS";
            this.nudPCS.ReadOnly = true;
            this.nudPCS.Size = new System.Drawing.Size(120, 20);
            this.nudPCS.TabIndex = 26;
            this.nudPCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudCG
            // 
            this.nudCG.DecimalPlaces = 2;
            this.nudCG.Location = new System.Drawing.Point(202, 330);
            this.nudCG.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudCG.Name = "nudCG";
            this.nudCG.Size = new System.Drawing.Size(120, 20);
            this.nudCG.TabIndex = 25;
            this.nudCG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudTCS
            // 
            this.nudTCS.DecimalPlaces = 2;
            this.nudTCS.Location = new System.Drawing.Point(202, 270);
            this.nudTCS.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudTCS.Name = "nudTCS";
            this.nudTCS.Size = new System.Drawing.Size(120, 20);
            this.nudTCS.TabIndex = 24;
            this.nudTCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Hesapla
            // 
            this.btn_Hesapla.Location = new System.Drawing.Point(1017, 361);
            this.btn_Hesapla.Name = "btn_Hesapla";
            this.btn_Hesapla.Size = new System.Drawing.Size(121, 23);
            this.btn_Hesapla.TabIndex = 23;
            this.btn_Hesapla.Text = "HESAPLA";
            this.btn_Hesapla.UseVisualStyleBackColor = true;
            this.btn_Hesapla.Click += new System.EventHandler(this.btn_Hesapla_Click);
            // 
            // btn_guncelle
            // 
            this.btn_guncelle.Location = new System.Drawing.Point(784, 361);
            this.btn_guncelle.Name = "btn_guncelle";
            this.btn_guncelle.Size = new System.Drawing.Size(121, 23);
            this.btn_guncelle.TabIndex = 22;
            this.btn_guncelle.Text = "GÜNCELLE";
            this.btn_guncelle.UseVisualStyleBackColor = true;
            this.btn_guncelle.Click += new System.EventHandler(this.btn_guncelle_Click);
            // 
            // btn_ekle
            // 
            this.btn_ekle.Location = new System.Drawing.Point(899, 361);
            this.btn_ekle.Name = "btn_ekle";
            this.btn_ekle.Size = new System.Drawing.Size(121, 23);
            this.btn_ekle.TabIndex = 21;
            this.btn_ekle.Text = "EKLE";
            this.btn_ekle.UseVisualStyleBackColor = true;
            this.btn_ekle.Click += new System.EventHandler(this.btn_ekle_Click);
            // 
            // cbbirim
            // 
            this.cbbirim.FormattingEnabled = true;
            this.cbbirim.Items.AddRange(new object[] {
            "Bİlgi İşlem",
            "İnsan Kaynakları",
            "Muhasebe",
            "Satış Destek"});
            this.cbbirim.Location = new System.Drawing.Point(202, 55);
            this.cbbirim.Name = "cbbirim";
            this.cbbirim.Size = new System.Drawing.Size(121, 21);
            this.cbbirim.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(841, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Devamsizlık Maliyeti:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(841, 187);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Ortalama İşçilik Maliyeti:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(841, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Devamsızlık Oranı(%):";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(501, 332);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Kayıp Gün:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(501, 272);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Kayıp Aylık Çalışma Saati:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(505, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Bir Gün Çalışma Saati:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(505, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Devamsızlık Toplamı:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(505, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Planlanan Çalışma Saati:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 332);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Çalışılan Gün:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Toplam Çalışan Sayısı:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Birim:";
            // 
            // dgvMaliyet
            // 
            this.dgvMaliyet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaliyet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.birim,
            this.toplam_calisan_sayisi,
            this.calisilan_gun,
            this.planlanan_calisma_saati,
            this.devamsizlik_toplam,
            this.birgun_calisma_saati,
            this.kayip_aylik_calisma_saati,
            this.kayip_gun,
            this.devamsizlik_oran,
            this.ortlama_aylik_isci_maliyet,
            this.devamsizlik_maliyet});
            this.dgvMaliyet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMaliyet.Location = new System.Drawing.Point(0, 0);
            this.dgvMaliyet.Name = "dgvMaliyet";
            this.dgvMaliyet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaliyet.Size = new System.Drawing.Size(1141, 243);
            this.dgvMaliyet.TabIndex = 0;
            this.dgvMaliyet.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaliyet_CellDoubleClick);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // birim
            // 
            this.birim.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.birim.HeaderText = "Birim";
            this.birim.Name = "birim";
            // 
            // toplam_calisan_sayisi
            // 
            this.toplam_calisan_sayisi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.toplam_calisan_sayisi.HeaderText = "Toplam Çalışan Sayısı";
            this.toplam_calisan_sayisi.Name = "toplam_calisan_sayisi";
            // 
            // calisilan_gun
            // 
            this.calisilan_gun.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.calisilan_gun.HeaderText = "Çalışılan Gün";
            this.calisilan_gun.Name = "calisilan_gun";
            // 
            // planlanan_calisma_saati
            // 
            this.planlanan_calisma_saati.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.planlanan_calisma_saati.HeaderText = "Planlanan Çalışma Saati";
            this.planlanan_calisma_saati.Name = "planlanan_calisma_saati";
            // 
            // devamsizlik_toplam
            // 
            this.devamsizlik_toplam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.devamsizlik_toplam.HeaderText = "Devamsızlık Toplam";
            this.devamsizlik_toplam.Name = "devamsizlik_toplam";
            // 
            // birgun_calisma_saati
            // 
            this.birgun_calisma_saati.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.birgun_calisma_saati.HeaderText = "Bir Gün Çalışma Saati";
            this.birgun_calisma_saati.Name = "birgun_calisma_saati";
            // 
            // kayip_aylik_calisma_saati
            // 
            this.kayip_aylik_calisma_saati.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kayip_aylik_calisma_saati.HeaderText = "Kayıp Aylık Çalışma Saati";
            this.kayip_aylik_calisma_saati.Name = "kayip_aylik_calisma_saati";
            // 
            // kayip_gun
            // 
            this.kayip_gun.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kayip_gun.HeaderText = "Kayıp Gün";
            this.kayip_gun.Name = "kayip_gun";
            // 
            // devamsizlik_oran
            // 
            this.devamsizlik_oran.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.devamsizlik_oran.HeaderText = "Devamsızlık Oran";
            this.devamsizlik_oran.Name = "devamsizlik_oran";
            // 
            // ortlama_aylik_isci_maliyet
            // 
            this.ortlama_aylik_isci_maliyet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ortlama_aylik_isci_maliyet.HeaderText = "Ortalama Aylık İşçi Maliyeti";
            this.ortlama_aylik_isci_maliyet.Name = "ortlama_aylik_isci_maliyet";
            // 
            // devamsizlik_maliyet
            // 
            this.devamsizlik_maliyet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.devamsizlik_maliyet.HeaderText = "Devamsızlık Maliyeti";
            this.devamsizlik_maliyet.Name = "devamsizlik_maliyet";
            // 
            // maliyet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 650);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "maliyet";
            this.Text = "maliyet";
            this.Load += new System.EventHandler(this.maliyet_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOIM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKACS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBGCS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPCS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTCS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaliyet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Hesapla;
        private System.Windows.Forms.Button btn_guncelle;
        private System.Windows.Forms.Button btn_ekle;
        private System.Windows.Forms.ComboBox cbbirim;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvMaliyet;
        private System.Windows.Forms.NumericUpDown nudDM;
        private System.Windows.Forms.NumericUpDown nudOIM;
        private System.Windows.Forms.NumericUpDown nudDO;
        private System.Windows.Forms.NumericUpDown nudKG;
        private System.Windows.Forms.NumericUpDown nudKACS;
        private System.Windows.Forms.NumericUpDown nudBGCS;
        private System.Windows.Forms.NumericUpDown nudDT;
        private System.Windows.Forms.NumericUpDown nudPCS;
        private System.Windows.Forms.NumericUpDown nudCG;
        private System.Windows.Forms.NumericUpDown nudTCS;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn birim;
        private System.Windows.Forms.DataGridViewTextBoxColumn toplam_calisan_sayisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn calisilan_gun;
        private System.Windows.Forms.DataGridViewTextBoxColumn planlanan_calisma_saati;
        private System.Windows.Forms.DataGridViewTextBoxColumn devamsizlik_toplam;
        private System.Windows.Forms.DataGridViewTextBoxColumn birgun_calisma_saati;
        private System.Windows.Forms.DataGridViewTextBoxColumn kayip_aylik_calisma_saati;
        private System.Windows.Forms.DataGridViewTextBoxColumn kayip_gun;
        private System.Windows.Forms.DataGridViewTextBoxColumn devamsizlik_oran;
        private System.Windows.Forms.DataGridViewTextBoxColumn ortlama_aylik_isci_maliyet;
        private System.Windows.Forms.DataGridViewTextBoxColumn devamsizlik_maliyet;
        private System.Windows.Forms.TextBox txtYil;
        private System.Windows.Forms.ComboBox cbAy;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
    }
}
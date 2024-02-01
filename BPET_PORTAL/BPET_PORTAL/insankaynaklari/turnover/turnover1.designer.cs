namespace BPET_PORTAL.insankaynaklari.turnover
{
    partial class turnover1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabAylik = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvAylik = new System.Windows.Forms.DataGridView();
            this.textDonemDoldur = new System.Windows.Forms.TextBox();
            this.cbAylik = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvYillik = new System.Windows.Forms.DataGridView();
            this.btn_gosterYil = new System.Windows.Forms.Button();
            this.txtDonemYillik = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nudTurnover = new System.Windows.Forms.NumericUpDown();
            this.txtDonem = new System.Windows.Forms.MaskedTextBox();
            this.nudTahakkukKisi = new System.Windows.Forms.NumericUpDown();
            this.nudCikanKisi = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTahakkuk = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvTurnover = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tahakkuk_donem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.donem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tahakkuk_eden_kisi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cikan_kisi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turnover = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_goster = new System.Windows.Forms.Button();
            this.btn_hesapla = new System.Windows.Forms.Button();
            this.btn_guncelle = new System.Windows.Forms.Button();
            this.btn_ekle = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabAylik.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAylik)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYillik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTurnover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTahakkukKisi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCikanKisi)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnover)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1273, 680);
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
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(1273, 680);
            this.splitContainer1.SplitterDistance = 364;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.tabAylik);
            this.panel2.Controls.Add(this.nudTurnover);
            this.panel2.Controls.Add(this.txtDonem);
            this.panel2.Controls.Add(this.nudTahakkukKisi);
            this.panel2.Controls.Add(this.nudCikanKisi);
            this.panel2.Controls.Add(this.btn_hesapla);
            this.panel2.Controls.Add(this.btn_guncelle);
            this.panel2.Controls.Add(this.btn_ekle);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cbTahakkuk);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1273, 364);
            this.panel2.TabIndex = 0;
            // 
            // tabAylik
            // 
            this.tabAylik.Controls.Add(this.tabPage1);
            this.tabAylik.Controls.Add(this.tabPage2);
            this.tabAylik.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.tabAylik.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabAylik.Location = new System.Drawing.Point(579, 3);
            this.tabAylik.Name = "tabAylik";
            this.tabAylik.SelectedIndex = 0;
            this.tabAylik.Size = new System.Drawing.Size(691, 358);
            this.tabAylik.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.dgvAylik);
            this.tabPage1.Controls.Add(this.btn_goster);
            this.tabPage1.Controls.Add(this.textDonemDoldur);
            this.tabPage1.Controls.Add(this.cbAylik);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(683, 329);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "AYLIK TURNOVER";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvAylik
            // 
            this.dgvAylik.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAylik.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvAylik.Location = new System.Drawing.Point(3, 76);
            this.dgvAylik.Name = "dgvAylik";
            this.dgvAylik.Size = new System.Drawing.Size(680, 253);
            this.dgvAylik.TabIndex = 5;
            // 
            // textDonemDoldur
            // 
            this.textDonemDoldur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textDonemDoldur.Location = new System.Drawing.Point(375, 16);
            this.textDonemDoldur.Name = "textDonemDoldur";
            this.textDonemDoldur.Size = new System.Drawing.Size(110, 20);
            this.textDonemDoldur.TabIndex = 3;
            // 
            // cbAylik
            // 
            this.cbAylik.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbAylik.FormattingEnabled = true;
            this.cbAylik.Items.AddRange(new object[] {
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
            this.cbAylik.Location = new System.Drawing.Point(168, 17);
            this.cbAylik.Name = "cbAylik";
            this.cbAylik.Size = new System.Drawing.Size(121, 21);
            this.cbAylik.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(308, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Dönem;";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(26, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tahakkuk Dönemi:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.dgvYillik);
            this.tabPage2.Controls.Add(this.btn_gosterYil);
            this.tabPage2.Controls.Add(this.txtDonemYillik);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(683, 329);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "YILLIK TURNOVER";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvYillik
            // 
            this.dgvYillik.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvYillik.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvYillik.Location = new System.Drawing.Point(1, 70);
            this.dgvYillik.Name = "dgvYillik";
            this.dgvYillik.Size = new System.Drawing.Size(680, 253);
            this.dgvYillik.TabIndex = 11;
            // 
            // btn_gosterYil
            // 
            this.btn_gosterYil.Location = new System.Drawing.Point(372, 8);
            this.btn_gosterYil.Name = "btn_gosterYil";
            this.btn_gosterYil.Size = new System.Drawing.Size(30, 30);
            this.btn_gosterYil.TabIndex = 10;
            this.btn_gosterYil.UseVisualStyleBackColor = true;
            this.btn_gosterYil.Click += new System.EventHandler(this.btn_gosterYil_Click);
            // 
            // txtDonemYillik
            // 
            this.txtDonemYillik.Location = new System.Drawing.Point(151, 16);
            this.txtDonemYillik.Name = "txtDonemYillik";
            this.txtDonemYillik.Size = new System.Drawing.Size(110, 22);
            this.txtDonemYillik.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(70, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Dönem;";
            // 
            // nudTurnover
            // 
            this.nudTurnover.DecimalPlaces = 2;
            this.nudTurnover.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.nudTurnover.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudTurnover.Location = new System.Drawing.Point(298, 303);
            this.nudTurnover.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudTurnover.Name = "nudTurnover";
            this.nudTurnover.ReadOnly = true;
            this.nudTurnover.Size = new System.Drawing.Size(121, 20);
            this.nudTurnover.TabIndex = 18;
            this.nudTurnover.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDonem
            // 
            this.txtDonem.BeepOnError = true;
            this.txtDonem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDonem.Location = new System.Drawing.Point(298, 101);
            this.txtDonem.Name = "txtDonem";
            this.txtDonem.Size = new System.Drawing.Size(121, 20);
            this.txtDonem.TabIndex = 17;
            this.txtDonem.ValidatingType = typeof(int);
            // 
            // nudTahakkukKisi
            // 
            this.nudTahakkukKisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.nudTahakkukKisi.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudTahakkukKisi.Location = new System.Drawing.Point(298, 169);
            this.nudTahakkukKisi.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudTahakkukKisi.Name = "nudTahakkukKisi";
            this.nudTahakkukKisi.Size = new System.Drawing.Size(121, 20);
            this.nudTahakkukKisi.TabIndex = 16;
            this.nudTahakkukKisi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudCikanKisi
            // 
            this.nudCikanKisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.nudCikanKisi.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudCikanKisi.Location = new System.Drawing.Point(298, 238);
            this.nudCikanKisi.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudCikanKisi.Name = "nudCikanKisi";
            this.nudCikanKisi.Size = new System.Drawing.Size(121, 20);
            this.nudCikanKisi.TabIndex = 15;
            this.nudCikanKisi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(39, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Aylık Turnover Oranı:";
            // 
            // cbTahakkuk
            // 
            this.cbTahakkuk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbTahakkuk.FormattingEnabled = true;
            this.cbTahakkuk.Items.AddRange(new object[] {
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
            this.cbTahakkuk.Location = new System.Drawing.Point(298, 38);
            this.cbTahakkuk.Name = "cbTahakkuk";
            this.cbTahakkuk.Size = new System.Drawing.Size(121, 21);
            this.cbTahakkuk.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(39, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tahakkuk Eden Kişi Sayısı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(39, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(253, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ay İçinde İşten Çıkarılan Kişi Sayısı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(39, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dönem:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(39, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tahakkuk Dönemi:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.dgvTurnover);
            this.panel3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1273, 312);
            this.panel3.TabIndex = 0;
            // 
            // dgvTurnover
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTurnover.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvTurnover.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTurnover.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvTurnover.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnover.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.tahakkuk_donem,
            this.donem,
            this.tahakkuk_eden_kisi,
            this.cikan_kisi,
            this.turnover});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTurnover.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvTurnover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTurnover.Location = new System.Drawing.Point(0, 0);
            this.dgvTurnover.Name = "dgvTurnover";
            this.dgvTurnover.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTurnover.Size = new System.Drawing.Size(1273, 312);
            this.dgvTurnover.TabIndex = 0;
            this.dgvTurnover.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTurnover_CellDoubleClick);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // tahakkuk_donem
            // 
            this.tahakkuk_donem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tahakkuk_donem.HeaderText = "Tahakkuk Dönemi";
            this.tahakkuk_donem.Name = "tahakkuk_donem";
            // 
            // donem
            // 
            this.donem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.donem.HeaderText = "Dönem";
            this.donem.Name = "donem";
            // 
            // tahakkuk_eden_kisi
            // 
            this.tahakkuk_eden_kisi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tahakkuk_eden_kisi.HeaderText = "Tahakkuk Eden Kişi Sayısı";
            this.tahakkuk_eden_kisi.Name = "tahakkuk_eden_kisi";
            // 
            // cikan_kisi
            // 
            this.cikan_kisi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cikan_kisi.HeaderText = "Ay İçinde İşten Çıkan Kişi Sayısı";
            this.cikan_kisi.Name = "cikan_kisi";
            this.cikan_kisi.Width = 177;
            // 
            // turnover
            // 
            this.turnover.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.turnover.HeaderText = "Aylık Turnover Oranı";
            this.turnover.MaxInputLength = 5;
            this.turnover.Name = "turnover";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(491, 100);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.label9.Size = new System.Drawing.Size(51, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "EKLE";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(474, 213);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.label10.Size = new System.Drawing.Size(83, 16);
            this.label10.TabIndex = 21;
            this.label10.Text = "HESAPLA";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(474, 326);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.label11.Size = new System.Drawing.Size(93, 16);
            this.label11.TabIndex = 22;
            this.label11.Text = "GÜNCELLE";
            // 
            // btn_goster
            // 
            this.btn_goster.Location = new System.Drawing.Point(547, 8);
            this.btn_goster.Name = "btn_goster";
            this.btn_goster.Size = new System.Drawing.Size(30, 30);
            this.btn_goster.TabIndex = 4;
            this.btn_goster.UseVisualStyleBackColor = true;
            this.btn_goster.Click += new System.EventHandler(this.btn_goster_Click);
            // 
            // btn_hesapla
            // 
            this.btn_hesapla.Location = new System.Drawing.Point(477, 145);
            this.btn_hesapla.Name = "btn_hesapla";
            this.btn_hesapla.Size = new System.Drawing.Size(65, 65);
            this.btn_hesapla.TabIndex = 14;
            this.btn_hesapla.UseVisualStyleBackColor = true;
            this.btn_hesapla.Click += new System.EventHandler(this.btn_hesapla_Click);
            // 
            // btn_guncelle
            // 
            this.btn_guncelle.Location = new System.Drawing.Point(477, 259);
            this.btn_guncelle.Name = "btn_guncelle";
            this.btn_guncelle.Size = new System.Drawing.Size(64, 64);
            this.btn_guncelle.TabIndex = 13;
            this.btn_guncelle.UseVisualStyleBackColor = true;
            this.btn_guncelle.Click += new System.EventHandler(this.btn_guncelle_Click);
            // 
            // btn_ekle
            // 
            this.btn_ekle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_ekle.Location = new System.Drawing.Point(486, 43);
            this.btn_ekle.Name = "btn_ekle";
            this.btn_ekle.Size = new System.Drawing.Size(56, 54);
            this.btn_ekle.TabIndex = 12;
            this.btn_ekle.UseVisualStyleBackColor = true;
            this.btn_ekle.Click += new System.EventHandler(this.btn_ekle_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(531, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 16);
            this.label12.TabIndex = 6;
            this.label12.Text = "GÖSTER";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(351, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 16);
            this.label13.TabIndex = 12;
            this.label13.Text = "GÖSTER";
            // 
            // turnover1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 680);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "turnover1";
            this.Text = "turnover";
            this.Load += new System.EventHandler(this.turnover1_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabAylik.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAylik)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYillik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTurnover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTahakkukKisi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCikanKisi)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnover)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTahakkuk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_guncelle;
        private System.Windows.Forms.Button btn_ekle;
        private System.Windows.Forms.Button btn_hesapla;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvTurnover;
        private System.Windows.Forms.NumericUpDown nudTahakkukKisi;
        private System.Windows.Forms.NumericUpDown nudCikanKisi;
        private System.Windows.Forms.MaskedTextBox txtDonem;
        private System.Windows.Forms.NumericUpDown nudTurnover;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tahakkuk_donem;
        private System.Windows.Forms.DataGridViewTextBoxColumn donem;
        private System.Windows.Forms.DataGridViewTextBoxColumn tahakkuk_eden_kisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn cikan_kisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn turnover;
        private System.Windows.Forms.TabControl tabAylik;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvAylik;
        private System.Windows.Forms.Button btn_goster;
        private System.Windows.Forms.TextBox textDonemDoldur;
        private System.Windows.Forms.ComboBox cbAylik;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvYillik;
        private System.Windows.Forms.Button btn_gosterYil;
        private System.Windows.Forms.TextBox txtDonemYillik;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}
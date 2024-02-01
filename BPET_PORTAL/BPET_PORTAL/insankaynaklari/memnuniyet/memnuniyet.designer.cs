namespace BPET_PORTAL.insankaynaklari.memnuniyet
{
    partial class memnuniyet
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_detay = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cbSec = new System.Windows.Forms.ComboBox();
            this.cbGrup = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_goruntule = new System.Windows.Forms.Button();
            this.btn_guncelle = new System.Windows.Forms.Button();
            this.btn_ekle = new System.Windows.Forms.Button();
            this.btn_hesapla = new System.Windows.Forms.Button();
            this.nudSoruMemnuniyeti = new System.Windows.Forms.NumericUpDown();
            this.nudToplamCevap = new System.Windows.Forms.NumericUpDown();
            this.nudKatilm = new System.Windows.Forms.NumericUpDown();
            this.nudKararVermekZor = new System.Windows.Forms.NumericUpDown();
            this.nudKesinlikleKatilmiyorum = new System.Windows.Forms.NumericUpDown();
            this.nudKatiliyorum = new System.Windows.Forms.NumericUpDown();
            this.nudKK = new System.Windows.Forms.NumericUpDown();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.rchBasliklar = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudKatilmiyorum = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMemnuniyet = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.basliklar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tarih = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kesinlikle_katiliyorum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.katiliyorum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zor_karar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.katilmiyorum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kesinlikle_katilmiyorum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toplam_cevap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soru_memnuniyeti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoruMemnuniyeti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudToplamCevap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKatilm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKararVermekZor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKesinlikleKatilmiyorum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKatiliyorum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemnuniyet)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1314, 748);
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
            this.splitContainer1.Panel2.Controls.Add(this.dgvMemnuniyet);
            this.splitContainer1.Size = new System.Drawing.Size(1314, 748);
            this.splitContainer1.SplitterDistance = 360;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btn_detay);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.cbSec);
            this.panel2.Controls.Add(this.cbGrup);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btn_goruntule);
            this.panel2.Controls.Add(this.btn_guncelle);
            this.panel2.Controls.Add(this.btn_ekle);
            this.panel2.Controls.Add(this.btn_hesapla);
            this.panel2.Controls.Add(this.nudSoruMemnuniyeti);
            this.panel2.Controls.Add(this.nudToplamCevap);
            this.panel2.Controls.Add(this.nudKatilm);
            this.panel2.Controls.Add(this.nudKararVermekZor);
            this.panel2.Controls.Add(this.nudKesinlikleKatilmiyorum);
            this.panel2.Controls.Add(this.nudKatiliyorum);
            this.panel2.Controls.Add(this.nudKK);
            this.panel2.Controls.Add(this.dtpTarih);
            this.panel2.Controls.Add(this.rchBasliklar);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.nudKatilmiyorum);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1314, 361);
            this.panel2.TabIndex = 0;
            // 
            // btn_detay
            // 
            this.btn_detay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_detay.BackgroundImage = global::BPET_PORTAL.Properties.Resources.icons8_detail_50__1_1;
            this.btn_detay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_detay.Location = new System.Drawing.Point(1096, 280);
            this.btn_detay.MaximumSize = new System.Drawing.Size(59, 51);
            this.btn_detay.MinimumSize = new System.Drawing.Size(59, 51);
            this.btn_detay.Name = "btn_detay";
            this.btn_detay.Size = new System.Drawing.Size(59, 51);
            this.btn_detay.TabIndex = 25;
            this.btn_detay.UseVisualStyleBackColor = true;
            this.btn_detay.Click += new System.EventHandler(this.btn_detay_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(754, 259);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(283, 29);
            this.label10.TabIndex = 24;
            this.label10.Text = "Görüntülemek İstediğiniz Detayı Seçiniz:";
            // 
            // cbSec
            // 
            this.cbSec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cbSec.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbSec.FormattingEnabled = true;
            this.cbSec.Items.AddRange(new object[] {
            "KESİNLİKLE KATILIYORUM",
            "KARAR VERMEK ZOR",
            "KESİNLİKLE KATILMIYORUM"});
            this.cbSec.Location = new System.Drawing.Point(1045, 255);
            this.cbSec.MaximumSize = new System.Drawing.Size(120, 0);
            this.cbSec.MinimumSize = new System.Drawing.Size(120, 0);
            this.cbSec.Name = "cbSec";
            this.cbSec.Size = new System.Drawing.Size(120, 21);
            this.cbSec.TabIndex = 23;
            // 
            // cbGrup
            // 
            this.cbGrup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cbGrup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbGrup.FormattingEnabled = true;
            this.cbGrup.Items.AddRange(new object[] {
            "ÇALIŞMA ORTAMI",
            "ŞİRKET KÜLTÜRÜ VE İMAJI",
            "MOTİVASYON",
            "GÖREVLER, HEDEFLER, FAALİYETLER",
            "BİLGİ AKIŞI VE İLETİŞİM",
            "BAĞLI OLDUĞUM YÖNETİCİ",
            "İŞE ALMA VE YERLEŞTİRME",
            "EKİP ÇALIŞMASI",
            "ÇALIŞANLARI GELİŞTİRMEYE YÖNELİK FAALİYETLER",
            "ÜCRET, EK GELİRLER VE DİĞER İMKANLAR",
            "ANKET"});
            this.cbGrup.Location = new System.Drawing.Point(550, 272);
            this.cbGrup.MinimumSize = new System.Drawing.Size(190, 0);
            this.cbGrup.Name = "cbGrup";
            this.cbGrup.Size = new System.Drawing.Size(190, 21);
            this.cbGrup.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(415, 275);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 15);
            this.label5.TabIndex = 20;
            this.label5.Text = "Grup Seçiniz:";
            // 
            // btn_goruntule
            // 
            this.btn_goruntule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_goruntule.BackgroundImage = global::BPET_PORTAL.Properties.Resources.icons8_look_501;
            this.btn_goruntule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_goruntule.Location = new System.Drawing.Point(1091, 198);
            this.btn_goruntule.MaximumSize = new System.Drawing.Size(59, 51);
            this.btn_goruntule.MinimumSize = new System.Drawing.Size(59, 51);
            this.btn_goruntule.Name = "btn_goruntule";
            this.btn_goruntule.Size = new System.Drawing.Size(59, 51);
            this.btn_goruntule.TabIndex = 19;
            this.btn_goruntule.UseVisualStyleBackColor = true;
            this.btn_goruntule.Click += new System.EventHandler(this.btn_goruntule_Click);
            // 
            // btn_guncelle
            // 
            this.btn_guncelle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_guncelle.BackgroundImage = global::BPET_PORTAL.Properties.Resources.icons8_update_501;
            this.btn_guncelle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_guncelle.Location = new System.Drawing.Point(1091, 141);
            this.btn_guncelle.MaximumSize = new System.Drawing.Size(59, 51);
            this.btn_guncelle.MinimumSize = new System.Drawing.Size(59, 51);
            this.btn_guncelle.Name = "btn_guncelle";
            this.btn_guncelle.Size = new System.Drawing.Size(59, 51);
            this.btn_guncelle.TabIndex = 18;
            this.btn_guncelle.UseVisualStyleBackColor = true;
            this.btn_guncelle.Click += new System.EventHandler(this.btn_guncelle_Click);
            // 
            // btn_ekle
            // 
            this.btn_ekle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_ekle.BackgroundImage = global::BPET_PORTAL.Properties.Resources.icons8_add_481;
            this.btn_ekle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_ekle.Location = new System.Drawing.Point(1091, 82);
            this.btn_ekle.MaximumSize = new System.Drawing.Size(59, 51);
            this.btn_ekle.MinimumSize = new System.Drawing.Size(59, 51);
            this.btn_ekle.Name = "btn_ekle";
            this.btn_ekle.Size = new System.Drawing.Size(59, 51);
            this.btn_ekle.TabIndex = 17;
            this.btn_ekle.UseVisualStyleBackColor = true;
            this.btn_ekle.Click += new System.EventHandler(this.btn_ekle_Click);
            // 
            // btn_hesapla
            // 
            this.btn_hesapla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_hesapla.BackgroundImage = global::BPET_PORTAL.Properties.Resources.icons8_calculator_471;
            this.btn_hesapla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_hesapla.Location = new System.Drawing.Point(1091, 20);
            this.btn_hesapla.MaximumSize = new System.Drawing.Size(59, 51);
            this.btn_hesapla.MinimumSize = new System.Drawing.Size(59, 51);
            this.btn_hesapla.Name = "btn_hesapla";
            this.btn_hesapla.Size = new System.Drawing.Size(59, 51);
            this.btn_hesapla.TabIndex = 16;
            this.btn_hesapla.UseVisualStyleBackColor = true;
            this.btn_hesapla.Click += new System.EventHandler(this.btn_hesapla_Click);
            // 
            // nudSoruMemnuniyeti
            // 
            this.nudSoruMemnuniyeti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.nudSoruMemnuniyeti.DecimalPlaces = 2;
            this.nudSoruMemnuniyeti.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.nudSoruMemnuniyeti.Location = new System.Drawing.Point(903, 205);
            this.nudSoruMemnuniyeti.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudSoruMemnuniyeti.MaximumSize = new System.Drawing.Size(120, 0);
            this.nudSoruMemnuniyeti.MinimumSize = new System.Drawing.Size(120, 0);
            this.nudSoruMemnuniyeti.Name = "nudSoruMemnuniyeti";
            this.nudSoruMemnuniyeti.ReadOnly = true;
            this.nudSoruMemnuniyeti.Size = new System.Drawing.Size(120, 20);
            this.nudSoruMemnuniyeti.TabIndex = 15;
            this.nudSoruMemnuniyeti.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudToplamCevap
            // 
            this.nudToplamCevap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.nudToplamCevap.DecimalPlaces = 2;
            this.nudToplamCevap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.nudToplamCevap.Location = new System.Drawing.Point(903, 117);
            this.nudToplamCevap.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudToplamCevap.MaximumSize = new System.Drawing.Size(120, 0);
            this.nudToplamCevap.MinimumSize = new System.Drawing.Size(120, 0);
            this.nudToplamCevap.Name = "nudToplamCevap";
            this.nudToplamCevap.ReadOnly = true;
            this.nudToplamCevap.Size = new System.Drawing.Size(120, 20);
            this.nudToplamCevap.TabIndex = 14;
            this.nudToplamCevap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudKatilm
            // 
            this.nudKatilm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.nudKatilm.DecimalPlaces = 2;
            this.nudKatilm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.nudKatilm.Location = new System.Drawing.Point(550, 202);
            this.nudKatilm.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudKatilm.MaximumSize = new System.Drawing.Size(120, 0);
            this.nudKatilm.MinimumSize = new System.Drawing.Size(120, 0);
            this.nudKatilm.Name = "nudKatilm";
            this.nudKatilm.Size = new System.Drawing.Size(120, 20);
            this.nudKatilm.TabIndex = 13;
            this.nudKatilm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudKararVermekZor
            // 
            this.nudKararVermekZor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.nudKararVermekZor.DecimalPlaces = 2;
            this.nudKararVermekZor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.nudKararVermekZor.Location = new System.Drawing.Point(550, 117);
            this.nudKararVermekZor.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudKararVermekZor.MaximumSize = new System.Drawing.Size(120, 0);
            this.nudKararVermekZor.MinimumSize = new System.Drawing.Size(120, 0);
            this.nudKararVermekZor.Name = "nudKararVermekZor";
            this.nudKararVermekZor.Size = new System.Drawing.Size(120, 20);
            this.nudKararVermekZor.TabIndex = 12;
            this.nudKararVermekZor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudKesinlikleKatilmiyorum
            // 
            this.nudKesinlikleKatilmiyorum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.nudKesinlikleKatilmiyorum.DecimalPlaces = 2;
            this.nudKesinlikleKatilmiyorum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.nudKesinlikleKatilmiyorum.Location = new System.Drawing.Point(903, 39);
            this.nudKesinlikleKatilmiyorum.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudKesinlikleKatilmiyorum.MaximumSize = new System.Drawing.Size(120, 0);
            this.nudKesinlikleKatilmiyorum.MinimumSize = new System.Drawing.Size(120, 0);
            this.nudKesinlikleKatilmiyorum.Name = "nudKesinlikleKatilmiyorum";
            this.nudKesinlikleKatilmiyorum.Size = new System.Drawing.Size(120, 20);
            this.nudKesinlikleKatilmiyorum.TabIndex = 12;
            this.nudKesinlikleKatilmiyorum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudKatiliyorum
            // 
            this.nudKatiliyorum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.nudKatiliyorum.DecimalPlaces = 2;
            this.nudKatiliyorum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.nudKatiliyorum.Location = new System.Drawing.Point(550, 39);
            this.nudKatiliyorum.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudKatiliyorum.MaximumSize = new System.Drawing.Size(120, 0);
            this.nudKatiliyorum.MinimumSize = new System.Drawing.Size(120, 0);
            this.nudKatiliyorum.Name = "nudKatiliyorum";
            this.nudKatiliyorum.Size = new System.Drawing.Size(120, 20);
            this.nudKatiliyorum.TabIndex = 11;
            this.nudKatiliyorum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudKK
            // 
            this.nudKK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.nudKK.DecimalPlaces = 2;
            this.nudKK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.nudKK.Location = new System.Drawing.Point(196, 204);
            this.nudKK.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudKK.MaximumSize = new System.Drawing.Size(120, 0);
            this.nudKK.MinimumSize = new System.Drawing.Size(120, 0);
            this.nudKK.Name = "nudKK";
            this.nudKK.Size = new System.Drawing.Size(120, 20);
            this.nudKK.TabIndex = 10;
            this.nudKK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpTarih
            // 
            this.dtpTarih.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dtpTarih.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpTarih.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTarih.Location = new System.Drawing.Point(196, 112);
            this.dtpTarih.MaximumSize = new System.Drawing.Size(120, 20);
            this.dtpTarih.MinimumSize = new System.Drawing.Size(120, 20);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(120, 20);
            this.dtpTarih.TabIndex = 9;
            // 
            // rchBasliklar
            // 
            this.rchBasliklar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.rchBasliklar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rchBasliklar.Location = new System.Drawing.Point(132, 41);
            this.rchBasliklar.MaximumSize = new System.Drawing.Size(260, 50);
            this.rchBasliklar.MinimumSize = new System.Drawing.Size(260, 50);
            this.rchBasliklar.Name = "rchBasliklar";
            this.rchBasliklar.Size = new System.Drawing.Size(260, 50);
            this.rchBasliklar.TabIndex = 8;
            this.rchBasliklar.Text = "";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(727, 209);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 15);
            this.label9.TabIndex = 7;
            this.label9.Text = "Soru Memnuniyeti:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(727, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "Toplam Cevap:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(727, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "Kesinlikle Katılmıyorum:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(412, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Karar Vermek Zor:";
            // 
            // nudKatilmiyorum
            // 
            this.nudKatilmiyorum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.nudKatilmiyorum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.nudKatilmiyorum.Location = new System.Drawing.Point(412, 209);
            this.nudKatilmiyorum.Name = "nudKatilmiyorum";
            this.nudKatilmiyorum.Size = new System.Drawing.Size(99, 15);
            this.nudKatilmiyorum.TabIndex = 4;
            this.nudKatilmiyorum.Text = "Katılmıyorum:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(412, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Katılıyorum:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(31, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kesinlikle Katılıyorum:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(31, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tarih:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(31, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Başlıklar:";
            // 
            // dgvMemnuniyet
            // 
            this.dgvMemnuniyet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMemnuniyet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMemnuniyet.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMemnuniyet.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMemnuniyet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMemnuniyet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMemnuniyet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.basliklar,
            this.tarih,
            this.grup,
            this.kesinlikle_katiliyorum,
            this.katiliyorum,
            this.zor_karar,
            this.katilmiyorum,
            this.kesinlikle_katilmiyorum,
            this.toplam_cevap,
            this.soru_memnuniyeti});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMemnuniyet.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMemnuniyet.Location = new System.Drawing.Point(12, 3);
            this.dgvMemnuniyet.Name = "dgvMemnuniyet";
            this.dgvMemnuniyet.RowHeadersVisible = false;
            this.dgvMemnuniyet.RowHeadersWidth = 10;
            this.dgvMemnuniyet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMemnuniyet.Size = new System.Drawing.Size(1170, 369);
            this.dgvMemnuniyet.TabIndex = 0;
            this.dgvMemnuniyet.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMemnuniyet_CellDoubleClick);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // basliklar
            // 
            this.basliklar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.basliklar.HeaderText = "Başlıklar";
            this.basliklar.Name = "basliklar";
            // 
            // tarih
            // 
            this.tarih.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tarih.HeaderText = "Tarih";
            this.tarih.Name = "tarih";
            // 
            // grup
            // 
            this.grup.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.grup.HeaderText = "Grup";
            this.grup.Name = "grup";
            // 
            // kesinlikle_katiliyorum
            // 
            this.kesinlikle_katiliyorum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kesinlikle_katiliyorum.HeaderText = "Kesinlikle Katılıyorum";
            this.kesinlikle_katiliyorum.Name = "kesinlikle_katiliyorum";
            // 
            // katiliyorum
            // 
            this.katiliyorum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.katiliyorum.HeaderText = "Katılıyorum";
            this.katiliyorum.Name = "katiliyorum";
            // 
            // zor_karar
            // 
            this.zor_karar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.zor_karar.HeaderText = "Karar Vermek Zor";
            this.zor_karar.Name = "zor_karar";
            // 
            // katilmiyorum
            // 
            this.katilmiyorum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.katilmiyorum.HeaderText = "Katılmıyorum";
            this.katilmiyorum.Name = "katilmiyorum";
            // 
            // kesinlikle_katilmiyorum
            // 
            this.kesinlikle_katilmiyorum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kesinlikle_katilmiyorum.HeaderText = "Kesinlikle Katılmıyorum";
            this.kesinlikle_katilmiyorum.Name = "kesinlikle_katilmiyorum";
            // 
            // toplam_cevap
            // 
            this.toplam_cevap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.toplam_cevap.HeaderText = "Toplam Cevap";
            this.toplam_cevap.Name = "toplam_cevap";
            // 
            // soru_memnuniyeti
            // 
            this.soru_memnuniyeti.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.soru_memnuniyeti.HeaderText = "Soru Memnuniyeti";
            this.soru_memnuniyeti.Name = "soru_memnuniyeti";
            // 
            // memnuniyet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 751);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1319, 751);
            this.Name = "memnuniyet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "memnuniyet";
            this.Load += new System.EventHandler(this.memnuniyet_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudSoruMemnuniyeti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudToplamCevap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKatilm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKararVermekZor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKesinlikleKatilmiyorum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKatiliyorum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemnuniyet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvMemnuniyet;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_detay;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbSec;
        private System.Windows.Forms.ComboBox cbGrup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_goruntule;
        private System.Windows.Forms.Button btn_guncelle;
        private System.Windows.Forms.Button btn_ekle;
        private System.Windows.Forms.Button btn_hesapla;
        private System.Windows.Forms.NumericUpDown nudSoruMemnuniyeti;
        private System.Windows.Forms.NumericUpDown nudToplamCevap;
        private System.Windows.Forms.NumericUpDown nudKatilm;
        private System.Windows.Forms.NumericUpDown nudKararVermekZor;
        private System.Windows.Forms.NumericUpDown nudKesinlikleKatilmiyorum;
        private System.Windows.Forms.NumericUpDown nudKatiliyorum;
        private System.Windows.Forms.NumericUpDown nudKK;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.RichTextBox rchBasliklar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label nudKatilmiyorum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn basliklar;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarih;
        private System.Windows.Forms.DataGridViewTextBoxColumn grup;
        private System.Windows.Forms.DataGridViewTextBoxColumn kesinlikle_katiliyorum;
        private System.Windows.Forms.DataGridViewTextBoxColumn katiliyorum;
        private System.Windows.Forms.DataGridViewTextBoxColumn zor_karar;
        private System.Windows.Forms.DataGridViewTextBoxColumn katilmiyorum;
        private System.Windows.Forms.DataGridViewTextBoxColumn kesinlikle_katilmiyorum;
        private System.Windows.Forms.DataGridViewTextBoxColumn toplam_cevap;
        private System.Windows.Forms.DataGridViewTextBoxColumn soru_memnuniyeti;
    }
}
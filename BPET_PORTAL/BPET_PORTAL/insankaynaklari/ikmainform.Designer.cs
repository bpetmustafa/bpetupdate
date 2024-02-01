namespace BPET_PORTAL.insankaynaklari
{
    partial class ikmainform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ikmainform));
            this.mainpanel = new System.Windows.Forms.Panel();
            this.dgvGoster = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kurum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isyeri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gorevi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soyadi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ise_giris_tarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isten_cikis_tarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eXCELdenAktarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.iZİNLERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bİRİMBAZLIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kİŞİBAZLIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dEVAMSIZLIKMALİYETİToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.iŞÇİLİKMALİYETİToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bALPETToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dİĞERŞİRKETLERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eĞİTİMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eĞİTİMSAATİToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tALEPEDİLENEĞİTİMLERORANIVEKONULARIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eGİTİMLERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çALIŞANBİLGİSİToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çALIŞANLARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eĞİTİMDURUMUANALİZİVEYÜZDESİToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pERSONELLERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mEMNUNİYETANKETDURUMUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoster)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainpanel
            // 
            this.mainpanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainpanel.Controls.Add(this.dgvGoster);
            this.mainpanel.Location = new System.Drawing.Point(-1, 56);
            this.mainpanel.Margin = new System.Windows.Forms.Padding(2);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(1322, 616);
            this.mainpanel.TabIndex = 1;
            // 
            // dgvGoster
            // 
            this.dgvGoster.AllowUserToOrderColumns = true;
            this.dgvGoster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvGoster.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvGoster.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvGoster.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGoster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGoster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.kurum,
            this.isyeri,
            this.gorevi,
            this.adi,
            this.soyadi,
            this.ise_giris_tarihi,
            this.isten_cikis_tarihi});
            this.dgvGoster.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvGoster.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGoster.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGoster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGoster.Location = new System.Drawing.Point(0, 0);
            this.dgvGoster.Name = "dgvGoster";
            this.dgvGoster.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvGoster.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvGoster.RowHeadersVisible = false;
            this.dgvGoster.Size = new System.Drawing.Size(1322, 616);
            this.dgvGoster.TabIndex = 1;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            this.id.Width = 26;
            // 
            // kurum
            // 
            this.kurum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kurum.HeaderText = "Kurum";
            this.kurum.Name = "kurum";
            // 
            // isyeri
            // 
            this.isyeri.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.isyeri.HeaderText = "İşyeri";
            this.isyeri.Name = "isyeri";
            // 
            // gorevi
            // 
            this.gorevi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gorevi.HeaderText = "Görevi";
            this.gorevi.Name = "gorevi";
            // 
            // adi
            // 
            this.adi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.adi.HeaderText = "Adı";
            this.adi.Name = "adi";
            // 
            // soyadi
            // 
            this.soyadi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.soyadi.HeaderText = "Soyadı";
            this.soyadi.Name = "soyadi";
            // 
            // ise_giris_tarihi
            // 
            this.ise_giris_tarihi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ise_giris_tarihi.HeaderText = "İşe Giriş Tarihi";
            this.ise_giris_tarihi.Name = "ise_giris_tarihi";
            // 
            // isten_cikis_tarihi
            // 
            this.isten_cikis_tarihi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.isten_cikis_tarihi.HeaderText = "İşten Çıkış Tarihi";
            this.isten_cikis_tarihi.Name = "isten_cikis_tarihi";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eXCELdenAktarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(167, 26);
            // 
            // eXCELdenAktarToolStripMenuItem
            // 
            this.eXCELdenAktarToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.eXCELdenAktarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.eXCELdenAktarToolStripMenuItem.Name = "eXCELdenAktarToolStripMenuItem";
            this.eXCELdenAktarToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.eXCELdenAktarToolStripMenuItem.Text = "EXCEL\'den Aktar";
            this.eXCELdenAktarToolStripMenuItem.Click += new System.EventHandler(this.eXCELdenAktarToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1321, 52);
            this.panel2.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iŞÇİLİKMALİYETİToolStripMenuItem,
            this.eĞİTİMToolStripMenuItem,
            this.çALIŞANBİLGİSİToolStripMenuItem,
            this.mEMNUNİYETANKETDURUMUToolStripMenuItem,
            this.iZİNLERToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(258, 9);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(895, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // iZİNLERToolStripMenuItem
            // 
            this.iZİNLERToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bİRİMBAZLIToolStripMenuItem,
            this.kİŞİBAZLIToolStripMenuItem,
            this.dEVAMSIZLIKMALİYETİToolStripMenuItem});
            this.iZİNLERToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.iZİNLERToolStripMenuItem.Image = global::BPET_PORTAL.Properties.Resources.icons8_permission_64;
            this.iZİNLERToolStripMenuItem.Name = "iZİNLERToolStripMenuItem";
            this.iZİNLERToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.iZİNLERToolStripMenuItem.Text = "İZİNLER";
            this.iZİNLERToolStripMenuItem.Click += new System.EventHandler(this.iZİNLERToolStripMenuItem_Click);
            // 
            // bİRİMBAZLIToolStripMenuItem
            // 
            this.bİRİMBAZLIToolStripMenuItem.Name = "bİRİMBAZLIToolStripMenuItem";
            this.bİRİMBAZLIToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.bİRİMBAZLIToolStripMenuItem.Text = "BİRİM BAZLI";
            // 
            // kİŞİBAZLIToolStripMenuItem
            // 
            this.kİŞİBAZLIToolStripMenuItem.Name = "kİŞİBAZLIToolStripMenuItem";
            this.kİŞİBAZLIToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.kİŞİBAZLIToolStripMenuItem.Text = "KİŞİ BAZLI";
            // 
            // dEVAMSIZLIKMALİYETİToolStripMenuItem
            // 
            this.dEVAMSIZLIKMALİYETİToolStripMenuItem.Name = "dEVAMSIZLIKMALİYETİToolStripMenuItem";
            this.dEVAMSIZLIKMALİYETİToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.dEVAMSIZLIKMALİYETİToolStripMenuItem.Text = "DEVAMSIZLIK MALİYETİ";
            this.dEVAMSIZLIKMALİYETİToolStripMenuItem.Click += new System.EventHandler(this.dEVAMSIZLIKMALİYETİToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::BPET_PORTAL.Properties.Resources.icons8_hr_501;
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 51);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // iŞÇİLİKMALİYETİToolStripMenuItem
            // 
            this.iŞÇİLİKMALİYETİToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bALPETToolStripMenuItem,
            this.dİĞERŞİRKETLERToolStripMenuItem});
            this.iŞÇİLİKMALİYETİToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.iŞÇİLİKMALİYETİToolStripMenuItem.Image = global::BPET_PORTAL.Properties.Resources.icons8_worker_161;
            this.iŞÇİLİKMALİYETİToolStripMenuItem.Name = "iŞÇİLİKMALİYETİToolStripMenuItem";
            this.iŞÇİLİKMALİYETİToolStripMenuItem.Size = new System.Drawing.Size(160, 24);
            this.iŞÇİLİKMALİYETİToolStripMenuItem.Text = "İŞÇİLİK MALİYETİ";
            // 
            // bALPETToolStripMenuItem
            // 
            this.bALPETToolStripMenuItem.Image = global::BPET_PORTAL.Properties.Resources.bpet_logo;
            this.bALPETToolStripMenuItem.Name = "bALPETToolStripMenuItem";
            this.bALPETToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.bALPETToolStripMenuItem.Text = "BALPET";
            this.bALPETToolStripMenuItem.Click += new System.EventHandler(this.bALPETToolStripMenuItem_Click);
            // 
            // dİĞERŞİRKETLERToolStripMenuItem
            // 
            this.dİĞERŞİRKETLERToolStripMenuItem.Image = global::BPET_PORTAL.Properties.Resources.icons8_other_641;
            this.dİĞERŞİRKETLERToolStripMenuItem.Name = "dİĞERŞİRKETLERToolStripMenuItem";
            this.dİĞERŞİRKETLERToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.dİĞERŞİRKETLERToolStripMenuItem.Text = "DİĞER ŞİRKETLER";
            this.dİĞERŞİRKETLERToolStripMenuItem.Click += new System.EventHandler(this.dİĞERŞİRKETLERToolStripMenuItem_Click);
            // 
            // eĞİTİMToolStripMenuItem
            // 
            this.eĞİTİMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eĞİTİMSAATİToolStripMenuItem,
            this.tALEPEDİLENEĞİTİMLERORANIVEKONULARIToolStripMenuItem,
            this.eGİTİMLERToolStripMenuItem});
            this.eĞİTİMToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.eĞİTİMToolStripMenuItem.Image = global::BPET_PORTAL.Properties.Resources.icons8_education_241;
            this.eĞİTİMToolStripMenuItem.Name = "eĞİTİMToolStripMenuItem";
            this.eĞİTİMToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.eĞİTİMToolStripMenuItem.Text = "EĞİTİM";
            // 
            // eĞİTİMSAATİToolStripMenuItem
            // 
            this.eĞİTİMSAATİToolStripMenuItem.Image = global::BPET_PORTAL.Properties.Resources.icons8_time_501;
            this.eĞİTİMSAATİToolStripMenuItem.Name = "eĞİTİMSAATİToolStripMenuItem";
            this.eĞİTİMSAATİToolStripMenuItem.Size = new System.Drawing.Size(418, 22);
            this.eĞİTİMSAATİToolStripMenuItem.Text = "EĞİTİM SAATİ && GERÇEKLEŞEN EĞİTİMLER";
            this.eĞİTİMSAATİToolStripMenuItem.Click += new System.EventHandler(this.eĞİTİMSAATİToolStripMenuItem_Click);
            // 
            // tALEPEDİLENEĞİTİMLERORANIVEKONULARIToolStripMenuItem
            // 
            this.tALEPEDİLENEĞİTİMLERORANIVEKONULARIToolStripMenuItem.Image = global::BPET_PORTAL.Properties.Resources.icons8_ratio_501;
            this.tALEPEDİLENEĞİTİMLERORANIVEKONULARIToolStripMenuItem.Name = "tALEPEDİLENEĞİTİMLERORANIVEKONULARIToolStripMenuItem";
            this.tALEPEDİLENEĞİTİMLERORANIVEKONULARIToolStripMenuItem.Size = new System.Drawing.Size(418, 22);
            this.tALEPEDİLENEĞİTİMLERORANIVEKONULARIToolStripMenuItem.Text = "TALEP EDİLEN EĞİTİMLER ORANI VE KONULARI";
            this.tALEPEDİLENEĞİTİMLERORANIVEKONULARIToolStripMenuItem.Click += new System.EventHandler(this.tALEPEDİLENEĞİTİMLERORANIVEKONULARIToolStripMenuItem_Click);
            // 
            // eGİTİMLERToolStripMenuItem
            // 
            this.eGİTİMLERToolStripMenuItem.Image = global::BPET_PORTAL.Properties.Resources.icons8_education_501;
            this.eGİTİMLERToolStripMenuItem.Name = "eGİTİMLERToolStripMenuItem";
            this.eGİTİMLERToolStripMenuItem.Size = new System.Drawing.Size(418, 22);
            this.eGİTİMLERToolStripMenuItem.Text = "EGİTİMLER";
            this.eGİTİMLERToolStripMenuItem.Click += new System.EventHandler(this.eGİTİMLERToolStripMenuItem_Click);
            // 
            // çALIŞANBİLGİSİToolStripMenuItem
            // 
            this.çALIŞANBİLGİSİToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.çALIŞANLARToolStripMenuItem,
            this.eĞİTİMDURUMUANALİZİVEYÜZDESİToolStripMenuItem,
            this.pERSONELLERToolStripMenuItem});
            this.çALIŞANBİLGİSİToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.çALIŞANBİLGİSİToolStripMenuItem.Image = global::BPET_PORTAL.Properties.Resources.icons8_wi_241;
            this.çALIŞANBİLGİSİToolStripMenuItem.Name = "çALIŞANBİLGİSİToolStripMenuItem";
            this.çALIŞANBİLGİSİToolStripMenuItem.Size = new System.Drawing.Size(157, 24);
            this.çALIŞANBİLGİSİToolStripMenuItem.Text = "ÇALIŞAN BİLGİSİ";
            // 
            // çALIŞANLARToolStripMenuItem
            // 
            this.çALIŞANLARToolStripMenuItem.Image = global::BPET_PORTAL.Properties.Resources.icons8_detail_50__1_1;
            this.çALIŞANLARToolStripMenuItem.Name = "çALIŞANLARToolStripMenuItem";
            this.çALIŞANLARToolStripMenuItem.Size = new System.Drawing.Size(349, 22);
            this.çALIŞANLARToolStripMenuItem.Text = "ÇALIŞANLAR DETAY";
            this.çALIŞANLARToolStripMenuItem.Click += new System.EventHandler(this.çALIŞANLARToolStripMenuItem_Click);
            // 
            // eĞİTİMDURUMUANALİZİVEYÜZDESİToolStripMenuItem
            // 
            this.eĞİTİMDURUMUANALİZİVEYÜZDESİToolStripMenuItem.Image = global::BPET_PORTAL.Properties.Resources.icons8_analysis_501;
            this.eĞİTİMDURUMUANALİZİVEYÜZDESİToolStripMenuItem.Name = "eĞİTİMDURUMUANALİZİVEYÜZDESİToolStripMenuItem";
            this.eĞİTİMDURUMUANALİZİVEYÜZDESİToolStripMenuItem.Size = new System.Drawing.Size(349, 22);
            this.eĞİTİMDURUMUANALİZİVEYÜZDESİToolStripMenuItem.Text = "EĞİTİM DURUMU ANALİZİ VE YÜZDESİ";
            this.eĞİTİMDURUMUANALİZİVEYÜZDESİToolStripMenuItem.Click += new System.EventHandler(this.eĞİTİMDURUMUANALİZİVEYÜZDESİToolStripMenuItem_Click);
            // 
            // pERSONELLERToolStripMenuItem
            // 
            this.pERSONELLERToolStripMenuItem.Image = global::BPET_PORTAL.Properties.Resources.icons8_worker_501;
            this.pERSONELLERToolStripMenuItem.Name = "pERSONELLERToolStripMenuItem";
            this.pERSONELLERToolStripMenuItem.Size = new System.Drawing.Size(349, 22);
            this.pERSONELLERToolStripMenuItem.Text = "PERSONELLER";
            this.pERSONELLERToolStripMenuItem.Click += new System.EventHandler(this.pERSONELLERToolStripMenuItem_Click);
            // 
            // mEMNUNİYETANKETDURUMUToolStripMenuItem
            // 
            this.mEMNUNİYETANKETDURUMUToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mEMNUNİYETANKETDURUMUToolStripMenuItem.Image = global::BPET_PORTAL.Properties.Resources.icons8_satisfaction_501;
            this.mEMNUNİYETANKETDURUMUToolStripMenuItem.Name = "mEMNUNİYETANKETDURUMUToolStripMenuItem";
            this.mEMNUNİYETANKETDURUMUToolStripMenuItem.Size = new System.Drawing.Size(265, 24);
            this.mEMNUNİYETANKETDURUMUToolStripMenuItem.Text = "MEMNUNİYET ANKET DURUMU";
            this.mEMNUNİYETANKETDURUMUToolStripMenuItem.Click += new System.EventHandler(this.mEMNUNİYETANKETDURUMUToolStripMenuItem_Click);
            // 
            // ikmainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1321, 681);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.mainpanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ikmainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İNSAN KAYNAKLARI ANA SAYFA";
            this.Load += new System.EventHandler(this.ikmainform_Load);
            this.mainpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoster)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel mainpanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem iŞÇİLİKMALİYETİToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eĞİTİMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eĞİTİMSAATİToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tALEPEDİLENEĞİTİMLERORANIVEKONULARIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çALIŞANBİLGİSİToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çALIŞANLARToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eĞİTİMDURUMUANALİZİVEYÜZDESİToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mEMNUNİYETANKETDURUMUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iZİNLERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bİRİMBAZLIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kİŞİBAZLIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dEVAMSIZLIKMALİYETİToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bALPETToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dİĞERŞİRKETLERToolStripMenuItem;
        private MetroFramework.Controls.MetroProgressSpinner progressBar;
        private System.Windows.Forms.ToolStripMenuItem eGİTİMLERToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvGoster;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem eXCELdenAktarToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn kurum;
        private System.Windows.Forms.DataGridViewTextBoxColumn isyeri;
        private System.Windows.Forms.DataGridViewTextBoxColumn gorevi;
        private System.Windows.Forms.DataGridViewTextBoxColumn adi;
        private System.Windows.Forms.DataGridViewTextBoxColumn soyadi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ise_giris_tarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn isten_cikis_tarihi;
        private System.Windows.Forms.ToolStripMenuItem pERSONELLERToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
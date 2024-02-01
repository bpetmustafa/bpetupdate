namespace BPET_PORTAL.insankaynaklari.egitim
{
    partial class egitimEkle
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvegitim = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.egitim_adi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.egitim_konusu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.egitim_yili = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.katilimci_sayisi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_ara = new System.Windows.Forms.Button();
            this.btn_temizle = new System.Windows.Forms.Button();
            this.txtGerceklesenEgitimSaati = new System.Windows.Forms.TextBox();
            this.txtPlananEgitimSaati = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_guncelle = new System.Windows.Forms.Button();
            this.btn_ekle = new System.Windows.Forms.Button();
            this.txtKatilimciSayisi = new System.Windows.Forms.TextBox();
            this.txtEgitimYili = new System.Windows.Forms.TextBox();
            this.txt_egitimAdi = new System.Windows.Forms.TextBox();
            this.rtxtEgitimKonusu = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvegitim)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 720);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.dgvegitim);
            this.panel4.Location = new System.Drawing.Point(4, 254);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1273, 463);
            this.panel4.TabIndex = 2;
            // 
            // dgvegitim
            // 
            this.dgvegitim.AllowUserToDeleteRows = false;
            this.dgvegitim.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvegitim.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvegitim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvegitim.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.egitim_adi,
            this.egitim_konusu,
            this.egitim_yili,
            this.katilimci_sayisi});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvegitim.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvegitim.Location = new System.Drawing.Point(0, 0);
            this.dgvegitim.Name = "dgvegitim";
            this.dgvegitim.ReadOnly = true;
            this.dgvegitim.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvegitim.Size = new System.Drawing.Size(1273, 463);
            this.dgvegitim.TabIndex = 0;
            this.dgvegitim.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvegitim_CellDoubleClick);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // egitim_adi
            // 
            this.egitim_adi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.egitim_adi.HeaderText = "Eğitim Adı";
            this.egitim_adi.Name = "egitim_adi";
            this.egitim_adi.ReadOnly = true;
            // 
            // egitim_konusu
            // 
            this.egitim_konusu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.egitim_konusu.HeaderText = "Eğitim Konusu";
            this.egitim_konusu.Name = "egitim_konusu";
            this.egitim_konusu.ReadOnly = true;
            // 
            // egitim_yili
            // 
            this.egitim_yili.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.egitim_yili.HeaderText = "Eğitim Yılı";
            this.egitim_yili.Name = "egitim_yili";
            this.egitim_yili.ReadOnly = true;
            // 
            // katilimci_sayisi
            // 
            this.katilimci_sayisi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.katilimci_sayisi.HeaderText = "Katılımcı Sayısı";
            this.katilimci_sayisi.Name = "katilimci_sayisi";
            this.katilimci_sayisi.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1274, 71);
            this.panel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(722, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "EĞİTİM ";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btn_ara);
            this.panel2.Controls.Add(this.btn_temizle);
            this.panel2.Controls.Add(this.txtGerceklesenEgitimSaati);
            this.panel2.Controls.Add(this.txtPlananEgitimSaati);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.btn_guncelle);
            this.panel2.Controls.Add(this.btn_ekle);
            this.panel2.Controls.Add(this.txtKatilimciSayisi);
            this.panel2.Controls.Add(this.txtEgitimYili);
            this.panel2.Controls.Add(this.txt_egitimAdi);
            this.panel2.Controls.Add(this.rtxtEgitimKonusu);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1277, 176);
            this.panel2.TabIndex = 0;
            // 
            // btn_ara
            // 
            this.btn_ara.BackgroundImage = global::BPET_PORTAL.Properties.Resources.icons8_search_501;
            this.btn_ara.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_ara.Location = new System.Drawing.Point(518, 112);
            this.btn_ara.Name = "btn_ara";
            this.btn_ara.Size = new System.Drawing.Size(62, 58);
            this.btn_ara.TabIndex = 15;
            this.btn_ara.UseVisualStyleBackColor = true;
            this.btn_ara.Click += new System.EventHandler(this.btn_ara_Click);
            // 
            // btn_temizle
            // 
            this.btn_temizle.BackgroundImage = global::BPET_PORTAL.Properties.Resources.icons8_clear_501;
            this.btn_temizle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_temizle.Location = new System.Drawing.Point(603, 112);
            this.btn_temizle.Name = "btn_temizle";
            this.btn_temizle.Size = new System.Drawing.Size(61, 58);
            this.btn_temizle.TabIndex = 14;
            this.btn_temizle.UseVisualStyleBackColor = true;
            this.btn_temizle.Click += new System.EventHandler(this.btn_temizle_Click);
            // 
            // txtGerceklesenEgitimSaati
            // 
            this.txtGerceklesenEgitimSaati.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGerceklesenEgitimSaati.Location = new System.Drawing.Point(862, 82);
            this.txtGerceklesenEgitimSaati.Name = "txtGerceklesenEgitimSaati";
            this.txtGerceklesenEgitimSaati.Size = new System.Drawing.Size(100, 21);
            this.txtGerceklesenEgitimSaati.TabIndex = 13;
            // 
            // txtPlananEgitimSaati
            // 
            this.txtPlananEgitimSaati.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPlananEgitimSaati.Location = new System.Drawing.Point(862, 26);
            this.txtPlananEgitimSaati.Name = "txtPlananEgitimSaati";
            this.txtPlananEgitimSaati.Size = new System.Drawing.Size(100, 21);
            this.txtPlananEgitimSaati.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(683, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Gerçekleşen Eğitim Saati:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(683, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "Planlanan Eğitim Saati:";
            // 
            // btn_guncelle
            // 
            this.btn_guncelle.BackgroundImage = global::BPET_PORTAL.Properties.Resources.icons8_update_501;
            this.btn_guncelle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_guncelle.Location = new System.Drawing.Point(766, 113);
            this.btn_guncelle.Name = "btn_guncelle";
            this.btn_guncelle.Size = new System.Drawing.Size(57, 57);
            this.btn_guncelle.TabIndex = 9;
            this.btn_guncelle.UseVisualStyleBackColor = true;
            this.btn_guncelle.Click += new System.EventHandler(this.btn_guncelle_Click);
            // 
            // btn_ekle
            // 
            this.btn_ekle.BackgroundImage = global::BPET_PORTAL.Properties.Resources.icons8_add_481;
            this.btn_ekle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_ekle.Location = new System.Drawing.Point(686, 112);
            this.btn_ekle.Name = "btn_ekle";
            this.btn_ekle.Size = new System.Drawing.Size(55, 58);
            this.btn_ekle.TabIndex = 8;
            this.btn_ekle.UseVisualStyleBackColor = true;
            this.btn_ekle.Click += new System.EventHandler(this.btn_ekle_Click);
            // 
            // txtKatilimciSayisi
            // 
            this.txtKatilimciSayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKatilimciSayisi.Location = new System.Drawing.Point(547, 79);
            this.txtKatilimciSayisi.Name = "txtKatilimciSayisi";
            this.txtKatilimciSayisi.Size = new System.Drawing.Size(100, 21);
            this.txtKatilimciSayisi.TabIndex = 7;
            // 
            // txtEgitimYili
            // 
            this.txtEgitimYili.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEgitimYili.Location = new System.Drawing.Point(547, 23);
            this.txtEgitimYili.Name = "txtEgitimYili";
            this.txtEgitimYili.Size = new System.Drawing.Size(100, 21);
            this.txtEgitimYili.TabIndex = 6;
            // 
            // txt_egitimAdi
            // 
            this.txt_egitimAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_egitimAdi.Location = new System.Drawing.Point(130, 20);
            this.txt_egitimAdi.Name = "txt_egitimAdi";
            this.txt_egitimAdi.Size = new System.Drawing.Size(100, 21);
            this.txt_egitimAdi.TabIndex = 5;
            // 
            // rtxtEgitimKonusu
            // 
            this.rtxtEgitimKonusu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rtxtEgitimKonusu.Location = new System.Drawing.Point(130, 79);
            this.rtxtEgitimKonusu.Name = "rtxtEgitimKonusu";
            this.rtxtEgitimKonusu.Size = new System.Drawing.Size(242, 63);
            this.rtxtEgitimKonusu.TabIndex = 4;
            this.rtxtEgitimKonusu.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(431, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Katılımcı Sayısı:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(431, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Eğitim Yılı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(20, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Eğitim Konusu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(20, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Eğitim Adı:";
            // 
            // egitimEkle
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(972, 621);
            this.Name = "egitimEkle";
            this.Text = "egitimEkle";
            this.Load += new System.EventHandler(this.egitimEkle_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvegitim)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtKatilimciSayisi;
        private System.Windows.Forms.TextBox txtEgitimYili;
        private System.Windows.Forms.TextBox txt_egitimAdi;
        private System.Windows.Forms.RichTextBox rtxtEgitimKonusu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_ekle;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvegitim;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn egitim_adi;
        private System.Windows.Forms.DataGridViewTextBoxColumn egitim_konusu;
        private System.Windows.Forms.DataGridViewTextBoxColumn egitim_yili;
        private System.Windows.Forms.DataGridViewTextBoxColumn katilimci_sayisi;
        private System.Windows.Forms.Button btn_temizle;
        private System.Windows.Forms.Button btn_ara;
        private System.Windows.Forms.TextBox txtGerceklesenEgitimSaati;
        private System.Windows.Forms.TextBox txtPlananEgitimSaati;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_guncelle;
    }
}
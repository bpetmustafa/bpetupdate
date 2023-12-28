namespace BPET_PORTAL.lojistik.lojistikekranlar.yolharcirah
{
    partial class yeniharcirah
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.comboOzelKod2 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTutar = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSehirAdi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoforAdi = new System.Windows.Forms.TextBox();
            this.txtHesapKodu = new System.Windows.Forms.TextBox();
            this.kaydet = new System.Windows.Forms.Button();
            this.comboPlaka = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTarih = new MetroFramework.Controls.MetroDateTime();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(5, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 15);
            this.label4.TabIndex = 146;
            this.label4.Text = "İD Numarası (değiştirilemez)";
            // 
            // txtID
            // 
            this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtID.Location = new System.Drawing.Point(57, 27);
            this.txtID.MaximumSize = new System.Drawing.Size(73, 26);
            this.txtID.MinimumSize = new System.Drawing.Size(73, 26);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(73, 26);
            this.txtID.TabIndex = 145;
            // 
            // comboOzelKod2
            // 
            this.comboOzelKod2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.comboOzelKod2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboOzelKod2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboOzelKod2.BackColor = System.Drawing.SystemColors.Control;
            this.comboOzelKod2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.comboOzelKod2.FormattingEnabled = true;
            this.comboOzelKod2.Items.AddRange(new object[] {
            "BALPET",
            "UGURPET",
            "VICTOR"});
            this.comboOzelKod2.Location = new System.Drawing.Point(136, 281);
            this.comboOzelKod2.Margin = new System.Windows.Forms.Padding(2);
            this.comboOzelKod2.MaximumSize = new System.Drawing.Size(238, 0);
            this.comboOzelKod2.MinimumSize = new System.Drawing.Size(216, 0);
            this.comboOzelKod2.Name = "comboOzelKod2";
            this.comboOzelKod2.Size = new System.Drawing.Size(216, 32);
            this.comboOzelKod2.TabIndex = 144;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label15.Location = new System.Drawing.Point(501, 294);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(81, 24);
            this.label15.TabIndex = 138;
            this.label15.Text = "Kaydet";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(523, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 15);
            this.label13.TabIndex = 137;
            this.label13.Text = "Tutar";
            // 
            // txtTutar
            // 
            this.txtTutar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtTutar.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTutar.Location = new System.Drawing.Point(441, 143);
            this.txtTutar.MaximumSize = new System.Drawing.Size(238, 26);
            this.txtTutar.MinimumSize = new System.Drawing.Size(216, 26);
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.Size = new System.Drawing.Size(216, 26);
            this.txtTutar.TabIndex = 125;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(209, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 15);
            this.label12.TabIndex = 136;
            this.label12.Text = "Şehir Adı";
            // 
            // txtSehirAdi
            // 
            this.txtSehirAdi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtSehirAdi.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSehirAdi.Location = new System.Drawing.Point(134, 143);
            this.txtSehirAdi.MaximumSize = new System.Drawing.Size(238, 26);
            this.txtSehirAdi.MinimumSize = new System.Drawing.Size(216, 26);
            this.txtSehirAdi.Name = "txtSehirAdi";
            this.txtSehirAdi.Size = new System.Drawing.Size(216, 26);
            this.txtSehirAdi.TabIndex = 124;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(209, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 15);
            this.label6.TabIndex = 134;
            this.label6.Text = "Özel Kod";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(209, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 133;
            this.label5.Text = "Şöför Adı";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(209, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 130;
            this.label1.Text = "Hesap Kodu";
            // 
            // txtSoforAdi
            // 
            this.txtSoforAdi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtSoforAdi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSoforAdi.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSoforAdi.Location = new System.Drawing.Point(136, 186);
            this.txtSoforAdi.MaximumSize = new System.Drawing.Size(237, 26);
            this.txtSoforAdi.MinimumSize = new System.Drawing.Size(214, 26);
            this.txtSoforAdi.Name = "txtSoforAdi";
            this.txtSoforAdi.Size = new System.Drawing.Size(214, 19);
            this.txtSoforAdi.TabIndex = 123;
            // 
            // txtHesapKodu
            // 
            this.txtHesapKodu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtHesapKodu.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtHesapKodu.Location = new System.Drawing.Point(136, 233);
            this.txtHesapKodu.MaximumSize = new System.Drawing.Size(238, 26);
            this.txtHesapKodu.MinimumSize = new System.Drawing.Size(216, 26);
            this.txtHesapKodu.Name = "txtHesapKodu";
            this.txtHesapKodu.Size = new System.Drawing.Size(216, 26);
            this.txtHesapKodu.TabIndex = 122;
            // 
            // kaydet
            // 
            this.kaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.kaydet.BackColor = System.Drawing.Color.GhostWhite;
            this.kaydet.BackgroundImage = global::BPET_PORTAL.Properties.Resources.icons8_saved_80;
            this.kaydet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.kaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kaydet.FlatAppearance.BorderSize = 0;
            this.kaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kaydet.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kaydet.Location = new System.Drawing.Point(518, 242);
            this.kaydet.MaximumSize = new System.Drawing.Size(45, 49);
            this.kaydet.MinimumSize = new System.Drawing.Size(45, 49);
            this.kaydet.Name = "kaydet";
            this.kaydet.Size = new System.Drawing.Size(45, 49);
            this.kaydet.TabIndex = 129;
            this.kaydet.UseVisualStyleBackColor = false;
            this.kaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // comboPlaka
            // 
            this.comboPlaka.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.comboPlaka.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboPlaka.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboPlaka.BackColor = System.Drawing.SystemColors.Control;
            this.comboPlaka.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.comboPlaka.FormattingEnabled = true;
            this.comboPlaka.Items.AddRange(new object[] {
            "BALPET",
            "UGURPET",
            "VICTOR"});
            this.comboPlaka.Location = new System.Drawing.Point(441, 94);
            this.comboPlaka.Margin = new System.Windows.Forms.Padding(2);
            this.comboPlaka.MaximumSize = new System.Drawing.Size(238, 0);
            this.comboPlaka.MinimumSize = new System.Drawing.Size(216, 0);
            this.comboPlaka.Name = "comboPlaka";
            this.comboPlaka.Size = new System.Drawing.Size(216, 32);
            this.comboPlaka.TabIndex = 148;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(523, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 15);
            this.label7.TabIndex = 147;
            this.label7.Text = "Plaka";
            // 
            // dateTarih
            // 
            this.dateTarih.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dateTarih.CustomFormat = "\"yyyy-MM-dd\"";
            this.dateTarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTarih.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateTarih.Location = new System.Drawing.Point(134, 94);
            this.dateTarih.MaxDate = new System.DateTime(2023, 12, 31, 0, 0, 0, 0);
            this.dateTarih.MaximumSize = new System.Drawing.Size(218, 29);
            this.dateTarih.MinDate = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            this.dateTarih.MinimumSize = new System.Drawing.Size(0, 29);
            this.dateTarih.Name = "dateTarih";
            this.dateTarih.Size = new System.Drawing.Size(218, 29);
            this.dateTarih.TabIndex = 150;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(200, 79);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 149;
            this.label8.Text = "Tarih Başlangıç";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(514, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 152;
            this.label2.Text = "Açıklama";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtAciklama.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAciklama.Location = new System.Drawing.Point(441, 186);
            this.txtAciklama.MaximumSize = new System.Drawing.Size(238, 26);
            this.txtAciklama.MinimumSize = new System.Drawing.Size(216, 26);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(216, 26);
            this.txtAciklama.TabIndex = 151;
            // 
            // yeniharcirah
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(793, 371);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.dateTarih);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboPlaka);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.comboOzelKod2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtTutar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtSehirAdi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kaydet);
            this.Controls.Add(this.txtSoforAdi);
            this.Controls.Add(this.txtHesapKodu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "yeniharcirah";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni Kayıt Oluştur";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ComboBox comboOzelKod2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTutar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSehirAdi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button kaydet;
        private System.Windows.Forms.TextBox txtSoforAdi;
        private System.Windows.Forms.TextBox txtHesapKodu;
        private System.Windows.Forms.ComboBox comboPlaka;
        private System.Windows.Forms.Label label7;
        private MetroFramework.Controls.MetroDateTime dateTarih;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAciklama;
    }
}
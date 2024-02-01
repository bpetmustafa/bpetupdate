namespace BPET_PORTAL.arsiv_uygulamasi
{
    partial class KisiAtaForm
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
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxKisiler = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnkaydet = new System.Windows.Forms.Button();
            this.geri = new System.Windows.Forms.Button();
            this.epostalabel = new System.Windows.Forms.Label();
            this.uyarı = new System.Windows.Forms.Label();
            this.geciciyetki = new System.Windows.Forms.Button();
            this.dosyaidlabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Font = new System.Drawing.Font("Arial", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label12.Location = new System.Drawing.Point(254, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(260, 34);
            this.label12.TabIndex = 22;
            this.label12.Text = "Kişi Atama Ekranı";
            // 
            // comboBoxKisiler
            // 
            this.comboBoxKisiler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxKisiler.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxKisiler.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxKisiler.BackColor = System.Drawing.SystemColors.Control;
            this.comboBoxKisiler.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.comboBoxKisiler.FormattingEnabled = true;
            this.comboBoxKisiler.Location = new System.Drawing.Point(215, 119);
            this.comboBoxKisiler.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxKisiler.MaximumSize = new System.Drawing.Size(324, 0);
            this.comboBoxKisiler.Name = "comboBoxKisiler";
            this.comboBoxKisiler.Size = new System.Drawing.Size(324, 32);
            this.comboBoxKisiler.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label5.Location = new System.Drawing.Point(113, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 23);
            this.label5.TabIndex = 31;
            this.label5.Text = "Kişiler";
            // 
            // btnkaydet
            // 
            this.btnkaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnkaydet.BackColor = System.Drawing.Color.DarkGray;
            this.btnkaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnkaydet.Location = new System.Drawing.Point(309, 197);
            this.btnkaydet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnkaydet.MaximumSize = new System.Drawing.Size(92, 34);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.Size = new System.Drawing.Size(92, 34);
            this.btnkaydet.TabIndex = 35;
            this.btnkaydet.Text = "Kaydet";
            this.btnkaydet.UseVisualStyleBackColor = false;
            this.btnkaydet.Click += new System.EventHandler(this.buttonKisiAta_Click);
            // 
            // geri
            // 
            this.geri.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.geri.BackgroundImage = global::BPET_PORTAL.Properties.Resources.icons8_return_48;
            this.geri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.geri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.geri.FlatAppearance.BorderSize = 0;
            this.geri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.geri.Location = new System.Drawing.Point(699, 2);
            this.geri.MaximumSize = new System.Drawing.Size(40, 40);
            this.geri.Name = "geri";
            this.geri.Size = new System.Drawing.Size(40, 40);
            this.geri.TabIndex = 36;
            this.geri.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.geri.UseVisualStyleBackColor = true;
            this.geri.Click += new System.EventHandler(this.geri_Click);
            // 
            // epostalabel
            // 
            this.epostalabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.epostalabel.AutoSize = true;
            this.epostalabel.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.epostalabel.Location = new System.Drawing.Point(10, 7);
            this.epostalabel.Name = "epostalabel";
            this.epostalabel.Size = new System.Drawing.Size(27, 14);
            this.epostalabel.TabIndex = 37;
            this.epostalabel.Text = "-----";
            // 
            // uyarı
            // 
            this.uyarı.Cursor = System.Windows.Forms.Cursors.Default;
            this.uyarı.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uyarı.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.uyarı.Font = new System.Drawing.Font("Arial", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.uyarı.ForeColor = System.Drawing.Color.Red;
            this.uyarı.Location = new System.Drawing.Point(0, 323);
            this.uyarı.Name = "uyarı";
            this.uyarı.Size = new System.Drawing.Size(742, 76);
            this.uyarı.TabIndex = 38;
            this.uyarı.Text = "BU DOSYA BAŞKASI TARAFINDAN ALINDIĞI İÇİN İŞLEM YAPILAMIYOR!";
            this.uyarı.Visible = false;
            // 
            // geciciyetki
            // 
            this.geciciyetki.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.geciciyetki.BackColor = System.Drawing.Color.DarkGray;
            this.geciciyetki.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.geciciyetki.Location = new System.Drawing.Point(561, 112);
            this.geciciyetki.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.geciciyetki.MaximumSize = new System.Drawing.Size(125, 46);
            this.geciciyetki.Name = "geciciyetki";
            this.geciciyetki.Size = new System.Drawing.Size(125, 46);
            this.geciciyetki.TabIndex = 39;
            this.geciciyetki.Text = "Geçici Yetki Göster";
            this.geciciyetki.UseVisualStyleBackColor = false;
            this.geciciyetki.Click += new System.EventHandler(this.GeciciYetkiGosterButton_Click);
            // 
            // dosyaidlabel
            // 
            this.dosyaidlabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.dosyaidlabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.dosyaidlabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dosyaidlabel.Font = new System.Drawing.Font("Arial", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.dosyaidlabel.ForeColor = System.Drawing.Color.Red;
            this.dosyaidlabel.Location = new System.Drawing.Point(0, 0);
            this.dosyaidlabel.Name = "dosyaidlabel";
            this.dosyaidlabel.Size = new System.Drawing.Size(742, 34);
            this.dosyaidlabel.TabIndex = 40;
            this.dosyaidlabel.Text = "DOSYA İD KISMI!";
            this.dosyaidlabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // KisiAtaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(742, 399);
            this.Controls.Add(this.geciciyetki);
            this.Controls.Add(this.uyarı);
            this.Controls.Add(this.epostalabel);
            this.Controls.Add(this.geri);
            this.Controls.Add(this.btnkaydet);
            this.Controls.Add(this.comboBoxKisiler);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dosyaidlabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "KisiAtaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KisiAtaForm";
            this.Load += new System.EventHandler(this.KisiAtaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxKisiler;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnkaydet;
        private System.Windows.Forms.Button geri;
        private System.Windows.Forms.Label epostalabel;
        private System.Windows.Forms.Label uyarı;
        private System.Windows.Forms.Button geciciyetki;
        private System.Windows.Forms.Label dosyaidlabel;
    }
}
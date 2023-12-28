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
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Font = new System.Drawing.Font("Arial", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label12.Location = new System.Drawing.Point(327, 42);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(325, 31);
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
            this.comboBoxKisiler.Location = new System.Drawing.Point(325, 139);
            this.comboBoxKisiler.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxKisiler.MaximumSize = new System.Drawing.Size(404, 0);
            this.comboBoxKisiler.Name = "comboBoxKisiler";
            this.comboBoxKisiler.Size = new System.Drawing.Size(404, 37);
            this.comboBoxKisiler.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label5.Location = new System.Drawing.Point(198, 143);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 28);
            this.label5.TabIndex = 31;
            this.label5.Text = "Kişiler";
            // 
            // btnkaydet
            // 
            this.btnkaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnkaydet.BackColor = System.Drawing.Color.DarkGray;
            this.btnkaydet.Location = new System.Drawing.Point(432, 244);
            this.btnkaydet.MaximumSize = new System.Drawing.Size(115, 42);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.Size = new System.Drawing.Size(115, 42);
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
            this.geri.Location = new System.Drawing.Point(874, 3);
            this.geri.Margin = new System.Windows.Forms.Padding(4);
            this.geri.MaximumSize = new System.Drawing.Size(50, 50);
            this.geri.Name = "geri";
            this.geri.Size = new System.Drawing.Size(50, 50);
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
            this.epostalabel.Location = new System.Drawing.Point(13, 9);
            this.epostalabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.epostalabel.Name = "epostalabel";
            this.epostalabel.Size = new System.Drawing.Size(27, 16);
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
            this.uyarı.Location = new System.Drawing.Point(0, 404);
            this.uyarı.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uyarı.Name = "uyarı";
            this.uyarı.Size = new System.Drawing.Size(927, 95);
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
            this.geciciyetki.Location = new System.Drawing.Point(758, 134);
            this.geciciyetki.MaximumSize = new System.Drawing.Size(115, 42);
            this.geciciyetki.Name = "geciciyetki";
            this.geciciyetki.Size = new System.Drawing.Size(115, 42);
            this.geciciyetki.TabIndex = 39;
            this.geciciyetki.Text = "Geçici Yetki Göster";
            this.geciciyetki.UseVisualStyleBackColor = false;
            this.geciciyetki.Click += new System.EventHandler(this.GeciciYetkiGosterButton_Click);
            // 
            // KisiAtaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(927, 499);
            this.Controls.Add(this.geciciyetki);
            this.Controls.Add(this.uyarı);
            this.Controls.Add(this.epostalabel);
            this.Controls.Add(this.geri);
            this.Controls.Add(this.btnkaydet);
            this.Controls.Add(this.comboBoxKisiler);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
    }
}
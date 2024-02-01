namespace BPET_PORTAL.insankaynaklari.iscilikmaliyeti
{
    partial class digerSirketler
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_goruntule = new System.Windows.Forms.Button();
            this.cbMaliyet = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btn_goruntule);
            this.panel1.Controls.Add(this.cbMaliyet);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 211);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::BPET_PORTAL.Properties.Resources.icons8_cost_801;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(3, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 72);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btn_goruntule
            // 
            this.btn_goruntule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_goruntule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_goruntule.Location = new System.Drawing.Point(729, 97);
            this.btn_goruntule.Name = "btn_goruntule";
            this.btn_goruntule.Size = new System.Drawing.Size(122, 23);
            this.btn_goruntule.TabIndex = 5;
            this.btn_goruntule.Text = "GÖRÜNTÜLE";
            this.btn_goruntule.UseVisualStyleBackColor = true;
            this.btn_goruntule.Click += new System.EventHandler(this.btn_goruntule_Click);
            // 
            // cbMaliyet
            // 
            this.cbMaliyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cbMaliyet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaliyet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbMaliyet.FormattingEnabled = true;
            this.cbMaliyet.Items.AddRange(new object[] {
            "KONSOLİDE AYLIK İŞÇİLİK MALİYET ORANI",
            "MALİYETİN BİRİMLERE DAĞILIM ORANI",
            "YILLIK HARCIRAH MALİYETİ VE MALİYETE ORANI",
            "EN ÇOK MESAİ YAPAN BİRİM",
            "YILLIK YEMEK MALİYETİ VE TOPLAM MALİYETE ORANI",
            "MESAİ MALİYETİ VE TOPLAM MALİYETE ORANI"});
            this.cbMaliyet.Location = new System.Drawing.Point(436, 97);
            this.cbMaliyet.Name = "cbMaliyet";
            this.cbMaliyet.Size = new System.Drawing.Size(274, 23);
            this.cbMaliyet.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(432, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Görüntülemek İstediğiniz Maliyeti Seçiniz:";
            // 
            // digerSirketler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(877, 333);
            this.Name = "digerSirketler";
            this.Text = "digerSirketler";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_goruntule;
        private System.Windows.Forms.ComboBox cbMaliyet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
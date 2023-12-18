
namespace destek_otomasyonu
{
    partial class AnaEkran
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.label6 = new System.Windows.Forms.Label();
            this.txtEposta = new MetroFramework.Controls.MetroTextBox();
            this.cmbTalepTuru = new MetroFramework.Controls.MetroComboBox();
            this.cmb_oncelik = new MetroFramework.Controls.MetroComboBox();
            this.rtbAciklama = new MetroFramework.Controls.MetroTextBox();
            this.label22 = new MetroFramework.Controls.MetroLabel();
            this.progressBar = new MetroFramework.Controls.MetroProgressBar();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.label5 = new MetroFramework.Controls.MetroLabel();
            this.txtAdSoyad = new MetroFramework.Controls.MetroTextBox();
            this.sendbutton = new MetroFramework.Controls.MetroButton();
            this.dosyaekle = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(171, 567);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 12);
            this.label6.TabIndex = 15;
            // 
            // txtEposta
            // 
            this.txtEposta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            // 
            // 
            // 
            this.txtEposta.CustomButton.Image = null;
            this.txtEposta.CustomButton.Location = new System.Drawing.Point(181, 1);
            this.txtEposta.CustomButton.Name = "";
            this.txtEposta.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtEposta.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtEposta.CustomButton.TabIndex = 1;
            this.txtEposta.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtEposta.CustomButton.UseSelectable = true;
            this.txtEposta.CustomButton.Visible = false;
            this.txtEposta.Enabled = false;
            this.txtEposta.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtEposta.Lines = new string[0];
            this.txtEposta.Location = new System.Drawing.Point(286, 49);
            this.txtEposta.MaximumSize = new System.Drawing.Size(203, 23);
            this.txtEposta.MaxLength = 32767;
            this.txtEposta.Name = "txtEposta";
            this.txtEposta.PasswordChar = '\0';
            this.txtEposta.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEposta.SelectedText = "";
            this.txtEposta.SelectionLength = 0;
            this.txtEposta.SelectionStart = 0;
            this.txtEposta.ShortcutsEnabled = true;
            this.txtEposta.Size = new System.Drawing.Size(203, 23);
            this.txtEposta.TabIndex = 20;
            this.txtEposta.UseSelectable = true;
            this.txtEposta.Visible = false;
            this.txtEposta.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtEposta.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // cmbTalepTuru
            // 
            this.cmbTalepTuru.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cmbTalepTuru.FormattingEnabled = true;
            this.cmbTalepTuru.ItemHeight = 24;
            this.cmbTalepTuru.Location = new System.Drawing.Point(286, 155);
            this.cmbTalepTuru.MaximumSize = new System.Drawing.Size(203, 0);
            this.cmbTalepTuru.Name = "cmbTalepTuru";
            this.cmbTalepTuru.Size = new System.Drawing.Size(203, 30);
            this.cmbTalepTuru.TabIndex = 22;
            this.cmbTalepTuru.UseSelectable = true;
            // 
            // cmb_oncelik
            // 
            this.cmb_oncelik.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cmb_oncelik.FormattingEnabled = true;
            this.cmb_oncelik.ItemHeight = 24;
            this.cmb_oncelik.Location = new System.Drawing.Point(286, 206);
            this.cmb_oncelik.MaximumSize = new System.Drawing.Size(203, 0);
            this.cmb_oncelik.Name = "cmb_oncelik";
            this.cmb_oncelik.Size = new System.Drawing.Size(203, 30);
            this.cmb_oncelik.TabIndex = 23;
            this.cmb_oncelik.UseSelectable = true;
            // 
            // rtbAciklama
            // 
            this.rtbAciklama.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            // 
            // 
            // 
            this.rtbAciklama.CustomButton.Image = null;
            this.rtbAciklama.CustomButton.Location = new System.Drawing.Point(124, 1);
            this.rtbAciklama.CustomButton.Name = "";
            this.rtbAciklama.CustomButton.Size = new System.Drawing.Size(79, 79);
            this.rtbAciklama.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.rtbAciklama.CustomButton.TabIndex = 1;
            this.rtbAciklama.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.rtbAciklama.CustomButton.UseSelectable = true;
            this.rtbAciklama.CustomButton.Visible = false;
            this.rtbAciklama.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.rtbAciklama.Lines = new string[0];
            this.rtbAciklama.Location = new System.Drawing.Point(285, 260);
            this.rtbAciklama.MaximumSize = new System.Drawing.Size(204, 81);
            this.rtbAciklama.MaxLength = 32767;
            this.rtbAciklama.Multiline = true;
            this.rtbAciklama.Name = "rtbAciklama";
            this.rtbAciklama.PasswordChar = '\0';
            this.rtbAciklama.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.rtbAciklama.SelectedText = "";
            this.rtbAciklama.SelectionLength = 0;
            this.rtbAciklama.SelectionStart = 0;
            this.rtbAciklama.ShortcutsEnabled = true;
            this.rtbAciklama.Size = new System.Drawing.Size(204, 81);
            this.rtbAciklama.TabIndex = 24;
            this.rtbAciklama.UseSelectable = true;
            this.rtbAciklama.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.rtbAciklama.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label22.AutoSize = true;
            this.label22.FontSize = MetroFramework.MetroLabelSize.Small;
            this.label22.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.label22.Location = new System.Drawing.Point(285, 355);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(72, 17);
            this.label22.TabIndex = 25;
            this.label22.Text = "Dosya Yolu";
            this.label22.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.progressBar.Location = new System.Drawing.Point(285, 438);
            this.progressBar.MaximumSize = new System.Drawing.Size(204, 24);
            this.progressBar.MinimumSize = new System.Drawing.Size(204, 24);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(204, 24);
            this.progressBar.TabIndex = 28;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(136, 99);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(93, 25);
            this.metroLabel1.TabIndex = 30;
            this.metroLabel1.Text = "Ad Soyad";
            // 
            // metroLabel2
            // 
            this.metroLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(128, 155);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(101, 25);
            this.metroLabel2.TabIndex = 31;
            this.metroLabel2.Text = "Talep Türü";
            // 
            // metroLabel3
            // 
            this.metroLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(79, 210);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(150, 25);
            this.metroLabel3.TabIndex = 32;
            this.metroLabel3.Text = "Öncelik Durumu";
            // 
            // metroLabel4
            // 
            this.metroLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel4.Location = new System.Drawing.Point(76, 281);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(153, 25);
            this.metroLabel4.TabIndex = 33;
            this.metroLabel4.Text = "Talep Açıklaması";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label5.AutoSize = true;
            this.label5.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.label5.Location = new System.Drawing.Point(47, 394);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 20);
            this.label5.TabIndex = 34;
            this.label5.Text = "Dosya Ekle (İsteğe Bağlı)";
            // 
            // txtAdSoyad
            // 
            this.txtAdSoyad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            // 
            // 
            // 
            this.txtAdSoyad.CustomButton.Image = null;
            this.txtAdSoyad.CustomButton.Location = new System.Drawing.Point(175, 2);
            this.txtAdSoyad.CustomButton.Name = "";
            this.txtAdSoyad.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtAdSoyad.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAdSoyad.CustomButton.TabIndex = 1;
            this.txtAdSoyad.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAdSoyad.CustomButton.UseSelectable = true;
            this.txtAdSoyad.CustomButton.Visible = false;
            this.txtAdSoyad.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtAdSoyad.Lines = new string[0];
            this.txtAdSoyad.Location = new System.Drawing.Point(286, 99);
            this.txtAdSoyad.MaximumSize = new System.Drawing.Size(203, 30);
            this.txtAdSoyad.MaxLength = 32767;
            this.txtAdSoyad.Name = "txtAdSoyad";
            this.txtAdSoyad.PasswordChar = '\0';
            this.txtAdSoyad.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAdSoyad.SelectedText = "";
            this.txtAdSoyad.SelectionLength = 0;
            this.txtAdSoyad.SelectionStart = 0;
            this.txtAdSoyad.ShortcutsEnabled = true;
            this.txtAdSoyad.Size = new System.Drawing.Size(203, 30);
            this.txtAdSoyad.TabIndex = 35;
            this.txtAdSoyad.UseSelectable = true;
            this.txtAdSoyad.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAdSoyad.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // sendbutton
            // 
            this.sendbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.sendbutton.BackgroundImage = global::BPET_PORTAL.Properties.Resources.talebigonder;
            this.sendbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sendbutton.DisplayFocus = true;
            this.sendbutton.Location = new System.Drawing.Point(286, 483);
            this.sendbutton.MaximumSize = new System.Drawing.Size(204, 57);
            this.sendbutton.MinimumSize = new System.Drawing.Size(204, 57);
            this.sendbutton.Name = "sendbutton";
            this.sendbutton.Size = new System.Drawing.Size(204, 57);
            this.sendbutton.TabIndex = 29;
            this.sendbutton.UseSelectable = true;
            this.sendbutton.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // dosyaekle
            // 
            this.dosyaekle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dosyaekle.BackgroundImage = global::BPET_PORTAL.Properties.Resources.dosyasecyukle;
            this.dosyaekle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dosyaekle.Location = new System.Drawing.Point(286, 375);
            this.dosyaekle.MaximumSize = new System.Drawing.Size(204, 57);
            this.dosyaekle.MinimumSize = new System.Drawing.Size(204, 57);
            this.dosyaekle.Name = "dosyaekle";
            this.dosyaekle.Size = new System.Drawing.Size(204, 57);
            this.dosyaekle.TabIndex = 26;
            this.dosyaekle.UseSelectable = true;
            this.dosyaekle.Click += new System.EventHandler(this.dosyaekle_Click);
            // 
            // AnaEkran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(695, 588);
            this.Controls.Add(this.txtAdSoyad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.sendbutton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.dosyaekle);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.rtbAciklama);
            this.Controls.Add(this.cmb_oncelik);
            this.Controls.Add(this.cmbTalepTuru);
            this.Controls.Add(this.txtEposta);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AnaEkran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BT Yardım Masası";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private MetroFramework.Controls.MetroTextBox txtEposta;
        private MetroFramework.Controls.MetroComboBox cmbTalepTuru;
        private MetroFramework.Controls.MetroComboBox cmb_oncelik;
        private MetroFramework.Controls.MetroTextBox rtbAciklama;
        private MetroFramework.Controls.MetroLabel label22;
        private MetroFramework.Controls.MetroButton dosyaekle;
        private MetroFramework.Controls.MetroProgressBar progressBar;
        private MetroFramework.Controls.MetroButton sendbutton;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel label5;
        private MetroFramework.Controls.MetroTextBox txtAdSoyad;
    }
}


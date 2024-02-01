namespace BPET_PORTAL.sms_mfa
{
    partial class SmsMFAForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmsMFAForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.mailgonderbtn = new System.Windows.Forms.Label();
            this.btnclose = new System.Windows.Forms.Button();
            this.txtUserİnput = new System.Windows.Forms.MaskedTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnOnayla = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.mailgonderbtn);
            this.panel2.Controls.Add(this.btnclose);
            this.panel2.Controls.Add(this.txtUserİnput);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.btnOnayla);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(18, 37);
            this.panel2.MaximumSize = new System.Drawing.Size(928, 475);
            this.panel2.MinimumSize = new System.Drawing.Size(928, 475);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(928, 475);
            this.panel2.TabIndex = 3;
            // 
            // mailgonderbtn
            // 
            this.mailgonderbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.mailgonderbtn.AutoSize = true;
            this.mailgonderbtn.BackColor = System.Drawing.Color.Transparent;
            this.mailgonderbtn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mailgonderbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mailgonderbtn.Font = new System.Drawing.Font("Arial Black", 8.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mailgonderbtn.ForeColor = System.Drawing.Color.Red;
            this.mailgonderbtn.Location = new System.Drawing.Point(349, 307);
            this.mailgonderbtn.Name = "mailgonderbtn";
            this.mailgonderbtn.Size = new System.Drawing.Size(458, 17);
            this.mailgonderbtn.TabIndex = 71;
            this.mailgonderbtn.Text = "SMS gelmedi ise sistemde kayıtlı mail adresinize kod almak için tıklayınız.";
            this.mailgonderbtn.Click += new System.EventHandler(this.mailgonderbtn_Click);
            // 
            // btnclose
            // 
            this.btnclose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnclose.BackColor = System.Drawing.Color.Red;
            this.btnclose.BackgroundImage = global::BPET_PORTAL.Properties.Resources.çıkış2;
            this.btnclose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnclose.FlatAppearance.BorderSize = 0;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnclose.ForeColor = System.Drawing.Color.White;
            this.btnclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnclose.Location = new System.Drawing.Point(883, 12);
            this.btnclose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(32, 24);
            this.btnclose.TabIndex = 5;
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // txtUserİnput
            // 
            this.txtUserİnput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtUserİnput.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUserİnput.Location = new System.Drawing.Point(362, 209);
            this.txtUserİnput.Mask = "000000";
            this.txtUserİnput.Name = "txtUserİnput";
            this.txtUserİnput.PromptChar = '*';
            this.txtUserİnput.Size = new System.Drawing.Size(436, 80);
            this.txtUserİnput.TabIndex = 70;
            this.txtUserİnput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUserİnput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserİnput_KeyDown);
            this.txtUserİnput.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtUserİnput_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = global::BPET_PORTAL.Properties.Resources.phone_message__1_;
            this.pictureBox1.Location = new System.Drawing.Point(14, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(400, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(440, 20);
            this.label8.TabIndex = 69;
            this.label8.Text = "CEP TELEFONUNUZA GÖNDERİLEN KODU GİRİNİZ";
            // 
            // btnOnayla
            // 
            this.btnOnayla.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOnayla.BackgroundImage = global::BPET_PORTAL.Properties.Resources.icons8_protect_96;
            this.btnOnayla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOnayla.Location = new System.Drawing.Point(508, 363);
            this.btnOnayla.MaximumSize = new System.Drawing.Size(96, 96);
            this.btnOnayla.MinimumSize = new System.Drawing.Size(96, 96);
            this.btnOnayla.Name = "btnOnayla";
            this.btnOnayla.Size = new System.Drawing.Size(96, 96);
            this.btnOnayla.TabIndex = 67;
            this.btnOnayla.UseVisualStyleBackColor = true;
            this.btnOnayla.Click += new System.EventHandler(this.btnOnayla_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(489, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(213, 15);
            this.label7.TabIndex = 65;
            this.label7.Text = "Sistemde Kayıtlı Cep Telefonunuza Gönderilmiştir!";
            // 
            // SmsMFAForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(956, 540);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SmsMFAForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMS Doğrulama Ekranı";
            this.Load += new System.EventHandler(this.SmsMFAForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnOnayla;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox txtUserİnput;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Label mailgonderbtn;
    }
}
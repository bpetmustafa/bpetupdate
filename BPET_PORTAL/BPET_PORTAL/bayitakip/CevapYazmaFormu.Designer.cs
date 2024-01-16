namespace BPET_PORTAL.bayitakip
{
    partial class CevapYazmaFormu
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
            this.txtCevapMetni = new System.Windows.Forms.TextBox();
            this.btnCevapla = new System.Windows.Forms.Button();
            this.btnKapat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCevapMetni
            // 
            this.txtCevapMetni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtCevapMetni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCevapMetni.Location = new System.Drawing.Point(188, 141);
            this.txtCevapMetni.MinimumSize = new System.Drawing.Size(681, 186);
            this.txtCevapMetni.Multiline = true;
            this.txtCevapMetni.Name = "txtCevapMetni";
            this.txtCevapMetni.Size = new System.Drawing.Size(681, 186);
            this.txtCevapMetni.TabIndex = 0;
            this.txtCevapMetni.Text = "TEST DENEME";
            // 
            // btnCevapla
            // 
            this.btnCevapla.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCevapla.BackColor = System.Drawing.Color.Black;
            this.btnCevapla.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCevapla.ForeColor = System.Drawing.Color.Lime;
            this.btnCevapla.Location = new System.Drawing.Point(421, 387);
            this.btnCevapla.MaximumSize = new System.Drawing.Size(186, 40);
            this.btnCevapla.MinimumSize = new System.Drawing.Size(186, 40);
            this.btnCevapla.Name = "btnCevapla";
            this.btnCevapla.Size = new System.Drawing.Size(186, 40);
            this.btnCevapla.TabIndex = 1;
            this.btnCevapla.Text = "CEVAPLA";
            this.btnCevapla.UseVisualStyleBackColor = false;
            this.btnCevapla.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // btnKapat
            // 
            this.btnKapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKapat.BackColor = System.Drawing.Color.Red;
            this.btnKapat.BackgroundImage = global::BPET_PORTAL.Properties.Resources.çıkış2;
            this.btnKapat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKapat.FlatAppearance.BorderSize = 0;
            this.btnKapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKapat.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKapat.ForeColor = System.Drawing.Color.White;
            this.btnKapat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKapat.Location = new System.Drawing.Point(1022, 11);
            this.btnKapat.Margin = new System.Windows.Forms.Padding(2);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(40, 30);
            this.btnKapat.TabIndex = 5;
            this.btnKapat.UseVisualStyleBackColor = false;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(203, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(651, 69);
            this.label1.TabIndex = 6;
            this.label1.Text = "CEVAPLAMA EKRANI";
            // 
            // CevapYazmaFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1073, 527);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.btnCevapla);
            this.Controls.Add(this.txtCevapMetni);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1073, 527);
            this.MinimumSize = new System.Drawing.Size(1073, 527);
            this.Name = "CevapYazmaFormu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CevapYazmaFormu";
            this.Load += new System.EventHandler(this.CevapYazmaFormu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCevapMetni;
        private System.Windows.Forms.Button btnCevapla;
        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.Label label1;
    }
}
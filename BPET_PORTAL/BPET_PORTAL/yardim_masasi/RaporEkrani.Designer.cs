
namespace destek_otomasyonu
{
    partial class RaporEkrani
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
            this.dgvRapor = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtToplamTalepSayisi = new System.Windows.Forms.TextBox();
            this.txtBekleyentalepsayisi = new System.Windows.Forms.TextBox();
            this.txtTamamlananTalepSayisi = new System.Windows.Forms.TextBox();
            this.txtSLAihlali = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRapor)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRapor
            // 
            this.dgvRapor.AllowUserToAddRows = false;
            this.dgvRapor.AllowUserToDeleteRows = false;
            this.dgvRapor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRapor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRapor.Location = new System.Drawing.Point(12, 62);
            this.dgvRapor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvRapor.Name = "dgvRapor";
            this.dgvRapor.ReadOnly = true;
            this.dgvRapor.RowHeadersWidth = 51;
            this.dgvRapor.RowTemplate.Height = 24;
            this.dgvRapor.Size = new System.Drawing.Size(917, 261);
            this.dgvRapor.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(407, 345);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 69);
            this.button1.TabIndex = 1;
            this.button1.Text = "EXCEL\'E Aktar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Toplam";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bekleyen";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(457, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tamamlanan";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(693, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "SLA İhlali";
            // 
            // txtToplamTalepSayisi
            // 
            this.txtToplamTalepSayisi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtToplamTalepSayisi.Location = new System.Drawing.Point(124, 31);
            this.txtToplamTalepSayisi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtToplamTalepSayisi.Name = "txtToplamTalepSayisi";
            this.txtToplamTalepSayisi.ReadOnly = true;
            this.txtToplamTalepSayisi.Size = new System.Drawing.Size(61, 22);
            this.txtToplamTalepSayisi.TabIndex = 6;
            // 
            // txtBekleyentalepsayisi
            // 
            this.txtBekleyentalepsayisi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBekleyentalepsayisi.Location = new System.Drawing.Point(320, 30);
            this.txtBekleyentalepsayisi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBekleyentalepsayisi.Name = "txtBekleyentalepsayisi";
            this.txtBekleyentalepsayisi.ReadOnly = true;
            this.txtBekleyentalepsayisi.Size = new System.Drawing.Size(61, 22);
            this.txtBekleyentalepsayisi.TabIndex = 7;
            // 
            // txtTamamlananTalepSayisi
            // 
            this.txtTamamlananTalepSayisi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTamamlananTalepSayisi.Location = new System.Drawing.Point(556, 26);
            this.txtTamamlananTalepSayisi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTamamlananTalepSayisi.Name = "txtTamamlananTalepSayisi";
            this.txtTamamlananTalepSayisi.ReadOnly = true;
            this.txtTamamlananTalepSayisi.Size = new System.Drawing.Size(61, 22);
            this.txtTamamlananTalepSayisi.TabIndex = 8;
            // 
            // txtSLAihlali
            // 
            this.txtSLAihlali.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSLAihlali.Location = new System.Drawing.Point(765, 26);
            this.txtSLAihlali.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSLAihlali.Name = "txtSLAihlali";
            this.txtSLAihlali.ReadOnly = true;
            this.txtSLAihlali.Size = new System.Drawing.Size(61, 22);
            this.txtSLAihlali.TabIndex = 9;
            // 
            // RaporEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(963, 426);
            this.Controls.Add(this.txtSLAihlali);
            this.Controls.Add(this.txtTamamlananTalepSayisi);
            this.Controls.Add(this.txtBekleyentalepsayisi);
            this.Controls.Add(this.txtToplamTalepSayisi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvRapor);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RaporEkrani";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RaporEkrani";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvRapor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRapor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtToplamTalepSayisi;
        private System.Windows.Forms.TextBox txtBekleyentalepsayisi;
        private System.Windows.Forms.TextBox txtTamamlananTalepSayisi;
        private System.Windows.Forms.TextBox txtSLAihlali;
    }
}
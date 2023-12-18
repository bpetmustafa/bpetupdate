
namespace destek_otomasyonu
{
    partial class AdminPaneliForm
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
            this.dgvTalepler = new System.Windows.Forms.DataGridView();
            this.cmbSonuclandirmaDurumu = new System.Windows.Forms.ComboBox();
            this.talepKontrolTimer = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTalepler)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTalepler
            // 
            this.dgvTalepler.AllowUserToAddRows = false;
            this.dgvTalepler.AllowUserToDeleteRows = false;
            this.dgvTalepler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTalepler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTalepler.Location = new System.Drawing.Point(12, 12);
            this.dgvTalepler.Name = "dgvTalepler";
            this.dgvTalepler.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTalepler.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTalepler.RowHeadersWidth = 51;
            this.dgvTalepler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTalepler.Size = new System.Drawing.Size(946, 353);
            this.dgvTalepler.TabIndex = 0;
            this.dgvTalepler.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTalepler_CellContentClick);
            // 
            // cmbSonuclandirmaDurumu
            // 
            this.cmbSonuclandirmaDurumu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSonuclandirmaDurumu.BackColor = System.Drawing.SystemColors.HotTrack;
            this.cmbSonuclandirmaDurumu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSonuclandirmaDurumu.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cmbSonuclandirmaDurumu.FormattingEnabled = true;
            this.cmbSonuclandirmaDurumu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbSonuclandirmaDurumu.Location = new System.Drawing.Point(602, 399);
            this.cmbSonuclandirmaDurumu.MaximumSize = new System.Drawing.Size(100, 0);
            this.cmbSonuclandirmaDurumu.Name = "cmbSonuclandirmaDurumu";
            this.cmbSonuclandirmaDurumu.Size = new System.Drawing.Size(96, 21);
            this.cmbSonuclandirmaDurumu.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(294, 390);
            this.button2.MaximumSize = new System.Drawing.Size(100, 100);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 37);
            this.button2.TabIndex = 3;
            this.button2.Text = "Açıklama Göster";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnAciklamaGoster_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button3.Location = new System.Drawing.Point(719, 390);
            this.button3.MaximumSize = new System.Drawing.Size(100, 100);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 37);
            this.button3.TabIndex = 2;
            this.button3.Text = "Sonuçlandır";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.btnSonuclandir_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(16, 390);
            this.button1.MaximumSize = new System.Drawing.Size(100, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 37);
            this.button1.TabIndex = 4;
            this.button1.Text = "Raporlar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button4.Location = new System.Drawing.Point(155, 390);
            this.button4.MaximumSize = new System.Drawing.Size(100, 100);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 37);
            this.button4.TabIndex = 5;
            this.button4.Text = "Tabloyu Yenile";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button5.Location = new System.Drawing.Point(848, 390);
            this.button5.MaximumSize = new System.Drawing.Size(100, 100);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 37);
            this.button5.TabIndex = 6;
            this.button5.Text = "Talep Sil";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button6.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button6.Location = new System.Drawing.Point(410, 390);
            this.button6.MaximumSize = new System.Drawing.Size(100, 100);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 37);
            this.button6.TabIndex = 7;
            this.button6.Text = "Dosya Göster";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // AdminPaneliForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 455);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cmbSonuclandirmaDurumu);
            this.Controls.Add(this.dgvTalepler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminPaneliForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminPaneliForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminPaneliForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTalepler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTalepler;
        private System.Windows.Forms.ComboBox cmbSonuclandirmaDurumu;
        private System.Windows.Forms.Timer talepKontrolTimer;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}
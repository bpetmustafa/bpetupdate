namespace BPET_PORTAL.butce_sistemi.bayi_sistemi
{
    partial class bayianaekran
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
            this.epostalabel = new System.Windows.Forms.Label();
            this.dosya_bul = new System.Windows.Forms.Button();
            this.datagridViewBayiler = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBoxAktifBayiler = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBoxIptalBayiler = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.checkBoxLPG = new System.Windows.Forms.CheckBox();
            this.checkBoxAkaryakit = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.datagridViewBayiler)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // epostalabel
            // 
            this.epostalabel.AutoSize = true;
            this.epostalabel.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.epostalabel.Location = new System.Drawing.Point(13, 9);
            this.epostalabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.epostalabel.Name = "epostalabel";
            this.epostalabel.Size = new System.Drawing.Size(27, 16);
            this.epostalabel.TabIndex = 19;
            this.epostalabel.Text = "-----";
            this.epostalabel.Visible = false;
            // 
            // dosya_bul
            // 
            this.dosya_bul.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dosya_bul.BackgroundImage = global::BPET_PORTAL.Properties.Resources.icons8_return_48;
            this.dosya_bul.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dosya_bul.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dosya_bul.FlatAppearance.BorderSize = 0;
            this.dosya_bul.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dosya_bul.Location = new System.Drawing.Point(1259, 9);
            this.dosya_bul.Margin = new System.Windows.Forms.Padding(4);
            this.dosya_bul.MaximumSize = new System.Drawing.Size(50, 50);
            this.dosya_bul.Name = "dosya_bul";
            this.dosya_bul.Size = new System.Drawing.Size(46, 42);
            this.dosya_bul.TabIndex = 20;
            this.dosya_bul.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.dosya_bul.UseVisualStyleBackColor = true;
            this.dosya_bul.Click += new System.EventHandler(this.dosya_bul_Click);
            // 
            // datagridViewBayiler
            // 
            this.datagridViewBayiler.AllowUserToAddRows = false;
            this.datagridViewBayiler.AllowUserToDeleteRows = false;
            this.datagridViewBayiler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datagridViewBayiler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagridViewBayiler.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.datagridViewBayiler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridViewBayiler.Location = new System.Drawing.Point(13, 140);
            this.datagridViewBayiler.Name = "datagridViewBayiler";
            this.datagridViewBayiler.ReadOnly = true;
            this.datagridViewBayiler.RowHeadersWidth = 51;
            this.datagridViewBayiler.RowTemplate.Height = 24;
            this.datagridViewBayiler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridViewBayiler.Size = new System.Drawing.Size(1293, 407);
            this.datagridViewBayiler.TabIndex = 21;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(101, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 24);
            this.button1.TabIndex = 22;
            this.button1.Text = "Bayi Ekle";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 24);
            this.button2.TabIndex = 23;
            this.button2.Text = "Excel Aktif";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.exceldenVeriAktar_Click);
            // 
            // checkBoxAktifBayiler
            // 
            this.checkBoxAktifBayiler.AutoSize = true;
            this.checkBoxAktifBayiler.Checked = true;
            this.checkBoxAktifBayiler.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAktifBayiler.Location = new System.Drawing.Point(13, 29);
            this.checkBoxAktifBayiler.Name = "checkBoxAktifBayiler";
            this.checkBoxAktifBayiler.Size = new System.Drawing.Size(145, 20);
            this.checkBoxAktifBayiler.TabIndex = 24;
            this.checkBoxAktifBayiler.Text = "Aktif Bayileri Göster";
            this.checkBoxAktifBayiler.UseVisualStyleBackColor = true;
            this.checkBoxAktifBayiler.CheckedChanged += new System.EventHandler(this.checkBoxDurum_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(2, 99);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 24);
            this.button3.TabIndex = 25;
            this.button3.Text = "Excel İptal";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBoxIptalBayiler
            // 
            this.checkBoxIptalBayiler.AutoSize = true;
            this.checkBoxIptalBayiler.Checked = true;
            this.checkBoxIptalBayiler.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIptalBayiler.Location = new System.Drawing.Point(12, 55);
            this.checkBoxIptalBayiler.Name = "checkBoxIptalBayiler";
            this.checkBoxIptalBayiler.Size = new System.Drawing.Size(145, 20);
            this.checkBoxIptalBayiler.TabIndex = 26;
            this.checkBoxIptalBayiler.Text = "İptal Bayileri Göster";
            this.checkBoxIptalBayiler.UseVisualStyleBackColor = true;
            this.checkBoxIptalBayiler.CheckedChanged += new System.EventHandler(this.checkBoxDurum_CheckedChanged);
            // 
            // button4
            // 
            this.button4.AutoSize = true;
            this.button4.Location = new System.Drawing.Point(3, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(116, 26);
            this.button4.TabIndex = 27;
            this.button4.Text = "Excel Aktif LPG";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkBoxLPG
            // 
            this.checkBoxLPG.AutoSize = true;
            this.checkBoxLPG.Checked = true;
            this.checkBoxLPG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLPG.Location = new System.Drawing.Point(11, 107);
            this.checkBoxLPG.Name = "checkBoxLPG";
            this.checkBoxLPG.Size = new System.Drawing.Size(119, 20);
            this.checkBoxLPG.TabIndex = 29;
            this.checkBoxLPG.Text = "LPG\'leri Göster";
            this.checkBoxLPG.UseVisualStyleBackColor = true;
            this.checkBoxLPG.CheckedChanged += new System.EventHandler(this.checkBoxDurum_CheckedChanged);
            // 
            // checkBoxAkaryakit
            // 
            this.checkBoxAkaryakit.AutoSize = true;
            this.checkBoxAkaryakit.Checked = true;
            this.checkBoxAkaryakit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAkaryakit.Location = new System.Drawing.Point(11, 81);
            this.checkBoxAkaryakit.Name = "checkBoxAkaryakit";
            this.checkBoxAkaryakit.Size = new System.Drawing.Size(146, 20);
            this.checkBoxAkaryakit.TabIndex = 28;
            this.checkBoxAkaryakit.Text = "Akaryakıtları Göster";
            this.checkBoxAkaryakit.UseVisualStyleBackColor = true;
            this.checkBoxAkaryakit.CheckedChanged += new System.EventHandler(this.checkBoxDurum_CheckedChanged);
            // 
            // button5
            // 
            this.button5.AutoSize = true;
            this.button5.Location = new System.Drawing.Point(3, 37);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(116, 26);
            this.button5.TabIndex = 30;
            this.button5.Text = "Excel Pasif LPG";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(1055, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(197, 125);
            this.panel1.TabIndex = 31;
            this.panel1.Visible = false;
            // 
            // bayianaekran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1318, 559);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBoxLPG);
            this.Controls.Add(this.checkBoxAkaryakit);
            this.Controls.Add(this.checkBoxIptalBayiler);
            this.Controls.Add(this.checkBoxAktifBayiler);
            this.Controls.Add(this.datagridViewBayiler);
            this.Controls.Add(this.dosya_bul);
            this.Controls.Add(this.epostalabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "bayianaekran";
            this.Text = "bayianaekran";
            this.Load += new System.EventHandler(this.bayianaekran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridViewBayiler)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label epostalabel;
        private System.Windows.Forms.Button dosya_bul;
        private System.Windows.Forms.DataGridView datagridViewBayiler;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBoxAktifBayiler;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBoxIptalBayiler;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox checkBoxLPG;
        private System.Windows.Forms.CheckBox checkBoxAkaryakit;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel1;
    }
}
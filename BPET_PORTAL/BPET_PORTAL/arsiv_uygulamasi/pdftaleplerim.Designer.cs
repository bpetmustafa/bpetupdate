namespace BPET_PORTAL.arsiv_uygulamasi
{
    partial class pdftaleplerim
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.epostalabel = new System.Windows.Forms.Label();
            this.dosya_bul = new System.Windows.Forms.Button();
            this.returns = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.adminpanel = new System.Windows.Forms.Panel();
            this.comboTalepEden = new System.Windows.Forms.ComboBox();
            this.progressBar = new MetroFramework.Controls.MetroProgressSpinner();
            this.DosyaAcButonu = new System.Windows.Forms.Button();
            this.CevaplaButonu = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.adminpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // epostalabel
            // 
            this.epostalabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.epostalabel.AutoSize = true;
            this.epostalabel.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.epostalabel.Location = new System.Drawing.Point(3, 2);
            this.epostalabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.epostalabel.Name = "epostalabel";
            this.epostalabel.Size = new System.Drawing.Size(27, 16);
            this.epostalabel.TabIndex = 45;
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
            this.dosya_bul.Location = new System.Drawing.Point(1942, 3);
            this.dosya_bul.Margin = new System.Windows.Forms.Padding(4);
            this.dosya_bul.MaximumSize = new System.Drawing.Size(50, 50);
            this.dosya_bul.Name = "dosya_bul";
            this.dosya_bul.Size = new System.Drawing.Size(50, 50);
            this.dosya_bul.TabIndex = 44;
            this.dosya_bul.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.dosya_bul.UseVisualStyleBackColor = true;
            // 
            // returns
            // 
            this.returns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.returns.BackgroundImage = global::BPET_PORTAL.Properties.Resources.icons8_return_48;
            this.returns.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.returns.Cursor = System.Windows.Forms.Cursors.Hand;
            this.returns.FlatAppearance.BorderSize = 0;
            this.returns.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returns.Location = new System.Drawing.Point(1834, 3);
            this.returns.Margin = new System.Windows.Forms.Padding(4);
            this.returns.MaximumSize = new System.Drawing.Size(50, 50);
            this.returns.Name = "returns";
            this.returns.Size = new System.Drawing.Size(50, 50);
            this.returns.TabIndex = 48;
            this.returns.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.returns.UseVisualStyleBackColor = true;
            this.returns.Click += new System.EventHandler(this.returns_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.Location = new System.Drawing.Point(6, 119);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1300, 517);
            this.dataGridView.TabIndex = 60;
            // 
            // adminpanel
            // 
            this.adminpanel.Controls.Add(this.comboTalepEden);
            this.adminpanel.Controls.Add(this.progressBar);
            this.adminpanel.Controls.Add(this.DosyaAcButonu);
            this.adminpanel.Controls.Add(this.CevaplaButonu);
            this.adminpanel.Location = new System.Drawing.Point(6, 12);
            this.adminpanel.Name = "adminpanel";
            this.adminpanel.Size = new System.Drawing.Size(517, 100);
            this.adminpanel.TabIndex = 61;
            // 
            // comboTalepEden
            // 
            this.comboTalepEden.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboTalepEden.FormattingEnabled = true;
            this.comboTalepEden.Location = new System.Drawing.Point(203, 16);
            this.comboTalepEden.MaximumSize = new System.Drawing.Size(198, 0);
            this.comboTalepEden.MinimumSize = new System.Drawing.Size(198, 0);
            this.comboTalepEden.Name = "comboTalepEden";
            this.comboTalepEden.Size = new System.Drawing.Size(198, 33);
            this.comboTalepEden.TabIndex = 64;
            this.comboTalepEden.SelectedIndexChanged += new System.EventHandler(this.comboTalepEden_SelectedIndexChanged);
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.progressBar.Location = new System.Drawing.Point(407, 3);
            this.progressBar.Maximum = 100;
            this.progressBar.MaximumSize = new System.Drawing.Size(271, 275);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(107, 92);
            this.progressBar.Speed = 2F;
            this.progressBar.Style = MetroFramework.MetroColorStyle.Orange;
            this.progressBar.TabIndex = 63;
            this.progressBar.UseCustomBackColor = true;
            this.progressBar.UseSelectable = true;
            this.progressBar.Value = 90;
            this.progressBar.Visible = false;
            // 
            // DosyaAcButonu
            // 
            this.DosyaAcButonu.AutoSize = true;
            this.DosyaAcButonu.BackColor = System.Drawing.SystemColors.ControlText;
            this.DosyaAcButonu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DosyaAcButonu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.DosyaAcButonu.Location = new System.Drawing.Point(3, 56);
            this.DosyaAcButonu.Name = "DosyaAcButonu";
            this.DosyaAcButonu.Size = new System.Drawing.Size(194, 44);
            this.DosyaAcButonu.TabIndex = 1;
            this.DosyaAcButonu.Text = "DOSYAYI AÇ";
            this.DosyaAcButonu.UseVisualStyleBackColor = false;
            this.DosyaAcButonu.Click += new System.EventHandler(this.DosyaAcButonu_Click);
            // 
            // CevaplaButonu
            // 
            this.CevaplaButonu.AutoSize = true;
            this.CevaplaButonu.BackColor = System.Drawing.SystemColors.ControlText;
            this.CevaplaButonu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CevaplaButonu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CevaplaButonu.Location = new System.Drawing.Point(3, 9);
            this.CevaplaButonu.Name = "CevaplaButonu";
            this.CevaplaButonu.Size = new System.Drawing.Size(194, 44);
            this.CevaplaButonu.TabIndex = 0;
            this.CevaplaButonu.Text = "CEVAPLA";
            this.CevaplaButonu.UseVisualStyleBackColor = false;
            this.CevaplaButonu.Click += new System.EventHandler(this.CevaplaButonu_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = global::BPET_PORTAL.Properties.Resources.icons8_return_48;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(1256, 12);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.MaximumSize = new System.Drawing.Size(50, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 50);
            this.button1.TabIndex = 64;
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pdftaleplerim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1319, 649);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.adminpanel);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.returns);
            this.Controls.Add(this.dosya_bul);
            this.Controls.Add(this.epostalabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "pdftaleplerim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.pdftaleplerim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.adminpanel.ResumeLayout(false);
            this.adminpanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button dosya_bul;
        private System.Windows.Forms.Label epostalabel;
        private System.Windows.Forms.Button returns;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel adminpanel;
        private System.Windows.Forms.Button CevaplaButonu;
        private System.Windows.Forms.Button DosyaAcButonu;
        private MetroFramework.Controls.MetroProgressSpinner progressBar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboTalepEden;
    }
}
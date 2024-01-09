namespace BPET_PORTAL.lojistik.lojistikekranlar.yolharcirah
{
    partial class harcirahlistesi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(harcirahlistesi));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yENİEKLEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dÜZENLEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnYeniArac = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.driverTotalsDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnOdemeEmri = new System.Windows.Forms.Button();
            this.dateTimePickerEnd = new MetroFramework.Controls.MetroDateTime();
            this.dateTimePickerStart = new MetroFramework.Controls.MetroDateTime();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnFiltrele = new System.Windows.Forms.Button();
            this.resetle = new System.Windows.Forms.Button();
            this.labelDateRange = new System.Windows.Forms.Label();
            this.sİLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.driverTotalsDataGridView)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(6, 130);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1259, 228);
            this.dataGridView1.TabIndex = 124;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yENİEKLEToolStripMenuItem,
            this.dÜZENLEToolStripMenuItem,
            this.sİLToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(128, 70);
            // 
            // yENİEKLEToolStripMenuItem
            // 
            this.yENİEKLEToolStripMenuItem.Image = global::BPET_PORTAL.Properties.Resources.icons8_add_folder_80;
            this.yENİEKLEToolStripMenuItem.Name = "yENİEKLEToolStripMenuItem";
            this.yENİEKLEToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.yENİEKLEToolStripMenuItem.Text = "YENİ EKLE";
            this.yENİEKLEToolStripMenuItem.Click += new System.EventHandler(this.yENİEKLEToolStripMenuItem_Click);
            // 
            // dÜZENLEToolStripMenuItem
            // 
            this.dÜZENLEToolStripMenuItem.Image = global::BPET_PORTAL.Properties.Resources.icons8_edit_48;
            this.dÜZENLEToolStripMenuItem.Name = "dÜZENLEToolStripMenuItem";
            this.dÜZENLEToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.dÜZENLEToolStripMenuItem.Text = "DÜZENLE";
            this.dÜZENLEToolStripMenuItem.Click += new System.EventHandler(this.dÜZENLEToolStripMenuItem_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnUpdate.Location = new System.Drawing.Point(6, 53);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(119, 26);
            this.btnUpdate.TabIndex = 40;
            this.btnUpdate.Text = "Bilgi Sil";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnYeniArac
            // 
            this.btnYeniArac.AutoSize = true;
            this.btnYeniArac.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnYeniArac.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnYeniArac.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYeniArac.FlatAppearance.BorderSize = 0;
            this.btnYeniArac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniArac.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYeniArac.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnYeniArac.Location = new System.Drawing.Point(6, 21);
            this.btnYeniArac.Name = "btnYeniArac";
            this.btnYeniArac.Size = new System.Drawing.Size(119, 26);
            this.btnYeniArac.TabIndex = 39;
            this.btnYeniArac.Text = "Yeni Oluştur";
            this.btnYeniArac.UseVisualStyleBackColor = false;
            this.btnYeniArac.Click += new System.EventHandler(this.btnYeniArac_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.btnYeniArac);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(6, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.MinimumSize = new System.Drawing.Size(102, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(131, 114);
            this.groupBox2.TabIndex = 123;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "İşlemler";
            // 
            // driverTotalsDataGridView
            // 
            this.driverTotalsDataGridView.AllowUserToAddRows = false;
            this.driverTotalsDataGridView.AllowUserToDeleteRows = false;
            this.driverTotalsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.driverTotalsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.driverTotalsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.driverTotalsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.driverTotalsDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.driverTotalsDataGridView.Location = new System.Drawing.Point(6, 413);
            this.driverTotalsDataGridView.MultiSelect = false;
            this.driverTotalsDataGridView.Name = "driverTotalsDataGridView";
            this.driverTotalsDataGridView.ReadOnly = true;
            this.driverTotalsDataGridView.RowHeadersVisible = false;
            this.driverTotalsDataGridView.RowHeadersWidth = 51;
            this.driverTotalsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.driverTotalsDataGridView.Size = new System.Drawing.Size(1259, 155);
            this.driverTotalsDataGridView.TabIndex = 129;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Controls.Add(this.btnOdemeEmri);
            this.groupBox4.Controls.Add(this.dateTimePickerEnd);
            this.groupBox4.Controls.Add(this.dateTimePickerStart);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.btnFiltrele);
            this.groupBox4.Controls.Add(this.resetle);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox4.Location = new System.Drawing.Point(141, 11);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.MinimumSize = new System.Drawing.Size(428, 93);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(428, 104);
            this.groupBox4.TabIndex = 130;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Arama Yap";
            // 
            // btnOdemeEmri
            // 
            this.btnOdemeEmri.AutoSize = true;
            this.btnOdemeEmri.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnOdemeEmri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOdemeEmri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOdemeEmri.FlatAppearance.BorderSize = 0;
            this.btnOdemeEmri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOdemeEmri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOdemeEmri.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOdemeEmri.Location = new System.Drawing.Point(4, 69);
            this.btnOdemeEmri.MaximumSize = new System.Drawing.Size(256, 26);
            this.btnOdemeEmri.MinimumSize = new System.Drawing.Size(212, 26);
            this.btnOdemeEmri.Name = "btnOdemeEmri";
            this.btnOdemeEmri.Size = new System.Drawing.Size(244, 26);
            this.btnOdemeEmri.TabIndex = 40;
            this.btnOdemeEmri.Text = "Finans\'a Aylık Ödeme Emri Gönder!";
            this.btnOdemeEmri.UseVisualStyleBackColor = false;
            this.btnOdemeEmri.Click += new System.EventHandler(this.btnOdemeEmri_Click);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.CustomFormat = "\"yyyy-MM-dd\"";
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerEnd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(125, 34);
            this.dateTimePickerEnd.MaxDate = new System.DateTime(2025, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerEnd.MaximumSize = new System.Drawing.Size(213, 30);
            this.dateTimePickerEnd.MinDate = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerEnd.MinimumSize = new System.Drawing.Size(0, 29);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(123, 29);
            this.dateTimePickerEnd.TabIndex = 68;
            this.dateTimePickerEnd.Value = new System.DateTime(2023, 12, 31, 0, 0, 0, 0);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.CustomFormat = "\"yyyy-MM-dd\"";
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateTimePickerStart.Location = new System.Drawing.Point(5, 34);
            this.dateTimePickerStart.MaxDate = new System.DateTime(2025, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerStart.MaximumSize = new System.Drawing.Size(213, 30);
            this.dateTimePickerStart.MinDate = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerStart.MinimumSize = new System.Drawing.Size(0, 29);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(114, 29);
            this.dateTimePickerStart.TabIndex = 67;
            this.dateTimePickerStart.Value = new System.DateTime(2023, 12, 31, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(143, 18);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 50;
            this.label7.Text = "Tarih Bitiş";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(15, 20);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 48;
            this.label8.Text = "Tarih Başlangıç";
            // 
            // btnFiltrele
            // 
            this.btnFiltrele.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFiltrele.AutoSize = true;
            this.btnFiltrele.BackColor = System.Drawing.SystemColors.Control;
            this.btnFiltrele.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFiltrele.BackgroundImage")));
            this.btnFiltrele.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFiltrele.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrele.FlatAppearance.BorderSize = 0;
            this.btnFiltrele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrele.Location = new System.Drawing.Point(254, 28);
            this.btnFiltrele.MaximumSize = new System.Drawing.Size(33, 37);
            this.btnFiltrele.Name = "btnFiltrele";
            this.btnFiltrele.Size = new System.Drawing.Size(33, 37);
            this.btnFiltrele.TabIndex = 46;
            this.btnFiltrele.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFiltrele.UseVisualStyleBackColor = false;
            this.btnFiltrele.Click += new System.EventHandler(this.btnFiltrele_Click);
            // 
            // resetle
            // 
            this.resetle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resetle.AutoSize = true;
            this.resetle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.resetle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resetle.BackgroundImage")));
            this.resetle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.resetle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resetle.FlatAppearance.BorderSize = 0;
            this.resetle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetle.Location = new System.Drawing.Point(293, 28);
            this.resetle.MaximumSize = new System.Drawing.Size(33, 37);
            this.resetle.Name = "resetle";
            this.resetle.Size = new System.Drawing.Size(33, 37);
            this.resetle.TabIndex = 33;
            this.resetle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.resetle.UseVisualStyleBackColor = false;
            this.resetle.Click += new System.EventHandler(this.resetle_Click);
            // 
            // labelDateRange
            // 
            this.labelDateRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelDateRange.AutoSize = true;
            this.labelDateRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelDateRange.Location = new System.Drawing.Point(489, 370);
            this.labelDateRange.Name = "labelDateRange";
            this.labelDateRange.Size = new System.Drawing.Size(223, 31);
            this.labelDateRange.TabIndex = 131;
            this.labelDateRange.Text = "labelDateRange";
            // 
            // sİLToolStripMenuItem
            // 
            this.sİLToolStripMenuItem.Image = global::BPET_PORTAL.Properties.Resources.icons8_delete_48;
            this.sİLToolStripMenuItem.Name = "sİLToolStripMenuItem";
            this.sİLToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.sİLToolStripMenuItem.Text = "SİL";
            this.sİLToolStripMenuItem.Click += new System.EventHandler(this.sİLToolStripMenuItem_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDelete.Location = new System.Drawing.Point(6, 83);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(119, 26);
            this.btnDelete.TabIndex = 41;
            this.btnDelete.Text = "Şeçili Veriyi Sİl";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // harcirahlistesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1283, 580);
            this.Controls.Add(this.labelDateRange);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.driverTotalsDataGridView);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "harcirahlistesi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.driverTotalsDataGridView)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnYeniArac;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView driverTotalsDataGridView;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnOdemeEmri;
        private MetroFramework.Controls.MetroDateTime dateTimePickerEnd;
        private MetroFramework.Controls.MetroDateTime dateTimePickerStart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnFiltrele;
        private System.Windows.Forms.Button resetle;
        private System.Windows.Forms.Label labelDateRange;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dÜZENLEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yENİEKLEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sİLToolStripMenuItem;
        private System.Windows.Forms.Button btnDelete;
    }
}
namespace BPET_PORTAL.victorreklam
{
    partial class victorreklamform
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
            this.s = new MetroFramework.Controls.MetroProgressSpinner();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panelheader = new System.Windows.Forms.Panel();
            this.dosyasil = new System.Windows.Forms.Button();
            this.dosyayukle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panelheader.SuspendLayout();
            this.SuspendLayout();
            // 
            // epostalabel
            // 
            this.epostalabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.epostalabel.AutoSize = true;
            this.epostalabel.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.epostalabel.Location = new System.Drawing.Point(13, 31);
            this.epostalabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.epostalabel.Name = "epostalabel";
            this.epostalabel.Size = new System.Drawing.Size(27, 16);
            this.epostalabel.TabIndex = 58;
            this.epostalabel.Text = "-----";
            // 
            // s
            // 
            this.s.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.s.BackColor = System.Drawing.Color.DarkGray;
            this.s.Location = new System.Drawing.Point(503, 282);
            this.s.Maximum = 100;
            this.s.MaximumSize = new System.Drawing.Size(271, 275);
            this.s.Name = "s";
            this.s.Size = new System.Drawing.Size(271, 275);
            this.s.Speed = 2F;
            this.s.Style = MetroFramework.MetroColorStyle.Orange;
            this.s.TabIndex = 62;
            this.s.UseSelectable = true;
            this.s.UseStyleColors = true;
            this.s.Value = 90;
            this.s.Visible = false;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 82);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1251, 625);
            this.dataGridView.TabIndex = 63;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // panelheader
            // 
            this.panelheader.BackColor = System.Drawing.Color.Coral;
            this.panelheader.Controls.Add(this.dosyasil);
            this.panelheader.Controls.Add(this.epostalabel);
            this.panelheader.Controls.Add(this.dosyayukle);
            this.panelheader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelheader.Location = new System.Drawing.Point(0, 0);
            this.panelheader.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelheader.Name = "panelheader";
            this.panelheader.Size = new System.Drawing.Size(1251, 77);
            this.panelheader.TabIndex = 65;
            // 
            // dosyasil
            // 
            this.dosyasil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dosyasil.BackgroundImage = global::BPET_PORTAL.Properties.Resources.icons8_delete_file_64;
            this.dosyasil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dosyasil.Location = new System.Drawing.Point(1144, 3);
            this.dosyasil.Name = "dosyasil";
            this.dosyasil.Size = new System.Drawing.Size(95, 66);
            this.dosyasil.TabIndex = 60;
            this.dosyasil.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.dosyasil.UseVisualStyleBackColor = true;
            this.dosyasil.Click += new System.EventHandler(this.silButton_Click);
            // 
            // dosyayukle
            // 
            this.dosyayukle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dosyayukle.BackgroundImage = global::BPET_PORTAL.Properties.Resources.icons8_upload_to_ftp_96;
            this.dosyayukle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dosyayukle.Location = new System.Drawing.Point(1031, 3);
            this.dosyayukle.Name = "dosyayukle";
            this.dosyayukle.Size = new System.Drawing.Size(95, 66);
            this.dosyayukle.TabIndex = 59;
            this.dosyayukle.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.dosyayukle.UseVisualStyleBackColor = true;
            this.dosyayukle.Click += new System.EventHandler(this.DosyaYukleButton_Click);
            // 
            // victorreklamform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1251, 708);
            this.Controls.Add(this.s);
            this.Controls.Add(this.panelheader);
            this.Controls.Add(this.dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "victorreklamform";
            this.Text = "victorreklam";
            this.Load += new System.EventHandler(this.victorreklamform_Load);
            this.Shown += new System.EventHandler(this.victorreklamform_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panelheader.ResumeLayout(false);
            this.panelheader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label epostalabel;
        private MetroFramework.Controls.MetroProgressSpinner s;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel panelheader;
        private System.Windows.Forms.Button dosyasil;
        private System.Windows.Forms.Button dosyayukle;
    }
}
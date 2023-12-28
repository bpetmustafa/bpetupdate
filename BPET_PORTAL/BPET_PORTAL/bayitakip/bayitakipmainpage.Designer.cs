namespace BPET_PORTAL.bayitakip
{
    partial class bayitakipmainpage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bayitakipmainpage));
            this.epostalabel = new System.Windows.Forms.Label();
            this.panelheader = new System.Windows.Forms.Panel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.bolgeMuduruComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.excelyukle = new MetroFramework.Controls.MetroButton();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.progressBar = new MetroFramework.Controls.MetroProgressSpinner();
            this.panelheader.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // epostalabel
            // 
            this.epostalabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.epostalabel.AutoSize = true;
            this.epostalabel.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.epostalabel.Location = new System.Drawing.Point(4, 9);
            this.epostalabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.epostalabel.Name = "epostalabel";
            this.epostalabel.Size = new System.Drawing.Size(27, 16);
            this.epostalabel.TabIndex = 58;
            this.epostalabel.Text = "-----";
            this.epostalabel.Visible = false;
            // 
            // panelheader
            // 
            this.panelheader.BackColor = System.Drawing.Color.Coral;
            this.panelheader.Controls.Add(this.metroPanel1);
            this.panelheader.Controls.Add(this.excelyukle);
            this.panelheader.Controls.Add(this.epostalabel);
            this.panelheader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelheader.Location = new System.Drawing.Point(0, 0);
            this.panelheader.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelheader.Name = "panelheader";
            this.panelheader.Size = new System.Drawing.Size(1251, 77);
            this.panelheader.TabIndex = 68;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.metroPanel1.Controls.Add(this.metroButton1);
            this.metroPanel1.Controls.Add(this.metroButton2);
            this.metroPanel1.Controls.Add(this.bolgeMuduruComboBox);
            this.metroPanel1.Controls.Add(this.label1);
            this.metroPanel1.Controls.Add(this.label2);
            this.metroPanel1.Controls.Add(this.numericUpDown1);
            this.metroPanel1.Controls.Add(this.label3);
            this.metroPanel1.Controls.Add(this.numericUpDown);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(136, 2);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(721, 74);
            this.metroPanel1.TabIndex = 62;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroButton1
            // 
            this.metroButton1.AutoSize = true;
            this.metroButton1.BackColor = System.Drawing.Color.OrangeRed;
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton1.ForeColor = System.Drawing.SystemColors.Control;
            this.metroButton1.Location = new System.Drawing.Point(569, 39);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(114, 26);
            this.metroButton1.TabIndex = 66;
            this.metroButton1.Text = "SIFIRLA";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.resetFiltersButton_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.AutoSize = true;
            this.metroButton2.BackColor = System.Drawing.Color.OrangeRed;
            this.metroButton2.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton2.ForeColor = System.Drawing.SystemColors.Control;
            this.metroButton2.Location = new System.Drawing.Point(570, 7);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(114, 26);
            this.metroButton2.TabIndex = 63;
            this.metroButton2.Text = "ARAMA YAP";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.araButton_Click);
            // 
            // bolgeMuduruComboBox
            // 
            this.bolgeMuduruComboBox.FormattingEnabled = true;
            this.bolgeMuduruComboBox.Location = new System.Drawing.Point(337, 37);
            this.bolgeMuduruComboBox.Name = "bolgeMuduruComboBox";
            this.bolgeMuduruComboBox.Size = new System.Drawing.Size(226, 24);
            this.bolgeMuduruComboBox.TabIndex = 65;
            this.bolgeMuduruComboBox.SelectedIndexChanged += new System.EventHandler(this.bolgeMuduruComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 18);
            this.label1.TabIndex = 63;
            this.label1.Text = "Son Satışdan Sonra Geçen Gün";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(4, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 18);
            this.label2.TabIndex = 63;
            this.label2.Text = "Son Tahsilattan Sonra Geçen Gün ";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.AutoSize = true;
            this.numericUpDown1.Location = new System.Drawing.Point(263, 34);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(68, 22);
            this.numericUpDown1.TabIndex = 60;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(342, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 18);
            this.label3.TabIndex = 63;
            this.label3.Text = "Bölge Müdürüne Göre Filtrele";
            // 
            // numericUpDown
            // 
            this.numericUpDown.AutoSize = true;
            this.numericUpDown.Location = new System.Drawing.Point(252, 3);
            this.numericUpDown.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(68, 22);
            this.numericUpDown.TabIndex = 60;
            this.numericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // excelyukle
            // 
            this.excelyukle.AutoSize = true;
            this.excelyukle.BackColor = System.Drawing.Color.OrangeRed;
            this.excelyukle.ForeColor = System.Drawing.SystemColors.Control;
            this.excelyukle.Location = new System.Drawing.Point(3, 37);
            this.excelyukle.Name = "excelyukle";
            this.excelyukle.Size = new System.Drawing.Size(99, 26);
            this.excelyukle.TabIndex = 59;
            this.excelyukle.Text = "Excel Yükle";
            this.excelyukle.UseSelectable = true;
            this.excelyukle.Click += new System.EventHandler(this.browseButton_Click);
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
            this.dataGridView.Size = new System.Drawing.Size(1251, 503);
            this.dataGridView.TabIndex = 67;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.progressBar.BackColor = System.Drawing.Color.DarkGray;
            this.progressBar.Location = new System.Drawing.Point(481, 194);
            this.progressBar.Maximum = 100;
            this.progressBar.MaximumSize = new System.Drawing.Size(271, 275);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(271, 275);
            this.progressBar.Speed = 2F;
            this.progressBar.Style = MetroFramework.MetroColorStyle.Orange;
            this.progressBar.TabIndex = 63;
            this.progressBar.UseSelectable = true;
            this.progressBar.UseStyleColors = true;
            this.progressBar.Value = 90;
            this.progressBar.Visible = false;
            // 
            // bayitakipmainpage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1251, 583);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.panelheader);
            this.Controls.Add(this.dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "bayitakipmainpage";
            this.Text = "bayitakipmainpage";
            this.Load += new System.EventHandler(this.bayitakipmainpage_Load);
            this.panelheader.ResumeLayout(false);
            this.panelheader.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label epostalabel;
        private System.Windows.Forms.Panel panelheader;
        private System.Windows.Forms.DataGridView dataGridView;
        private MetroFramework.Controls.MetroButton excelyukle;
        private MetroFramework.Controls.MetroProgressSpinner progressBar;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ComboBox bolgeMuduruComboBox;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}
namespace BPET_PORTAL.lojistik.lojistikekranlar.nakliyegelirleri
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewDriverReport = new System.Windows.Forms.DataGridView();
            this.dataGridViewCariKoduReport = new System.Windows.Forms.DataGridView();
            this.cartesianChartDriverReport = new LiveCharts.WinForms.CartesianChart();
            this.cartesianChartCariKoduReport = new LiveCharts.WinForms.CartesianChart();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDriverReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCariKoduReport)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDriverReport
            // 
            this.dataGridViewDriverReport.AllowUserToAddRows = false;
            this.dataGridViewDriverReport.AllowUserToDeleteRows = false;
            this.dataGridViewDriverReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dataGridViewDriverReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDriverReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDriverReport.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDriverReport.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewDriverReport.MaximumSize = new System.Drawing.Size(679, 133);
            this.dataGridViewDriverReport.MultiSelect = false;
            this.dataGridViewDriverReport.Name = "dataGridViewDriverReport";
            this.dataGridViewDriverReport.ReadOnly = true;
            this.dataGridViewDriverReport.RowHeadersVisible = false;
            this.dataGridViewDriverReport.RowHeadersWidth = 51;
            this.dataGridViewDriverReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDriverReport.Size = new System.Drawing.Size(645, 129);
            this.dataGridViewDriverReport.TabIndex = 125;
            // 
            // dataGridViewCariKoduReport
            // 
            this.dataGridViewCariKoduReport.AllowUserToAddRows = false;
            this.dataGridViewCariKoduReport.AllowUserToDeleteRows = false;
            this.dataGridViewCariKoduReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dataGridViewCariKoduReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCariKoduReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCariKoduReport.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewCariKoduReport.Location = new System.Drawing.Point(676, 12);
            this.dataGridViewCariKoduReport.MaximumSize = new System.Drawing.Size(744, 133);
            this.dataGridViewCariKoduReport.MultiSelect = false;
            this.dataGridViewCariKoduReport.Name = "dataGridViewCariKoduReport";
            this.dataGridViewCariKoduReport.ReadOnly = true;
            this.dataGridViewCariKoduReport.RowHeadersVisible = false;
            this.dataGridViewCariKoduReport.RowHeadersWidth = 51;
            this.dataGridViewCariKoduReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCariKoduReport.Size = new System.Drawing.Size(744, 129);
            this.dataGridViewCariKoduReport.TabIndex = 126;
            // 
            // cartesianChartDriverReport
            // 
            this.cartesianChartDriverReport.Location = new System.Drawing.Point(12, 147);
            this.cartesianChartDriverReport.Name = "cartesianChartDriverReport";
            this.cartesianChartDriverReport.Size = new System.Drawing.Size(645, 490);
            this.cartesianChartDriverReport.TabIndex = 129;
            this.cartesianChartDriverReport.Text = "cartesianChartDriverReport";
            // 
            // cartesianChartCariKoduReport
            // 
            this.cartesianChartCariKoduReport.Location = new System.Drawing.Point(676, 147);
            this.cartesianChartCariKoduReport.Name = "cartesianChartCariKoduReport";
            this.cartesianChartCariKoduReport.Size = new System.Drawing.Size(744, 490);
            this.cartesianChartCariKoduReport.TabIndex = 130;
            this.cartesianChartCariKoduReport.Text = "cartesianChart1";
            // 
            // RaporEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 653);
            this.Controls.Add(this.cartesianChartCariKoduReport);
            this.Controls.Add(this.cartesianChartDriverReport);
            this.Controls.Add(this.dataGridViewCariKoduReport);
            this.Controls.Add(this.dataGridViewDriverReport);
            this.Name = "RaporEkrani";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RaporEkrani";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDriverReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCariKoduReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDriverReport;
        private System.Windows.Forms.DataGridView dataGridViewCariKoduReport;
        private LiveCharts.WinForms.CartesianChart cartesianChartDriverReport;
        private LiveCharts.WinForms.CartesianChart cartesianChartCariKoduReport;
    }
}
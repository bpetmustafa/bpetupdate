namespace BPET_PORTAL.insankaynaklari.iscilikmaliyeti
{
    partial class iscilikmaliyetiform
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
            this.htmlToolTip1 = new MetroFramework.Drawing.Html.HtmlToolTip();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.balpetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_goruntule = new System.Windows.Forms.Button();
            this.cbMaliyet = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // htmlToolTip1
            // 
            this.htmlToolTip1.OwnerDraw = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.balpetToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 26);
            // 
            // balpetToolStripMenuItem
            // 
            this.balpetToolStripMenuItem.Name = "balpetToolStripMenuItem";
            this.balpetToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.balpetToolStripMenuItem.Text = "Balpet";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 720);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.btn_goruntule);
            this.panel2.Controls.Add(this.cbMaliyet);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1280, 235);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::BPET_PORTAL.Properties.Resources.icons8_cost_801;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(3, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 72);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btn_goruntule
            // 
            this.btn_goruntule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_goruntule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_goruntule.Location = new System.Drawing.Point(732, 99);
            this.btn_goruntule.Name = "btn_goruntule";
            this.btn_goruntule.Size = new System.Drawing.Size(120, 23);
            this.btn_goruntule.TabIndex = 2;
            this.btn_goruntule.Text = "GÖRÜNTÜLE";
            this.btn_goruntule.UseVisualStyleBackColor = true;
            this.btn_goruntule.Click += new System.EventHandler(this.btn_goruntule_Click);
            // 
            // cbMaliyet
            // 
            this.cbMaliyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cbMaliyet.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbMaliyet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaliyet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbMaliyet.FormattingEnabled = true;
            this.cbMaliyet.Items.AddRange(new object[] {
            "KONSOLİDE AYLIK İŞÇİLİK MALİYET ORANI",
            "MALİYETİN BİRİMLERE DAĞILIM ORANI",
            "YILLIK HARCIRAH MALİYETİ VE MALİYETE ORANI",
            "EN ÇOK MESAİ YAPAN BİRİM",
            "YILLIK YEMEK MALİYETİ VE TOPLAM MALİYETE ORANI",
            "MESAİ MALİYETİ VE TOPLAM MALİYETE ORANI"});
            this.cbMaliyet.Location = new System.Drawing.Point(453, 99);
            this.cbMaliyet.Name = "cbMaliyet";
            this.cbMaliyet.Size = new System.Drawing.Size(273, 23);
            this.cbMaliyet.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(449, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Görüntülemek İstediğiniz Maliyeti Seçiniz:";
            // 
            // iscilikmaliyetiform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(877, 333);
            this.Name = "iscilikmaliyetiform";
            this.Text = "iscilikmaliyetiform";
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Drawing.Html.HtmlToolTip htmlToolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem balpetToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMaliyet;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_goruntule;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
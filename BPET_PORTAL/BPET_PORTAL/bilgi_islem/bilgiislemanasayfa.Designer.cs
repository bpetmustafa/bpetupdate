namespace BPET_PORTAL.bilgi_islem
{
    partial class bilgiislemanasayfa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bilgiislemanasayfa));
            this.mainpanel = new System.Windows.Forms.Panel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.epostalabel = new System.Windows.Forms.Label();
            this.anasayfastrip = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainpanel
            // 
            this.mainpanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainpanel.Location = new System.Drawing.Point(11, 30);
            this.mainpanel.Margin = new System.Windows.Forms.Padding(2);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(1135, 510);
            this.mainpanel.TabIndex = 11;
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.menuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anasayfastrip});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1157, 28);
            this.menuStrip.TabIndex = 10;
            this.menuStrip.Text = "MENÜ ÇUBUĞU";
            // 
            // epostalabel
            // 
            this.epostalabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.epostalabel.AutoSize = true;
            this.epostalabel.BackColor = System.Drawing.Color.Black;
            this.epostalabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.epostalabel.ForeColor = System.Drawing.Color.Lime;
            this.epostalabel.Location = new System.Drawing.Point(1002, 9);
            this.epostalabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.epostalabel.Name = "epostalabel";
            this.epostalabel.Size = new System.Drawing.Size(144, 18);
            this.epostalabel.TabIndex = 12;
            this.epostalabel.Text = "E POSTA ADRESİNİZ!";
            this.epostalabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // anasayfastrip
            // 
            this.anasayfastrip.Image = ((System.Drawing.Image)(resources.GetObject("anasayfastrip.Image")));
            this.anasayfastrip.Name = "anasayfastrip";
            this.anasayfastrip.ShortcutKeyDisplayString = "";
            this.anasayfastrip.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.anasayfastrip.Size = new System.Drawing.Size(137, 24);
            this.anasayfastrip.Text = "Gelen Talepler";
            this.anasayfastrip.Click += new System.EventHandler(this.anasayfastrip_Click);
            // 
            // bilgiislemanasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1157, 551);
            this.Controls.Add(this.epostalabel);
            this.Controls.Add(this.mainpanel);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "bilgiislemanasayfa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bilgi İşlem Ana Sayfa";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainpanel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem anasayfastrip;
        public System.Windows.Forms.Label epostalabel;
    }
}
namespace BPET_PORTAL.butce_sistemi
{
    partial class butceanaekran
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
            this.dosyabullabel = new System.Windows.Forms.Label();
            this.dosya_bul = new System.Windows.Forms.Button();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // epostalabel
            // 
            this.epostalabel.AutoSize = true;
            this.epostalabel.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.epostalabel.Location = new System.Drawing.Point(10, 7);
            this.epostalabel.Name = "epostalabel";
            this.epostalabel.Size = new System.Drawing.Size(27, 14);
            this.epostalabel.TabIndex = 18;
            this.epostalabel.Text = "-----";
            // 
            // dosyabullabel
            // 
            this.dosyabullabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dosyabullabel.AutoSize = true;
            this.dosyabullabel.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.dosyabullabel.Location = new System.Drawing.Point(56, 261);
            this.dosyabullabel.Name = "dosyabullabel";
            this.dosyabullabel.Size = new System.Drawing.Size(137, 24);
            this.dosyabullabel.TabIndex = 26;
            this.dosyabullabel.Text = "Bayi Sistemi";
            // 
            // dosya_bul
            // 
            this.dosya_bul.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dosya_bul.BackgroundImage = global::BPET_PORTAL.Properties.Resources.icons8_profile_96;
            this.dosya_bul.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dosya_bul.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dosya_bul.FlatAppearance.BorderSize = 0;
            this.dosya_bul.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dosya_bul.Location = new System.Drawing.Point(85, 201);
            this.dosya_bul.MaximumSize = new System.Drawing.Size(60, 57);
            this.dosya_bul.MinimumSize = new System.Drawing.Size(60, 57);
            this.dosya_bul.Name = "dosya_bul";
            this.dosya_bul.Size = new System.Drawing.Size(60, 57);
            this.dosya_bul.TabIndex = 25;
            this.dosya_bul.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.dosya_bul.UseVisualStyleBackColor = true;
            this.dosya_bul.Click += new System.EventHandler(this.dosya_bul_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(366, 185);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(291, 50);
            this.metroLabel1.TabIndex = 27;
            this.metroLabel1.Text = "Bu Sistem Yapım Aşamasındadır. \r\nİlginiz için teşekkürler.";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // butceanaekran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 520);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.dosyabullabel);
            this.Controls.Add(this.dosya_bul);
            this.Controls.Add(this.epostalabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "butceanaekran";
            this.Text = "butceanaekran";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label epostalabel;
        private System.Windows.Forms.Label dosyabullabel;
        private System.Windows.Forms.Button dosya_bul;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}
namespace BPET_PORTAL.yukleme_ekrani
{
    partial class LoadingScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingScreen));
            this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // metroProgressSpinner1
            // 
            this.metroProgressSpinner1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.metroProgressSpinner1.Location = new System.Drawing.Point(273, 100);
            this.metroProgressSpinner1.Maximum = 100;
            this.metroProgressSpinner1.MaximumSize = new System.Drawing.Size(247, 256);
            this.metroProgressSpinner1.MinimumSize = new System.Drawing.Size(247, 256);
            this.metroProgressSpinner1.Name = "metroProgressSpinner1";
            this.metroProgressSpinner1.Size = new System.Drawing.Size(247, 256);
            this.metroProgressSpinner1.Speed = 5F;
            this.metroProgressSpinner1.Style = MetroFramework.MetroColorStyle.White;
            this.metroProgressSpinner1.TabIndex = 0;
            this.metroProgressSpinner1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroProgressSpinner1.UseSelectable = true;
            this.metroProgressSpinner1.Value = 75;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(255, 30);
            this.label1.MaximumSize = new System.Drawing.Size(283, 37);
            this.label1.MinimumSize = new System.Drawing.Size(283, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lütfen Bekleyiniz!";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(243, 380);
            this.label2.MaximumSize = new System.Drawing.Size(306, 46);
            this.label2.MinimumSize = new System.Drawing.Size(306, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(306, 46);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ekran Donmuş Gibi Gözükebilir\r\nLütfen Beklemeye Devam Ediniz";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LoadingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.metroProgressSpinner1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 450);
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "LoadingScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoadingScreen";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
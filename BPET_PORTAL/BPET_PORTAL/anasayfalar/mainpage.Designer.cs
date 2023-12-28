namespace BPET_PORTAL
{
    partial class mainpage
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainpage));
            this.mainpanel = new System.Windows.Forms.Panel();
            this.livechat = new System.Windows.Forms.Panel();
            this.chatclose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gondertusu = new System.Windows.Forms.Button();
            this.txtMessage = new MetroFramework.Controls.MetroTextBox();
            this.txtChatLog = new System.Windows.Forms.RichTextBox();
            this.panelside = new System.Windows.Forms.Panel();
            this.btnlojistik = new System.Windows.Forms.Button();
            this.btninsankaynaklari = new System.Windows.Forms.Button();
            this.btnmuhasebe = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnayarlar = new System.Windows.Forms.Button();
            this.btnadmin = new System.Windows.Forms.Button();
            this.btnbayitalep = new System.Windows.Forms.Button();
            this.btnborsa = new System.Windows.Forms.Button();
            this.btnsms = new System.Windows.Forms.Button();
            this.btnozelrapor = new System.Windows.Forms.Button();
            this.btnarsiv = new System.Windows.Forms.Button();
            this.btnrapor = new System.Windows.Forms.Button();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.bpetlogo = new System.Windows.Forms.PictureBox();
            this.panelheader = new System.Windows.Forms.Panel();
            this.boyutlandırma = new System.Windows.Forms.Button();
            this.Togglemenubutton = new System.Windows.Forms.Button();
            this.epostalabel = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.livechatbtn = new System.Windows.Forms.Button();
            this.solidGauge1 = new LiveCharts.WinForms.SolidGauge();
            this.label2 = new System.Windows.Forms.Label();
            this.livechat.SuspendLayout();
            this.panelside.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bpetlogo)).BeginInit();
            this.panelheader.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainpanel
            // 
            this.mainpanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainpanel.Location = new System.Drawing.Point(206, 37);
            this.mainpanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(1019, 643);
            this.mainpanel.TabIndex = 5;
            // 
            // livechat
            // 
            this.livechat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.livechat.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.livechat.Controls.Add(this.chatclose);
            this.livechat.Controls.Add(this.label1);
            this.livechat.Controls.Add(this.gondertusu);
            this.livechat.Controls.Add(this.txtMessage);
            this.livechat.Controls.Add(this.txtChatLog);
            this.livechat.Location = new System.Drawing.Point(780, 221);
            this.livechat.Name = "livechat";
            this.livechat.Size = new System.Drawing.Size(454, 421);
            this.livechat.TabIndex = 0;
            this.livechat.Visible = false;
            // 
            // chatclose
            // 
            this.chatclose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chatclose.BackColor = System.Drawing.Color.White;
            this.chatclose.BackgroundImage = global::BPET_PORTAL.Properties.Resources.çıkış2;
            this.chatclose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chatclose.FlatAppearance.BorderSize = 0;
            this.chatclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chatclose.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chatclose.ForeColor = System.Drawing.Color.Red;
            this.chatclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chatclose.Location = new System.Drawing.Point(402, 2);
            this.chatclose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chatclose.Name = "chatclose";
            this.chatclose.Size = new System.Drawing.Size(40, 27);
            this.chatclose.TabIndex = 9;
            this.chatclose.UseVisualStyleBackColor = false;
            this.chatclose.Click += new System.EventHandler(this.chatclose_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "BPET PORTAL CANLI DESTEĞE HOŞGELDİNİZ!";
            // 
            // gondertusu
            // 
            this.gondertusu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gondertusu.BackColor = System.Drawing.Color.Orange;
            this.gondertusu.Cursor = System.Windows.Forms.Cursors.Default;
            this.gondertusu.Font = new System.Drawing.Font("Unispace", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gondertusu.ForeColor = System.Drawing.Color.Navy;
            this.gondertusu.Location = new System.Drawing.Point(327, 361);
            this.gondertusu.Name = "gondertusu";
            this.gondertusu.Size = new System.Drawing.Size(118, 29);
            this.gondertusu.TabIndex = 6;
            this.gondertusu.Text = "Gönder";
            this.gondertusu.UseVisualStyleBackColor = false;
            this.gondertusu.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtMessage.CustomButton.Image = null;
            this.txtMessage.CustomButton.Location = new System.Drawing.Point(259, 1);
            this.txtMessage.CustomButton.Name = "";
            this.txtMessage.CustomButton.Size = new System.Drawing.Size(53, 53);
            this.txtMessage.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMessage.CustomButton.TabIndex = 1;
            this.txtMessage.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMessage.CustomButton.UseSelectable = true;
            this.txtMessage.CustomButton.Visible = false;
            this.txtMessage.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtMessage.Lines = new string[0];
            this.txtMessage.Location = new System.Drawing.Point(3, 348);
            this.txtMessage.MaxLength = 32767;
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.PasswordChar = '\0';
            this.txtMessage.PromptText = "Mesajınızı buraya yazınız...";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMessage.SelectedText = "";
            this.txtMessage.SelectionLength = 0;
            this.txtMessage.SelectionStart = 0;
            this.txtMessage.ShortcutsEnabled = true;
            this.txtMessage.Size = new System.Drawing.Size(313, 55);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.UseSelectable = true;
            this.txtMessage.WaterMark = "Mesajınızı buraya yazınız...";
            this.txtMessage.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtMessage.WaterMarkFont = new System.Drawing.Font("Segoe UI Black", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessage_KeyPress);
            // 
            // txtChatLog
            // 
            this.txtChatLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChatLog.BackColor = System.Drawing.Color.White;
            this.txtChatLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtChatLog.Location = new System.Drawing.Point(3, 28);
            this.txtChatLog.Name = "txtChatLog";
            this.txtChatLog.ReadOnly = true;
            this.txtChatLog.Size = new System.Drawing.Size(440, 314);
            this.txtChatLog.TabIndex = 0;
            this.txtChatLog.Text = "";
            // 
            // panelside
            // 
            this.panelside.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelside.Controls.Add(this.label2);
            this.panelside.Controls.Add(this.solidGauge1);
            this.panelside.Controls.Add(this.btnlojistik);
            this.panelside.Controls.Add(this.btninsankaynaklari);
            this.panelside.Controls.Add(this.btnmuhasebe);
            this.panelside.Controls.Add(this.btnexit);
            this.panelside.Controls.Add(this.btnayarlar);
            this.panelside.Controls.Add(this.btnadmin);
            this.panelside.Controls.Add(this.btnbayitalep);
            this.panelside.Controls.Add(this.btnborsa);
            this.panelside.Controls.Add(this.btnsms);
            this.panelside.Controls.Add(this.btnozelrapor);
            this.panelside.Controls.Add(this.btnarsiv);
            this.panelside.Controls.Add(this.btnrapor);
            this.panelside.Controls.Add(this.linkLabel);
            this.panelside.Controls.Add(this.bpetlogo);
            this.panelside.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelside.Location = new System.Drawing.Point(0, 33);
            this.panelside.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelside.Name = "panelside";
            this.panelside.Size = new System.Drawing.Size(200, 658);
            this.panelside.TabIndex = 3;
            // 
            // btnlojistik
            // 
            this.btnlojistik.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlojistik.FlatAppearance.BorderSize = 0;
            this.btnlojistik.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(55)))), ((int)(((byte)(113)))));
            this.btnlojistik.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlojistik.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnlojistik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnlojistik.Image = ((System.Drawing.Image)(resources.GetObject("btnlojistik.Image")));
            this.btnlojistik.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnlojistik.Location = new System.Drawing.Point(4, 394);
            this.btnlojistik.MaximumSize = new System.Drawing.Size(189, 32);
            this.btnlojistik.Name = "btnlojistik";
            this.btnlojistik.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnlojistik.Size = new System.Drawing.Size(189, 32);
            this.btnlojistik.TabIndex = 31;
            this.btnlojistik.Text = " Lojistik";
            this.btnlojistik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnlojistik.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnlojistik.UseVisualStyleBackColor = true;
            this.btnlojistik.Visible = false;
            this.btnlojistik.Click += new System.EventHandler(this.btnlojistik_Click);
            // 
            // btninsankaynaklari
            // 
            this.btninsankaynaklari.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btninsankaynaklari.FlatAppearance.BorderSize = 0;
            this.btninsankaynaklari.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(55)))), ((int)(((byte)(113)))));
            this.btninsankaynaklari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btninsankaynaklari.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btninsankaynaklari.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btninsankaynaklari.Image = ((System.Drawing.Image)(resources.GetObject("btninsankaynaklari.Image")));
            this.btninsankaynaklari.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btninsankaynaklari.Location = new System.Drawing.Point(4, 368);
            this.btninsankaynaklari.MaximumSize = new System.Drawing.Size(189, 32);
            this.btninsankaynaklari.Name = "btninsankaynaklari";
            this.btninsankaynaklari.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btninsankaynaklari.Size = new System.Drawing.Size(189, 32);
            this.btninsankaynaklari.TabIndex = 30;
            this.btninsankaynaklari.Text = " İnsan Kaynakları";
            this.btninsankaynaklari.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btninsankaynaklari.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btninsankaynaklari.UseVisualStyleBackColor = true;
            this.btninsankaynaklari.Visible = false;
            this.btninsankaynaklari.Click += new System.EventHandler(this.btninsankaynaklari_Click);
            // 
            // btnmuhasebe
            // 
            this.btnmuhasebe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnmuhasebe.FlatAppearance.BorderSize = 0;
            this.btnmuhasebe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(55)))), ((int)(((byte)(113)))));
            this.btnmuhasebe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmuhasebe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnmuhasebe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnmuhasebe.Image = ((System.Drawing.Image)(resources.GetObject("btnmuhasebe.Image")));
            this.btnmuhasebe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnmuhasebe.Location = new System.Drawing.Point(4, 339);
            this.btnmuhasebe.MaximumSize = new System.Drawing.Size(189, 32);
            this.btnmuhasebe.Name = "btnmuhasebe";
            this.btnmuhasebe.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnmuhasebe.Size = new System.Drawing.Size(189, 32);
            this.btnmuhasebe.TabIndex = 29;
            this.btnmuhasebe.Text = "  Muhasebe";
            this.btnmuhasebe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnmuhasebe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnmuhasebe.UseVisualStyleBackColor = true;
            this.btnmuhasebe.Visible = false;
            this.btnmuhasebe.Click += new System.EventHandler(this.btnmuhasebe_Click);
            // 
            // btnexit
            // 
            this.btnexit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnexit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnexit.FlatAppearance.BorderSize = 0;
            this.btnexit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(55)))), ((int)(((byte)(113)))));
            this.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnexit.Image = ((System.Drawing.Image)(resources.GetObject("btnexit.Image")));
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnexit.Location = new System.Drawing.Point(-1, 630);
            this.btnexit.Name = "btnexit";
            this.btnexit.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnexit.Size = new System.Drawing.Size(203, 28);
            this.btnexit.TabIndex = 28;
            this.btnexit.Text = " Çıkış Yap";
            this.btnexit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnexit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.button11_Click);
            // 
            // btnayarlar
            // 
            this.btnayarlar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnayarlar.FlatAppearance.BorderSize = 0;
            this.btnayarlar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(55)))), ((int)(((byte)(113)))));
            this.btnayarlar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnayarlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnayarlar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnayarlar.Image = ((System.Drawing.Image)(resources.GetObject("btnayarlar.Image")));
            this.btnayarlar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnayarlar.Location = new System.Drawing.Point(4, 309);
            this.btnayarlar.MaximumSize = new System.Drawing.Size(189, 32);
            this.btnayarlar.Name = "btnayarlar";
            this.btnayarlar.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnayarlar.Size = new System.Drawing.Size(189, 32);
            this.btnayarlar.TabIndex = 27;
            this.btnayarlar.Text = "  Bütçe Sistemi";
            this.btnayarlar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnayarlar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnayarlar.UseVisualStyleBackColor = true;
            this.btnayarlar.Visible = false;
            this.btnayarlar.Click += new System.EventHandler(this.btnayarlar_Click);
            // 
            // btnadmin
            // 
            this.btnadmin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnadmin.FlatAppearance.BorderSize = 0;
            this.btnadmin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(55)))), ((int)(((byte)(113)))));
            this.btnadmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnadmin.ForeColor = System.Drawing.Color.SeaShell;
            this.btnadmin.Image = ((System.Drawing.Image)(resources.GetObject("btnadmin.Image")));
            this.btnadmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnadmin.Location = new System.Drawing.Point(4, 277);
            this.btnadmin.MaximumSize = new System.Drawing.Size(189, 32);
            this.btnadmin.Name = "btnadmin";
            this.btnadmin.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnadmin.Size = new System.Drawing.Size(189, 32);
            this.btnadmin.TabIndex = 26;
            this.btnadmin.Text = "  Admin Panel";
            this.btnadmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnadmin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnadmin.UseVisualStyleBackColor = true;
            this.btnadmin.Visible = false;
            this.btnadmin.Click += new System.EventHandler(this.btnadmin_Click);
            // 
            // btnbayitalep
            // 
            this.btnbayitalep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbayitalep.FlatAppearance.BorderSize = 0;
            this.btnbayitalep.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(55)))), ((int)(((byte)(113)))));
            this.btnbayitalep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbayitalep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnbayitalep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnbayitalep.Image = ((System.Drawing.Image)(resources.GetObject("btnbayitalep.Image")));
            this.btnbayitalep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnbayitalep.Location = new System.Drawing.Point(4, 245);
            this.btnbayitalep.MaximumSize = new System.Drawing.Size(189, 32);
            this.btnbayitalep.Name = "btnbayitalep";
            this.btnbayitalep.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnbayitalep.Size = new System.Drawing.Size(189, 32);
            this.btnbayitalep.TabIndex = 25;
            this.btnbayitalep.Text = " Bayi Takip Sistemi";
            this.btnbayitalep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnbayitalep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnbayitalep.UseVisualStyleBackColor = true;
            this.btnbayitalep.Visible = false;
            this.btnbayitalep.Click += new System.EventHandler(this.btnbayitalep_Click);
            // 
            // btnborsa
            // 
            this.btnborsa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnborsa.FlatAppearance.BorderSize = 0;
            this.btnborsa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(55)))), ((int)(((byte)(113)))));
            this.btnborsa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnborsa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnborsa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnborsa.Image = ((System.Drawing.Image)(resources.GetObject("btnborsa.Image")));
            this.btnborsa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnborsa.Location = new System.Drawing.Point(4, 217);
            this.btnborsa.MaximumSize = new System.Drawing.Size(189, 32);
            this.btnborsa.Name = "btnborsa";
            this.btnborsa.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnborsa.Size = new System.Drawing.Size(189, 32);
            this.btnborsa.TabIndex = 23;
            this.btnborsa.Text = " Yücel KOÇ";
            this.btnborsa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnborsa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnborsa.UseVisualStyleBackColor = true;
            this.btnborsa.Visible = false;
            this.btnborsa.Click += new System.EventHandler(this.btnborsa_Click);
            // 
            // btnsms
            // 
            this.btnsms.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsms.FlatAppearance.BorderSize = 0;
            this.btnsms.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(55)))), ((int)(((byte)(113)))));
            this.btnsms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsms.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnsms.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnsms.Image = ((System.Drawing.Image)(resources.GetObject("btnsms.Image")));
            this.btnsms.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsms.Location = new System.Drawing.Point(4, 185);
            this.btnsms.MaximumSize = new System.Drawing.Size(189, 32);
            this.btnsms.Name = "btnsms";
            this.btnsms.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnsms.Size = new System.Drawing.Size(189, 32);
            this.btnsms.TabIndex = 22;
            this.btnsms.Text = " SMS Sistemi";
            this.btnsms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsms.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnsms.UseVisualStyleBackColor = true;
            this.btnsms.Visible = false;
            this.btnsms.Click += new System.EventHandler(this.btnsms_Click);
            // 
            // btnozelrapor
            // 
            this.btnozelrapor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnozelrapor.FlatAppearance.BorderSize = 0;
            this.btnozelrapor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(55)))), ((int)(((byte)(113)))));
            this.btnozelrapor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnozelrapor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnozelrapor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnozelrapor.Image = ((System.Drawing.Image)(resources.GetObject("btnozelrapor.Image")));
            this.btnozelrapor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnozelrapor.Location = new System.Drawing.Point(4, 153);
            this.btnozelrapor.MaximumSize = new System.Drawing.Size(189, 32);
            this.btnozelrapor.Name = "btnozelrapor";
            this.btnozelrapor.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnozelrapor.Size = new System.Drawing.Size(189, 32);
            this.btnozelrapor.TabIndex = 21;
            this.btnozelrapor.Text = " Victor Reklam";
            this.btnozelrapor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnozelrapor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnozelrapor.UseVisualStyleBackColor = true;
            this.btnozelrapor.Visible = false;
            this.btnozelrapor.Click += new System.EventHandler(this.btnbayitakip_Click);
            // 
            // btnarsiv
            // 
            this.btnarsiv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnarsiv.FlatAppearance.BorderSize = 0;
            this.btnarsiv.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(55)))), ((int)(((byte)(113)))));
            this.btnarsiv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnarsiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnarsiv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnarsiv.Image = ((System.Drawing.Image)(resources.GetObject("btnarsiv.Image")));
            this.btnarsiv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnarsiv.Location = new System.Drawing.Point(4, 121);
            this.btnarsiv.MaximumSize = new System.Drawing.Size(189, 32);
            this.btnarsiv.Name = "btnarsiv";
            this.btnarsiv.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnarsiv.Size = new System.Drawing.Size(189, 32);
            this.btnarsiv.TabIndex = 20;
            this.btnarsiv.Text = " Arşiv Uygulaması";
            this.btnarsiv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnarsiv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnarsiv.UseVisualStyleBackColor = true;
            this.btnarsiv.Visible = false;
            this.btnarsiv.Click += new System.EventHandler(this.btnarsiv_Click);
            // 
            // btnrapor
            // 
            this.btnrapor.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnrapor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnrapor.FlatAppearance.BorderSize = 0;
            this.btnrapor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(55)))), ((int)(((byte)(113)))));
            this.btnrapor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnrapor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnrapor.ForeColor = System.Drawing.Color.LightGray;
            this.btnrapor.Image = ((System.Drawing.Image)(resources.GetObject("btnrapor.Image")));
            this.btnrapor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrapor.Location = new System.Drawing.Point(4, 89);
            this.btnrapor.MaximumSize = new System.Drawing.Size(189, 32);
            this.btnrapor.Name = "btnrapor";
            this.btnrapor.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnrapor.Size = new System.Drawing.Size(189, 32);
            this.btnrapor.TabIndex = 19;
            this.btnrapor.Text = " Rapor Uygulaması";
            this.btnrapor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrapor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnrapor.UseVisualStyleBackColor = false;
            this.btnrapor.Visible = false;
            this.btnrapor.Click += new System.EventHandler(this.btnrapor_Click);
            // 
            // linkLabel
            // 
            this.linkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel.AutoSize = true;
            this.linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.linkLabel.Location = new System.Drawing.Point(15, 631);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(125, 13);
            this.linkLabel.TabIndex = 13;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "Made By @BpetIT v1.8.1";
            // 
            // bpetlogo
            // 
            this.bpetlogo.BackgroundImage = global::BPET_PORTAL.Properties.Resources.My_project__1_;
            this.bpetlogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bpetlogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bpetlogo.Location = new System.Drawing.Point(2, 0);
            this.bpetlogo.Margin = new System.Windows.Forms.Padding(4);
            this.bpetlogo.MaximumSize = new System.Drawing.Size(200, 76);
            this.bpetlogo.MinimumSize = new System.Drawing.Size(200, 76);
            this.bpetlogo.Name = "bpetlogo";
            this.bpetlogo.Size = new System.Drawing.Size(200, 76);
            this.bpetlogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bpetlogo.TabIndex = 0;
            this.bpetlogo.TabStop = false;
            this.bpetlogo.Click += new System.EventHandler(this.bpetlogo_Click);
            // 
            // panelheader
            // 
            this.panelheader.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelheader.Controls.Add(this.boyutlandırma);
            this.panelheader.Controls.Add(this.Togglemenubutton);
            this.panelheader.Controls.Add(this.epostalabel);
            this.panelheader.Controls.Add(this.button5);
            this.panelheader.Controls.Add(this.button1);
            this.panelheader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelheader.Location = new System.Drawing.Point(0, 0);
            this.panelheader.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelheader.Name = "panelheader";
            this.panelheader.Size = new System.Drawing.Size(1237, 33);
            this.panelheader.TabIndex = 4;
            this.panelheader.DoubleClick += new System.EventHandler(this.panelheader_DoubleClick);
            // 
            // boyutlandırma
            // 
            this.boyutlandırma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boyutlandırma.BackColor = System.Drawing.Color.RoyalBlue;
            this.boyutlandırma.BackgroundImage = global::BPET_PORTAL.Properties.Resources.küçültme;
            this.boyutlandırma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.boyutlandırma.FlatAppearance.BorderSize = 0;
            this.boyutlandırma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boyutlandırma.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.boyutlandırma.ForeColor = System.Drawing.Color.White;
            this.boyutlandırma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.boyutlandırma.Location = new System.Drawing.Point(1148, 3);
            this.boyutlandırma.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.boyutlandırma.Name = "boyutlandırma";
            this.boyutlandırma.Size = new System.Drawing.Size(40, 30);
            this.boyutlandırma.TabIndex = 8;
            this.boyutlandırma.Text = "-";
            this.boyutlandırma.UseVisualStyleBackColor = false;
            this.boyutlandırma.Click += new System.EventHandler(this.boyutlandırma_Click);
            // 
            // Togglemenubutton
            // 
            this.Togglemenubutton.BackColor = System.Drawing.SystemColors.Window;
            this.Togglemenubutton.BackgroundImage = global::BPET_PORTAL.Properties.Resources.sidemenu;
            this.Togglemenubutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Togglemenubutton.Location = new System.Drawing.Point(-1, 0);
            this.Togglemenubutton.Name = "Togglemenubutton";
            this.Togglemenubutton.Size = new System.Drawing.Size(46, 33);
            this.Togglemenubutton.TabIndex = 7;
            this.Togglemenubutton.UseVisualStyleBackColor = false;
            this.Togglemenubutton.Click += new System.EventHandler(this.Togglemenubutton_Click);
            // 
            // epostalabel
            // 
            this.epostalabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.epostalabel.AutoSize = true;
            this.epostalabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.epostalabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.epostalabel.Location = new System.Drawing.Point(565, 8);
            this.epostalabel.Name = "epostalabel";
            this.epostalabel.Size = new System.Drawing.Size(119, 15);
            this.epostalabel.TabIndex = 6;
            this.epostalabel.Text = "E POSTA ADRESİNİZ!";
            this.epostalabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackColor = System.Drawing.Color.RoyalBlue;
            this.button5.BackgroundImage = global::BPET_PORTAL.Properties.Resources.simgedurumuna;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(1102, 3);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(40, 30);
            this.button5.TabIndex = 5;
            this.button5.Text = "-";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.BackgroundImage = global::BPET_PORTAL.Properties.Resources.çıkış2;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1194, 3);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 30);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // livechatbtn
            // 
            this.livechatbtn.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuPopup;
            this.livechatbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.livechatbtn.BackColor = System.Drawing.Color.Orange;
            this.livechatbtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.livechatbtn.Font = new System.Drawing.Font("Unispace", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.livechatbtn.ForeColor = System.Drawing.Color.Navy;
            this.livechatbtn.Location = new System.Drawing.Point(1044, 648);
            this.livechatbtn.Name = "livechatbtn";
            this.livechatbtn.Size = new System.Drawing.Size(193, 43);
            this.livechatbtn.TabIndex = 1;
            this.livechatbtn.Text = "CANLI DESTEK";
            this.livechatbtn.UseVisualStyleBackColor = false;
            this.livechatbtn.Click += new System.EventHandler(this.livechatbtn_Click);
            // 
            // solidGauge1
            // 
            this.solidGauge1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.solidGauge1.Location = new System.Drawing.Point(-1, 526);
            this.solidGauge1.Name = "solidGauge1";
            this.solidGauge1.Size = new System.Drawing.Size(198, 98);
            this.solidGauge1.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.BackColor = System.Drawing.Color.DarkBlue;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 526);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "Sunucu Yanıt Süresi (ms)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mainpage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1237, 691);
            this.ControlBox = false;
            this.Controls.Add(this.livechat);
            this.Controls.Add(this.livechatbtn);
            this.Controls.Add(this.panelside);
            this.Controls.Add(this.mainpanel);
            this.Controls.Add(this.panelheader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainpage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BPET PORTAL";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.mainpage_Load);
            this.Shown += new System.EventHandler(this.mainpage_Shown);
            this.livechat.ResumeLayout(false);
            this.livechat.PerformLayout();
            this.panelside.ResumeLayout(false);
            this.panelside.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bpetlogo)).EndInit();
            this.panelheader.ResumeLayout(false);
            this.panelheader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainpanel;
        private System.Windows.Forms.Panel panelside;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.PictureBox bpetlogo;
        private System.Windows.Forms.Panel panelheader;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
        public System.Windows.Forms.Button btnayarlar;
        public System.Windows.Forms.Button btnadmin;
        public System.Windows.Forms.Button btnbayitalep;
        public System.Windows.Forms.Button btnborsa;
        public System.Windows.Forms.Button btnsms;
        public System.Windows.Forms.Button btnozelrapor;
        public System.Windows.Forms.Button btnarsiv;
        public System.Windows.Forms.Button btnrapor;
        internal System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Label epostalabel;
        private System.Windows.Forms.Button livechatbtn;
        private System.Windows.Forms.RichTextBox txtChatLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Togglemenubutton;
        private System.Windows.Forms.Button boyutlandırma;
        public System.Windows.Forms.Button btnmuhasebe;
        public System.Windows.Forms.Button btninsankaynaklari;
        private System.Windows.Forms.Button chatclose;
        public System.Windows.Forms.Panel livechat;
        public MetroFramework.Controls.MetroTextBox txtMessage;
        public System.Windows.Forms.Button gondertusu;
        public System.Windows.Forms.Button btnlojistik;
        private LiveCharts.WinForms.SolidGauge solidGauge1;
        private System.Windows.Forms.Label label2;
    }
}


namespace BPET_PORTAL.sms_otomasyonu
{
    partial class sms
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
            this.testmode = new System.Windows.Forms.Button();
            this.adminpanel = new System.Windows.Forms.GroupBox();
            this.clientmode = new System.Windows.Forms.Button();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.metroButton6 = new MetroFramework.Controls.MetroButton();
            this.sendtestbtn = new MetroFramework.Controls.MetroButton();
            this.listBoxNumbers = new System.Windows.Forms.ListBox();
            this.txtNewNumber = new MetroFramework.Controls.MetroTextBox();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroButton5 = new MetroFramework.Controls.MetroButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saniyeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.dakikaNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.saatNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txtNewEmail = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.key = new MetroFramework.Controls.MetroLabel();
            this.kalanLabel = new MetroFramework.Controls.MetroLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.adminbtn = new MetroFramework.Controls.MetroButton();
            this.saatLabel = new MetroFramework.Controls.MetroLabel();
            this.autoSendTimer = new System.Windows.Forms.Timer(this.components);
            this.consoletxtbox = new MetroFramework.Controls.MetroTextBox();
            this.adminpanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saniyeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dakikaNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saatNumericUpDown)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // testmode
            // 
            this.testmode.BackColor = System.Drawing.Color.Red;
            this.testmode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testmode.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.testmode.ForeColor = System.Drawing.Color.Black;
            this.testmode.Location = new System.Drawing.Point(813, 85);
            this.testmode.Name = "testmode";
            this.testmode.Size = new System.Drawing.Size(73, 44);
            this.testmode.TabIndex = 22;
            this.testmode.Text = "TEST MODE";
            this.testmode.UseVisualStyleBackColor = false;
            this.testmode.Click += new System.EventHandler(this.testmode_click);
            // 
            // adminpanel
            // 
            this.adminpanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.adminpanel.Controls.Add(this.clientmode);
            this.adminpanel.Controls.Add(this.testmode);
            this.adminpanel.Controls.Add(this.metroButton4);
            this.adminpanel.Controls.Add(this.metroButton6);
            this.adminpanel.Controls.Add(this.sendtestbtn);
            this.adminpanel.Controls.Add(this.listBoxNumbers);
            this.adminpanel.Controls.Add(this.txtNewNumber);
            this.adminpanel.Controls.Add(this.metroButton3);
            this.adminpanel.Controls.Add(this.metroButton5);
            this.adminpanel.Controls.Add(this.groupBox1);
            this.adminpanel.Controls.Add(this.listBox1);
            this.adminpanel.Controls.Add(this.txtNewEmail);
            this.adminpanel.ForeColor = System.Drawing.Color.Red;
            this.adminpanel.Location = new System.Drawing.Point(32, 43);
            this.adminpanel.MaximumSize = new System.Drawing.Size(1005, 136);
            this.adminpanel.Name = "adminpanel";
            this.adminpanel.Size = new System.Drawing.Size(1005, 136);
            this.adminpanel.TabIndex = 29;
            this.adminpanel.TabStop = false;
            this.adminpanel.Text = "Admin Panel";
            this.adminpanel.Visible = false;
            // 
            // clientmode
            // 
            this.clientmode.BackColor = System.Drawing.Color.Green;
            this.clientmode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clientmode.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.clientmode.ForeColor = System.Drawing.Color.Black;
            this.clientmode.Location = new System.Drawing.Point(904, 85);
            this.clientmode.Name = "clientmode";
            this.clientmode.Size = new System.Drawing.Size(73, 44);
            this.clientmode.TabIndex = 23;
            this.clientmode.Text = "CLİENT MODE";
            this.clientmode.UseVisualStyleBackColor = false;
            this.clientmode.Click += new System.EventHandler(this.clientmode_Click);
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroButton4.AutoSize = true;
            this.metroButton4.BackColor = System.Drawing.SystemColors.Control;
            this.metroButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroButton4.Location = new System.Drawing.Point(7, 36);
            this.metroButton4.Margin = new System.Windows.Forms.Padding(4);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(201, 26);
            this.metroButton4.TabIndex = 13;
            this.metroButton4.Text = "MAİL, SMS SEND";
            this.metroButton4.UseSelectable = true;
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroButton6
            // 
            this.metroButton6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroButton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroButton6.Location = new System.Drawing.Point(760, 28);
            this.metroButton6.Margin = new System.Windows.Forms.Padding(4);
            this.metroButton6.MaximumSize = new System.Drawing.Size(40, 37);
            this.metroButton6.Name = "metroButton6";
            this.metroButton6.Size = new System.Drawing.Size(28, 23);
            this.metroButton6.TabIndex = 21;
            this.metroButton6.Text = "X";
            this.metroButton6.UseSelectable = true;
            this.metroButton6.Visible = false;
            this.metroButton6.Click += new System.EventHandler(this.btnDeleteNumber_Click);
            // 
            // sendtestbtn
            // 
            this.sendtestbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sendtestbtn.AutoSize = true;
            this.sendtestbtn.BackColor = System.Drawing.SystemColors.Control;
            this.sendtestbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sendtestbtn.Location = new System.Drawing.Point(7, 79);
            this.sendtestbtn.Margin = new System.Windows.Forms.Padding(4);
            this.sendtestbtn.Name = "sendtestbtn";
            this.sendtestbtn.Size = new System.Drawing.Size(88, 26);
            this.sendtestbtn.TabIndex = 2;
            this.sendtestbtn.Text = "MAİL SEND";
            this.sendtestbtn.UseSelectable = true;
            this.sendtestbtn.Click += new System.EventHandler(this.sendtestbtn_Click);
            // 
            // listBoxNumbers
            // 
            this.listBoxNumbers.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.listBoxNumbers.FormattingEnabled = true;
            this.listBoxNumbers.ItemHeight = 16;
            this.listBoxNumbers.Location = new System.Drawing.Point(520, 58);
            this.listBoxNumbers.Name = "listBoxNumbers";
            this.listBoxNumbers.Size = new System.Drawing.Size(233, 68);
            this.listBoxNumbers.TabIndex = 20;
            this.listBoxNumbers.Visible = false;
            // 
            // txtNewNumber
            // 
            this.txtNewNumber.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            // 
            // 
            // 
            this.txtNewNumber.CustomButton.BackColor = System.Drawing.SystemColors.ControlText;
            this.txtNewNumber.CustomButton.Image = null;
            this.txtNewNumber.CustomButton.Location = new System.Drawing.Point(211, 1);
            this.txtNewNumber.CustomButton.Name = "";
            this.txtNewNumber.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtNewNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNewNumber.CustomButton.TabIndex = 1;
            this.txtNewNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNewNumber.CustomButton.UseSelectable = true;
            this.txtNewNumber.CustomButton.UseVisualStyleBackColor = false;
            this.txtNewNumber.DisplayIcon = true;
            this.txtNewNumber.IconRight = true;
            this.txtNewNumber.Lines = new string[0];
            this.txtNewNumber.Location = new System.Drawing.Point(520, 28);
            this.txtNewNumber.MaxLength = 32767;
            this.txtNewNumber.Name = "txtNewNumber";
            this.txtNewNumber.PasswordChar = '\0';
            this.txtNewNumber.PromptText = "Phone Number Add";
            this.txtNewNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNewNumber.SelectedText = "";
            this.txtNewNumber.SelectionLength = 0;
            this.txtNewNumber.SelectionStart = 0;
            this.txtNewNumber.ShortcutsEnabled = true;
            this.txtNewNumber.ShowButton = true;
            this.txtNewNumber.Size = new System.Drawing.Size(233, 23);
            this.txtNewNumber.TabIndex = 19;
            this.txtNewNumber.UseSelectable = true;
            this.txtNewNumber.Visible = false;
            this.txtNewNumber.WaterMark = "Phone Number Add";
            this.txtNewNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNewNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtNewNumber.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.btnAddNumber_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroButton3.AutoSize = true;
            this.metroButton3.BackColor = System.Drawing.SystemColors.Control;
            this.metroButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroButton3.Location = new System.Drawing.Point(121, 79);
            this.metroButton3.Margin = new System.Windows.Forms.Padding(4);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(87, 26);
            this.metroButton3.TabIndex = 12;
            this.metroButton3.Text = "SMS SEND";
            this.metroButton3.UseSelectable = true;
            this.metroButton3.Click += new System.EventHandler(this.btnSendMultiSms_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroButton5.Location = new System.Drawing.Point(477, 28);
            this.metroButton5.Margin = new System.Windows.Forms.Padding(4);
            this.metroButton5.MaximumSize = new System.Drawing.Size(40, 37);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Size = new System.Drawing.Size(28, 23);
            this.metroButton5.TabIndex = 18;
            this.metroButton5.Text = "X";
            this.metroButton5.UseSelectable = true;
            this.metroButton5.Visible = false;
            this.metroButton5.Click += new System.EventHandler(this.btnDeleteEmail_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.saniyeNumericUpDown);
            this.groupBox1.Controls.Add(this.dakikaNumericUpDown);
            this.groupBox1.Controls.Add(this.saatNumericUpDown);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(813, 28);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.MaximumSize = new System.Drawing.Size(185, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(185, 57);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Timer";
            this.groupBox1.Visible = false;
            // 
            // saniyeNumericUpDown
            // 
            this.saniyeNumericUpDown.Location = new System.Drawing.Point(117, 23);
            this.saniyeNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.saniyeNumericUpDown.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.saniyeNumericUpDown.Name = "saniyeNumericUpDown";
            this.saniyeNumericUpDown.Size = new System.Drawing.Size(47, 22);
            this.saniyeNumericUpDown.TabIndex = 13;
            // 
            // dakikaNumericUpDown
            // 
            this.dakikaNumericUpDown.Location = new System.Drawing.Point(63, 23);
            this.dakikaNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.dakikaNumericUpDown.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.dakikaNumericUpDown.Name = "dakikaNumericUpDown";
            this.dakikaNumericUpDown.Size = new System.Drawing.Size(47, 22);
            this.dakikaNumericUpDown.TabIndex = 12;
            // 
            // saatNumericUpDown
            // 
            this.saatNumericUpDown.Location = new System.Drawing.Point(8, 23);
            this.saatNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.saatNumericUpDown.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.saatNumericUpDown.Name = "saatNumericUpDown";
            this.saatNumericUpDown.Size = new System.Drawing.Size(47, 22);
            this.saatNumericUpDown.TabIndex = 11;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(237, 58);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(233, 68);
            this.listBox1.TabIndex = 17;
            this.listBox1.Visible = false;
            // 
            // txtNewEmail
            // 
            this.txtNewEmail.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            // 
            // 
            // 
            this.txtNewEmail.CustomButton.BackColor = System.Drawing.SystemColors.ControlText;
            this.txtNewEmail.CustomButton.Image = null;
            this.txtNewEmail.CustomButton.Location = new System.Drawing.Point(211, 1);
            this.txtNewEmail.CustomButton.Name = "";
            this.txtNewEmail.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtNewEmail.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNewEmail.CustomButton.TabIndex = 1;
            this.txtNewEmail.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNewEmail.CustomButton.UseSelectable = true;
            this.txtNewEmail.CustomButton.UseVisualStyleBackColor = false;
            this.txtNewEmail.DisplayIcon = true;
            this.txtNewEmail.IconRight = true;
            this.txtNewEmail.Lines = new string[0];
            this.txtNewEmail.Location = new System.Drawing.Point(237, 28);
            this.txtNewEmail.MaxLength = 32767;
            this.txtNewEmail.Name = "txtNewEmail";
            this.txtNewEmail.PasswordChar = '\0';
            this.txtNewEmail.PromptText = "E-Mail Add";
            this.txtNewEmail.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNewEmail.SelectedText = "";
            this.txtNewEmail.SelectionLength = 0;
            this.txtNewEmail.SelectionStart = 0;
            this.txtNewEmail.ShortcutsEnabled = true;
            this.txtNewEmail.ShowButton = true;
            this.txtNewEmail.Size = new System.Drawing.Size(233, 23);
            this.txtNewEmail.TabIndex = 16;
            this.txtNewEmail.UseSelectable = true;
            this.txtNewEmail.Visible = false;
            this.txtNewEmail.WaterMark = "E-Mail Add";
            this.txtNewEmail.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNewEmail.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtNewEmail.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.metroTextBox1_ButtonClick);
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(1057, 415);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(59, 20);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Black;
            this.metroLabel1.TabIndex = 28;
            this.metroLabel1.Text = "MUC v2";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // key
            // 
            this.key.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.key.AutoSize = true;
            this.key.Location = new System.Drawing.Point(522, 4);
            this.key.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(33, 20);
            this.key.Style = MetroFramework.MetroColorStyle.Black;
            this.key.TabIndex = 7;
            this.key.Text = "KEY";
            this.key.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // kalanLabel
            // 
            this.kalanLabel.AutoSize = true;
            this.kalanLabel.Location = new System.Drawing.Point(4, 4);
            this.kalanLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kalanLabel.Name = "kalanLabel";
            this.kalanLabel.Size = new System.Drawing.Size(79, 20);
            this.kalanLabel.Style = MetroFramework.MetroColorStyle.Black;
            this.kalanLabel.TabIndex = 6;
            this.kalanLabel.Text = "Kalan Label";
            this.kalanLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel1.Controls.Add(this.key);
            this.panel1.Controls.Add(this.kalanLabel);
            this.panel1.Controls.Add(this.adminbtn);
            this.panel1.Controls.Add(this.saatLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1126, 31);
            this.panel1.TabIndex = 25;
            // 
            // adminbtn
            // 
            this.adminbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.adminbtn.BackgroundImage = global::BPET_PORTAL.Properties.Resources.icons8_admin_96;
            this.adminbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.adminbtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.adminbtn.Location = new System.Drawing.Point(1085, 0);
            this.adminbtn.Margin = new System.Windows.Forms.Padding(4);
            this.adminbtn.MaximumSize = new System.Drawing.Size(40, 37);
            this.adminbtn.Name = "adminbtn";
            this.adminbtn.Size = new System.Drawing.Size(37, 31);
            this.adminbtn.TabIndex = 27;
            this.adminbtn.UseSelectable = true;
            this.adminbtn.Click += new System.EventHandler(this.adminbtn_Click);
            // 
            // saatLabel
            // 
            this.saatLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saatLabel.AutoSize = true;
            this.saatLabel.Location = new System.Drawing.Point(999, 4);
            this.saatLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.saatLabel.Name = "saatLabel";
            this.saatLabel.Size = new System.Drawing.Size(71, 20);
            this.saatLabel.Style = MetroFramework.MetroColorStyle.Black;
            this.saatLabel.TabIndex = 3;
            this.saatLabel.Text = "Saat Label";
            this.saatLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // consoletxtbox
            // 
            this.consoletxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            // 
            // 
            // 
            this.consoletxtbox.CustomButton.Image = null;
            this.consoletxtbox.CustomButton.Location = new System.Drawing.Point(857, 1);
            this.consoletxtbox.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.consoletxtbox.CustomButton.Name = "";
            this.consoletxtbox.CustomButton.Size = new System.Drawing.Size(151, 151);
            this.consoletxtbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.consoletxtbox.CustomButton.TabIndex = 1;
            this.consoletxtbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.consoletxtbox.CustomButton.UseSelectable = true;
            this.consoletxtbox.CustomButton.Visible = false;
            this.consoletxtbox.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.consoletxtbox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.consoletxtbox.Lines = new string[] {
        "metroTextBox1"};
            this.consoletxtbox.Location = new System.Drawing.Point(28, 208);
            this.consoletxtbox.Margin = new System.Windows.Forms.Padding(4);
            this.consoletxtbox.MaximumSize = new System.Drawing.Size(1067, 153);
            this.consoletxtbox.MaxLength = 9999999;
            this.consoletxtbox.Multiline = true;
            this.consoletxtbox.Name = "consoletxtbox";
            this.consoletxtbox.PasswordChar = '\0';
            this.consoletxtbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.consoletxtbox.SelectedText = "";
            this.consoletxtbox.SelectionLength = 0;
            this.consoletxtbox.SelectionStart = 0;
            this.consoletxtbox.ShortcutsEnabled = true;
            this.consoletxtbox.Size = new System.Drawing.Size(1009, 153);
            this.consoletxtbox.TabIndex = 23;
            this.consoletxtbox.Text = "metroTextBox1";
            this.consoletxtbox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.consoletxtbox.UseSelectable = true;
            this.consoletxtbox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.consoletxtbox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // sms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(1126, 443);
            this.Controls.Add(this.adminpanel);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.consoletxtbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "sms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "sms";
            this.Load += new System.EventHandler(this.sms_Load);
            this.adminpanel.ResumeLayout(false);
            this.adminpanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.saniyeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dakikaNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saatNumericUpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button testmode;
        private System.Windows.Forms.GroupBox adminpanel;
        private System.Windows.Forms.Button clientmode;
        private MetroFramework.Controls.MetroButton metroButton4;
        private MetroFramework.Controls.MetroButton metroButton6;
        private MetroFramework.Controls.MetroButton sendtestbtn;
        private System.Windows.Forms.ListBox listBoxNumbers;
        private MetroFramework.Controls.MetroTextBox txtNewNumber;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroButton metroButton5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown saniyeNumericUpDown;
        private System.Windows.Forms.NumericUpDown dakikaNumericUpDown;
        private System.Windows.Forms.NumericUpDown saatNumericUpDown;
        private System.Windows.Forms.ListBox listBox1;
        private MetroFramework.Controls.MetroTextBox txtNewEmail;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton adminbtn;
        private MetroFramework.Controls.MetroLabel key;
        private MetroFramework.Controls.MetroLabel kalanLabel;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroLabel saatLabel;
        private System.Windows.Forms.Timer autoSendTimer;
        private MetroFramework.Controls.MetroTextBox consoletxtbox;
    }
}
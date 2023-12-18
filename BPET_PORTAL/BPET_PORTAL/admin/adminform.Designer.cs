namespace BPET_PORTAL.admin
{
    partial class adminform
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.livechat = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.txtAdminMessage = new MetroFramework.Controls.MetroTextBox();
            this.senduser = new System.Windows.Forms.Button();
            this.cmbAllUsers = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbUserList = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtAdminResponse = new MetroFramework.Controls.MetroTextBox();
            this.txtAdminChat = new System.Windows.Forms.RichTextBox();
            this.livechatbtn = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.livechat.SuspendLayout();
            this.SuspendLayout();
            // 
            // epostalabel
            // 
            this.epostalabel.AutoSize = true;
            this.epostalabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.epostalabel.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.epostalabel.Location = new System.Drawing.Point(0, 0);
            this.epostalabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.epostalabel.Name = "epostalabel";
            this.epostalabel.Size = new System.Drawing.Size(27, 16);
            this.epostalabel.TabIndex = 18;
            this.epostalabel.Text = "-----";
            this.epostalabel.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 98);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Silver;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1318, 475);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // livechat
            // 
            this.livechat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.livechat.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.livechat.Controls.Add(this.button3);
            this.livechat.Controls.Add(this.txtAdminMessage);
            this.livechat.Controls.Add(this.senduser);
            this.livechat.Controls.Add(this.cmbAllUsers);
            this.livechat.Controls.Add(this.button1);
            this.livechat.Controls.Add(this.cmbUserList);
            this.livechat.Controls.Add(this.button2);
            this.livechat.Controls.Add(this.txtAdminResponse);
            this.livechat.Controls.Add(this.txtAdminChat);
            this.livechat.Location = new System.Drawing.Point(388, 13);
            this.livechat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.livechat.Name = "livechat";
            this.livechat.Size = new System.Drawing.Size(933, 523);
            this.livechat.TabIndex = 20;
            this.livechat.Visible = false;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button3.BackColor = System.Drawing.Color.Orange;
            this.button3.Cursor = System.Windows.Forms.Cursors.Default;
            this.button3.Font = new System.Drawing.Font("Unispace", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.ForeColor = System.Drawing.Color.Navy;
            this.button3.Location = new System.Drawing.Point(607, 51);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.MaximumSize = new System.Drawing.Size(120, 30);
            this.button3.MinimumSize = new System.Drawing.Size(120, 30);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 30);
            this.button3.TabIndex = 12;
            this.button3.Text = "History";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtAdminMessage
            // 
            this.txtAdminMessage.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtAdminMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            // 
            // 
            // 
            this.txtAdminMessage.CustomButton.Image = null;
            this.txtAdminMessage.CustomButton.Location = new System.Drawing.Point(284, 1);
            this.txtAdminMessage.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAdminMessage.CustomButton.Name = "";
            this.txtAdminMessage.CustomButton.Size = new System.Drawing.Size(51, 51);
            this.txtAdminMessage.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAdminMessage.CustomButton.TabIndex = 1;
            this.txtAdminMessage.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAdminMessage.CustomButton.UseSelectable = true;
            this.txtAdminMessage.CustomButton.Visible = false;
            this.txtAdminMessage.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtAdminMessage.Lines = new string[0];
            this.txtAdminMessage.Location = new System.Drawing.Point(495, 81);
            this.txtAdminMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAdminMessage.MaximumSize = new System.Drawing.Size(336, 53);
            this.txtAdminMessage.MaxLength = 32767;
            this.txtAdminMessage.MinimumSize = new System.Drawing.Size(336, 53);
            this.txtAdminMessage.Multiline = true;
            this.txtAdminMessage.Name = "txtAdminMessage";
            this.txtAdminMessage.PasswordChar = '\0';
            this.txtAdminMessage.PromptText = "ADMİN Mesajınızı buraya yazınız...";
            this.txtAdminMessage.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAdminMessage.SelectedText = "";
            this.txtAdminMessage.SelectionLength = 0;
            this.txtAdminMessage.SelectionStart = 0;
            this.txtAdminMessage.ShortcutsEnabled = true;
            this.txtAdminMessage.ShowClearButton = true;
            this.txtAdminMessage.Size = new System.Drawing.Size(336, 53);
            this.txtAdminMessage.TabIndex = 11;
            this.txtAdminMessage.UseSelectable = true;
            this.txtAdminMessage.WaterMark = "ADMİN Mesajınızı buraya yazınız...";
            this.txtAdminMessage.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAdminMessage.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // senduser
            // 
            this.senduser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.senduser.BackColor = System.Drawing.Color.Orange;
            this.senduser.Cursor = System.Windows.Forms.Cursors.Default;
            this.senduser.Font = new System.Drawing.Font("Unispace", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.senduser.ForeColor = System.Drawing.Color.Navy;
            this.senduser.Location = new System.Drawing.Point(586, 158);
            this.senduser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.senduser.MaximumSize = new System.Drawing.Size(141, 30);
            this.senduser.MinimumSize = new System.Drawing.Size(141, 30);
            this.senduser.Name = "senduser";
            this.senduser.Size = new System.Drawing.Size(141, 30);
            this.senduser.TabIndex = 10;
            this.senduser.Text = "Send User";
            this.senduser.UseVisualStyleBackColor = false;
            this.senduser.Click += new System.EventHandler(this.senduser_Click);
            // 
            // cmbAllUsers
            // 
            this.cmbAllUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cmbAllUsers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbAllUsers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAllUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbAllUsers.FormattingEnabled = true;
            this.cmbAllUsers.Location = new System.Drawing.Point(463, 17);
            this.cmbAllUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbAllUsers.MaximumSize = new System.Drawing.Size(428, 0);
            this.cmbAllUsers.MinimumSize = new System.Drawing.Size(428, 0);
            this.cmbAllUsers.Name = "cmbAllUsers";
            this.cmbAllUsers.Size = new System.Drawing.Size(428, 30);
            this.cmbAllUsers.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button1.BackColor = System.Drawing.Color.Orange;
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.Font = new System.Drawing.Font("Unispace", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.Navy;
            this.button1.Location = new System.Drawing.Point(154, 53);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.MaximumSize = new System.Drawing.Size(120, 30);
            this.button1.MinimumSize = new System.Drawing.Size(120, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 30);
            this.button1.TabIndex = 8;
            this.button1.Text = "History";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnShowUserMessageHistory_Click);
            // 
            // cmbUserList
            // 
            this.cmbUserList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cmbUserList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbUserList.FormattingEnabled = true;
            this.cmbUserList.Location = new System.Drawing.Point(15, 17);
            this.cmbUserList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbUserList.MaximumSize = new System.Drawing.Size(428, 0);
            this.cmbUserList.MinimumSize = new System.Drawing.Size(428, 0);
            this.cmbUserList.Name = "cmbUserList";
            this.cmbUserList.Size = new System.Drawing.Size(428, 30);
            this.cmbUserList.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button2.BackColor = System.Drawing.Color.Orange;
            this.button2.Cursor = System.Windows.Forms.Cursors.Default;
            this.button2.Font = new System.Drawing.Font("Unispace", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ForeColor = System.Drawing.Color.Navy;
            this.button2.Location = new System.Drawing.Point(341, 479);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.MaximumSize = new System.Drawing.Size(103, 30);
            this.button2.MinimumSize = new System.Drawing.Size(103, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 30);
            this.button2.TabIndex = 6;
            this.button2.Text = "Send";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnAdminRespond_Click);
            // 
            // txtAdminResponse
            // 
            this.txtAdminResponse.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtAdminResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            // 
            // 
            // 
            this.txtAdminResponse.CustomButton.Image = null;
            this.txtAdminResponse.CustomButton.Location = new System.Drawing.Point(284, 1);
            this.txtAdminResponse.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAdminResponse.CustomButton.Name = "";
            this.txtAdminResponse.CustomButton.Size = new System.Drawing.Size(51, 51);
            this.txtAdminResponse.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAdminResponse.CustomButton.TabIndex = 1;
            this.txtAdminResponse.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAdminResponse.CustomButton.UseSelectable = true;
            this.txtAdminResponse.CustomButton.Visible = false;
            this.txtAdminResponse.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtAdminResponse.Lines = new string[0];
            this.txtAdminResponse.Location = new System.Drawing.Point(5, 464);
            this.txtAdminResponse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAdminResponse.MaximumSize = new System.Drawing.Size(336, 53);
            this.txtAdminResponse.MaxLength = 32767;
            this.txtAdminResponse.MinimumSize = new System.Drawing.Size(336, 53);
            this.txtAdminResponse.Multiline = true;
            this.txtAdminResponse.Name = "txtAdminResponse";
            this.txtAdminResponse.PasswordChar = '\0';
            this.txtAdminResponse.PromptText = "Mesajınızı buraya yazınız...";
            this.txtAdminResponse.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAdminResponse.SelectedText = "";
            this.txtAdminResponse.SelectionLength = 0;
            this.txtAdminResponse.SelectionStart = 0;
            this.txtAdminResponse.ShortcutsEnabled = true;
            this.txtAdminResponse.ShowClearButton = true;
            this.txtAdminResponse.Size = new System.Drawing.Size(336, 53);
            this.txtAdminResponse.TabIndex = 1;
            this.txtAdminResponse.UseSelectable = true;
            this.txtAdminResponse.WaterMark = "Mesajınızı buraya yazınız...";
            this.txtAdminResponse.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAdminResponse.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtAdminChat
            // 
            this.txtAdminChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtAdminChat.BackColor = System.Drawing.Color.White;
            this.txtAdminChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAdminChat.Location = new System.Drawing.Point(5, 81);
            this.txtAdminChat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAdminChat.MaximumSize = new System.Drawing.Size(439, 377);
            this.txtAdminChat.MinimumSize = new System.Drawing.Size(439, 377);
            this.txtAdminChat.Name = "txtAdminChat";
            this.txtAdminChat.ReadOnly = true;
            this.txtAdminChat.Size = new System.Drawing.Size(439, 377);
            this.txtAdminChat.TabIndex = 0;
            this.txtAdminChat.Text = "";
            // 
            // livechatbtn
            // 
            this.livechatbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.livechatbtn.BackColor = System.Drawing.Color.Orange;
            this.livechatbtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.livechatbtn.Font = new System.Drawing.Font("Unispace", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.livechatbtn.ForeColor = System.Drawing.Color.Navy;
            this.livechatbtn.Location = new System.Drawing.Point(1109, 540);
            this.livechatbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.livechatbtn.Name = "livechatbtn";
            this.livechatbtn.Size = new System.Drawing.Size(213, 43);
            this.livechatbtn.TabIndex = 7;
            this.livechatbtn.Text = "Admin Live Chat";
            this.livechatbtn.UseVisualStyleBackColor = false;
            this.livechatbtn.Click += new System.EventHandler(this.livechatbtn_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button4.ForeColor = System.Drawing.Color.Crimson;
            this.button4.Location = new System.Drawing.Point(12, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(213, 34);
            this.button4.TabIndex = 21;
            this.button4.Text = "YARDIM MASASI ADMİN";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // adminform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 586);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.livechat);
            this.Controls.Add(this.livechatbtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.epostalabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "adminform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "admin";
            this.Load += new System.EventHandler(this.adminform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.livechat.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label epostalabel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel livechat;
        private System.Windows.Forms.Button button2;
        private MetroFramework.Controls.MetroTextBox txtAdminResponse;
        private System.Windows.Forms.RichTextBox txtAdminChat;
        private System.Windows.Forms.Button livechatbtn;
        private System.Windows.Forms.ComboBox cmbUserList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbAllUsers;
        private System.Windows.Forms.Button senduser;
        private MetroFramework.Controls.MetroTextBox txtAdminMessage;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}
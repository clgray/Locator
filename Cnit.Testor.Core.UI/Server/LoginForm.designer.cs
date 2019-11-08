namespace Cnit.Testor.Core.UI
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.comboBoxUserName = new System.Windows.Forms.ComboBox();
            this.checkBoxSavePassword = new System.Windows.Forms.CheckBox();
            this.pictureBoxSplash = new System.Windows.Forms.PictureBox();
            this.labelServer = new System.Windows.Forms.Label();
            this.comboBoxServer = new System.Windows.Forms.ComboBox();
            this.linkLabelClearn = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplash)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(311, 187);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 3;
            this.buttonOk.Text = "Войти";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(392, 187);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(6, 128);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(106, 13);
            this.labelUserName.TabIndex = 8;
            this.labelUserName.Text = "Имя пользователя:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(6, 155);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(48, 13);
            this.labelPassword.TabIndex = 9;
            this.labelPassword.Text = "Пароль:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(117, 152);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(350, 20);
            this.textBoxPassword.TabIndex = 1;
            this.textBoxPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPassword_KeyPress);
            // 
            // comboBoxUserName
            // 
            this.comboBoxUserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxUserName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxUserName.FormattingEnabled = true;
            this.comboBoxUserName.Location = new System.Drawing.Point(117, 125);
            this.comboBoxUserName.Name = "comboBoxUserName";
            this.comboBoxUserName.Size = new System.Drawing.Size(350, 21);
            this.comboBoxUserName.TabIndex = 0;
            this.comboBoxUserName.SelectedIndexChanged += new System.EventHandler(this.comboBoxUserName_SelectedIndexChanged);
            this.comboBoxUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxUserName_KeyPress);
            this.comboBoxUserName.TextChanged += new System.EventHandler(this.comboBoxUserName_SelectedIndexChanged);
            // 
            // checkBoxSavePassword
            // 
            this.checkBoxSavePassword.AutoSize = true;
            this.checkBoxSavePassword.Location = new System.Drawing.Point(117, 178);
            this.checkBoxSavePassword.Name = "checkBoxSavePassword";
            this.checkBoxSavePassword.Size = new System.Drawing.Size(121, 17);
            this.checkBoxSavePassword.TabIndex = 2;
            this.checkBoxSavePassword.Text = "Запомнить пароль";
            this.checkBoxSavePassword.UseVisualStyleBackColor = true;
            // 
            // pictureBoxSplash
            // 
            this.pictureBoxSplash.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxSplash.ErrorImage = null;
            this.pictureBoxSplash.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSplash.Image")));
            this.pictureBoxSplash.InitialImage = null;
            this.pictureBoxSplash.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxSplash.Name = "pictureBoxSplash";
            this.pictureBoxSplash.Size = new System.Drawing.Size(479, 91);
            this.pictureBoxSplash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxSplash.TabIndex = 7;
            this.pictureBoxSplash.TabStop = false;
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.Location = new System.Drawing.Point(6, 101);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(47, 13);
            this.labelServer.TabIndex = 7;
            this.labelServer.Text = "Сервер:";
            // 
            // comboBoxServer
            // 
            this.comboBoxServer.FormattingEnabled = true;
            this.comboBoxServer.Items.AddRange(new object[] {
            "http://192.168.0.1"});
            this.comboBoxServer.Location = new System.Drawing.Point(117, 98);
            this.comboBoxServer.Name = "comboBoxServer";
            this.comboBoxServer.Size = new System.Drawing.Size(350, 21);
            this.comboBoxServer.TabIndex = 5;
            // 
            // linkLabelClearn
            // 
            this.linkLabelClearn.AutoSize = true;
            this.linkLabelClearn.Location = new System.Drawing.Point(6, 179);
            this.linkLabelClearn.Name = "linkLabelClearn";
            this.linkLabelClearn.Size = new System.Drawing.Size(100, 13);
            this.linkLabelClearn.TabIndex = 6;
            this.linkLabelClearn.TabStop = true;
            this.linkLabelClearn.Text = "Очистить историю";
            this.linkLabelClearn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelClearn_LinkClicked);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(479, 218);
            this.Controls.Add(this.linkLabelClearn);
            this.Controls.Add(this.comboBoxServer);
            this.Controls.Add(this.labelServer);
            this.Controls.Add(this.pictureBoxSplash);
            this.Controls.Add(this.checkBoxSavePassword);
            this.Controls.Add(this.comboBoxUserName);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplash)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.ComboBox comboBoxUserName;
        private System.Windows.Forms.CheckBox checkBoxSavePassword;
        private System.Windows.Forms.PictureBox pictureBoxSplash;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.ComboBox comboBoxServer;
        private System.Windows.Forms.LinkLabel linkLabelClearn;
    }
}


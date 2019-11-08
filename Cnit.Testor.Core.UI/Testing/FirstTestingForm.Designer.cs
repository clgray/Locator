namespace Cnit.Testor.Core.UI
{
    partial class FirstTestForm
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.labelSelectUser = new System.Windows.Forms.Label();
            this.textBoxStudentName = new System.Windows.Forms.TextBox();
            this.buttonSelectStudent = new System.Windows.Forms.Button();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.comboBoxUserType = new System.Windows.Forms.ComboBox();
            this.panel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::Cnit.Testor.Core.UI.Properties.Resources.usrcard;
            this.pictureBox.Location = new System.Drawing.Point(-4, 26);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(160, 165);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 13;
            this.pictureBox.TabStop = false;
            // 
            // labelSelectUser
            // 
            this.labelSelectUser.AutoSize = true;
            this.labelSelectUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSelectUser.Location = new System.Drawing.Point(145, 9);
            this.labelSelectUser.Name = "labelSelectUser";
            this.labelSelectUser.Size = new System.Drawing.Size(144, 24);
            this.labelSelectUser.TabIndex = 0;
            this.labelSelectUser.Text = "Пользователь:";
            // 
            // textBoxStudentName
            // 
            this.textBoxStudentName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxStudentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxStudentName.Location = new System.Drawing.Point(149, 80);
            this.textBoxStudentName.MaxLength = 50;
            this.textBoxStudentName.Name = "textBoxStudentName";
            this.textBoxStudentName.ReadOnly = true;
            this.textBoxStudentName.Size = new System.Drawing.Size(436, 29);
            this.textBoxStudentName.TabIndex = 0;
            // 
            // buttonSelectStudent
            // 
            this.buttonSelectStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelectStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSelectStudent.Location = new System.Drawing.Point(591, 75);
            this.buttonSelectStudent.Name = "buttonSelectStudent";
            this.buttonSelectStudent.Size = new System.Drawing.Size(131, 39);
            this.buttonSelectStudent.TabIndex = 1;
            this.buttonSelectStudent.Text = "Выбрать...";
            this.buttonSelectStudent.UseVisualStyleBackColor = true;
            this.buttonSelectStudent.Click += new System.EventHandler(this.buttonSelectStudent_Click);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPassword.Location = new System.Drawing.Point(145, 112);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(81, 24);
            this.labelPassword.TabIndex = 9;
            this.labelPassword.Text = "Пароль:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPassword.Location = new System.Drawing.Point(149, 139);
            this.textBoxPassword.MaxLength = 50;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(573, 29);
            this.textBoxPassword.TabIndex = 2;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(591, 179);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(131, 44);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Выход";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOK.Location = new System.Drawing.Point(454, 179);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(131, 44);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // comboBoxUserType
            // 
            this.comboBoxUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUserType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxUserType.FormattingEnabled = true;
            this.comboBoxUserType.Items.AddRange(new object[] {
            "Студент",
            "Лаборант/Преподаватель"});
            this.comboBoxUserType.Location = new System.Drawing.Point(149, 36);
            this.comboBoxUserType.Name = "comboBoxUserType";
            this.comboBoxUserType.Size = new System.Drawing.Size(573, 32);
            this.comboBoxUserType.TabIndex = 5;
            this.comboBoxUserType.SelectedIndexChanged += new System.EventHandler(this.comboBoxUserType_SelectedIndexChanged);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.comboBoxUserType);
            this.panel.Controls.Add(this.buttonOK);
            this.panel.Controls.Add(this.buttonCancel);
            this.panel.Controls.Add(this.textBoxPassword);
            this.panel.Controls.Add(this.labelPassword);
            this.panel.Controls.Add(this.buttonSelectStudent);
            this.panel.Controls.Add(this.textBoxStudentName);
            this.panel.Controls.Add(this.labelSelectUser);
            this.panel.Controls.Add(this.pictureBox);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(734, 233);
            this.panel.TabIndex = 14;
            // 
            // FirstTestForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(734, 233);
            this.ControlBox = false;
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FirstTestForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вход в систему";
            this.Shown += new System.EventHandler(this.FirstTestForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label labelSelectUser;
        private System.Windows.Forms.TextBox textBoxStudentName;
        private System.Windows.Forms.Button buttonSelectStudent;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ComboBox comboBoxUserType;
        private System.Windows.Forms.Panel panel;

    }
}
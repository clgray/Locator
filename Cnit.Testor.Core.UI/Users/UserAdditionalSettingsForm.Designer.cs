namespace Cnit.Testor.Core.UI.Users
{
    partial class UserAdditionalSettingsForm
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabControlUserData = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBoxStatus = new System.Windows.Forms.GroupBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.groupBoxUserData = new System.Windows.Forms.GroupBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxPassword2 = new System.Windows.Forms.TextBox();
            this.textBoxPassword1 = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxRole = new System.Windows.Forms.GroupBox();
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.tabPageGroupAdmin = new System.Windows.Forms.TabPage();
            this.buttonDel = new System.Windows.Forms.Button();
            this.dataGridViewGroups = new System.Windows.Forms.DataGridView();
            this.ColumnGroupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnGroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIsAdmin = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.buttonAddGroups = new System.Windows.Forms.Button();
            this.tabControlUserData.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBoxStatus.SuspendLayout();
            this.groupBoxUserData.SuspendLayout();
            this.groupBoxRole.SuspendLayout();
            this.tabPageGroupAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(446, 511);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 9;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(527, 511);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // tabControlUserData
            // 
            this.tabControlUserData.Controls.Add(this.tabPage1);
            this.tabControlUserData.Controls.Add(this.tabPageGroupAdmin);
            this.tabControlUserData.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControlUserData.Location = new System.Drawing.Point(0, 0);
            this.tabControlUserData.Name = "tabControlUserData";
            this.tabControlUserData.SelectedIndex = 0;
            this.tabControlUserData.Size = new System.Drawing.Size(610, 505);
            this.tabControlUserData.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBoxStatus);
            this.tabPage1.Controls.Add(this.groupBoxUserData);
            this.tabPage1.Controls.Add(this.groupBoxRole);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(602, 479);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Настройки учётной записи";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBoxStatus
            // 
            this.groupBoxStatus.Controls.Add(this.labelStatus);
            this.groupBoxStatus.Controls.Add(this.comboBoxStatus);
            this.groupBoxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxStatus.Location = new System.Drawing.Point(3, 186);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Size = new System.Drawing.Size(596, 290);
            this.groupBoxStatus.TabIndex = 7;
            this.groupBoxStatus.TabStop = false;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(6, 22);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(125, 13);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "Статус учётной записи:";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Items.AddRange(new object[] {
            "Не активный пользователь",
            "Интернет пользователь",
            "Пользователь удалён",
            "Локальный пользователь"});
            this.comboBoxStatus.Location = new System.Drawing.Point(137, 19);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(453, 21);
            this.comboBoxStatus.TabIndex = 8;
            // 
            // groupBoxUserData
            // 
            this.groupBoxUserData.Controls.Add(this.textBoxEmail);
            this.groupBoxUserData.Controls.Add(this.textBoxPassword2);
            this.groupBoxUserData.Controls.Add(this.textBoxPassword1);
            this.groupBoxUserData.Controls.Add(this.textBoxUserName);
            this.groupBoxUserData.Controls.Add(this.label4);
            this.groupBoxUserData.Controls.Add(this.label3);
            this.groupBoxUserData.Controls.Add(this.label2);
            this.groupBoxUserData.Controls.Add(this.label1);
            this.groupBoxUserData.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxUserData.Location = new System.Drawing.Point(3, 60);
            this.groupBoxUserData.Name = "groupBoxUserData";
            this.groupBoxUserData.Size = new System.Drawing.Size(596, 126);
            this.groupBoxUserData.TabIndex = 2;
            this.groupBoxUserData.TabStop = false;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEmail.Location = new System.Drawing.Point(118, 97);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(472, 20);
            this.textBoxEmail.TabIndex = 6;
            // 
            // textBoxPassword2
            // 
            this.textBoxPassword2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassword2.Location = new System.Drawing.Point(118, 71);
            this.textBoxPassword2.Name = "textBoxPassword2";
            this.textBoxPassword2.PasswordChar = '*';
            this.textBoxPassword2.Size = new System.Drawing.Size(472, 20);
            this.textBoxPassword2.TabIndex = 5;
            // 
            // textBoxPassword1
            // 
            this.textBoxPassword1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassword1.Location = new System.Drawing.Point(118, 45);
            this.textBoxPassword1.Name = "textBoxPassword1";
            this.textBoxPassword1.PasswordChar = '*';
            this.textBoxPassword1.Size = new System.Drawing.Size(472, 20);
            this.textBoxPassword1.TabIndex = 4;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUserName.Location = new System.Drawing.Point(118, 19);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(472, 20);
            this.textBoxUserName.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Повторите пароль:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Имя пользователя:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Пароль:";
            // 
            // groupBoxRole
            // 
            this.groupBoxRole.Controls.Add(this.comboBoxRole);
            this.groupBoxRole.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxRole.Location = new System.Drawing.Point(3, 3);
            this.groupBoxRole.Name = "groupBoxRole";
            this.groupBoxRole.Size = new System.Drawing.Size(596, 57);
            this.groupBoxRole.TabIndex = 0;
            this.groupBoxRole.TabStop = false;
            this.groupBoxRole.Text = "Роль";
            // 
            // comboBoxRole
            // 
            this.comboBoxRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRole.FormattingEnabled = true;
            this.comboBoxRole.Items.AddRange(new object[] {
            "Студент",
            "Лаборант",
            "Преподаватель",
            "Администратор"});
            this.comboBoxRole.Location = new System.Drawing.Point(6, 19);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new System.Drawing.Size(584, 21);
            this.comboBoxRole.TabIndex = 1;
            // 
            // tabPageGroupAdmin
            // 
            this.tabPageGroupAdmin.Controls.Add(this.buttonDel);
            this.tabPageGroupAdmin.Controls.Add(this.dataGridViewGroups);
            this.tabPageGroupAdmin.Controls.Add(this.buttonAddGroups);
            this.tabPageGroupAdmin.Location = new System.Drawing.Point(4, 22);
            this.tabPageGroupAdmin.Name = "tabPageGroupAdmin";
            this.tabPageGroupAdmin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGroupAdmin.Size = new System.Drawing.Size(602, 479);
            this.tabPageGroupAdmin.TabIndex = 1;
            this.tabPageGroupAdmin.Text = "Администрирование групп";
            this.tabPageGroupAdmin.UseVisualStyleBackColor = true;
            // 
            // buttonDel
            // 
            this.buttonDel.Enabled = false;
            this.buttonDel.Location = new System.Drawing.Point(8, 6);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(89, 23);
            this.buttonDel.TabIndex = 11;
            this.buttonDel.Text = "Удалить";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // dataGridViewGroups
            // 
            this.dataGridViewGroups.AllowUserToAddRows = false;
            this.dataGridViewGroups.AllowUserToDeleteRows = false;
            this.dataGridViewGroups.AllowUserToResizeRows = false;
            this.dataGridViewGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnGroupId,
            this.ColumnGroupName,
            this.ColumnIsAdmin});
            this.dataGridViewGroups.Location = new System.Drawing.Point(8, 35);
            this.dataGridViewGroups.Name = "dataGridViewGroups";
            this.dataGridViewGroups.RowHeadersVisible = false;
            this.dataGridViewGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGroups.Size = new System.Drawing.Size(586, 438);
            this.dataGridViewGroups.TabIndex = 13;
            this.dataGridViewGroups.SelectionChanged += new System.EventHandler(this.dataGridViewGroups_SelectionChanged);
            // 
            // ColumnGroupId
            // 
            this.ColumnGroupId.DataPropertyName = "ItemId";
            this.ColumnGroupId.HeaderText = "GroupId";
            this.ColumnGroupId.Name = "ColumnGroupId";
            this.ColumnGroupId.Visible = false;
            // 
            // ColumnGroupName
            // 
            this.ColumnGroupName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnGroupName.DataPropertyName = "ItemName";
            this.ColumnGroupName.HeaderText = "Группа";
            this.ColumnGroupName.Name = "ColumnGroupName";
            this.ColumnGroupName.ReadOnly = true;
            // 
            // ColumnIsAdmin
            // 
            this.ColumnIsAdmin.DataPropertyName = "IsGroupAdmin";
            this.ColumnIsAdmin.FalseValue = "False";
            this.ColumnIsAdmin.HeaderText = "Администратор?";
            this.ColumnIsAdmin.Name = "ColumnIsAdmin";
            this.ColumnIsAdmin.TrueValue = "True";
            // 
            // buttonAddGroups
            // 
            this.buttonAddGroups.Location = new System.Drawing.Point(447, 6);
            this.buttonAddGroups.Name = "buttonAddGroups";
            this.buttonAddGroups.Size = new System.Drawing.Size(147, 23);
            this.buttonAddGroups.TabIndex = 12;
            this.buttonAddGroups.Text = "Добавить группы...";
            this.buttonAddGroups.UseVisualStyleBackColor = true;
            this.buttonAddGroups.Click += new System.EventHandler(this.buttonAddGroups_Click);
            // 
            // UserAdditionalSettingsForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(610, 539);
            this.Controls.Add(this.tabControlUserData);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserAdditionalSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Дополнительные настройки";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserAdditionalSettingsForm_FormClosed);
            this.tabControlUserData.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBoxStatus.ResumeLayout(false);
            this.groupBoxStatus.PerformLayout();
            this.groupBoxUserData.ResumeLayout(false);
            this.groupBoxUserData.PerformLayout();
            this.groupBoxRole.ResumeLayout(false);
            this.tabPageGroupAdmin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroups)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TabControl tabControlUserData;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBoxRole;
        private System.Windows.Forms.ComboBox comboBoxRole;
        private System.Windows.Forms.TabPage tabPageGroupAdmin;
        private System.Windows.Forms.GroupBox groupBoxUserData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPassword1;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.GroupBox groupBoxStatus;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxPassword2;
        private System.Windows.Forms.DataGridView dataGridViewGroups;
        private System.Windows.Forms.Button buttonAddGroups;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGroupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGroupName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnIsAdmin;
    }
}
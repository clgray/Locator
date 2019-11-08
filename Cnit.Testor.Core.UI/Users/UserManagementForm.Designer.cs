namespace Cnit.Testor.Core.UI.Users
{
    partial class UserManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManagementForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.testorCoreUserBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonAddUser = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButtonChange = new System.Windows.Forms.ToolStripDropDownButton();
            this.userDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemAdditional = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonDeleteUser = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelRole = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxRole = new System.Windows.Forms.ToolStripComboBox();
            this.testorCoreUserDataGridView = new TestorUsersDataGrid();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripNext = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelSearch = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelGroup = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelCurrentGroup = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSelectGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testorCoreUserBindingNavigator)).BeginInit();
            this.testorCoreUserBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testorCoreUserDataGridView)).BeginInit();
            this.toolStripNext.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 470);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(904, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // testorCoreUserBindingNavigator
            // 
            this.testorCoreUserBindingNavigator.AddNewItem = null;
            this.testorCoreUserBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.testorCoreUserBindingNavigator.CountItemFormat = "из {0}";
            this.testorCoreUserBindingNavigator.DeleteItem = null;
            this.testorCoreUserBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.toolStripButtonAddUser,
            this.toolStripDropDownButtonChange,
            this.toolStripSeparator,
            this.toolStripButtonDeleteUser,
            this.toolStripSeparator1,
            this.toolStripLabelRole,
            this.toolStripComboBoxRole});
            this.testorCoreUserBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.testorCoreUserBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.testorCoreUserBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.testorCoreUserBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.testorCoreUserBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.testorCoreUserBindingNavigator.Name = "testorCoreUserBindingNavigator";
            this.testorCoreUserBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.testorCoreUserBindingNavigator.Size = new System.Drawing.Size(904, 25);
            this.testorCoreUserBindingNavigator.TabIndex = 2;
            this.testorCoreUserBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(36, 22);
            this.bindingNavigatorCountItem.Text = "из {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonAddUser
            // 
            this.toolStripButtonAddUser.Image = global::Cnit.Testor.Core.UI.Properties.Resources.user_add;
            this.toolStripButtonAddUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddUser.Name = "toolStripButtonAddUser";
            this.toolStripButtonAddUser.Size = new System.Drawing.Size(157, 22);
            this.toolStripButtonAddUser.Text = "Добавить пользователя";
            this.toolStripButtonAddUser.Click += new System.EventHandler(this.toolStripButtonAddUser_Click);
            // 
            // toolStripDropDownButtonChange
            // 
            this.toolStripDropDownButtonChange.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userDataToolStripMenuItem,
            this.toolStripMenuItem1,
            this.ToolStripMenuItemAdditional});
            this.toolStripDropDownButtonChange.Enabled = false;
            this.toolStripDropDownButtonChange.Image = global::Cnit.Testor.Core.UI.Properties.Resources.document_edit;
            this.toolStripDropDownButtonChange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonChange.Name = "toolStripDropDownButtonChange";
            this.toolStripDropDownButtonChange.Size = new System.Drawing.Size(90, 22);
            this.toolStripDropDownButtonChange.Text = "Изменить";
            // 
            // userDataToolStripMenuItem
            // 
            this.userDataToolStripMenuItem.Name = "userDataToolStripMenuItem";
            this.userDataToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.userDataToolStripMenuItem.Text = "Данные пользователя...";
            this.userDataToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonChange_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(237, 6);
            // 
            // ToolStripMenuItemAdditional
            // 
            this.ToolStripMenuItemAdditional.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripMenuItemAdditional.Name = "ToolStripMenuItemAdditional";
            this.ToolStripMenuItemAdditional.Size = new System.Drawing.Size(240, 22);
            this.ToolStripMenuItemAdditional.Text = "Дополнительные настройки...";
            this.ToolStripMenuItemAdditional.Click += new System.EventHandler(this.ToolStripMenuItemAdditional_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonDeleteUser
            // 
            this.toolStripButtonDeleteUser.Enabled = false;
            this.toolStripButtonDeleteUser.Image = global::Cnit.Testor.Core.UI.Properties.Resources.user_delete;
            this.toolStripButtonDeleteUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteUser.Name = "toolStripButtonDeleteUser";
            this.toolStripButtonDeleteUser.Size = new System.Drawing.Size(71, 22);
            this.toolStripButtonDeleteUser.Text = "Удалить";
            this.toolStripButtonDeleteUser.Click += new System.EventHandler(this.toolStripButtonDeleteUser_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabelRole
            // 
            this.toolStripLabelRole.Name = "toolStripLabelRole";
            this.toolStripLabelRole.Size = new System.Drawing.Size(37, 22);
            this.toolStripLabelRole.Text = "Роль:";
            // 
            // toolStripComboBoxRole
            // 
            this.toolStripComboBoxRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxRole.Items.AddRange(new object[] {
            "Студенты",
            "Лаборанты",
            "Преподаватели",
            "Администраторы",
            "Удалённые пользователи"});
            this.toolStripComboBoxRole.Name = "toolStripComboBoxRole";
            this.toolStripComboBoxRole.Size = new System.Drawing.Size(250, 25);
            this.toolStripComboBoxRole.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxRole_SelectedIndexChanged);
            // 
            // testorCoreUserDataGridView
            // 
            this.testorCoreUserDataGridView.AllowUserToAddRows = false;
            this.testorCoreUserDataGridView.AllowUserToDeleteRows = false;
            this.testorCoreUserDataGridView.AllowUserToResizeRows = false;
            this.testorCoreUserDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.testorCoreUserDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.testorCoreUserDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11});
            this.testorCoreUserDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testorCoreUserDataGridView.Location = new System.Drawing.Point(0, 50);
            this.testorCoreUserDataGridView.MultiSelect = false;
            this.testorCoreUserDataGridView.Name = "testorCoreUserDataGridView";
            this.testorCoreUserDataGridView.ReadOnly = true;
            this.testorCoreUserDataGridView.RowHeadersVisible = false;
            this.testorCoreUserDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.testorCoreUserDataGridView.Size = new System.Drawing.Size(904, 420);
            this.testorCoreUserDataGridView.TabIndex = 3;
            this.testorCoreUserDataGridView.SelectionChanged += new System.EventHandler(this.testorCoreUserDataGridView_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "UserId";
            this.dataGridViewTextBoxColumn1.HeaderText = "UserId";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "LastName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Фамилия";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "FirstName";
            this.dataGridViewTextBoxColumn3.HeaderText = "Имя";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "SecondName";
            this.dataGridViewTextBoxColumn4.HeaderText = "Отчество";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Login";
            this.dataGridViewTextBoxColumn5.HeaderText = "Логин";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn8.HeaderText = "Статус";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Email";
            this.dataGridViewTextBoxColumn10.HeaderText = "Email";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "StudNumber";
            this.dataGridViewTextBoxColumn11.HeaderText = "Номер студенческого";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 150;
            // 
            // toolStripNext
            // 
            this.toolStripNext.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripNext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelSearch,
            this.toolStripTextBoxSearch,
            this.toolStripSeparator2,
            this.toolStripLabelGroup,
            this.toolStripLabelCurrentGroup,
            this.toolStripSeparator3,
            this.toolStripButtonSelectGroup});
            this.toolStripNext.Location = new System.Drawing.Point(0, 25);
            this.toolStripNext.Name = "toolStripNext";
            this.toolStripNext.Size = new System.Drawing.Size(904, 25);
            this.toolStripNext.TabIndex = 4;
            this.toolStripNext.Text = "toolStrip1";
            // 
            // toolStripLabelSearch
            // 
            this.toolStripLabelSearch.Name = "toolStripLabelSearch";
            this.toolStripLabelSearch.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabelSearch.Text = "Поиск:";
            // 
            // toolStripTextBoxSearch
            // 
            this.toolStripTextBoxSearch.Name = "toolStripTextBoxSearch";
            this.toolStripTextBoxSearch.Size = new System.Drawing.Size(250, 25);
            this.toolStripTextBoxSearch.Enter += new System.EventHandler(this.toolStripTextBoxSearch_Enter);
            this.toolStripTextBoxSearch.TextChanged += new System.EventHandler(this.toolStripTextBoxSearch_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabelGroup
            // 
            this.toolStripLabelGroup.Name = "toolStripLabelGroup";
            this.toolStripLabelGroup.Size = new System.Drawing.Size(49, 22);
            this.toolStripLabelGroup.Text = "Группа:";
            // 
            // toolStripLabelCurrentGroup
            // 
            this.toolStripLabelCurrentGroup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.toolStripLabelCurrentGroup.Name = "toolStripLabelCurrentGroup";
            this.toolStripLabelCurrentGroup.Size = new System.Drawing.Size(72, 22);
            this.toolStripLabelCurrentGroup.Text = "не выбрана";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonSelectGroup
            // 
            this.toolStripButtonSelectGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSelectGroup.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSelectGroup.Image")));
            this.toolStripButtonSelectGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSelectGroup.Name = "toolStripButtonSelectGroup";
            this.toolStripButtonSelectGroup.Size = new System.Drawing.Size(99, 22);
            this.toolStripButtonSelectGroup.Text = "Выбрать группу";
            this.toolStripButtonSelectGroup.Click += new System.EventHandler(this.toolStripButtonSelectGroup_Click);
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(150, 16);
            // 
            // UserManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 492);
            this.Controls.Add(this.testorCoreUserDataGridView);
            this.Controls.Add(this.toolStripNext);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.testorCoreUserBindingNavigator);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserManagementForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление пользователями";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserManagementForm_FormClosed);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testorCoreUserBindingNavigator)).EndInit();
            this.testorCoreUserBindingNavigator.ResumeLayout(false);
            this.testorCoreUserBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testorCoreUserDataGridView)).EndInit();
            this.toolStripNext.ResumeLayout(false);
            this.toolStripNext.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.BindingNavigator testorCoreUserBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private TestorUsersDataGrid testorCoreUserDataGridView;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxRole;
        private System.Windows.Forms.ToolStripLabel toolStripLabelRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonChange;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAdditional;
        private System.Windows.Forms.ToolStripMenuItem userDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStrip toolStripNext;
        private System.Windows.Forms.ToolStripLabel toolStripLabelSearch;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonSelectGroup;
        private System.Windows.Forms.ToolStripLabel toolStripLabelGroup;
        private System.Windows.Forms.ToolStripLabel toolStripLabelCurrentGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
    }
}
using Cnit.Testor.Core.UI.Users;
using Cnit.Testor.Core;
namespace Cnit.Testor.Core.UI
{
    partial class ClientSelectUserForm
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
            Cnit.Testor.Core.Server.TestorTreeItem testorTreeItem1 = new Cnit.Testor.Core.Server.TestorTreeItem();
            this.toolStripNext = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelGroup = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelCurrentGroup = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSelectGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelSearch = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.testorCoreUserDataGridView = new Cnit.Testor.Core.UI.Users.TestorUsersDataGrid();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStudNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripNext.SuspendLayout();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testorCoreUserDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripNext
            // 
            this.toolStripNext.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripNext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelGroup,
            this.toolStripLabelCurrentGroup,
            this.toolStripSeparator3,
            this.toolStripButtonSelectGroup,
            this.toolStripSeparator2,
            this.toolStripLabelSearch,
            this.toolStripTextBoxSearch});
            this.toolStripNext.Location = new System.Drawing.Point(0, 0);
            this.toolStripNext.Name = "toolStripNext";
            this.toolStripNext.Size = new System.Drawing.Size(994, 25);
            this.toolStripNext.TabIndex = 5;
            this.toolStripNext.Text = "toolStrip1";
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
            this.toolStripButtonSelectGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSelectGroup.Name = "toolStripButtonSelectGroup";
            this.toolStripButtonSelectGroup.Size = new System.Drawing.Size(99, 22);
            this.toolStripButtonSelectGroup.Text = "Выбрать группу";
            this.toolStripButtonSelectGroup.Click += new System.EventHandler(this.toolStripButtonSelectGroup_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabelSearch
            // 
            this.toolStripLabelSearch.Name = "toolStripLabelSearch";
            this.toolStripLabelSearch.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabelSearch.Text = "Поиск:";
            // 
            // toolStripTextBoxSearch
            // 
            this.toolStripTextBoxSearch.MaxLength = 50;
            this.toolStripTextBoxSearch.Name = "toolStripTextBoxSearch";
            this.toolStripTextBoxSearch.Size = new System.Drawing.Size(250, 25);
            this.toolStripTextBoxSearch.TextChanged += new System.EventHandler(this.toolStripTextBoxSearch_TextChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOK.Location = new System.Drawing.Point(714, 12);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(131, 44);
            this.buttonOK.TabIndex = 13;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(851, 12);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(131, 44);
            this.buttonCancel.TabIndex = 14;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddUser.Location = new System.Drawing.Point(12, 12);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(259, 44);
            this.buttonAddUser.TabIndex = 15;
            this.buttonAddUser.Text = "Добавить пользователя";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.buttonCancel);
            this.panel.Controls.Add(this.buttonAddUser);
            this.panel.Controls.Add(this.buttonOK);
            this.panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel.Location = new System.Drawing.Point(0, 459);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(994, 65);
            this.panel.TabIndex = 16;
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
            this.ColumnStudNumber});
            this.testorCoreUserDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testorCoreUserDataGridView.Location = new System.Drawing.Point(0, 25);
            this.testorCoreUserDataGridView.MultiSelect = false;
            this.testorCoreUserDataGridView.Name = "testorCoreUserDataGridView";
            this.testorCoreUserDataGridView.ReadOnly = true;
            this.testorCoreUserDataGridView.RowHeadersVisible = false;
            testorTreeItem1.IsGroupAdmin = false;
            testorTreeItem1.ItemId = 0;
            testorTreeItem1.ItemName = "";
            testorTreeItem1.ItemOwner = null;
            testorTreeItem1.ItemType = Cnit.Testor.Core.TestorItemType.Group;
            testorTreeItem1.SubItems = new Cnit.Testor.Core.Server.TestorTreeItem[0];
            testorTreeItem1.TestId = 0;
            this.testorCoreUserDataGridView.SelectedGroup = testorTreeItem1;
            this.testorCoreUserDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.testorCoreUserDataGridView.Size = new System.Drawing.Size(994, 434);
            this.testorCoreUserDataGridView.TabIndex = 17;
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
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "SecondName";
            this.dataGridViewTextBoxColumn4.HeaderText = "Отчество";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // ColumnStudNumber
            // 
            this.ColumnStudNumber.DataPropertyName = "StudNumber";
            this.ColumnStudNumber.HeaderText = "№ студенческого";
            this.ColumnStudNumber.Name = "ColumnStudNumber";
            this.ColumnStudNumber.ReadOnly = true;
            this.ColumnStudNumber.Width = 150;
            // 
            // ClientSelectUserForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(994, 524);
            this.Controls.Add(this.testorCoreUserDataGridView);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.toolStripNext);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientSelectUserForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор пользователя";
            this.toolStripNext.ResumeLayout(false);
            this.toolStripNext.PerformLayout();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.testorCoreUserDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripNext;
        private System.Windows.Forms.ToolStripLabel toolStripLabelGroup;
        private System.Windows.Forms.ToolStripLabel toolStripLabelCurrentGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonSelectGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabelSearch;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Panel panel;
        private TestorUsersDataGrid testorCoreUserDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStudNumber;
    }
}
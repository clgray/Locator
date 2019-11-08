using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnit.Testor.Core.UI.Users;
using Cnit.Testor.Core.UI.Server;
using Cnit.Testor.Core.Server;
using Cnit.Testor.Core;

namespace Cnit.Testor.Core.UI
{
    public partial class ClientSelectUserForm : Form
    {
        private TestorTreeItem _selectedGroup = new TestorTreeItem(0, 0, String.Empty, TestorItemType.Group, null);
        private TestorCoreUser _resultUser;

        public TestorCoreUser ResultUser
        {
            get
            {
                return _resultUser;
            }
        }

        public ClientSelectUserForm()
        {
            InitializeComponent();
            testorCoreUserDataGridView.InitTestorCoreUsers();
            testorCoreUserDataGridView.SelectedGroupChanged += new EventHandler<EventArgs>(testorCoreUserDataGridView_SelectedGroupChanged);
            testorCoreUserDataGridView.UsersGetted += new EventHandler<EventArgs>(testorCoreUserDataGridView_UsersGetted);
            testorCoreUserDataGridView.GetUsers(TestorUserRole.Student, TestorUserStatus.LocalNetUser, false);
            if (Screen.PrimaryScreen.WorkingArea.Width<=800)
            {
                this.Width = 798;
                this.Height = 425;
            }
        }

        void testorCoreUserDataGridView_UsersGetted(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(toolStripTextBoxSearch.Text.Trim()))
                toolStripTextBoxSearch_TextChanged(this, new EventArgs());
            else
                toolStripTextBoxSearch.Text = String.Empty;
        }

        void testorCoreUserDataGridView_SelectedGroupChanged(object sender, EventArgs e)
        {
            if (testorCoreUserDataGridView.SelectedGroup.ItemId != 0)
                toolStripLabelCurrentGroup.Text = testorCoreUserDataGridView.SelectedGroup.ItemName;
            else
                toolStripLabelCurrentGroup.Text = "не выбрана";
            testorCoreUserDataGridView.GetUsers(TestorUserRole.Student,TestorUserStatus.LocalNetUser, false);
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm();
            if (addUserForm.ShowDialog() != DialogResult.OK)
                return;
            _resultUser = addUserForm.ResultUser;
            this.DialogResult = DialogResult.OK;
        }

        private void toolStripButtonSelectGroup_Click(object sender, EventArgs e)
        {
            testorCoreUserDataGridView.SelectGroup();
        }

        private void toolStripTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            testorCoreUserDataGridView.FindUsers(toolStripTextBoxSearch.Text);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            _resultUser = testorCoreUserDataGridView.SelectedUser;
            if (_resultUser != null)
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.Cancel;
        }
    }
}

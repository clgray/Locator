using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Cnit.Testor.Core.UI.Server;
using Cnit.Testor.Core.Server;

namespace Cnit.Testor.Core.UI.Users
{
    public partial class UserManagementForm : Form
    {
        private Thread _currentThread;
        private bool _getRemoved;

        public UserManagementForm()
        {
            InitializeComponent();
            SystemStateManager.StateChanged+=new EventHandler<EventArgs>(SystemStateManager_StateChanged);
            toolStripComboBoxRole.SelectedIndex = 0;
            testorCoreUserDataGridView.InitTestorCoreUsers();
            testorCoreUserDataGridView.SelectedGroupChanged += new EventHandler<EventArgs>(testorCoreUserDataGridView_SelectedGroupChanged);
            testorCoreUserDataGridView.UsersGetted += new EventHandler<EventArgs>(testorCoreUserDataGridView_UsersGetted);
        }

        void testorCoreUserDataGridView_UsersGetted(object sender, EventArgs e)
        {
            if (toolStripTextBoxSearch.Text.Trim() == String.Empty)
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
            testorCoreUserDataGridView.GetUsers(TestorUserRole.Student, TestorUserStatus.Any, false);
        }

        void SystemStateManager_StateChanged(object sender, EventArgs e)
        {
            toolStripProgressBar.Style = SystemStateManager.State == true ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks;
        }

        private void toolStripButtonAddUser_Click(object sender, EventArgs e)
        {
            if (SystemStateManager.TestState())
                return;
            AddUserForm addUser = new AddUserForm();
            if (addUser.ShowDialog() == DialogResult.OK)
            {
                testorCoreUserDataGridView.AddUser(addUser.ResultUser);
                if (toolStripComboBoxRole.SelectedIndex == 0)
                {
                    testorCoreUserBindingNavigator.BindingSource.CurrencyManager.Refresh();
                }
            }
        }

        private void toolStripButtonChange_Click(object sender, EventArgs e)
        {
            if (SystemStateManager.TestState())
                return;
            AddUserForm addUser = new AddUserForm(testorCoreUserDataGridView.SelectedUser);
            addUser.ShowDialog();
            testorCoreUserDataGridView.CurrentBindingSource.CurrencyManager.Refresh();
        }

        private void UserManagementForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SystemStateManager.StateChanged -= new EventHandler<EventArgs>(SystemStateManager_StateChanged);
        }

        private void toolStripComboBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            _getRemoved = false;
            TestorUserRole selectedRole = TestorUserRole.NotDefined;
            if (toolStripComboBoxRole.SelectedIndex != toolStripComboBoxRole.Items.Count - 1)
                selectedRole = (TestorUserRole)toolStripComboBoxRole.SelectedIndex + 1;
            else
                _getRemoved = true;
            testorCoreUserDataGridView.GetUsers(selectedRole, TestorUserStatus.Any, _getRemoved);
        }

        private void ToolStripMenuItemAdditional_Click(object sender, EventArgs e)
        {
            if (SystemStateManager.TestState())
                return;
            var row = testorCoreUserDataGridView.SelectedRows[0];
            TestorCoreUser selUser = testorCoreUserDataGridView.SelectedUser;
            TestorUserRole role = selUser.UserRole;
            TestorUserStatus status = selUser.Status;
            UserAdditionalSettingsForm settingsForm = new UserAdditionalSettingsForm(selUser);
            if (settingsForm.ShowDialog() != DialogResult.OK)
                return;
            if (settingsForm.User.UserRole != role || (settingsForm.User.Status == TestorUserStatus.Removed && status != TestorUserStatus.Removed)
                || (status == TestorUserStatus.Removed && settingsForm.User.Status != TestorUserStatus.Removed))
                testorCoreUserDataGridView.Rows.Remove(row);
            selUser.SetSettings(settingsForm.User);
            toolStripTextBoxSearch_TextChanged(this, new EventArgs());
        }

        private void toolStripButtonDeleteUser_Click(object sender, EventArgs e)
        {
            if (SystemStateManager.TestState())
                return;
            var selUser = testorCoreUserDataGridView.SelectedUser;
            if (MessageBox.Show(String.Format("Вы действительно хотите удалить пользователя \"{0} {1} {2}\"?",
                selUser.LastName, selUser.FirstName, selUser.SecondName), "Удаление пользователя", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            SystemStateManager.OnStateChanged(true);
            _currentThread = new Thread(new ThreadStart(() =>
            {
                try
                {
                    StaticServerProvider.UserManagement.RemoveUser(testorCoreUserDataGridView.SelectedUser.UserId);
                    if ((this.TopLevelControl as Form).IsHandleCreated)
                    {
                        this.Invoke((Action)(() =>
                        {
                            testorCoreUserDataGridView.Rows.Remove(testorCoreUserDataGridView.SelectedRows[0]);
                            SystemStateManager.OnStateChanged(false);
                        }));
                    }
                }
                catch (Exception ex)
                {
                    if ((this.TopLevelControl as Form).IsHandleCreated)
                    {
                        this.Invoke((Action)(() =>
                        {
                            SystemMessage.ShowErrorMessage(ex);
                            SystemStateManager.OnStateChanged(false);
                        }));
                    }
                }
            }));
            _currentThread.Start();
        }

        private void testorCoreUserDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            bool hasRow = testorCoreUserDataGridView.SelectedRows.Count > 0;
            toolStripButtonDeleteUser.Enabled = hasRow;
            toolStripDropDownButtonChange.Enabled = hasRow;
            if (_getRemoved || (hasRow && StaticServerProvider.CurrentUser.UserId == testorCoreUserDataGridView.SelectedUser.UserId))
                toolStripButtonDeleteUser.Enabled = false;
        }

        private void toolStripButtonSelectGroup_Click(object sender, EventArgs e)
        {
            testorCoreUserDataGridView.SelectGroup();
        }

        private void toolStripTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            testorCoreUserDataGridView.FindUsers(toolStripTextBoxSearch.Text);
            testorCoreUserBindingNavigator.BindingSource = null;
            testorCoreUserBindingNavigator.BindingSource = testorCoreUserDataGridView.CurrentBindingSource;
        }

        private void toolStripTextBoxSearch_Enter(object sender, EventArgs e)
        {
            if (SystemStateManager.TestState())
                return;
        }
    }
}

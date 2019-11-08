using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnit.Testor.Core.UI.Server;
using System.Threading;
using Cnit.Testor.Core.Server;

namespace Cnit.Testor.Core.UI.Users
{
    public partial class UserAdditionalSettingsForm : Form
    {
        private TestorCoreUser _user;
        private Thread _currentThread;
        private string _defaultPassword = "         ";
        private List<TestorTreeItem> _userGroups;

        private BindingSource _bindingSource = new BindingSource();

        public TestorCoreUser User
        {
            get
            {
                return _user;
            }
        }

        private void SetAccessMode()
        {
            if (StaticServerProvider.CurrentUser.UserRole != TestorUserRole.Administrator)
                comboBoxRole.Enabled = false;
            if (_user.UserRole == TestorUserRole.Student || StaticServerProvider.CurrentUser.UserRole != TestorUserRole.Administrator)
                tabControlUserData.TabPages.Remove(tabPageGroupAdmin);
        }

        public UserAdditionalSettingsForm(TestorCoreUser user)
        {
            InitializeComponent();
            _user = new TestorCoreUser(user);
            SetAccessMode();
            _userGroups = new List<TestorTreeItem>();
            dataGridViewGroups.AutoGenerateColumns = false;
            comboBoxRole.SelectedIndex = (int)_user.UserRole - 1;
            comboBoxStatus.SelectedIndex = (int)_user.Status;
            textBoxUserName.DataBindings.Add("Text", _user, "Login", false);
            textBoxEmail.DataBindings.Add("Text", _user, "Email", false);
            textBoxPassword1.Text = _defaultPassword;
            textBoxPassword2.Text = _defaultPassword;
            SystemStateManager.OnStateChanged(true);
            SynchronizationContext context = SynchronizationContext.Current;
            _currentThread = new Thread(new ThreadStart(() =>
            {
                try
                {
                    _userGroups.AddRange(StaticServerProvider.UserManagement.GetUserGroups(_user.UserId));
                    context.Send(d =>
                    {
                        _bindingSource.DataSource = _userGroups;
                        dataGridViewGroups.DataSource = _bindingSource;
                        SystemStateManager.OnStateChanged(false);
                    }, null);
                }
                catch (Exception ex)
                {
                    context.Send(d =>
                    {
                        SystemMessage.ShowErrorMessage(d as Exception);
                        SystemStateManager.OnStateChanged(false);
                    }, ex);

                }
            }));
            _currentThread.Start();
            SystemStateManager.StateChanged += new EventHandler<EventArgs>(SystemStateManager_StateChanged);
        }

        void SystemStateManager_StateChanged(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
                control.Enabled = !SystemStateManager.State;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SynchronizationContext context = SynchronizationContext.Current;
            _user.UserRole = (TestorUserRole)comboBoxRole.SelectedIndex + 1;
            _user.Status = (TestorUserStatus)comboBoxStatus.SelectedIndex;
            if (textBoxPassword1.Text != _defaultPassword || textBoxPassword2.Text != _defaultPassword)
            {
                if (textBoxPassword1.Text != textBoxPassword2.Text)
                {
                    SystemMessage.ShowWarningMessage("Пароли не совпадают.");
                    return;
                }
                else
                {
                    _user.Password = textBoxPassword1.Text;
                }
            }
            _user.UserGroups = _userGroups.ToArray();
            SystemStateManager.OnStateChanged(true);
            _currentThread = new Thread(new ThreadStart(() =>
            {
                try
                {
                    _user = StaticServerProvider.UserManagement.AlterUser(_user, true);
                    context.Send(d =>
                    {
                        SystemStateManager.OnStateChanged(false);
                        this.DialogResult = DialogResult.OK;
                    }, null);
                }
                catch (Exception ex)
                {
                    context.Send(d =>
                    {
                        SystemMessage.ShowErrorMessage(d as Exception);
                        SystemStateManager.OnStateChanged(false);
                    }, ex);

                }
            }));
            _currentThread.Start();
        }

        private void UserAdditionalSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SystemStateManager.StateChanged -= new EventHandler<EventArgs>(SystemStateManager_StateChanged);
        }

        private void buttonAddGroups_Click(object sender, EventArgs e)
        {
            SelectItemsForm selectForm = new SelectItemsForm(TestingServerItemType.GroupTree);
            if (selectForm.ShowDialog() != DialogResult.OK)
                return;
            TestorTreeItem[] items = selectForm.TestorTreeItems;
            foreach (var item in items)
            {
                item.IsGroupAdmin = false;
                if (_userGroups.Where(c => c.ItemId == item.ItemId).Count() <= 0)
                    _userGroups.Add(item);
            }
            _bindingSource.CurrencyManager.Refresh();
        }

        private void dataGridViewGroups_SelectionChanged(object sender, EventArgs e)
        {
            bool hasItems = dataGridViewGroups.SelectedRows.Count > 0;
            buttonDel.Enabled = hasItems;
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            _userGroups.Remove(
            _userGroups.Where(c => c.ItemId == int.Parse(dataGridViewGroups.SelectedRows[0].Cells[0].Value.ToString())).First());
            _bindingSource.CurrencyManager.Refresh(); 
        }
    }
}

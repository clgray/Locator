using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnit.Testor.Core.Server;
using System.Threading;
using Cnit.Testor.Core.UI.Server;
using System.ComponentModel;
using Cnit.Testor.Core.Packaging;

namespace Cnit.Testor.Core.UI.Users
{
    public sealed class TestorUsersDataGrid : DataGridView
    {
        private List<TestorCoreUser> _users = new List<TestorCoreUser>();
        private BindingSource _bindingSource = new BindingSource();
        private TestorTreeItem _selectedGroup = new TestorTreeItem(0, 0, String.Empty, TestorItemType.Group, null);
        private Thread _currentThread;

        public event EventHandler<EventArgs> SelectedGroupChanged;
        public event EventHandler<EventArgs> UsersGetted;

        public BindingSource CurrentBindingSource
        {
            get
            {
                return _bindingSource;
            }
        }

        public TestorTreeItem SelectedGroup
        {
            get
            {
                return _selectedGroup;
            }
            set
            {
                _selectedGroup = value;
            }
        }

        public TestorCoreUser SelectedUser
        {
            get
            {
                return _bindingSource.Current as TestorCoreUser;
            }
        }

        public void AddUser(TestorCoreUser user)
        {
            _users.Add(user);
        }

        public void InitTestorCoreUsers()
        {
            this.AutoGenerateColumns = false;
            _bindingSource.DataSource = _users;
            this.DataSource = _bindingSource;
        }

        public void GetUsers(TestorUserRole selectedRole, TestorUserStatus status, bool getRemoved)
        {
            if (SystemStateManager.TestState())
                return;
            this.CurrentBindingSource.DataSource = null;
            SystemStateManager.OnStateChanged(true);
            _currentThread = new Thread(new ThreadStart(() =>
            {
                try
                {
                    _users.Clear();
                    _users.InsertRange(0, DataCompressor.DecompressData<TestorCoreUser[]>(StaticServerProvider.UserManagement.FindUsers(
                        String.Empty, selectedRole, status, getRemoved,
                        this.SelectedGroup.ItemId, 0)));
                    if ((this.TopLevelControl as Form).IsHandleCreated)
                    {
                        this.Invoke((Action)(() =>
                        {
                            OnUsersGetted();
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

        public void SelectGroup()
        {
            TestorTreeItem group = SelectedGroup;
            if (SystemStateManager.TestState())
                return;
            SelectSingleItemForm selectGroup = new SelectSingleItemForm(TestingServerItemType.GroupTree);
            if (selectGroup.ShowDialog() == DialogResult.Cancel)
            {
                SelectedGroup = new TestorTreeItem(0, 0, String.Empty, TestorItemType.Group, null);
                if (group.ItemId != SelectedGroup.ItemId)
                    OnSelectedGroupChanged();
                return;
            }
            this.SelectedGroup = selectGroup.SelectedItem;
            if (this.SelectedGroup == null)
            {
                this.CurrentBindingSource.DataSource = _users;
                this.SelectedGroup = new TestorTreeItem(0, 0, String.Empty, TestorItemType.Group, null);
            }
            if (group.ItemId != SelectedGroup.ItemId)
            {
                this.CurrentBindingSource.CurrencyManager.Refresh();
                OnSelectedGroupChanged();
            }
        }

        public void FindUsers(string prefix)
        {
            if (prefix.Trim() == String.Empty)
                this.CurrentBindingSource.DataSource = _users;
            else
            {
                var users = _users.Where(c => c.LastName.StartsWith(prefix));
                this.CurrentBindingSource.DataSource = users;
            }
            this.CurrentBindingSource.CurrencyManager.Refresh();
        }
        
        public void OnSelectedGroupChanged()
        {
            if (SelectedGroupChanged != null)
                SelectedGroupChanged(this, new EventArgs());
        }

        public void OnUsersGetted()
        {
            if (UsersGetted != null)
                UsersGetted(this, new EventArgs());
        }
    }
}

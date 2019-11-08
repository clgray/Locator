using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnit.Testor.Core.UI.Server;
using Cnit.Testor.Core.Server;
using System.Threading;

namespace Cnit.Testor.Core.UI.Users
{
    public partial class AddUserForm : Form
    {
        private TestorTreeItem[] _groups;
        private TestorTreeItem _selectedGroup;
        private string _lastName;
        private string _firstName;
        private string _secondName;
        private string _studNumber;
        private string _password;
        private string _password2;
        private DateTime _birthday;
        private bool _gender;
        private bool _isOnlineMode = true;
        private TestorCoreUser _resultUser;

        private Thread _currentThread;
        private bool _isAlterMode;

        public TestorCoreUser ResultUser
        {
            get
            {
                if (_resultUser == null)
                    _resultUser = new TestorCoreUser();
                _resultUser.LastName = _lastName;
                _resultUser.FirstName = _firstName;
                _resultUser.SecondName = _secondName;
                _resultUser.Sex = _gender;
                _resultUser.Birthday = _birthday;
                _resultUser.StudNumber = _studNumber;
                _resultUser.Password = _password;
                if (_groups == null)
                    _resultUser.UserGroups = new TestorTreeItem[] { _selectedGroup };
                else
                    _resultUser.UserGroups = _groups;
                _resultUser.IsLocalUser = true;
                return _resultUser;
            }
        }

        public AddUserForm(bool isOnlineMode)
            : this()
        {
            _isOnlineMode = isOnlineMode;
            if (!_isOnlineMode)
            {
                buttonSelectGroup.Enabled = false;
                textBoxPassword1.Enabled = false;
                textBoxPassword2.Enabled = false;
            }
        }

        public AddUserForm(TestorCoreUser user)
            : this()
        {
            _isAlterMode = true;
            _resultUser = user;
            textBoxLastName.Text = _resultUser.LastName;
            textBoxFirstName.Text = _resultUser.FirstName;
            textBoxSecondName.Text = _resultUser.SecondName;
            radioButtonMale.Checked = _resultUser.Sex;
            radioButtonFemale.Checked = !_resultUser.Sex;
            dateTimePickerBirthday.Value = _resultUser.Birthday >= dateTimePickerBirthday.MinDate ? _resultUser.Birthday : dateTimePickerBirthday.MinDate;
            textBoxStudNumber.Text = _resultUser.StudNumber;
            SynchronizationContext context = SynchronizationContext.Current;
            SystemStateManager.OnStateChanged(true);
            _currentThread = new Thread(new ThreadStart(() =>
            {
                try
                {
                    _groups = StaticServerProvider.UserManagement.GetUserGroups(_resultUser.UserId);
                    context.Send(d =>
                    {
                        if (_groups.Length > 0)
                        {
                            _selectedGroup = (d as TestorTreeItem[])[0];
                            textBoxGroup.Text = _selectedGroup.ItemName;
                        }
                        SystemStateManager.OnStateChanged(false);
                    }, _groups);
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
            buttonSelectGroup.Enabled = !_isAlterMode;
        }

        public AddUserForm()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            _lastName = textBoxLastName.Text.Trim();
            _firstName = textBoxFirstName.Text.Trim();
            _secondName = textBoxSecondName.Text.Trim();
            _birthday = dateTimePickerBirthday.Value;
            _studNumber = textBoxStudNumber.Text.Trim();
            _password = textBoxPassword1.Text;
            _password2 = textBoxPassword2.Text;
            _gender = radioButtonMale.Checked;

            if (_password != String.Empty || _password2 != String.Empty)
            {
                if (_password != _password2)
                {
                    SystemMessage.ShowWarningMessage("Пароли не совпадают.");
                    textBoxPassword1.Text = String.Empty;
                    textBoxPassword2.Text = String.Empty;
                    return;
                }
            }
            else if (!_isAlterMode)
                _password = "{@#emptypassword#}";

            labelStarLastName.Visible = String.IsNullOrEmpty(_lastName);
            labelStarFirstName.Visible = String.IsNullOrEmpty(_firstName);
            if (_isOnlineMode && !_isAlterMode)
                labelStarGroup.Visible = _selectedGroup == null;
            labelNumber.Visible = String.IsNullOrEmpty(_studNumber);
            if (labelStarLastName.Visible || labelStarFirstName.Visible ||
                labelStarGroup.Visible || labelNumber.Visible)
            {
                SystemMessage.ShowWarningMessage("Для добавления пользователя заполните обязательные поля.");
            }
            else
            {
                if (_isOnlineMode)
                    AddUser();
                else
                {
                    _resultUser = new TestorCoreUser()
                    {
                        FirstName = _firstName,
                        LastName = _lastName,
                        SecondName = _secondName,
                        Sex = _gender,
                        Status = TestorUserStatus.LocalNetUser,
                        StudNumber = _studNumber,
                        UserRole = TestorUserRole.Student,
                        Password = _password
                    };
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        public void AddUser()
        {
            SynchronizationContext context = SynchronizationContext.Current;
            SystemStateManager.OnStateChanged(true);
            _currentThread = new Thread(new ThreadStart(() =>
            {
                try
                {
                    TestorCoreUser user = ResultUser;
                    if (!_isAlterMode)
                        _resultUser = StaticServerProvider.UserManagement.CreateUser(user);
                    else
                        StaticServerProvider.UserManagement.AlterUser(_resultUser, true);
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

        private void buttonSelectGroup_Click(object sender, EventArgs e)
        {
            SelectSingleItemForm selectGroup = new SelectSingleItemForm(TestingServerItemType.GroupTree);
            if (selectGroup.ShowDialog() != DialogResult.OK)
                return;
            _selectedGroup = selectGroup.SelectedItem;
            if (_selectedGroup != null)
                textBoxGroup.Text = _selectedGroup.ItemName;
            else
                textBoxGroup.Text = String.Empty;
        }
    }
}

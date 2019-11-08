using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnit.Testor.Core;
using Cnit.Testor.Core.UI.Server;
using Cnit.Testor.Core.Server;
using Cnit.Testor.Core.HttpServer.TestingProviders;
using Cnit.Testor.Core.UI.Testing;
using Cnit.Testor.Core.UI.Server.Login;
using Cnit.Testor.Core.UI;
using System.Threading;

namespace Cnit.Testor.Core.UI
{
    public partial class FirstTestForm : Form
    {
        private EditMainForm _mainForm;
        private TestorCoreUser _resultUser;
        private TestorTreeItem _selectedTest;
        private string _userName;
        private string _password;

        public bool IsTeacherMode { get; set; }

        public TestorCoreUser ResultUser
        {
            get
            {
                return _resultUser;
            }
        }

        public FirstTestForm()
        {
            InitializeComponent();
            comboBoxUserType.SelectedIndex = 0;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Выход из системы", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                this.MdiParent.Close();
        }

        private void buttonSelectStudent_Click(object sender, EventArgs e)
        {
            ClientSelectUserForm selectUser = new ClientSelectUserForm();
            if (selectUser.ShowDialog() != DialogResult.OK)
                return;
            _resultUser = selectUser.ResultUser;
            textBoxStudentName.Text = String.Format("{0} {1} {2}", HtmlStore.GetString(_resultUser.LastName),
                 HtmlStore.GetString(_resultUser.FirstName), HtmlStore.GetString(_resultUser.SecondName));
        }

        private void FirstTestForm_Shown(object sender, EventArgs e)
        {
            _mainForm = this.MdiParent as EditMainForm;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            _password = textBoxPassword.Text;
            if (!IsTeacherMode)
            {
                if (_resultUser == null)
                {
                    MessageBox.Show("Для начала тестирования необходимо выбрать пользователя.",
                        "Выбор пользователя", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                SetChildEnable(false);
                StaticServerProvider.Logout();
                LoginProvider loginProvider = LoginProvider.Login(_resultUser.Login, textBoxPassword.Text, LoginHelper.Server, LoginHelper.SEND_TIMEOUT, null,
                    new LoginProvider.LoginResultDelegate((hasPassword, errorMessage) =>
                    {
                        this.Invoke((Action)(() =>
                        {
                            if (hasPassword)
                            {
                                if (String.IsNullOrEmpty(LoginHelper.Server))
                                {
                                    string[] databases = StaticServerProvider.TestClient.GetDatabaseNamesList();
                                    if (databases.Length > 0)
                                    {
                                        string dbPassword = StaticServerProvider.TestClient.GetDatabasePassword(databases[0]);
                                        using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(String.Format(
                                            "Data Source=(local);Initial Catalog={0};User ID=testingUser;Password={1}", databases[0], dbPassword)))
                                        {
                                            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("EXEC InitDbSettings;", conn);
                                            conn.Open();
                                            cmd.ExecuteNonQuery();
                                            conn.Close();
                                            Console.WriteLine(cmd.ExecuteScalar());
                                        }
                                    }
                                }
                                StartTestParams ncs = StaticServerProvider.TestClient.GetNotCommitedSessions(_resultUser.UserId, false);
                                TestorData testSettings = null;
                                if (ncs == null)
                                {
                                    SelectSingleItemForm selectTest = new SelectSingleItemForm(_resultUser, TestingServerItemType.ActiveTestTree);
                                    if (selectTest.ShowDialog() != DialogResult.OK)
                                    {
                                        textBoxPassword.Text = String.Empty;
                                        StaticServerProvider.Logout();
                                        LoginHelper.AnonymousLogin();
                                        SetChildEnable(true);
                                        return;
                                    }
                                    _selectedTest = selectTest.SelectedItem;
                                    if (_selectedTest == null || _selectedTest.ItemType != TestorItemType.Test &&
                                        _selectedTest.ItemType != TestorItemType.MasterTest)
                                    {
                                        MessageBox.Show("Для начала тестирования необходимо выбрать тест.",
                                            "Выбор теста", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        _selectedTest = null;
                                        StaticServerProvider.Logout();
                                        LoginHelper.AnonymousLogin();
                                        SetChildEnable(true);
                                        return;
                                    }
                                    testSettings = selectTest.TestSettings;
                                }
                                else
                                {
                                    testSettings = ncs.TestSettings;
                                    TestorData.CoreTestsRow coreTest = testSettings.CoreTests[0];
                                    _selectedTest = new TestorTreeItem(0, coreTest.TestId, coreTest.TestName,
                                       coreTest.IsMasterTest ? TestorItemType.MasterTest : TestorItemType.Test, null);
                                }
                                RemoteTestingProvider provider = new RemoteTestingProvider(null, _selectedTest,
                                    testSettings, ncs, true);
                                TestForm testForm = new TestForm(provider);
                                testForm.ShowDialog();
                                comboBoxUserType_SelectedIndexChanged(sender, e);
                                StaticServerProvider.Logout();
                                LoginHelper.AnonymousLogin();
                                SetChildEnable(true);
                            }
                            else
                            {
                                SystemMessage.ShowServerErrorMessage(errorMessage);
                                textBoxPassword.Text = String.Empty;
                                StaticServerProvider.Logout();
                                LoginHelper.AnonymousLogin();
                                SetChildEnable(true);
                                return;
                            }
                        }));
                    }));
            }
            else
            {
                SetFormEnableMode(false);
                _userName = textBoxStudentName.Text;
                StaticServerProvider.Logout();
                LoginProvider loginProvider = LoginProvider.Login(_userName, _password, LoginHelper.Server, LoginHelper.SEND_TIMEOUT, null,
                    new LoginProvider.LoginResultDelegate((hasPassword, errorMessage) =>
                    {
                        this.Invoke((Action)(() =>
                        {
                            SetFormEnableMode(true);
                            if (hasPassword)
                            {
                                StatisticsForm statistics = new StatisticsForm(false);
                                statistics.MdiParent = this.MdiParent;
                                statistics.Dock = DockStyle.Fill;
                                statistics.ControlBox = false;
                                statistics.Show();
                                comboBoxUserType.SelectedIndex = 0;
                                textBoxStudentName.Focus();
                                SetChildEnable(true);
                            }
                            else
                            {
                                SystemMessage.ShowServerErrorMessage(errorMessage);
                                StaticServerProvider.Logout();
                                LoginHelper.AnonymousLogin();
                                SetChildEnable(true);
                                return;
                            }
                        }));
                    }));
            }
        }

        private void SetChildEnable(bool isEnabled)
        {
            panel.Enabled = isEnabled;
        }

        private void comboBoxUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxStudentName.Text = String.Empty;
            textBoxPassword.Text = String.Empty;
            SetFormEnableMode(true);
            _resultUser = null;
        }

        private void SetFormEnableMode(bool mode)
        {
            IsTeacherMode = comboBoxUserType.SelectedIndex == 1;
            buttonSelectStudent.Enabled = !IsTeacherMode && mode;
            textBoxStudentName.ReadOnly = !IsTeacherMode || !mode;
            textBoxStudentName.Enabled = mode;
            comboBoxUserType.Enabled = mode;
            textBoxPassword.Enabled = mode;
            buttonOK.Enabled = mode;
            labelSelectUser.Enabled = mode;
            labelPassword.Enabled = mode;
        }
    }
}

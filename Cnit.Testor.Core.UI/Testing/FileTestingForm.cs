using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnit.Testor.Core.Packaging;
using Cnit.Testor.Core.UI.Users;
using Cnit.Testor.Core.Server;
using Cnit.Testor.Core.HttpServer.TestingProviders;
using Cnit.Testor.Core.UI.Testing;
using Cnit.Testor.Core;

namespace Cnit.Testor.Core.UI
{
    public partial class FileTestingForm : Form
    {
        private DataPackageManager _dataPackageManager;
        private TestorCoreUser _resultUser;
        private List<TestHelper> _testHelpers;

        public FileTestingForm()
        {
            InitializeComponent();
            _dataPackageManager = new DataPackageManager(LoginHelper.NeedOpen.FullName);
            _dataPackageManager.Open();
            Dictionary<string, TestConfig> tests = _dataPackageManager.TestManager.GetTestObjects();
            _testHelpers = new List<TestHelper>(tests.Count);
            foreach (var test in tests)
            {
                TestHelper testHelper = new TestHelper(_dataPackageManager, test.Value);
                listBox.Items.Add(testHelper);
                _testHelpers.Add(testHelper);
            }
            _dataPackageManager.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Выход из системы", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                this.MdiParent.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm(false);
            if (addUserForm.ShowDialog() != DialogResult.OK)
                return;
            _resultUser = addUserForm.ResultUser;
            LocalTestingProvider provider = null;
            TestHelper selectedTest = listBox.SelectedItem as TestHelper;
            if (selectedTest.IsMasterTest)
                provider = new LocalTestingProvider(DataCreator.CreateFullTestorDataSet(_testHelpers),
                            selectedTest);
            else
                provider = new LocalTestingProvider(selectedTest.TestorData,
                            selectedTest);
            provider.SetStudentName(String.Format("{0} {1} {2}", HtmlStore.GetString(_resultUser.LastName),
                  HtmlStore.GetString(_resultUser.FirstName), HtmlStore.GetString(_resultUser.SecondName)));
            TestForm testForm = new TestForm(provider);
            testForm.ShowDialog();
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedItems.Count != 0)
                buttonOK.Enabled = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Cnit.Testor.Core.Packaging;
using Cnit.Testor.Core.Parsing;

namespace Cnit.Testor.Core.UI.Edit
{
    public partial class ConvertingForm : Form
    {
        private List<TestHelper> _tests;
        private delegate void EndConvertingDelegate();
        private delegate void BeginUpdateDelegate(string fileName,HtmlStore[] store);
        private delegate void RefreshListDelegate(string testName);
        private int _testCount = 0;
        private bool _canClose = false;
        private string[] _fileNames;
        private bool _cancel=false;
        private bool _isUpdate;

        public ConvertingForm(string[] fileNames,bool isUpdate)
        {
            InitializeComponent();
            _tests = new List<TestHelper>();
            _testCount = fileNames.Length;
            _fileNames = fileNames;
            _isUpdate = isUpdate;
            listBoxMain.Items.Add(String.Format("[{0}]: Запуск конвертации тестов",DateTime.Now));
        }

        private void ConvertNext()
        {
            if (_testCount>0)
            {
                FileInfo fi = new FileInfo(_fileNames[_testCount-1]);
                TestConverter.GetTest(fi, new TestConverter.ParsingFinishDelegate(TestIsDone));
            }
        }

        private void TestIsDone(FileInfo file, HtmlStore[] htmlStore)
        {
            string testName = String.Empty;
            EndConvertingDelegate endConvertingDelegate = new EndConvertingDelegate(EndConverting);
            if (htmlStore == null)
            {
                SystemMessage.ShowErrorMessage("Ошибка конвертации тестов.");
                _cancel = true;
                this.Invoke(endConvertingDelegate, new object[] { });
                return;
            }
            if (_isUpdate)
            {
                BeginUpdateDelegate updateDelegate = new BeginUpdateDelegate(UpdateTest);
                this.Invoke(updateDelegate, new object[] { file.FullName, htmlStore });
                return;
            }
            TestorData testorData = HtmlStore.GetDataSet(htmlStore, file, out testName);
            TestHelper testHelper = new TestHelper(ProjectState.DataPackageManager);
            testHelper.ConvTime = file.LastWriteTime;
            testHelper.TestId = testorData.CoreTests[0].TestId;
            testHelper.FullFileName = file.FullName;
            testHelper.TestorData = testorData;
            testHelper.TestName = testName;
            testHelper.QuestCount = testorData.CoreQuestions.Count();
            foreach (var test in testorData.CoreTests)
                testHelper.TestKey = test.TestKey.ToString();
            _tests.Add(testHelper);
            RefreshListDelegate refreshListDelegate = new RefreshListDelegate(RefreshList);
            this.Invoke(refreshListDelegate, new object[] { testHelper.TestName });
            lock (this)
            {
                _testCount--;
                if (_testCount == 0 || _cancel)
                {
                    this.Invoke(endConvertingDelegate, new object[] { });
                    return;
                }
                ConvertNext();
            }
        }

        private void UpdateTest(string fileName, HtmlStore[] store)
        {
            _canClose = true;
            if (!_cancel)
                ProjectState.UpdateTest(fileName, store);
            this.Close();
        }

        private void RefreshList(string testName)
        {
            listBoxMain.Items.Add(String.Format("[{0}]: Тест \"{1}\" сконвертирован", DateTime.Now, testName));
            listBoxMain.SelectedIndex = listBoxMain.Items.Count - 1;

            Application.DoEvents();
        }

        private void EndConverting()
        {
            _canClose = true;
            if (!_cancel)
                ProjectState.AddTests(_tests);
            this.Close();
        }

        private void ConvertingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_canClose)
                e.Cancel = true;
            _cancel = true;
        }

		private void ConvertingForm_Shown(object sender, EventArgs e)
		{
			ConvertNext();
		}

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _cancel = true;
            buttonCancel.Enabled = false;
        }
    }
}

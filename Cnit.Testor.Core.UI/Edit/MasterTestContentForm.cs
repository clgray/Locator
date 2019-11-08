using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnit.Testor.Core.Packaging;
using Cnit.Testor.Core.UI.Server;
using Cnit.Testor.Core.Server;

namespace Cnit.Testor.Core.UI.Edit
{
    public partial class MasterTestContentForm : Form
    {
		private bool _isServerMode;
		private int _testId;
        private TestHelper _helper;
        private List<TestorMasterPart> _serverMasterParts; 
        private Dictionary<string, int> _tests;

		public MasterTestContentForm(bool isServerMode, int testId)
        {
            InitializeComponent();
			_isServerMode = isServerMode;
			_testId = testId;
			cbAddTest.Enabled = !_isServerMode;
			if (_isServerMode)
				buttonAdd.Text = "Добавить...";
			else
				buttonAdd.Text = "Добавить";
			if (!_isServerMode)
			{
				_helper = ProjectState.SelectedTestHelper;
				_tests = new Dictionary<string, int>();
				foreach (var item in _helper.SubTests)
					_tests.Add(item.Key, item.Value);
				cbAddTest.Items.AddRange(ProjectState.TestHelpers.Where(c => c.IsMasterTest == false
					&& !_tests.ContainsKey(c.TestKey)).ToArray());
				ProcessItemsCountChange();
				foreach (var test in _tests)
				{
					TestHelper testHelper = null;
					foreach (var helper in ProjectState.TestHelpers)
						if (helper.TestKey == test.Key)
							testHelper = helper;
					dataGridView.Rows.Add(test.Key, testHelper.TestName, test.Value, testHelper.QuestCount);
				}
			}
			else
			{
                _serverMasterParts = new List<TestorMasterPart>();
                _serverMasterParts.AddRange(StaticServerProvider.TestEdit.GetTestMasterParts(_testId));
                foreach (var item in _serverMasterParts)
                    dataGridView.Rows.Add(item.PartTestId, item.Name, item.QuestionsNumber, "нет данных");
                buttonAdd.Enabled = true;
                ProcessItemsCountChange();
			}
        }

        private void ProcessItemsCountChange()
        {
            if (!_isServerMode)
            {
                bool isCountBiggerZero = cbAddTest.Items.Count > 0;
                if (isCountBiggerZero)
                    cbAddTest.SelectedIndex = 0;
                buttonAdd.Enabled = isCountBiggerZero;
                cbAddTest.Enabled = isCountBiggerZero;
            }
            buttonDel.Enabled = dataGridView.SelectedRows.Count > 0;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
			if (!_isServerMode)
			{
				TestHelper helper = (TestHelper)cbAddTest.SelectedItem;
				_tests.Add(helper.TestKey, 0);
				dataGridView.Rows.Add(helper.TestKey, helper.TestName, 0, helper.QuestCount);
				cbAddTest.Items.Remove(helper);
				ProcessItemsCountChange();
			}
			else
			{
                SelectItemsForm selectTests = new SelectItemsForm(TestingServerItemType.TestTree);
				if (selectTests.ShowDialog() != DialogResult.OK)
					return;
                TestorTreeItem[] items = selectTests.TestorTreeItems;
                foreach (var item in items)
                {
                    TestorMasterPart part= new TestorMasterPart() { Name = item.ItemName, PartTestId = item.TestId.Value, QuestionsNumber = 0 };
                    if (_serverMasterParts.Where(c => c.PartTestId == part.PartTestId).Count() == 0 && item.TestId != _testId)
                    {
                        _serverMasterParts.Add(part);
                        dataGridView.Rows.Add(part.PartTestId, part.Name, part.QuestionsNumber, "нет данных");
                    }
                }
			}
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!_isServerMode)
            {
                bool isEqu = true;
                if (_helper.SubTests.Count == _tests.Count)
                {
                    foreach (var item in _helper.SubTests)
                    {
                        if (!_tests.ContainsKey(item.Key) || _tests[item.Key] != item.Value)
                            isEqu = false;
                    }
                }
                else
                    isEqu = false;
                if (!isEqu)
                {
                    _helper.SubTests = _tests;
                    _helper.OnHelperUpdated();
                    ProjectState.HasChanges = true;
                }
            }
            else
            {
                StaticServerProvider.TestEdit.SetTestMasterParts(_serverMasterParts.ToArray(), _testId);
            }
            this.DialogResult = DialogResult.OK;
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 2)
                return;
            int value = 0;
            object val = dataGridView.Rows[e.RowIndex].Cells[2].Value;
            if (val is string || val == null)
                if (!int.TryParse((string)val, out value))
                {
                    MessageBox.Show("Введено некорректное число.");
                    dataGridView.Rows[e.RowIndex].Cells[2].Value = 0;
                }
                else if (val is int)
                    value = (int)val;
            if (!_isServerMode)
            {
                string key = (string)dataGridView.Rows[e.RowIndex].Cells[0].Value;
                int maxValue = (int)dataGridView.Rows[e.RowIndex].Cells[3].Value;
                if (value > maxValue || value < 0)
                {
                    MessageBox.Show(String.Format("Превышено число вопросов.\nКол-во вопросов в тесте: {0}.",
                        maxValue.ToString()));
                    dataGridView.Rows[e.RowIndex].Cells[2].Value = _tests[key];
                }
                else
                    _tests[key] = value;
            }
            else
            {
                int partTestId = (int)dataGridView.Rows[e.RowIndex].Cells[0].Value;
                var masterPart = _serverMasterParts.Where(c => c.PartTestId == partTestId).First();
                if (value < 0)
                {
                    MessageBox.Show("Введено некорректное число вопросов.");
                    dataGridView.Rows[e.RowIndex].Cells[2].Value = masterPart.QuestionsNumber;
                }
                else
                {
                    masterPart.QuestionsNumber = value;
                }
            }
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            ProcessItemsCountChange();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (!_isServerMode)
            {
                string key = (string)dataGridView.SelectedRows[0].Cells[0].Value;
                _tests.Remove(key);
                cbAddTest.Items.Add(ProjectState.TestHelpers.Where(c => c.TestKey == key).First());
            }
            else
            {
                int partTestId = (int)dataGridView.SelectedRows[0].Cells[0].Value;
                _serverMasterParts.Remove(_serverMasterParts.Where(c => c.PartTestId == partTestId).First());
            }
            dataGridView.Rows.Remove(dataGridView.SelectedRows[0]);
            ProcessItemsCountChange();
        }
    }
}

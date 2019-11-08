using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnit.Testor.Core.Server;
using Cnit.Testor.Core;
using Cnit.Testor.Core.UI.Server;

namespace Cnit.Testor.Core.UI
{
    public partial class StatisticsForm : Form
    {
        private bool _blockCellChanges = true;
        private bool _isEditMode;
        private TestorCoreUser _resultUser;
        private TestorTreeItem _selectedTest;
        private TestorTreeItem _selectedGroup;
        private BindingSource _bindingSource = new BindingSource();
        private List<TestSessionStatistics> _statistics = new List<TestSessionStatistics>();

        private bool _dateGetStatistics;

        public TestSessionStatistics SelectedSession
        {
            get
            {
                return _bindingSource.Current as TestSessionStatistics;
            }
        }

        public StatisticsForm(bool isEditMode)
        {
            InitializeComponent();
            _isEditMode = isEditMode;
            DateTime dtNow = DateTime.Now;
            DateTime dt = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0, 0);
            DateTime dtEnd = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 23, 59, 59, 0);
            dateTimePickerStart.Value = dt;
            dateTimePickerEnd.Value = dtEnd;
            comboBoxAutoupdate.SelectedIndex = 0;
            dataGridView.AutoGenerateColumns = false;
            _bindingSource.DataSource = _statistics;
            dataGridView.DataSource = _bindingSource;
            GetStatistics();
            _dateGetStatistics = true;
        }

        public void GetStatistics()
        {
            _blockCellChanges = true;
            _statistics.Clear();
            _statistics.AddRange(StaticServerProvider.TestClient.GetStatistics(dateTimePickerStart.Value, dateTimePickerEnd.Value,
                _selectedGroup != null ? _selectedGroup.ItemId : 0, _selectedTest != null ? _selectedTest.TestId.Value : 0,
                _resultUser != null ? _resultUser.UserId : 0));
            _bindingSource.CurrencyManager.Refresh();
            _blockCellChanges = false;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!_isEditMode)
            {
                StaticServerProvider.Logout();
                LoginHelper.AnonymousLogin();
            }
            this.Close();
        }

        private void linkLabelSelectStudent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClientSelectUserForm selectUser = new ClientSelectUserForm();
            if (selectUser.ShowDialog() != DialogResult.OK)
            {
                _resultUser = null;
                textBoxStudent.Text = String.Empty;
            }
            else
            {
                _resultUser = selectUser.ResultUser;
                textBoxStudent.Text = String.Format("{0} {1} {2}", HtmlStore.GetString(_resultUser.LastName),
                     HtmlStore.GetString(_resultUser.FirstName), HtmlStore.GetString(_resultUser.SecondName));
            }
            GetStatistics();
        }

        private void linkLabelTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SelectSingleItemForm selectTest = new SelectSingleItemForm(_resultUser, TestingServerItemType.TestTree);
            selectTest.ShowDialog();
            _selectedTest = selectTest.SelectedItem;
            if (_selectedTest != null && (_selectedTest.ItemType != TestorItemType.Test &&
                _selectedTest.ItemType != TestorItemType.MasterTest))
            {
                MessageBox.Show("Для начала тестирования необходимо выбрать тест.",
                    "Выбор теста", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _selectedTest = null;
            }
            if (_selectedTest == null || _selectedTest.TestId == 0)
                linkLabelTest.Text = "не выбран";
            else
            {
                if (_selectedTest.ItemName.Length <= 21)
                    linkLabelTest.Text = _selectedTest.ItemName;
                else
                    linkLabelTest.Text = _selectedTest.ItemName.Substring(0, 21) + "...";
            }
            GetStatistics();
        }

        private void linkLabelGroup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SelectSingleItemForm selectGroup = new SelectSingleItemForm(TestingServerItemType.GroupTree);
            if (selectGroup.ShowDialog() == DialogResult.Cancel)
                _selectedGroup = new TestorTreeItem(0, 0, String.Empty, TestorItemType.Group, null);
            _selectedGroup = selectGroup.SelectedItem;
            if (_selectedGroup == null || _selectedGroup.ItemId == 0)
                linkLabelGroup.Text = "не выбрана";
            else
            {
                if (_selectedGroup.ItemName.Length <= 21)
                    linkLabelGroup.Text = _selectedGroup.ItemName;
                else
                    linkLabelGroup.Text = _selectedGroup.ItemName.Substring(0, 21) + "...";
            }
            GetStatistics();
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            if (!_dateGetStatistics)
                return;
            GetStatistics();
        }

        private void comboBoxAutoupdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAutoupdate.SelectedIndex == 0)
                timer.Enabled = false;
            else
            {
                switch (comboBoxAutoupdate.SelectedIndex)
                {
                    case 1:
                        {
                            timer.Interval = 10000;
                        } break;
                    case 2:
                        {
                            timer.Interval = 30000;
                        } break;
                    case 3:
                        {
                            timer.Interval = 60000;
                        } break;
                    default:
                        break;
                }
                timer.Enabled = true;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            GetStatistics();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            int vp = 0;
            int v5 = 0;
            int v4 = 0;
            int v3 = 0;
            int.TryParse(mtbPass.Text, out vp);
            int.TryParse(mtb5.Text, out v5);
            int.TryParse(mtb4.Text, out v4);
            int.TryParse(mtb3.Text, out v3);
            DataGridViewPrinter.PrintDataGridView(dataGridView, vp, v5, v4, v3);
        }

        private void buttonAppeal_Click(object sender, EventArgs e)
        {
            AppealForm appeal = new AppealForm(SelectedSession);
            appeal.ShowDialog();
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            bool isSelected = dataGridView.SelectedRows.Count > 0;
            buttonAppeal.Enabled = isSelected;
            buttonPrint.Enabled = isSelected;
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!_blockCellChanges && e.ColumnIndex == dataGridView.Columns["Score"].Index)
                StaticServerProvider.TestClient.ChangeSessionScore(SelectedSession.TestSessionId, SelectedSession.Score.Value);
        }

        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show(String.Format("Вы действительно хотите удалить прохождение студента \"{0} {1}\"?",
                SelectedSession.LastName, SelectedSession.FirstName), "Удаление",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            StaticServerProvider.TestClient.DeleteSession(SelectedSession.TestSessionId);
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            SystemMessage.ShowWarningMessage("Неверный формат данных.");
        }
    }
}

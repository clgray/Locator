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
using Cnit.Testor.Core.HttpServer;
using Cnit.Testor.Core.HttpServer.TestingProviders;
using Cnit.Testor.Core.Parsing;
using System.Diagnostics;

namespace Cnit.Testor.Core.UI.Edit
{
    public partial class TestContentForm : Form
    {
        private TestorData _data;
        private TestHelper _testHelper;
        private EditProvider _provider;

        private int _index = 0;

        public TestContentForm(TestorData data)
        {
            InitializeComponent();
            _data = data;
            int i = 0;
            foreach (var test in ProjectState.TestHelpers.OrderBy(c => c.TestName))
            {
                if (test.IsMasterTest)
                    continue;
                if (test.IsTestorDataLoaded && test.TestorData == data)
                    _index = i;
                tscbTests.Items.Add(test);
                i++;
            }
            tscbTests.SelectedIndex = _index;
            bool canBackForward = ProjectState.TestHelpers.Count > 1;
            tsbBackTest.Enabled = canBackForward;
            tsbForwardTest.Enabled = canBackForward;

            _provider = new EditProvider(HtmlStore.GetHtmlStore(_data, 1));
            _provider.ProviderMode = ProviderMode.EditMode;
            TestingHttpServer.StartServer(_provider);
            TestingHttpServer.ServerNotStarted.WaitOne();
            webBrowserQuestion.Navigate(TestingHttpServer.BaseUrl);
        }

        private void toolStripComboBoxTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            _index = tscbTests.SelectedIndex;
            _testHelper = tscbTests.SelectedItem as TestHelper;
            _data = _testHelper.TestorData;
            bindingSource.DataSource = _data.CoreQuestions;
            InitParams();
        }

        private void SelectNewItem(bool isForward)
        {
            int index = _index;
            if (isForward)
                index++;
            else
                index--;
            if (index > tscbTests.Items.Count - 1)
                index = 0;
            else if (index < 0)
                index = tscbTests.Items.Count - 1;
            _index = index;
            tscbTests.SelectedIndex = _index;
        }

        private void tsbBack_Click(object sender, EventArgs e)
        {
            SelectNewItem(false);
        }

        private void tsbForward_Click(object sender, EventArgs e)
        {
            SelectNewItem(true);
        }

        private void bindingSourceQuest_CurrentItemChanged(object sender, EventArgs e)
        {
            if (bindingSourceQuest.CurrencyManager.Position == -1)
                return;
            TestorData.CoreQuestionsRow currentRow = ((bindingSourceQuest.Current as DataRowView).Row
                 as TestorData.CoreQuestionsRow);
            tscbMark.SelectedIndex = (int)Math.Round(currentRow.QuestionMark, 0) - 1;
            try
            {
                _provider.SetHtmlStore(HtmlStore.GetHtmlStore(_data, currentRow.QuestionId));
                webBrowserQuestion.Navigate(TestingHttpServer.BaseUrl);
            }
            catch
            {
            }
        }

        private void tscbMark_SelectedIndexChanged(object sender, EventArgs e)
        {
            TestorData.CoreQuestionsRow currentRow = ((bindingSourceQuest.Current as DataRowView).Row
                 as TestorData.CoreQuestionsRow);
            short currentMark = (short)(tscbMark.SelectedIndex + 1);
            if (currentMark != currentRow.QuestionMark)
            {
                currentRow.QuestionMark = currentMark;
                ProjectState.HasChanges = true;
            }
        }

        private void InitParams()
        {
            tslQuestCount.Text = String.Format("Вопросов: {0}", _testHelper.QuestCount.ToString());
        }

        private void tsbUpdateTest_Click(object sender, EventArgs e)
        {
            int index = bindingSourceQuest.Position;
            try
            {
                ProjectState.UpdateTest(_testHelper);
            }
            catch (Exception ex)
            {
                SystemMessage.ShowErrorMessage(ex);
            }
            InitParams();
            if (bindingSourceQuest.Count > index)
                bindingSourceQuest.Position = index;
        }

        private void tsbOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(_testHelper.FullFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void tsmClearBR_Click(object sender, EventArgs e)
        {
            foreach (TestHelper item in ProjectState.TestHelpers)
            {
                foreach (TestorData.CoreAnswersRow row in item.TestorData.CoreAnswers.Rows)
                {
                    row.Answer = ClearBR(row.Answer);
                }
                foreach (TestorData.CoreQuestionsRow row in item.TestorData.CoreQuestions.Rows)
                {
                    row.Question = ClearBR(row.Question);
                }
            }
            MessageBox.Show("Пробелы успешно удалены. ");
        }

        private static string ClearBR(string st)
        {
            st = st.Trim();

            while ((st.IndexOf("<br/><br/>") >= 0))
            {
                st = st.Replace("<br/><br/>", "<br/>");
            }

            while (st.StartsWith("<br/>", StringComparison.InvariantCultureIgnoreCase))
            {
                st = st.Substring(5);
            }

            while (st.EndsWith("<br/>", StringComparison.InvariantCultureIgnoreCase))
            {
                st = st.Substring(0, st.Length - 5);
            }
            return st;
        }

        private void TestContentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TestingHttpServer.StopServer();
        }

        private void dgwFK_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            bindingSourceQuest_CurrentItemChanged(sender, null);
        }

        private void dgwFK_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            DataGridViewCell cell = null;
            if (sender == dgwFK)
                cell = dgwFK.Rows[e.RowIndex].Cells[e.ColumnIndex];
            else if (sender == dgwQuest)
                cell = dgwQuest.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.ValueType == Type.GetType("System.String") && cell.Value as System.String == null)
                cell.Value = String.Empty;
        }
    }
}

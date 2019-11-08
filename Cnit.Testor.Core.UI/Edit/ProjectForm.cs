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
using Cnit.Testor.Core.UI.Server;

namespace Cnit.Testor.Core.UI.Edit
{
    public partial class ProjectForm : Form
    {
        private const string _formText = "Проект";

        public ProjectForm()
        {
            InitializeComponent();
            this.Text = _formText;
            RefreshList();
            ProjectState.TestHelpersChanged += new EventHandler(Commands_TestHelpersChanged);
            ProjectState.TestHelperDeleted += new EventHandler(Commands_TestHelperDeleted);
        }

        void Commands_TestHelperDeleted(object sender, EventArgs e)
        {
            TestHelper testHelper = (TestHelper)sender;
            foreach (ListViewItem item in listView.Items)
            {
                if (item.Tag == testHelper)
                {
                    listView.Items.Remove(item);
                    item.Selected = false;
                    panel.Enabled = false;
                    ProjectState.SelectedTestHelper = null;
                    break;
                }
            }
        }

        void Commands_TestHelpersChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private int GetQuestCount(TestHelper helper)
        {
            int questCount = 0;
            if (!helper.IsMasterTest)
                questCount = helper.QuestCount;
            else
                foreach (var subTest in helper.SubTests)
                    questCount += subTest.Value;
            return questCount;
        }

        public void RefreshList()
        {
            listView.BeginUpdate();
            foreach (var test in ProjectState.TestHelpers.OrderBy(c=>c.TestName))
            {
                if (GetItemByTestHelper(test) != null)
                    continue;
                ListViewItem lvi = new ListViewItem(new String[] { 
                    test.TestName, GetQuestCount(test).ToString()}, test.IsMasterTest ? 1 : 0);
                lvi.Tag = test;
                lvi.ToolTipText = test.FullFileName;
                test.ListViewItem = lvi;
                test.HelperUpdated += new EventHandler(test_OnHelperUpdated);
                lvi.Group = listView.Groups[test.IsMasterTest ? 1 : 0];
                listView.Items.Add(lvi);
            }
            listView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
            listView.EndUpdate();
        }

        void CurrentForm_OnProjectChanged(object sender, EventArgs e)
        {
            if (ProjectState.HasChanges)
                this.Text = String.Format("{0}*", _formText);
            else
                this.Text = _formText;
        }

        public ListViewItem GetItemByTestHelper(TestHelper testHelper)
        {
            return testHelper.ListViewItem;
        }

        void test_OnHelperUpdated(object sender, EventArgs e)
        {
            TestHelper helper = (TestHelper)sender;
            ListViewItem item = GetItemByTestHelper(helper);
            if (item == null)
                return;
            item.Text = helper.TestName;
            item.SubItems[1].Text = GetQuestCount(helper).ToString();
            item.ToolTipText = helper.FullFileName;
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            ProjectState.ShowTestContent();
        }

        private void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (!e.IsSelected)
                return;
            ProjectState.SelectedTestHelper = (listView.SelectedItems[0].Tag as TestHelper);
            panel.Enabled = true;
            testSettings.SetDataSet(new TestSettingsAdapter((listView.SelectedItems[0].Tag as TestHelper)));
            ProjectState.CanDelete = true;
        }

        private void listView_MouseDown(object sender, MouseEventArgs e)
        {
            ListViewItem lvi = this.listView.GetItemAt(e.X, e.Y);
            if (lvi != null)
                return;
            panel.Enabled = false;
            ProjectState.SelectedTestHelper = null;
            ProjectState.CanDelete = false;
        }

        private void ProjectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProjectState.TestHelpersChanged -= new EventHandler(Commands_TestHelpersChanged);
            ProjectState.TestHelperDeleted -= new EventHandler(Commands_TestHelperDeleted);
			testSettings.ProjectClosing();
        }
    }
}

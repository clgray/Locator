using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnit.Testor.Core.Packaging;
using Cnit.Testor.Core.Server;
using Cnit.Testor.Core.UI.Server;
using System.Collections;

namespace Cnit.Testor.Core.UI.Edit
{
    public partial class AdditionalSettingsForm : Form
    {
        private bool _isServerMode;
        private TestSettingsAdapter _adapter;
        private List<TestorTreeItem> _serverRequirements;

        public AdditionalSettingsForm(bool isServerMode, TestSettingsAdapter adapter)
        {
            InitializeComponent();
            _isServerMode = isServerMode;
            _adapter = adapter;
            buttonAddReq.Enabled = _isServerMode;
            if (!_isServerMode)
            {
                foreach (var helper in ProjectState.TestHelpers)
                    if (helper != ProjectState.SelectedTestHelper)
                    {
                        bool isChecked = ProjectState.SelectedTestHelper.TestRequirements.Contains(helper.TestKey);
                        clbAddSettings.Items.Add(helper, isChecked);
                    }
            }
            else
            {
                _serverRequirements = new List<TestorTreeItem>();
                _serverRequirements.AddRange(StaticServerProvider.TestEdit.GetTestRequirements(_adapter.TestId));
                foreach (var req in _serverRequirements)
                {
                    clbAddSettings.Items.Add(req, true);
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!_isServerMode)
            {
                bool isEqu = true;
                List<string> keys = new List<string>();
                foreach (var item in clbAddSettings.CheckedItems)
                    keys.Add(((TestHelper)item).TestKey);
                if (ProjectState.SelectedTestHelper.TestRequirements.Count == clbAddSettings.CheckedItems.Count)
                {
                    foreach (var item in ProjectState.SelectedTestHelper.TestRequirements)
                        if (!keys.Contains(item))
                        {
                            isEqu = false;
                            break;
                        }
                    foreach (var item in clbAddSettings.CheckedItems)
                        if (!ProjectState.SelectedTestHelper.TestRequirements.Contains((item as TestHelper).TestKey))
                        {
                            isEqu = false;
                            break;
                        }
                }
                else
                    isEqu = false;
                if (!isEqu)
                {
                    ProjectState.SelectedTestHelper.TestRequirements.Clear();
                    foreach (var item in clbAddSettings.CheckedItems)
                    {
                        TestHelper helper = (TestHelper)item;
                        ProjectState.SelectedTestHelper.TestRequirements.Add(helper.TestKey);
                    }
                    ProjectState.HasChanges = true;
                }
            }
            else
            {
                bool isEqu = true;
                List<int> keys = new List<int>();
                foreach (var item in clbAddSettings.CheckedItems)
                    keys.Add(((TestorTreeItem)item).ItemId);
                if (_serverRequirements.Count == clbAddSettings.CheckedItems.Count)
                {
                    foreach (var item in _serverRequirements)
                        if (!keys.Contains(item.ItemId))
                        {
                            isEqu = false;
                            break;
                        }
                    foreach (var item in clbAddSettings.CheckedItems)
                        if (!_serverRequirements.Contains((item as TestorTreeItem)))
                        {
                            isEqu = false;
                            break;
                        }
                }
                else
                    isEqu = false;
                if (!isEqu)
                {

                    StaticServerProvider.TestEdit.SetTestRequirements(GetItems(true).ToArray(), _adapter.TestId);
                }
            }
        }

        private List<TestorTreeItem> GetItems(bool isChecked)
        {
            List<TestorTreeItem> retValue = new List<TestorTreeItem>();
            IEnumerable collection = null;
            if(isChecked)
                collection=clbAddSettings.CheckedItems;
            else
                collection=clbAddSettings.Items;
            foreach (var item in collection)
            {
                TestorTreeItem treeItem = (TestorTreeItem)item;
                retValue.Add(treeItem);
            }
            return retValue;
        }

        private void buttonAddReq_Click(object sender, EventArgs e)
        {
            SelectItemsForm selectForm = new SelectItemsForm(TestingServerItemType.TestTree);
            if (selectForm.ShowDialog() != DialogResult.OK)
                return;
            TestorTreeItem[] items = selectForm.TestorTreeItems;
            var currentItems=GetItems(false);
            foreach (var item in items)
            {
                if (currentItems.Where(c => c.TestId == item.TestId).Count() == 0 && item.TestId != _adapter.TestId)
                    clbAddSettings.Items.Add(item, true);
            }
        }
    }
}

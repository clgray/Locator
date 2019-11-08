using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnit.Testor.Core.Server;

namespace Cnit.Testor.Core.UI.Server
{
    public partial class SelectItemsForm : Form
    {
        private TestorTreeItem _selectedItem;
        private TestingServerItemType _itemType;

        public TestorTreeItem[] TestorTreeItems
        {
            get
            {
                List<TestorTreeItem> retValue = new List<TestorTreeItem>();
                foreach (var item in listBox.Items)
                {
                    TestorTreeItem testorItem = item as TestorTreeItem;
                    testorItem.SubItems = null;
                    retValue.Add(testorItem);
                }
                return retValue.ToArray();
            }
        }

        public SelectItemsForm(TestingServerItemType itemType)
        {
            InitializeComponent();
            _itemType = itemType;
            mainTreeView.InitTreeView(_itemType, null, false);
            mainTreeView.ItemSelected += new EventHandler<TestorItemSelectedEventArgs>(testTreeView_ItemSelected);
        }

        void testTreeView_ItemSelected(object sender, TestorItemSelectedEventArgs e)
        {
            if (e.Item.ItemType != TestorItemType.MasterTest && e.Item.ItemType != TestorItemType.Test
                && e.Item.ItemType != TestorItemType.Group)
            {
                buttonAdd.Enabled = false;
                labelTestName.Text = "не выбран";
                return;
            }
            _selectedItem = e.Item;
            buttonAdd.Enabled = true;
            labelTestName.Text = e.Item.ItemName;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (_selectedItem != null)
            {
                if (TestorTreeItems.Where(c => c.ItemId == _selectedItem.ItemId).Count() > 0)
                {
                    SystemMessage.ShowWarningMessage("Данный тест уже содержится в списке.");
                    return;
                }
                listBox.Items.Add(_selectedItem);
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            listBox.Items.Remove(listBox.SelectedItem);
        }

        private void listBox_SelectedValueChanged(object sender, EventArgs e)
        {
            buttonDel.Enabled = listBox.SelectedItems.Count > 0;
        }

        private void testTreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Point pt = new Point(e.X, e.Y);
            
            TreeNode tn = ((TreeView)sender).GetNodeAt(pt);
            if (tn != null)
            {
                mainTreeView.SelectedNode = tn;
                if (buttonAdd.Enabled)
                    buttonAdd_Click(this, new EventArgs());
            }
        }
    }
}

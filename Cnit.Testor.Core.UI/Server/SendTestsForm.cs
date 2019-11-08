using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Cnit.Testor.Core.UI.Server;
using Cnit.Testor.Core.Server;
using Cnit.Testor.Core.UI.Edit;
using Cnit.Testor.Core.UI.Server.Controls;

namespace Cnit.Testor.Core.UI.Server
{
	public partial class SendTestsForm : Form
	{
        private TestorData _testorData;

		public SendTestsForm()
		{
			InitializeComponent();
            _testorData = ProjectState.FullTestorDataSet;
            treeView.InitTreeView(TestingServerItemType.TestTree, cmsContext, false);
            treeView.EnableDragDrop = true;
            tvGroups.InitTreeView(TestingServerItemType.GroupTree, null, false);
            treeView.ItemSelected += new EventHandler<TestorItemSelectedEventArgs>(_serviceProvider_ItemSelected);
			foreach (var testHelper in ProjectState.TestHelpers)
			{
				ListViewItem lvi = new ListViewItem(new string[] { testHelper.TestName }, 0);
				lvi.Group = clbTests.Groups[testHelper.IsMasterTest ? 1 : 0];
				lvi.Tag = testHelper;
				clbTests.Items.Add(lvi);
			}
            SystemStateManager.StateChanged += new EventHandler<EventArgs>(SystemStateManager_StateChanged);
		}

        void SystemStateManager_StateChanged(object sender, EventArgs e)
        {
            tsbCancel.Visible = SystemStateManager.State;
            toolStripProgressBar.Style = SystemStateManager.State == true ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks;
        }

        public void ProcessControlsEnableProp()
        {
            bool isNonAccess = false;
            TestorTreeItem item = treeView.SelectedItem;
            if (StaticServerProvider.CurrentUser.UserRole != TestorUserRole.Administrator && StaticServerProvider.CurrentUser.UserId != item.ItemOwner)
                isNonAccess = true;

            bool isRootNode = item.ItemId == 0 || isNonAccess;

            tssShowFolder.Visible = item.ItemType == TestorItemType.Folder && !isRootNode;
            tsbIsActive.Visible = tssShowFolder.Visible;

            if (item.ItemType == TestorItemType.Folder && item.ItemId != 0)
            {
                tsbIsActive.Checked = item.IsActive;
            }

            tsbDelete.Enabled = !isRootNode;
            bool showFolderName = item.ItemType == TestorItemType.Folder;
            tlsFolder.Visible = showFolderName;
            toolStripSeparator3.Visible = showFolderName;
            tscbFolder.Visible = showFolderName;
            tsbAddFolder.Enabled = showFolderName;
            masterTestToolStripMenuItem.Enabled = showFolderName;
            tsbSend.Enabled = showFolderName;
            if (item.ItemType == TestorItemType.Folder)
            {
                tscbFolder.Text = GetFolderName(treeView.SelectedNode);
                tscbFolder.SelectionStart = tscbFolder.Text.Length - 1;
            }
            else
                tscbFolder.Text = String.Empty;
            renameToolStripMenuItem.Enabled = !isNonAccess;
            deleteToolStripMenuItem.Enabled = !isNonAccess;
        }

		void _serviceProvider_ItemSelected(object sender, TestorItemSelectedEventArgs e)
		{
            ProcessControlsEnableProp();
		}

		public string GetFolderName(TreeNode treeNode)
		{
			if (treeNode.Parent == null)
				return treeNode.Text;
			else
				return String.Format("{0}\\{1}", GetFolderName(treeNode.Parent), treeNode.Text);
		}

		private void tsbDelete_Click(object sender, EventArgs e)
		{
            if (SystemStateManager.TestState())
                return;
            treeView.RemoveItem();
		}

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SystemStateManager.TestState())
                return;
            treeView.RenameItem();
        }

		private void tsbAddFolder_Click(object sender, EventArgs e)
		{
            if (SystemStateManager.TestState())
                return;
            treeView.AddFolder();
		}

        private void tsbSend_Click(object sender, EventArgs e)
        {
            if (SystemStateManager.TestState())
                return;
            List<int> groupIds = new List<int>();
            tvGroups.GetGroupIds(null, groupIds);
            treeView.SendTests(_testorData, groupIds);
        }

		private void tscbFolder_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		private void tsbCancel_Click(object sender, EventArgs e)
		{
            treeView.Abort();
		}

		private void SendTestsForm_FormClosing(object sender, FormClosingEventArgs e)
		{
            treeView.Abort();
		}

        private void SendTestsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SystemStateManager.StateChanged -= new EventHandler<EventArgs>(SystemStateManager_StateChanged);
        }

        private void masterTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputBox ib = new InputBox("Имя мастер теста", "Введите имя мастер теста:");
            if (ib.ShowDialog() != DialogResult.OK)
                return;
            treeView.CreateMasterTest(ib.Text);
        }

        private void tsbIsActive_Click(object sender, EventArgs e)
        {
            StaticServerProvider.TestEdit.SetTestTreeItemActivity(treeView.SelectedItem.ItemId, tsbIsActive.Checked);
            treeView.SelectedItem.IsActive = tsbIsActive.Checked;
        }
	}
}

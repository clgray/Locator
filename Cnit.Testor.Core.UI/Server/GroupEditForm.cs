using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnit.Testor.Core.UI.Server;
using Cnit.Testor.Core.Server;

namespace Cnit.Testor.Core.UI.UI
{
    public partial class GroupEditForm : Form
    {
        public GroupEditForm()
        {
            InitializeComponent();
            treeView.InitTreeView(TestingServerItemType.GroupTree,cmsContext, false);
            treeView.NodesAdded += new EventHandler<EventArgs>(_serviceProvider_GroupNodesAdded);
            treeView.EnableDragDrop = true;
            SystemStateManager.StateChanged += new EventHandler<EventArgs>(SystemStateManager_StateChanged);
        }

        void SystemStateManager_StateChanged(object sender, EventArgs e)
        {
            tsbCancel.Visible = SystemStateManager.State;
            toolStripProgressBar.Style = SystemStateManager.State == true ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks;
        }

        private void SetControlsEnabled()
        {
            bool isRoot = treeView.SelectedNode == treeView.Nodes[0];
            bool state = SystemStateManager.State;
            toolStripButtonDel.Enabled = !isRoot && !state;
            deleteToolStripMenuItem.Enabled = toolStripButtonDel.Enabled;
            toolStripButtonRename.Enabled = !isRoot && !state;
            renameToolStripMenuItem.Enabled = toolStripButtonRename.Enabled;
        }

        void _serviceProvider_GroupNodesAdded(object sender, EventArgs e)
        {
            treeView_AfterSelect(this, new TreeViewEventArgs(null));
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            if (SystemStateManager.TestState())
                return;
            string groupName=treeView.Nodes[0].Text;
            if(treeView.SelectedNode!=null)
                groupName=treeView.SelectedNode.Text;
            CreateTreeForm ctf = new CreateTreeForm("Группы:",
                String.Format("Добавить группы в '{0}'", groupName));
            ctf.ShowDialog();
            if (ctf.DialogResult != DialogResult.OK)
                return;
            int parentId = 0;
            if (treeView.SelectedNode != null)
                parentId=(treeView.SelectedNode.Tag as TestorTagItem).TreeItem.ItemId;
            treeView.AddGroups(parentId, ctf.TestorItems);
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listView.Items.Clear();
            TreeNode node = treeView.SelectedNode;
            TreeNodeCollection collection = null;
            if (node == null)
                collection = treeView.Nodes;
            else
            {
                collection = node.Nodes;
                if (node.Parent != null)
                {
                    ListViewItem lviUp = new ListViewItem("..");
                    lviUp.ImageIndex = 1;
                    listView.Items.Add(lviUp);
                }
                tstbGroupCode.Text = !String.IsNullOrEmpty(treeView.SelectedItem.GroupCode) ? treeView.SelectedItem.GroupCode : String.Empty;
            }
            foreach (TreeNode tn in collection)
            {
                ListViewItem lvi = new ListViewItem(tn.Text);
                lvi.ImageIndex = 0;
                lvi.Tag = tn;
                listView.Items.Add(lvi);
            }
            SetControlsEnabled();
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
                return;
            TreeNode tn = (TreeNode)listView.SelectedItems[0].Tag;
            try
            {
                if (tn == null)
                {
                    treeView.SelectedNode = treeView.SelectedNode.Parent;
                    return;
                }
            }
            catch { }
            treeView.SelectedNode = tn;
            tn.Expand();
        }

        private void toolStripButtonDel_Click(object sender, EventArgs e)
        {
            if (SystemStateManager.TestState())
                return;
            treeView.RemoveItem();
        }

        private void toolStripButtonRename_Click(object sender, EventArgs e)
        {
            if (SystemStateManager.TestState())
                return;
            treeView.RenameItem();
        }

        private void GroupEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            treeView.Abort();
        }

        private void GroupEditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SystemStateManager.StateChanged -= new EventHandler<EventArgs>(SystemStateManager_StateChanged);
        }
    }
}

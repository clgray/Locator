using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnit.Testor.Core.Server;
using System.Threading;
using System.Windows.Forms;

namespace Cnit.Testor.Core.UI.Server.Controls
{
    public class GroupTreeView : SystemTreeView
    {
        private int[] _groupIds;

        public void SetTestGroups(int testId)
        {
            List<int> currentGroups = new List<int>();
            GetGroupIds(null, currentGroups);
            currentGroups = currentGroups.OrderBy(c => c).ToList();
            bool isEq = true;
            if (_groupIds.Length == 0 && currentGroups.Count == 0)
                return;
            if (_groupIds.Length == currentGroups.Count)
            {
                for (int i = 0; i < _groupIds.Length; i++)
                {
                    if (_groupIds[i] != currentGroups[i])
                    {
                        isEq = false;
                        break;
                    }
                }
            }
            else
                isEq = false;
            if (!isEq)
            {
                int[] addGroups = currentGroups.Where(c => !_groupIds.Contains(c)).ToArray();
                int[] remGroups = _groupIds.Where(c => !currentGroups.Contains(c)).ToArray();
                StaticServerProvider.TestEdit.SetTestGroups(testId, addGroups, remGroups);
            }
        }

        public void AddGroups(int parentId, TestorTreeItem[] groups)
        {
            TreeNode selectedNode = this.SelectedNode;
            SystemStateManager.OnStateChanged(true);
            SynchronizationContext context = SynchronizationContext.Current;
            _currentThread = new Thread(new ThreadStart(() =>
            {
                TestorTreeItem[] retValue = StaticServerProvider.TestEdit.AddGroups(parentId, groups);
                context.Send(d =>
                {
                    AddTreeNodes(retValue, this.SelectedNode, false);
                    if (selectedNode != null)
                        selectedNode.Expand();
                    SystemStateManager.OnStateChanged(false);
                }, null);
            }));
            _currentThread.Start();
        }

        public void GetGroupIds(TreeNode tn, List<int> ids)
        {
            TreeNodeCollection nodes;
            if (tn == null)
                nodes = _rootNode.Nodes;
            else
                nodes = tn.Nodes;
            foreach (TreeNode node in nodes)
            {
                if (!node.Checked)
                    GetGroupIds(node, ids);
                else
                    ids.Add((node.Tag as TestorTagItem).TreeItem.ItemId);
            }
        }

        public void ProcessTestGroups(int testId)
        {
            _rootNode.Checked = false;
            SystemStateManager.OnStateChanged(true);
            try
            {
                _groupIds = GetTestGroups(testId).OrderBy(c => c).ToArray();
                if ((this.TopLevelControl as Form).IsHandleCreated)
                {
                    foreach (var node in _serverNodes)
                    {
                        if (!_groupIds.Contains(node.Key))
                        {
                            if (node.Value.Checked)
                                node.Value.Checked = false;
                        }
                        else
                        {
                            if (!node.Value.Checked)
                                node.Value.Checked = true;
                        }
                    }
                    SystemStateManager.OnStateChanged(false);
                }
            }
            catch (Exception ex)
            {
                SystemMessage.Log(ex);
            }
        }

        public int[] GetTestGroups(int testId)
        {
            return StaticServerProvider.TestEdit.GetTestGroups(testId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnit.Testor.Core.Server;
using System.Drawing;
using System.Threading;
using Cnit.Testor.Core.Packaging;

namespace Cnit.Testor.Core.UI.Server.Controls
{
    public abstract class SystemTreeView : TreeView
    {
        private bool _enableDragDrop;

        protected TreeNode _rootNode;
        protected TestorTreeItem _selectedItem;
        protected Dictionary<int, TreeNode> _serverNodes;
        protected TestingServerItemType _serverItemType = TestingServerItemType.None;
        protected int _levelsNumber = 2;
        protected bool _fillAllLevels;
        protected string _serverText;
        protected Thread _currentThread;
        protected ContextMenuStrip _nodeContextMenu;

        public event EventHandler<EventArgs> NodesAdded;
        public event EventHandler<TestorItemSelectedEventArgs> ItemSelected;

        protected delegate void ProcessTreeLevelDelegate(TestorTreeItem[] items, TreeNode tn, bool expand);

        public Thread Thread
        {
            get
            {
                return _currentThread;
            }
        }

        public string ServerText
        {
            get
            {
                return _serverText;
            }
            set
            {
                _serverText = String.Format("{0}", value);
            }
        }

        public bool FillAllLevels
        {
            get
            {
                return _fillAllLevels;
            }
        }

        public int LevelsNumber
        {
            get
            {
                if (_fillAllLevels)
                    return 0;
                else
                    return _levelsNumber;
            }
            set
            {
                _levelsNumber = value;
            }
        }

        public TestingServerItemType ServerItemType
        {
            get
            {
                return _serverItemType;
            }
            private set
            {
                if (_serverItemType == value)
                    return;
                switch (value)
                {
                    case TestingServerItemType.TestTree:
                        ServerText = "Тесты";
                        break;
                    case TestingServerItemType.ActiveTestTree:
                        ServerText = "Тесты";
                        break;
                    case TestingServerItemType.GroupTree:
                        ServerText = "Группы";
                        break;
                    case TestingServerItemType.FolderTree:
                        ServerText = "Папки";
                        break;
                    default:
                        break;
                }
                _serverItemType = value;
            }
        }

        public ContextMenuStrip NodeContextMenu
        {
            get
            {
                return _nodeContextMenu;
            }
            set
            {
                _nodeContextMenu = value;
            }
        }

        public TestorTreeItem SelectedItem
        {
            get
            {
                return _selectedItem;
            }
        }

        public bool EnableDragDrop
        {
            get
            {
                return _enableDragDrop;
            }
            set
            {
                _enableDragDrop = value;
            }
        }

        public void InitTreeView(TestingServerItemType serverItemType, ContextMenuStrip nodeContextMenu,
            bool fillAllLevels)
        {
            _fillAllLevels = false;
            ServerItemType = serverItemType;
            _nodeContextMenu = nodeContextMenu;
            this.Nodes.Clear();
            _rootNode = new TreeNode(_serverText, 0, 0);
            TestorTagItem rootTag = new TestorTagItem(
                new TestorTreeItem(0, null, _serverText, TestorItemType.Folder, new TestorTreeItem[] { }));
            rootTag.IsChildProcessed = true;
            _rootNode.Tag = rootTag;
            this.Nodes.Add(_rootNode);
            this.SelectedNode = _rootNode;
            ProcessTreeByLevel(LevelsNumber);
        }

        public SystemTreeView()
            : base()
        {
            this.MouseUp += new MouseEventHandler(TestorTreeView_MouseUp);
            this.AfterSelect += new TreeViewEventHandler(TestorTreeView_AfterSelect);
            this.AfterCheck += new TreeViewEventHandler(TestorTreeView_AfterCheck);
            _serverNodes = new Dictionary<int, TreeNode>();
            this.ItemDrag += new ItemDragEventHandler(SystemTreeView_ItemDrag);
            this.DragEnter += new DragEventHandler(SystemTreeView_DragEnter);
            this.DragDrop += new DragEventHandler(SystemTreeView_DragDrop);
            this.AllowDrop = true;
        }

        void SystemTreeView_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode newNode;
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                TreeNode destinationNode = GetDropTreeNode(sender, e);
                newNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                if (destinationNode != newNode)
                {
                    var tag = destinationNode.Tag as TestorTagItem;
                    if (tag.TreeItem.ItemType == TestorItemType.Folder ||
                        tag.TreeItem.ItemType == TestorItemType.Group)
                    {
                        bool canReparent = true;
                        TreeNode tn = destinationNode.Parent;
                        while (tn != null)
                        {
                            if (tn == newNode)
                            {
                                canReparent = false;
                                break;
                            }
                            tn = tn.Parent;
                        }
                        if (canReparent)
                        {
                            var tagItem = destinationNode.Tag as TestorTagItem;
                            if (!tagItem.IsChildProcessed && destinationNode.Nodes.Count == 0)
                            {
                                ProcessTreeByLevel(LevelsNumber, destinationNode);
                                tagItem.IsChildProcessed = true;
                            }
                            ReparentItem(newNode, destinationNode);
                            ((TreeView)sender).Nodes.Remove(newNode);
                            destinationNode.Nodes.Add((TreeNode)newNode);
                            destinationNode.Expand();
                        }
                    }
                }
            }
        }

        private TreeNode GetDropTreeNode(object sender,DragEventArgs e)
        {
            TreeNode retValue = null;
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                retValue = ((TreeView)sender).GetNodeAt(pt);
            }
            return retValue;
        }

        void SystemTreeView_DragEnter(object sender, DragEventArgs e)
        {
            if (_enableDragDrop)
                e.Effect = DragDropEffects.Move;
        }

        void SystemTreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (_enableDragDrop && e.Item != _rootNode)
                DoDragDrop(e.Item, DragDropEffects.Move);
        }

        public void ReparentItem(TreeNode tn, TreeNode newParent)
        {
            TestorTagItem nodeItem = tn.Tag as TestorTagItem;
            TestorTagItem newItem = newParent.Tag as TestorTagItem;
            SystemStateManager.OnStateChanged(true);
            SynchronizationContext context = SynchronizationContext.Current;
            _currentThread = new Thread(new ThreadStart(() =>
            {
                StaticServerProvider.TestEdit.SetItemParent(nodeItem.TreeItem.ItemId,
                newItem.TreeItem.ItemId, _serverItemType);
                context.Send(d =>
                {
                    SystemStateManager.OnStateChanged(false);
                }, null);
            }));
            _currentThread.Start();
            
        }

        void TestorTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TestorTagItem tagItem = (TestorTagItem)e.Node.Tag;
            if (e.Node.Nodes.Count == 0 && !tagItem.IsChildProcessed)
                ProcessTreeByLevel(LevelsNumber, e.Node);
            if (e.Node == _rootNode)
            {
                foreach (TreeNode node in _rootNode.Nodes)
                    node.Checked = _rootNode.Checked;
            }
            e.Node.Expand();
        }

        void TestorTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TestorTagItem tagItem = (TestorTagItem)e.Node.Tag;
            _selectedItem = tagItem.TreeItem;
            if ((_selectedItem.ItemType == TestorItemType.Folder || _selectedItem.ItemType ==
                TestorItemType.Group) && !tagItem.IsChildProcessed && e.Node.Nodes.Count == 0)
            {
                if (e.Node != _rootNode)
                {
                    if (SystemStateManager.TestState())
                        return;
                }
                tagItem.IsChildProcessed = true;
                ProcessTreeByLevel(LevelsNumber, this.SelectedNode);
            }
            OnItemSelected(_selectedItem, e);
        }

        public void ProcessTreeByLevel(int levelsNumber)
        {
            ProcessTreeByLevel(levelsNumber, this.Nodes[0]);
        }

        public void ProcessTreeByLevel(int levelsNumber, TreeNode node)
        {
            SystemStateManager.OnStateChanged(true);
            SynchronizationContext context = SynchronizationContext.Current;
            _currentThread = new Thread(new ThreadStart(() =>
            {
                TestorTreeItem item = null;
                if (node != null)
                    item = (node.Tag as TestorTagItem).TreeItem;
                int itemId = 0;
                if (item != null)
                    itemId = item.ItemId;
                TestorTreeItem[] items = new TestorTreeItem[] { };
				try
				{
					items = StaticServerProvider.TestEdit.GetServerTree(itemId, levelsNumber, ServerItemType);
				}
				catch(Exception ex)
				{
					SystemMessage.ShowErrorMessage(ex.Message);
				}
                ProcessTreeLevelDelegate deligate = new ProcessTreeLevelDelegate(AddTreeNodes);
                if (this.IsHandleCreated)
                {
                    context.Send(d =>
                    {
                        SystemStateManager.OnStateChanged(false);
                    }, null);
                    try
                    {
                        this.Invoke(deligate, items, node, true);
                    }
                    catch { }
                }
            }));
            _currentThread.Start();
        }

        public void AddTreeNodes(TestorTreeItem[] items, TreeNode parent, bool expand)
        {
            foreach (var newItem in items)
            {
                TreeNode newNode = new TreeNode();
                switch (newItem.ItemType)
                {
                    case TestorItemType.Folder:
                        {
                            newNode.ImageIndex = 0;
                            newNode.SelectedImageIndex = 0;
                        }
                        break;
                    case TestorItemType.Test:
                        {
                            newNode.ImageIndex = 1;
                            newNode.SelectedImageIndex = 1;
                        }
                        break;
                    case TestorItemType.MasterTest:
                        {
                            newNode.ImageIndex = 2;
                            newNode.SelectedImageIndex = 2;
                        }
                        break;
                    case TestorItemType.Group:
                        {
                            newNode.ImageIndex = 0;
                            newNode.SelectedImageIndex = 0;
                        }
                        break;
                }
                if (_nodeContextMenu != null)
                    newNode.ContextMenuStrip = _nodeContextMenu;
                bool contains = false;
                if (!_serverNodes.ContainsKey(newItem.ItemId))
                    _serverNodes.Add(newItem.ItemId, newNode);
                else
                {
                    newNode = _serverNodes[newItem.ItemId];
                    contains = true;
                }
                TestorTagItem tagItem = new TestorTagItem(newItem);
                if (_fillAllLevels)
                    tagItem.IsChildProcessed = true;
                if (!contains)
                {
                    newNode.Tag = tagItem;
                    newNode.Text = newItem.ItemName;
                    if (parent == null)
                        _rootNode.Nodes.Add(newNode);
                    else
                        parent.Nodes.Add(newNode);
                }
                AddTreeNodes(newItem.SubItems, newNode, false);
            }
            if (parent != null)
            {
                if (expand)
                    parent.Expand();
            }
            OnNodesAdded();
        }

        void TestorTreeView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point p = new Point(e.X, e.Y);
                TreeNode node = this.GetNodeAt(p);
                if (node != null)
                    this.SelectedNode = node;
            }
        }

        public void RenameItem()
        {
            TreeNode selectedNode = this.SelectedNode;
            InputBox ib = new InputBox("Переименовать", "Имя:");
            ib.Input = this.SelectedNode.Text;
            if (ib.ShowDialog() == DialogResult.OK)
            {
                SystemStateManager.OnStateChanged(true);
                SynchronizationContext context = SynchronizationContext.Current;
                _currentThread = new Thread(new ThreadStart(() =>
                {
                    StaticServerProvider.TestEdit.RenameItem(_selectedItem.ItemId, ib.Input, _serverItemType);
                    context.Send(d =>
                    {
                                                SystemStateManager.OnStateChanged(false);
                        selectedNode.Text = ib.Input;
                    }, null);
                }));
                _currentThread.Start();
            }
        }

        public void RemoveItem()
        {
            TreeNode selectedNode = this.SelectedNode;
            string text = this.SelectedNode.Text;
            if (MessageBox.Show(String.Format("Вы действительно хотите удалить \"{0}\"?",
                text),
                "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SystemStateManager.OnStateChanged(true);
                SynchronizationContext context = SynchronizationContext.Current;
                _currentThread = new Thread(new ThreadStart(() =>
                {
                    StaticServerProvider.TestEdit.RemoveItem(_selectedItem.ItemId, _serverItemType);
                    context.Send(d =>
                    {
                        SystemStateManager.OnStateChanged(false);
                        selectedNode.Remove();
                    }, null);
                }));
                _currentThread.Start();
            }
        }

        public void Abort()
        {
            if (_currentThread != null)
                _currentThread.Abort();
            SystemStateManager.State = false;
        }

        public void OnNodesAdded()
        {
            if (NodesAdded != null)
                NodesAdded(this, new EventArgs());
        }

        public void OnItemSelected(TestorTreeItem item, TreeViewEventArgs e)
        {
            if (ItemSelected != null)
                ItemSelected(this, new TestorItemSelectedEventArgs(item) { TreeEventArgs = e });
        }
    }
}

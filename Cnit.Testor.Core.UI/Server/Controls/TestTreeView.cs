using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Cnit.Testor.Core.Server;
using Cnit.Testor.Core.Packaging;
using System.Windows.Forms;

namespace Cnit.Testor.Core.UI.Server.Controls
{
    public class TestTreeView : SystemTreeView
    {
        public void AddFolder()
        {
            TreeNode selectedNode = this.SelectedNode;
            InputBox ib = new InputBox("Создать папку", "Имя папки:");
            if (ib.ShowDialog() == DialogResult.OK)
            {
                SystemStateManager.OnStateChanged(true);
                SynchronizationContext context = SynchronizationContext.Current;
                _currentThread = new Thread(new ThreadStart(() =>
                {
                    TestorTreeItem folder = StaticServerProvider.TestEdit.CreateFolder(_selectedItem.ItemId, ib.Input);
                    folder.IsActive = true;
                    TestorTagItem tagItem = new TestorTagItem(folder);
                    context.Send(d =>
                    {
                        TreeNode tn = new TreeNode(ib.Input)
                        {
                            Tag = tagItem
                        };
                        tn.ContextMenuStrip = _nodeContextMenu;
                        if (selectedNode != null)
                        {
                            selectedNode.Expand();
                            selectedNode.Nodes.Add(tn);
                        }
                        else
                            _rootNode.Nodes.Add(tn);
                        SystemStateManager.OnStateChanged(false);
                    }, null);
                }));
                _currentThread.Start();
            }
        }

        public void SendTests(TestorData testorData, List<int> groupIds)
        {
            SystemStateManager.OnStateChanged(true);
            TreeNode selectedNode = this.SelectedNode;
            SynchronizationContext context = SynchronizationContext.Current;
            _currentThread = new Thread(new ThreadStart(() =>
            {
                byte[] arr = DataCompressor.CompressData(testorData);
				try
				{
					TestorTreeItem[] newItems = StaticServerProvider.TestEdit.SendTests(arr,
						_selectedItem.ItemId, groupIds.ToArray());
					foreach (var item in newItems)
						item.ItemOwner = StaticServerProvider.CurrentUser.UserId;
					context.Send(d =>
					{
						AddTreeNodes(newItems, selectedNode, false);
						if (selectedNode != null)
							selectedNode.Expand();
					}, null);
				}
				catch (Exception ex)
				{
					SystemMessage.ShowErrorMessage(ex);
				}
				finally
				{
					context.Send(d =>
					{
						SystemStateManager.OnStateChanged(false);
					}, null);
				}
            }));
            _currentThread.Start();
        }

        public void SetTestSettings(TestorData testorData)
        {
            SystemStateManager.OnStateChanged(true);
            byte[] data = DataCompressor.CompressData(testorData);
            SynchronizationContext context = SynchronizationContext.Current;
            _currentThread = new Thread(new ThreadStart(() =>
            {
                StaticServerProvider.TestEdit.SetTestSettings(data);
                if ((this.TopLevelControl as Form).IsHandleCreated)
                {
                    context.Send(d =>
                        {
                            SystemStateManager.OnStateChanged(false);
                        }, null);
                }
            }));
            _currentThread.Start();
        }

        public TestorData GetTestSettings(int testId)
        {
            byte[] result = StaticServerProvider.TestEdit.GetTestSettings(testId);
			return DataCompressor.DecompressData<TestorData>(result);
        }

        public void CreateMasterTest(string testName)
        {
            TestorData data = new TestorData();
            TestorData.CoreTestsRow row = HtmlStore.CreateCoreTest(data, testName);
            row.IsMasterTest = true;
            data.CoreTests.Rows.Add(row);
            SendTests(data, new List<int>());
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnit.Testor.Core.Server;
using Cnit.Testor.Core.UI.Edit;
using System.Threading;
using System.IO;
using Cnit.Testor.Core.Packaging;

namespace Cnit.Testor.Core.UI.Server
{
    public partial class ManageTestsForm : Form
    {
        private TestSettingsAdapter _adapter;
        private TreeNode _preNode;

        public ManageTestsForm()
        {
            InitializeComponent();
            testSettings.IsServerMode = true;
            treeView.InitTreeView(TestingServerItemType.TestTree, cmsContext, false);
            treeView.EnableDragDrop = true;
            tvGroups.InitTreeView(TestingServerItemType.GroupTree, null, true);
            treeView.ItemSelected += new EventHandler<TestorItemSelectedEventArgs>(_serviceProvider_ItemSelected);
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
            
            tsbDelete.Enabled = !isRootNode;
            bool showFolderName = item.ItemType == TestorItemType.Folder;
            tsbAddFolder.Enabled = showFolderName;
            masterTestToolStripMenuItem.Enabled = showFolderName;
            tsbTestContent.Enabled = item.ItemType == TestorItemType.MasterTest && !isNonAccess;
            renameToolStripMenuItem.Enabled = !isNonAccess;
            deleteToolStripMenuItem.Enabled = !isNonAccess;
        }

        void _serviceProvider_ItemSelected(object sender, TestorItemSelectedEventArgs e)
        {
            ProcessControlsEnableProp();
            if (_adapter != null)
            {
                if (_adapter.HasChanges)
                {
                    _preNode.Text = _adapter.TestName;
                    treeView.SetTestSettings(_adapter.TestorData);
                }
                tvGroups.SetTestGroups((_preNode.Tag as TestorTagItem).TreeItem.TestId.Value);
            }
            TestorTreeItem item = e.Item;
            if (StaticServerProvider.CurrentUser.UserRole != TestorUserRole.Administrator && StaticServerProvider.CurrentUser.UserId != item.ItemOwner)
            {
                testSettings.Enabled = false;
                tvGroups.Enabled = false;
                _adapter = null;
                return;
            }
            bool isTest = item.ItemType == TestorItemType.Test || item.ItemType == TestorItemType.MasterTest;
            testSettings.Enabled = isTest;
            tvGroups.Enabled = testSettings.Enabled;
            if (isTest)
            {
                int testId = item.TestId ?? 0;
                tvGroups.ProcessTestGroups(testId);
                TestorData settings = treeView.GetTestSettings(testId);
                _adapter = new TestSettingsAdapter(settings);
                testSettings.SetDataSet(_adapter);
                _preNode = e.TreeEventArgs.Node;
            }
            else if (item.ItemType == TestorItemType.Folder && item.ItemId != 0)
            {
                tsbIsActive.Checked = item.IsActive;
            }
        }

        private void tsbAddFolder_Click(object sender, EventArgs e)
        {
            if (SystemStateManager.TestState())
                return;
            treeView.AddFolder();
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

        private void ManageTestsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_preNode != null)
            {
                _serviceProvider_ItemSelected(this,
                    new TestorItemSelectedEventArgs((_preNode.Tag as TestorTagItem).TreeItem)
                    {
                        TreeEventArgs = new TreeViewEventArgs(treeView.SelectedNode)
                    });
            };
            SystemStateManager.State = false;
        }

        private void ManageTestsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SystemStateManager.StateChanged -= new EventHandler<EventArgs>(SystemStateManager_StateChanged);
        }

        private void masterTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputBox ib = new InputBox("Имя мастер теста", "Введите имя мастер теста:");
            if (ib.ShowDialog() != DialogResult.OK)
                return;
            treeView.CreateMasterTest(ib.Input);
        }

        private void tsbTestContent_Click(object sender, EventArgs e)
        {
            TestorTreeItem item = treeView.SelectedItem;
            MasterTestContentForm masterForm = new MasterTestContentForm(true,
                item.TestId.HasValue ? item.TestId.Value : -1);
            masterForm.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SystemStateManager.TestState())
                return;

            if (treeView.SelectedItem.ItemType != TestorItemType.Test)
            {
                SystemMessage.ShowErrorMessage("Выберите тест.");
                return;
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                HtmlStore[] store = DataCompressor.DecompressData<HtmlStore[]>(StaticServerProvider.TestEdit.GetTestHTML(treeView.SelectedItem.TestId.Value));

                StringBuilder sb = new StringBuilder();

                sb.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
                sb.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\"><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\"/><title>Test</title></head><body>");

                int i = 0;
                foreach (var str in store)
                {
                    if (i != 0)
                        sb.Append("<br/>");
                    i++;
                    sb.Append(i.ToString() + ". ");
                    sb.Append(str.Html);
                    sb.Append("<br/>");
                    char cr = 'a';
                    foreach (var ans in str.SubItems)
                    {
                        sb.Append(cr.ToString() + ")");
                        if (ans.IsTrue)
                            sb.Append("!!!");
                        sb.Append(ans.Html);
                        sb.Append("<br/>");
                        cr++;
                    }
                }

                sb.Append("</body></html>");

                try
                {
                    FileInfo fi = new FileInfo(saveFileDialog.FileName);

                    DirectoryInfo di = Directory.CreateDirectory(Path.Combine(fi.Directory.FullName, fi.Name + "_files"));
                    foreach (var str in store)
                    {
                        foreach (var image in str.Images)
                        {
                            using (BinaryWriter bw = new BinaryWriter(File.Open(Path.Combine(di.FullName, image.Key.ToString() + ".png"), FileMode.Create)))
                            {
                                bw.Write(image.Value, 0, image.Value.Length);
                            }
                        }
                    }

                    using (TextWriter tw = new StreamWriter(File.Open(saveFileDialog.FileName, FileMode.Create)))
                    {
                        tw.Write(sb.ToString().Replace("#$", di.Name + "/").Replace("#%", "."));
                    }
                }
                catch (Exception ex)
                {
                    SystemMessage.ShowErrorMessage(ex.Message);
                }
            }
        }

        private void tsbIsActive_Click(object sender, EventArgs e)
        {
            StaticServerProvider.TestEdit.SetTestTreeItemActivity(treeView.SelectedItem.ItemId, tsbIsActive.Checked);
            treeView.SelectedItem.IsActive = tsbIsActive.Checked;
        }
    }
}

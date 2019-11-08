using Cnit.Testor.Core.UI.Server.Controls;
namespace Cnit.Testor.Core.UI.Server
{
    partial class SendTestsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Тесты", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Мастер тесты", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendTestsForm));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbSend = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCreate = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbAddFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.masterTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsFolder = new System.Windows.Forms.ToolStripLabel();
            this.tscbFolder = new System.Windows.Forms.ToolStripTextBox();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.imageListMain = new System.Windows.Forms.ImageList(this.components);
            this.splitter = new System.Windows.Forms.Splitter();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.clbTests = new System.Windows.Forms.ListView();
            this.columnHeaderTestName = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbGroups = new System.Windows.Forms.GroupBox();
            this.tvGroups = new Cnit.Testor.Core.UI.Server.Controls.GroupTreeView();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.cmsContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView = new Cnit.Testor.Core.UI.Server.Controls.TestTreeView();
            this.tsbIsActive = new System.Windows.Forms.ToolStripButton();
            this.tssShowFolder = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.gbGroups.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.cmsContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSend,
            this.toolStripSeparator1,
            this.tsbCreate,
            this.toolStripSeparator2,
            this.tsbDelete,
            this.tssShowFolder,
            this.tsbIsActive,
            this.toolStripSeparator3,
            this.tlsFolder,
            this.tscbFolder,
            this.tsbCancel});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(992, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsbSend
            // 
            this.tsbSend.Enabled = false;
            this.tsbSend.Image = global::Cnit.Testor.Core.UI.Properties.Resources.mail_send;
            this.tsbSend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSend.Name = "tsbSend";
            this.tsbSend.Size = new System.Drawing.Size(85, 22);
            this.tsbSend.Text = "Отправить";
            this.tsbSend.Click += new System.EventHandler(this.tsbSend_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbCreate
            // 
            this.tsbCreate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddFolder,
            this.masterTestToolStripMenuItem});
            this.tsbCreate.Image = ((System.Drawing.Image)(resources.GetObject("tsbCreate.Image")));
            this.tsbCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCreate.Name = "tsbCreate";
            this.tsbCreate.Size = new System.Drawing.Size(79, 22);
            this.tsbCreate.Text = "Создать";
            // 
            // tsbAddFolder
            // 
            this.tsbAddFolder.Enabled = false;
            this.tsbAddFolder.Image = global::Cnit.Testor.Core.UI.Properties.Resources.folder_add;
            this.tsbAddFolder.Name = "tsbAddFolder";
            this.tsbAddFolder.Size = new System.Drawing.Size(149, 22);
            this.tsbAddFolder.Text = "Папку...";
            this.tsbAddFolder.Click += new System.EventHandler(this.tsbAddFolder_Click);
            // 
            // masterTestToolStripMenuItem
            // 
            this.masterTestToolStripMenuItem.Enabled = false;
            this.masterTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("masterTestToolStripMenuItem.Image")));
            this.masterTestToolStripMenuItem.Name = "masterTestToolStripMenuItem";
            this.masterTestToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.masterTestToolStripMenuItem.Text = "Мастер тест...";
            this.masterTestToolStripMenuItem.Click += new System.EventHandler(this.masterTestToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Enabled = false;
            this.tsbDelete.Image = global::Cnit.Testor.Core.UI.Properties.Resources.folder_delete;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(71, 22);
            this.tsbDelete.Text = "Удалить";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator3.Visible = false;
            // 
            // tlsFolder
            // 
            this.tlsFolder.Name = "tlsFolder";
            this.tlsFolder.Size = new System.Drawing.Size(70, 22);
            this.tlsFolder.Text = "Имя папки:";
            this.tlsFolder.Visible = false;
            // 
            // tscbFolder
            // 
            this.tscbFolder.Name = "tscbFolder";
            this.tscbFolder.Size = new System.Drawing.Size(450, 25);
            this.tscbFolder.Visible = false;
            this.tscbFolder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tscbFolder_KeyPress);
            // 
            // tsbCancel
            // 
            this.tsbCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCancel.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancel.Image")));
            this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancel.Name = "tsbCancel";
            this.tsbCancel.Size = new System.Drawing.Size(53, 22);
            this.tsbCancel.Text = "Отмена";
            this.tsbCancel.Visible = false;
            this.tsbCancel.Click += new System.EventHandler(this.tsbCancel_Click);
            // 
            // imageListMain
            // 
            this.imageListMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMain.ImageStream")));
            this.imageListMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMain.Images.SetKeyName(0, "folder-closed_16.png");
            this.imageListMain.Images.SetKeyName(1, "documents_16.png");
            this.imageListMain.Images.SetKeyName(2, "piechart.png");
            this.imageListMain.Images.SetKeyName(3, "edit.gif");
            // 
            // splitter
            // 
            this.splitter.Location = new System.Drawing.Point(270, 25);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(3, 397);
            this.splitter.TabIndex = 3;
            this.splitter.TabStop = false;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.clbTests);
            this.groupBox.Controls.Add(this.panel1);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(273, 25);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(443, 397);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            // 
            // clbTests
            // 
            this.clbTests.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTestName});
            this.clbTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbTests.FullRowSelect = true;
            listViewGroup3.Header = "Тесты";
            listViewGroup3.Name = "listViewGroupTests";
            listViewGroup4.Header = "Мастер тесты";
            listViewGroup4.Name = "listViewGroupMasterTests";
            this.clbTests.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3,
            listViewGroup4});
            this.clbTests.Location = new System.Drawing.Point(3, 16);
            this.clbTests.MultiSelect = false;
            this.clbTests.Name = "clbTests";
            this.clbTests.Size = new System.Drawing.Size(437, 378);
            this.clbTests.TabIndex = 3;
            this.clbTests.UseCompatibleStateImageBehavior = false;
            this.clbTests.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderTestName
            // 
            this.columnHeaderTestName.Text = "Имя теста";
            this.columnHeaderTestName.Width = 350;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(437, 0);
            this.panel1.TabIndex = 8;
            // 
            // gbGroups
            // 
            this.gbGroups.Controls.Add(this.tvGroups);
            this.gbGroups.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbGroups.Location = new System.Drawing.Point(716, 25);
            this.gbGroups.Name = "gbGroups";
            this.gbGroups.Size = new System.Drawing.Size(276, 397);
            this.gbGroups.TabIndex = 0;
            this.gbGroups.TabStop = false;
            this.gbGroups.Text = "Группы";
            // 
            // tvGroups
            // 
            this.tvGroups.AllowDrop = true;
            this.tvGroups.CheckBoxes = true;
            this.tvGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvGroups.EnableDragDrop = false;
            this.tvGroups.LevelsNumber = 2;
            this.tvGroups.Location = new System.Drawing.Point(3, 16);
            this.tvGroups.Name = "tvGroups";
            this.tvGroups.NodeContextMenu = null;
            this.tvGroups.ServerText = "                      ";
            this.tvGroups.Size = new System.Drawing.Size(270, 378);
            this.tvGroups.TabIndex = 4;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 422);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(992, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(150, 16);
            // 
            // cmsContext
            // 
            this.cmsContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsContext.Name = "cmsContext";
            this.cmsContext.Size = new System.Drawing.Size(162, 48);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Image = global::Cnit.Testor.Core.UI.Properties.Resources.document_edit;
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.renameToolStripMenuItem.Text = "Переименовать";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::Cnit.Testor.Core.UI.Properties.Resources.folder_delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.deleteToolStripMenuItem.Text = "Удалить";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // treeView
            // 
            this.treeView.AllowDrop = true;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView.EnableDragDrop = false;
            this.treeView.HideSelection = false;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageListMain;
            this.treeView.LevelsNumber = 2;
            this.treeView.Location = new System.Drawing.Point(0, 25);
            this.treeView.Name = "treeView";
            this.treeView.NodeContextMenu = null;
            this.treeView.SelectedImageIndex = 0;
            this.treeView.ServerText = "                      ";
            this.treeView.Size = new System.Drawing.Size(270, 397);
            this.treeView.TabIndex = 2;
            // 
            // tsbIsActive
            // 
            this.tsbIsActive.Checked = true;
            this.tsbIsActive.CheckOnClick = true;
            this.tsbIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbIsActive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbIsActive.Image = ((System.Drawing.Image)(resources.GetObject("tsbIsActive.Image")));
            this.tsbIsActive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbIsActive.Name = "tsbIsActive";
            this.tsbIsActive.Size = new System.Drawing.Size(113, 22);
            this.tsbIsActive.Text = "Отображать папку";
            this.tsbIsActive.Click += new System.EventHandler(this.tsbIsActive_Click);
            // 
            // tssShowFolder
            // 
            this.tssShowFolder.Name = "tssShowFolder";
            this.tssShowFolder.Size = new System.Drawing.Size(6, 25);
            // 
            // SendTestsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 444);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.gbGroups);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 471);
            this.Name = "SendTestsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отправка тестов";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SendTestsForm_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SendTestsForm_FormClosing);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.gbGroups.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.cmsContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private TestTreeView treeView;
        private System.Windows.Forms.Splitter splitter;
		private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.ToolStripButton tsbSend;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel tlsFolder;
        private System.Windows.Forms.GroupBox gbGroups;
        private GroupTreeView tvGroups;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ListView clbTests;
		private System.Windows.Forms.ColumnHeader columnHeaderTestName;
        private System.Windows.Forms.ToolStripTextBox tscbFolder;
        private System.Windows.Forms.ContextMenuStrip cmsContext;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ImageList imageListMain;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripDropDownButton tsbCreate;
        private System.Windows.Forms.ToolStripMenuItem tsbAddFolder;
        private System.Windows.Forms.ToolStripMenuItem masterTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator tssShowFolder;
        private System.Windows.Forms.ToolStripButton tsbIsActive;
    }
}
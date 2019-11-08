using Cnit.Testor.Core.UI.Edit;
using Cnit.Testor.Core.UI.Server.Controls;
namespace Cnit.Testor.Core.UI.Server
{
    partial class ManageTestsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageTestsForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.imageListMain = new System.Windows.Forms.ImageList(this.components);
            this.splitter = new System.Windows.Forms.Splitter();
            this.panel = new System.Windows.Forms.Panel();
            this.tvGroups = new Cnit.Testor.Core.UI.Server.Controls.GroupTreeView();
            this.testSettings = new Cnit.Testor.Core.UI.Edit.TestSettings();
            this.cmsContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbCreate = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbAddFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.masterTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbTestContent = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.tssShowFolder = new System.Windows.Forms.ToolStripSeparator();
            this.tsbIsActive = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.treeView = new Cnit.Testor.Core.UI.Server.Controls.TestTreeView();
            this.statusStrip.SuspendLayout();
            this.panel.SuspendLayout();
            this.cmsContext.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 559);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(999, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(150, 16);
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
            this.splitter.Location = new System.Drawing.Point(280, 25);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(3, 534);
            this.splitter.TabIndex = 6;
            this.splitter.TabStop = false;
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.Controls.Add(this.tvGroups);
            this.panel.Controls.Add(this.testSettings);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(283, 25);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(716, 534);
            this.panel.TabIndex = 7;
            // 
            // tvGroups
            // 
            this.tvGroups.AllowDrop = true;
            this.tvGroups.CheckBoxes = true;
            this.tvGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvGroups.EnableDragDrop = false;
            this.tvGroups.LevelsNumber = 2;
            this.tvGroups.Location = new System.Drawing.Point(421, 0);
            this.tvGroups.Name = "tvGroups";
            this.tvGroups.NodeContextMenu = null;
            this.tvGroups.ServerText = "                  ";
            this.tvGroups.Size = new System.Drawing.Size(295, 534);
            this.tvGroups.TabIndex = 6;
            // 
            // testSettings
            // 
            this.testSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.testSettings.IsServerMode = false;
            this.testSettings.Location = new System.Drawing.Point(0, 0);
            this.testSettings.MinimumSize = new System.Drawing.Size(420, 523);
            this.testSettings.Name = "testSettings";
            this.testSettings.Size = new System.Drawing.Size(421, 534);
            this.testSettings.TabIndex = 5;
            // 
            // cmsContext
            // 
            this.cmsContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveToolStripMenuItem});
            this.cmsContext.Name = "cmsContext";
            this.cmsContext.Size = new System.Drawing.Size(215, 76);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Image = global::Cnit.Testor.Core.UI.Properties.Resources.document_edit;
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.renameToolStripMenuItem.Text = "Переименовать";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::Cnit.Testor.Core.UI.Properties.Resources.folder_delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.deleteToolStripMenuItem.Text = "Удалить";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(211, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.saveToolStripMenuItem.Text = "Сохранить вопросы как...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCreate,
            this.toolStripSeparator1,
            this.tsbTestContent,
            this.toolStripSeparator2,
            this.tsbDelete,
            this.tsbCancel,
            this.tssShowFolder,
            this.tsbIsActive});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip.Size = new System.Drawing.Size(999, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
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
            // tsbTestContent
            // 
            this.tsbTestContent.Enabled = false;
            this.tsbTestContent.Image = ((System.Drawing.Image)(resources.GetObject("tsbTestContent.Image")));
            this.tsbTestContent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTestContent.Name = "tsbTestContent";
            this.tsbTestContent.Size = new System.Drawing.Size(157, 22);
            this.tsbTestContent.Text = "Просмотр мастер теста";
            this.tsbTestContent.Click += new System.EventHandler(this.tsbTestContent_Click);
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
            // 
            // tssShowFolder
            // 
            this.tssShowFolder.Name = "tssShowFolder";
            this.tssShowFolder.Size = new System.Drawing.Size(6, 25);
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
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "HTML файл|*.htm";
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
            this.treeView.ServerText = "                  ";
            this.treeView.Size = new System.Drawing.Size(280, 534);
            this.treeView.TabIndex = 5;
            // 
            // ManageTestsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 581);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(900, 617);
            this.Name = "ManageTestsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Управление тестами";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ManageTestsForm_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageTestsForm_FormClosing);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panel.ResumeLayout(false);
            this.cmsContext.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ImageList imageListMain;
        private TestTreeView treeView;
        private System.Windows.Forms.Splitter splitter;
        private System.Windows.Forms.Panel panel;
        private GroupTreeView tvGroups;
        private TestSettings testSettings;
        private System.Windows.Forms.ContextMenuStrip cmsContext;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripDropDownButton tsbCreate;
        private System.Windows.Forms.ToolStripMenuItem tsbAddFolder;
        private System.Windows.Forms.ToolStripMenuItem masterTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbTestContent;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripSeparator tssShowFolder;
        private System.Windows.Forms.ToolStripButton tsbIsActive;
    }
}
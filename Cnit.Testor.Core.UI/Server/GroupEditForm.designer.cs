using Cnit.Testor.Core.UI.Server.Controls;
namespace Cnit.Testor.Core.UI.UI
{
    partial class GroupEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupEditForm));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRename = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.splitter = new System.Windows.Forms.Splitter();
            this.listView = new System.Windows.Forms.ListView();
            this.imageListBig = new System.Windows.Forms.ImageList(this.components);
            this.cmsContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView = new Cnit.Testor.Core.UI.Server.Controls.GroupTreeView();
            this.tstbGroupCode = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelGroupCode = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.cmsContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAdd,
            this.toolStripSeparator1,
            this.toolStripButtonDel,
            this.toolStripButtonRename,
            this.tsbCancel,
            this.toolStripSeparator2,
            this.toolStripLabelGroupCode,
            this.tstbGroupCode});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(882, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButtonAdd
            // 
            this.toolStripButtonAdd.Image = global::Cnit.Testor.Core.UI.Properties.Resources.folder_add;
            this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdd.Name = "toolStripButtonAdd";
            this.toolStripButtonAdd.Size = new System.Drawing.Size(137, 22);
            this.toolStripButtonAdd.Text = "Добавить группу(ы)";
            this.toolStripButtonAdd.Click += new System.EventHandler(this.toolStripButtonAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonDel
            // 
            this.toolStripButtonDel.Enabled = false;
            this.toolStripButtonDel.Image = global::Cnit.Testor.Core.UI.Properties.Resources.folder_delete;
            this.toolStripButtonDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDel.Name = "toolStripButtonDel";
            this.toolStripButtonDel.Size = new System.Drawing.Size(71, 22);
            this.toolStripButtonDel.Text = "Удалить";
            this.toolStripButtonDel.Click += new System.EventHandler(this.toolStripButtonDel_Click);
            // 
            // toolStripButtonRename
            // 
            this.toolStripButtonRename.Enabled = false;
            this.toolStripButtonRename.Image = global::Cnit.Testor.Core.UI.Properties.Resources.document_edit;
            this.toolStripButtonRename.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRename.Name = "toolStripButtonRename";
            this.toolStripButtonRename.Size = new System.Drawing.Size(114, 22);
            this.toolStripButtonRename.Text = "Переименовать";
            this.toolStripButtonRename.Click += new System.EventHandler(this.toolStripButtonRename_Click);
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
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 405);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(882, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(150, 16);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "user_manage.png");
            // 
            // splitter
            // 
            this.splitter.Location = new System.Drawing.Point(338, 25);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(3, 380);
            this.splitter.TabIndex = 3;
            this.splitter.TabStop = false;
            // 
            // listView
            // 
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.LargeImageList = this.imageListBig;
            this.listView.Location = new System.Drawing.Point(341, 25);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(541, 380);
            this.listView.TabIndex = 4;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseDoubleClick);
            // 
            // imageListBig
            // 
            this.imageListBig.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListBig.ImageStream")));
            this.imageListBig.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListBig.Images.SetKeyName(0, "user_manage.png");
            this.imageListBig.Images.SetKeyName(1, "folder_empty.png");
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
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonRename_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::Cnit.Testor.Core.UI.Properties.Resources.folder_delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.deleteToolStripMenuItem.Text = "Удалить";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonDel_Click);
            // 
            // treeView
            // 
            this.treeView.AllowDrop = true;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView.EnableDragDrop = false;
            this.treeView.HideSelection = false;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageList;
            this.treeView.LevelsNumber = 2;
            this.treeView.Location = new System.Drawing.Point(0, 25);
            this.treeView.Name = "treeView";
            this.treeView.NodeContextMenu = null;
            this.treeView.SelectedImageIndex = 0;
            this.treeView.ServerText = "     ";
            this.treeView.Size = new System.Drawing.Size(338, 380);
            this.treeView.TabIndex = 2;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // tstbGroupCode
            // 
            this.tstbGroupCode.Name = "tstbGroupCode";
            this.tstbGroupCode.ReadOnly = true;
            this.tstbGroupCode.Size = new System.Drawing.Size(250, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabelGroupCode
            // 
            this.toolStripLabelGroupCode.Name = "toolStripLabelGroupCode";
            this.toolStripLabelGroupCode.Size = new System.Drawing.Size(74, 22);
            this.toolStripLabelGroupCode.Text = "Код группы:";
            // 
            // GroupEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 427);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GroupEditForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор групп";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GroupEditForm_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GroupEditForm_FormClosing);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.cmsContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private GroupTreeView treeView;
        private System.Windows.Forms.Splitter splitter;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
        private System.Windows.Forms.ToolStripButton toolStripButtonDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonRename;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ImageList imageListBig;
        private System.Windows.Forms.ContextMenuStrip cmsContext;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabelGroupCode;
        private System.Windows.Forms.ToolStripTextBox tstbGroupCode;
    }
}
namespace Cnit.Testor.Core.UI.Server
{
    partial class SelectItemsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectItemsForm));
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.buttonDel = new System.Windows.Forms.Button();
            this.labelTestName = new System.Windows.Forms.Label();
            this.labelXTest = new System.Windows.Forms.Label();
            this.listBox = new System.Windows.Forms.ListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.splitter = new System.Windows.Forms.Splitter();
            this.mainTreeView = new Cnit.Testor.Core.UI.Server.Controls.TestTreeView();
            this.imageListMain = new System.Windows.Forms.ImageList(this.components);
            this.panel.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(678, 320);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(759, 320);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Controls.Add(this.panelContent);
            this.panel.Controls.Add(this.splitter);
            this.panel.Controls.Add(this.mainTreeView);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(848, 312);
            this.panel.TabIndex = 2;
            // 
            // panelContent
            // 
            this.panelContent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelContent.Controls.Add(this.buttonDel);
            this.panelContent.Controls.Add(this.labelTestName);
            this.panelContent.Controls.Add(this.labelXTest);
            this.panelContent.Controls.Add(this.listBox);
            this.panelContent.Controls.Add(this.buttonAdd);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(267, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(581, 312);
            this.panelContent.TabIndex = 5;
            // 
            // buttonDel
            // 
            this.buttonDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDel.Enabled = false;
            this.buttonDel.Location = new System.Drawing.Point(490, 10);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(75, 23);
            this.buttonDel.TabIndex = 4;
            this.buttonDel.Text = "Удалить";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // labelTestName
            // 
            this.labelTestName.AutoSize = true;
            this.labelTestName.Location = new System.Drawing.Point(35, 15);
            this.labelTestName.Name = "labelTestName";
            this.labelTestName.Size = new System.Drawing.Size(60, 13);
            this.labelTestName.TabIndex = 3;
            this.labelTestName.Text = "не выбран";
            // 
            // labelXTest
            // 
            this.labelXTest.AutoSize = true;
            this.labelXTest.Location = new System.Drawing.Point(4, 15);
            this.labelXTest.Name = "labelXTest";
            this.labelXTest.Size = new System.Drawing.Size(34, 13);
            this.labelXTest.TabIndex = 2;
            this.labelXTest.Text = "Тест:";
            // 
            // listBox
            // 
            this.listBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(7, 41);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(558, 264);
            this.listBox.TabIndex = 0;
            this.listBox.SelectedValueChanged += new System.EventHandler(this.listBox_SelectedValueChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Enabled = false;
            this.buttonAdd.Location = new System.Drawing.Point(409, 10);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // splitter
            // 
            this.splitter.Location = new System.Drawing.Point(264, 0);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(3, 312);
            this.splitter.TabIndex = 4;
            this.splitter.TabStop = false;
            // 
            // testTreeView
            // 
            this.mainTreeView.AllowDrop = true;
            this.mainTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.mainTreeView.HideSelection = false;
            this.mainTreeView.ImageIndex = 0;
            this.mainTreeView.ImageList = this.imageListMain;
            this.mainTreeView.LevelsNumber = 2;
            this.mainTreeView.Location = new System.Drawing.Point(0, 0);
            this.mainTreeView.Margin = new System.Windows.Forms.Padding(0);
            this.mainTreeView.Name = "testTreeView";
            this.mainTreeView.NodeContextMenu = null;
            this.mainTreeView.SelectedImageIndex = 0;
            this.mainTreeView.ServerText = "         ";
            this.mainTreeView.Size = new System.Drawing.Size(264, 312);
            this.mainTreeView.TabIndex = 3;
            this.mainTreeView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.testTreeView_MouseDoubleClick);
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
            // SelectTestsForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(846, 350);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectTestsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор тестов";
            this.panel.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Splitter splitter;
        private Cnit.Testor.Core.UI.Server.Controls.TestTreeView mainTreeView;
        private System.Windows.Forms.ImageList imageListMain;
        private System.Windows.Forms.Label labelXTest;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label labelTestName;
        private System.Windows.Forms.Button buttonDel;
    }
}
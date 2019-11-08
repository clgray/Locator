namespace Cnit.Testor.Core.UI.Edit
{
    partial class ProjectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectForm));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Тесты", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Мастер тесты", System.Windows.Forms.HorizontalAlignment.Left);
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.columnHeaderName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderQCount = new System.Windows.Forms.ColumnHeader();
            this.listView = new System.Windows.Forms.ListView();
            this.splitter = new System.Windows.Forms.Splitter();
            this.panel = new System.Windows.Forms.Panel();
            this.testSettings = new Cnit.Testor.Core.UI.Edit.TestSettings();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Autoplay.png");
            this.imageList.Images.SetKeyName(1, "autoList.ico");
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Имя теста";
            this.columnHeaderName.Width = 350;
            // 
            // columnHeaderQCount
            // 
            this.columnHeaderQCount.Text = "Кол-во вопросов";
            this.columnHeaderQCount.Width = 200;
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderQCount});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView.FullRowSelect = true;
            listViewGroup1.Header = "Тесты";
            listViewGroup1.Name = "listViewGroupTests";
            listViewGroup2.Header = "Мастер тесты";
            listViewGroup2.Name = "listViewGroupMasterTests";
            this.listView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.HideSelection = false;
            this.listView.LargeImageList = this.imageList;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.ShowItemToolTips = true;
            this.listView.Size = new System.Drawing.Size(469, 571);
            this.listView.SmallImageList = this.imageList;
            this.listView.TabIndex = 41;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            this.listView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView_MouseDown);
            this.listView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView_ItemSelectionChanged);
            // 
            // splitter
            // 
            this.splitter.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter.Location = new System.Drawing.Point(469, 0);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(3, 571);
            this.splitter.TabIndex = 40;
            this.splitter.TabStop = false;
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.Controls.Add(this.testSettings);
            this.panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel.Enabled = false;
            this.panel.Location = new System.Drawing.Point(472, 0);
            this.panel.MinimumSize = new System.Drawing.Size(434, 4);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(434, 571);
            this.panel.TabIndex = 39;
            // 
            // testSettings
            // 
            this.testSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.testSettings.Location = new System.Drawing.Point(0, 0);
            this.testSettings.MinimumSize = new System.Drawing.Size(346, 502);
            this.testSettings.Name = "testSettings";
            this.testSettings.Size = new System.Drawing.Size(434, 538);
            this.testSettings.TabIndex = 38;
            // 
            // ProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 571);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.panel);
            this.DoubleBuffered = true;
            this.Name = "ProjectForm";
            this.Text = "Проект";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProjectForm_FormClosing);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderQCount;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Splitter splitter;
        private TestSettings testSettings;
        private System.Windows.Forms.Panel panel;


    }
}
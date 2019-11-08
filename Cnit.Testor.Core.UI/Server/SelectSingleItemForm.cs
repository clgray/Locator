using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnit.Testor.Core.Server;
using Cnit.Testor.Core.UI.Server.Controls;

namespace Cnit.Testor.Core.UI.Server
{
    public partial class SelectSingleItemForm : Form
    {
        private TreeView itemTreeView;
        private TestorTreeItem _selectedItem;
        private TestorCoreUser _resultUser;
        private SystemTreeView _treeView;

        public TestorCoreUser ResultUser
        {
            get
            {
                return _resultUser;
            }
        }

        public TestorTreeItem SelectedItem
        {
            get
            {
                return _selectedItem;
            }
        }

        public TestorData TestSettings
        {
            get
            {
                return (itemTreeView as TestTreeView).GetTestSettings(_selectedItem.TestId.Value);
            }
        }

        public SelectSingleItemForm(TestorCoreUser user, TestingServerItemType itemType)
            : this(itemType)
        {
            _resultUser = user;
        }
        public SelectSingleItemForm(TestingServerItemType itemType, string text)
            : this(itemType)
        {
            this.Text = text;
        }

        public SelectSingleItemForm(TestingServerItemType itemType)
        {
            InitializeComponent();
            switch (itemType)
            {
                case TestingServerItemType.None:
                    break;
                case TestingServerItemType.TestTree:
                    {
                        itemTreeView = new TestTreeView();
                        this.Text = "Выбрать тест";
                    } break;
                case TestingServerItemType.ActiveTestTree:
                    {
                        itemTreeView = new TestTreeView();
                        this.Text = "Выбрать тест";
                    } break;
                case TestingServerItemType.GroupTree:
                    {
                        itemTreeView = new GroupTreeView();
                        this.Text = "Выбрать группу";
                    } break;
                case TestingServerItemType.FolderTree:
                    {
                        itemTreeView = new TestTreeView();
                        this.Text = "Выбрать папку";
                    } break;
                default:
                    break;
            }
            InitItemTreeView();
            _treeView = (itemTreeView as SystemTreeView);
            _treeView.InitTreeView(itemType, null, true);
            _treeView.ItemSelected += new EventHandler<TestorItemSelectedEventArgs>(groupTreeView_ItemSelected);
        }

        private void InitItemTreeView()
        {
            this.itemTreeView.AllowDrop = true;
            this.itemTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.itemTreeView.FullRowSelect = true;
            this.itemTreeView.ImageIndex = 0;
            this.itemTreeView.ImageList = this.imageListMain;
            this.itemTreeView.Location = new System.Drawing.Point(0, 0);
            this.itemTreeView.Name = "itemTreeView";
            this.itemTreeView.SelectedImageIndex = 0;
            this.itemTreeView.Size = new System.Drawing.Size(448, 382);
            this.itemTreeView.TabIndex = 0;
            panelTreeView.Controls.Add(this.itemTreeView);
        }

        void groupTreeView_ItemSelected(object sender, TestorItemSelectedEventArgs e)
        {
            if (e.Item.ItemId <= 0)
                _selectedItem = null;
            else
                _selectedItem = e.Item;
        }
    }
}

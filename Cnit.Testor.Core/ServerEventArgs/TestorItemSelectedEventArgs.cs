using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cnit.Testor.Core.Server
{
    public class TestorItemSelectedEventArgs : EventArgs
    {
        private TestorTreeItem _item;
        private TreeViewEventArgs _treeEventArgs;

        public TestorTreeItem Item
        {
            get
            {
                return _item;
            }
        }

        public TreeViewEventArgs TreeEventArgs
        {
            get
            {
                return _treeEventArgs;
            }
            set
            {
                _treeEventArgs = value;
            }
        }

        public TestorItemSelectedEventArgs(TestorTreeItem item)
        {
            _item = item;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnit.Testor.Core.Server;

namespace Cnit.Testor
{
    public sealed class TestorTagItem
    {
        private TestorTreeItem _treeItem;
        private bool _isChildProcessed;

        public TestorTreeItem TreeItem
        {
            get
            {
                return _treeItem;
            }
            set
            {
                _treeItem = value;
            }
        }

        public bool IsChildProcessed
        {
            get
            {
                return _isChildProcessed;
            }
            set
            {
                _isChildProcessed = value;
            }
        }

        public TestorTagItem(TestorTreeItem treeItem)
        {
            _treeItem = treeItem;
        }
    }
}

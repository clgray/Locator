using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Cnit.Testor.Core.Server
{
    [Serializable]
    [DataContract]
    public sealed class TestorTreeItem
    {
        private TestorItemType _itemType;
        private int _itemId;
        private int? _testId;
        private int? _itemOwner;
        private string _itemName;
        private string _groupCode;
        private bool _isGroupAdmin;
        private bool _isActive;
        private TestorTreeItem[] _subItems;

        [DataMember(IsRequired=true)]
        public TestorItemType ItemType
        {
            get
            {
                return _itemType;
            }
            set
            {
                _itemType = value;
            }
        }

        [DataMember(IsRequired = true)]
        public int ItemId
        {
            get
            {
                return _itemId;
            }
            set
            {
                _itemId = value;
            }
        }

        [DataMember(IsRequired = true)]
        public string ItemName
        {
            get
            {
                return _itemName;
            }
            set
            {
                _itemName = value;
            }
        }

        [DataMember(IsRequired = true)]
        public string GroupCode
        {
            get
            {
                return _groupCode;
            }
            set
            {
                _groupCode = value;
            }
        }

        [DataMember(IsRequired = true)]
        public TestorTreeItem[] SubItems
        {
            get
            {
                return _subItems;
            }
            set
            {
                _subItems = value;
            }
        }

        [DataMember(IsRequired = true)]
        public int? TestId
        {
            get
            {
                return _testId;
            }
            set
            {
                _testId = value;
            }
        }

        [DataMember]
        public bool IsGroupAdmin
        {
            get
            {
                return _isGroupAdmin;
            }
            set
            {
                _isGroupAdmin = value;
            }
        }

        [DataMember]
        public int? ItemOwner
        {
            get
            {
                return _itemOwner;
            }
            set
            {
                _itemOwner = value;
            }
        }

        [DataMember(IsRequired = true)]
        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
            }
        }

        public override string ToString()
        {
            return _itemName;
        }

        public TestorTreeItem(int itemId, int? testId, string itemName, TestorItemType itemType, TestorTreeItem[] subItems)
        {
            _itemId = itemId;
            _itemName = itemName;
            _itemType = itemType;
            _testId = testId;
            _isGroupAdmin = false;
            if (subItems != null)
                _subItems = subItems;
            else
                _subItems = new TestorTreeItem[] { };
        }

        public TestorTreeItem()
        {
            _subItems = new TestorTreeItem[] { };
            _testId = null;
            _isGroupAdmin = false;
        }
    }
}

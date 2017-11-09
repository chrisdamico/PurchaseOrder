using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrder
{
    public class Item
    {
        public Item(string name, ItemType itemType)
        {
            _name = name;
            _itemType = itemType;
        }

        private string _name;
        private ItemType _itemType;

        public string Name { get => _name; }
        public ItemType ItemType { get => _itemType; }
    }
}

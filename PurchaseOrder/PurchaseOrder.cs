using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrder
{
    public class PurchaseOrder
    {
        public PurchaseOrder(Customer customer, List<Item> itemsList, string poNumber, double total)
        {
            _customer = customer;
            _itemsList = itemsList;
            _poNumber = poNumber;
            _total = total;
        }

        private Customer _customer;
        private List<Item> _itemsList;
        private string _poNumber;
        private double _total;

        public Customer Customer { get => _customer; }
        public List<Item> ItemsList { get => _itemsList; }
        public string PoNumber { get => _poNumber; }
        public double Total { get => _total; }


    }
}

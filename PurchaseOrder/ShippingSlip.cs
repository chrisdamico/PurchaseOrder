using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrder
{
    public class ShippingSlip
    {
        public ShippingSlip(string customerName, string customerAddress, string returnAddress,
            string poNumber, string poTotal)
        {
            _customerName = customerName;
            _customerAddress = customerAddress;
            _returnAddress = returnAddress;
            _poNumber = poNumber;
            _poTotal = poTotal;
        }
        private string _customerName;
        private string _customerAddress;
        private string _returnAddress;
        private string _poNumber;
        private string _poTotal;
        
        public void printSlip()
        {
            //print line
        }

    }
}

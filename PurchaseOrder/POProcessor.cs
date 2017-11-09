using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrder
{
    public class POProcessor
    {
        public POProcessor(PurchaseOrder po, List<BusinessRule> businessRules)
        {
            _po = po;
            _businessRules = businessRules;
        }
        private PurchaseOrder _po;
        private List<BusinessRule> _businessRules;

        public void processPurchaseOrder()
        {

        }

        public void updateCustomerAccountType(MembershipType membershipType)
        {
            _po.Customer.changeMembershipType(membershipType);
        }

        public void printShippingSlip()
        {
            ShippingSlip slip = new ShippingSlip(_po.Customer.Name, _po.Customer.Address,
                "RETURN ADDRESS", _po.PoNumber, _po.Total);
            slip.printSlip();

        }
    }
}

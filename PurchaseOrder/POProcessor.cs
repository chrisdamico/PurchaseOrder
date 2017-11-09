using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

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

        public PurchaseOrder PO { get => _po; }
        public List<BusinessRule> BusinessRules { get => _businessRules;}

        public void processPurchaseOrder()
        {
            foreach (Item item in _po.ItemsList)
            {
                List<BusinessRule> removeRules = new List<BusinessRule>();
                foreach(BusinessRule rule in _businessRules)
                {
                    bool ruleActioned = actionRule(rule, item);
                    if (rule.OneTimeRule && ruleActioned)
                        removeRules.Add(rule);
                }

                //remove single use rules from the collection so they aren't
                //actioned again
                foreach(BusinessRule removeRule in removeRules)
                {
                    _businessRules.Remove(removeRule);
                }
            }
        }

        public bool actionRule(BusinessRule rule, Item item)
        {
            switch (rule.ValueComparison)
            {
                case Comparator.Equals:
                    switch (rule.Value1.ToString().ToUpper())
                    {
                        case "ITEMTYPE":
                            if (item.ItemType.ToString().ToUpper() == rule.Value2.ToString().ToUpper())
                            {
                                Type thisType = this.GetType();
                                MethodInfo theMethod = thisType.GetMethod(rule.MethodName);
                                theMethod.Invoke(this, rule.HasParameter ? new object[] { item } : null);

                                return true;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case Comparator.GreaterThan:
                    break;
                case Comparator.LessThan:
                    break;
                case Comparator.NotEquals:
                    break;
            }
            return false;
        }

        public void updateCustomerAccountType(Item item)
        {
            if (item.ItemType == ItemType.Membership)
            {
                MembershipType membershipType;
                switch (item.Name.ToUpper())
                {
                    case "BOOK CLUB MEMBERSHIP":
                        membershipType = MembershipType.Book;
                        break;
                    case "VIDEO CLUB MEMBERSHIP":
                        membershipType = MembershipType.Video;
                        break;
                    case "PREMIUM MEMBERSHIP":
                        membershipType = MembershipType.Premium;
                        break;
                    default:
                        membershipType = MembershipType.None;
                        break;

                }

                _po.Customer.changeMembershipType(membershipType);

            }
        }

        public void printShippingSlip()
        {
            ShippingSlip.printSlip(_po.Customer.Name, _po.Customer.Address,
                "RETURN ADDRESS", _po.PoNumber, _po.Total.ToString());

            _po.PackingSlipPrinted = true;
            
        }
    }
}

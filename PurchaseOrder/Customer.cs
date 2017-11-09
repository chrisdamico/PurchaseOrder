using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrder
{
    public class Customer
    {
        private string _customerNumber;
        private string _name;
        private string _address;
        private MembershipType _membershipType;
        private bool _customerChanged;

        public string CustomerNumber { get => _customerNumber; }
        public string Name { get => _name; }
        public string Address { get => _address; }

        public void changeMembershipType(MembershipType membershipType)
        {
            if (membershipType != _membershipType)
            {
                if (membershipType == MembershipType.Book || membershipType == MembershipType.Video)
                {
                    _membershipType = MembershipType.Premium;
                }
                else
                {
                    _membershipType = membershipType;
                }

                //in a real world scenario, we'd want to update this customer in storage
                _customerChanged = true; 
            }
        }

        public Boolean isBookMember()
        {
            return _membershipType == MembershipType.Book ||
                _membershipType == MembershipType.Premium;
        }

        public Boolean isVideoMember()
        {
            return _membershipType == MembershipType.Video ||
                _membershipType == MembershipType.Premium;
        }
    }
}

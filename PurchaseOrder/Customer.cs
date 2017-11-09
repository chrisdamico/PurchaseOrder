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

        public Customer(string customerNumber, string name, string address, string membershipType)
        {
            _customerNumber = customerNumber;
            _name = name;
            _address = address;
            switch(membershipType.ToUpper())
            {
                case "BOOK":
                    _membershipType = MembershipType.Book;
                    break;
                case "VIDEO":
                    _membershipType = MembershipType.Video;
                    break;
                case "PREMIUM":
                    _membershipType = MembershipType.Premium;
                    break;
                default:
                    _membershipType = MembershipType.None;
                    break;
            }
        }

        public string CustomerNumber { get => _customerNumber; }
        public string Name { get => _name; }
        public string Address { get => _address; }

        public void changeMembershipType(MembershipType membershipType)
        {
            if (membershipType != _membershipType)
            {
                if (_membershipType == MembershipType.Book || _membershipType == MembershipType.Video)
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

        public bool isBookMember()
        {
            return _membershipType == MembershipType.Book ||
                _membershipType == MembershipType.Premium;
        }

        public bool isVideoMember()
        {
            return _membershipType == MembershipType.Video ||
                _membershipType == MembershipType.Premium;
        }
    }
}

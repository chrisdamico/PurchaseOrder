﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrder
{
    public enum Comparator
    {
        Equals,
        GreaterThan,
        LessThan,
        NotEquals
        
    }

    public enum MembershipType
    {
        Book,
        None,
        Premium,
        Video
    }

    public enum ItemType
    {
        Book,
        Membership,
        Video
    }
    
}

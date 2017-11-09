using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrder
{
    
    public class BusinessRule
    {
        private object _value1;
        private object _value2;
        private Comparator _valueComparison;
        private string _methodName;
        private Boolean _oneTimeRule = false;

        public BusinessRule(object value1, object value2, Comparator valueComparison,
            string methodName)
        {
            _value1 = value1;
            _value2 = value2;
            _valueComparison = valueComparison;
            _methodName = methodName;
        }

        public object Value1 { get => _value1; }
        public object Value2 { get => _value2; }
        public object ValueComparison { get => _valueComparison; }
        public object MethodName { get => _methodName; }
        public bool RuleApplied { get => _oneTimeRule; }
    }
}

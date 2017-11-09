using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrder
{
    
    public class BusinessRule
    {
        private object _value1;
        private object _value2;
        private Comparator _valueComparator;
        private string _methodName;
        private bool _oneTimeRule = false;
        private bool _hasParameter;

        public BusinessRule(object value1, object value2, string valueComparator,
            string methodName, bool oneTimeRule, bool hasParameter)
        {
            _value1 = value1;
            _value2 = value2;
            switch(valueComparator.ToUpper())
            {
                case "EQUALTO":
                    _valueComparator = Comparator.Equals;
                    break;
                case "NOTEQUALTO":
                    _valueComparator = Comparator.NotEquals;
                    break;
                case "GREATERTHAN":
                    _valueComparator = Comparator.GreaterThan;
                    break;
                case "LESSTHAN":
                    _valueComparator = Comparator.LessThan;
                    break;
                default:
                    break;
                
            }
            _methodName = methodName;
            _oneTimeRule = oneTimeRule;
            _hasParameter = hasParameter;
        }

        public object Value1 { get => _value1; }
        public object Value2 { get => _value2; }
        public Comparator ValueComparison { get => _valueComparator; }
        public string MethodName { get => _methodName; }
        public bool OneTimeRule { get => _oneTimeRule; }
        public bool HasParameter { get => _hasParameter; }
    }
}

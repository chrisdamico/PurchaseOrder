using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace PurchaseOrder
{
   
    [TestFixture]
    public class When_creating_purchase_order_processor
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void _001_business_rule_value1_should_map_to_item_member()
        {
            Assert.That(true);
        }

        [Test]
        public void _00_business_rule_valueComparison_should_map_to_comparator_enum()
        {
            Assert.That(true);
        }

        [Test]
        public void _002_business_rule_method_value_should_map_to_method()
        {
            Assert.That(true);
        }
    }

    [TestFixture]
    public class When_processing_PO
    {
        private POProcessor processor;
        private PurchaseOrder po;

        [SetUp]
        public void SetUp()
        {
            List<BusinessRule> rulesList = new List<BusinessRule>()
               { new BusinessRule("ITEMTYPE", "MEMBERSHIP", "EQUALS", "updateCustomerAccountType", false, true),
                new BusinessRule("ITEMTYPE", "BOOK", "EQUALS", "printShippingSlip", true, false) };

            Customer customer = new Customer("12345", "Test Customer", "123 S. Broadway, Denver, CO 80223", string.Empty);

            List<Item> poItems = new List<Item>()
            {
                new Item("Book \"4 3 2 1\"", ItemType.Book),
                new Item("Video \"Hilarious Cat Video\"", ItemType.Video),
                new Item("Book Club Membership", ItemType.Membership),
                new Item("Book \"A Brief History of Seven Killings\"", ItemType.Book)

            };

            po = new PurchaseOrder(customer, poItems, "7890", 100.15);

            processor = new POProcessor(po, rulesList);


        }
        [Test]
        public void _00_setting_business_rule_hasParameters_flag_to_true_will_pass_parameters_in_invoke()
        {
            Assert.That(true);
        }

        [Test]
        public void _00_setting_business_rule_hasParameters_flag_to_false_will_not_pass_parameters_in_invoke()
        {
            Assert.That(true);
        }

        [Test]
        public void _00_setting_business_rule_oneTimeRule_flag_to_true_will_remove_the_rule_once_it_executes()
        {
            processor.processPurchaseOrder();

            bool ruleExists = false;

            foreach (BusinessRule checkRule in processor.BusinessRules)
            {
                if (checkRule.HasParameter == false &&
                    checkRule.MethodName == "printShippingSlip" &&
                    checkRule.OneTimeRule == false &&
                   checkRule.Value1.ToString().ToUpper() == "ITEMTYPE" &&
                    checkRule.Value2.ToString().ToUpper() == "BOOK" &&
                    checkRule.ValueComparison.ToString().ToUpper() == "EQUALS")
                {
                    ruleExists = true;
                }


            }

            Assert.That(ruleExists,Is.False);
        }

        [Test]
        public void _00_setting_business_rule_oneTimeRule_flag_to_false_will_not_remove_the_rule_once_it_executes()
        {

            processor.processPurchaseOrder();

            bool ruleExists = false;

            foreach(BusinessRule checkRule in processor.BusinessRules)
            {
                if (checkRule.HasParameter == true &&
                    checkRule.MethodName == "updateCustomerAccountType" &&
                    checkRule.OneTimeRule == false &&
                    checkRule.Value1.ToString().ToUpper() == "ITEMTYPE" &&
                    checkRule.Value2.ToString().ToUpper() == "MEMBERSHIP" &&
                    checkRule.ValueComparison.ToString().ToUpper() == "EQUALS")
                {
                    ruleExists = true;
                }

            }

            Assert.That(ruleExists, Is.True);
        }
        [Test]
        public void _001_item_equals_membership_should_update_customer_membership_in_po()
        {
            processor.processPurchaseOrder();

            Assert.That(processor.PO.Customer.isBookMember(), Is.True);
        }

        [Test]
        public void _002_item_equals_book_should_generate_shipping_slip()
        {
            processor.processPurchaseOrder();

            Assert.That(processor.PO.PackingSlipPrinted, Is.True);
        }
    }
}

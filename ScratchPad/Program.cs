using System;
using System.Reflection;

namespace ScratchPad
{
    class Program
    {
        
        static void Main(string[] args)
        {
            TestClass testClass = new TestClass();
            testClass.testInvokeMember();
            Console.ReadKey();
            Console.WriteLine("Hello World!");
        }

        
    }

   

    

    public class TestClass
    {
       

        public TestClass() { }
        public void printThis()
        {
            Console.WriteLine("PRINT THIS");
        }

        public void testInvokeMember()
        {
            object var1 = "blah";
            object var2 = "blah";
            string var3 = "printThis";
            Comparator compType = Comparator.Equality;
            switch (compType)
            {
                case Comparator.Equality:
                    if (var1 == var2)
                    {
                        Type thisType = this.GetType();
                        MethodInfo theMethod = thisType.GetMethod(var3);
                        theMethod.Invoke(this, null);

                        ((this.GetType()).GetMethod(var3)).Invoke(this,null);

                    }
                    break;
            }

            
        }
    }
}

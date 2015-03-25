using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SnippetsTest.Basics.Operator
{
    // operator are overloaded, not overriden
    // http://geekswithblogs.net/BlackRabbitCoder/archive/2011/07/07/c.net-little-pitfalls-operators-are-overloaded-not-overridden.aspx
    class MyClass
    {
        private readonly int _value;

        public MyClass(int i)
        {
            _value = i;
        }

        public int Value
        {
            get { return _value; }
        }

        public static MyClass operator +(MyClass o1, MyClass o2)
        {
            return new MyClass(o1._value + o2._value);
        }

        public static MyClass operator ++(MyClass o1)
        {
            return new MyClass(o1._value + 1);
        }

        public static implicit operator MyClass(bool b)
        {
            return new MyClass(b ? 1 : 0);
        }

        public static implicit operator bool(MyClass o)
        {
            return o._value > 0;
        }

        public static explicit operator MyClass(string s)
        {
            return new MyClass(int.Parse(s));
        }

        public static bool operator ==(MyClass a, MyClass b)
        {
            return a._value == b._value;
        }

        public static bool operator !=(MyClass a, MyClass b)
        {
            return !(a == b);
        }
    }


    [TestFixture]
    class Test
    {
        [Test]
        public void Run()
        {
            var op1 = new MyClass(4);
            var op2 = new MyClass(5);
            Assert.AreEqual(9, (op1 + op2).Value);
            ++op2;
            Assert.AreEqual(6, op2.Value);
        }

        [Test]
        public void Implicit()
        {
            MyClass res = true;
            Assert.AreEqual(1, res.Value);

            Assert.AreEqual(false, new MyClass(0));
        }

        [Test]
        public void Explicit()
        {
            // MyClass o1 = "1"; // would have worked if operator was implicit
            var o2 = (MyClass) "5";
            Assert.AreEqual(5, o2.Value);
        }

        public void ImplicitBoolOperator()
        {
            var res = new MyClass(1);
            if (res) ;
        }
        
        /*
         * Perfectly syntactically legal because == works between two type object references, and 
         * Fraction inherits from object (as all types do) so we can assign a Fraction to object.  
         * But now we yield false instead!  Why?
         * Because, the == operator is an overload, not an override.  We have not replaced the behavior 
         * of == dynamically at run-time, but are binding to the definition of == at compile-time.  
         * And the two types it is appearing between are object which means we’d get a reference equality check.  
         * And since oneHalf and anotherOneHalf are obviously referring to separate (though “identical”) objects, 
         * the comparison yields false!
         * 
         * To achieve virtuality in oeprator we need to implement a virtual method ourselves.
         */
        [Test]
        public void OperatorAreOverloaded()
        {
            var c1 = new MyClass(5);
            var c2 = new MyClass(5);
            Assert.IsTrue(c1 == c2);

            object o1 = new MyClass(5);
            object o2 = new MyClass(5);
            Assert.IsFalse(o1 == o2);
        }
    }
}

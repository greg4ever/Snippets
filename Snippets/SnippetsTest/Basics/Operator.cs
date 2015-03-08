using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SnippetsTest.Basics.Operator
{
    class Operator
    {
        private readonly int _value;

        public Operator(int i)
        {
            _value = i;
        }

        public int Value
        {
            get { return _value; }
        }

        public static Operator operator +(Operator o1, Operator o2)
        {
            return new Operator(o1._value + o2._value);
        }

        public static Operator operator ++(Operator o1)
        {
            return new Operator(o1._value + 1);
        }

        public static implicit operator Operator(bool b)
        {
            return new Operator(b ? 1 : 0);
        }

        public static implicit operator bool(Operator o)
        {
            return o._value > 0;
        }

        public static explicit operator Operator(string s)
        {
            return new Operator(int.Parse(s));
        }
    }


    [TestFixture]
    class Test
    {
        [Test]
        public void Run()
        {
            var op1 = new Operator(4);
            var op2 = new Operator(5);
            Assert.AreEqual(9, (op1 + op2).Value);
            ++op2;
            Assert.AreEqual(6, op2.Value);
        }

        [Test]
        public void Implicit()
        {
            Operator res = true;
            Assert.AreEqual(1, res.Value);

            Assert.AreEqual(false, new Operator(0));
        }

        [Test]
        public void Explicit()
        {
            // Operator o1 = "1"; // would have worked if operator was implicit
            var o2 = (Operator) "5";
            Assert.AreEqual(5, o2.Value);
        }

        public void ImplicitBoolOperator()
        {
            var res = new Operator(1);
            if (res) ;
        }
    }
}

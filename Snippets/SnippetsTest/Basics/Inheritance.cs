using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SnippetsTest.Basics.Inheritance
{
    class A
    {
        public virtual void Function(int a)
        {
            Debug.WriteLine("A.Int");
        }
    }

    class B : A
    {
        public override void Function(int a)
        {
            Debug.WriteLine("B.Int");
        }

        public void Function(double a)
        {
            Debug.WriteLine("B.Double");
        }
    }

    [TestFixture]
    class Test
    {
        [Test]
        public void Run()
        {
            B a = new B();
            a.Function(1); // display B.Double
        }
    }
}

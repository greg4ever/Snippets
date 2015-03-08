using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SnippetsTest.Basics.NamedParameter
{
    public class MyClass
    {
        public void Test(int a, int b, int c) { }
    }

    [TestFixture]
    class TestClass
    {
        [Test]
        public void Run()
        {
            var c = new MyClass();
            c.Test(c:3, b:2, a:1);
        }
    }
}

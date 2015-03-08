using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SnippetsTest.Basics
{
    [TestFixture]
    public class Cast
    {
        class Base { }
        class Extended : Base { }
        class Other { }

        [Test]
        public void Misc()
        {
            var a = (Exception)null; // valid but throws InvalidCastException

            var b = new Base();
            var c = (Extended)b; // compile but throws InvalidCastException
            // var d = (Other)b; does not compile, safe type check
            // var d = b as Other; does not compile neither
        }
    }
}

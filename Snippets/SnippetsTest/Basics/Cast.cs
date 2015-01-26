using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SnippetsTest.Basics
{
    [TestClass]
    class Cast
    {
        class Base { }
        class Extended : Base { }
        class Other { }

        public void Misc()
        {
            var a = (Exception)null; // valid

            var b = new Base();
            var c = (Extended)b;
            // var d = (Other)b; does not compile, safe type check
            // var d = b as Other; does not compile neither
        }
    }
}

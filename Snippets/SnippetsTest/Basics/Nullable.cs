using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SnippetsTest.Basics
{
    [TestFixture]
    class Nullable
    {
        [Test]
        public void LiftedOperator()
        {
            var i = 5;
            // compile thanks to lifted operator. i is boxed into a Nullable<int> and compared to null.
            var res = i == null; 
        }
    }
}

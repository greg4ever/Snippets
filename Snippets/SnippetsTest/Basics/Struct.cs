using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework;

namespace SnippetsTest.Basics
{
    [TestFixture]
    public class Struct
    {
        struct A
        {
            public int AA { get; set; }
            public double BB { get; set; }

            public void Run()
            {
            }
        }

        [Test]
        public void CannotUseUnitializedMember()
        {
            A aa;
            // var tmp = aa.AA; does not compile - use of unassigned local variable aa
            // aa.Run(); same
            // aa.AA = 10; same
        }
    }
}

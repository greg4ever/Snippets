using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SnippetsTest.Basics
{
    [TestClass]
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

        [TestMethod]
        public void CannotUseUnitializedMember()
        {
            A aa;
            // var tmp = aa.AA; does not compile - use of unassigned local variable aa
            // aa.Run(); same
            // aa.AA = 10; same
        }
    }
}

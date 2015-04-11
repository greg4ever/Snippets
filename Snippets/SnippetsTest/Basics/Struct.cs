using System;
using System.Collections.Generic;
using System.Drawing;
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

        class B
        {
            public class MyPoint
            {
                public int X;
                public int Y;
            }

            private Point _point;
            private MyPoint _myPoint;

            public Point Point { get; set; }
            public MyPoint PointClass { get; set; }
        }

        [Test]
        public void CompilerErrorWhenStructProperty()
        {
            var b = new B();
            // b.Point.X += 5; // cannot modify the expression because it is not a variable
            b.PointClass.X += 5;
        }
    }
}

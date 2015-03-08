using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTmp._1._Creational
{
    class FluentOpion
    {
        private int _maturity;
        private double _strike;

        public static FluentOpion Create()
        {
            return new FluentOpion();
        }

        public FluentOpion WithMaturity(int date)
        {
            _maturity = date;
            return this;
        }

        public FluentOpion WithStrike(double d)
        {
            _strike = d;
            return this;
        }
    }

    class Test
    {
        static void Run()
        {
            var myOption = FluentOpion.Create().WithMaturity(20140525).WithStrike(12000);
        }
    }
}

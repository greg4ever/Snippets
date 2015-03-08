using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTmp._2._Structural.Bridge
{
    interface IOption
    {
        int Price();
    }

    class Option : IOption
    {
        private int _maturity;
        private double _strike;
        private readonly OptionPricer _optionPricer = new OptionPricer();

        public virtual int Price()
        {
            return _optionPricer.PriceMe();
        }
    }

    class OptionPricer
    {
        public int PriceMe()
        {
            return 10;
        }
    }
}

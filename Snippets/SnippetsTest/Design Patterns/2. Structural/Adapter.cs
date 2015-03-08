using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTmp._2._Structural.Adapter
{
    interface IOption
    {
        int Price();
    }

    class Option : IOption
    {
        private int _maturity;
        private double _strike;

        public virtual int Price()
        {
            return 10;
        }
    }

    class BarrierOption : Option // can use the interface too (like decorator)
    {
        private readonly IOption _option;
        private readonly CustomPricer _customPricer;

        public BarrierOption(IOption option)
        {
            _option = option;
            _customPricer = new CustomPricer();
        }

        public override int Price()
        {
            return _customPricer.Price();
        }
    }

    class CustomPricer
    {
        public int Price()
        {
            return 10;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTmp._2._Structural
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

    class BarrierOption : Option
    {
        private readonly IOption _option;

        public BarrierOption(IOption option)
        {
            _option = option;
        }

        public override int Price()
        {
            return _option.Price() + 1;
        }
    }
}

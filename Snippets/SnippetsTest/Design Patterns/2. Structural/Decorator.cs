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

        public int Price()
        {
            return 10;
        }
    }

    class BarrierOption : IOption // can be inherited
    {
        private IOption _option;

        public BarrierOption(IOption option)
        {
            _option = option;
        }

        public int Price()
        {
            return _option.Price() + 1;
        }
    }
}

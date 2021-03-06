﻿using System;
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

    class BarrierOption : Option
    {
        private readonly BarrierOptionExternalLib _adaptee = new BarrierOptionExternalLib();

        public override int Price()
        {
            return _adaptee.PriceMe();
        }
    }

    class BarrierOptionExternalLib
    {
        public int PriceMe()
        {
            return 20;
        }
    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTmp._3._Behavioral.Visitor
{
    interface IPricerVisitor
    {
        void Visit(VanillaOption option);
        void Visit(BarrierOption option);
    }

    interface IPricerVisitable
    {
        void Accept(IPricerVisitor pricerVisitor);
    }

    abstract class OptionBase
    {
        public int Maturity { get; set; }
        public double Strike { get; set; }
    }

    class VanillaOption : OptionBase, IPricerVisitable
    {
        public void Accept(IPricerVisitor pricerVisitor)
        {
            pricerVisitor.Visit(this);
        }
    }

    class BarrierOption : OptionBase, IPricerVisitable
    {
        public double KnockOut { get; set; }

        public void Accept(IPricerVisitor pricerVisitor)
        {
            pricerVisitor.Visit(this);
        }
    }

    class MyPricer : IPricerVisitor
    {
        private double _res;

        public double Price(IPricerVisitable option)
        {
            option.Accept(this);
            return _res;
        }

        public void Visit(VanillaOption option)
        {
            _res = option.Maturity*12;
        }

        public void Visit(BarrierOption option)
        {
            _res = option.Maturity * 12 + option.KnockOut * 24;
        }
    }
}

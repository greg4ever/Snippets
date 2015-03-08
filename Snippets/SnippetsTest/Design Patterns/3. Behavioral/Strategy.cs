using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnippetsTest.Design_Patterns._3._Behavioral
{
    interface IPricer
    {
        double Price();
    }

    class VanillaOptionPricer : IPricer
    {
        public double Price()
        {
            return 10;
        }
    }

    class BarrierOptionPricer : IPricer
    {
        public double Price()
        {
            return 20;
        }
    }

    class PricerContext
    {
        private readonly IPricer _pricer = new VanillaOptionPricer();

        public void PriceMe()
        {
            _pricer.Price();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTmp._3._Behavioral.State
{
    class PricingContext
    {
        public PricingState State { get; set; }

        public void Price()
        {
            State.Price(this);
        }
    }

    abstract class PricingState
    {
        public abstract void Price(PricingContext context);
    }

    class CheckInstrumentValidityState : PricingState
    {
        public override void Price(PricingContext context)
        {
            // Check instrument validity
            context.State = new RequestPricingCurvePricingState();
        }
    }

    class RequestPricingCurvePricingState : PricingState
    {
        public override void Price(PricingContext context)
        {
            // ServiceLocator.PricingCurveService.RequestPricingCurves();
            context.State = new EffectivePricingState();
        }
    }

    class EffectivePricingState : PricingState
    {
        public override void Price(PricingContext context)
        {
            // Price
            context.State = new PricingDoneState();
        }
    }

    class PricingDoneState : PricingState
    {
        public override void Price(PricingContext context)
        {
            // Nothing
        }
    }

    class Test
    {
        public static void Run()
        {
            var pricingContext = new PricingContext();
            while(pricingContext.State.GetType() != typeof(PricingDoneState))
            {
                pricingContext.Price();
            }
        }
    }
}

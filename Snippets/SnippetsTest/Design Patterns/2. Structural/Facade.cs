using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTmp._2._Structural
{
    interface IFacade
    {
        void RequestData();
        void RequestPrice();
    }

    class Facade
    {
        private readonly DataRequestor _dataRequestor = new DataRequestor();
        private readonly PriceRequestor _priceRequestor = new PriceRequestor();

        public void RequestData()
        {
            _dataRequestor.RequestData();
        }

        public void RequestPrice()
        {
            _priceRequestor.RequestPrice();
        }
    }

    class DataRequestor
    {
        public void RequestData() { }
    }

    class PriceRequestor
    {
        public void RequestPrice() { }
    }
}

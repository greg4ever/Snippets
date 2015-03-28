using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Assignment.Data;
using Assignment.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Test.PerformanceTest
{
    [TestClass]
    public class CyclingRouteServicePerformanceTest
    {
        private CyclingRouteService _service;

        [TestInitialize]
        public void BeforeTest()
        {
            _service = new CyclingRouteService();
        }

        [TestMethod]
        public void GivenLargeEntries_ShouldExecuteOnTime()
        {
            const int nbRoutes     = 100;
            const int routesLength = 100000;
            const int timeoutInMs  = 2000;

            var mre = new ManualResetEvent(false);
            IList<CyclingItinerary> res = null;

            Task.Factory.StartNew(() =>
            {
                res = _service.GetCyclingRoutes(TestHelper.GenerateRandomRoutes(nbRoutes, routesLength));
                mre.Set();
            });

            var isOnTime = mre.WaitOne(timeoutInMs);

            Assert.IsTrue(isOnTime, "Operation timed out.");
            AssertionHelper.IsListNotNullAndSizeEqualsTo(res, nbRoutes);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
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
                res = _service.GetCyclingRoutes(GenerateRandomRoutes(nbRoutes, routesLength));
                mre.Set();
            });

            var isOnTime = mre.WaitOne(timeoutInMs);

            Assert.IsTrue(isOnTime, "Operation timed out.");
            AssertionHelper.IsListNotNullAndSizeEqualsTo(res, nbRoutes);
        }

        private static List<RouteDescription> GenerateRandomRoutes(int nbRoutes, int routesLength)
        {
            var routes = new List<RouteDescription>(nbRoutes);
            Random rand = new Random();

            for (int i = 0; i < nbRoutes; ++i)
            {
                routes.Add(new RouteDescription(
                    Enumerable.Range(1, routesLength).Select(x => rand.Next(-100, 100)).ToList()));
            }

            return routes;
        }
    }
}

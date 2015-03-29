using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Assignment.Data;
using Assignment.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Test.PerformanceTest
{
    [TestClass]
    public class RouteServicePerformanceTest
    {
        private RouteService _service;
        private readonly Random _rand = new Random();

        [TestInitialize]
        public void BeforeTest()
        {
            _service = new RouteService();
        }

        [TestMethod]
        public void GetCyclingSegment_GivenLargeEntries_ShouldExecuteOnTime()
        {
            const int nbRoutes     = 100;
            const int routesLength = 100000;
            const int timeoutInMs  = 1000;

            var mre    = new ManualResetEvent(false);
            var routes = GenerateRandomRoutes(nbRoutes, routesLength);

            Task.Factory.StartNew(() =>
            {
                var sw = new Stopwatch();
                sw.Start();

                foreach (var route in routes)
                {
                    _service.GetCyclingSegment(route);
                }

                sw.Stop();
                Debug.WriteLine("Elapsed time: ({0}) ms", sw.ElapsedMilliseconds);

                mre.Set();
            });

            var isOnTime = mre.WaitOne(timeoutInMs);

            Assert.IsTrue(isOnTime, "Operation timed out.");
        }

        private List<RouteDescription> GenerateRandomRoutes(int nbRoutes, int routesLength)
        {
            var routes = new List<RouteDescription>(nbRoutes);

            for (var i = 0; i < nbRoutes; ++i)
            {
                routes.Add(new RouteDescription(
                    Enumerable.Range(1, routesLength).Select(_ => _rand.Next(-100, 100)).ToList()));
            }

            return routes;
        }
    }
}

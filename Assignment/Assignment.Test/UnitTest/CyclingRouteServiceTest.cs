using System.Collections.Generic;
using System.Linq;
using Assignment.Data;
using Assignment.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Test.UnitTest
{
    [TestClass]
    public class CyclingRouteServiceTest
    {
        private CyclingRouteService _service; 

        [TestInitialize]
        public void BeforeTest()
        {
            _service = new CyclingRouteService();
        }

        [TestMethod]
        public void GivenNullParameter_ShouldReturnEmpty()
        {
            var res = _service.GetCyclingRoutes(null);
            AssertionHelper.IsListNotNullAndSizeEqualsTo(res, 0);
        }

        [TestMethod]
        public void GivenEmptyParameter_ShouldReturnEmpty()
        {
            var res = _service.GetCyclingRoutes(new List<RouteDescription>());
            AssertionHelper.IsListNotNullAndSizeEqualsTo(res, 0);
        }

        [TestMethod]
        public void GivenEmptyRoute_ShouldReturnNotCyclable()
        {
            var res = _service.GetCyclingRoutes(GenerateRoutes(new int[] { }));
            AssertionHelper.IsListNotNullAndSizeEqualsTo(res, 1);
            AssertionHelper.AssertCyclingItinerary(false, res[0]);
        }

        [TestMethod]
        public void GivenOnlyNegativeRatings_ShouldReturnNotCyclable()
        {
            var res = _service.GetCyclingRoutes(GenerateRoutes(new [] { -1, -2, -3, -4, -5}));
            AssertionHelper.IsListNotNullAndSizeEqualsTo(res, 1);
            AssertionHelper.AssertCyclingItinerary(false, res[0]);
        }

        [TestMethod]
        public void GivenOnlyPositiveRatings_ShouldReturnEntireRoute()
        {
            var res = _service.GetCyclingRoutes(GenerateRoutes(new [] { 1, 2, 3, 4, 5 }));
            AssertionHelper.IsListNotNullAndSizeEqualsTo(res, 1);
            AssertionHelper.AssertCyclingItinerary(true, 1, 6, res[0]);
        }

        [TestMethod]
        public void GivenTwoEqualRoutes_ShouldReturnTheFirst()
        {
            var res = _service.GetCyclingRoutes(GenerateRoutes(new[] { 1, 2, -100, 2, 1 }));
            AssertionHelper.IsListNotNullAndSizeEqualsTo(res, 1);
            AssertionHelper.AssertCyclingItinerary(true, 1, 3, res[0]);
        }

        [TestMethod]
        public void GivenAssignmentInputs_ShouldReturnAssignmentOutputs()
        {
            var routes = GenerateRoutes(
                            new[] { -3, 7 },
                            new[] { 12, -15, 12, -9, 12, 12, -12, 12, -15 },
                            new[] { -7, -2, -8}
                            );

            var res = _service.GetCyclingRoutes(routes);

            AssertionHelper.IsListNotNullAndSizeEqualsTo(res, 3);
            AssertionHelper.AssertCyclingItinerary(true, 2, 3, res[0]);
            AssertionHelper.AssertCyclingItinerary(true, 3, 9, res[1]);
            AssertionHelper.AssertCyclingItinerary(false, res[2]);
        }

        [TestMethod]
        public void GivenCustomInputs_ShouldReturnExpectedOutputs()
        {
            var routes = GenerateRoutes(
                            new[] { 12, -3, 7, -5 },
                            new[] { -10, -10, 5, -10, -10 },
                            new[] { 5, 5, -10, -10, 5, 5, -10 }
                            );

            var res = _service.GetCyclingRoutes(routes);

            AssertionHelper.IsListNotNullAndSizeEqualsTo(res, 3);
            AssertionHelper.AssertCyclingItinerary(true, 1, 4, res[0]);
            AssertionHelper.AssertCyclingItinerary(true, 3, 4, res[1]);
            AssertionHelper.AssertCyclingItinerary(true, 1, 3, res[2]);
        }

        private static List<RouteDescription> GenerateRoutes(params int[][] routes)
        {
            var routesAsList = new List<RouteDescription>(routes.Length);
            routesAsList.AddRange(routes.Select(x => new RouteDescription(x.ToList())));
            return routesAsList;
        }
    }
}

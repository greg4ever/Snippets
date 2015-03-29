using System.Collections.Generic;
using System.Linq;
using Assignment.Data;
using Assignment.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Test.UnitTest
{
    [TestClass]
    public class RouteServiceTest
    {
        private RouteService _service; 

        [TestInitialize]
        public void BeforeTest()
        {
            _service = new RouteService();
        }

        [TestMethod]
        public void GetCyclingSegment_GivenNullParameter_ShouldReturnNoCycling()
        {
            var res = _service.GetCyclingSegment(null);
            AssertionHelper.AssertCyclingItinerary(false, res);
        }

        [TestMethod]
        public void GetCyclingSegment_GivenEmptyRoute_ShouldReturnNoCycling()
        {
            var res = _service.GetCyclingSegment(GenerateRoute());
            AssertionHelper.AssertCyclingItinerary(false, res);
        }

        [TestMethod]
        public void GetCyclingSegment_GivenOnlyNegativeRatings_ShouldReturnNoCycling()
        {
            var res = _service.GetCyclingSegment(GenerateRoute(-1, -2, -3, -4, -5));
            AssertionHelper.AssertCyclingItinerary(false, res);
        }

        [TestMethod]
        public void GetCyclingSegment_GivenOnlyPositiveRatings_ShouldReturnEntireRoute()
        {
            var res = _service.GetCyclingSegment(GenerateRoute(1, 2, 3, 4, 5));
            AssertionHelper.AssertCyclingItinerary(true, 1, 6, res);
        }

        [TestMethod]
        public void GetCyclingSegment_GivenTwoEqualSegments_ShouldReturnTheFirst()
        {
            var res = _service.GetCyclingSegment(GenerateRoute(1, 2, -100, 2, 1));
            AssertionHelper.AssertCyclingItinerary(true, 1, 3, res);
        }

        [TestMethod]
        public void GetCyclingSegment_GivenTwoEquivalentSegments_ShouldReturnTheLongest()
        {
            var res = _service.GetCyclingSegment(GenerateRoute(1, 2, -100, 1, 1, 1));
            AssertionHelper.AssertCyclingItinerary(true, 4, 7, res);
        }

        [TestMethod]
        public void GetCyclingSegment_GivenAssignmentInputs_ShouldReturnAssignmentOutputs()
        {
            var res = _service.GetCyclingSegment(GenerateRoute(-3, 7));
            AssertionHelper.AssertCyclingItinerary(true, 2, 3, res);

            res = _service.GetCyclingSegment(GenerateRoute(12, -15, 12, -9, 12, 12, -12, 12, -15));
            AssertionHelper.AssertCyclingItinerary(true, 3, 9, res);

            res = _service.GetCyclingSegment(GenerateRoute(-7, -2, -8));
            AssertionHelper.AssertCyclingItinerary(false, res);
        }

        [TestMethod]
        public void GetCyclingSegment_GivenCustomInputs_ShouldReturnExpectedOutputs()
        {
            var res = _service.GetCyclingSegment(GenerateRoute(12, -3, 7, -5));
            AssertionHelper.AssertCyclingItinerary(true, 1, 4, res);

            res = _service.GetCyclingSegment(GenerateRoute(-10, -10, 5, -10, -10));
            AssertionHelper.AssertCyclingItinerary(true, 3, 4, res);

            res = _service.GetCyclingSegment(GenerateRoute(5, 5, -10, -10, 5, 5, -10));
            AssertionHelper.AssertCyclingItinerary(true, 1, 3, res);
        }

        private static RouteDescription GenerateRoute(params int[] routes)
        {
            return new RouteDescription(routes.ToList());
        }
    }
}

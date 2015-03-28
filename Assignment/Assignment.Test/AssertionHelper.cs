using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Test
{
    internal static class AssertionHelper
    {
        public static void IsListNotNullAndSizeEqualsTo<T>(IList<T> list, int expectedSize)
        {
            Assert.IsNotNull(list);
            Assert.AreEqual(expectedSize, list.Count);
        }

        public static void AssertCyclingItinerary(bool expectedIsCyclable, CyclingItinerary cyclingItinerary)
        {
            Assert.IsNotNull(cyclingItinerary);
            Assert.AreEqual(expectedIsCyclable,     cyclingItinerary.IsCyclable);
        }

        public static void AssertCyclingItinerary(bool expectedIsCyclable, int expectedBusStopBegin, int expectedBusStopEnd,
            CyclingItinerary cyclingItinerary)
        {
            Assert.IsNotNull(cyclingItinerary);
            Assert.AreEqual(expectedIsCyclable, cyclingItinerary.IsCyclable);
            Assert.AreEqual(expectedBusStopBegin, cyclingItinerary.BusStopBegin);
            Assert.AreEqual(expectedBusStopEnd, cyclingItinerary.BusStopEnd);
        }
    }
}

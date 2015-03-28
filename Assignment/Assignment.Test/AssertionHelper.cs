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

        public static void AssertCyclingItinerary(bool expectedIsCyclable, CyclingSegment cyclingSegment)
        {
            Assert.IsNotNull(cyclingSegment);
            Assert.AreEqual(expectedIsCyclable, cyclingSegment.IsCyclingPossible);
        }

        public static void AssertCyclingItinerary(bool expectedIsCyclable, int expectedBusStopBegin, int expectedBusStopEnd,
            CyclingSegment cyclingSegment)
        {
            Assert.IsNotNull(cyclingSegment);
            Assert.AreEqual(expectedIsCyclable,   cyclingSegment.IsCyclingPossible);
            Assert.AreEqual(expectedBusStopBegin, cyclingSegment.StartingBusStop);
            Assert.AreEqual(expectedBusStopEnd,   cyclingSegment.EndingBusStop);
        }
    }
}

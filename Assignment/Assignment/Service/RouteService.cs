using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment.Data;

namespace Assignment.Service
{
    /// <summary>
    /// This class exposes functionalities related to a route
    /// </summary>
    public class RouteService
    {
        /// <summary>
        /// Given a list of route descriptions, compute and return the longest continuous cycling semgments.
        /// Input order is preserved.
        /// </summary>
        /// <param name="routes">the route descriptions</param>
        /// <returns>the longest continuous cycling segments</returns>
        public IList<CyclingSegment> GetCyclingSegments(IList<RouteDescription> routes)
        {
            if (routes == null)
            {
                return new List<CyclingSegment>();
            }

            var itineraries = new List<CyclingSegment>(routes.Count);
            itineraries.AddRange(routes.Select(ComputeCyclingSegment));
            return itineraries;
        }

        /// <summary>
        /// Give a route description, compute and return the longest continuous cycling segment.
        /// </summary>
        /// <param name="route">the route description</param>
        /// <returns>the longest continuous cycling segment</returns>
        private CyclingSegment ComputeCyclingSegment(RouteDescription route)
        {
            if (route == null || route.SegmentRatings == null)
            {
                return new CyclingSegment(1, 1);
            }

            var sectionRatings = route.SegmentRatings;

            var maxSum     = 0;
            var currentSum = 0;

            // Indexes start at -1 as we here positioned at the first stop, before the first segment
            var beginIndex        = -1;
            var endIndex          = -1;
            var currentBeginIndex = -1;

            for (int i = 0; i < sectionRatings.Count; ++i)
            {
                currentSum += sectionRatings[i];
                if (currentSum >= 0)
                {
                    if (currentSum > maxSum ||
                        // for the same sum, we prefer longest segment
                        currentSum == maxSum && (i - currentBeginIndex) > (endIndex - beginIndex))
                    {
                        beginIndex = currentBeginIndex;
                        endIndex   = i;
                        maxSum     = currentSum;
                    }
                }
                else
                {
                    currentSum          = 0;
                    currentBeginIndex   = i;
                }
            }

            // We add +2 because the result is 1-based, plus we need to count the first stop
            return new CyclingSegment(beginIndex + 2, endIndex + 2);
        }
    }
}

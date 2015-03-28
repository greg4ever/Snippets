﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment.Data;

namespace Assignment.Service
{
    public class CyclingSegmentService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="routes"></param>
        /// <returns></returns>
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
                        // we prefer longest segment
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
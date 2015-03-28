﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment.Data;

namespace Assignment.Service
{
    public class CyclingRouteService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="routes"></param>
        /// <returns></returns>
        public IList<CyclingItinerary> GetCyclingRoutes(IList<RouteDescription> routes)
        {
            if (routes == null)
            {
                return new List<CyclingItinerary>();
            }

            var itineraries = new List<CyclingItinerary>(routes.Count);
            itineraries.AddRange(routes.Select(ComputeCyclingItinerary));
            return itineraries;
        }

        private CyclingItinerary ComputeCyclingItinerary(RouteDescription route)
        {
            if (route == null || route.SectionRatings == null)
            {
                return new CyclingItinerary();
            }

            var sectionRatings = route.SectionRatings;

            var maxSum  = 0;
            var currentSum = 0;

            var beginIndex        = -1;
            var endIndex          = -1;
            var currentBeginIndex = -1;

            for (int i = 0; i < sectionRatings.Count; ++i)
            {
                currentSum += sectionRatings[i];
                if (currentSum >= 0)
                {
                    if (currentSum > maxSum ||
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

            return new CyclingItinerary(beginIndex + 2, endIndex + 2);
        }
    }
}

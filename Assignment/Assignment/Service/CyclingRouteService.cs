using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment.Data;

namespace Assignment.Service
{
    public class CyclingRouteService : ICyclingRouteService
    {
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
                return new CyclingItinerary();;
            }

            var sectionRatings = route.SectionRatings;

            var currentSum = 0;
            var beginIndex = -1;
            var endIndex   = -1;

            for (int i = 0; i < sectionRatings.Count; ++i)
            {
                var newSum = currentSum + sectionRatings[i];
                if (newSum >= 0)
                {
                    if (newSum >= currentSum)
                    {
                        endIndex = i;
                    }
                    currentSum = newSum;
                }
                else
                {
                    currentSum = 0;
                    beginIndex = i;
                    endIndex   = i;
                }
            }

            return new CyclingItinerary(beginIndex + 2, endIndex + 2);
        }
    }
}

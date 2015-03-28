using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment.Data;

namespace Assignment.Service
{
    public interface ICyclingRouteService
    {
        /// <summary>
        /// Return the largest cyclable section for each route. The parameter order is kept.
        /// </summary>
        /// <param name="routes"></param>
        /// <returns></returns>
        IList<CyclingItinerary> GetCyclingRoutes(IList<RouteDescription> routes);
    }
}

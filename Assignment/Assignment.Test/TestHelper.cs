using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment.Data;

namespace Assignment.Test
{
    internal static class TestHelper
    {
        public static List<RouteDescription> GenerateRoutes(params int[][] routes)
        {
            var routesAsList = new List<RouteDescription>(routes.Length);
            routesAsList.AddRange(routes.Select(x => new RouteDescription(x.ToList())));
            return routesAsList;
        }

        public static List<RouteDescription> GenerateRandomRoutes(int nbRoutes, int routesLength)
        {
            var routes = new List<RouteDescription>(nbRoutes);
            Random rand = new Random();

            for(int i = 0; i < nbRoutes; ++i)
            {
                routes.Add(new RouteDescription(
                    Enumerable.Range(1, routesLength).Select(x => rand.Next(-100, 100)).ToList()));
            }

            return routes;
        }
    }
}

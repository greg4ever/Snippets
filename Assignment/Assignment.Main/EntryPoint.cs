using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Data;
using Assignment.Service;
using Microsoft.SqlServer.Server;

namespace Assignment.Main
{
    /// <summary>
    /// The entry point class for the application
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// The entry point for the application
        /// </summary>
        /// <param name="args">a list of command line arguments</param>
        static void Main(string[] args)
        {
            if (args == null || args.Length != 1)
            {
                Console.Error.WriteLine("Bad parameter. Usage: Assignment.Main.exe [FILE]");
                return;
            }

            ProcessFile(args[0]);
        }

        /// <summary>
        /// Read a RouteDescription file and write on standard output the longest continuous cycling segments
        /// </summary>
        /// <param name="filePath">a RouteDescription file</param>
        private static void ProcessFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.Error.WriteLine("File not found: " + filePath);
            }

            List<RouteDescription> routesDescription;

            using (var file = new StreamReader(filePath))
            {
                var nbRoutes = int.Parse(file.ReadLine());
                routesDescription = new List<RouteDescription>(nbRoutes);

                for (int i = 0; i < nbRoutes; ++i)
                {
                    var nbBusStops = int.Parse(file.ReadLine());

                    var sectionsRating = new List<int>(nbBusStops - 1);
                    for (int j = 0; j < nbBusStops - 1; ++j)
                    {
                        sectionsRating.Add(int.Parse(file.ReadLine()));
                    }

                    routesDescription.Add(new RouteDescription(sectionsRating));
                }
            }

            var cyclingItineraries = new CyclingSegmentService().GetCyclingSegments(routesDescription);

            for (int i = 0; i < cyclingItineraries.Count; ++i)
            {
                Console.Write("route {0}: ", i + 1);
                if (cyclingItineraries[i].IsCyclingPossible)
                {
                    Console.WriteLine("cycle between stops {0} and {1}", cyclingItineraries[i].StartingBusStop, 
                                                                         cyclingItineraries[i].EndingBusStop);
                }
                else
                {
                    Console.WriteLine("no cycling");
                }
            }
        }
    }
}

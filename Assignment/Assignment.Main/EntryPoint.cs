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
    class EntryPoint
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length != 1)
            {
                Console.Error.WriteLine("Bad parameter. Usage: Assignment.Main.exe [FILE]");
                return;
            }

            ProcessFile(args[0]);
        }

        private static void ProcessFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.Error.WriteLine("File not found: " + filePath);
            }

            var file              = new StreamReader(filePath);
            var nbRoutes          = int.Parse(file.ReadLine());
            var routesDescription = new List<RouteDescription>(nbRoutes);

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

            var cyclingItineraries = new CyclingSegmentService().GetCyclingSegments(routesDescription);

            for (int i = 0; i < cyclingItineraries.Count; ++i)
            {
                Console.Write("route {0}: ", i + 1);
                if (cyclingItineraries[i].IsCyclingPossible)
                {
                    Console.WriteLine("cycle between stops {0} and {1}", cyclingItineraries[i].BusStopBegin, 
                                                                         cyclingItineraries[i].BusStopEnd);
                }
                else
                {
                    Console.WriteLine("no cycling");
                }
            }
        }
    }
}

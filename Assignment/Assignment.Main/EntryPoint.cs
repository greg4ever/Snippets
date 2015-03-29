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
                Console.Error.WriteLine("File not found: ({0})", filePath);
                return;
            }

            var routeService = new RouteService();

            using (var file = new StreamReader(filePath))
            {
                var nbRoutes = int.Parse(file.ReadLine());

                foreach (var i in Enumerable.Range(1, nbRoutes))
                {
                    var nbBusStops     = int.Parse(file.ReadLine()) - 1;
                    var sectionsRating = new List<int>(nbBusStops);

                    sectionsRating.AddRange(
                        Enumerable.Range(1, nbBusStops).
                        Select(_ => int.Parse(file.ReadLine())));

                    PrintCyclingSegment(
                        routeService.GetCyclingSegment(
                            new RouteDescription(sectionsRating)), 
                            i);
                }
            }
        }

        /// <summary>
        /// Write on the standard output the given cycling segment and route number
        /// </summary>
        /// <param name="cyclingSegment">the cycling segment</param>
        /// <param name="numRoute">the route number</param>
        private static void PrintCyclingSegment(CyclingSegment cyclingSegment, int numRoute)
        {
            Console.Write("route {0}: ", numRoute);
            if (cyclingSegment.IsCyclingPossible)
            {
                Console.WriteLine("cycle between stops {0} and {1}", cyclingSegment.StartingBusStop,
                                                                     cyclingSegment.EndingBusStop);
            }
            else
            {
                Console.WriteLine("no cycling");
            }
        }
    }
}

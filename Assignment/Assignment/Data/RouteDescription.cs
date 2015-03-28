using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment.Data
{
    /// <summary>
    /// This class represents a route description
    /// </summary>
    public class RouteDescription
    {
        /// <summary>
        /// Gets the segment ratings for the route
        /// </summary>
        public List<int> SegmentRatings { get; private set; }

        /// <summary>
        /// The class constructor
        /// </summary>
        /// <param name="segmentRatings">the segment ratings</param>
        public RouteDescription(List<int> segmentRatings)
        {
            SegmentRatings = segmentRatings;
        }
    }
}

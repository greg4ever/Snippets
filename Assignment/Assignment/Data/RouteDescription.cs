using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment.Data
{
    public sealed class RouteDescription
    {
        /// <summary>
        /// 
        /// </summary>
        public List<int> SegmentRatings { get; private set; }

        public RouteDescription(List<int> segmentRatings)
        {
            SegmentRatings = segmentRatings;
        }
    }
}

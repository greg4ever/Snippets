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
        public List<int> SectionRatings { get; private set; }

        public RouteDescription(List<int> sectionRatings)
        {
            SectionRatings = sectionRatings;
        }
    }
}

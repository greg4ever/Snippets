using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment.Data
{
    public sealed class CyclingItinerary
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsCyclable
        {
            get { return BusStopBegin != BusStopEnd; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int BusStopBegin { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int BusStopEnd { get; private set; }

        public CyclingItinerary(int busStopBegin, int busStopEnd)
        {
            BusStopBegin = busStopBegin;
            BusStopEnd   = busStopEnd;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment.Data
{
    public sealed class CyclingSegment
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsCyclingPossible
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

        public CyclingSegment(int busStopBegin, int busStopEnd)
        {
            BusStopBegin = busStopBegin;
            BusStopEnd   = busStopEnd;
        }
    }
}

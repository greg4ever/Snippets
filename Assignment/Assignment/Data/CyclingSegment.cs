using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment.Data
{
    /// <summary>
    /// This class represents a cycling segment
    /// </summary>
    public class CyclingSegment
    {
        /// <summary>
        /// Gets if any cycling is possible
        /// </summary>
        public bool IsCyclingPossible
        {
            get { return StartingBusStop != EndingBusStop; }
        }

        /// <summary>
        /// Gets the starting bust stop number
        /// Invalid state if <see cref="IsCyclingPossible"/> is false
        /// </summary>
        public int StartingBusStop { get; private set; }

        /// <summary>
        /// Gets the ending bus stop number
        /// Invalid state if <see cref="IsCyclingPossible"/> is false
        /// </summary>
        public int EndingBusStop { get; private set; }

        /// <summary>
        /// The class constructor
        /// </summary>
        /// <param name="startingBusStop">the starting bus stop number</param>
        /// <param name="endingBusStop">the ending bus stop number</param>
        public CyclingSegment(int startingBusStop, int endingBusStop)
        {
            StartingBusStop = startingBusStop;
            EndingBusStop   = endingBusStop;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entity
{
    public class Rover
    {
        /// <summary>
        /// X coordinate information
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Y coordinate information
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Rover direction information
        /// </summary>
        public string Direction { get; set; }

        public List<string> MoveInformationList { get; set; }
    }
}

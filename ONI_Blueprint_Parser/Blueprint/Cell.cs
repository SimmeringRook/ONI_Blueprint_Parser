using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONI_Blueprint_Parser.Blueprint
{
    internal class Cell
    {
        /// <summary>
        /// X coordinate of the Cell in the Blueprint
        /// </summary>
        internal int Location_X;

        /// <summary>
        /// Y coordinate of the Cell in the Blueprint
        /// </summary>
        internal int Location_Y;

        /// <summary>
        /// The element
        /// </summary>
        internal Elements Element;

        /// <summary>
        /// Mass of Element in kg(?)
        /// </summary>
        internal int Mass;

        /// <summary>
        /// Temperature of Element in Kelvin
        /// </summary>
        internal int Temperature;

        internal Cell(int x, int y, Elements element, int mass = 0, int temperature = 295)
        {
            Location_X = x;
            Location_Y = y;
            Element = element;
            Mass = mass;
            Temperature = temperature;
        }
    }
}

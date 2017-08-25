using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONI_Blueprint_Parser.Blueprint.Buildings
{
    internal class Building : Cell
    {
        /// <summary>
        /// id property in .yaml
        /// </summary>
        internal BuildingName ID;


        internal Building(BuildingName id, int x, int y, Elements element, int mass = 0, int temperature = 295) : base(x, y, element, mass, temperature)
        {
            ID = id;
        }

        internal Building(BuildingName id, Cell cell) : base(cell.Location_X, cell.Location_Y, cell.Element, cell.Mass, cell.Temperature)
        {
            ID = id;
        }
    }
}

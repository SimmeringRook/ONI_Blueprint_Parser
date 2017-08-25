using ONI_Blueprint_Parser.Blueprint.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONI_Blueprint_Parser.Blueprint
{
    internal class Blueprint
    {
        public string Name;

        public int Size_X;
        public int Size_Y;

        public List<Cell> Cells;

        public List<Building> Buildings;

        internal Blueprint(string name, int x, int y)
        {
            Name = name;
            Size_X = x;
            Size_Y = y;
            Cells = new List<Cell>();
            Buildings = new List<Building>();
        }
    }
}

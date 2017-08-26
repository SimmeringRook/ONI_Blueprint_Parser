﻿using BlueprintResources.Buildings;
using System.Collections.Generic;

namespace BlueprintResources
{
    public class Blueprint
    {
        public string Name;

        public int Size_X;
        public int Size_Y;

        public int X_NormalizeFactor;
        public int Y_NormalizeFactor;


        public List<Cell> Cells;

        public List<Building> Buildings;

        public string FileLocation;

        public Blueprint(string name, int x, int y, string fileLocation)
        {
            Name = name;
            Size_X = x;
            Size_Y = y;
            Cells = new List<Cell>();
            Buildings = new List<Building>();

            FileLocation = fileLocation;
        }
    }
}

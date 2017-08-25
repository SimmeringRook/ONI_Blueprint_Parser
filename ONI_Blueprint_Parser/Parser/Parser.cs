using ONI_Blueprint_Parser.Blueprint;
using ONI_Blueprint_Parser.Blueprint.Buildings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ONI_Blueprint_Parser.Parser
{
    class Parser
    {
        public string BlueprintPath;

        public Parser()
        {

        }

        /// <summary>
        /// Attempts to return a parsed Blueprint
        /// </summary>
        /// <param name="blueprint"></param>
        /// <returns></returns>
        public bool GetBlueprint(out Blueprint.Blueprint blueprint)
        {
            //Check the path
            if (BlueprintPath.Equals(string.Empty))
            {
                throw new Exception("The path to the blueprint file was empty.");
            }

            //Verify the system can see the file
            if (File.Exists(BlueprintPath) == false)
            {
                throw new Exception("The file, \"{0}\", could not be found.");
            }

            //Begin Parse attempt
            Blueprint.Blueprint blueprintAttempt;
            if (TryReadBlueprint(out blueprintAttempt))
            {
                blueprint = blueprintAttempt;
                return true;
            }
            else
            {
                blueprint = null;
                return false;
            }
        }


        /// <summary>
        /// Attempt to read in the raw data from the .yaml file, and convert into a blueprint
        /// </summary>
        /// <param name="bluePrint"></param>
        /// <returns></returns>
        private bool TryReadBlueprint(out Blueprint.Blueprint bluePrint)
        {
            //Read in raw data
            List<string> unparsedBlueprintHeader = new List<string>();
            List<string> unparsedCellData = new List<string>();
            List<string> unparsedBuildingData = new List<string>();

            using (StreamReader reader = new StreamReader(BlueprintPath))
            {
                bool headerDataComplete = false;
                bool cellDataComplete = false;
                //TODO:: read in creatures
                bool buildingDataComplete = false;

                string lineOfData = "";

                while (!reader.EndOfStream)
                {
                    lineOfData = reader.ReadLine();

                    if (!headerDataComplete && lineOfData.Split(':')[0].Equals("cells"))
                        headerDataComplete = true;

                    if (!cellDataComplete && lineOfData.Split(':')[0].Equals("buildings"))
                        cellDataComplete = true;

                    if (!buildingDataComplete && lineOfData.Split(':')[0].Equals("pickupables"))
                        buildingDataComplete = true;

                    if (!headerDataComplete)
                    {
                        unparsedBlueprintHeader.Add(lineOfData);
                    }
                    else if (!cellDataComplete)
                    {
                        unparsedCellData.Add(lineOfData);
                    }
                    else if (!buildingDataComplete)
                    {
                        unparsedBuildingData.Add(lineOfData);
                    }
                }
            }

            if (unparsedBlueprintHeader.Count > 0 && unparsedCellData.Count > 0)
            {
                bluePrint = ParseBlueprintHeader(unparsedBlueprintHeader);
                bluePrint.Cells = ParseCellData(unparsedCellData);
                bluePrint.Buildings = ParseBuildingData(unparsedBuildingData, bluePrint.Cells);

                int minimumX = 0;
                int minimumY = 0;

                foreach (Cell cell in bluePrint.Cells)
                {
                    if (cell.Location_X < minimumX)
                        minimumX = cell.Location_X;
                    if (cell.Location_Y < minimumY)
                        minimumY = cell.Location_Y;
                }

                bluePrint.X_NormalizeFactor = Math.Abs(minimumX);
                bluePrint.Y_NormalizeFactor = Math.Abs(minimumY);

                return true;
            }
            else
            {
                bluePrint = null;

                return false;
            }
        }

        /// <summary>
        /// Parse raw string data into descriptive information about the BluePrint
        /// </summary>
        /// <param name="unparsedBlueprintHeader"></param>
        /// <returns></returns>
        private Blueprint.Blueprint ParseBlueprintHeader(List<string> unparsedBlueprintHeader)
        {
            int index = 0;
            string name = RemoveExcess(unparsedBlueprintHeader[index]);
            index++;

            /* Unused */
            string info = RemoveExcess(unparsedBlueprintHeader[index]);
            index++;
            /* Unused */
            string size = RemoveExcess(unparsedBlueprintHeader[index]);
            index++;

            int size_X = int.Parse(RemoveExcess(unparsedBlueprintHeader[index]));
            index++;

            int size_Y = int.Parse(RemoveExcess(unparsedBlueprintHeader[index]));
            index++;

            /* Unused */
            int area = int.Parse(RemoveExcess(unparsedBlueprintHeader[index]));

            return new Blueprint.Blueprint(name, size_X, size_Y, BlueprintPath);
        }

        /// <summary>
        /// Parse raw string data from the .yaml into a collection of Cell objects
        /// </summary>
        /// <param name="unparsedCellData"></param>
        /// <returns></returns>
        private List<Cell> ParseCellData(List<string> unparsedCellData)
        {
            List<Cell> parsedCells = new List<Cell>();

            Cell tempCell = new Cell();

            foreach (string cellData in unparsedCellData)
            {
                string[] data = cellData.Split(':');

                switch (data[0].TrimStart(new char[]{' ', '-'}))
                {
                    case "element":
                        if (tempCell.Element.HasValue)
                        {
                            parsedCells.Add(tempCell); //assume complete object, add and create new holder
                            tempCell = new Cell();
                        }

                        tempCell.Element = (Element)Enum.Parse(typeof(Element), data[1]);
                        break;
                    case "mass":
                        tempCell.Mass = double.Parse(data[1]);
                        break;
                    case "temperature":
                        tempCell.Temperature = double.Parse(data[1]);
                        break;
                    case "location_x":
                        tempCell.Location_X = int.Parse(data[1]);
                        break;
                    case "location_y":
                        tempCell.Location_Y = int.Parse(data[1]);
                        break;
                    default:
                        break;
                }
            }

            return parsedCells;
        }

        /// <summary>
        /// Parse raw string data from the .yaml into a collection of Buildings
        /// </summary>
        /// <param name="unparsedBuildingData"></param>
        /// <param name="Cells"></param>
        /// <returns></returns>
        private List<Building> ParseBuildingData(List<string> unparsedBuildingData, List<Cell> Cells)
        {
            List<Building> parsedBuildings = new List<Building>();

            Building tempBuilding = new Building();

            foreach (string cellData in unparsedBuildingData)
            {
                string[] data = cellData.Split(':');

                switch (data[0].TrimStart(new char[] { ' ', '-' }))
                {
                    case "id":
                        EntityID id = (EntityID)Enum.Parse(typeof(EntityID), data[1]);
                        if (id != EntityID.FieldRation)
                            tempBuilding.ID = (EntityID)Enum.Parse(typeof(EntityID), data[1]);
                        break;
                    case "temperature":
                        tempBuilding.Temperature = double.Parse(data[1]);
                        break;
                    case "location_x":
                        tempBuilding.Location_X = int.Parse(data[1]);
                        break;
                    case "location_y":
                        tempBuilding.Location_Y = int.Parse(data[1]);
                        break;

                    case "storage":
                        if (tempBuilding.ID.HasValue)
                        {

                            Cell associatedCell = Cells.Where(c =>
                            c.Location_X == tempBuilding.Location_X &&
                            c.Location_Y == tempBuilding.Location_Y).FirstOrDefault();
                            if (associatedCell != null)
                            {
                                tempBuilding = new Building(tempBuilding.ID.Value, associatedCell);
                            }

                            parsedBuildings.Add(tempBuilding); //assume complete object, add and create new holder
                            tempBuilding = new Building();
                        }
                        break;
                    default:
                        break;
                }
            }

            return parsedBuildings;
        }

        private string RemoveExcess(string dataLine)
        {//TODO:: Refactor or Remove
            return dataLine.Split(':')[1];
        }
    }
}

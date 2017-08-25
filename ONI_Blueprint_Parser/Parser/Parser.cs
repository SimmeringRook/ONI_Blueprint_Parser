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
        string blueprintPath;
        public Parser (string pathOfBlueprint)
        {
            blueprintPath = pathOfBlueprint;
        }

        public bool GetBlueprint(out Blueprint.Blueprint blueprint)
        {
            //Check the path
            if (blueprintPath.Equals(string.Empty))
            {
                throw new Exception("The path to the blueprint file was empty.");
            }

            //Verify the system can see the file
            if (File.Exists(blueprintPath) == false)
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

        private bool TryReadBlueprint(out Blueprint.Blueprint bluePrint)
        {
            //Read in raw data
            List<string> unparsedBlueprintHeader = new List<string>();
            List<string> unparsedCellData = new List<string>();
            List<string> unparsedBuildingData = new List<string>();

            using (StreamReader reader = new StreamReader(blueprintPath))
            {
                bool headerDataComplete = false;
                bool cellDataComplete = false;
                //TODO:: read in creatures
                bool buildingDataComplete = false;

                string lineOfData = "";

                while (!reader.EndOfStream)
                {
                    lineOfData = reader.ReadLine();

                    if (!headerDataComplete && lineOfData.Split(':')[0].Equals("cells:"))
                        headerDataComplete = true;

                    if (!cellDataComplete && lineOfData.Split(':')[0].Equals("buildings:"))
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

            return new Blueprint.Blueprint(name, size_X, size_Y);
        }

        /// <summary>
        /// Parse raw string data from the .yaml into a collection of Cell objects
        /// </summary>
        /// <param name="unparsedCellData"></param>
        /// <returns></returns>
        private List<Cell> ParseCellData(List<string> unparsedCellData)
        {
            List<Cell> parsedCells = new List<Cell>();

            //Need to start at index of 1
            //Index of 0 is "cells:"
            for (int cellIndex = 1; cellIndex < unparsedCellData.Count; cellIndex++)
            {
                Elements element = (Elements)Enum.Parse(typeof(Elements), RemoveExcess(unparsedCellData[cellIndex]));
                cellIndex++;
                int mass = int.Parse(RemoveExcess(unparsedCellData[cellIndex]));
                cellIndex++;
                int temperature = int.Parse(RemoveExcess(unparsedCellData[cellIndex]));
                cellIndex++;
                int location_x = int.Parse(RemoveExcess(unparsedCellData[cellIndex]));
                cellIndex++;
                int location_y = int.Parse(RemoveExcess(unparsedCellData[cellIndex]));

                parsedCells.Add(new Cell(location_x, location_y, element, mass, temperature));
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
            List<Building> parsedCells = new List<Building>();

            //Need to start at index of 1
            //Index of 0 is "cells:"
            for (int index = 1; index < unparsedBuildingData.Count; index++)
            {
                BuildingName id = (BuildingName)Enum.Parse(typeof(BuildingName), RemoveExcess(unparsedBuildingData[index]));
                index++;

                int location_x = int.Parse(RemoveExcess(unparsedBuildingData[index]));
                index++;
                int location_y = int.Parse(RemoveExcess(unparsedBuildingData[index]));
                index++;

                Cell cell = Cells.Where(c => c.Location_X == location_x && c.Location_Y == location_y).FirstOrDefault();
                if (cell != null)
                {
                    parsedCells.Add(new Building(id, cell));
                    index += 5;
                }
                else
                {
                    Elements element = (Elements)Enum.Parse(typeof(Elements), RemoveExcess(unparsedBuildingData[index]));
                    index++;

                    int temperature = int.Parse(RemoveExcess(unparsedBuildingData[index]));
                    index++;

                    /* Unused */
                    string storage = RemoveExcess(unparsedBuildingData[index]);
                    index++;
                    string rottable = RemoveExcess(unparsedBuildingData[index]);
                    index++;
                    string amounts = RemoveExcess(unparsedBuildingData[index]);
                    index++;
                    string other_values = RemoveExcess(unparsedBuildingData[index]);

                    parsedCells.Add(new Building(id, location_x, location_y, element));
                }
            }

            return parsedCells;
        }

        private string RemoveExcess(string dataLine)
        {
            return dataLine.Split(':')[1];
        }
    }
}

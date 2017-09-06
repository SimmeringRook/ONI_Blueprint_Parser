using System.Drawing;

namespace BlueprintResources.Buildings
{
    public static class BuildingFactory
    {
        public static Building CreateNew(BuildingParameters parsedBuildingInfo)
        {
            Building buildingToCreate = new Building();

            buildingToCreate.ID = parsedBuildingInfo.ID;

            buildingToCreate.Connection = parsedBuildingInfo.Connection;
            buildingToCreate.Rotation = parsedBuildingInfo.Rotation;

            buildingToCreate.Size = GetBuildingSize(parsedBuildingInfo.ID, parsedBuildingInfo.Rotation);
            buildingToCreate.Offset = GetBuildingOffset(buildingToCreate.Size);

            buildingToCreate.Location = parsedBuildingInfo.Location;

            try
            {
                buildingToCreate.Sprite = BuildingAssetManager.GetImage(buildingToCreate);
                buildingToCreate.Sprite_Outline = BuildingAssetManager.GetImage(buildingToCreate, true);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Exception Thrown with: " + parsedBuildingInfo.ID.ToString() + "\n" + e.Message);
                buildingToCreate.Sprite = new Bitmap(50, 50);
                buildingToCreate.Sprite_Outline = new Bitmap(50, 50);
            }

            return buildingToCreate;
        }

        private static Size GetBuildingSize(EntityID id, int rotation)
        {
            switch (id)
            {
                case EntityID.Headquarters:
                    return new Size(4, 4);
                case EntityID.WaterPurifier:
                case EntityID.FertilizerMaker:
                case EntityID.ClothingFabricator:
                case EntityID.MethaneGenerator:
                    return new Size(4, 3);           
                case EntityID.HydrogenGenerator:
                    return new Size(4, 2);
                case EntityID.LiquidHeater:
                    return new Size(4, 1);
                case EntityID.AlgaeDistillery:
                    return new Size(3, 4);
                case EntityID.Shower:
                case EntityID.LiquidPumpingStation:
                    return new Size(2, 4);
                case EntityID.AdvancedResearchCenter:
                case EntityID.Generator:
                    return new Size(3, 3);
                case EntityID.PowerTransformer:
                case EntityID.MedicalCot:
                case EntityID.CookingStation:
                case EntityID.OreScrubber:
                    return new Size(3, 2);
                case EntityID.Outhouse:
                case EntityID.FlushToilet:
                case EntityID.WashBasin:
                case EntityID.HandSanitizer:
                case EntityID.MedicalBed:
                case EntityID.MicrobeMusher:    
                    return new Size(2, 3);
                case EntityID.GasFilter:
                case EntityID.LiquidFilter:
                    if (rotation == 90 || rotation == 270)
                        return new Size(1, 3);
                    return new Size(3, 1);
                case EntityID.ResearchCenter:
                case EntityID.Electrolyzer:
                case EntityID.CO2Scrubber:
                case EntityID.ManualGenerator:
                case EntityID.BatteryMedium:
                case EntityID.LiquidCooledFan:
                case EntityID.AirConditioner:
                case EntityID.LiquidConditioner:
                case EntityID.LiquidPump:
                case EntityID.GasPump:
                case EntityID.SpaceHeater:
                case EntityID.Canvas:
                case EntityID.Bed:
                case EntityID.MassageTable:
                case EntityID.Compost:
                    return new Size(2, 2);
                case EntityID.RationBox:
                    return new Size(2, 1);
                case EntityID.StorageLocker:
                case EntityID.Door:
                case EntityID.ManualPressureDoor:
                case EntityID.PressureDoor:
                case EntityID.MineralDeoxidizer:
                case EntityID.AlgaeHabitat:
                case EntityID.Refrigerator:
                case EntityID.FloorLamp:
                case EntityID.Grave:
                case EntityID.Battery:
                    return new Size(1, 2);
                case EntityID.LiquidValve:
                case EntityID.GasValve: //TODO:: Gas Valve is wrong
                    if (rotation == 90 || rotation == 270)
                        return new Size(2, 1);
                    return new Size(1, 2);
                case EntityID.GasConduitBridge:
                case EntityID.LiquidConduitBridge:
                case EntityID.WireBridge:
                    if (rotation == 90 || rotation == 270)
                        return new Size(1, 3);
                    return new Size(3, 1);
                case EntityID.Sculpture:
                case EntityID.BottleEmptier:
                    return new Size(1, 3);
                default:
                    return new Size(1, 1);
            }
        }

        private static Point GetBuildingOffset(Size buildingSize)
        {
            Point offset = new Point();

            offset.X = (int) System.Math.Ceiling(buildingSize.Width / 2.0) - 1;
            offset.Y = buildingSize.Height - 1;

            return offset;
        }
    }
}

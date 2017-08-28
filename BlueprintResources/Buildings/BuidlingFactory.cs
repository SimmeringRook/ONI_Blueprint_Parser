using System.Drawing;

namespace BlueprintResources.Buildings
{
    public static class BuildingFactory
    {
        public static Building CreateNew(BuildingParameters parsedBuildingInfo)
        {
            Building buildingToCreate = new Building();

            buildingToCreate.ID = parsedBuildingInfo.ID;
            buildingToCreate.Size = GetBuildingSize(parsedBuildingInfo.ID);
            buildingToCreate.Offset = GetBuildingOffset(buildingToCreate.Size);

            buildingToCreate.Connection = parsedBuildingInfo.Connection;
            buildingToCreate.Rotation = parsedBuildingInfo.Rotation;

            buildingToCreate.Location = parsedBuildingInfo.Location;

            try
            {
                buildingToCreate.Sprite = BuildingAssetManager.GetImage(buildingToCreate);
            }
            catch (System.Exception e)
            {
                //System.Windows.Forms.MessageBox.Show(e.Message);
                buildingToCreate.Sprite = new Bitmap(50, 50);
            }

            return buildingToCreate;
        }

        private static Size GetBuildingSize(EntityID id)
        {
            switch (id)
            {
                case EntityID.Headquarters:
                    return new Size(4, 4);
                case EntityID.RationBox:
                    return new Size(2, 2);
                case EntityID.GasConduitBridge:
                case EntityID.LiquidConduitBridge:
                case EntityID.WireBridge:
                    return new Size(3, 1);
                default:
                    return new Size(1, 1);
            }
        }

        private static Point GetBuildingOffset(Size buildingSize)
        {
            Point offset = new Point();

            offset.X = (int) System.Math.Ceiling(buildingSize.Width / 2.0) - 1;
            offset.Y = (int) System.Math.Ceiling(buildingSize.Height / 1.0) - 1;

            return offset;
        }
    }
}

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
                buildingToCreate.Sprite_Outline = BuildingAssetManager.GetOutline(buildingToCreate);
            }
            catch (System.Exception e)
            {
                //System.Windows.Forms.MessageBox.Show(e.Message);
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
                case EntityID.RationBox:
                    return new Size(2, 1);
                case EntityID.GasConduitBridge:
                case EntityID.LiquidConduitBridge:
                case EntityID.WireBridge:
                    if (rotation == 90 || rotation == 270)
                        return new Size(1, 3);
                    return new Size(3, 1);
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

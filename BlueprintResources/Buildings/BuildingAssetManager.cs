using System.Collections.Generic;
using System.Drawing;

namespace BlueprintResources.Buildings
{
    /// <summary>
    /// Searches by Oxygen Not Included <seealso cref="EntityID"/> to return the .png of the requested building.
    /// Use <see cref="GetImage(EntityID)"/> for a <see cref="Image"/>
    /// </summary>
    public static class BuildingAssetManager
    {
        /// <summary>
        /// Returns the corresponding .png for the building as an <see cref="Image"/>
        /// </summary>
        /// <param name="buildingName"></param>
        /// <returns></returns>
        public static Image GetImage(Building building)
        {
            switch (building.ID)
            {
                case EntityID.Tile:
                    return Properties.Resources.Tile_Outline;
                case EntityID.RationBox:
                    return Properties.Resources.rationBox;
                case EntityID.Headquarters:
                    return Properties.Resources.Headquarters_Outline;
                case EntityID.Wire:
                case EntityID.HighWattageWire:
                    return GetWire(building);
                case EntityID.BatteryMedium:
                    return Properties.Resources.BatteryMedium;
                case EntityID.WireBridge:
                    return Properties.Resources.wire_Bridge;
                default:
                    throw new System.Exception("Could not find the image for: " + building.ID.ToString());
            }
        }

        private static Image GetWire(Building wire)
        {
            Image rotatedImage;
            switch (wire.Connection)
            {
                case Connection.W:
                    return Properties.Resources.wire_MaleEnding;
                case Connection.E:
                    rotatedImage = Properties.Resources.wire_MaleEnding;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    return rotatedImage;
                case Connection.EW:
                    return Properties.Resources.wire_Cable;
                case Connection.N:
                    rotatedImage = Properties.Resources.wire_MaleEnding;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    return rotatedImage;
                case Connection.NW:
                    rotatedImage = Properties.Resources.wire_LJunction;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate180FlipX);
                    return rotatedImage;
                case Connection.NE:
                    rotatedImage = Properties.Resources.wire_LJunction;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    return rotatedImage;
                case Connection.NEW:
                    rotatedImage = Properties.Resources.wire_TJunction;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    return rotatedImage;
                case Connection.S:
                    rotatedImage = Properties.Resources.wire_MaleEnding;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate90FlipY);
                    return rotatedImage;
                case Connection.SW:
                    return Properties.Resources.wire_LJunction;
                case Connection.ES:
                    rotatedImage = Properties.Resources.wire_LJunction;
                    rotatedImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    return rotatedImage;
                case Connection.ESW:
                    return Properties.Resources.wire_TJunction;
                case Connection.NS:
                    rotatedImage = Properties.Resources.wire_Cable;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    return rotatedImage;
                case Connection.NSW:
                    rotatedImage = Properties.Resources.wire_TJunction;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    return rotatedImage;
                case Connection.NSE:
                    rotatedImage = Properties.Resources.wire_TJunction;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate90FlipX);
                    return rotatedImage;
                case Connection.NESW:
                    return Properties.Resources.wire_XJunction;
                case Connection.None:
                default:
                    return Properties.Resources.wire_NoConnections;
            }
        }

        public static Image GetOutline(Building building)
        {
            switch (building.ID)
            {
                case EntityID.Tile:
                    return Properties.Resources.Tile_Outline;
                case EntityID.RationBox:
                    return Properties.Resources.rationBox_Outline;
                case EntityID.Headquarters:
                    return Properties.Resources.Headquarters_Outline;
                case EntityID.Wire:
                case EntityID.HighWattageWire:
                    return GetWireOutline(building);
                case EntityID.BatteryMedium:
                    return Properties.Resources.BatteryMedium;
                case EntityID.WireBridge:
                    return Properties.Resources.wire_Bridge_Outline;
                default:
                    throw new System.Exception("Could not find the image for: " + building.ID.ToString());
            }
        }

        private static Image GetWireOutline(Building wire)
        {
            Image rotatedImage;
            switch (wire.Connection)
            {
                case Connection.W:
                    return Properties.Resources.wire_MaleEnding_Outline;
                case Connection.E:
                    rotatedImage = Properties.Resources.wire_MaleEnding_Outline;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    return rotatedImage;
                case Connection.EW:
                    return Properties.Resources.wire_Cable_Outline;
                case Connection.N:
                    rotatedImage = Properties.Resources.wire_MaleEnding_Outline;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    return rotatedImage;
                case Connection.NW:
                    rotatedImage = Properties.Resources.wire_LJunction_Outline;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate180FlipX);
                    return rotatedImage;
                case Connection.NE:
                    rotatedImage = Properties.Resources.wire_LJunction_Outline;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    return rotatedImage;
                case Connection.NEW:
                    rotatedImage = Properties.Resources.wire_TJunction_Outline;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    return rotatedImage;
                case Connection.S:
                    rotatedImage = Properties.Resources.wire_MaleEnding_Outline;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate90FlipY);
                    return rotatedImage;
                case Connection.SW:
                    return Properties.Resources.wire_LJunction_Outline;
                case Connection.ES:
                    rotatedImage = Properties.Resources.wire_LJunction_Outline;
                    rotatedImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    return rotatedImage;
                case Connection.ESW:
                    return Properties.Resources.wire_TJunction_Outline;
                case Connection.NS:
                    rotatedImage = Properties.Resources.wire_Cable_Outline;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    return rotatedImage;
                case Connection.NSW:
                    rotatedImage = Properties.Resources.wire_TJunction_Outline;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    return rotatedImage;
                case Connection.NSE:
                    rotatedImage = Properties.Resources.wire_TJunction_Outline;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate90FlipX);
                    return rotatedImage;
                case Connection.NESW:
                    return Properties.Resources.wire_XJunction_Outline;
                case Connection.None:
                default:
                    return Properties.Resources.wire_NoConnections_Outline;
            }
        }
    }
}

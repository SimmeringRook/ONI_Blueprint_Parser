using System.Collections.Generic;
using System.Drawing;

namespace BlueprintResources.Buildings
{
    /// <summary>
    /// Searches by Oxygen Not Included <seealso cref="EntityID"/> to return the .png of the requested building.
    /// Use <see cref="GetImage(EntityID)"/> for a <see cref="Image"/>
    /// </summary>
    internal static class BuildingAssetManager
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
                    return Properties.Resources.rationBox_206;
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
                    return Properties.Resources.maleending;
                case Connection.E:
                    rotatedImage = Properties.Resources.maleending;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    return rotatedImage;
                case Connection.EW:
                    return Properties.Resources.cable;
                case Connection.N:
                    rotatedImage = Properties.Resources.maleending;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    return rotatedImage;
                case Connection.NW:
                    rotatedImage = Properties.Resources.ljunction;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate180FlipX);
                    return rotatedImage;
                case Connection.NE:
                    rotatedImage = Properties.Resources.ljunction;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    return rotatedImage;
                case Connection.NEW:
                    rotatedImage = Properties.Resources.tjunction;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    return rotatedImage;
                case Connection.S:
                    rotatedImage = Properties.Resources.maleending;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate90FlipY);
                    return rotatedImage;
                case Connection.SW:
                    return Properties.Resources.ljunction;
                case Connection.ES:
                    rotatedImage = Properties.Resources.ljunction;
                    rotatedImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    return rotatedImage;
                case Connection.ESW:
                    return Properties.Resources.tjunction;
                case Connection.NS:
                    rotatedImage = Properties.Resources.cable;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    return rotatedImage;
                case Connection.NSW:
                    rotatedImage = Properties.Resources.tjunction;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    return rotatedImage;
                case Connection.NSE:
                    rotatedImage = Properties.Resources.tjunction;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate90FlipX);
                    return rotatedImage;
                case Connection.NESW:
                    return Properties.Resources.xjunction;
                case Connection.None:
                default:
                    return Properties.Resources.noconnections;
            }
        }
    }
}

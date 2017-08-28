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
            switch (building.ID.Value)
            {
                case EntityID.Tile:
                    return Properties.Resources.Tile_Outline;
                case EntityID.RationBox:
                    return Properties.Resources.RationBox_Outline;
                case EntityID.Headquarters:
                    return Properties.Resources.Headquarters_Outline;
                case EntityID.Wire:
                case EntityID.HighWattageWire:
                    return GetWire(building);
                default:
                    throw new System.Exception("Could not find the image for: " + building.ID.Value.ToString());
            }
        }

        private static Image GetWire(Building wire)
        {
            Image rotatedImage;
            switch (wire.Connection)
            {
                case Connection.W:
                    return Properties.Resources.electric_Single;
                case Connection.E:
                    rotatedImage = Properties.Resources.electric_Single;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    return rotatedImage;
                case Connection.EW:
                    return Properties.Resources.electric_Line;
                case Connection.N:
                    rotatedImage = Properties.Resources.electric_Single;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    return rotatedImage;
                case Connection.NW:
                    rotatedImage = Properties.Resources.electric_corner;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate180FlipX);
                    return rotatedImage;
                case Connection.NE:
                    rotatedImage = Properties.Resources.electric_corner;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    return rotatedImage;
                case Connection.NEW:
                    rotatedImage = Properties.Resources.electric_T;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    return rotatedImage;
                case Connection.S:
                    rotatedImage = Properties.Resources.electric_Single;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate90FlipY);
                    return rotatedImage;
                case Connection.SW:
                    return Properties.Resources.electric_corner;
                case Connection.ES:
                    rotatedImage = Properties.Resources.electric_corner;
                    rotatedImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    return rotatedImage;
                case Connection.ESW:
                    return Properties.Resources.electric_T;
                case Connection.NS:
                    rotatedImage = Properties.Resources.electric_Line;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    return rotatedImage;
                case Connection.NSW:
                    rotatedImage = Properties.Resources.electric_T;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    return rotatedImage;
                case Connection.NSE:
                    rotatedImage = Properties.Resources.electric_T;
                    rotatedImage.RotateFlip(RotateFlipType.Rotate90FlipX);
                    return rotatedImage;
                case Connection.NESW:
                    return Properties.Resources.electric_All;
                case Connection.None:
                default:
                    return Properties.Resources.electric_0;
            }
        }
    }
}

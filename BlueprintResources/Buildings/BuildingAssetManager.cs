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
        public static Image GetImage(Building building, bool outline = false)
        {
            string imageName = building.ID.ToString() + GetConnectionSuffix(building.Connection);
            if (outline)
                imageName += "_Outline";

            RotateFlipType rotation = GetRotation(building.Connection);
            Image importedSprite = Properties.Resources.ResourceManager.GetObject(imageName) as Image;
                
            importedSprite.RotateFlip(rotation);

            return importedSprite;
        }

        private static RotateFlipType GetRotation(Connection connection)
        {
            switch (connection)
            {
                case Connection.N:
                    return RotateFlipType.Rotate90FlipNone;
                case Connection.E:
                    return RotateFlipType.Rotate180FlipNone;
                case Connection.S:
                    return RotateFlipType.Rotate90FlipY;
                case Connection.NS:
                    return RotateFlipType.Rotate90FlipNone;
                case Connection.NW:
                    return RotateFlipType.Rotate180FlipX;
                case Connection.NE:
                    return RotateFlipType.Rotate180FlipNone;
                case Connection.ES:
                    return RotateFlipType.RotateNoneFlipX;
                case Connection.NEW:
                    return RotateFlipType.Rotate180FlipNone;
                case Connection.NSW:
                    return RotateFlipType.Rotate90FlipNone;
                case Connection.NSE:
                    return RotateFlipType.Rotate90FlipX;
                case Connection.W:
                case Connection.EW:
                case Connection.SW:
                case Connection.ESW:
                case Connection.NESW:
                case Connection.None:
                case Connection.Null:
                default:
                    return RotateFlipType.RotateNoneFlipNone;
            }
        }

        private static string GetConnectionSuffix(Connection connection)
        {
            switch (connection)
            {
                case Connection.N:
                case Connection.E:
                case Connection.S:
                case Connection.W:
                    return "_MaleEnding";
                case Connection.NS:
                case Connection.EW:
                    return "_TwoWay";
                case Connection.NW:
                case Connection.NE:
                case Connection.ES:
                case Connection.SW:
                    return "_LJunction";
                case Connection.NEW:
                case Connection.NSW:
                case Connection.NSE:
                case Connection.ESW:
                    return "_TJunction";
                case Connection.NESW:
                    return "_XJunction";
                case Connection.None:
                case Connection.Null:
                default:
                    return "";
            }
        }
    }
}

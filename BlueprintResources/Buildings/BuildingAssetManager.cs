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
        public static Image GetImage(EntityID buildingName)
        {
            switch (buildingName)
            {
                case EntityID.Tile:
                    return Properties.Resources.Tile_Outline;
                case EntityID.RationBox:
                    return Properties.Resources.RationBox_Outline;
                case EntityID.Headquarters:
                    return Properties.Resources.Headquarters_Outline;
                default:
                    throw new System.Exception("Could not find the image for: " + buildingName.ToString());
            }
        }
    }
}

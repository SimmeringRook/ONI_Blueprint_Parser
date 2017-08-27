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
                    return GetWire(building);
                default:
                    throw new System.Exception("Could not find the image for: " + building.ID.Value.ToString());
            }
        }

        private static Image GetWire(Building wire)
        {
            switch (wire.Connection)
            {
                case Connection.W:
                case Connection.E:
                case Connection.EW:
                case Connection.N:
                case Connection.NW:
                case Connection.NE:
                case Connection.NEW:
                case Connection.S:
                case Connection.SW:
                case Connection.ES:
                case Connection.ESW:
                case Connection.NS:
                case Connection.NSW:
                case Connection.NSE:
                case Connection.NESW:
                    
                case Connection.None:
                default:
                    return Properties.Resources.electric_0;
            }
        }
    }
}

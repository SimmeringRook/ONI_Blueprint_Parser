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

        //private static string executableLocation = (new System.Uri(System.Reflection.Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
        //private static string exeDir = System.IO.Path.GetDirectoryName(executableLocation);
        //private static string resourceDirectory = System.IO.Path.Combine(exeDir, "..\\..\\BlueprintResources\\Buildings\\Assets\\");

        //string file = string.Concat(Properties.Resources., buildingName, ".png");
        //return Image.FromFile(file);


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
                    return Properties.Resources.Tile;
                case EntityID.RationBox:
                    return Properties.Resources.RationBox;
                case EntityID.Headquarters:
                    return Properties.Resources.Headquarters;
                default:
                    throw new System.Exception("Could not find the image for: " + buildingName.ToString());
            }
        }
    }
}

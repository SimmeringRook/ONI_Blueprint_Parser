using System.Drawing;

namespace BlueprintResources.Buildings
{
    public class Building
    {
        /// <summary>
        /// id property in .yaml
        /// </summary>
        public EntityID ID;
        public Connection Connection = Connection.None;

        public Point Location;

        public Point Offset;

        public Size Size;
        public int Rotation;

        public Image Sprite;

        public Building()
        {
        }
    }
}

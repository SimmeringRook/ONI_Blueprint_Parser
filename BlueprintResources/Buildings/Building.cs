namespace BlueprintResources.Buildings
{
    public class Building : Cell
    {
        /// <summary>
        /// id property in .yaml
        /// </summary>
        public EntityID? ID;
        public Connection Connection = Connection.None;
        public int Rotation;

        public Building(EntityID id, Connection connection, Cell cell, int rotation = 0 ) : base(cell.Element.Value, cell.Location_X, cell.Location_Y, cell.Mass, cell.Temperature)
        {
            ID = id;
            Connection = connection;
            Rotation = rotation;
        }

        public Building()
        {
        }
    }
}

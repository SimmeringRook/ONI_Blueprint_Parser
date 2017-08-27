namespace BlueprintResources.Buildings
{
    public class Building : Cell
    {
        /// <summary>
        /// id property in .yaml
        /// </summary>
        public EntityID? ID;
        public Connection Connection = Connection.None;

        public Building(EntityID id, Connection connection, Cell cell) : base(cell.Element.Value, cell.Location_X, cell.Location_Y, cell.Mass, cell.Temperature)
        {
            ID = id;
            Connection = connection;
        }

        public Building()
        {
        }
    }
}

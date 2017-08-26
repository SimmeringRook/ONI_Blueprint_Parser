namespace BlueprintResources.Buildings
{
    public class Building : Cell
    {
        /// <summary>
        /// id property in .yaml
        /// </summary>
        public EntityID? ID;

        public Building(EntityID id, Cell cell) : base(cell.Element.Value, cell.Location_X, cell.Location_Y, cell.Mass, cell.Temperature)
        {
            ID = id;
        }

        public Building()
        {

        }
    }
}

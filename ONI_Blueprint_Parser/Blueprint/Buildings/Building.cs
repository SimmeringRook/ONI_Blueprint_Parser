namespace ONI_Blueprint_Parser.Blueprint.Buildings
{
    internal class Building : Cell
    {
        /// <summary>
        /// id property in .yaml
        /// </summary>
        internal EntityID? ID;

        internal Building(EntityID id, Cell cell) : base(cell.Element.Value, cell.Location_X, cell.Location_Y, cell.Mass, cell.Temperature)
        {
            ID = id;
        }

        public Building()
        {

        }
    }
}

namespace ONI_Blueprint_Parser.Blueprint
{
    internal class Cell
    {
        /// <summary>
        /// X coordinate of the Cell in the Blueprint
        /// </summary>
        internal int Location_X;

        /// <summary>
        /// Y coordinate of the Cell in the Blueprint
        /// </summary>
        internal int Location_Y;

        /// <summary>
        /// The element
        /// </summary>
        internal Element? Element;

        /// <summary>
        /// Mass of Element in kg(?)
        /// </summary>
        internal double Mass;

        /// <summary>
        /// Temperature of Element in Kelvin
        /// </summary>
        internal double Temperature;

        internal Cell(Element element, int x=0, int y=0, double mass = 0.0, double temperature = 295)
        {
            Location_X = x;
            Location_Y = y;
            Element = element;
            Mass = mass;
            Temperature = temperature;
        }

        public Cell()
        {

        }

    }
}

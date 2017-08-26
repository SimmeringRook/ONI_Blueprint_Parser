namespace BlueprintResources
{
    public class Cell
    {
        /// <summary>
        /// X coordinate of the Cell in the Blueprint
        /// </summary>
        public int Location_X;

        /// <summary>
        /// Y coordinate of the Cell in the Blueprint
        /// </summary>
        public int Location_Y;

        /// <summary>
        /// The element
        /// </summary>
        public Element? Element;

        /// <summary>
        /// Mass of Element in kg(?)
        /// </summary>
        public double Mass;

        /// <summary>
        /// Temperature of Element in Kelvin
        /// </summary>
        public double Temperature;

        public Cell(Element element, int x=0, int y=0, double mass = 0.0, double temperature = 295)
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

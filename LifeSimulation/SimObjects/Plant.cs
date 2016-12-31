namespace LifeSimulation.SimObjects
{
    public class Plant : SimObject
    {
        public int Energy { get; set; }
        public Plant(int energy, int xPos, int yPos, SimObjectColor color, SimulationContext context) : base(xPos, yPos, color, context)
        {

        }

        /// <summary>
        /// A plant can grow by an amount of energy
        /// </summary>
        /// <param name="energy">The amount of energy the plant will grow by</param>
        public void Grow(int energy)
        {

        }

        /// <summary>
        /// The plant will grow with 1 energy
        /// </summary>
        public void Grow()
        {

        }
    }
}

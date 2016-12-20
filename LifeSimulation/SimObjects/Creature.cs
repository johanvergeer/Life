namespace LifeSimulation.SimObjects
{
    public class Creature : SimObject
    {
        public int Energy { get; set; }
        public int Speed { get; set; }
        public int Hunger { get; set; }
        public int Strength { get; set; }
        public int Weight { get; set; }
        public Species Species { get; set; }

        public Creature(int xPos, int yPos, SimObjectColor color, int energy, int speed, int hunger,
            int strength, int weight, Species species) : base(xPos, yPos, color)
        {

        }

        /// <summary>
        /// The creature can move to a given location on the grid
        /// </summary>
        /// <param name="xPos">new xPos of the creature on the grid</param>
        /// <param name="yPos">new yPos of the creature on the grid</param>
        public void Move(int xPos, int yPos)
        {

        }

        /// <summary>
        /// The creature can mate with another creature if it is of the same species
        /// </summary>
        /// <param name="creature">The creature this creature will mate with</param>
        /// <exception cref="">Thrown if the creature in the input parameter is not of the same species</exception>
        public void Mate(Creature creature)
        {

        }

        /// <summary>
        /// The creature can eat another sim object, based on the digestion
        /// </summary>
        /// <param name="simObject">Sim object that will be eaten by the creature</param>
        /// <exception cref="">Thrown if the eaten simObject does not match the creatures digestions</exception>
        public void Eat(SimObject simObject)
        {

        }
    }
}

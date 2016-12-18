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
    }
}

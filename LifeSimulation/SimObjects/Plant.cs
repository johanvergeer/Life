namespace LifeSimulation.SimObjects
{
    public class Plant : SimObject
    {
        public int Energy { get; set; }
        public Plant(int energy, int xPos, int yPos, SimObjectColor color) : base(xPos, yPos, color)
        {

        }
    }
}

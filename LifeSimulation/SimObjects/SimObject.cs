namespace LifeSimulation.SimObjects
{
    public abstract class SimObject
    {
        public int Xpos { get; set; }
        public int YPos { get; set; }
        public SimObjectColor Color { get; set; }

        public SimObject(int xPos, int yPos, SimObjectColor color, SimulationContext context)
        {

        }
    }
}

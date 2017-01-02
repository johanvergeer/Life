namespace LifeSimulation.SimObjects
{
    public abstract class SimObject
    {
        public int XPos { get; set; }
        public int YPos { get; set; }

        protected SimObject(int xPos, int yPos, SimulationContext context)
        {

        }
    }
}

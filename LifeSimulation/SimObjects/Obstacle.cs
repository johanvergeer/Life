namespace LifeSimulation.SimObjects
{
    public class Obstacle : SimObject
    {
        public SimObjectColor SimObjectColor => SimObjectColor.Black;

        public Obstacle(int xPos, int yPos, SimulationContext context) : base(xPos, yPos, context)
        {

        }
    }
}

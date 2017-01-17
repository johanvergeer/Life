using System.Drawing;

namespace LifeSimulation.SimObjects
{
    public abstract class SimObject : ISimObject
    {
        protected SimulationContext Context;
        public int XPos { get; protected set; }
        public int YPos { get; protected set; }
        public Color Color { get; set; }


        protected SimObject(int xPos, int yPos, SimulationContext context)
        {
            Context = context;
            XPos = xPos;
            YPos = yPos;
        }
    }
}

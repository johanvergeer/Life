using System;
using System.Drawing;
using LifeSimulation.Exceptions;

namespace LifeSimulation.SimObjects
{
    public class Obstacle : SimObject
    {
        public Obstacle(int xPos, int yPos, SimulationContext context) : base(xPos, yPos, context)
        {
            Color = Color.Black;
        }
    }
}

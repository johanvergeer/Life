using System;
using LifeSimulation.Exceptions;

namespace LifeSimulation.SimObjects
{
    public class Obstacle : SimObject
    {
        public SimObjectColor SimObjectColor => SimObjectColor.Black;

        public Obstacle(int xPos, int yPos, SimulationContext context) : base(xPos, yPos, context)
        {

        }

        protected override void CheckLocation()
        {
            if (Context.HasSimObjects(XPos, YPos))
                throw new InvalidLocationException();
            if (!Context.Layout.hasTerritory(XPos, YPos))
                throw new InvalidLocationException();
        }
    }
}

﻿using System;
using LifeSimulation.Exceptions;

namespace LifeSimulation.SimObjects
{
    public class Obstacle : SimObject
    {
        public SimObjectColor SimObjectColor => SimObjectColor.Black;

        public Obstacle(int xPos, int yPos, SimulationContext context) : base(xPos, yPos, context)
        {

        }

        /// <summary>
        /// Check if the location is suitable for an obstacle
        /// </summary>
        protected override void CheckLocation()
        {
            if (Context.HasSimObjects(XPos, YPos))
                throw new InvalidLocationException();
            if (!Context.Layout.hasTerritory(XPos, YPos))
                throw new InvalidLocationException();
        }
    }
}

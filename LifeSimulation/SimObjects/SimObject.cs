using System.ComponentModel.Design.Serialization;
using System.Runtime.InteropServices;
using LifeSimulation.Exceptions;

namespace LifeSimulation.SimObjects
{
    public abstract class SimObject
    {
        protected SimulationContext Context;
        public int XPos { get; set; }
        public int YPos { get; set; }
        

        protected SimObject(int xPos, int yPos, SimulationContext context)
        {
            Context = context;
            XPos = xPos;
            YPos = yPos;
            CheckLocation();
        }

        /// <summary>
        /// Check if the SimObject can be located on the x and y position
        /// </summary>
        /// <exception cref="InvalidLocationException">In the location of the SimObject is invalid</exception>
        protected abstract void CheckLocation();
    }
}

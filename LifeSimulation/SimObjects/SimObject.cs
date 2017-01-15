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

        ///// <summary>
        ///// Check if the SimObject can be located on the x and y position
        ///// </summary>
        ///// <exception cref="InvalidLocationException">In the location of the SimObject is invalid</exception>
        //protected bool CheckLocation()
        //{
        //    if (this is Obstacle)
        //    {
        //        if (Context.HasSimObjects(XPos, YPos))
        //            return false;
        //    }
        //    else
        //    {
        //        if (Context.HasSimObjects<Obstacle>(XPos, YPos))
        //            return false;
        //    }
        //    if (!Context.Layout.hasTerritory(XPos, YPos))
        //        return false;

        //    return true;
        //}
    }
}

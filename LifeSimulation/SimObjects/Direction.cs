using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSimulation.SimObjects
{
    /// <summary>
    /// The direction a simObject can move to, or look to. 
    /// 
    /// None = Look or stay at the current position
    /// </summary>
    public enum Direction
    {
        None ,N, NE, E, SE, S, SW, W, NW
    }
}

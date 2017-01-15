using System.Drawing;

namespace LifeSimulation
{
    public interface ISimObject
    {
        int XPos { get; }
        int YPos { get; }
        Color Color { get; set; }
    }
}

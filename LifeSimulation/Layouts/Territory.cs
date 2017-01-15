using System.Drawing;

namespace LifeSimulation.Layouts
{
    public class Territory : ISimObject
    {
        public int XPos { get; }
        public int YPos { get; }
        public Color Color { get; set; }   

        public Territory(int xPos, int yPos)
        {
            XPos = xPos;
            YPos = yPos;
            Color = Color.White;
        }
    }
}
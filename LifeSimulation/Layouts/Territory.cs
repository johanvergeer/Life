namespace LifeSimulation.Layouts
{
    public class Territory
    {
        public int XPos { get; }
        public int YPos { get; }
        public SimObjectColor Color { get; set; }   

        public Territory(int xPos, int yPos)
        {
            XPos = xPos;
            YPos = yPos;
            Color = SimObjectColor.White;
        }
    }
}
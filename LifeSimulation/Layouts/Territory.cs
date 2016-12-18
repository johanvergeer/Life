namespace LifeSimulation.Layouts
{
    public class Territory
    {
        public int XPos { get; set; }
        public int YPos { get; set; }
        public SimObjectColor Color { get; set; }

        public Territory(int xPos, int yPos)
        {
            Color = SimObjectColor.White;
        }
    }
}
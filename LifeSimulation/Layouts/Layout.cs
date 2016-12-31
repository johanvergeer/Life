using System;
using System.Collections.Generic;
using System.Linq;

namespace LifeSimulation.Layouts
{
    /// <summary>
    /// Base class for a layout
    /// </summary>
    public class Layout : ILayout
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int GridSizeX { get; }
        public int GridSizeY { get; }

        public Layout(int id, string name, int gridSizeX, int gridSizeY)
        {
            Id = id;
            Name = name;
            GridSizeX = gridSizeX;
            GridSizeY = gridSizeY;
        }

        public List<Territory> Territories { get; set; }

        IEnumerable<Territory> ILayout.Territories { get; set; }

        public void AddTerritory(Territory territory)
        {
            throw new NotImplementedException();
        }

        public void AddTerritory(int xPos, int yPos)
        {
            throw new NotImplementedException();
        }

        public bool HasTerritory(int xPos, int yPos)
        {
            return Territories.Any(t => t.XPos == xPos && t.YPos == yPos);
        }
    }
}

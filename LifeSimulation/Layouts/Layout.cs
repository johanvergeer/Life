using System;
using System.Collections.Generic;
using System.Linq;
using LifeSimulation.SimObjects;

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
            Territories = new List<Territory>();
        }

        public List<Territory> Territories { get; set; }

        public void addTerritory(Territory territory)
        {
            Territories.Add(territory);
        }

        public void addTerritory(int xPos, int yPos)
        {
            Territories.Add(new Territory(xPos, yPos));
        }

        public bool hasTerritory(int xPos, int yPos)
        {
            return Territories.Any(t => t.XPos == xPos && t.YPos == yPos);
        }

        public bool hasTerritory(int xPos, int yPos, Direction direction)
        {
            SimulationContext.GetCoordinates(ref xPos, ref yPos, direction);
            return hasTerritory(xPos, yPos);
        }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace LifeSimulation.Layouts
{
    public interface ILayout
    {
        /// <summary>
        /// Unique id for the layout
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Name for the layout
        /// </summary>
        string Name { get; set; }

        int GridSizeX { get; }
        int GridSizeY { get; }
        /// <summary>
        /// List of all the territory objects in the layout
        /// </summary>
        List<Territory> Territories { get; set; }

        /// <summary>
        /// Add a territory to the layout.
        /// </summary>
        /// <param name="territory">Territory object</param>
        /// <exception cref="">Thrown if there already is a territory on the selected location</exception>
        void addTerritory(Territory territory);

        /// <summary>
        /// Add a territory to the layout
        /// </summary>
        /// <param name="xPos">The x position of the new territory on the layout</param>
        /// <param name="yPos">The y position of the new territory on the layout</param>
        /// <exception cref="">Thrown if there already is a territory on the selected location</exception>
        void addTerritory(int xPos, int yPos);

        /// <summary>
        /// Check if the coordinates contain territory
        /// </summary>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        /// <returns></returns>
        bool hasTerritory(int xPos, int yPos);
    }
}
using System.Collections.Generic;

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

        /// <summary>
        /// List of all the territory objects in the layout
        /// </summary>
        List<Territory> Territories { get; set; }

        /// <summary>
        /// Add a territory to the layout.
        /// </summary>
        /// <param name="territory">Territory object</param>
        /// <exception cref="">Thrown if there already is a territory on the selected location</exception>
        void AddTerritory(Territory territory);

        /// <summary>
        /// Add a territory to the layout
        /// </summary>
        /// <param name="xPos">The x position of the new territory on the layout</param>
        /// <param name="yPos">The y position of the new territory on the layout</param>
        /// <exception cref="">Thrown if there already is a territory on the selected location</exception>
        void AddTerritory(int xPos, int yPos);
    }
}

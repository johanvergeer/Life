using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Layouts
{
    interface ILayout
    {
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

using System;
using System.Collections.Generic;

namespace LifeSimulation.Layouts
{
    /// <summary>
    /// Base class for a layout
    /// </summary>
    public class Layout : ILayout
    {
        public int Id
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public List<Territory> Territories
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void AddTerritory(Territory territory)
        {
            throw new NotImplementedException();
        }

        public void AddTerritory(int xPos, int yPos)
        {
            throw new NotImplementedException();
        }

        public Layout(int id, string name)
        {

        }
    }
}

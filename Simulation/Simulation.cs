using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.Layouts;
using Simulation.SimObjects;

namespace Simulation
{
    class Simulation : ISimulation
    {
        public Layout layout
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

        public List<SimObject> SimObjects
        {
            get
            {
                throw new NotImplementedException();
            }

            private set
            {

            }
        }

        public int Speed
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

        public SimulationStatus Status
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ISimulation Initialize(Layout layout, int nElements, int? plants, int? carnivores, int? herbivores, int? omnivores, int? nonivores, int? obstacles, int? speed, List<Species> species)
        {
            throw new NotImplementedException();
        }

        public SimulationStatus Pauze()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public SimulationStatus Start()
        {
            throw new NotImplementedException();
        }

        public void Step()
        {
            throw new NotImplementedException();
        }

        public SimulationStatus Stop()
        {
            throw new NotImplementedException();
        }
    }
}

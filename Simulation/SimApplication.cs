using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationProj.Layouts;
using SimulationProj.SimObjects;

namespace SimulationProj
{
    public class SimApplication : ISimApplication
    {
        public List<Layout> layouts
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

        public List<ISimulation> Simulations
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

        public List<Species> Species
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

        public ISimulation AddSimulation(ISimulation simulation)
        {
            throw new NotImplementedException();
        }

        public Layout CreateLayout(string Name, int GridSize)
        {
            throw new NotImplementedException();
        }

        public Species CreateSpecies(string Name, int Searing, int NLegs, Digestion digestion, int MovingThreshold, int SwimmingThreshold, int RepoductionCosts, int Stamina, int HerdBehaviour)
        {
            throw new NotImplementedException();
        }

        public void DeleteLayout(Layout layout)
        {
            throw new NotImplementedException();
        }

        public void DeleteSimulation(ISimulation simulation)
        {
            throw new NotImplementedException();
        }

        public void DeleteSpecies(Species species)
        {
            throw new NotImplementedException();
        }

        public ISimulation LoadSimulation(string fileName)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using LifeSimulation.Layouts;
using LifeSimulation.SimObjects;

namespace LifeSimulation
{
    public class LifeApplication : ILifeApplication
    {
        public LifeApplication()
        {

        }

        public List<Layout> layouts { get; set; }

        public List<ILifeSimulation> Simulations{get; set; }

        public List<Species> Species{get; set; }

        public ILifeSimulation AddSimulation(ILifeSimulation simulation)
        {
            Simulations.Add(simulation);
            return simulation;
        }

        public Layout CreateLayout(string name, int gridSize)
        {
            throw new NotImplementedException();
        }

        public Species CreateSpecies(string name, int searing, int nLegs, Digestion digestion, int movingThreshold, int swimmingThreshold, int sepoductionCosts, int stamina, int herdBehaviour)
        {
            throw new NotImplementedException();
        }

        public void DeleteLayout(Layout layout)
        {
            throw new NotImplementedException();
        }

        public void DeleteSimulation(ILifeSimulation simulation)
        {
            throw new NotImplementedException();
        }

        public void DeleteSpecies(Species species)
        {
            throw new NotImplementedException();
        }

        public ILifeSimulation LoadSimulation(string fileName)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }
    }
}

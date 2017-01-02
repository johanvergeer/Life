using System;
using System.Collections.Generic;
using System.Net.Cache;
using System.Xml.Serialization;
using LifeSimulation.Layouts;
using LifeSimulation.SimObjects;

namespace LifeSimulation
{
    public class LifeApplication : ILifeApplication
    {
        public LifeApplication()
        {
            // Layouts doen we tijdens het implementeren van LifeApplication 
            Layouts = new List<Layout>();
            Simulations = new List<ILifeSimulation>();
            Species = new List<Species>();
        }

        public List<Layout> Layouts { get; set; }

        public List<ILifeSimulation> Simulations{get; set; }

        public List<Species> Species{get; set; }

        public ILifeSimulation AddSimulation(ILifeSimulation simulation)
        {
            Simulations.Add(simulation);
            return simulation;
        }

        public Layout CreateLayout(string name, int gridSize)
        {
            // TODO goede ID maken
            Layout l = new Layout(1, name, gridSize, gridSize);
            Layouts.Add(l);

            return l;
        }

        public Species CreateSpecies(string name, int searing, int nLegs, Digestion digestion, int movingThreshold, 
            int swimmingThreshold, int reprooductionCosts, int stamina, int herdBehaviour, int maximumStrength, int minimumStrength)
        {
            var species = new Species(name, searing, nLegs, digestion, movingThreshold, swimmingThreshold, 
                reprooductionCosts, stamina, herdBehaviour, maximumStrength, minimumStrength);

            Species.Add(species);
            return species;
        }

        public void DeleteLayout(Layout layout)
        {
            Layouts.Remove(layout);
        }

        public void DeleteSimulation(ILifeSimulation simulation)
        {
            Simulations.Remove(simulation);
        }

        public void DeleteSpecies(Species species)
        {
            Species.Remove(species);
        }

        public ILifeSimulation LoadSimulation(string fileName)
        {
            // TODO In overleg met Floris voor het opslaan van een simulatie
            return null;
        }
    }
}

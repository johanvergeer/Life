using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Cache;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using LifeSimulation.Layouts;
using LifeSimulation.SimObjects;

namespace LifeSimulation
{
    public class LifeApplication : ILifeApplication
    {
        public List<Layout> Layouts { get; set; }

        public List<ILifeSimulation> Simulations { get; set; }

        private SpeciesCollection Species { get; set; }

        public LifeApplication()
        {
            // Layouts doen we tijdens het implementeren van LifeApplication 
            Layouts = new List<Layout>();
            Simulations = new List<ILifeSimulation>();
            Species = new SpeciesCollection();
        }

        public ILifeSimulation AddSimulation(ILifeSimulation simulation)
        {
            Simulations.Add(simulation);
            return simulation;
        }

        public Layout CreateLayout(string name, int gridSize)
        {
            var l = CreateLayout(name, gridSize, gridSize);
            return l;
        }

        public Layout CreateLayout(string name, int gridSizeX, int gridSizeY )
        {
            var id_ = (from y in Layouts
                      select(int?)y.Id).Max();

            var id = id_ ?? 0;

            var l = new Layout(id, name, gridSizeX, gridSizeY);
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

        public void DeleteSpecies(Species species)
        {
            Species.Remove(species);
        }

        public bool SaveSpecies(string fileName)
        {
            // https://msdn.microsoft.com/en-us/library/system.runtime.serialization.datacontractserializer.aspx
            try
            {
                var writer = new FileStream(fileName, FileMode.Create);
                var ser = new DataContractSerializer(typeof(SpeciesCollection));
                ser.WriteObject(writer, Species);
                writer.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Loads species from the XML file. 
        /// 
        /// If the XML file does not exist, a new list will be created. 
        /// </summary>
        /// <param name="fileName">Path and filename for the XML file to be loaded</param>
        public void LoadSpecies(string fileName)
        {
            try
            {
                var fs = new FileStream(fileName, FileMode.Open);
                var reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                var ser = new DataContractSerializer(typeof(SpeciesCollection));

                // Deserialize the data and read it from the instance.
                Species = (SpeciesCollection)ser.ReadObject(reader, true);
                reader.Close();
                fs.Close();
            }
            catch (Exception)
            {
                Species = new SpeciesCollection();
            }
        }

        public  ICollection<Species> GetSpecies() => new ReadOnlyCollection<Species>(Species);

        public void DeleteLayout(Layout layout)
        {
            Layouts.Remove(layout);
        }

        public void DeleteSimulation(ILifeSimulation simulation)
        {
            Simulations.Remove(simulation);
        }

        public ILifeSimulation LoadSimulation(string fileName)
        {
            // TODO In overleg met Floris voor het opslaan van een simulatie
            return null;
        }
    }
}

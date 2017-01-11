using System;
using System.Collections.Generic;
using LifeSimulation.Layouts;
using LifeSimulation.SimObjects;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

namespace LifeSimulation
{
    [Serializable]
    public class LifeSimulation : ILifeSimulation
    {
        public int Id { get; set; }
        public int Speed { get; set; }
        public SimulationStatus Status { get; private set; }
        public SimulationContext Context { get; }

        // REPORT DATA
        public int Carnivores { get; private set; }
        public int Omnivores { get; private set; }
        public int Nonivores { get; private set; }
        public int Herbivores { get; private set; }
        public int Planten { get; private set; }
        public int EnergyCarnivores { get; private set; }
        public int EnergyHerbivores { get; private set; }
        public int EnergyOmnivores { get; private set; }
        public int EnergyNonivores { get; private set; }
        public int EnergyPlanten { get; private set;  }

        private readonly int _nElements;
        private readonly ICollection<Species> _species;

        /// <summary>
        /// Initialize the application and set the initial values
        /// 
        /// Precondictions:
        ///     At least one layout has to be created in the application
        ///     
        /// Postconditions:
        ///     The application is initialized
        /// </summary>
        /// 
        /// <param name="layout">A layout object</param>
        /// 
        /// <param name="nElements">The total number of SimObjects that will be in the application</param>
        /// 
        /// <param name="plants">
        ///     The percentage of SimObjects that will be plants
        ///     This value is optional
        /// </param>
        /// <exception cref="">Thrown when plants is smaller then 0 or bigger then 100</exception>
        /// 
        /// <param name="carnivores">
        ///     The percentage of SimObjects that will be carnivores
        ///     This value is optional
        /// </param>
        /// <exception cref="">Thrown when carnivores is smaller then 0 or bigger then 100</exception>
        /// 
        /// <param name="herbivores">
        ///     The percentage of SimObjects that will be herbivores
        ///     This value is optional
        /// </param>
        /// <exception cref="">Thrown when herbivores is smaller then 0 or bigger then 100</exception>
        /// 
        /// <param name="omnivores">
        ///     The percentage of SimObjects that will be omnivores
        ///     This value is optional
        /// </param>
        /// <exception cref="">Thrown when omnivores is smaller then 0 or bigger then 100</exception>
        /// 
        /// <param name="nonivores">
        ///     The percentage of SimObjects that will be nonivores
        ///     This value is optional
        /// </param>
        /// <exception cref="">Thrown when nonivores is smaller then 0 or bigger then 100</exception>
        /// 
        /// <param name="obstacles">
        ///     The percentage of SimObjects that will be obstacles
        ///     This value is optional
        /// </param>
        /// <exception cref="">Thrown when obstacles is smaller then 0 or bigger then 100</exception>
        /// 
        /// <param name="speed">
        ///     The initial speed of the application
        ///     This value is optional
        /// </param>
        /// 
        /// <param name="species">
        ///     A list of all the species that should be used in the simulation
        /// </param>
        /// 
        /// <exception cref="">
        ///     Thrown when the total of plants, carnivores, herbivores, omnivores, 
        ///     nonivores and obstacles is not equal to 100
        /// </exception>
        /// 
        /// <exception cref="">
        /// Thrown when nElements cannot be devided over the types. 
        /// </exception>
        /// 
        /// <returns>An ISimulation object</returns>
        public LifeSimulation(ILayout layout, int nElements, ICollection<Species> species, int plants = 0, int carnivores = 0, int herbivores = 0, int omnivores = 0,
            int nonivores = 0, int obstacles = 0, int speed = 100)
        {
            Context = new SimulationContext(layout);
            _nElements = nElements;
            _species = species;
            Speed = speed;

            // Mooie exceptions geven misschien
            // Loop aantal keer voor maken

            var types = new List<int>
            {
                plants,
                carnivores,
                herbivores,
                omnivores,
                nonivores,
                obstacles
            };

            // Check if every type percentage is from 0 to 100
            if (types.Any(type => type < 0 || type > 100))
                throw new Exception();

            // Check if the count of all types is equal to 100
            if (types.Sum(x => x) != 100)
                throw new Exception();

            AddSimObjects<Obstacle>(obstacles);
            AddSimObjects<Plant>(plants);

            AddCreatures(Digestion.Carnivore, carnivores);
            AddCreatures(Digestion.Herbivore, herbivores);
            AddCreatures(Digestion.OmnivoreCreature, omnivores);
            AddCreatures(Digestion.OmnivorePlant, omnivores);
            AddCreatures(Digestion.Nonivore, nonivores);

            Status = SimulationStatus.New;

            RefreshReportData();
        }

        /// <summary>
        /// Add the creatures of a given digestion to the SimulationContext
        /// The species will be equally devided for the digestion
        /// </summary>
        /// <param name="digestion">The creatures digestion</param>
        /// <param name="percentage">The percentage of the creature with the digestion in the simulation</param>
        private void AddCreatures(Digestion digestion, int percentage)
        {
            var species = _species.Where(sp => sp.Digestion == digestion);
            var speciesCount = species.Count();

            double p;

            if (digestion == Digestion.OmnivorePlant || digestion == Digestion.OmnivoreCreature)
            {
                var omnivores = _species.Where(
                    sp => sp.Digestion == Digestion.OmnivoreCreature || sp.Digestion == Digestion.OmnivorePlant);
                var omnivoreCount = omnivores.Count();
                p = percentage / Math.Pow(speciesCount, 2) / omnivoreCount;
            }
            else
                p = (double)percentage / (double)speciesCount;

            foreach (var s in species)
            {
                AddSimObjects<Creature>(Convert.ToInt32(p), s);
            }
        }

        /// <summary>
        /// Add SimObjects to the context
        /// </summary>
        /// <typeparam name="TSimObject">Type of SimObject</typeparam>
        /// <param name="simObjectPercentage">The percentage for the type of SimObject in the Simulation</param>
        /// <param name="species">Only required if the SimObject is a Creature.</param>
        /// <exception cref="">Thrown when the type is Creature, and species is null</exception>
        private void AddSimObjects<TSimObject>(int simObjectPercentage, Species species = null) where TSimObject : SimObject
        {
            var simObjectType = typeof(TSimObject);
            var gridX = Context.Layout.GridSizeX;
            var gridY = Context.Layout.GridSizeY;
            var random = new Random();

            for (var i = 0; i < Convert.ToInt32(_nElements / 100 * simObjectPercentage); i++)
            {
                while (true)
                {
                    // Random positie blijven genereren tot dit een niet gebruikte plek is vor obstacle
                    var posX = random.Next(0, gridX);
                    var posY = random.Next(0, gridY);

                    // Add object if it is an Obstacle
                    if (simObjectType == typeof(Obstacle))
                    {
                        if (Context.HasSimObjects(posX, posY) || !Context.Layout.hasTerritory(posX, posY)) continue;
                        Context.AddObstacle(new Obstacle(posX, posY, Context));
                        break;
                    }

                    // Check if the position is territory (not water) and does not contain an obstacle
                    if (Context.HasSimObjects<Obstacle>(posX, posY) || !Context.Layout.hasTerritory(posX, posY)) continue;

                    // Add object if it is a plant
                    if (simObjectType == typeof(Plant))
                    {
                        Context.AddPlant(new Plant(100, posX, posY, Context));
                        break;
                    }

                    // Add the object if it is a creature
                    Debug.Assert(species != null, "Species cannot be null if the SimObject type is creature");
                    var str = random.Next(species.MinimumStrength, species.MaximumStrength);
                    Context.AddCreature(new Creature(posX, posY, Context, 100, str, species, Direction.E));
                    break;
                }
            }
        }

        public SimulationStatus Pauze()
        {
            Status = SimulationStatus.Pauzed;
            return Status;
        }

        public void RefreshReportData()
        {
            // In txt bestand de report data opslaan
            // Heel simpel de data opslaan per regel
            // BIj het inladen op dezelfde manier inladen
            var creatures = Context.GetSimObjects<Creature>();
            var plants = Context.GetSimObjects<Plant>();

            Carnivores = 0;
            EnergyCarnivores = 0;
            Herbivores = 0;
            EnergyHerbivores = 0;
            Omnivores = 0;
            EnergyOmnivores = 0;
            Nonivores = 0;
            EnergyNonivores = 0;
            Planten = 0;
            EnergyPlanten = 0;

            foreach (var so in creatures)
            {
                switch (so.Species.Digestion)
                {
                    case Digestion.Carnivore:
                        Carnivores++;
                        EnergyCarnivores += ((Creature)so).Energy;
                        break;
                    case Digestion.Herbivore:
                        Herbivores++;
                        EnergyHerbivores += ((Creature)so).Energy;
                        break;
                    case Digestion.OmnivoreCreature:
                    case Digestion.OmnivorePlant:
                        Omnivores++;
                        EnergyOmnivores += ((Creature)so).Energy;
                        break;
                    case Digestion.Nonivore:
                        Nonivores += 1;
                        EnergyNonivores += ((Creature)so).Energy;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            foreach (var so in plants)
            {
                Planten++;
                EnergyPlanten += so.Energy;
            }
        }

        public void SaveReportData(string filename)
        {
            RefreshReportData();

            using (var outputFile = new StreamWriter(filename))
            {
                // Data opslaan per regel
                outputFile.WriteLine(Carnivores.ToString()); // Aantal carnivores
                outputFile.WriteLine(Herbivores.ToString()); // Aantal herbivores
                outputFile.WriteLine(Omnivores.ToString()); // Aantal omnivores
                outputFile.WriteLine(Nonivores.ToString()); // Aantal nonivores

                // Energie per type
                outputFile.WriteLine(EnergyCarnivores.ToString()); // carnivores
                outputFile.WriteLine(EnergyHerbivores.ToString()); // herbivores
                outputFile.WriteLine(EnergyOmnivores.ToString()); // omnivores
                outputFile.WriteLine(EnergyNonivores.ToString()); // nonivores

                // Gemiddeld per type
                outputFile.WriteLine((EnergyCarnivores / Carnivores).ToString()); // carnivores
                outputFile.WriteLine((EnergyHerbivores / Herbivores).ToString()); // herbivores
                outputFile.WriteLine((EnergyOmnivores / Omnivores).ToString()); // omnivores
                outputFile.WriteLine((EnergyNonivores / Nonivores).ToString()); // nonivores

                // Aantal planten
                outputFile.WriteLine(Planten);
                // Energie planten
                outputFile.WriteLine(EnergyPlanten.ToString());

                // Gemiddeld energie per plant
                outputFile.WriteLine((EnergyPlanten / Planten).ToString());
            }
        }

        public void SaveSimulation(string filename)
        {
            // Class inclusief onderliggende classes serializeren
            // Waarschijnlijk moet dit op een andere manier om alle onderliggende gegevens ok goed door te zetten
            using (FileStream stream = new FileStream(filename, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
            }
        }

        public SimulationStatus Start()
        {
            Status = SimulationStatus.Started;
            return Status;
        }

        public void Step()
        {
            Context.SimulationStep++;

            // Only do step when status is started
            // TODO Snelheid verwerken in de step?
            if ((Status != SimulationStatus.Started) || (Speed <= 0)) return;

            // Loop through SimObjects en voer de juiste functies uit
            foreach (var so in Context.GetAllSimObjects())
                if (so is Creature)
                    // Die dieren willen eerst lopen
                    ((Creature) so).Move();
                else if (so is Plant)
                    // De planten willen groeien
                    ((Plant) so).Act();

            // Na dat iedereen heeft gelopen willen de beesten nog een actie uitvoeren
            foreach (var so in Context.GetAllSimObjects())
                if (so is Creature)
                    // De dieren willen actie ondernemen
                    ((Creature) so).Act();

            RefreshReportData();
        }

        public SimulationStatus Stop()
        {
            Status = SimulationStatus.Stopped;
            return Status;
        }
    }
}

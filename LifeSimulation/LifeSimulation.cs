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

        private readonly SimulationContext _context;
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
        public LifeSimulation(Layout layout, int nElements, List<Species> species, int plants = 0, int carnivores = 0, int herbivores = 0, int omnivores = 0,
            int nonivores = 0, int obstacles = 0, int speed = 100)
        {
            _context = new SimulationContext(layout);
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
            AddCreatures(Digestion.Omnivore, omnivores);
            AddCreatures(Digestion.Nonivore, nonivores);

            this.Status = SimulationStatus.New;
        }

        private void AddCreatures(Digestion digestion, int percentage)
        {
            IEnumerable<Species> species = _species.Where(sp => sp.Digestion == digestion);
            var speciesCount = species.Count();
            
            // Calculate the percentage for each species
            double p = (double) percentage / (double) speciesCount;

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
            var gridX = _context.Layout.GridSizeX;
            var gridY = _context.Layout.GridSizeY;
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
                        if (_context.HasSimObjects(posX, posY) || !_context.Layout.HasTerritory(posX, posY)) continue;
                        _context.AddObstacle(new Obstacle(posX, posY, SimObjectColor.Black, _context));
                        break;
                    }

                    // Check if the position is territory (not water) and does not contain an obstacle
                    if (_context.HasObstacle(posX, posY) || !_context.Layout.HasTerritory(posX, posY)) continue;

                    // Add object if it is a plant
                    if (simObjectType == typeof(Plant))
                    {
                        _context.AddPlant(new Plant(100, posX, posY, SimObjectColor.Green, _context));
                        break;
                    }

                    // Add the object if it is a creature
                    Debug.Assert(species != null, "Species cannot be null if the SimObject type is creature");
                    _context.AddCreature(new Creature(posX, posY, SimObjectColor.Yellow, _context, 100, 0, 0, 0, 0, species));
                    break;
                }
            }
        }

        public SimulationStatus Pauze()
        {
            Status = SimulationStatus.Pauzed;
            return Status;
        }

        public void SaveReportData(string filename)
        {
            // In txt bestand de report data opslaan
            // Heel simpel de data opslaan per regel
            // BIj het inladen op dezelfde manier inladen
            var creatures = _context.GetAllSimObjectsOfType<Creature>();
            var plants = _context.GetAllSimObjectsOfType<Plant>();

            int carnivores = 0;
            int herbivores = 0;
            int omnivores = 0;
            int nonivores = 0;
            int planten = 0;
            int EnergyCarnivores = 0;
            int EnergyHerbivores = 0;
            int EnergyOmnivores = 0;
            int EnergyNonivores = 0;
            int EnergyPlanten = 0;

            foreach (Creature so in creatures)
            {
                if ((so as Creature).Species.Digestion == Digestion.Carnivore)
                {
                    carnivores++;
                    EnergyCarnivores += (so as Creature).Energy;
                }
                else if ((so as Creature).Species.Digestion == Digestion.Herbivore)
                {
                    herbivores++;
                    EnergyHerbivores += (so as Creature).Energy;
                }
                else if ((so as Creature).Species.Digestion == Digestion.Omnivore)
                {
                    omnivores++;
                    omnivores += (so as Creature).Energy;
                }
                else if ((so as Creature).Species.Digestion == Digestion.Nonivore)
                {
                    nonivores += 1;
                    EnergyNonivores += (so as Creature).Energy;
                }
            }

            foreach (var so in plants)
            {
                planten++;
                EnergyPlanten += so.Energy;
            }


            using (var outputFile = new StreamWriter(filename))
            {
                // Data opslaan per regel
                outputFile.WriteLine(carnivores.ToString()); // Aantal carnivores
                outputFile.WriteLine(herbivores.ToString()); // Aantal herbivores
                outputFile.WriteLine(omnivores.ToString()); // Aantal omnivores
                outputFile.WriteLine(nonivores.ToString()); // Aantal nonivores

                // Energie per type
                outputFile.WriteLine(EnergyCarnivores.ToString()); // carnivores
                outputFile.WriteLine(EnergyHerbivores.ToString()); // herbivores
                outputFile.WriteLine(EnergyOmnivores.ToString()); // omnivores
                outputFile.WriteLine(EnergyNonivores.ToString()); // nonivores

                // Gemiddeld per type
                outputFile.WriteLine((EnergyCarnivores / carnivores).ToString()); // carnivores
                outputFile.WriteLine((EnergyHerbivores / herbivores).ToString()); // herbivores
                outputFile.WriteLine((EnergyOmnivores / omnivores).ToString()); // omnivores
                outputFile.WriteLine((EnergyNonivores / nonivores).ToString()); // nonivores

                // Aantal planten
                outputFile.WriteLine(planten);
                // Energie planten
                outputFile.WriteLine(EnergyPlanten.ToString());

                // Gemiddeld energie per plant
                outputFile.WriteLine((EnergyPlanten / planten).ToString());
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
            // Only do step when status is started
            // TODO Snelheid verwerken in de step?
            if ((Status != SimulationStatus.Started) || (Speed <= 0)) return;

            // Loop through SimObjects en voer de juiste functies uit
            foreach (var so in _context.GetAllSimObjects())
                if (so is Creature)
                {
                    // De dieren willen actie ondernemen
                    var c = so as Creature;
                    c.Act();
                }
                else if (so is Plant)
                {
                    // De planten willen groeien
                    var p = so as Plant;
                    p.Grow();
                }
        }

        public SimulationStatus Stop()
        {
            Status = SimulationStatus.Stopped;
            return Status;
        }
    }
}

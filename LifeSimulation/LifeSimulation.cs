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
            AddCreatures(Digestion.Omnivore, omnivores);
            AddCreatures(Digestion.Nonivore, nonivores);

            Status = SimulationStatus.New;
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
                    Context.AddCreature(new Creature(posX, posY, Context, 100, 0, species, Direction.E));
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
            var creatures = Context.GetSimObjects<Creature>();
            var plants = Context.GetSimObjects<Plant>();

            var carnivores = 0;
            var herbivores = 0;
            var omnivores = 0;
            var nonivores = 0;
            var planten = 0;
            var energyCarnivores = 0;
            var energyHerbivores = 0;
            var energyOmnivores = 0;
            var energyNonivores = 0;
            var energyPlanten = 0;

            foreach (var so in creatures)
            {
                switch (so.Species.Digestion)
                {
                    case Digestion.Carnivore:
                        carnivores++;
                        energyCarnivores += ((Creature) so).Energy;
                        break;
                    case Digestion.Herbivore:
                        herbivores++;
                        energyHerbivores += ((Creature) so).Energy;
                        break;
                    case Digestion.Omnivore:
                        omnivores++;
                        energyOmnivores += ((Creature) so).Energy;
                        break;
                    case Digestion.Nonivore:
                        nonivores += 1;
                        energyNonivores += ((Creature) so).Energy;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            foreach (var so in plants)
            {
                planten++;
                energyPlanten += so.Energy;
            }


            using (var outputFile = new StreamWriter(filename))
            {
                // Data opslaan per regel
                outputFile.WriteLine(carnivores.ToString()); // Aantal carnivores
                outputFile.WriteLine(herbivores.ToString()); // Aantal herbivores
                outputFile.WriteLine(omnivores.ToString()); // Aantal omnivores
                outputFile.WriteLine(nonivores.ToString()); // Aantal nonivores

                // Energie per type
                outputFile.WriteLine(energyCarnivores.ToString()); // carnivores
                outputFile.WriteLine(energyHerbivores.ToString()); // herbivores
                outputFile.WriteLine(energyOmnivores.ToString()); // omnivores
                outputFile.WriteLine(energyNonivores.ToString()); // nonivores

                // Gemiddeld per type
                outputFile.WriteLine((energyCarnivores / carnivores).ToString()); // carnivores
                outputFile.WriteLine((energyHerbivores / herbivores).ToString()); // herbivores
                outputFile.WriteLine((energyOmnivores / omnivores).ToString()); // omnivores
                outputFile.WriteLine((energyNonivores / nonivores).ToString()); // nonivores

                // Aantal planten
                outputFile.WriteLine(planten);
                // Energie planten
                outputFile.WriteLine(energyPlanten.ToString());

                // Gemiddeld energie per plant
                outputFile.WriteLine((energyPlanten / planten).ToString());
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
                {
                    // Die dieren willen eerst lopen
                    ((Creature) so).Move();
                }
                else if (so is Plant)
                {
                    // De planten willen groeien
                    ((Plant)so).Grow();
                }
            // Na dat iedereen heeft gelopen willen de beesten nog een actie uitvoeren
            foreach (var so in Context.GetAllSimObjects())
                if (so is Creature)
                {
                    // De dieren willen actie ondernemen
                    ((Creature)so).Move();
                }
        }

        public SimulationStatus Stop()
        {
            Status = SimulationStatus.Stopped;
            return Status;
        }
    }
}

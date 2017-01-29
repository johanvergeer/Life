using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using LifeSimulation.Layouts;
using LifeSimulation.SimObjects;

namespace LifeSimulation
{
    public class SimulationContext
    {
        public ILayout Layout { get; private set; }
        private IList<SimObject> SimObjects { get; }

        private IList<SimObject> NewSimObjects { get; }
        public long SimulationStep { get; set; }

        public int PlantsCount => GetSimObjects<Plant>().Count;
        public int CarnivoresCount => GetCreatures(Digestion.Carnivore).Count;
        public int HerbivoresCount => GetCreatures(Digestion.Herbivore).Count;
        public int OmnivoresCount
            => GetCreatures(Digestion.OmnivoreCreature).Count
            + GetCreatures(Digestion.OmnivoreCreature).Count;
        public int NonivoresCount => GetCreatures(Digestion.Nonivore).Count;

        public int PlantsTotalEnergy => GetSimObjects<Plant>().Sum(p => p.Energy);
        public int CarnivoresTotalEnergy => GetCreatures(Digestion.Carnivore).Sum(c => c.Energy);
        public int HerbivoresTotalEnergy => GetCreatures(Digestion.Herbivore).Sum(h => h.Energy);
        public int OmnivoresTotalEnergy
            => GetCreatures(Digestion.OmnivoreCreature).Sum(o => o.Energy)
            + GetCreatures(Digestion.OmnivoreCreature).Sum(o => o.Energy);
        public int NonivoresTotalEnergy => GetCreatures(Digestion.Nonivore).Sum(n => n.Energy);

        public int PlantsAverageEnergy => PlantsCount > 0 ? PlantsTotalEnergy / PlantsCount : 0;
        public int CarnivoresAverageEnergy => CarnivoresCount > 0 ? CarnivoresTotalEnergy / CarnivoresCount : 0;
        public int HerbivoresAverageEnergy => HerbivoresCount > 0 ? HerbivoresTotalEnergy / HerbivoresCount : 0;
        public int OmnivoresAverageEnergy => OmnivoresCount > 0 ? OmnivoresTotalEnergy / OmnivoresCount : 0;
        public int NonivoresAverageEnergy => NonivoresCount > 0 ? NonivoresTotalEnergy / NonivoresCount : 0;

        public SimulationContext(ILayout layout)
        {
            Layout = layout;
            SimObjects = new List<SimObject>();
            NewSimObjects = new List<SimObject>();
        }

        /// <summary>
        /// Add a new creature to the SimObjects list
        /// </summary>
        /// <param name="creature">Creature object</param>
        public void AddCreature(Creature creature) => SimObjects.Add(creature);

        /// <summary>
        /// Add a new creature to the NewSimObjects list
        /// </summary>
        /// <param name="creature">Creature object</param>
        public void AddNewCreature(Creature creature) => NewSimObjects.Add(creature);

        /// <summary>
        /// Add a new plant to the SimObjects list
        /// </summary>
        /// <param name="plant">Plant object</param>
        public void AddPlant(Plant plant) => SimObjects.Add(plant);

        public void AddPlant(int energy, int xPos, int yPos)
        {
            SimObjects.Add(new Plant(energy, xPos, yPos, this));
        }

        /// <summary>
        /// Add a new obstacle to the SimObjects list
        /// </summary>
        /// <param name="obstacle">Obstacle object</param>
        public void AddObstacle(Obstacle obstacle) => SimObjects.Add(obstacle);

        public void AddObstacle(int xPos, int yPos)
        {
            SimObjects.Add(new Obstacle(xPos, yPos, this));
        }

        /// <summary>
        /// Get all the Simobjects in the SimObjects List
        /// </summary>
        /// <returns>An IEnumerable of all the SimObjects</returns>
        public ReadOnlyCollection<SimObject> GetAllSimObjects() => new ReadOnlyCollection<SimObject>(SimObjects);

        public void RemoveSimObject(SimObject simObject) => SimObjects.Remove(simObject);

        /// <summary>
        /// get all simobjects of a certain SimObject type
        /// </summary>
        /// <typeparam name="TSimObject">A type of SimObject</typeparam>
        /// <returns></returns>
        public ReadOnlyCollection<TSimObject> GetSimObjects<TSimObject>() where TSimObject : SimObject
        {
            var so = SimObjects.OfType<TSimObject>().ToList();
            return new ReadOnlyCollection<TSimObject>(so);
        }

        /// <summary>
        ///  Get all the plants in the direct surroundings
        /// The direct surroundings are all the adjacent gridsquares the creature is currently on
        /// </summary>
        /// <typeparam name="TSimObject">A type of simobjects</typeparam>
        /// <param name="xPos">The xPosition on the grid to look from</param>
        /// <param name="yPos">The yPosition on the grid to look from</param>
        /// <returns></returns>
        public ReadOnlyCollection<TSimObject> GetSimObjects<TSimObject>(int xPos, int yPos) where TSimObject : SimObject
        {
            var values = Enum.GetValues(typeof(Direction));
            return
                values.Cast<Direction>()
                    .Select(direction => GetSimObject<TSimObject>(xPos, yPos, direction))
                    .Where(plant => plant != null)
                    .ToList().AsReadOnly();
        }

        /// <summary>
        /// Get the first simObject in a certain position
        /// </summary>
        /// <typeparam name="TSimObject">A type of SimObject</typeparam>
        /// <param name="xPos">The xPosition on the grid to look from</param>
        /// <param name="yPos">The yPosition on the grid to look from</param>
        /// <param name="direction">
        ///     The direction to look to
        ///     The default is None (The current location)
        /// </param>
        /// <returns></returns>
        public TSimObject GetSimObject<TSimObject>(int xPos, int yPos, Direction direction = Direction.None) where TSimObject : SimObject
        {
            GetCoordinates(ref xPos, ref yPos, direction);

            var simObjects = GetSimObjects<TSimObject>();
            return simObjects.FirstOrDefault(o => o.XPos == xPos && o.YPos == yPos);
        }

        /// <summary>
        /// Get a ReadOnlyCollection of all creatures that are alive
        /// </summary>
        /// <returns>ReadOnlyCollection of alive creatures</returns>
        public ReadOnlyCollection<Creature> GetCreatures()
            => GetSimObjects<Creature>().Where(c => c.IsAlive).ToList().AsReadOnly();

        /// <summary>
        /// Get creatures of a specific digestion type
        /// </summary>
        /// <param name="digestion">Digestion type</param>
        /// <returns>
        ///     List of creatures of a specific digestion type
        ///     Null if there are no creatures of the digestion type
        /// </returns>
        public ReadOnlyCollection<Creature> GetCreatures(Digestion digestion)
        {
            var creatures = GetCreatures().Where(c => c.Species.Digestion == digestion).ToList().AsReadOnly();
            return creatures;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="species"></param>
        /// <returns></returns>
        public ReadOnlyCollection<Creature> GetCreatures(Species species)
            => GetCreatures().Where(c => c.Species == species).ToList().AsReadOnly();

        public ReadOnlyCollection<Creature> GetCreatures(int xPos, int yPos)
            => GetSimObjects<Creature>(xPos, yPos).Where(c => c.IsAlive).ToList().AsReadOnly();

        /// <summary>
        /// Get all creatures except for the one in the creature parameter
        /// </summary>
        /// <param name="xPos">X position of the creature</param>
        /// <param name="yPos">Y position of the creature</param>
        /// <param name="creature">Creature that should be excluded from the returned collection</param>
        /// <returns></returns>
        public ReadOnlyCollection<Creature> GetCreatures(int xPos, int yPos, Creature creature)
            => GetSimObjects<Creature>(xPos, yPos).Where(c => c.IsAlive & !ReferenceEquals(c, creature)).ToList().AsReadOnly();

        public ReadOnlyCollection<Creature> GetCreatures(Species species, int xPos, int yPos)
            => GetCreatures(xPos, yPos).Where(c => c.Species == species && c.IsAlive).ToList().AsReadOnly();

        public ReadOnlyCollection<Creature> GetCreatures(Species species, int xPos, int yPos, Creature creature)
            => GetCreatures(xPos, yPos).Where(c => c.Species == species && c.IsAlive && !ReferenceEquals(c, creature)).ToList().AsReadOnly();

        /// <summary>
        /// Get all the dead creatures in the context. 
        /// 
        /// A creature is dead when the energy is equal to or lower then 0.
        /// </summary>
        /// <returns>List of all the dead creatures in the context</returns>
        public ReadOnlyCollection<Creature> GetDeadCreatures()
           => SimObjects.OfType<Creature>().Where(c => c.IsAlive == false).ToList().AsReadOnly();

        /// <summary>
        /// Check if the location contains any SimObjects
        /// </summary>
        /// <param name="xPos">The x position to look on the grid</param>
        /// <param name="yPos">The Y position to look on the grid</param>
        /// <returns>True if the location contains a SimObject, else False</returns>
        public bool HasSimObjects(int xPos, int yPos)
        {
            return SimObjects.Any(s => s.XPos == xPos && s.YPos == yPos);
        }

        /// <summary>
        /// Check if the position contains a SimObject of a type
        /// </summary>
        /// <param name="xPos">The xPos to look on the grid</param>
        /// <param name="yPos">The yPos to look on the grid</param>
        /// <returns>
        ///     True if the location contains SimObjects of the given type
        ///     False if the location does not contain objects og the give type
        /// </returns>
        public bool HasSimObjects<TSimObject>(int xPos, int yPos) where TSimObject : SimObject
            => GetSimObjects<TSimObject>().Any(o => o.XPos == xPos && o.YPos == yPos);

        public bool HasSimObjects<TSimObject>(int xPos, int yPos, Direction direction) where TSimObject : SimObject
        {
            GetCoordinates(ref xPos, ref yPos, direction);
            return HasSimObjects<TSimObject>(xPos, yPos);
        }

        public void UpdateContext()
        {
            AddNewCreatures();
            RemoveDeadCreatures();
        }

        private void AddNewCreatures()
        {
            foreach (var newSimObject in NewSimObjects)
            {
                SimObjects.Add(newSimObject);
            }
            NewSimObjects.Clear();
        }

        /// <summary>
        /// Delete all the dead creatures from the context
        /// </summary>
        private void RemoveDeadCreatures()
        {
            var dc = GetDeadCreatures();
            if (!dc.Any()) return;
            foreach (var deadCreature in GetDeadCreatures())
            {
                SimObjects.Remove(deadCreature);
            }
        }

        /// <summary>
        /// Get coordinates based on the current position and the direction
        /// </summary>
        /// <param name="xPos">reference , input current x-position, output new x-position</param>
        /// <param name="yPos">reference, input current y-position, output new y-position</param>
        /// <param name="direction">The direction for the new position</param>
        public static void GetCoordinates(ref int xPos, ref int yPos, Direction direction)
        {
            switch (direction)
            {
                case Direction.None:
                    break;
                case Direction.N:
                    yPos--;
                    break;
                case Direction.NE:
                    xPos++;
                    yPos--;
                    break;
                case Direction.E:
                    xPos++;
                    break;
                case Direction.SE:
                    xPos++;
                    yPos++;
                    break;
                case Direction.S:
                    yPos++;
                    break;
                case Direction.SW:
                    xPos--;
                    yPos++;
                    break;
                case Direction.W:
                    xPos--;
                    break;
                case Direction.NW:
                    xPos--;
                    yPos--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
    }
}

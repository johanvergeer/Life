using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using LifeSimulation.Layouts;
using LifeSimulation.SimObjects;

namespace LifeSimulation
{
    public class SimulationContext
    {
        public ILayout Layout { get; private set; }
        private List<SimObject> SimObjects { get; }
        public long SimulationStep { get; set; }

        public SimulationContext(ILayout layout)
        {
            Layout = layout;
            SimObjects = new List<SimObject>();
        }

        /// <summary>
        /// Add a new creature to the SimObjects list
        /// </summary>
        /// <param name="creature">Creature object</param>
        public void AddCreature(Creature creature) => SimObjects.Add(creature);

        /// <summary>
        /// Add a new plant to the SimObjects list
        /// </summary>
        /// <param name="plant">Plant object</param>
        public void AddPlant(Plant plant) => SimObjects.Add(plant);

        /// <summary>
        /// Add a new obstacle to the SimObjects list
        /// </summary>
        /// <param name="obstacle">Obstacle object</param>
        public void AddObstacle(Obstacle obstacle) => SimObjects.Add(obstacle);

        /// <summary>
        /// Get all the Simobjects in the SimObjects List
        /// </summary>
        /// <returns>An IEnumerable of all the SimObjects</returns>
        public IEnumerable<SimObject> GetAllSimObjects() => SimObjects;

        public void RemoveSimObject(SimObject simObject) => SimObjects.Remove(simObject);

        /// <summary>
        /// get all simobjects of a certain SimObject type
        /// </summary>
        /// <typeparam name="TSimObject">A type of SimObject</typeparam>
        /// <returns></returns>
        public IEnumerable<TSimObject> GetSimObjects<TSimObject>() where TSimObject : SimObject
            => SimObjects.OfType<TSimObject>();

        /// <summary>
        ///  Get all the plants in the direct surroundings
        /// The direct surroundings are all the adjacent gridsquares the creature is currently on
        /// </summary>
        /// <typeparam name="TSimObject">A type of simobjects</typeparam>
        /// <param name="xPos">The xPosition on the grid to look from</param>
        /// <param name="yPos">The yPosition on the grid to look from</param>
        /// <returns></returns>
        public IEnumerable<TSimObject> GetSimObjects<TSimObject>(int xPos, int yPos) where TSimObject : SimObject
        {
            var values = Enum.GetValues(typeof(Direction));
            return
                values.Cast<Direction>()
                    .Select(direction => GetSimObject<TSimObject>(xPos, yPos, direction))
                    .Where(plant => plant != null)
                    .ToList();
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
        /// Get creatures of a specific digestion type
        /// </summary>
        /// <param name="digestion">Digestion type</param>
        /// <returns>
        ///     List of creatures of a specific digestion type
        ///     Null if there are no creatures of the digestion type
        /// </returns>
        public IEnumerable<Creature> GetCreatures(Digestion digestion)
        {
            var creatures = GetSimObjects<Creature>();
            return creatures?.Where(c => c.Species.Digestion == digestion);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="species"></param>
        /// <returns></returns>
        public IEnumerable<Creature> GetCreatures(Species species)
        {
            var creatures = GetSimObjects<Creature>();
            return creatures?.Where(c => c.Species == species);
        }

        public IEnumerable<Creature> GetCreatures(Species species, int xPos, int yPos)
        {
            var creatures = GetSimObjects<Creature>(xPos, yPos);
            return creatures?.Where(c => c.Species == species);
        }

        public IEnumerable<Creature> GetCreatures(int xPos, int yPos)
        {
            return GetSimObjects<Creature>(xPos, yPos);
        }

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

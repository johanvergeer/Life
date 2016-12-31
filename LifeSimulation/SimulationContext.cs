using System;
using System.Collections.Generic;
using System.Linq;
using LifeSimulation.Layouts;
using LifeSimulation.SimObjects;

namespace LifeSimulation
{
    public class SimulationContext
    {
        public ILayout Layout { get; private set; }
        private List<SimObject> SimObjects { get; }

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

        public IEnumerable<SimObject> GetAllSimObjects() => SimObjects;

        public void RemoveSimObject(SimObject simObject)
        {
            SimObjects.Remove(simObject);
        }

        /// <summary>
        /// get all simobjects of a certain SimObject type
        /// </summary>
        /// <typeparam name="T">A type of SimObject</typeparam>
        /// <returns></returns>
        public IEnumerable<TSimObject> GetAllSimObjectsOfType<TSimObject>() where TSimObject : SimObject 
            => SimObjects.OfType<TSimObject>();

        /// <summary>
        /// Get a simObject in a certain position
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

            var simObjects = GetAllSimObjectsOfType<TSimObject>();
            return simObjects.FirstOrDefault(o => o.Xpos == xPos && o.YPos == yPos) ?? null;
        }

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
        /// Get creatures of a specific digestion type
        /// </summary>
        /// <param name="digestion">Digestion type</param>
        /// <returns>
        ///     List of creatures of a specific digestion type
        ///     Null if there are no creatures of the digestion type
        /// </returns>
        public IEnumerable<Creature> GetCreaturesOfDigestion(Digestion digestion)
        {
            var creatures = GetAllSimObjectsOfType<Creature>();
            return creatures?.Where(c => c.Species.Digestion == digestion);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="species"></param>
        /// <returns></returns>
        public IEnumerable<Creature> GetCreaturesOfSpecies(Species species)
        {
            var creatures = GetAllSimObjectsOfType<Creature>();
            return creatures?.Where(c => c.Species == species);
        }

        public bool HasSimObjects(int xPos, int yPos)
        {
            return SimObjects.Any(s => s.Xpos == xPos && s.YPos == yPos);
        }

        /// <summary>
        /// Check if the position contains an obstacle
        /// </summary>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        /// <returns></returns>
        public bool HasObstacle(int xPos, int yPos) 
            => GetAllSimObjectsOfType<Obstacle>().Any(o => o.Xpos == xPos && o.YPos == yPos);

        /// <summary>
        /// Get coordinates based on the current position and the direction
        /// </summary>
        /// <param name="xPos">reference , input current x-position, output new x-position</param>
        /// <param name="yPos">reference, input current y-position, output new y-position</param>
        /// <param name="direction">The direction for the new position</param>
        private void GetCoordinates(ref int xPos, ref int yPos, Direction direction)
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
                    break;
            }
        }
    }
}

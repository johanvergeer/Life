using LifeSimulation.Layouts;
using System.Collections.Generic;

namespace LifeSimulation.SimObjects
{
    public class Creature : SimObject
    {
        public int Energy { get; set; }
        public int Speed { get; set; }
        public int Hunger { get; set; }
        public int Strength { get; set; }
        public int Weight { get; set; }
        public Species Species { get; set; }

        public Creature(int xPos, int yPos, SimObjectColor color, SimulationContext context, int energy, int speed, int hunger,
            int strength, int weight, Species species) : base(xPos, yPos, color, context)
        {

        }

        /// <summary>
        /// Make a creature perform an action
        /// 
        /// The creature performs an action.
        /// </summary>
        /// <param name="layout">The entire layout a creature is in</param>
        /// <param name="simObjects">List of SimObjects in the direct environment</param>
        /// <param name="gridSizeX">X size of the grid</param>
        /// <param name="gridSizeY">Y size of the grid</param>
        public void Act()
        {

        }


        /// <summary>
        /// The creature can move to a given location on the grid
        /// </summary>
        /// <param name="xPos">new xPos of the creature on the grid</param>
        /// <param name="yPos">new yPos of the creature on the grid</param>
        public void Move(Layout layout, List<Obstacle> obstacles, int GridSizeX, int GridSizeY)
        {
            
        }

        /// <summary>
        /// Used to check if a creature collides every time it moves to another piece of the grid.
        /// 
        /// 
        /// </summary>
        /// <returns>
        /// true if the creature can continue
        /// false if the creature has to pick another direction
        /// </returns>
        private bool CheckCollision()
        {
            return true;
        }

        /// <summary>
        /// The creature can mate with another creature if it is of the same species
        /// </summary>
        /// <param name="creature">The creature this creature will mate with</param>
        /// <exception cref="">Thrown if the creature in the input parameter is not of the same species</exception>
        private void Mate(Creature creature)
        {

        }

        /// <summary>
        /// The creature can eat another sim object, based on the digestion
        /// </summary>
        /// <param name="simObject">Sim object that will be eaten by the creature</param>
        /// <exception cref="">Thrown if the eaten simObject does not match the creatures digestions</exception>
        private void Eat(SimObject simObject)
        {

        }
    }
}

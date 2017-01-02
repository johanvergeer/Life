using System;
using LifeSimulation.Layouts;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LifeSimulation.SimObjects
{
    public class Creature : SimObject
    {
        private int _strength;
        private int _energy;
        private SimulationContext context;

        /// <summary>
        /// The species of the creature
        /// </summary>
        public Species Species { get; }

        /// <summary>
        /// Energy of the creature.
        /// This has to be more then or equal to 0 and less then or equal to the creatures stamina
        /// </summary>
        public int Energy
        {
            get { return _energy; }
            set
            {
                if (value < 0 || value > Species.Stamina) throw new ArgumentOutOfRangeException(nameof(value));
                _energy = value;
            }
        }

        /// <summary>
        /// Speed of the creature.
        /// 
        /// For Every 10 energy over the minimum weight, the creature is also delayed by one. 
        /// There is no minimum here. 
        /// </summary>
        public int Speed
        {
            get
            {
                // Calculate speed based on weight
                var diff = Weight - Species.MinimumWeight;
                var delay = (int)Math.Floor((double)diff / 10);
                var speed = Species.MaximumSpeed - delay;

                return speed;
            }
        }

        /// <summary>
        /// The hunger of a creature. 
        /// This is the stamina of the species - Energy
        /// </summary>
        public int Hunger => Species.Stamina - Energy;

        /// <summary>
        /// Strength of the creature. 
        /// The strength must always be bigger then or equal to the MinimumStrength 
        /// and smaller then or equal to the MaximumStrenght of the species.
        /// </summary>
        public int Strength
        {
            get { return _strength; }
            set
            {
                if (value < Species.MinimumStrength || value > Species.MaximumStrength) throw new ArgumentOutOfRangeException(nameof(value));
                _strength = value;
            }
        }

        /// <summary>
        /// The weight of the creature
        /// Weight = nLegs * 10 + Energy - Strength with Minimum Weight is nLegs * 10
        /// </summary>
        public int Weight
        {
            get
            {
                var diff = Energy - Strength;
                if (diff > 0)
                    return Species.MinimumWeight + diff;
                return Species.MinimumWeight;
            }
        }

        /// <summary>
        /// Color of the creature.
        /// Carnivore: Red
        /// Herbivore: Brown
        /// Omnivore: Yellow
        /// Nonivore: Purple
        /// </summary>
        public SimObjectColor SimObjectColor
        {
            get
            {
                switch (Species.Digestion)
                {
                    case Digestion.Carnivore:
                        return SimObjectColor.Red;
                    case Digestion.Herbivore:
                        return SimObjectColor.Brown;
                    case Digestion.Omnivore:
                        return SimObjectColor.Yellow;
                    case Digestion.Nonivore:
                        return SimObjectColor.Purple;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public Direction Direction { get; set; }

        public Creature(int xPos, int yPos, SimulationContext context, int energy,
            int strength, Species species, Direction direction) : base(xPos, yPos, context)
        {
            Species = species;
            Energy = energy;
            Strength = strength;
            Direction = direction;
            this.context = context;
        }

        /// <summary>
        /// Make a creature perform an action
        /// 
        /// The creature performs an action.
        /// </summary>
        public void Act()
        {

        }


        /// <summary>
        /// The creature can move to a given location on the grid
        /// </summary>
        public void Move()
        {

        }

        /// <summary>
        /// Used to check if a creature collides every time it moves to another piece of the grid.
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
        /// <exception cref="">Thrown if the creature in the input parameter is not of the same species</exception>
        private void Mate()
        {
            var creature = context.GetCreatures(Species, XPos, YPos).FirstOrDefault();
            if (creature != null)
            {
                var energy = GetChildValue(Energy, creature.Energy);
                var strength = GetChildValue(Strength, creature.Strength);


                var c = new Creature(XPos, YPos, context, energy, strength, Species, GetRandomDirection()); 
                context.AddCreature(c);  
            }
        }

        private int GetChildValue(int parent1, int parent2)
        {
            var e1 = parent1;
            var e2 = parent2;

            var r = new Random();

            return (e1 + e2) / 2 + Math.Abs(e1 - e2) * (r.Next(-1, 1) / 10);
        }

        private Direction GetRandomDirection()
        {
            var values = Enum.GetValues(typeof(Direction));
            var random = new Random();

            var direction = Direction.None;
            while (direction == Direction.None)
            {
                direction = (Direction) values.GetValue(random.Next(values.Length));
            }
            return direction;
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

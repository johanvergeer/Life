using System;
using System.Linq;
using LifeSimulation.Exceptions;

namespace LifeSimulation.SimObjects
{
    public class Creature : SimObject
    {
        private int _strength;
        private int _energy;
        private readonly SimulationContext _context;

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
                    case Digestion.OmnivoreCreature:
                    case Digestion.OmnivorePlant:
                        return SimObjectColor.Yellow;
                    case Digestion.Nonivore:
                        return SimObjectColor.Purple;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// The direction the creature is currently moving in
        /// </summary>
        public Direction Direction { get; set; }

        public Creature(int xPos, int yPos, SimulationContext context, int energy,
            int strength, Species species, Direction direction) : base(xPos, yPos, context)
        {
            Species = species;
            Energy = energy;
            Strength = strength;
            Direction = direction;
            _context = context;
        }

        protected override void CheckLocation()
        {
            if (Context.HasSimObjects<Obstacle>(XPos, YPos))
                throw new InvalidLocationException();
            if (!Context.Layout.hasTerritory(XPos, YPos))
                throw new InvalidLocationException();
        }

        /// <summary>
        /// Make a creature perform an action
        /// 
        /// The creature performs an action.
        /// </summary>
        public void Act()
        {
            if (Energy < Species.Searing)
                Eat();
            else
                Mate();
        }


        /// <summary>
        /// The creature can move to a given location on the grid
        /// </summary>
        public void Move()
        {

        }

        /// <summary>
        /// Called when a creature is eaten. 
        /// Returns the amount of energy that the creature returns. 
        /// 
        /// If energy == 0 then the creature dies.
        /// </summary>
        /// <returns></returns>
        public int GetEaten(int energy)
        {
            return 1;
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
        /// 
        /// The child gets energy from both parents. This is ReproductionCosts of the Species. 
        /// Both parents loose the ReproductionCosts amount of energy.
        /// </summary>
        private void Mate()
        {
            var creature = _context.GetCreatures(Species, XPos, YPos).FirstOrDefault();
            if (creature == null) return;

            // Transfer energy to the child
            var energy = Species.ReproductionCosts * 2;
            Energy -= Species.ReproductionCosts;
            creature.Energy -= Species.ReproductionCosts;

            // Give the child strength. Average of both parents ±10%
            var strength = GetChildValue(Strength, creature.Strength);


            var c = new Creature(XPos, YPos, _context, energy, strength, Species, GetRandomDirection());
            _context.AddCreature(c);
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
                direction = (Direction)values.GetValue(random.Next(values.Length));
            }
            return direction;
        }

        /// <summary>
        /// The creature can eat another sim object, based on the digestion
        /// </summary>
        /// <param name="simObject">Sim object that will be eaten by the creature</param>
        /// <exception cref="">Thrown if the eaten simObject does not match the creatures digestions</exception>
        private void Eat()
        {
            switch (Species.Digestion)
            {
                case Digestion.Carnivore:
                    EatCreature();
                    break;
                case Digestion.Herbivore:
                    break;
                case Digestion.OmnivoreCreature:
                    break;
                case Digestion.OmnivorePlant:
                    
                case Digestion.Nonivore:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private bool EatCreature()
        {
            // Find the first creature that can be eaten
            var creature = _context.GetCreatures(XPos, YPos).First(c => c.Species.Stamina > Strength);
            if (creature == null) return false;

            var transferredEnergy = Strength - creature.Species.Stamina;

            if (creature.Species.Digestion == Digestion.Herbivore ||
                creature.Species.Digestion == Digestion.Nonivore)
            {
                Energy += transferredEnergy;
                creature.Energy -= transferredEnergy;
            }
            else
            {
                // If the other creature also eats creatures, 
                // the energy will be transferred to the strongest one.
                if (Strength > creature.Strength)
                {
                    Energy += transferredEnergy;
                    creature.Energy -= Energy;
                }
                else
                {
                    Energy -= transferredEnergy;
                    creature.Energy += transferredEnergy;
                }
            }
            return true;
        }

        private bool EatPlant()
        {
            // Get the first plant with the most amount of Energy
            var plant = _context.GetSimObjects<Plant>(XPos, YPos).OrderByDescending(p => p.Energy).First();
            if (plant == null) return false;

            Energy++;
            plant.GetEaten();

            return true;
        }
    }
}

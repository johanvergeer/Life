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
        private bool _hasHitObject;

        /// <summary>
        /// The species of the creature
        /// </summary>
        public Species Species { get; }

        /// <summary>
        /// Energy of the creature.
        /// The maximum amount of energy is the stamina of the species
        /// If the energy is 0 or lower, the creature dies.
        /// </summary>
        public int Energy
        {
            get { return _energy; }
            set
            {
                if (value > Species.Stamina)
                    _energy = Species.Stamina;
                else if (value <= 0)
                    Die();
                else
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

        /// <summary>
        /// Check if the location does not have any obstacles and it is territory (not water)
        /// </summary>
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
        /// 
        /// The creature can only move if Energy > MovingThreshold
        /// The creature will move the number of grid squares that is indicated by the speed
        /// 
        /// If the creature hits an obstacle in this round, it will stop immediately and lose half it's energy
        /// If the creature is in the water at the end of the turn, it will loose the same amount of energy as it has legs.
        /// If the creature is on land at the end of the turn, it will loose the same amount of energy as it's weight.
        /// </summary>
        public void Move()
        {
            if (Energy < Species.MovingThreshold)
                return;

            var steps = Speed;
            var hasHitObject = false;
            var water = false;

            while (steps != 0 && !hasHitObject)
            {
                hasHitObject = MoveOne(out water);
                steps--;
            }

            if (hasHitObject)
                Energy /= 2;
            else if (water)
                Energy -= Species.NLegs;
            else
                Energy -= Weight;
        }

        /// <summary>
        /// Move the creature one step
        /// </summary>
        /// <param name="water">True if the Creature is in water.</param>
        /// <returns>True if the creature has hit an obstacle in this round</returns>
        private bool MoveOne(out bool water)
        {
            var move = false;
            water = false;

            // First make sure there is no obstacle in the path
            if (CheckCollision())
            {
                if (!_hasHitObject)
                {
                    _hasHitObject = true;
                    return true;
                }

                while (!move)
                {
                    if (CheckCollision())
                    {
                        Direction = GetRandomDirection();
                        continue;
                    }
                    move = true;
                    _hasHitObject = false;
                }
            }

            // If there is territory in the next square
            if (_context.Layout.hasTerritory(XPos, YPos, Direction))
            {
                MoveDirection();
            }
            // If there is water in the next square
            else
            {
                // Check if energy is below the swimming threshold
                if (Energy <= Species.SwimmingThreshold)
                {
                    MoveDirection();
                    water = true;
                }
                else
                {
                    // If the creature does not want to swim yet, get another direction
                    move = false;
                    while (!move)
                    {
                        Direction = GetRandomDirection();
                        if (!_context.Layout.hasTerritory(XPos, YPos, Direction) ||
                            _context.HasSimObjects<Obstacle>(XPos, YPos, Direction)) continue;
                        move = true;
                        MoveDirection();
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Check if there is an obstacle in the way
        /// </summary>
        /// <returns></returns>
        private bool CheckCollision()
        {
            return _context.HasSimObjects<Obstacle>(XPos, YPos, Direction);
        }

        /// <summary>
        /// Move the creature in a direction
        /// </summary>
        private void MoveDirection()
        {
            switch (Direction)
            {
                case Direction.None:
                    break;
                case Direction.N:
                    MoveUp();
                    break;
                case Direction.NE:
                    MoveUp();
                    MoveRight();
                    break;
                case Direction.E:
                    MoveRight();
                    break;
                case Direction.SE:
                    MoveDown();
                    MoveRight();
                    break;
                case Direction.S:
                    MoveDown();
                    break;
                case Direction.SW:
                    MoveDown();
                    MoveLeft();
                    break;
                case Direction.W:
                    MoveLeft();
                    break;
                case Direction.NW:
                    MoveUp();
                    MoveLeft();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(Direction), Direction, null);
            }
        }

        /// <summary>
        /// Move the creature down on the grid. 
        /// If the creature get's over the edge, send it to the other side of the grid.
        /// </summary>
        private void MoveDown()
        {
            if (YPos != _context.Layout.GridSizeY)
                YPos++;
            else
                YPos = 0;
        }

        /// <summary>
        /// Move the creature up on the grid. 
        /// If the creature get's over the edge, send it to the other side of the grid.
        /// </summary>
        private void MoveUp()
        {
            if (YPos != 0)
                YPos--;
            else
                YPos = _context.Layout.GridSizeY;
        }

        /// <summary>
        /// Move the creature left on the grid. 
        /// If the creature get's over the edge, send it to the other side of the grid.
        /// </summary>
        private void MoveLeft()
        {
            if (XPos != 0)
                XPos--;
            else
                XPos = _context.Layout.GridSizeX;
        }

        /// <summary>
        /// Move the creature right on the grid. 
        /// If the creature get's over the edge, send it to the other side of the grid.
        /// </summary>
        private void MoveRight()
        {
            if (XPos != _context.Layout.GridSizeX)
                XPos++;
            else
                XPos = 0;
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
            if (energy >= Energy) return Energy;
            Energy -= energy;
            return energy;
        }

        /// <summary>
        /// Remove the creature from the context
        /// </summary>
        private void Die()
        {
            _context.RemoveSimObject(this);
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

        /// <summary>
        /// Get the average values of both parents with a random ±10%
        /// </summary>
        /// <param name="parent1">First parent of the child</param>
        /// <param name="parent2">Second parent of the child</param>
        /// <returns></returns>
        private int GetChildValue(int parent1, int parent2)
        {
            var e1 = parent1;
            var e2 = parent2;

            var r = new Random();

            return (e1 + e2) / 2 + Math.Abs(e1 - e2) * (r.Next(-1, 1) / 10);
        }

        /// <summary>
        /// Get a random direction for the creature
        /// </summary>
        /// <returns>A direction</returns>
        private static Direction GetRandomDirection()
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
        /// <exception cref="">Thrown if the eaten simObject does not match the creatures digestions</exception>
        private void Eat()
        {
            switch (Species.Digestion)
            {
                case Digestion.Carnivore:
                    EatCreature();
                    break;
                case Digestion.Herbivore:
                    EatPlant();
                    break;
                case Digestion.OmnivoreCreature:
                    if (!EatCreature())
                        EatPlant();
                    break;
                case Digestion.OmnivorePlant:
                    if (!EatPlant())
                        EatCreature();
                    break;
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

            // Get the difference between the Strenght and the stamina of both creatures
            var diffStrengthStamina = Math.Abs(Strength - creature.Species.Stamina);

            // If the Hunger is smaller then diffStrengthStamina, then the amount of transferred energy is
            // limited by Hunger
            var transferredEnergy = Math.Min(diffStrengthStamina, Hunger);

            // If the target creature does not eat other creatures
            if (creature.Species.Digestion == Digestion.Herbivore ||
                creature.Species.Digestion == Digestion.Nonivore)
            {
                transferredEnergy = creature.GetEaten(transferredEnergy);
                Energy += transferredEnergy;
            }
            else
            {
                // If the other creature also eats creatures, 
                // the energy will be transferred to the strongest one.
                if (Strength > creature.Strength)
                {
                    transferredEnergy = creature.GetEaten(transferredEnergy);
                    Energy += transferredEnergy;
                }
                else
                {
                    transferredEnergy = GetEaten(transferredEnergy);
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

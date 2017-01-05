using System;
using System.ComponentModel;
using LifeSimulation.Exceptions;

namespace LifeSimulation.SimObjects
{
    public class Species
    {
        private int _nLegs;
        private int _stamina;
        private int _searing;
        private int _movingThreshold;
        private int _swimmingThreshold;
        private int _reproductionCosts;
        private int _maximumStrength;
        private int _minimumStrength;

        /// <summary>
        /// Name of the species.
        /// This is only for recognition in the UI.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Stamina of the creature. 
        /// This is the maximum amount of energy a creature can have. 
        /// The minimum is 25, and the maximum is 100.
        /// </summary>
        public int Stamina
        {
            get { return _stamina; }
            private set
            {
                if (value < 25 || value > 100) throw new ArgumentOutOfRangeException(nameof(value));
                _stamina = value;
            }
        }

        /// <summary>
        /// The number of legs for a creature
        /// 
        /// This needs to be an even number and >= 2
        /// </summary>
        public int NLegs
        {
            get { return _nLegs; }
            private set
            {
                if (value == 0 || value % 2 != 0) throw new InvalidNumberOfLegsException(nameof(value));
                _nLegs = value;
            }
        }

        /// <summary>
        /// The Digestion of the creature.  
        /// What the creature will eat
        ///     - Carnivore: The creature will eat other creatures
        ///     - Herbivore: The creature will eat plants
        ///     - OmnivoreCreature: The creature can eat both plants and other creatures, with a preference for other creatures
        ///     - OmnivorePlant: The creature can eat both plants and other creatures, with a preference for Plants
        ///     - Nonivore: The creature cannot eat anything 
        /// </summary>
        public Digestion Digestion { get; set; }

        /// <summary>
        /// Percentage of the stamina where the creature still wants to mate. 
        /// </summary>
        public int Searing
        {
            get { return _searing / 100 * Stamina; }
            private set
            {
                if (value < 0 || value > 100) throw new ArgumentOutOfRangeException(nameof(value));
                _searing = value;
            }
        }

        /// <summary>
        /// Percentage of the stamina where the creature is still able to move
        /// 
        /// This always needs to be smaller then the SwimmingThreshold
        /// </summary>
        public int MovingThreshold
        {
            get { return _movingThreshold / 100 * Stamina; }
            private set
            {
                if (value < 0 || value >= SwimmingThreshold) throw new ArgumentOutOfRangeException(nameof(value));
                _movingThreshold = value;
            }
        }

        /// <summary>
        /// Percentage of the stamina where the creature wants to start swimming to get to another territory for food
        /// 
        /// This always needs to be bigger then the MovingThreshold
        /// </summary>
        public int SwimmingThreshold
        {
            get { return _swimmingThreshold / 100 * Stamina; }
            private set
            {
                if (value <= MovingThreshold || value > 100) throw new ArgumentOutOfRangeException(nameof(value));
                _swimmingThreshold = value;
            }
        }

        /// <summary>
        /// The percentage of stamina the parent transfers to the child
        /// This needs to be less then Searing
        /// </summary>
        public int ReproductionCosts
        {
            get { return _reproductionCosts / 100 * Stamina; }
            private set
            {
                if (value < 0 || value >= Searing) throw new ArgumentOutOfRangeException(nameof(value));
                _reproductionCosts = value;
            }
        }

        /// <summary>
        /// Radius in which the creature will be attracted to others of it's species. 
        /// If this is 0, then the creature will not show any HerdBehavior.
        /// </summary>
        public int Herbehaviour { get; set; }

        /// <summary>
        /// The minimum weight of the creature. 
        /// This is NLegs * 10
        /// </summary>
        public int MinimumWeight => NLegs * 10;

        /// <summary>
        /// The maximum strength a creature can have. 
        /// This needs to be less then the stamina and more then the MinimumStrength.
        /// </summary>
        public int MaximumStrength
        {
            get { return _maximumStrength; }
            private set
            {
                if (value <= MinimumStrength || value >= Stamina) throw new ArgumentOutOfRangeException(nameof(value));
                _maximumStrength = value;
            }
        }

        /// <summary>
        /// The minimum strength a creature can have.
        /// This needs to be more then 0.
        /// </summary>
        public int MinimumStrength
        {
            get { return _minimumStrength; }
            private set
            {
                if (value < 0 || value >= MaximumStrength) throw new ArgumentOutOfRangeException(nameof(value));
                _minimumStrength = value;
            }
        }

        /// <summary>
        /// Maximum speed of the creature based on the number of legs. 
        /// 
        ///  The optimal speed is 5 grid squares per simulation step. 
        /// For every pair of legs the creature has over 6 or below 4, the speed is delayed by one, 
        /// with a minimum of 1 grid square per simulation step.
        /// </summary>
        public int MaximumSpeed {
            get
            {
                const int optimalSpeed = 5;

                // Calculate speed based on nLegs
                int delay;
                if (NLegs < 4)
                    delay = (4 - NLegs) / 2;
                else if (NLegs > 6)
                    delay = (NLegs - 6) / 2;
                else
                    delay = 0;

                var speed = optimalSpeed - delay;
                // The minimumspeed based on nLegs = 1
                if (speed < 1)
                    speed = 1;

                return speed;
            }
        }

        /// <summary>
        /// Create a new species
        /// </summary>
        /// <param name="name">The name of the species</param>
        /// <param name="searing">Percentage of stamina where the creature still wants to mate</param>
        /// <param name="nLegs">
        ///     The number of legs of the creature. 
        ///     This must be an equal number, equal to or higher then 2
        /// </param>
        /// <param name="digestion">
        ///     What the creature will eat
        ///     - Carnivore: The creature will eat other creatures
        ///     - Herbivore: The creature will eat plants
        ///     - OmnivoreCreature: The creature can eat both plants and other creatures, with a preference for other creatures
        ///     - OmnivorePlant: The creature can eat both plants and other creatures, with a preference for Plants
        ///     - Nonivore: The creature cannot eat anything
        /// </param>
        /// <param name="movingThreshold">The percentage of the stamina where the creature can still move</param>
        /// <param name="swimmingThreshold">The percentage of the stamina where the creature want to swim</param>
        /// <param name="reproductionCosts">
        ///     Percentage of stamina that is transferred to the child
        ///     This must be lower then searing
        /// </param>
        /// <param name="stamina">The maximum amount of energy a creature can have</param>
        /// <param name="herdBehaviour">
        ///     The redius in which a creature is attracted to others of it's species
        ///     When this numnber is 0, the creature will not be attracted
        /// </param>
        /// <param name="maximumStrength">The maximum strength a creature can have</param>
        /// <param name="minimumStrength">The minimum strength a creature can haves</param>
        public Species(string name, int searing, int nLegs, Digestion digestion, int movingThreshold, int swimmingThreshold,
            int reproductionCosts, int stamina, int herdBehaviour, int maximumStrength, int minimumStrength)
        {
            Name = name;
            Stamina = stamina;
            NLegs = nLegs;
            Searing = searing;
            Digestion = digestion;
            MovingThreshold = movingThreshold;
            SwimmingThreshold = swimmingThreshold;
            ReproductionCosts = reproductionCosts;
            Herbehaviour = herdBehaviour;
            MaximumStrength = maximumStrength;
            MinimumStrength = minimumStrength;
        }
    }
}

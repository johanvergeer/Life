using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using LifeSimulation.Exceptions;

namespace LifeSimulation.SimObjects
{
    [DataContractAttribute(Name = "Species", Namespace = "http://www.life.com")]
    public class Species
    {
        [DataMember]
        private int _nLegs;
        [DataMember]
        private int _stamina;
        [DataMember]
        private int _searing;
        [DataMember]
        private int _movingThreshold;
        [DataMember]
        private int _swimmingThreshold;
        [DataMember]
        private int _reproductionCosts;
        [DataMember]
        private int _maximumStrength;
        [DataMember]
        private int _minimumStrength;

        /// <summary>
        /// Name of the species.
        /// This is only for recognition in the UI.
        /// </summary>
        [DataMember(Name = "Name", Order = 1)]
        public string Name { get; private set; }

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
                if (value < 25 || value > 100) throw new ArgumentOutOfRangeException(
                    $"Stamina must be between 25 and 100");
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
                if (value == 0 || value % 2 != 0) throw new InvalidNumberOfLegsException("The number of legs must be more then 0 and an equal number");
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
        [DataMember]
        public Digestion Digestion { get; private set; }

        /// <summary>
        /// Percentage of the stamina where the creature still wants to mate. 
        /// </summary>
        public int Searing
        {
            get { return GetStaminaPercentage(_searing); }
            private set
            {
                if (value < 0 || value > 100) throw new ArgumentOutOfRangeException(
                    $"Searing must have a value between 0 and 100");
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
            get { return GetStaminaPercentage(_movingThreshold); }
            private set
            {
                if (SwimmingThreshold != 0)
                    if (value >= SwimmingThreshold) throw new ArgumentOutOfRangeException(
                        $"MovingThreshold must be greater then SwimmingThreshold");
                if (value <= 0) throw new ArgumentOutOfRangeException($"MovingThreshold must be greater then 0");
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
            get { return GetStaminaPercentage(_swimmingThreshold); }
            private set
            {
                if (value <= MovingThreshold || value > 100) throw new ArgumentOutOfRangeException(
                    $"SwimmingThreshold must be greater then MovingThreshopld and smaller then 100");
                _swimmingThreshold = value;
            }
        }

        /// <summary>
        /// The percentage of stamina the parent transfers to the child
        /// This needs to be less then Searing
        /// </summary>
        public int ReproductionCosts
        {
            get { return GetStaminaPercentage(_reproductionCosts); }
            private set
            {
                if (value < 0 || value >= Searing) throw new ArgumentOutOfRangeException(
                    $"ReproductionCosts must be greater then 0 and lower then Searing");
                _reproductionCosts = value;
            }
        }

        /// <summary>
        /// Radius in which the creature will be attracted to others of it's species. 
        /// If this is 0, then the creature will not show any HerdBehavior.
        /// </summary>
        public int Herbehaviour { get; private set; }

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
                if (MinimumStrength != 0)
                    if (value >= Stamina) throw new ArgumentOutOfRangeException(
                        $"Maximumstrength must be smaller then Stamina");
                if (value <= 0 || value >= Stamina) throw new ArgumentOutOfRangeException(
                    $"Maximumstrength must be smaller then Stamina");
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
                if (value < 0 || value >= MaximumStrength) throw new ArgumentOutOfRangeException(
                    $"MinimumStrength must be lower than MaximumStrength");
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

        private int GetStaminaPercentage(int value) => Convert.ToInt32(Math.Round((float) value / 100 * Stamina));

        public Species()
        {
            
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

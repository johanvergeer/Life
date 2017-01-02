using System;
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

        public string Name { get; set; }

        public int Stamina
        {
            get { return _stamina; }
            private set
            {
                if (value < 0 || value > 100) throw new ArgumentOutOfRangeException(nameof(value));
                _stamina = value;
            }
        }

        public int NLegs
        {
            get { return _nLegs; }
            private set
            {
                if (value == 0 || value % 2 != 0) throw new InvalidNumberOfLegsException(nameof(value));
                _nLegs = value;
            }
        }

        public Digestion Digestion { get; set; }

        public int Searing
        {
            get { return _searing; }
            private set
            {
                if (value < 0 || value > 100) throw new ArgumentOutOfRangeException(nameof(value));
                _searing = value;
            }
        }

        public int MovingThreshold
        {
            get { return _movingThreshold; }
            private set
            {
                if (value < 0 || value > 100) throw new ArgumentOutOfRangeException(nameof(value));
                _movingThreshold = value;
            }
        }

        public int SwimmingThreshold
        {
            get { return _swimmingThreshold; }
            private set
            {
                if (value < 0 || value > 100) throw new ArgumentOutOfRangeException(nameof(value));
                _swimmingThreshold = value;
            }
        }

        public int ReproductionCosts
        {
            get { return _reproductionCosts; }
            private set
            {
                if (value < 0 || value > 100) throw new ArgumentOutOfRangeException(nameof(value));
                _reproductionCosts = value;
            }
        }

        public int Herbehaviour { get; set; }

        public int MinimumWeight => NLegs * 10;

        public int MaximumStrength
        {
            get { return _maximumStrength; }
            private set
            {
                if (value < 0 || value >= Stamina) throw new ArgumentOutOfRangeException(nameof(value));
                _maximumStrength = value;
            }
        }

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

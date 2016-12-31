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

        public string Name { get; set; }

        public int Stamina
        {
            get { return _stamina; }
            set
            {
                if (value < 0 || value > 100) throw new ArgumentOutOfRangeException(nameof(value));
                _stamina = value;
            }
        }

        public int NLegs
        {
            get { return _nLegs; }
            set
            {
                if (value == 0 || value % 4 != 0)
                    throw new InvalidNumberOfLegsException();
                _nLegs = value;
            }
        }

        public Digestion Digestion { get; set; }

        public int Searing
        {
            get
            {
                return _searing;
            }
            set
            {
                if (value < 0 || value > 100) throw new ArgumentOutOfRangeException(nameof(value));
                _searing = value;
            }
        }

        public int MovingThreshold
        {
            get { return _movingThreshold; }
            set
            {
                if (value < 0 || value > 100) throw new ArgumentOutOfRangeException(nameof(value));
                _movingThreshold = value;
            }
        }

        public int SwimmingThreshold
        {
            get { return _swimmingThreshold; }
            set
            {
                if (value < 0 || value > 100) throw new ArgumentOutOfRangeException(nameof(value));
                _swimmingThreshold = value;
            }
        }

        public int ReproductionCosts
        {
            get { return _reproductionCosts; }
            set
            {
                if (value < 0 || value > 100) throw new ArgumentOutOfRangeException(nameof(value));
                _reproductionCosts = value;
            }
        }

        public int Herbehaviour { get; set; }

        public int MinimumWeight => NLegs * 10;

        public Species(string name, int searing, int nLegs, Digestion digestion, int movingThreshold, int swimmingThreshold,
            int reproductionCosts, int stamina, int herdBehaviour)
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
        }
    }
}

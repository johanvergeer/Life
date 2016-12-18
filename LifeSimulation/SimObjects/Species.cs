namespace LifeSimulation.SimObjects
{
    public class Species
    {
        public string Name { get; set; }
        public int Searing { get; set; }
        public int NLegs { get; set; }
        public Digestion Digestion { get; set; }
        public int MovingThreshold { get; set; }
        public int SwimmingThreshold { get; set; }
        public int ReproductionCosts { get; set; }
        public int Stamina { get; set; }
        public int Herbehaviour { get; set; }
        public int MinimumWeight { get; set; }

        public Species(string name, int searing, int nLegs, Digestion digestion, int movingThreshold, int swimmingThreshold,
            int reproductionCosts, int stamina, int herdBehaviour, int minimumweight)
        {

        }
    }
}

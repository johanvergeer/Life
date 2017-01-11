using LifeSimulation.Exceptions;

namespace LifeSimulation.SimObjects
{
    public class Plant : SimObject
    {
        public int Energy { get; set; }
        public SimObjectColor SimObjectColor => SimObjectColor.Green;
        public bool IsDead { get; set; }

        private long SimulationStepDeath { get; set; }
        private int CountToDeath { get; set; }

        public Plant(int energy, int xPos, int yPos, SimulationContext context) : base(xPos, yPos, context)
        {
            Energy = energy;
            CountToDeath = 10;
        }

        /// <summary>
        /// Main method to be called in every simulation step
        /// 
        /// This method decides what a plant does in the simulationstep
        /// 
        /// If the plant is dead, there is a check on whether the plant died 100 simulationsteps ago. 
        /// If it was 100 simulation steps, the plant comes back to life and starts growing again.
        /// </summary>
        public void Act()
        {
            if (IsDead)
            {
                if (SimulationStepDeath > Context.SimulationStep - 100) return;
                IsDead = false;
                CountToDeath = 10;
            }
            else
                Grow();
        }

        /// <summary>
        /// A plant can grow by an amount of energy
        /// </summary>
        /// <param name="energy">The amount of energy the plant will grow by</param>
        private void Grow(int energy)
        {
            Energy += energy;
        }

        /// <summary>
        /// The plant will grow with 1 energy
        /// </summary>
        private void Grow()
        {
            Energy++;
        }

        /// <summary>
        /// Get eaten by another SimObject
        /// 
        /// Every time a plant get eaten it looses 1 energy
        /// If the enery is lower then 0, the plant's CountToDeath is reduced by 1
        /// If the plant's CountToDeath is 0, the plant dies. 
        /// </summary>
        public void GetEaten()
        {
            if (IsDead) return;

            Energy--;
            if (Energy <= 0)
                // A plant can loose all energy 10 times before it actually dies.
                CountToDeath--;
            if (CountToDeath <= 0)
                Die();
        }

        /// <summary>
        /// Let the plant die.
        /// 
        /// Set the SimulationStepDeath to the current SimulationStep and IsDead to true.
        /// </summary>
        private void Die()
        {
            SimulationStepDeath = Context.SimulationStep;
            IsDead = true;
        }

        /// <summary>
        /// Check if the location is suitable for a plant
        /// </summary>
        protected sealed override void CheckLocation()
        {
            // Check if there already is an obstacle on the location
            if (Context.GetSimObject<Obstacle>(XPos, YPos) != null)
                throw new InvalidLocationException();

            if (!Context.Layout.hasTerritory(XPos, YPos))
                throw new InvalidLocationException();
        }
    }
}

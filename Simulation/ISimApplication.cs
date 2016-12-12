using Simulation.Layouts;
using Simulation.SimObjects;
using System.Collections.Generic;

namespace Simulation
{
    /// <summary>
    /// Base interface for the simulation application
    /// </summary>
    interface ISimApplication
    {
        /// <summary>
        /// A list of all the species that can be used in simulations
        /// </summary>
        List<Species> Species{ get; set; }

        /// <summary>
        /// A list of all the layouts that can be used in simulations
        /// </summary>
        List<Layout> layouts { get; set; }

        /// <summary>
        /// All the simulations running in the application. 
        /// 
        /// The maximum number of applications is 4
        /// </summary>
        List<ISimulation> Simulations { get; set; }

        /// <summary>
        /// Save the base settings
        ///     - Existing species
        ///     - Existing layouts
        /// </summary>
        /// <exception>Is raised if the save action did not succeed</exception>
        bool Save();

        /// <summary>
        /// Create a new species that can be used to create creatures.
        /// 
        /// PostConditions:
        ///     The minimumWeight is NLegs * 10
        /// </summary>
        /// 
        /// <param name="Name">The name of the species.</param>
        /// 
        /// <param name="Searing">Percentage of the stamina a creature still wants to procreate</param>
        /// <exception cref="">Thrown when searing is smaller then 0 or bigger then 100</exception>
        /// 
        /// <param name="NLegs">The number of legs the creature will have.</param>
        /// <exception cref="">Thrown when the number of legs is not equal</exception>
        /// 
        /// <param name="digestion">A type that indicates what a creature will eat</param>
        /// 
        /// <param name="MovingThreshold">Percentage of the stamina a creature can still move</param>
        /// <exception cref="">Thrown when MovingThreshold is smaller then 0 or bigger then 100</exception>
        /// 
        /// <param name="SwimmingThreshold">Percentage of the stamina a creature can still swim</param>
        /// <exception cref="">Thrown when Swimmingthreshold is smaller then 0 or bigger then 100</exception>
        /// 
        /// <param name="RepoductionCosts">Percentage of the stamina that is passed on to the child while procreating</param>
        /// <exception cref="">Thrown when ReproductionCosts is smaller then 0 or bigger then 100</exception> 
        /// 
        /// <param name="Stamina">Maximum amount of energy a creature can have</param>
        /// 
        /// <param name="HerdBehaviour">
        ///     Incates the distance a creature must be from a herd to be attracted to it.
        ///     If the value is set to 0, the creature will not want to be in a herd.
        /// </param>
        /// 
        /// <returns>The new species object</returns>
        Species CreateSpecies(string Name, int Searing, int NLegs, Digestion digestion,
            int MovingThreshold, int SwimmingThreshold, int RepoductionCosts, int Stamina,
            int HerdBehaviour);

        /// <summary>
        /// Delete a spiecies from the list
        /// 
        /// preconditions:
        ///     The species cannot be used by any of the existing simulations
        /// </summary>
        /// <param name="species">The species that should be deleted</param>
        void DeleteSpecies(Species species);

        /// <summary>
        /// Creates a layout and adds it to the layouts list
        /// </summary>
        /// <param name="Name">Name of the layout</param>
        /// <param name="GridSize">
        ///     The horizontal and vertical number of squares on the grid
        /// </param>
        /// <returns></returns>
        Layout CreateLayout(string Name, int GridSize);

        /// <summary>
        /// Delete a layout from the list
        /// 
        /// precondition:
        ///     The layout cannot be used by any of the existing simulations
        /// </summary>
        /// <param name="layout">The layout that should be deleted</param>
        void DeleteLayout(Layout layout);

        /// <summary>
        /// Add a new simulation to the application
        /// </summary>
        /// <param name="simulation">ISimulation object</param>
        /// <returns>ISimulation object</returns>
        ISimulation AddSimulation(ISimulation simulation);


        /// <summary>
        /// Delete a simulation from the list.
        /// 
        /// precondition:
        ///     The simulation must have the status Stopped
        /// </summary>
        /// <param name="simulation">The simulation that needs to be deleted</param>
        void DeleteSimulation(ISimulation simulation);
    }
}

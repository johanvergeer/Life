
using LifeSimulation.Layouts;
using LifeSimulation.SimObjects;
using System.Collections.Generic;

namespace LifeSimulation
{
    /// <summary>
    /// Base interface for the simulation application
    /// </summary>
    public interface ILifeApplication
    {
        /// <summary>
        /// A list of all the species that can be used in simulations
        /// </summary>
        List<Species> Species { get; set; }

        /// <summary>
        /// A list of all the Layouts that can be used in simulations
        /// </summary>
        List<Layout> Layouts { get; set; }

        /// <summary>
        /// All the simulations running in the application. 
        /// 
        /// The maximum number of applications is 4
        /// </summary>
        List<ILifeSimulation> Simulations { get; set; }

        /// <summary>
        /// Save the base settings
        ///     - Existing species
        ///     - Existing Layouts
        /// </summary>
        /// <exception>Is raised if the save action did not succeed</exception>
        void Save(ILifeSimulation simulation);

        /// <summary>
        /// Create a new species that can be used to create creatures.
        /// Add the new species to the Species List
        /// After the creature is created it has to be saved to the datastore.
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
        /// <exception cref="">Raised if the new species was not saved</exception>
        Species CreateSpecies(string name, int searing, int nLegs, Digestion digestion,
            int movingThreshold, int swimmingThreshold, int repoductionCosts, int stamina,
            int herdBehaviour);

        /// <summary>
        /// Delete a spiecies from the list
        /// 
        /// preconditions:
        ///     The species cannot be used by any of the existing simulations
        /// </summary>
        /// <param name="species">The species that should be deleted</param>
        void DeleteSpecies(Species species);

        /// <summary>
        /// Creates a layout and adds it to the Layouts list
        /// </summary>
        /// <param name="Name">Name of the layout</param>
        /// <param name="GridSize">
        ///     The horizontal and vertical number of squares on the grid
        /// </param>
        /// <returns></returns>
        Layout CreateLayout(string name, int gridSize);

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
        ILifeSimulation AddSimulation(ILifeSimulation simulation);

        /// <summary>
        /// Load a simluation file that can be used to continue the previously stored simulation
        /// </summary>
        /// <param name="fileName">File with the stored simulation</param>
        /// <returns>SimulationProj obect</returns>
        /// <exception cref="">Thrown when file not found</exception>
        /// <exception cref="">
        ///     Thrown when SimulationProj could not be loaded. 
        ///     e.g. in case of a corrupt file
        /// </exception>
        ILifeSimulation LoadSimulation(string fileName);


        /// <summary>
        /// Delete a simulation from the list.
        /// 
        /// precondition:
        ///     The simulation must have the status Stopped
        /// </summary>
        /// <param name="simulation">The simulation that needs to be deleted</param>
        void DeleteSimulation(ILifeSimulation simulation);
    }
}

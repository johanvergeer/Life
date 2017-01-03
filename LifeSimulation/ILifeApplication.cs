
using System;
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
        /// Create a new species that can be used to create creatures.
        /// Add the new species to the Species List
        /// After the creature is created it has to be saved to the datastore.
        /// 
        /// PostConditions:
        ///     The minimumWeight is NLegs * 10
        /// </summary>
        /// 
        /// <param name="name">The name of the species.</param>
        /// 
        /// <param name="searing">Percentage of the stamina a creature still wants to procreate</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when searing is smaller then 0 or bigger then 100</exception>
        /// 
        /// <param name="nLegs">The number of legs the creature will have.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the number of legs is not equal</exception>
        /// 
        /// <param name="digestion">A type that indicates what a creature will eat</param>
        /// 
        /// <param name="movingThreshold">Percentage of the stamina a creature can still move</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when MovingThreshold is smaller then 0 or bigger then 100</exception>
        /// 
        /// <param name="swimmingThreshold">Percentage of the stamina a creature can still swim</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Swimmingthreshold is smaller then 0 or bigger then 100</exception>
        /// 
        /// <param name="repoductionCosts">Percentage of the stamina that is passed on to the child while procreating</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when ReproductionCosts is smaller then 0 or bigger then 100</exception> 
        /// 
        /// <param name="stamina">Maximum amount of energy a creature can have</param>
        /// 
        /// <param name="herdBehaviour">
        ///     Incates the distance a creature must be from a herd to be attracted to it.
        ///     If the value is set to 0, the creature will not want to be in a herd.
        /// </param>
        /// <param name="maximumStrength">
        ///     The maximum strength a creature can have. 
        ///     This should always be less then the stamina
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the maximumStrenght is lower then 0, or higher then the stamina
        /// </exception>
        /// <param name="minimumStrength">
        ///     The minimum strength a creature can have. 
        ///     This should always be lower then the maximumStrength
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the minimumStrength is lower then 0, or higher then the maximumStrength
        /// </exception>
        /// <returns>The new species object</returns>
        /// <exception cref="">Raised if the new species was not saved</exception>
        Species CreateSpecies(string name, int searing, int nLegs, Digestion digestion,
            int movingThreshold, int swimmingThreshold, int repoductionCosts, int stamina,
            int herdBehaviour, int maximumStrength, int minimumStrength);

        /// <summary>
        /// Delete a spiecies from the list
        /// 
        /// preconditions:
        ///     The species cannot be used by any of the existing simulations
        /// </summary>
        /// <param name="species">The species that should be deleted</param>
        void DeleteSpecies(Species species);

        /// <summary>
        /// Creates a square layout and adds it to the Layouts list
        /// </summary>
        /// <param name="name">Name of the layout</param>
        /// <param name="gridSize">
        ///     The horizontal and vertical number of squares on the grid
        /// </param>
        /// <returns></returns>
        Layout CreateLayout(string name, int gridSize);

        /// <summary>
        /// Creates a rectangular layout and adds it to the layouts list
        /// </summary>
        /// <param name="name">The name of the layout</param>
        /// <param name="gridSizeX">The horizontal number of squares on the grid</param>
        /// <param name="gridSizeY">The vertical number of squares on the grid</param>
        /// <returns></returns>
        Layout CreateLayout(string name, int gridSizeX, int gridSizeY);

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

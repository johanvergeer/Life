using Simulation.Layouts;
using Simulation.SimObjects;
using System.Collections.Generic;

namespace Simulation
{
    interface ISimulation
    {
        /// <summary>
        /// Layout will be added in the Initialize method
        /// </summary>
        Layout layout { get; }

        /// <summary>
        /// List of all the Objects in the simulation. 
        /// 
        /// These can only be set inside the class that implements the interface.
        /// </summary>
        List<SimObject> SimObjects { get; }

        /// <summary>
        /// Initialize the application and set the initial values
        /// 
        /// Precondictions:
        ///     At least one layout has to be created in the application
        ///     
        /// Postconditions:
        ///     The application is initialized
        /// </summary>
        /// 
        /// <param name="layout">A layout object</param>
        /// 
        /// <param name="nElements">The total number of SimObjects that will be in the application</param>
        /// 
        /// <param name="plants">
        ///     The percentage of SimObjects that will be plants
        ///     This value is optional
        /// </param>
        /// <exception cref="">Thrown when plants is smaller then 0 or bigger then 100</exception>
        /// 
        /// <param name="carnivores">
        ///     The percentage of SimObjects that will be carnivores
        ///     This value is optional
        /// </param>
        /// <exception cref="">Thrown when carnivores is smaller then 0 or bigger then 100</exception>
        /// 
        /// <param name="herbivores">
        ///     The percentage of SimObjects that will be herbivores
        ///     This value is optional
        /// </param>
        /// <exception cref="">Thrown when herbivores is smaller then 0 or bigger then 100</exception>
        /// 
        /// <param name="omnivores">
        ///     The percentage of SimObjects that will be omnivores
        ///     This value is optional
        /// </param>
        /// <exception cref="">Thrown when omnivores is smaller then 0 or bigger then 100</exception>
        /// 
        /// <param name="nonivores">
        ///     The percentage of SimObjects that will be nonivores
        ///     This value is optional
        /// </param>
        /// <exception cref="">Thrown when nonivores is smaller then 0 or bigger then 100</exception>
        /// 
        /// <param name="obstacles">
        ///     The percentage of SimObjects that will be obstacles
        ///     This value is optional
        /// </param>
        /// <exception cref="">Thrown when obstacles is smaller then 0 or bigger then 100</exception>
        /// 
        /// <param name="speed">
        ///     The initial speed of the application
        ///     This value is optional
        /// </param>
        /// 
        /// <param name="species">
        ///     A list of all the species that should be used in the simulation
        /// </param>
        /// 
        /// <exception cref="">
        ///     Thrown when the total of plants, carnivores, herbivores, omnivores, 
        ///     nonivores and obstacles is not equal to 100
        /// </exception>
        /// 
        /// <exception cref="">
        /// Thrown when nElements cannot be devided over the types. 
        /// </exception>
        /// 
        /// <returns>An ISimulation object</returns>
        ISimulation Initialize(Layout layout, int nElements, int? plants, int? carnivores, int? herbivores, int? omnivores, 
            int? nonivores, int? obstacles, int? speed, List<Species> species);

        /// <summary>
        /// The speed of the application in simulation steps per minute. 
        /// If the speed is 0, the simulation is not moving. 
        /// 
        /// The speed cannot be set to a value below 0. 
        /// There is no maximum other then the capacity of the hardware the application is running on.
        /// </summary>
        int Speed { get; set; }

        /// <summary>
        /// The status of the simulation. 
        /// This will be set with the Start, Pauze and Stop methods.
        /// </summary>
        SimulationStatus Status { get; }

        /// <summary>
        /// Starts or restarts the simulation and sets status to Started. 
        /// 
        /// Preconditions:
        ///     SimulationStatus is set to Pauze or New
        ///     The speed is set to a number higher then 0
        ///     
        /// Postconditions:
        ///     The simulation is running
        ///     SimulationStatus = Started
        /// </summary>
        /// <returns>SimulationStatus</returns>
        SimulationStatus Start();

        /// <summary>
        /// Pauzes the simulation and sets status to Pauzed
        /// 
        /// Preconditions:
        ///     SimulationStatus is set to Started
        ///     
        /// Postconditions:
        ///     The simulation is pauzed
        ///     SimulationStatus = Pauzed
        /// </summary>
        /// <returns>SimulationStatus</returns>
        SimulationStatus Pauze();

        /// <summary>
        /// Stops the simulation and sets the status to Stopped
        /// 
        /// Preconditions:
        ///     SimulationStatus is set to Started, Pauzed or New
        /// 
        /// Postconditions:
        ///     The simulation has stopped
        ///     SimulationStatus = Stopped
        /// </summary>
        /// <returns>SimulationStatus</returns>
        SimulationStatus Stop();

        /// <summary>
        /// Saves the current status of the simulation that can 
        /// be used to load and continue
        /// 
        /// Preconditions:
        ///     The simulation status is set to New or Pauzed
        ///     
        /// Postconditions:
        ///     The simulation data is saved
        /// </summary>
        void Save();

        /// <summary>
        /// Make one step forward in the simulation
        /// 
        /// Preconditions:
        ///     The simulation status is set to Pauzed or New
        ///     The speed is set to 0
        ///     
        /// Postconditions:
        ///     The simulation has moved one step further
        /// </summary>
        void Step();
    }
}

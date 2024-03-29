﻿using LifeSimulation.Layouts;
using LifeSimulation.SimObjects;
using System.Collections.Generic;

namespace LifeSimulation
{
    public interface ILifeSimulation
    {
        /// <summary>
        /// Unique id for a simulation
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// The speed of the application in simulation steps per minute. 
        /// If the speed is 0, the simulation is not moving. 
        /// 
        /// The speed cannot be set to a value below 0. 
        /// There is no maximum other then the capacity of the hardware the application is running on.
        /// </summary>
        int Speed { get; set; }

        // REPORT DATA
        int Carnivores { get; }
        int Omnivores { get; }
        int Nonivores { get; }
        int Herbivores { get; }
        int Planten { get; }
        int EnergyCarnivores { get; }
        int EnergyHerbivores { get;}
        int EnergyOmnivores { get; }
        int EnergyNonivores { get; }
        int EnergyPlanten { get; }

        SimulationContext Context { get; }

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
        void SaveSimulation(string filename);

        /// <summary>
        /// Recalculates current objects
        /// 
        /// Preconditions:
        ///     The simulation status is set to New or Pauzed
        ///     
        /// Postconditions:
        ///     Fields are changed
        /// </summary>
        void RefreshReportData();

        /// <summary>
        /// Saves the current data of the simulation for usage in reports
        /// 
        /// Preconditions:
        ///     The simulation status is set to New or Pauzed
        ///     
        /// Postconditions:
        ///     The report data is saved
        /// </summary>
        void SaveReportData(string filename);

        /// <summary>
        /// Make one step forward in the simulation
        /// 
        /// Preconditions:
        ///     The simulation status is set to Started
        ///     The speed is set to more than 0
        ///     
        /// Postconditions:
        ///     The simulation has moved one step further
        /// </summary>
        void Step();
    }
}

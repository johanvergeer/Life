using System;
using System.Collections.Generic;
using LifeSimulation.Layouts;
using LifeSimulation.SimObjects;

namespace LifeSimulation
{
    public class LifeSimulation : ILifeSimulation
    {
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
        public LifeSimulation(Layout layout, int nElements, int? plants, int? carnivores, int? herbivores, int? omnivores,
            int? nonivores, int? obstacles, int? speed, List<Species> species)
        {

        }

        public int Id
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Layout layout
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Layout Layout
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public List<SimObject> SimObjects
        {
            get
            {
                throw new NotImplementedException();
            }

            private set
            {

            }
        }

        public int Speed
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public SimulationStatus Status
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public SimulationStatus Pauze()
        {
            throw new NotImplementedException();
        }

        public void SaveReportData()
        {
            throw new NotImplementedException();
        }

        public void SaveSimulation()
        {
            throw new NotImplementedException();
        }

        public SimulationStatus Start()
        {
            throw new NotImplementedException();
        }

        public void Step()
        {
            throw new NotImplementedException();
        }

        public SimulationStatus Stop()
        {
            throw new NotImplementedException();
        }
    }
}

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
            // ID Misschien hier nog implementeren?
            this.layout = layout;
            this.Speed = (int)speed;
            SimObjects = new List<SimObject>();

            // Loop aantal keer voor maken 
            if ((carnivores < 0) || (carnivores > 100)) {
                throw new Exception();
            }
            if ((herbivores < 0) || (herbivores > 100))
            {
                throw new Exception();
            }
            if ((omnivores < 0) || (omnivores > 100))
            {
                throw new Exception();
            }
            if ((nonivores < 0) || (nonivores > 100))
            {
                throw new Exception();
            }
            if ((plants < 0) || (plants > 100))
            {
                throw new Exception();
            }
            if ((obstacles < 0) || (obstacles > 100))
            {
                throw new Exception();
            }

            if ((carnivores + omnivores + nonivores + herbivores + plants + obstacles) <> 100)
            {
                throw new Exception();
            }

            // Aanpassing aantal wordt altijd naar beneden afgerond i.p.v. foutmelding
            int i = 0;

            // TODO gridsize van layout ophalen deze word gebruikt voor locatie te bepalen
            int gridX = 100;
            int gridY = 100;
            int posX = 0;
            int posY = 0;
            bool objectPlaced = false;
            Random rnd = new Random();

            for (i = 0; i < Convert.ToInt32(((nElements / 100) * obstacles)); i++)
            {
                objectPlaced = false;
                // Random positie blijven genereren tot dit een niet gebruikte plek is vor obstacle
                while (!objectPlaced)
                {
                    posX = rnd.Next(gridX, gridX);
                    posY = rnd.Next(gridY, gridY);
                    if (!SimObjects.Exists(so => (so.Xpos == posX && so.YPos == posY)))
                    {
                        SimObjects.Add(new Obstacle(posX, posY, SimObjectColor.Black));
                        objectPlaced = true;
                    }
                }
            }

            // TODO NOG INBOUWEN DAT DE PLANTEN NIET OP OBSTAKELS WORDEN GEZET ENZ.

            // Als 2e de planten erop zetten
            for (i = 0; i < Convert.ToInt32(((nElements / 100) * plants)); i++)
            {
                objectPlaced = false;
                // Random positie blijven genereren tot dit een niet gebruikte plek is vor obstacle
                while (!objectPlaced)
                {
                    posX = rnd.Next(gridX, gridX);
                    posY = rnd.Next(gridY, gridY);
                    if (!SimObjects.Exists(so => (so.Xpos == posX && so.YPos == posY)))
                    {
                        SimObjects.Add(new Plant(100, posX, posY, SimObjectColor.Green));
                        objectPlaced = true;
                    }
                }
            }

            // Als 3e de beesten erop zetten
            for (i = 0; i < Convert.ToInt32(((nElements / 100) * carnivores)); i++)
            {
                objectPlaced = false;
                // Random positie blijven genereren tot dit een niet gebruikte plek is vor obstacle
                while (!objectPlaced)
                {
                    posX = rnd.Next(gridX, gridX);
                    posY = rnd.Next(gridY, gridY);
                    if (!SimObjects.Exists(so => (so.Xpos == posX && so.YPos == posY)))
                    {
                        SimObjects.Add(new Plant(100, posX, posY, SimObjectColor.Green));
                        objectPlaced = true;
                    }
                }
            }

            this.Status = SimulationStatus.New;
        }

        public int Id { get; set; }

        public Layout layout { get; }

        public List<SimObject> SimObjects { get; private set; }
        
        public int Speed { get; set; }

        public SimulationStatus Status { get; private set; }

        public SimulationStatus Pauze()
        {
            Status = SimulationStatus.Pauzed;
            return Status;
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
            Status = SimulationStatus.Started;
            return Status;
        }

        public void Step()
        {
            // Only do step when status is started
            if ((Status == SimulationStatus.Started) && (Speed > 0))
            {
                // Loop through SimObjects en voer de juiste functies uit

            }
        }

        public SimulationStatus Stop()
        {
            Status = SimulationStatus.Stopped;
            return Status;
        }
    }
}

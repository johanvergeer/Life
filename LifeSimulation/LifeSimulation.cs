using System;
using System.Collections.Generic;
using LifeSimulation.Layouts;
using LifeSimulation.SimObjects;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace LifeSimulation
{
    [Serializable]
    public class LifeSimulation : ILifeSimulation
    {
        public int Id { get; set; }

        public Layout layout { get; }

        public List<SimObject> SimObjects { get; private set; }

        public int Speed { get; set; }

        public SimulationStatus Status { get; private set; }

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

            // Mooie exceptions gegen misschien
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

            if ((carnivores + omnivores + nonivores + herbivores + plants + obstacles) != 100)
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
                    if ((!SimObjects.Exists(so => (so.Xpos == posX && so.YPos == posY)))
                        && (layout.Territories.Exists(t => (t.XPos == posX && t.YPos == posY))))
                    {
                        SimObjects.Add(new Obstacle(posX, posY, SimObjectColor.Black));
                        objectPlaced = true;
                    }
                }
            }
            
            // Als 2e de planten erop zetten
            for (i = 0; i < Convert.ToInt32(((nElements / 100) * plants)); i++)
            {
                objectPlaced = false;
                // Random positie blijven genereren tot dit een niet gebruikte plek is vor obstacle
                while (!objectPlaced)
                {
                    posX = rnd.Next(gridX, gridX);
                    posY = rnd.Next(gridY, gridY);
                    if ((!SimObjects.Exists(so => (so.Xpos == posX && so.YPos == posY && (so is Obstacle))))
                        && (layout.Territories.Exists(t => (t.XPos == posX && t.YPos == posY))))
                    {
                        SimObjects.Add(new Plant(100, posX, posY, SimObjectColor.Green));
                        objectPlaced = true;
                    }
                }
            }
            
            // De species verdelen met digestion
            List<Species> carnivoren = species.FindAll(sp => (sp.Digestion == Digestion.Carnivore));
            List<Species> herbivoren = species.FindAll(sp => (sp.Digestion == Digestion.Herbivore));
            List<Species> omnivoren = species.FindAll(sp => (sp.Digestion == Digestion.Omnivore));
            List<Species> nonivoren = species.FindAll(sp => (sp.Digestion == Digestion.Nonivore));

            // TODO de start waarden van de creatures bepalen zoals snelheid gewicht enz.
            // Verdeling is afgerond
            
            // Carnivoren
            foreach (Species s in carnivoren)
            {
                for (i = 0; i < Convert.ToInt32(((nElements / 100) * (carnivores / carnivoren.Count))); i++)
                {
                    // Alle carnivoren ophalen
                    objectPlaced = false;
                    // Random positie blijven genereren tot dit een niet gebruikte plek is vor obstacle
                    while (!objectPlaced)
                    {
                        posX = rnd.Next(gridX, gridX);
                        posY = rnd.Next(gridY, gridY);
                        if ((!SimObjects.Exists(so => (so.Xpos == posX && so.YPos == posY && (so is Obstacle))))
                            && (layout.Territories.Exists(t => (t.XPos == posX && t.YPos == posY))))
                        {
                            SimObjects.Add(new Creature(posX, posY, SimObjectColor.Red, 100, 0, 0, 0, 0, s));
                            objectPlaced = true;
                        }
                    }
                }
            }

            // Herbivoren
            foreach (Species s in herbivoren)
            {
                for (i = 0; i < Convert.ToInt32(((nElements / 100) * (herbivores / herbivoren.Count))); i++)
                {
                    // Alle carnivoren ophalen
                    objectPlaced = false;
                    // Random positie blijven genereren tot dit een niet gebruikte plek is vor obstacle
                    while (!objectPlaced)
                    {
                        posX = rnd.Next(gridX, gridX);
                        posY = rnd.Next(gridY, gridY);
                        if ((!SimObjects.Exists(so => (so.Xpos == posX && so.YPos == posY && (so is Obstacle))))
                            && (layout.Territories.Exists(t => (t.XPos == posX && t.YPos == posY))))
                        {
                            SimObjects.Add(new Creature(posX, posY, SimObjectColor.Brown, 100, 0, 0, 0, 0, s));
                            objectPlaced = true;
                        }
                    }
                }
            }

            // Herbivoren
            foreach (Species s in omnivoren)
            {
                for (i = 0; i < Convert.ToInt32(((nElements / 100) * (omnivores / omnivoren.Count))); i++)
                {
                    // Alle carnivoren ophalen
                    objectPlaced = false;
                    // Random positie blijven genereren tot dit een niet gebruikte plek is vor obstacle
                    while (!objectPlaced)
                    {
                        posX = rnd.Next(gridX, gridX);
                        posY = rnd.Next(gridY, gridY);
                        if ((!SimObjects.Exists(so => (so.Xpos == posX && so.YPos == posY && (so is Obstacle))))
                            && (layout.Territories.Exists(t => (t.XPos == posX && t.YPos == posY))))
                        {
                            SimObjects.Add(new Creature(posX, posY, SimObjectColor.Yellow, 100, 0, 0, 0, 0, s));
                            objectPlaced = true;
                        }
                    }
                }
            }

            // Nonivoren
            foreach (Species s in nonivoren)
            {
                for (i = 0; i < Convert.ToInt32(((nElements / 100) * (nonivores / nonivoren.Count))); i++)
                {
                    // Alle carnivoren ophalen
                    objectPlaced = false;
                    // Random positie blijven genereren tot dit een niet gebruikte plek is vor obstacle
                    while (!objectPlaced)
                    {
                        posX = rnd.Next(gridX, gridX);
                        posY = rnd.Next(gridY, gridY);
                        if ((!SimObjects.Exists(so => (so.Xpos == posX && so.YPos == posY && (so is Obstacle))))
                            && (layout.Territories.Exists(t => (t.XPos == posX && t.YPos == posY))))
                        {
                            SimObjects.Add(new Creature(posX, posY, SimObjectColor.Yellow, 100, 0, 0, 0, 0, s));
                            objectPlaced = true;
                        }
                    }
                }
            }

            this.Status = SimulationStatus.New;
        }

        public SimulationStatus Pauze()
        {
            Status = SimulationStatus.Pauzed;
            return Status;
        }

        public void SaveReportData(string filename)
        {
            // In txt bestand de report data opslaan
            // Heel simpel de data opslaan per regel
            // BIj het inladen op dezelfde manier inladen
            List<SimObject> creatures = SimObjects.FindAll(so => (so is Creature));
            List<SimObject> plants = SimObjects.FindAll(so => (so is Plant));

            int carnivores = 0;
            int herbivores = 0;
            int omnivores = 0;
            int nonivores = 0;
            int planten = 0;
            int EnergyCarnivores = 0;
            int EnergyHerbivores = 0;
            int EnergyOmnivores = 0;
            int EnergyNonivores = 0;
            int EnergyPlanten = 0;

            foreach (SimObject so in creatures)
            {
                if ((so as Creature).Species.Digestion == Digestion.Carnivore)
                {
                    carnivores++;
                    EnergyCarnivores += (so as Creature).Energy;
                }
                else if ((so as Creature).Species.Digestion == Digestion.Herbivore)
                {
                    herbivores++;
                    EnergyHerbivores += (so as Creature).Energy;
                }
                else if ((so as Creature).Species.Digestion == Digestion.Omnivore)
                {
                    omnivores++;
                    omnivores += (so as Creature).Energy;
                }
                else if ((so as Creature).Species.Digestion == Digestion.Nonivore)
                {
                    nonivores += 1;
                    EnergyNonivores += (so as Creature).Energy;
                }
            }
           
            foreach (SimObject so in plants)
            {
                planten++;
                EnergyPlanten += (so as Plant).Energy;
            }
            

            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                // Data opslaan per regel
                outputFile.WriteLine(carnivores.ToString()); // Aantal carnivores
                outputFile.WriteLine(herbivores.ToString()); // Aantal herbivores
                outputFile.WriteLine(omnivores.ToString()); // Aantal omnivores
                outputFile.WriteLine(nonivores.ToString()); // Aantal nonivores

                // Energie per type
                outputFile.WriteLine(EnergyCarnivores.ToString()); // carnivores
                outputFile.WriteLine(EnergyHerbivores.ToString()); // herbivores
                outputFile.WriteLine(EnergyOmnivores.ToString()); // omnivores
                outputFile.WriteLine(EnergyNonivores.ToString()); // nonivores

                // Gemiddeld per type
                outputFile.WriteLine((EnergyCarnivores / carnivores).ToString()); // carnivores
                outputFile.WriteLine((EnergyHerbivores / herbivores).ToString()); // herbivores
                outputFile.WriteLine((EnergyOmnivores / omnivores).ToString()); // omnivores
                outputFile.WriteLine((EnergyNonivores / nonivores).ToString()); // nonivores

                // Aantal planten
                outputFile.WriteLine(planten);
                // Energie planten
                outputFile.WriteLine(EnergyPlanten.ToString()); 

                // Gemiddeld energie per plant
                outputFile.WriteLine((EnergyPlanten / planten).ToString()); 
            }
        }

        public void SaveSimulation(string filename)
        {
            // Class inclusief onderliggende classes serializeren
            // Waarschijnlijk moet dit op een andere manier om alle onderliggende gegevens ok goed door te zetten
            using (FileStream stream = new FileStream(filename, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
            }
        }

        public SimulationStatus Start()
        {
            Status = SimulationStatus.Started;
            return Status;
        }

        public void Step()
        {
            // Only do step when status is started
            // TODO Snelheid verwerken in de step?
            if ((Status == SimulationStatus.Started) && (Speed > 0))
            {
                // Loop through SimObjects en voer de juiste functies uit
                foreach (SimObject so in SimObjects)
                {
                    if (so is Creature)
                    {
                        // De dieren willen actie ondernemen
                        Creature c = (so as Creature);
                        c.Act(layout, SimObjects);
                    } else if (so is Plant)
                    {
                        // De planten willen groeien
                        Plant p = (so as Plant);
                        p.Grow();
                    }
                }
            }
        }

        public SimulationStatus Stop()
        {
            Status = SimulationStatus.Stopped;
            return Status;
        }
    }
}

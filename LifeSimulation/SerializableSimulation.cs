using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeSimulation.Layouts;
using LifeSimulation.SimObjects;

namespace LifeSimulation
{
    [Serializable]
    class SerializableSimulation
    {
        public int Id { get; private set; }
        public ILayout Layout { get; private set; }
        public int Speed { get; private set; }

        public IEnumerable<SimObject> SimObjects { get; private set; }

        public SerializableSimulation(int id, int speed, ILayout layout, IEnumerable<SimObject> simObjects )
        {
            Id = id;
            Speed = speed;
            Layout = layout;
            SimObjects = simObjects;
        }

        public SerializableSimulation(int id, int speed, SimulationContext context)
        {
            Id = id;
            Speed = speed;
            Layout = context.Layout;
            SimObjects = context.GetAllSimObjects();
        }
    }
}

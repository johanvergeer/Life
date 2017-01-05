using Microsoft.VisualStudio.TestTools.UnitTesting;
using LifeSimulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeSimulation.Layouts;
using LifeSimulation.SimObjects;

namespace LifeSimulation.Tests
{
    [TestClass()]
    public class SimulationContextTests
    {
        private Layout _layout;
        private SimulationContext _context;
        private Species _species;
        private Creature _creature1;

        [TestInitialize]
        public void SimulationContextTestInitialize()
        {
            _layout = new Layout(1, "Layout 1", 100, 100);
            _layout.addTerritory(50, 50);
            _layout.addTerritory(50, 51);
            _layout.addTerritory(50, 52);
            _context = new SimulationContext(_layout);

            _species = new Species("Dog", 15, 4, Digestion.Carnivore, 20, 60, 10, 100, 0, 95, 20);
        }

        [TestMethod()]
        public void SimulationContextTest()
        {
            Assert.IsInstanceOfType(_context, typeof(SimulationContext));
        }

        [TestMethod()]
        public void AddCreatureTest()
        {
            _context.AddCreature(new Creature(50, 50, _context, 80, 70, _species, Direction.N));
            Assert.IsTrue(_context.GetAllSimObjects().Any(c => c.YPos == 50 && c.XPos == 50));
        }

        // A creature cannot be put on top of an obstacle

        // A creature cannot be put directly in the water

        [TestMethod()]
        public void AddPlantTest()
        {
            _context.AddPlant(new Plant(90, 50, 51, _context));
            Assert.IsTrue(_context.GetAllSimObjects().Any(c => c.YPos == 51 && c.XPos == 50));
        }

        // A plant cannot be put on top of an obstacle

        // A plant cannot be put in the water

        [TestMethod()]
        public void AddObstacleTest()
        {
            _context.AddObstacle(new Obstacle(50, 52, _context));
            Assert.IsTrue(_context.GetAllSimObjects().Any(c => c.YPos == 52 && c.XPos == 50));
        }

        // Obstacle cannot be put on plant

        // Obstacle cannot be put on creature

        // Obstacle cannot be put in the water

        [TestMethod()]
        public void GetAllSimObjectsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveSimObjectTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetSimObjectsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetSimObjectsTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetSimObjectTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCreaturesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCreaturesTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCreaturesTest2()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCreaturesTest3()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void HasSimObjectsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void HasSimObjectsTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void HasSimObjectsTest2()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCoordinatesTest()
        {
            Assert.Fail();
        }
    }
}
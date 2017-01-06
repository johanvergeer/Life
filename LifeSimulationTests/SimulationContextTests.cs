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

        [TestInitialize]
        public void SimulationContextTestInitialize()
        {
            _layout = new Layout(1, "Layout 1", 100, 100);
            for (var i = 50; i <= 100; i++)
            {
                for (var j = 1; j <= 100; j++)
                {
                    _layout.addTerritory(i, j);
                }
            }
            _context = new SimulationContext(_layout);

            _species = new Species("Dog", 15, 4, Digestion.Carnivore, 20, 60, 10, 100, 0, 95, 20);
            _context.AddCreature(new Creature(51, 56, _context, 70, 80, _species, Direction.E));
            _context.AddCreature(new Creature(70, 82, _context, 70, 80, _species, Direction.E));
            _context.AddCreature(new Creature(83, 85, _context, 70, 80, _species, Direction.E));
            _context.AddPlant(50, 51, 56);
            _context.AddPlant(60, 84, 63);
            _context.AddObstacle(84, 64);
            _context.AddObstacle(100, 100);
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

        [TestMethod()]
        public void AddPlantTest()
        {
            _context.AddPlant(new Plant(90, 50, 51, _context));
            Assert.IsTrue(_context.GetAllSimObjects().Any(c => c.YPos == 51 && c.XPos == 50));
        }

        [TestMethod()]
        public void AddObstacleTest()
        {
            _context.AddObstacle(new Obstacle(50, 52, _context));
            Assert.IsTrue(_context.GetAllSimObjects().Any(c => c.YPos == 52 && c.XPos == 50));
        }

        [TestMethod()]
        public void GetAllSimObjectsTest()
        {
            var so = _context.GetAllSimObjects();
            Assert.IsTrue(so.Count() == 7);
        }

        [TestMethod()]
        public void RemoveSimObjectTest()
        {
            var so = _context.GetAllSimObjects().First();
            _context.RemoveSimObject(so);
            Assert.IsTrue(_context.GetAllSimObjects().Count() == 6);
        }

        [TestMethod()]
        public void GetSimObjectsTest()
        {
            Assert.AreEqual(_context.GetSimObjects<Plant>().Count(), 2);
            Assert.AreEqual(_context.GetSimObjects<Creature>().Count(), 3);
            Assert.AreEqual(_context.GetSimObjects<Obstacle>().Count(), 2);
        }

        [TestMethod()]
        public void GetSimObjectsTest1()
        {
            Assert.AreEqual(_context.GetSimObjects<Creature>(51, 56).Count(), 1);
        }

        [TestMethod()]
        public void GetSimObjectTest()
        {
            var so = _context.GetSimObject<Creature>(51, 57, Direction.N);
            Assert.IsInstanceOfType(so, typeof(Creature));
        }

        [TestMethod()]
        public void GetCreaturesTest()
        {
            var c = _context.GetCreatures(Digestion.Carnivore);
            Assert.AreEqual(c.Count(), 3);
        }

        [TestMethod()]
        public void GetCreaturesTest1()
        {
            var c = _context.GetCreatures(_species);
            Assert.AreEqual(c.Count(), 3);
        }

        [TestMethod()]
        public void GetCreaturesTest2()
        {
            var c = _context.GetCreatures(_species, 51, 56);
            Assert.AreEqual(c.Count(), 1);

            var d = _context.GetCreatures(_species, 50, 50);
            Assert.AreEqual(d.Count(), 0);


        }

        [TestMethod()]
        public void GetCreaturesTest3()
        {
            var c = _context.GetCreatures(51, 56);
            Assert.AreEqual(c.Count(), 1);

            var d = _context.GetCreatures(50, 50);
            Assert.AreEqual(d.Count(), 0);
        }

        [TestMethod()]
        public void HasSimObjectsTest()
        {
            Assert.IsTrue(_context.HasSimObjects(51, 56));
            Assert.IsFalse(_context.HasSimObjects(50, 50));
        }

        [TestMethod()]
        public void HasSimObjectsTest1()
        {
            Assert.IsTrue(_context.HasSimObjects<Creature>(51, 56));
            Assert.IsFalse(_context.HasSimObjects<Creature>(50, 50));
        }

        [TestMethod()]
        public void HasSimObjectsTest2()
        {
            Assert.IsTrue(_context.HasSimObjects<Creature>(50, 56, Direction.E));
            Assert.IsFalse(_context.HasSimObjects<Creature>(50, 56, Direction.W));
        }

        [TestMethod()]
        public void GetCoordinatesTest()
        {
            var x = 10;
            var y = 10;
            SimulationContext.GetCoordinates(ref x, ref y, Direction.N);
            Assert.AreEqual(y, 9);

            x = 10;
            y = 10;
            SimulationContext.GetCoordinates(ref x, ref y, Direction.NE);
            Assert.AreEqual(x, 11);
            Assert.AreEqual(y, 9);

            x = 10;
            y = 10;
            SimulationContext.GetCoordinates(ref x, ref y, Direction.E);
            Assert.AreEqual(x, 11);

            x = 10;
            y = 10;
            SimulationContext.GetCoordinates(ref x, ref y, Direction.SE);
            Assert.AreEqual(x, 11);
            Assert.AreEqual(y, 11);

            x = 10;
            y = 10;
            SimulationContext.GetCoordinates(ref x, ref y, Direction.S);
            Assert.AreEqual(y, 11);

            x = 10;
            y = 10;
            SimulationContext.GetCoordinates(ref x, ref y, Direction.SW);
            Assert.AreEqual(x, 9);
            Assert.AreEqual(y, 11);

            x = 10;
            y = 10;
            SimulationContext.GetCoordinates(ref x, ref y, Direction.W);
            Assert.AreEqual(x, 9);

            x = 10;
            y = 10;
            SimulationContext.GetCoordinates(ref x, ref y, Direction.NW);
            Assert.AreEqual(x, 9);
            Assert.AreEqual(y, 9);

            x = 10;
            y = 10;
            SimulationContext.GetCoordinates(ref x, ref y, Direction.None);
            Assert.AreEqual(x, 10);
            Assert.AreEqual(y, 10);
        }
    }
}
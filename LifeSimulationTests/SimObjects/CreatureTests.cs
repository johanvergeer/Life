using Microsoft.VisualStudio.TestTools.UnitTesting;
using LifeSimulation.SimObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeSimulation.Layouts;

namespace LifeSimulation.SimObjects.Tests
{
    [TestClass()]
    public class CreatureTests
    {
        private Layout _layout;
        private SimulationContext _context;
        private Species _species;
        private Creature _creature1;
        private Creature _creature2;
        private Creature _creature3;

        [TestInitialize]
        public void CreatureTestInitialize()
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

            _creature1 = new Creature(51, 56, _context, 70, 80, _species, Direction.N);
            _creature2 = new Creature(70, 82, _context, 70, 80, _species, Direction.E);
            _creature3 = new Creature(83, 85, _context, 70, 80, _species, Direction.S);
            _context.AddCreature(_creature1);
            _context.AddCreature(_creature2);
            _context.AddCreature(_creature3);
            _context.AddPlant(50, 51, 56);
            _context.AddPlant(60, 84, 63);
            _context.AddObstacle(84, 64);
            _context.AddObstacle(100, 100);
        }

        [TestMethod()]
        public void CreatureTest()
        {
            Assert.IsInstanceOfType(_creature1, typeof(Creature));
            Assert.IsInstanceOfType(_creature2, typeof(Creature));
            Assert.IsInstanceOfType(_creature3, typeof(Creature));
        }

        [TestMethod()]
        public void GetEatenTest()
        {
            // Test waarbij er 20 van zijn energy afgaat
            int energy = _creature1.Energy;
            _creature1.GetEaten(20);
            Assert.AreEqual(_creature1.Energy, energy - 20);

            // Test waarbij energie te hoog is er dus niets gebeurd
            energy = _creature2.Energy;
            _creature2.GetEaten(100);
            Assert.AreEqual(_creature2.Energy, energy);
        }

        [TestMethod()]
        public void MoveTest()
        {
            int XPos = _creature1.XPos;
            int YPos = _creature1.YPos;
            int energy = _creature1.Energy;
            // Creature laten lopen (nnaar he noorden
            _creature1.Move();
            energy = energy - _creature1.Weight;
            YPos = YPos - _creature1.Speed;
            // Creature moet dus het aantal van speed aan stappen hebben gezet
            Assert.AreEqual(_creature1.YPos, YPos);
            // Energy moetlager zijn
            
            Assert.AreEqual(_creature1.Energy, energy);
            
            _creature1.Move();
            energy = energy - _creature1.Weight;
            YPos = YPos - _creature1.Speed;
            Assert.AreEqual(_creature1.YPos, YPos);
            
            // Creatures energy is te laag en gaat dus dood! TEST UITVOEREN
        }

        [TestMethod()]
        public void ActTest()
        {
            Assert.Fail();
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LifeSimulation.SimObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            _context.AddObstacle(83, 86);
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

            var creatureCount = _context.GetAllSimObjects().Count();
            _creature1.Move();
            YPos = YPos - _creature1.Speed;
            Assert.AreEqual(_creature1.YPos, YPos);

            // Het aanal moe dan ook minder zijn dus
            Assert.IsTrue(_context.GetAllSimObjects().Count() == (creatureCount -1));
        }

        [TestMethod()]
        public void MoveTest2()
        {
            // Test beest obstakel Colssion
            // Beest verliest helft van zijn energy
            Direction d1 = _creature3.Direction;
            var energy = _creature3.Energy;
            _creature3.Move();
            Assert.IsTrue(_creature3.Energy == (energy/2));
            // Na botsen tegen opstakel gaat hij bij de volgende move van richting veranderen
            _creature3.Move();
            Assert.AreNotEqual(d1, _creature3.Direction);
        }

        [TestMethod()]
        public void ActTest()
        {
            // Act kan of mate of 01
            var creatureCount = _context.GetAllSimObjects().Count();

            // We doen als eerst act! De beesten staan zo geinitialiseerd dat ze bij elkaar staan.
            // We verwachten dus dat ze gaan paren dit doen we tot ze onder Searing leven komen
            while (_creature2.Energy > _creature2.Species.Searing)
            {
                Assert.IsTrue(_creature2.Energy > _creature2.Species.Searing);
                _creature2.Act();
                // Er is nu dus een nieuw beest bijgekomen
                creatureCount++;
                Assert.AreEqual(creatureCount, _context.GetAllSimObjects().Count());
            }

            // Nu zijn we bij het punt dat het beest zou willen eten
            var energy = _creature2.Energy;
            _creature2.Act();
            // Na het eten heeft het beest dus meer energy
            Assert.IsTrue(_creature2.Energy > energy);

            // Na een keer eten heeft hij weer zin om te paren dus paart hij nu weer
            _creature2.Act();
            // creature 2 zou het andere creature op hebben gegeten i.v.m. de energie niveaus in de vorige cyclus
            // Nu paart hij weer dus blijft het aantal gelijk omdat we bij het opvragen van energy pas het beest dood laten gaan
            Assert.AreEqual(creatureCount, _context.GetAllSimObjects().Count());

            // Zo gaat het cirkeltje rond
        }
    }
}
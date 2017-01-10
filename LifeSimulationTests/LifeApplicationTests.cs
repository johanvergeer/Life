using Microsoft.VisualStudio.TestTools.UnitTesting;
using LifeSimulation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeSimulation.SimObjects;

namespace LifeSimulation.Tests
{
    [TestClass()]
    public class LifeApplicationTests
    {
        private LifeApplication _lifeApplication;
        private string XMLPath;

        [TestInitialize]
        public void LifeApplicationTestsInitialize()
        {
            _lifeApplication = new LifeApplication();

            // Test with existing XML file
            var currentPath = Environment.CurrentDirectory;
            XMLPath = Path.Combine(currentPath, "creatures.xml");
        }

        [TestCleanup]
        public void LifeApplicationTestsCleanup()
        {
            // Delete the created XML file
            File.Delete(XMLPath);
        }

        /// <summary>
        /// Save species with 1 species in the SpeciesCollection
        /// </summary>
        [TestMethod()]
        public void SaveSpeciesTest1()
        {
            _lifeApplication.CreateSpecies("Dog", 15, 4, Digestion.Carnivore, 20, 60, 10, 100, 0, 95, 20);
            _lifeApplication.SaveSpecies(XMLPath);

            bool fileExists = File.Exists(XMLPath);
            Assert.IsTrue(fileExists);
        }

        /// <summary>
        /// Save species without any species in the SpeciesCollection
        /// </summary>
        [TestMethod()]
        public void SaveSpeciesTest2()
        {
            _lifeApplication.SaveSpecies(XMLPath);

            bool fileExists = File.Exists(XMLPath);
            Assert.IsTrue(fileExists);
        }



        /// <summary>
        /// Test load species with existing XML file
        /// </summary>
        [TestMethod()]
        public void LoadSpeciesTest1()
        {

            // Test with existing XML file
            _lifeApplication.CreateSpecies("Dog", 15, 4, Digestion.Carnivore, 20, 60, 10, 100, 0, 95, 20);
            _lifeApplication.SaveSpecies(XMLPath);

            _lifeApplication.LoadSpecies(XMLPath);
            var s = _lifeApplication.GetSpecies().Count;

            Assert.AreEqual(s, 1);
        }

        /// <summary>
        /// Test load species without existing XML file. 
        /// 
        /// Result should be an empty SpeciesCollection
        /// </summary>
        [TestMethod()]
        public void LoadSpeciesTest2()
        {
            _lifeApplication.LoadSpecies(XMLPath);
            var s = _lifeApplication.GetSpecies().Count;
            Assert.AreEqual(s, 0);
        }

        /// <summary>
        /// Test load species with an XML file without any species. 
        /// 
        /// Result should be an empty SpeciesCollection
        /// </summary>
        [TestMethod()]
        public void LoadSpeciesTest3()
        {
            _lifeApplication.SaveSpecies(XMLPath);

            _lifeApplication.LoadSpecies(XMLPath);
            var s = _lifeApplication.GetSpecies().Count;
            Assert.AreEqual(s, 0);
        }
    }
}
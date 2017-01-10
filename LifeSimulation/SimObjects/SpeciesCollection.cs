using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LifeSimulation.SimObjects
{
    [CollectionDataContractAttribute(Name = "SpeciesCollection", Namespace = "", ItemName = "Species")]
    public class SpeciesCollection : List<Species> { }
}

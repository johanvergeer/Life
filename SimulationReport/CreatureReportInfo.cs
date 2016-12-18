using LifeSimulation.SimObjects;

namespace ReportManager
{
    class CreatureReportInfo : SimObjectinfo
    {
        public Digestion Digestion { get; set; }

        CreatureReportInfo(int totalCount, int totalEnergy, Digestion digestion)
        {

        }
    }
}

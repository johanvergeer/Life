using System;

namespace ReportManager
{
    public class BaseReport : IReport
    {
        public int Id
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void LoadSimulationData()
        {
            throw new NotImplementedException();
        }

        public BaseReport(string name)
        {

        }

        private void AddCarnivores(int totalCount, int totalEnergy)
        {

        }

        private void AddHerbivores(int totalCount, int totalEnergy)
        {

        }

        private void AddOmnivores(int totalCount, int totalEnergy)
        {

        }

        private void AddNonivores(int totalCount, int totalEnergy)
        {

        }

        private void AddPlants(int totalCount, int totalEnergy)
        {

        }
    }
}

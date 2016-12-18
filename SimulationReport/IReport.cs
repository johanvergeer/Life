namespace ReportManager
{
    public interface IReport
    {
        /// <summary>
        /// Unique Id for the report
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Name for the report
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Load a Simulation file into the report program
        /// </summary>
        void LoadSimulationData();
    }
}

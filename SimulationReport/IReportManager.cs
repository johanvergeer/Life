using System.Collections.Generic;

namespace ReportManager
{
    public interface IReportManager
    {
        List<IReport> Reports { get; set; }

        /// <summary>
        /// Create a new report
        /// </summary>
        /// <param name="simulationFile">Path to the simulation file</param>
        /// <returns>IReport object</returns>
        IReport CreateReport(string simulationFile);
    }
}

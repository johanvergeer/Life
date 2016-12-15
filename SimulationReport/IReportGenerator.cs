using System.Collections.Generic;

namespace ReportManager
{
    interface IReportManager
    {
        List<IReport> Reports { get; set; }

        /// <summary>
        /// Get a report from the reports list
        /// </summary>
        /// <param name="reportId">Id from a report</param>
        /// <returns></returns>
        IReport GetReport(int reportId);

        /// <summary>
        /// Create a new report
        /// </summary>
        /// <param name="simulationFile">Path to the simulation file</param>
        /// <returns>IReport object</returns>
        IReport CreateReport(string simulationFile);
    }
}

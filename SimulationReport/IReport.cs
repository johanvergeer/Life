using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    interface IReport
    {
        int Id { get; set; }

        /// <summary>
        /// Load a Simulation file into the report program
        /// </summary>
        void LoadSimulation();

        /// <summary>
        /// Create a report
        /// 
        /// preconditions:
        ///     - A simulation file has to be loaded
        /// </summary>
        void CreateReport();

        /// <summary>
        /// Exports a report to a file on the system that can be read in another system.
        /// </summary>
        /// <example>PDF, Excel, etc...</example>
        /// <param name="path">The path where the report should be exported to</param>
        void Export(string path);

        /// <summary>
        /// Save the report in the native format for reloading
        /// </summary>
        void Save();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Ethan Holmes
    /// Created: 04/28/2020
    /// Approver: Rasha Mohammed
    /// 
    /// EmpCustProblemVM is the data object for a Customer Conflict/Problem Record.
    /// </summary>
    ///
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// </remarks>
    public class EmpCustProblemVM
    {
        public string problemType { get; set; }
        public string name { get; set; }
        public string desctiption { get; set; }
    }
}

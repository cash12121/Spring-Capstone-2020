using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Jordan Lindo
    /// Created: 4/22/2020
    /// Approver: Chase Schulte
    /// 
    /// The class for a shift object view with employee name and shift time information.
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// 
    /// </remarks>
    public class ShiftUserVM : Shift
    {
        public string DateString { get; set; }
        public string EmployeeName { get; set; }
        public string ShiftStart { get; set; }
        public string ShiftEnd { get; set; }
    }
}

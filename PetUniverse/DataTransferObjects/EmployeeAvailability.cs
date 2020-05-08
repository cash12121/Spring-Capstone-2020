using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// CREATOR: Lane Sandburg
    /// DATE: 4/2/2020
    /// APPROVER: Jordan Lindo
    ///
    /// DTO from employee availability
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// </remarks>

    public class EmployeeAvailability
    {
        public int AvailabilityID { get; set; }
        public int EmployeeID { get; set; }
        public string DayOfWeek { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool Active { get; set; }
    }
}

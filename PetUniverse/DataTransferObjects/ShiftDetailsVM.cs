using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Chase Schulte
    /// Created: 2020/04/05
    /// Approver: Kaleb Bachert
    ///
    /// List of ShiftVM for the MVC
    /// </summary>
    public class ShiftDetailsVM : Shift
    {
        public string ShiftTimeDeptID { get; set; }
        public string ShiftStartTime { get; set; }
        public string ShiftEndTime { get; set; }
        public DateTime ShiftScheduleStartDate { get; set; }
        public DateTime ShiftScheduleEndDate { get; set; }
        public string ShiftPUUserFirstName { get; set; }
        public string ShiftPUUserLastName { get; set; }
        public List<EmployeeAvailability> ShiftAvailabilities { get; set; }
    }
}

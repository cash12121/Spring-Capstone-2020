using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Chase Schulte
    /// Created: 2020/03/28
    /// Approver: Kaleb Bachert
    ///
    /// List of Shift data objects
    /// </summary>
    public class Shift
    {
        public int ShiftID { get; set; }
        public int ShiftTimeID { get; set; }
        public int ScheduleID { get; set; }
        public DateTime ShiftDate { get; set; }
        public int EmployeeID { get; set; }
        public string RoleID { get; set; }
    }
}

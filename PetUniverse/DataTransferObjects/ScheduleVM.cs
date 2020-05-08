using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Jordan Lindo
    /// Created: 4/8/2020
    /// Approver: Chase Schulte
    /// 
    /// A View model for schedule.
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// 
    /// </remarks>
    public class ScheduleVM : Schedule
    {
        public string CreatorName { get; set; }
        public List<ShiftUserVM> ScheduleLines { get; set; }

    }
}

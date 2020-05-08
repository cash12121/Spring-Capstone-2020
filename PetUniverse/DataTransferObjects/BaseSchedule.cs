using System;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Jordan Lindo
    /// Created: 3/12/2020
    /// Approver: Chase Schulte
    /// 
    /// This is a data transfer object for BaseSchedule.
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// 
    /// </remarks>
    public class BaseSchedule
    {
        public int BaseScheduleID { get; set; }
        public int CreatingUserID { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }
    }
}

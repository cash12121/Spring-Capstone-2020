using System;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Lane Sandburg
    /// Created: 02/07/2020
    /// Approver: Alex Diers
    /// 
    /// ShiftTime Data Transfer Object
    /// </summary>
    /// <remarks>
    /// Updater: Alex Diers
    /// Updated: 5/5/2020
    /// Update: Changed date of creation to correct year
    /// Updater: Lane Sandburg
    /// Updated: 5/5/2020
    /// Update: Added Active Field
    /// </remarks> 
    public class PetUniverseShiftTime
    {
        public int ShiftTimeID { get; set; }
        public String DepartmentID { get; set; }
        public String StartTime { get; set; }
        public String EndTime { get; set; }
        public Boolean Active { get; set; }
    }
}

using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Jordan Lindo
    /// Created: 4/23/2020
    /// Approver: Chase Schulte
    /// 
    /// Interface for IScheduleHoursAccessor
    /// </summary>
    public interface IScheduleHoursAccessor
    {
        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/23/2020
        /// Approver: Chase Schulte
        /// 
        /// Interface method for inserting schedule hours.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        int InsertAllScheduleHours(int scheduleID, List<PUUserVMHours> employees);
    }
}

using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Jordan Lindo
    /// Created: 4/23/2020
    /// Approver: Chase Schulte
    /// 
    /// The class for Schedule hours logic
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// 
    /// </remarks>
    public class ScheduleHoursManager : IScheduleHoursManager
    {
        IScheduleHoursAccessor _scheduleHoursAccessor;

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/23/2020
        /// Approver: Chase Schulte
        /// 
        /// Constructor for schedule hours manager
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public ScheduleHoursManager()
        {
            _scheduleHoursAccessor = new ScheduleHoursAccessor();
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/23/2020
        /// Approver: Chase Schulte
        /// 
        /// Consructor for test manager.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="scheduleHoursAccessor"></param>
        public ScheduleHoursManager(IScheduleHoursAccessor scheduleHoursAccessor)
        {
            _scheduleHoursAccessor = scheduleHoursAccessor;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/23/2020
        /// Approver: Chase Schulte
        /// 
        /// The method for adding all schedule hours.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public int AddAllScheduleHours(int scheduleID, List<PUUserVMHours> employees)
        {
            return _scheduleHoursAccessor.InsertAllScheduleHours(scheduleID, employees);
        }
    }
}

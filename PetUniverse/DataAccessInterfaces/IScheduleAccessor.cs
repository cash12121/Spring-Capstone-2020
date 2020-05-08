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
    /// Created: 4/8/2020
    /// Approver: Chase Schulte
    /// 
    /// Interface for IScheduleAccessor
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// 
    /// </remarks>
    public interface IScheduleAccessor
    {
        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/8/2020
        /// Approver: Chase Schulte
        /// 
        /// Method for getting all schedules by active. 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        List<ScheduleVM> SelectAllSchedules(bool active);

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/8/2020
        /// Approver: Chase Schulte
        /// 
        /// Method for adding a schedule.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="schedule"></param>
        /// <returns></returns>
        int InsertSchedule(ScheduleVM schedule);

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/14/2020
        /// Approver: Chase Schulte
        /// 
        /// Method for building a shift.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="date"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        List<PUUserVMAvailability> GetListOfAvailableEmployees(DateTime date, BaseScheduleLine line);

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/14/2020
        /// Approver: Chase Schulte
        /// 
        /// Method for getting a count of active schedules.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <returns></returns>
        int GetCountOfActiveSchedules();

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/28/2020
        /// Approver: Kaleb Bachert
        /// 
        /// Method for deactivating a schedule.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="scheduleID"></param>
        /// <returns></returns>
        int DeactivateSchedule(int scheduleID);
        
    }
}

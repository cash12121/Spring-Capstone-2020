using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Jordan Lindo
    /// Created: 4/09/2020
    /// Approver: Chase Schutle
    /// 
    /// Interface methods for Schedule
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// 
    /// </remarks>
    public interface IScheduleManager
    {
        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/09/2020
        /// Approver: Chase Schutle
        /// 
        /// Interface method for adding a schedule.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        int AddSchedule(ScheduleVM scheduleVM);

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/09/2020
        /// Approver: Chase Schutle
        /// 
        /// Interface method for Schedule getting all schedules by active.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        List<ScheduleVM> RetrieveAllSchedules(bool active = true);

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/09/2020
        /// Approver: Chase Schutle
        /// 
        /// Interface method for generating a Schedule
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="date"></param>
        /// <param name="lines"></param>
        /// <returns></returns>
        ScheduleVM GenerateSchedule(DateTime date, List<BaseScheduleLine> lines);


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/09/2020
        /// Approver: Chase Schutle
        /// 
        /// Interface method for adding shceduled hours.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="scheduleID"></param>
        /// <returns></returns>
        bool AddScheduledHours(int scheduleID);
    }
}

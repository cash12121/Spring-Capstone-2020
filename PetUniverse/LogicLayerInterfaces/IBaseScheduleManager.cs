using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Jordan Lindo
    /// Created: 3/15/2020
    /// Approver: Chase Schulte
    /// 
    /// BaseSchedule Manager interface
    /// </summary>
    public interface IBaseScheduleManager
    {
        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver: Chase Schulte
        /// 
        /// Interface methods for BaseSchedule
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <returns></returns>
        BaseScheduleVM GetActiveBaseSchedule();

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver: Chase Schulte
        /// 
        /// Interface methods for BaseSchedule
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <returns></returns>
        List<BaseSchedule> GetAllBaseSchedules();

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver: Chase Schulte
        /// 
        /// Interface methods for BaseSchedule
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <returns></returns>
        List<BaseScheduleLine> GetBaseScheduleLinesByBaseScheduleID(int baseScheduleID);

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver: Chase Schulte
        /// 
        /// Interface methods for BaseSchedule
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <returns></returns>
        int AddBaseSchedule(BaseScheduleVM baseScheduleVM);

    }
}

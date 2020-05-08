using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Jordan Lindo
    /// Created: 3/13/2020
    /// Approver: Chase Schulte
    /// 
    /// BaseSchedule Accessor interface
    /// </summary>
    public interface IBaseScheduleAccessor
    {

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver: Chase Schulte
        /// 
        /// Interface method for BaseScheudle
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        BaseScheduleVM RetrieveActiveBaseSchedule();

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver: Chase Schulte
        /// 
        /// Interface method for BaseScheudle
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        List<BaseSchedule> RetrieveAllBaseSchedules();

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver: Chase Schulte
        /// 
        /// Interface method for BaseScheudle
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        List<BaseScheduleLine> RetrieveBaseScheduleLinesByBaseScheduleID(int baseScheduleID);

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver: Chase Schulte
        /// 
        /// Interface method for BaseScheudle
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        int InsertBaseScheduleVM(BaseScheduleVM baseScheduleVM);
    }
}
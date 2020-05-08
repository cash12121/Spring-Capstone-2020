using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 4/9/2020
    /// Approver: Ben Hanna, 4/10/20
    /// Approver: 
    /// 
    /// Interface for the FacilityTaskAccessor
    /// </summary>
    public interface IFacilityTaskAccessor
    {
        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// Approver: 
        /// 
        /// Method to insert a FacilityTask Record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityTask"></param>
        /// <returns>1 or 0 int depending if record was added</returns>
        int InsertFacilityTaskRecord(FacilityTask facilityTask);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// Approver: 
        /// 
        /// Method to select all FacilityTask Records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="taskCompleted"></param>
        /// <returns>List<FacilityTask></returns>
        List<FacilityTask> SelectAllFacilityTasks(bool taskCompleted = false);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// Approver: 
        /// 
        /// Method to select FacilityTask Records by id
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityTaskID"></param>
        /// <param name="taskCompleted"></param>
        /// <returns>List<FacilityTask></returns>
        List<FacilityTask> SelectFacilityTaskByID(int facilityTaskID, bool taskCompleted = false);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// Approver: 
        /// 
        /// Method to select FacilityTask Records by userID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="taskCompleted"></param>
        /// <returns>List<FacilityTask></returns>
        List<FacilityTask> SelectFacilityTaskByUserID(int userID, bool taskCompleted = false);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// Approver: 
        /// 
        /// Method to select FacilityTask Records by task name
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityTaskName"></param>
        /// <param name="taskCompleted"></param>
        /// <returns>List<FacilityTask></returns>
        List<FacilityTask> SelectFacilityTaskByTaskName(string facilityTaskName, bool taskCompleted = false);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/16/2020
        /// Approver: Daulton Schiling, 4/16/2020
        /// 
        /// Method to update a facility task record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldFacilityTask"></param>
        /// <param name="newFacilityTask"></param>
        /// <returns>1 or 0 int depending if record was updated</returns>
        int UpdateFacilityTask(FacilityTask oldFacilityTask, FacilityTask newFacilityTask);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/16/2020
        /// Approver: Daulton Schiling, 4/16/2020
        /// Approver: 
        /// 
        /// Method to delete a facility task record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="facilityTaskID"></param>
        /// <returns>int 1 or 0 depending if record was deleted</returns>
        int DeleteFacilityTask(int facilityTaskID);
    }
}

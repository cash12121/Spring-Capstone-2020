using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 4/9/2020
    /// Approver: Ben Hanna, 4/10/20
    /// Approver: 
    /// 
    /// Interface for the FacilityTaskManager class
    /// </summary>
    public interface IFacilityTaskManager
    {
        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// Approver: 
        /// 
        /// Method to add a FacilityTaskRecord
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityTask"></param>
        /// <returns>true or false depending on if record was updated</returns>
        bool AddFacilityTaskRecord(FacilityTask facilityTask);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// Approver: 
        /// 
        /// Method to retrieve all FacilityTask Records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="taskCompleted"></param>
        /// <returns>List<FacilityTask></returns>
        List<FacilityTask> RetrieveAllFacilityTask(bool taskCompleted = false);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// Approver: 
        /// 
        /// Method to retrieve FacilityTask Records by id
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityTaskID"></param>
        /// <param name="taskCompleted"></param>
        /// <returns>List<FacilityTask></returns>
        List<FacilityTask> RetrieveFacilityTaskByID(int facilityTaskID, bool taskCompleted = false);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// Approver: 
        /// 
        /// Method to retrieve FacilityTask Records by userID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="taskCompleted"></param>
        /// <returns>List<FacilityTask></returns>
        List<FacilityTask> RetrieveFacilityTaskByUserID(int userID, bool taskCompleted = false);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// Approver: 
        /// 
        /// Method to retrieve FacilityTask Records by task name
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="taskName"></param>
        /// <param name="taskCompleted"></param>
        /// <returns>List<FacilityTask></returns>
        List<FacilityTask> RetrieveFacilityTaskByTaskName(string taskName, bool taskCompleted = false);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/16/2020
        /// Approver: Daulton Schiling, 4/16/2020
        /// 
        /// Method to Edit a facility task record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldFacilityTask"></param>
        /// <param name="newFacilityTask"></param>
        /// <returns>bool depending if record was successfully updated</returns>
        bool EditFacilityTask(FacilityTask oldFacilityTask, FacilityTask newFacilityTask);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/16/2020
        /// Approver: Daulton Schiling, 4/16/2020
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
        bool DeleteFacilityTask(int facilityTaskID);
    }
}

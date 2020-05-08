using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 2/6/2020
    /// Approver: Chuck Baxter, 2/7/2020
    /// Approver: Daulton Schilling, 2/7/2020
    /// 
    /// Interface for the FacilityMaintenanceManager class
    /// </summary>
    public interface IFacilityMaintenanceManager
    {
        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/6/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// Method to add a FacilityMaintenanceRecord
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityMaintenance"></param>
        /// <returns>true or false depending on if record was updated</returns>
        bool AddFacilityMaintenanceRecord(FacilityMaintenance facilityMaintenance);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/13/2020
        /// Approver: Ethan Murphy, 2/14/2020
        /// Approver: Daulton Chuck Baxter, 2/14/2020
        /// 
        /// Method to retrieve a facility maintenance record by id
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// <param name="facilityMaintenanceID"></param>
        /// <returns>FacilityMaintenance object</returns>
        FacilityMaintenance RetrieveFacilityMaintenanceByFacilityMaintenanceID(int facilityMaintenanceID, bool active);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/13/2020
        /// Approver: Ethan Murphy, 2/14/2020
        /// Approver: Daulton Chuck Baxter, 2/14/2020
        /// 
        /// Method to retrieve a facility maintenance record by user id
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="userID"></param>
        /// <returns>List<FacilityMaintenance> objects</returns>
        List<FacilityMaintenance> RetrieveFacilityMaintenanceByUserID(int userID, bool active);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/13/2020
        /// Approver: Ethan Murphy, 2/14/2020
        /// Approver: Daulton Chuck Baxter, 2/14/2020
        /// 
        /// Method to retrieve a facility maintenance record by maintenance name
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityMaintenanceName"></param>
        /// <returns>List<FacilityMaintenance></returns>
        List<FacilityMaintenance> RetrieveFacilityMaintenanceFacilityMaintenanceName(string facilityMaintenanceName, bool active);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/13/2020
        /// Approver: Ethan Murphy, 2/14/2020
        /// Approver: Daulton Chuck Baxter, 2/14/2020
        /// 
        /// Method to retrieve all facility maintenance records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>List<FacilityMaintenance> objects</returns>
        List<FacilityMaintenance> RetrieveAllFacilityMaintenance(bool active);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/14/2020
        /// Approver: Ethan Murphy, 2/21/2020
        /// Approver: Daulton Schilling, 2/21/2020
        /// 
        /// Method to Edit a facility maintenance record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldFacilityMaintenance"></param>
        /// <param name="newFacilityMaintenance"></param>
        /// <returns>1 or 0 int depending if record was updated</returns>
        bool EditFacilityMaintenance(FacilityMaintenance oldFacilityMaintenance, FacilityMaintenance newFacilityMaintenance);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/14/2020
        /// Approver: Ethan Murphy 3/6/2020
        /// Approver: 
        /// 
        /// Method to delete a facility maintenance record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="facilityMaintenanceID"></param>
        /// <returns>int 1 or 0 depending if record was deleted</returns>
        bool DeactivateFacilityMaintenance(int facilityMaintenanceID);
    }
}

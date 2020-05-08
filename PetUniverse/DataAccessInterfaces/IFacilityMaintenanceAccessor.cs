using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 2/6/2020
    /// Approver: Chuck Baxter, 2/7/2020
    /// Approver: Daulton Schilling, 2/7/2020
    /// 
    /// Interface for the FacilityMaintenanceAccessor
    /// </summary>
    public interface IFacilityMaintenanceAccessor
    {

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/6/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// Method to insert a FacilityMaintenanceRecord
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityMaintenance"></param>
        /// <returns>1 or 0 int depending if record was added</returns>
        int InsertFacilityMaintenanceRecord(FacilityMaintenance facilityMaintenance);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/13/2020
        /// Approver: Ethan Murphy, 2/14/2020
        /// Approver: Daulton Chuck Baxter, 2/14/2020
        /// 
        /// Method to select a facility maintenance record by id
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityMaintenanceID"></param>
        /// <returns>FacilityMaintenance object</returns>
        FacilityMaintenance SelectFacilityMaintenanceByFacilityMaintenanceID(int facilityMaintenanceID, bool active);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/13/2020
        /// Approver: Ethan Murphy, 2/14/2020
        /// Approver: Daulton Chuck Baxter, 2/14/2020
        /// 
        /// Method to select a facility maintenance record by user id
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="userID"></param>
        /// <returns>List<FacilityMaintenance> objects</returns>
        List<FacilityMaintenance> SelectFacilityMaintenanceByUserID(int userID, bool active);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/13/2020
        /// Approver: Ethan Murphy, 2/14/2020
        /// Approver: Daulton Chuck Baxter, 2/14/2020
        /// 
        /// Method to select a facility maintenance record by maintenance name
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityMaintenanceName"></param>
        /// <returns>List<FacilityMaintenance></returns>
        List<FacilityMaintenance> SelectFacilityMaintenanceFacilityMaintenanceName(string facilityMaintenanceName, bool active);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/13/2020
        /// Approver: Ethan Murphy, 2/14/2020
        /// Approver: Daulton Chuck Baxter, 2/14/2020
        /// 
        /// Method to select all facility maintenance records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>List<FacilityMaintenance> objects</returns>
        List<FacilityMaintenance> SelectAllFacilityMaintenance(bool active);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/14/2020
        /// Approver: Ethan Murphy, 2/14/2020
        /// Approver: Daulton Schilling, 2/21/2020
        /// 
        /// Method to update a facility maintenance record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldFacilityMaintenance"></param>
        /// <param name="newFacilityMaintenance"></param>
        /// <returns>1 or 0 int depending if record was updated</returns>
        int UpdateFacilityMaintenance(FacilityMaintenance oldFacilityMaintenance, FacilityMaintenance newFacilityMaintenance);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/14/2020
        /// Approver: Ethan Murphy 3/6/2020
        /// Approver: 
        /// 
        /// Method to deactivate a facility maintenance record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="facilityMaintenanceID"></param>
        /// <returns>int 1 or 0 depending if record was deleted</returns>
        int DeactivateFacilityMaintenance(int facilityMaintenanceID);
    }
}
using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 2/6/2020
    /// Approver: Ethan Murphy 3/6/2020
    /// 
    /// Interface for the FacilityInspectionAccessor
    /// </summary>
    public interface IFacilityInspectionAccessor
    {

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/28/2020
        /// Approver: Ethan Murphy 3/6/2020
        /// 
        /// Method to insert a FacilityInspection Record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspection"></param>
        /// <returns>1 or 0 int depending if record was added</returns>
        int InsertFacilityInspectionRecord(FacilityInspection facilityInspection);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/11/2020
        /// Approver: Ethan Murphy 3/13/2020
        /// 
        /// Method to select all FacilityInspection Records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="inspectionComplete"></param>
        /// <returns>List<FacilityMaintenance></returns>
        List<FacilityInspection> SelectAllFacilityInspection(bool inspectionComplete);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/11/2020
        /// Approver: Ethan Murphy 3/13/2020
        /// 
        /// Method to select FacilityInspection Records by id
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspectionID"></param>
        /// <param name="inspectionComplete"></param>
        /// <returns>List<FacilityMaintenance></returns>
        List<FacilityInspection> SelectFacilityInspectionByID(int facilityInspectionID, bool inspectionComplete);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/11/2020
        /// Approver: Ethan Murphy 3/13/2020
        /// 
        /// Method to select FacilityInspection Records by userID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="inspectionComplete"></param>
        /// <returns>List<FacilityMaintenance></returns>
        List<FacilityInspection> SelectFacilityInspectionByUserID(int userID, bool inspectionComplete);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/11/2020
        /// Approver: Ethan Murphy 3/13/2020
        /// 
        /// Method to select FacilityInspection Records by inspector name
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="inspectorName"></param>
        /// <param name="inspectionComplete"></param>
        /// <returns>List<FacilityMaintenance></returns>
        List<FacilityInspection> SelectFacilityInspectionByInspectorName(string inspectorName, bool inspectionComplete);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/13/2020
        /// Approver: Chuck Baxter, 3/18/2020
        /// 
        /// Method to update a facility inspection record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldFacilityInspection"></param>
        /// <param name="newFacilityInspection"></param>
        /// <returns>1 or 0 int depending if record was updated</returns>
        int UpdateFacilityInspection(FacilityInspection oldFacilityInspection, FacilityInspection newFacilityInspection);
    }
}
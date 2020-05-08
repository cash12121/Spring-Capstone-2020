using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 3/30/2020
    /// Approver: Ethan Murphy 4/3/2020
    /// 
    /// Interface for the FacilityInspectionItemAccessor
    /// </summary>
    public interface IFacilityInspectionItemAccessor
    {

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// 
        /// Method to insert a FacilityInspectionItem Record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspectionItem"></param>
        /// <returns>1 or 0 int depending if record was added</returns>
        int InsertFacilityInspectionItemRecord(FacilityInspectionItem facilityInspectionItem);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// 
        /// Method to select all FacilityInspectionItem Records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>List<FacilityMaintenance></returns>
        List<FacilityInspectionItem> SelectAllFacilityInspectionItem();

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// 
        /// Method to select FacilityInspectionItem Records by id
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspectionItemID"></param>
        /// <returns>List<FacilityMaintenance></returns>
        List<FacilityInspectionItem> SelectFacilityInspectionByItemID(int facilityInspectionItemID);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// 
        /// Method to select FacilityInspectionItem Records by userID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="userID"></param>
        /// <returns>List<FacilityMaintenance></returns>
        List<FacilityInspectionItem> SelectFacilityInspectionByUserID(int userID);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// 
        /// Method to select FacilityInspectionItem Records by Facility Inspection ID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspectionID"></param>
        /// <returns>List<FacilityMaintenance></returns>
        List<FacilityInspectionItem> SelectFacilityInspectionByFacilityInspectionID(int facilityInspectionID);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// 
        /// Method to select FacilityInspectionItem Records by item name
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="itemName"></param>
        /// <returns>List<FacilityMaintenance></returns>
        List<FacilityInspectionItem> SelectFacilityInspectionItemByItemName(string itemName);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// 
        /// Method to update a facility inspection item record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldFacilityInspectionItem"></param>
        /// <param name="newFacilityInspectionItem"></param>
        /// <returns>1 or 0 int depending if record was updated</returns>
        int UpdateFacilityInspectionItem(FacilityInspectionItem oldFacilityInspectionItem, FacilityInspectionItem newFacilityInspectionItem);
    }
}
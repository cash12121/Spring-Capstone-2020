using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 3/30/2020
    /// Approver: Ethan Murphy 4/3/2020
    /// Approver: 
    /// 
    /// Interface for the FacilityInspectionItemManager class
    /// </summary>
    public interface IFacilityInspectionItemManager
    {
        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// Approver: 
        /// 
        /// Method to add a FacilityInspectionItem Record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspection"></param>
        /// <returns>true or false depending on if record was updated</returns>
        bool AddFacilityInspectionItemRecord(FacilityInspectionItem facilityInspectionItem);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// Approver: 
        /// 
        /// Method to retrieve all FacilityInspectionItem Records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>List<FacilityMaintenance></returns>
        List<FacilityInspectionItem> RetrieveAllFacilityInspectionItems();

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// Approver: 
        /// 
        /// Method to retrieve FacilityInspection Records by id
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspectionItemID"></param>
        /// <returns>List<FacilityMaintenance></returns>
        List<FacilityInspectionItem> RetrieveFacilityInspectionItemByID(int facilityInspectionItemID);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// Approver: 
        /// 
        /// Method to retrieve FacilityInspectionItem Records by userID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="userID"></param>
        /// <returns>List<FacilityMaintenance></returns>
        List<FacilityInspectionItem> RetrieveFacilityInspectionItemByUserID(int userID);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// Approver: 
        /// 
        /// Method to retrieve FacilityInspectionItem Records by facilityInspectionID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspectionID"></param>
        /// <returns>List<FacilityMaintenance></returns>
        List<FacilityInspectionItem> RetrieveFacilityInspectionItemByfacilityInspectionID(int facilityInspectionID);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// Approver: 
        /// 
        /// Method to retrieve FacilityInspectionItem Records by item name
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="itemName"></param>
        /// <returns>List<FacilityMaintenance></returns>
        List<FacilityInspectionItem> RetrieveFacilityInspectionByItemName(string itemName);

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// 
        /// Method to Edit a facility inspection item record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldFacilityInspectionItem"></param>
        /// <param name="newFacilityInspectionItem"></param>
        /// <returns>bool depending if record was successfully updated</returns>
        bool EditFacilityInspectionItem(FacilityInspectionItem oldFacilityInspectionItem, FacilityInspectionItem newFacilityInspectionItem);
    }
}

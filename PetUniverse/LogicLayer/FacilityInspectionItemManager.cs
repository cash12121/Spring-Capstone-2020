using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 3/30/2020
    /// Approver: Ethan Murphy 4/3/2020
    /// Approver: 
    /// 
    /// Class to pass information from the Accessor to Presentation layer
    /// </summary>
    public class FacilityInspectionItemManager : IFacilityInspectionItemManager
    {
        public IFacilityInspectionItemAccessor _facilityInspectionItemAccessor;

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// Approver:
        /// 
        /// Constructor to instaniate instance variables
        /// </summary> 
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public FacilityInspectionItemManager()
        {
            _facilityInspectionItemAccessor = new FacilityInspectionItemAccessor();
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// Approver: 
        /// 
        /// Constructor to instaniate instance variables to the parameter for the fake accessor
        /// </summary> 
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspectionAccessor"></param>
        public FacilityInspectionItemManager(IFacilityInspectionItemAccessor facilityInspectionItemAccessor)
        {
            _facilityInspectionItemAccessor = facilityInspectionItemAccessor;
        }

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
        public bool AddFacilityInspectionItemRecord(FacilityInspectionItem facilityInspectionItem)
        {
            bool result = true;

            try
            {
                result = 1 == _facilityInspectionItemAccessor.InsertFacilityInspectionItemRecord(facilityInspectionItem);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Failed to create record!", ex);
            }

            return result;
        }

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
        public bool EditFacilityInspectionItem(FacilityInspectionItem oldFacilityInspectionItem, FacilityInspectionItem newFacilityInspectionItem)
        {
            bool result = false;

            try
            {
                result = 1 == _facilityInspectionItemAccessor.UpdateFacilityInspectionItem(oldFacilityInspectionItem, newFacilityInspectionItem);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Update Inspection Item Record Failed!", ex);
            }

            return result;
        }

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
        public List<FacilityInspectionItem> RetrieveAllFacilityInspectionItems()
        {
            try
            {
                return _facilityInspectionItemAccessor.SelectAllFacilityInspectionItem();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Failed to retrieve record!", ex);
            }
        }

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
        public List<FacilityInspectionItem> RetrieveFacilityInspectionByItemName(string itemName)
        {
            try
            {
                return _facilityInspectionItemAccessor.SelectFacilityInspectionItemByItemName(itemName);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Failed to retrieve record!", ex);
            }
        }

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
        public List<FacilityInspectionItem> RetrieveFacilityInspectionItemByfacilityInspectionID(int facilityInspectionID)
        {
            try
            {
                return _facilityInspectionItemAccessor.SelectFacilityInspectionByFacilityInspectionID(facilityInspectionID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Failed to retrieve record!", ex);
            }
        }

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
        public List<FacilityInspectionItem> RetrieveFacilityInspectionItemByID(int facilityInspectionItemID)
        {
            try
            {
                return _facilityInspectionItemAccessor.SelectFacilityInspectionByItemID(facilityInspectionItemID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Failed to retrieve record!", ex);
            }
        }

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
        public List<FacilityInspectionItem> RetrieveFacilityInspectionItemByUserID(int userID)
        {
            try
            {
                return _facilityInspectionItemAccessor.SelectFacilityInspectionByUserID(userID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Failed to retrieve record!", ex);
            }
        }
    }
}

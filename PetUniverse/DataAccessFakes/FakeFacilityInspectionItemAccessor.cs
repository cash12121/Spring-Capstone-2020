using DataAccessInterfaces;
using DataTransferObjects;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 3/30/2020
    /// Approver: Ethan Murphy, 4/3/2020
    /// 
    /// Class to test the logic layer unit tests
    /// </summary>
    public class FakeFacilityInspectionItemAccessor : IFacilityInspectionItemAccessor
    {

        private List<FacilityInspectionItem> facilityInspectionItems = new List<FacilityInspectionItem>()
        {
            new FacilityInspectionItem()
            {
                FacilityInspectionItemID = 1000000,
                ItemName = "Pen",
                UserID = 100000,
                FacilityInpectionID = 1000000,
                ItemDescription = "To fill out reports"
            },

            new FacilityInspectionItem()
            {
                FacilityInspectionItemID = 1000001,
                ItemName = "Pen",
                UserID = 100001,
                FacilityInpectionID = 1000001,
                ItemDescription = "To fill out reports"
            },

            new FacilityInspectionItem()
            {
                FacilityInspectionItemID = 1000002,
                ItemName = "Pen",
                UserID = 100001,
                FacilityInpectionID = 1000001,
                ItemDescription = "To fill out reports"
            }
        };

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy, 4/3/2020
        /// 
        /// Method to insert a fake FacilityInspectionItem Record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspectionItem"></param>
        /// <returns>1 or 0 int depending if record was added</returns>
        public int InsertFacilityInspectionItemRecord(FacilityInspectionItem facilityInspectionItem)
        {
            int result;
            if (facilityInspectionItem.FacilityInspectionItemID == 1000000 && facilityInspectionItem.ItemName == "Pen" && facilityInspectionItem.UserID == 100000
                && facilityInspectionItem.FacilityInpectionID == 1000000
                && facilityInspectionItem.ItemDescription == "To fill out reports")
            {
                result = 1;
            }
            else
            {
                result = 0;
            }
            return result;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy, 4/3/2020
        /// 
        /// Method to test select all FacilityInspectionItem Records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityInspectionItem> SelectAllFacilityInspectionItem()
        {
            return (from f in facilityInspectionItems
                    select f).ToList();
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy, 4/3/2020
        /// 
        /// Method to test select FacilityInspectionItem Records by Facility Inspection ID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspectionID"></param>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityInspectionItem> SelectFacilityInspectionByFacilityInspectionID(int facilityInspectionID)
        {
            return (from f in facilityInspectionItems
                    where f.FacilityInpectionID == facilityInspectionID
                    select f).ToList();
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy, 4/3/2020
        /// Approver: 
        /// 
        /// Method to test select FacilityInspectionItem Records by id
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspectionItemID"></param>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityInspectionItem> SelectFacilityInspectionByItemID(int facilityInspectionItemID)
        {
            return (from f in facilityInspectionItems
                    where f.FacilityInspectionItemID == facilityInspectionItemID
                    select f).ToList();
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy, 4/3/2020
        /// 
        /// Method to test select FacilityInspectionItem Records by userID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="userID"></param>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityInspectionItem> SelectFacilityInspectionByUserID(int userID)
        {
            return (from f in facilityInspectionItems
                    where f.UserID == userID
                    select f).ToList();
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy, 4/3/2020
        /// 
        /// Method to test select FacilityInspectionItem Records by item name
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="itemName"></param>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityInspectionItem> SelectFacilityInspectionItemByItemName(string itemName)
        {
            return (from f in facilityInspectionItems
                    where f.ItemName == itemName
                    select f).ToList();
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/30/2020
        /// Approver: Ethan Murphy, 4/3/2020
        /// 
        /// Method to test update a facility inspection item record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldFacilityInspectionItem"></param>
        /// <param name="newFacilityInspectionItem"></param>
        /// <returns>1 or 0 int depending if record was updated</returns>
        public int UpdateFacilityInspectionItem(FacilityInspectionItem oldFacilityInspectionItem, FacilityInspectionItem newFacilityInspectionItem)
        {
            int result;
            oldFacilityInspectionItem = newFacilityInspectionItem;

            if (oldFacilityInspectionItem.Equals(newFacilityInspectionItem))
            {
                result = 1;
            }
            else
            {
                result = 0;
            }
            return result;
        }
    }
}

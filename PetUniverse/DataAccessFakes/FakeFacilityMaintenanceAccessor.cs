using DataAccessInterfaces;
using DataTransferObjects;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 2/6/2020
    /// Approver: Chuck Baxter, 2/7/2020
    /// Approver: Daulton Schilling, 2/7/2020
    /// 
    /// Class to test the logic layer unit tests
    /// </summary>
    public class FakeFacilityMaintenanceAccessor : IFacilityMaintenanceAccessor
    {

        private FacilityMaintenance _facilityMaintenance;

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/6/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// Constructor to instantiate the test objects
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public FakeFacilityMaintenanceAccessor()
        {
            _facilityMaintenance = new FacilityMaintenance()
            {
                FacilityMaintenanceID = 1000000,
                UserID = 1000000,
                MaintenanceName = "Window",
                MaintenanceInterval = "5 hours",
                MaintenanceDescription = "Fix cracked window"
            };
        }

        private List<FacilityMaintenance> facilityMaintenances = new List<FacilityMaintenance>()
        {
            new FacilityMaintenance()
            {
                FacilityMaintenanceID = 1000000,
                UserID = 1000000,
                MaintenanceName = "Window",
                MaintenanceInterval = "5 hours",
                MaintenanceDescription = "Fix cracked window"
            },

            new FacilityMaintenance()
            {
                FacilityMaintenanceID = 1000001,
                UserID = 1000001,
                MaintenanceName = "door",
                MaintenanceInterval = "5 hours",
                MaintenanceDescription = "Fix cracked window"
            }
        };

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/6/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// Method to insert a fake FacilityMaintenanceRecord
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityMaintenance"></param>
        /// <returns>1 or 0 depending if the record matches the data</returns>
        public int InsertFacilityMaintenanceRecord(FacilityMaintenance facilityMaintenance)
        {
            int result = 0;
            if (facilityMaintenance.FacilityMaintenanceID == 1000000
                && facilityMaintenance.UserID == 1000000
                && facilityMaintenance.MaintenanceName == "Window"
                && facilityMaintenance.MaintenanceInterval == "5 hours"
                && facilityMaintenance.MaintenanceDescription == "Fix cracked window")
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
        /// <param name="facilityMaintenanceID"></param>
        /// <returns>FacilityMaintenance object</returns>
        public FacilityMaintenance SelectFacilityMaintenanceByFacilityMaintenanceID(int facilityMaintenanceID, bool active)
        {
            if (facilityMaintenanceID == _facilityMaintenance.FacilityMaintenanceID)
            {
                return _facilityMaintenance;
            }
            else
            {
                FacilityMaintenance facilityMaintenance = new FacilityMaintenance()
                {
                    UserID = 1000001,
                    MaintenanceName = "Window",
                    MaintenanceInterval = "5 hours",
                    MaintenanceDescription = "Fix cracked window"
                };
                return facilityMaintenance;
            }
        }

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
        public List<FacilityMaintenance> SelectFacilityMaintenanceByUserID(int userID, bool active)
        {
            return (from f in facilityMaintenances
                    where f.UserID == userID
                    select f).ToList();
        }

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
        public List<FacilityMaintenance> SelectFacilityMaintenanceFacilityMaintenanceName(string facilityMaintenanceName, bool active)
        {
            return (from f in facilityMaintenances
                    where f.MaintenanceName == facilityMaintenanceName
                    select f).ToList();
        }

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
        public List<FacilityMaintenance> SelectAllFacilityMaintenance(bool active)
        {
            return (from f in facilityMaintenances
                    select f).ToList();
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/14/2020
        /// Approver: Ethan Murphy, 2/21/2020
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
        /// <returns>1 or 0 int if they are equal</returns>
        public int UpdateFacilityMaintenance(FacilityMaintenance oldFacilityMaintenance, FacilityMaintenance newFacilityMaintenance)
        {
            int result = 0;
            oldFacilityMaintenance = newFacilityMaintenance;

            if (oldFacilityMaintenance.Equals(newFacilityMaintenance))
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
        public int DeactivateFacilityMaintenance(int facilityMaintenanceID)
        {
            int result = 0;

            if (facilityMaintenanceID == _facilityMaintenance.FacilityMaintenanceID)
            {
                _facilityMaintenance.Active = false;
                if (_facilityMaintenance.Active)
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
                return result;
            }
            else
            {
                return 0;
            }
        }
    }
}

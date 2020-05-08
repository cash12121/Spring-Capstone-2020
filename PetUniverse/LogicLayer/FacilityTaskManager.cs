using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 4/9/2020
    /// Approver: Ben Hanna, 4/10/20
    /// Approver: 
    /// 
    /// Class to pass information from the Accessor to Presentation layer
    /// </summary>
    public class FacilityTaskManager : IFacilityTaskManager
    {

        public IFacilityTaskAccessor _facilityTaskAccessor;

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// Approver:
        /// 
        /// Constructor to instaniate instance variables
        /// </summary> 
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public FacilityTaskManager()
        {
            _facilityTaskAccessor = new FacilityTaskAccessor();
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// Approver: 
        /// 
        /// Constructor to instaniate instance variables to the parameter for the fake accessor
        /// </summary> 
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityTaskAccessor"></param>
        public FacilityTaskManager(IFacilityTaskAccessor facilityTaskAccessor)
        {
            _facilityTaskAccessor = facilityTaskAccessor;
        }

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
        public bool AddFacilityTaskRecord(FacilityTask facilityTask)
        {
            bool result = true;

            try
            {
                result = 1 == _facilityTaskAccessor.InsertFacilityTaskRecord(facilityTask);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Failed to create record!", ex);
            }

            return result;
        }


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
        public List<FacilityTask> RetrieveAllFacilityTask(bool taskCompleted = false)
        {
            try
            {
                return _facilityTaskAccessor.SelectAllFacilityTasks(taskCompleted);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Failed to retrieve record!", ex);
            }
        }

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
        public List<FacilityTask> RetrieveFacilityTaskByID(int facilityTaskID, bool taskCompleted = false)
        {
            try
            {
                return _facilityTaskAccessor.SelectFacilityTaskByID(facilityTaskID, taskCompleted);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Failed to retrieve record!", ex);
            }
        }

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
        public List<FacilityTask> RetrieveFacilityTaskByTaskName(string taskName, bool taskCompleted = false)
        {
            try
            {
                return _facilityTaskAccessor.SelectFacilityTaskByTaskName(taskName, taskCompleted);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Failed to retrieve record!", ex);
            }
        }

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
        public List<FacilityTask> RetrieveFacilityTaskByUserID(int userID, bool taskCompleted = false)
        {
            try
            {
                return _facilityTaskAccessor.SelectFacilityTaskByUserID(userID, taskCompleted);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Failed to retrieve record!", ex);
            }
        }

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
        public bool EditFacilityTask(FacilityTask oldFacilityTask, FacilityTask newFacilityTask)
        {
            bool result = false;

            try
            {
                result = 1 == _facilityTaskAccessor.UpdateFacilityTask(oldFacilityTask, newFacilityTask);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Update Task Record Failed!", ex);
            }

            return result;
        }

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
        public bool DeleteFacilityTask(int facilityTaskID)
        {
            bool result = false;

            try
            {
                result = 1 == _facilityTaskAccessor.DeleteFacilityTask(facilityTaskID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Delete Task Record Failed!", ex);
            }

            return result;
        }
    }
}

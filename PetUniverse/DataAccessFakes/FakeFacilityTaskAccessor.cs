using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 4/9/2020
    /// Approver: Ben Hanna, 4/10/20
    /// Approver: 
    /// 
    /// Class to test the logic layer unit tests
    /// </summary>
    public class FakeFacilityTaskAccessor : IFacilityTaskAccessor
    {
        private List<FacilityTask> facilityTasks = new List<FacilityTask>()
        {
            new FacilityTask()
            {
                FacilityTaskID = 1000000,
                FacilityTaskName = "Clean",
                UserID = 100000,
                StartDate = new DateTime(2018, 7, 10, 7, 10, 24),
                CompletionDate = new DateTime(2018, 7, 10, 7, 10, 24),
                TaskCompleted = false
            },
            new FacilityTask()
            {
                FacilityTaskID = 1000001,
                FacilityTaskName = "Clean",
                UserID = 100000,
                StartDate = new DateTime(2018, 7, 10, 7, 10, 24),
                CompletionDate = new DateTime(2018, 7, 10, 7, 10, 24),
                TaskCompleted = false
            },
            new FacilityTask()
            {
                FacilityTaskID = 1000002,
                FacilityTaskName = "Clean",
                UserID = 100001,
                StartDate = new DateTime(2018, 7, 10, 7, 10, 24),
                CompletionDate = new DateTime(2018, 7, 10, 7, 10, 24),
                TaskCompleted = false
            }
        };

        FacilityTask facilityTask = new FacilityTask()
        {
            FacilityTaskID = 1000003,
            FacilityTaskName = "Clean",
            UserID = 100001,
            StartDate = new DateTime(2018, 7, 10, 7, 10, 24),
            CompletionDate = new DateTime(2018, 7, 10, 7, 10, 24),
            TaskCompleted = false
        };


        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// Approver: 
        /// 
        /// Method to insert a fake FacilityTask Record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityTask"></param>
        /// <returns>1 or 0 int depending if record was added</returns>
        public int InsertFacilityTaskRecord(FacilityTask facilityTask)
        {
            DateTime dateTime = new DateTime(2018, 7, 10, 7, 10, 24);
            if (facilityTask.FacilityTaskID == 1000000 && facilityTask.FacilityTaskName == "Clean" && facilityTask.UserID == 100000 && facilityTask.StartDate == dateTime
                && facilityTask.CompletionDate == dateTime
                && facilityTask.TaskCompleted == false)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// Approver: 
        /// 
        /// Method to select all fake FacilityTask Records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="taskCompleted"></param>
        /// <returns>List<FacilityTask></returns>
        public List<FacilityTask> SelectAllFacilityTasks(bool taskCompleted = false)
        {
            return (from f in facilityTasks
                    select f).ToList();

        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// Approver: 
        /// 
        /// Method to select fake FacilityTask Records by id
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityTaskID"></param>
        /// <param name="taskCompleted"></param>
        /// <returns>List<FacilityTask></returns>
        public List<FacilityTask> SelectFacilityTaskByID(int facilityTaskID, bool taskCompleted = false)
        {
            return (from f in facilityTasks
                    where f.FacilityTaskID == facilityTaskID
                    select f).ToList();
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// Approver: 
        /// 
        /// Method to select fake FacilityTask Records by task name
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityTaskName"></param>
        /// <param name="taskCompleted"></param>
        /// <returns>List<FacilityTask></returns>
        public List<FacilityTask> SelectFacilityTaskByTaskName(string facilityTaskName, bool taskCompleted = false)
        {
            return (from f in facilityTasks
                    where f.FacilityTaskName == facilityTaskName
                    select f).ToList();
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// Approver: 
        /// 
        /// Method to select fake FacilityTask Records by userID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="taskCompleted"></param>
        /// <returns>List<FacilityTask></returns>
        public List<FacilityTask> SelectFacilityTaskByUserID(int userID, bool taskCompleted = false)
        {
            return (from f in facilityTasks
                    where f.UserID == userID
                    select f).ToList();
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/16/2020
        /// Approver: Daulton Schiling, 4/16/2020
        /// 
        /// Method to update a fake facility task record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldFacilityTask"></param>
        /// <param name="newFacilityTask"></param>
        /// <returns>1 or 0 int depending if record was updated</returns>
        public int UpdateFacilityTask(FacilityTask oldFacilityTask, FacilityTask newFacilityTask)
        {
            oldFacilityTask = newFacilityTask;

            if (oldFacilityTask.Equals(newFacilityTask))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/16/2020
        /// Approver: Daulton Schiling, 4/16/2020
        /// Approver: 
        /// 
        /// Method to delete a fake facility task record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="facilityTaskID"></param>
        /// <returns>int 1 or 0 depending if record was deleted</returns>
        public int DeleteFacilityTask(int facilityTaskID)
        {
            if (facilityTaskID == facilityTask.FacilityTaskID)
            {
                facilityTask = null;
            }
            if (facilityTask == null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}

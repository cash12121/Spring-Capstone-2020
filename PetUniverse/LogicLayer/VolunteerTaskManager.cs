using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// NAME: Ethan Holmes
    /// DATE: 2/6/2020
    /// APPROVER: Josh Jackson, Timothy Licktieg
    /// 
    /// This Logic Layer class contains a logic layer access method CreateVolunteerTask()
    /// Which passes parameters to the DataAccessLayer via the interface.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: N/A
    /// UPDATE DATE: N/A
    /// CHANGE DESCRIPTION: N/A
    /// </remarks>
    public class VolunteerTaskManager : IVolunteerTaskManager
    {
        public VolunteerTaskManager(IVolunteerTaskAccessor volunteerTaskAccessor)
        {
            _volunteerTaskAccessor = volunteerTaskAccessor;
        }

        private IVolunteerTaskAccessor _volunteerTaskAccessor;
        public VolunteerTaskManager()
        {
            _volunteerTaskAccessor = new VolunteerTaskAccessor();
        }

        /// <summary>
        /// NAME: Ethan Holmes
        /// DATE: 2/6/2020
        /// APPROVER: Josh Jackson, Timothy Licktieg
        /// 
        /// This method will Insert a VolunteerTask Object into 
        /// the database.
        /// </summary>
        /// <param name="taskName"></param>
        /// <param name="taskType"></param>
        /// <param name="assignmentGroup"></param>
        /// <param name="taskDescription"></param>
        /// <param name="dueDate"></param>
        /// <returns></returns>
        public int CreateVolunteerTask(string taskName, string taskType, string assignmentGroup, string taskDescription, DateTime dueDate)
        {
            int rows = 0;

            try
            {

                rows = _volunteerTaskAccessor.CreateVolunteerTask(taskName, taskType, assignmentGroup, taskDescription, dueDate);

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Insert Failed.", ex);
            }
            return rows;
        }

        /// <summary>
        /// NAME: Ethan Holmes
        /// DATE: 2/6/2020
        /// APPROVER: Josh Jackson, Timothy Licktieg
        /// 
        /// This method will retrieve a VolunteerTask() object by TaskName.
        /// </summary>
        /// <param name="volunteerTaskName"></param>
        /// <returns></returns>
        public VolunteerTask GetVolunteerTaskByName(string volunteerTaskName)
        {
            VolunteerTask result = null;
            try
            {
                result = _volunteerTaskAccessor.GetVolunteerTaskByName(volunteerTaskName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// NAME: Ethan Holmes
        /// DATE: 2/6/2020
        /// APPROVER: Josh Jackson, Timothy Licktieg
        /// 
        /// This method will return a list of all VolunteerTaskVM's existing
        /// in the database.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATE DATE: N/A
        /// CHANGE DESCRIPTION: N/A
        /// </remarks>
        public List<VolunteerTaskVM> GetAllVolunteerTasks()
        {
            List<VolunteerTaskVM> results = new List<VolunteerTaskVM>();
            try
            {
                results = _volunteerTaskAccessor.GetAllVolunteerTasks();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("No Data", ex);

            }
            return results;
        }

        /// <summary>
        /// NAME: Ethan Holmes
        /// DATE: 2/6/2020
        /// APPROVER: Josh Jackson, Timothy Licktieg
        /// 
        /// Updates a task record.
        /// </summary>
        /// <param name="taskName"></param>
        /// <param name="taskType"></param>
        /// <param name="assignmentGroup"></param>
        /// <param name="dueDate"></param>
        /// <param name="taskDescription"></param>
        /// <returns></returns>
        public int UpdateVolunteerTask(string taskName, string taskType, string assignmentGroup, DateTime dueDate, string taskDescription)
        {
            int rows = 0;

            try
            {
                rows = _volunteerTaskAccessor.UpdateVolunteerTask(taskName, taskType, assignmentGroup, dueDate, taskDescription);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update failed.", ex);
            }
            return rows;
        }

        /// <summary>
        /// NAME: Ethan Holmes
        /// DATE: 2/6/2020
        /// APPROVER:
        /// 
        /// Deletes a task record
        /// </summary>
        /// <param name="taskName"></param>
        /// <returns></returns>
        public int DeleteVolunteerTask(string taskName)
        {
            int rows = 0;

            try
            {
                rows = _volunteerTaskAccessor.DeleteVolunteerTask(taskName);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Delete failed.", ex);
            }
            return rows;
        }
    }

}




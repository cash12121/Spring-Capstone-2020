using DataTransferObjects;
using System;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Ethan Holmes
    /// Created: 2/6/2020
    /// Approver: Josh Jackson, Timothy Licktieg
    /// 
    /// This interface outlines the interface for the Volunteer Task Accessor.
    /// </summary>
    public interface IVolunteerTaskAccessor
    {

        /// <summary>
        /// Creator: Ethan Holmes
        /// Created: 2/6/2020
        /// Approver: Josh Jackson, Timothy Licktieg
        /// 
        /// Create a Volunteer Task Interface definition.
        /// </summary>
        /// <remarks>
        /// Creator: N/A
        /// Created: N/A
        /// Approver: N/A
        /// </remarks>
        /// <param name="taskName"></param>
        /// <param name="taskType"></param>
        /// <param name="assignmentGroup"></param>
        /// <param name="taskDescription"></param>
        /// <param name="dueDate"></param>
        /// <returns></returns>
        int CreateVolunteerTask(string taskName, string taskType, string assignmentGroup, string taskDescription, DateTime dueDate);

        /// <summary>
        /// Creator: Ethan Holmes
        /// Created: 2/6/2020
        /// Approver: Josh Jackson, Timothy Licktieg
        /// 
        /// Retrieves a volunteer task by task name.
        /// </summary>
        /// <remarks>
        /// Creator: N/A
        /// Created: N/A
        /// Approver: N/A
        /// </remarks>
        /// <param name="volunteerTaskName"></param>
        /// <returns></returns>
        VolunteerTask GetVolunteerTaskByName(string volunteerTaskName);

        /// <summary>
        /// Creator: Ethan Holmes
        /// Created: 2/6/2020
        /// Approver: Josh Jackson, Timothy Licktieg
        /// 
        /// Retrieves all volunteer task objects.
        /// </summary>
        /// <remarks>
        /// Creator: N/A
        /// Created: N/A
        /// Approver: N/A
        /// </remarks>
        /// <returns></returns>
        List<VolunteerTaskVM> GetAllVolunteerTasks();

        /// <summary>
        /// Creator: Ethan Holmes
        /// Created: 2/6/2020
        /// Approver: Josh Jackson, Timothy Licktieg
        /// 
        /// Updates a volunteer task
        /// </summary>
        /// <remarks>
        /// Creator: N/A
        /// Created: N/A
        /// Approver: N/A
        /// </remarks>
        /// <param name="taskName"></param>
        /// <param name="taskType"></param>
        /// <param name="assignmentGroup"></param>
        /// <param name="dueDate"></param>
        /// <param name="taskDescription"></param>
        /// <returns></returns>
        int UpdateVolunteerTask(string taskName, string taskType, string assignmentGroup, DateTime dueDate, string taskDescription);

        /// <summary>
        /// Creator: Ethan Holmes
        /// Created: 2/6/2020
        /// Approver: Josh Jackson, Timothy Licktieg
        /// 
        /// Deletes a volunteer task 
        /// </summary>
        /// <remarks>
        /// Creator: N/A
        /// Created: N/A
        /// Approver: N/A
        /// </remarks>
        /// <param name="taskName"></param>
        /// <returns></returns>
        int DeleteVolunteerTask(string taskName);
    }
}
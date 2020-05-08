using DataTransferObjects;
using System;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// NAME: Ethan Holmes
    /// DATE: 2/6/2020
    /// 
    /// Interface outlines the requirements for the CreateVolunteerTask() class.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: N/A
    /// UPDATE DATE: N/A
    /// CHANGE DESCRIPTION: N/A
    /// </remarks>
    public interface IVolunteerTaskManager
    {
        /// <summary>
        /// NAME: Ethan Holmes
        /// DATE: 2/6/2020
        /// APPROVER: Josh Jackson, Timothy Licktieg
        /// 
        /// This method creates the volunteer task.
        /// </summary>
        /// <param name="taskName"></param>
        /// <param name="taskType"></param>
        /// <param name="assignmentGroup"></param>
        /// <param name="taskDescription"></param>
        /// <param name="dueDate"></param>
        /// <returns></returns>
        int CreateVolunteerTask(string taskName, string taskType, string assignmentGroup, string taskDescription, DateTime dueDate);

        /// <summary>
        /// NAME: Ethan Holmes
        /// DATE: 2/6/2020
        /// APPROVER: Josh Jackson, Timothy Licktieg
        /// 
        /// Gets volunteer task by taskname.
        /// </summary>
        /// <param name="volunteerTaskName"></param>
        /// <returns></returns>
        VolunteerTask GetVolunteerTaskByName(string volunteerTaskName);

        /// <summary>
        /// NAME: Ethan Holmes
        /// DATE: 2/6/2020
        /// 
        /// retreives all volunteer task objects.
        /// </summary>
        /// <returns></returns>
        List<VolunteerTaskVM> GetAllVolunteerTasks();

        /// <summary>
        /// NAME: Ethan Holmes
        /// DATE: 2/6/2020
        /// APPROVER: Josh Jackson, Timothy Licktieg
        /// 
        /// Interface definition for update a task record.
        /// </summary>
        /// <param name="taskName"></param>
        /// <param name="taskType"></param>
        /// <param name="assignmentGroup"></param>
        /// <param name="dueDate"></param>
        /// <param name="taskDescription"></param>
        /// <returns></returns>
        int UpdateVolunteerTask(string taskName, string taskType, string assignmentGroup, DateTime dueDate, string taskDescription);

        /// <summary>
        /// NAME: Ethan Holmes
        /// DATE: 2/6/2020
        /// APPROVER:
        /// 
        /// </summary>
        /// <param name="taskName"></param>
        /// <returns></returns>
        int DeleteVolunteerTask(string taskName);
    }
}

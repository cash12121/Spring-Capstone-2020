using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Ethan Holmes
    /// Created: 2/6/2020
    /// Approver: Josh Jackson, Timothy Licktieg
    /// 
    /// This DataAccessFakes 
    /// </summary>
    public class FakeVolunteerTaskAccessor : IVolunteerTaskAccessor
    {

        /// <summary>
        /// Creator: Ethan Holmes
        /// Created: 2/6/2020
        /// Approver: Josh Jackson, Timothy Licktieg
        /// 
        /// This DataAccessFakeVolunteerTaskAccessor provides
        /// fake test data to use in the Accessor Tests.
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Updater: N/A
        /// </remarks>
        public FakeVolunteerTaskAccessor()
        {
            VolunteerTask volunteerTask = new VolunteerTask()
            {
                TaskName = "FAKE NAME",
                TaskType = "TASK TYPE",
                AssignmentGroup = "FAKE GROPU",
                TaskDescription = "FAKE DESC",
                DueDate = DateTime.Parse("02/03/2020")

            };

            List<VolunteerTaskVM> volTasks = new List<VolunteerTaskVM>()
            {
                new VolunteerTaskVM()
                {
                    TaskName = "fake1",
                    TaskType = "faketype",
                    AssignmentGroup = "Fake group",
                    DueDate = "02/04/2020",
                    TaskDescription = "Fake desc"
                }
            };
        }

        /// <summary>
        /// Creator: Ethan Holmes
        /// Created: 2/6/2020
        /// Approver: Josh Jackson, Timothy Licktieg
        /// 
        /// This is the Fake Method for CreateVolunteerTask()
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Updater: N/A
        /// </remarks>
        /// <param name="assignmentGroup"></param>
        /// <param name="dueDate"></param>
        /// <param name="taskDescription"></param>
        /// <param name="taskName"></param>
        /// <param name="taskType"></param>
        public int CreateVolunteerTask(string taskName, string taskType, string assignmentGroup, string taskDescription, DateTime dueDate)
        {
            if (taskDescription != null && taskDescription != "")
            {
                return 1;
            }
            else if (dueDate != null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Creator: Ethan Holmes
        /// Created: 2/6/2020
        /// Approver: Josh Jackson, Timothy Licktieg
        /// 
        /// This is a Fake GetAllVolunteerTasks() method which
        /// returns a fake list of VolunteerTaskVM's
        /// </summary>
        ///
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Updater: N/A
        /// </remarks>
        public List<VolunteerTaskVM> GetAllVolunteerTasks()
        {
            List<VolunteerTaskVM> volTasks = new List<VolunteerTaskVM>()
            {
                new VolunteerTaskVM()
                {
                    TaskName = "fake1",
                    TaskType = "faketype",
                    AssignmentGroup = "Fake group",
                    DueDate = "02/04/2020",
                    TaskDescription = "Fake desc"
                }
            };
            return volTasks;
        }

        /// <summary>
        /// Creator: Ethan Holmes
        /// Created: 2/6/2020
        /// Approver: Josh Jackson, Timothy Licktieg
        /// 
        /// This is a fake method for GetVolunteerTaskByName() which returns a fake
        /// VolunteerTask() object.
        /// </summary>
        /// <param name="volunteerTaskName"></param>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Updater: N/A
        /// </remarks>
        public VolunteerTask GetVolunteerTaskByName(string volunteerTaskName)
        {
            VolunteerTask _fakeReturnTask = new VolunteerTask();

            if (volunteerTaskName != null && volunteerTaskName != "")
            {
                _fakeReturnTask.TaskName = "valid";
                _fakeReturnTask.TaskType = "valid";
                _fakeReturnTask.AssignmentGroup = "valid";
                _fakeReturnTask.DueDate = DateTime.Parse("01/01/2021");
                _fakeReturnTask.TaskDescription = "valid";

                return _fakeReturnTask;
            }
            else
            {
                _fakeReturnTask.TaskName = "invalid";
                _fakeReturnTask.TaskType = "invalid";
                _fakeReturnTask.AssignmentGroup = "invalid";
                _fakeReturnTask.DueDate = DateTime.Parse("01/01/2021");
                _fakeReturnTask.TaskDescription = "invalid";

                return _fakeReturnTask;
            }
        }

        /// <summary>
        /// Creator: Ethan Holmes
        /// Created: 2/6/2020
        /// Approver: Josh Jackson, Timothy Licktieg
        /// 
        /// testing the updating of a task record.
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Updater: N/A
        /// </remarks>
        /// <param name="taskName"></param>
        /// <param name="taskType"></param>
        /// <param name="assignmentGroup"></param>
        /// <param name="dueDate"></param>
        /// <param name="taskDescription"></param>
        /// <returns></returns>
        public int UpdateVolunteerTask(string taskName, string taskType, string assignmentGroup, DateTime dueDate, string taskDescription)
        {
            VolunteerTask _updateTask = new VolunteerTask()
            {
                TaskName = "dfdfd",
                TaskType = "idk",
                AssignmentGroup = "group2",
                DueDate = DateTime.Parse("02/01/2021"),
                TaskDescription = "Desc"
            };

            _updateTask.TaskName = taskName;
            _updateTask.TaskType = taskType;
            _updateTask.DueDate = dueDate;
            _updateTask.TaskDescription = taskDescription;

            if (_updateTask.TaskName == taskName)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Creator: Ethan Holmes
        /// Created: 2/6/2020
        /// Approver: Josh Jackson, Timothy Licktieg
        /// 
        /// testing the updating of a task record.
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Updater: N/A
        /// </remarks>
        /// <param name="taskName"></param>
        /// <returns></returns>
        public int DeleteVolunteerTask(string taskName)
        {
            VolunteerTask _deleteTask = new VolunteerTask()
            {
                TaskName = "DELETE_THIS",
                TaskType = "idk",
                AssignmentGroup = "group2",
                DueDate = DateTime.Parse("02/01/2021"),
                TaskDescription = "Desc"
            };

            if (_deleteTask.TaskName == taskName)
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

using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// NAME: Ethan Holmes
    /// DATE: 2/6/2020
    /// APPROVER: Josh Jackson, Timothy Licktieg
    /// 
    /// This DataAccessLayer Class implements the interface IVolunteerTaskAccessor
    /// and contains the methods used for accessing VolunteerTask data.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: N/A
    /// UPDATE DATE: N/A
    /// CHANGE DESCRIPTION: N/A
    /// </remarks>
    public class VolunteerTaskAccessor : IVolunteerTaskAccessor
    {




        /// <summary>
        /// NAME: Ethan Holmes
        /// DATE: 2/6/2020
        /// APPROVER: Josh Jackson, Timothy Licktieg
        /// 
        /// This data access class contains the class CreateVolunteerTask()
        /// Which will insert VolunteerTask data into the database.
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



            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_volunteer_task", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TaskName", taskName);
            cmd.Parameters.AddWithValue("@TaskType", taskType);
            cmd.Parameters.AddWithValue("@AssignmentGroup", assignmentGroup);
            cmd.Parameters.AddWithValue("@TaskDescription", taskDescription);
            cmd.Parameters.AddWithValue("@DueDate", dueDate);



            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }

        /// <summary>
        /// NAME: Ethan Holmes
        /// DATE: 2/6/2020
        /// APPROVER: Josh Jackson, Timothy Licktieg
        /// 
        /// This data access class contains the class GetVolunteerTaskByName()
        /// Which will return a VolunteerTask Object by name.
        /// </summary>
        /// <param name="volunteerTaskName"></param>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATE DATE: N/A
        /// CHANGE DESCRIPTION: N/A
        /// </remarks>
        public VolunteerTask GetVolunteerTaskByName(string volunteerTaskName)
        {
            VolunteerTask _volunteerTask = null;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_volunteer_task_by_name", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@taskName", volunteerTaskName);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    _volunteerTask = new VolunteerTask();

                    _volunteerTask.TaskName = volunteerTaskName;
                    _volunteerTask.TaskType = reader.GetString(2);
                    _volunteerTask.AssignmentGroup = reader.GetString(3);
                    _volunteerTask.DueDate = reader.GetDateTime(4);
                    _volunteerTask.TaskDescription = reader.GetString(5);
                }
                else
                {
                    throw new ApplicationException("Volunteer Task Not found.");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _volunteerTask;
        }

        /// <summary>
        /// NAME: Ethan Holmes
        /// DATE: 2/6/2020
        /// APPROVER: Josh Jackson, Timothy Licktieg
        /// 
        /// This GetAllVolunteerTasks() method will return all existing
        /// VolunteerTaskVM objects within the database or throw an error
        /// that no data exists.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATE DATE: N/A
        /// CHANGE DESCRIPTION: N/A
        /// </remarks>
        public List<VolunteerTaskVM> GetAllVolunteerTasks()
        {
            List<VolunteerTaskVM> vTasks = new List<VolunteerTaskVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_volunteer_tasks", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        vTasks.Add(new VolunteerTaskVM()
                        {
                            TaskName = reader.GetString(0),
                            TaskType = reader.GetString(1),
                            AssignmentGroup = reader.GetString(2),
                            DueDate = reader.GetDateTime(3).ToString(),
                            TaskDescription = reader.GetString(4)
                        });
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return vTasks;
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

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_volunteer_task_by_name", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TaskName", taskName);
            cmd.Parameters.AddWithValue("@TaskType", taskType);
            cmd.Parameters.AddWithValue("@AssignmentGroup", assignmentGroup);
            cmd.Parameters.AddWithValue("@DueDate", dueDate);
            cmd.Parameters.AddWithValue("@TaskDescription", taskDescription);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }

        /// <summary>
        /// NAME: Ethan Holmes
        /// DATE: 2/6/2020
        /// APPROVER:
        /// 
        /// Deletes a volunteer task record
        /// </summary>
        /// <param name="taskName"></param>
        /// <returns></returns>
        public int DeleteVolunteerTask(string taskName)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_delete_volunteer_task", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TaskName", taskName);


            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }

    }
}

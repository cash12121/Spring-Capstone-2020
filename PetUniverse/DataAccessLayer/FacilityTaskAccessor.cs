using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 4/9/2020
    /// Approver: Ben Hanna, 4/10/20
    /// Approver: 
    /// 
    /// Accessor class that interacts with the database through stored procedures
    /// </summary>
    public class FacilityTaskAccessor : IFacilityTaskAccessor
    {

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// Approver: 
        /// 
        /// Method to insert a FacilityTask Record
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
            int result = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_INSERT_facility_task", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FacilityTaskName", facilityTask.FacilityTaskName);

            cmd.Parameters.AddWithValue("@UserID", facilityTask.UserID);

            cmd.Parameters.AddWithValue("@StartDate", facilityTask.StartDate);

            cmd.Parameters.AddWithValue("@CompletionDate", facilityTask.CompletionDate);

            cmd.Parameters.AddWithValue("@FacilityTaskNotes", facilityTask.FacilityTaskNotes);

            try
            {
                conn.Open();

                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// Approver: 
        /// 
        /// Method to select all FacilityTask Records
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
            List<FacilityTask> facilityTasks = new List<FacilityTask>();

            // get a connection
            var conn = DBConnection.GetConnection();

            // create a sql command
            var cmd = new SqlCommand("sp_select_all_facility_tasks", conn);

            // set the command type
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TaskCompleted", taskCompleted);

            try
            {
                // open the connection
                conn.Open();

                // create a variable to read the results
                var reader = cmd.ExecuteReader();

                // sees if results were found
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var facilityTask = new FacilityTask();
                        facilityTask.FacilityTaskID = reader.GetInt32(0);
                        facilityTask.FacilityTaskName = reader.GetString(1);
                        facilityTask.UserID = reader.GetInt32(2);
                        facilityTask.StartDate = reader.GetDateTime(3);
                        facilityTask.CompletionDate = reader.GetDateTime(4);
                        facilityTask.FacilityTaskNotes = reader.GetString(5);
                        facilityTask.TaskCompleted = reader.GetBoolean(6);

                        facilityTasks.Add(facilityTask);

                    }
                }
                // closes the reader
                reader.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                // close connection
                conn.Close();
            }

            return facilityTasks;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// Approver: 
        /// 
        /// Method to select FacilityTask Records by id
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
            List<FacilityTask> facilityTasks = new List<FacilityTask>();

            // get a connection
            var conn = DBConnection.GetConnection();

            // create a sql command
            var cmd = new SqlCommand("sp_select_facility_task_by_id", conn);

            // set the command type
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FacilityTaskID", facilityTaskID);
            cmd.Parameters.AddWithValue("@TaskCompleted", taskCompleted);

            try
            {
                // open the connection
                conn.Open();

                // create a variable to read the results
                var reader = cmd.ExecuteReader();

                // sees if results were found
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var facilityTask = new FacilityTask();
                        facilityTask.FacilityTaskID = reader.GetInt32(0);
                        facilityTask.FacilityTaskName = reader.GetString(1);
                        facilityTask.UserID = reader.GetInt32(2);
                        facilityTask.StartDate = reader.GetDateTime(3);
                        facilityTask.CompletionDate = reader.GetDateTime(4);
                        facilityTask.FacilityTaskNotes = reader.GetString(5);
                        facilityTask.TaskCompleted = reader.GetBoolean(6);

                        facilityTasks.Add(facilityTask);

                    }
                }
                // closes the reader
                reader.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                // close connection
                conn.Close();
            }

            return facilityTasks;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// Approver: 
        /// 
        /// Method to select FacilityTask Records by task name
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
            List<FacilityTask> facilityTasks = new List<FacilityTask>();

            // get a connection
            var conn = DBConnection.GetConnection();

            // create a sql command
            var cmd = new SqlCommand("sp_select_facility_task_by_name", conn);

            // set the command type
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FacilityTaskName", facilityTaskName);
            cmd.Parameters.AddWithValue("@TaskCompleted", taskCompleted);

            try
            {
                // open the connection
                conn.Open();

                // create a variable to read the results
                var reader = cmd.ExecuteReader();

                // sees if results were found
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var facilityTask = new FacilityTask();
                        facilityTask.FacilityTaskID = reader.GetInt32(0);
                        facilityTask.FacilityTaskName = reader.GetString(1);
                        facilityTask.UserID = reader.GetInt32(2);
                        facilityTask.StartDate = reader.GetDateTime(3);
                        facilityTask.CompletionDate = reader.GetDateTime(4);
                        facilityTask.FacilityTaskNotes = reader.GetString(5);
                        facilityTask.TaskCompleted = reader.GetBoolean(6);

                        facilityTasks.Add(facilityTask);

                    }
                }
                // closes the reader
                reader.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                // close connection
                conn.Close();
            }

            return facilityTasks;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/9/2020
        /// Approver: Ben Hanna, 4/10/20
        /// Approver: 
        /// 
        /// Method to select FacilityTask Records by userID
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
            List<FacilityTask> facilityTasks = new List<FacilityTask>();

            // get a connection
            var conn = DBConnection.GetConnection();

            // create a sql command
            var cmd = new SqlCommand("sp_select_facility_task_by_user_id", conn);

            // set the command type
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserID", userID);
            cmd.Parameters.AddWithValue("@TaskCompleted", taskCompleted);

            try
            {
                // open the connection
                conn.Open();

                // create a variable to read the results
                var reader = cmd.ExecuteReader();

                // sees if results were found
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var facilityTask = new FacilityTask();
                        facilityTask.FacilityTaskID = reader.GetInt32(0);
                        facilityTask.FacilityTaskName = reader.GetString(1);
                        facilityTask.UserID = reader.GetInt32(2);
                        facilityTask.StartDate = reader.GetDateTime(3);
                        facilityTask.CompletionDate = reader.GetDateTime(4);
                        facilityTask.FacilityTaskNotes = reader.GetString(5);
                        facilityTask.TaskCompleted = reader.GetBoolean(6);

                        facilityTasks.Add(facilityTask);

                    }
                }
                // closes the reader
                reader.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                // close connection
                conn.Close();
            }

            return facilityTasks;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/16/2020
        /// Approver: Daulton Schiling, 4/16/2020
        /// 
        /// Method to update a facility task record
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
            int result = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_facility_task", conn);

            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@FacilityTaskID", oldFacilityTask.FacilityTaskID);


            cmd.Parameters.AddWithValue("@OldFacilityTaskName", oldFacilityTask.FacilityTaskName);

            cmd.Parameters.AddWithValue("@OldUserID", oldFacilityTask.UserID);

            cmd.Parameters.AddWithValue("@OldStartDate", oldFacilityTask.StartDate);

            cmd.Parameters.AddWithValue("@OldCompletionDate", oldFacilityTask.CompletionDate);

            cmd.Parameters.AddWithValue("@OldFacilityTaskNotes", oldFacilityTask.FacilityTaskNotes);

            cmd.Parameters.AddWithValue("@OldTaskCompleted", oldFacilityTask.TaskCompleted);

            cmd.Parameters.AddWithValue("@NewFacilityTaskName", newFacilityTask.FacilityTaskName);

            cmd.Parameters.AddWithValue("@NewUserID", newFacilityTask.UserID);

            cmd.Parameters.AddWithValue("@NewStartDate", newFacilityTask.StartDate);

            cmd.Parameters.AddWithValue("@NewCompletionDate", newFacilityTask.CompletionDate);

            cmd.Parameters.AddWithValue("@NewFacilityTaskNotes", newFacilityTask.FacilityTaskNotes);

            cmd.Parameters.AddWithValue("@NewTaskCompleted", newFacilityTask.TaskCompleted);

            try
            {
                conn.Open();

                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/16/2020
        /// Approver: Daulton Schiling, 4/16/2020
        /// Approver: 
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
        public int DeleteFacilityTask(int facilityTaskID)
        {
            int result = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_delete_facility_task", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FacilityTaskID", facilityTaskID);

            try
            {
                conn.Open();

                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }
    }
}

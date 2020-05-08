using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 2/18/2020
    /// Approver: Carl Davis, 2/7/2020
    /// Approver: Chuck Baxter, 2/7/2020
    /// 
    /// Animal Activity Accessor class
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated:
    /// Update:
    /// </remarks>
    public class AnimalActivityAccessor : IAnimalActivityAccessor
    {

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Gets animal activity records by activity type
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="activity">Activity type ID</param>
        /// <returns>List of animal activity records</returns>
        public List<AnimalActivity> GetAnimalActivityRecordsByActivityType(string activity)
        {
            List<AnimalActivity> activities = new List<AnimalActivity>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_animal_activites_by_activity_type", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ActivityTypeID", activity);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    activities.Add(new AnimalActivity()
                    {
                        AnimalActivityId = reader.GetInt32(0),
                        AnimalID = reader.GetInt32(1),
                        UserID = reader.GetInt32(2),
                        AnimalName = reader.GetString(3),
                        AnimalActivityTypeID = reader.GetString(4),
                        ActivityDateTime = reader.GetDateTime(5),
                        Description = reader.IsDBNull(6) ? "" : reader.GetString(6)
                    });
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

            return activities;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Gets animal activity types
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>List of animal activity types</returns>
        public List<AnimalActivityType> GetAnimalActivityTypes()
        {
            List<AnimalActivityType> activityTypes = new List<AnimalActivityType>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_animal_activity_types", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    activityTypes.Add(new AnimalActivityType()
                    {
                        ActivityTypeId = reader.GetString(0),
                        Description = reader.GetString(1)
                    });
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

            return activityTypes;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Inserts an animal activity record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalActivity">The record to insert</param>
        /// <returns>List of animal activity types</returns>
        public int InsertAnimalActivityRecord(AnimalActivity animalActivity)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_animal_activity", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AnimalID", animalActivity.AnimalID);
            cmd.Parameters.AddWithValue("@UserID", animalActivity.UserID);
            cmd.Parameters.AddWithValue("@AnimalActivityTypeID", animalActivity.AnimalActivityTypeID);
            cmd.Parameters.AddWithValue("@ActivityDateTime", animalActivity.ActivityDateTime);
            cmd.Parameters.AddWithValue("@Description", animalActivity.Description);

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
        /// Creator: Ethan Murphy
        /// Created: 4/6/2020
        /// Approver: Chuck Baxter 4/7/2020
        /// 
        /// Updates an existing animal activity record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldAnimalActivity">The existing record</param>
        /// <param name="newAnimalActivity">The updated record</param>
        /// <returns>Update successful</returns>
        public int UpdateAnimalActivityRecord(AnimalActivity oldAnimalActivity, AnimalActivity newAnimalActivity)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_animal_activity", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AnimalActivityID", oldAnimalActivity.AnimalActivityId);
            cmd.Parameters.AddWithValue("@AnimalID", oldAnimalActivity.AnimalID);
            cmd.Parameters.AddWithValue("@UserID", oldAnimalActivity.UserID);
            cmd.Parameters.AddWithValue("@AnimalActivityTypeID", oldAnimalActivity.AnimalActivityTypeID);
            cmd.Parameters.AddWithValue("@ActivityDateTime", oldAnimalActivity.ActivityDateTime);
            cmd.Parameters.AddWithValue("@Description", oldAnimalActivity.Description);

            cmd.Parameters.AddWithValue("@NewAnimalID", newAnimalActivity.AnimalID);
            cmd.Parameters.AddWithValue("@NewUserID", newAnimalActivity.UserID);
            cmd.Parameters.AddWithValue("@NewAnimalActivityTypeID", newAnimalActivity.AnimalActivityTypeID);
            cmd.Parameters.AddWithValue("@NewActivityDateTime", newAnimalActivity.ActivityDateTime);
            cmd.Parameters.AddWithValue("@NewDescription", newAnimalActivity.Description);

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
        /// Creator: Chuck Baxter
        /// Created: 4/16/2020
        /// Approver: Ethan Murphy, 4/16/2020
        /// 
        /// Creates a new animal activity type record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalActivityType"></param>
        /// <returns></returns>
        public int InsertAnimalActivityType(AnimalActivityType animalActivityType)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_AnimalActivityType", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AnimalActivityTypeID", animalActivityType.ActivityTypeId);
            cmd.Parameters.AddWithValue("@ActivityNotes", animalActivityType.Description);

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
        /// Creator: Chuck Baxter
        /// Created: 4/16/2020
        /// Approver: Ethan Murphy, 4/16/2020
        /// 
        /// Updates an existing animal activity type record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldAnimalActivityType"></param>
        /// <param name="newAnimalActivityType"></param>
        /// <returns></returns>
        public int UpdateAnimalActivityType(AnimalActivityType oldAnimalActivityType, AnimalActivityType newAnimalActivityType)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_animal_activity_type", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OldAnimalActivityTypeID", oldAnimalActivityType.ActivityTypeId);

            cmd.Parameters.AddWithValue("@NewAnimalActivityTypeID", newAnimalActivityType.ActivityTypeId);
            cmd.Parameters.AddWithValue("@NewActivityNotes", newAnimalActivityType.Description);

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
        /// Creator: Chuck Baxter
        /// Created: 4/16/2020
        /// Approver: Ethan Murphy, 4/16/2020
        /// 
        /// Deletes an existing animal activity type record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalActivityType"></param>
        /// <returns></returns>
        public int DeleteAnimalActivityType(AnimalActivityType animalActivityType)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_delete_animal_activity_type", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AnimalActivityTypeID", animalActivityType.ActivityTypeId);

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
        /// Creator: Ethan Murphy
        /// Created: 4/25/2020
        /// Approver: Chuck Baxter 4/27/2020
        /// 
        /// Deletes an existing animal activity record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalActivity">Record to be deleted</param>
        /// <returns>Number of records deleted</returns>
        public int DeleteAnimalActivityRecord(AnimalActivity animalActivity)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_delete_animal_activity_record", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AnimalActivityID", animalActivity.AnimalActivityId);
            cmd.Parameters.AddWithValue("@AnimalID", animalActivity.AnimalID);
            cmd.Parameters.AddWithValue("@UserID", animalActivity.UserID);
            cmd.Parameters.AddWithValue("@AnimalActivityTypeID", animalActivity.AnimalActivityTypeID);
            cmd.Parameters.AddWithValue("@ActivityDateTime", animalActivity.ActivityDateTime);
            cmd.Parameters.AddWithValue("@Description", animalActivity.Description);

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
using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 2/28/2020
    /// Approver: Ethan Murphy 3/6/2020
    /// Approver: 
    /// 
    /// Accessor class thsat interacts with the database through stored procedures
    /// </summary>
    public class FacilityInspectionAccessor : IFacilityInspectionAccessor
    {
        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/28/2020
        /// Approver: Ethan Murphy 3/6/2020
        /// Approver: 
        /// 
        /// Method to insert a FacilityInspection Record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspection"></param>
        /// <returns>1 or 0 int depending if record was added</returns>
        public int InsertFacilityInspectionRecord(FacilityInspection facilityInspection)
        {
            int result = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_facility_inspection", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters["@UserID"].Value = facilityInspection.UserID;

            cmd.Parameters.Add("@InspectorName", SqlDbType.NVarChar);
            cmd.Parameters["@InspectorName"].Value = facilityInspection.InspectorName;

            cmd.Parameters.Add("@InspectionDate", SqlDbType.Date);
            cmd.Parameters["@InspectionDate"].Value = facilityInspection.InspectionDate;

            cmd.Parameters.Add("@InspectionDescription", SqlDbType.NVarChar);
            cmd.Parameters["@InspectionDescription"].Value = facilityInspection.InspectionDescription;

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
        /// Created: 3/11/2020
        /// Approver: Ethan Murphy 3/13/2020
        /// Approver: 
        /// 
        /// Method to select all FacilityInspection Records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="inspectionComplete"></param>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityInspection> SelectAllFacilityInspection(bool inspectionComplete)
        {
            List<FacilityInspection> facilityInspections = new List<FacilityInspection>();

            // get a connection
            var conn = DBConnection.GetConnection();

            // create a sql command
            var cmd = new SqlCommand("sp_select_all_facility_inspection", conn);

            // set the command type
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@InspectionCompleted", inspectionComplete);

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
                        var facilityInspection = new FacilityInspection();
                        facilityInspection.FacilityInspectionID = reader.GetInt32(0);
                        facilityInspection.UserID = reader.GetInt32(1);
                        facilityInspection.InspectorName = reader.GetString(2);
                        facilityInspection.InspectionDate = reader.GetDateTime(3);
                        facilityInspection.InspectionDescription = reader.GetString(4);
                        facilityInspection.InspectionCompleted = reader.GetBoolean(5);

                        facilityInspections.Add(facilityInspection);

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

            return facilityInspections;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/11/2020
        /// Approver: Ethan Murphy 3/13/2020
        /// Approver: 
        /// 
        /// Method to select FacilityInspection Records by id
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityInspectionID"></param>
        /// <param name="inspectionComplete"></param>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityInspection> SelectFacilityInspectionByID(int facilityInspectionID, bool inspectionComplete)
        {
            List<FacilityInspection> facilityInspections = new List<FacilityInspection>();

            // get a connection
            var conn = DBConnection.GetConnection();

            // create a sql command
            var cmd = new SqlCommand("sp_select_facility_inspection_by_id", conn);

            // set the command type
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FacilityInspectionID", facilityInspectionID);
            cmd.Parameters.AddWithValue("@InspectionCompleted", inspectionComplete);

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
                        var facilityInspection = new FacilityInspection();
                        facilityInspection.FacilityInspectionID = reader.GetInt32(0);
                        facilityInspection.UserID = reader.GetInt32(1);
                        facilityInspection.InspectorName = reader.GetString(2);
                        facilityInspection.InspectionDate = reader.GetDateTime(3);
                        facilityInspection.InspectionDescription = reader.GetString(4);
                        facilityInspection.InspectionCompleted = reader.GetBoolean(5);

                        facilityInspections.Add(facilityInspection);

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

            return facilityInspections;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/11/2020
        /// Approver: Ethan Murphy 3/13/2020
        /// Approver: 
        /// 
        /// Method to select FacilityInspection Records by inspector name
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="inspectorName"></param>
        /// <param name="inspectionComplete"></param>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityInspection> SelectFacilityInspectionByInspectorName(string inspectorName, bool inspectionComplete)
        {
            List<FacilityInspection> facilityInspections = new List<FacilityInspection>();

            // get a connection
            var conn = DBConnection.GetConnection();

            // create a sql command
            var cmd = new SqlCommand("sp_select_facility_inspection_by_inspector_name", conn);

            // set the command type
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@InspectorName", inspectorName);
            cmd.Parameters.AddWithValue("@InspectionCompleted", inspectionComplete);

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
                        var facilityInspection = new FacilityInspection();
                        facilityInspection.FacilityInspectionID = reader.GetInt32(0);
                        facilityInspection.UserID = reader.GetInt32(1);
                        facilityInspection.InspectorName = reader.GetString(2);
                        facilityInspection.InspectionDate = reader.GetDateTime(3);
                        facilityInspection.InspectionDescription = reader.GetString(4);
                        facilityInspection.InspectionCompleted = reader.GetBoolean(5);

                        facilityInspections.Add(facilityInspection);

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

            return facilityInspections;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/11/2020
        /// Approver: Ethan Murphy 3/13/2020
        /// Approver: 
        /// 
        /// Method to select FacilityInspection Records by userID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="inspectionComplete"></param>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityInspection> SelectFacilityInspectionByUserID(int userID, bool inspectionComplete)
        {
            List<FacilityInspection> facilityInspections = new List<FacilityInspection>();

            // get a connection
            var conn = DBConnection.GetConnection();

            // create a sql command
            var cmd = new SqlCommand("sp_select_facility_inspection_by_user_id", conn);

            // set the command type
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserID", userID);
            cmd.Parameters.AddWithValue("@InspectionCompleted", inspectionComplete);

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
                        var facilityInspection = new FacilityInspection();
                        facilityInspection.FacilityInspectionID = reader.GetInt32(0);
                        facilityInspection.UserID = reader.GetInt32(1);
                        facilityInspection.InspectorName = reader.GetString(2);
                        facilityInspection.InspectionDate = reader.GetDateTime(3);
                        facilityInspection.InspectionDescription = reader.GetString(4);
                        facilityInspection.InspectionCompleted = reader.GetBoolean(5);

                        facilityInspections.Add(facilityInspection);

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

            return facilityInspections;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/13/2020
        /// Approver: Chuck Baxter, 3/18/2020
        /// 
        /// Method to update a facility inspection record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldFacilityInspection"></param>
        /// <param name="newFacilityInspection"></param>
        /// <returns>1 or 0 int depending if record was updated</returns>
        public int UpdateFacilityInspection(FacilityInspection oldFacilityInspection, FacilityInspection newFacilityInspection)
        {
            int result = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_facility_inspection", conn);

            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@FacilityInspectionID", oldFacilityInspection.FacilityInspectionID);


            cmd.Parameters.AddWithValue("@OldUserID", oldFacilityInspection.UserID);

            cmd.Parameters.AddWithValue("@OldInspectorName", oldFacilityInspection.InspectorName);

            cmd.Parameters.AddWithValue("@OldInspectionDate", oldFacilityInspection.InspectionDate);

            cmd.Parameters.AddWithValue("@OldInspectionDescription", oldFacilityInspection.InspectionDescription);

            cmd.Parameters.AddWithValue("@OldInspectionComplete", oldFacilityInspection.InspectionCompleted);

            cmd.Parameters.AddWithValue("@NewUserID", newFacilityInspection.UserID);

            cmd.Parameters.AddWithValue("@NewInspectorName", newFacilityInspection.InspectorName);

            cmd.Parameters.AddWithValue("@NewInspectionDate", newFacilityInspection.InspectionDate);

            cmd.Parameters.AddWithValue("@NewInspectionDescription", newFacilityInspection.InspectionDescription);

            cmd.Parameters.AddWithValue("@NewInspectionComplete", newFacilityInspection.InspectionCompleted);

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

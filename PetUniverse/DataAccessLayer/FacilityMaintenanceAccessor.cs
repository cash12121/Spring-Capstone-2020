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
    /// Created: 2/6/2020
    /// Approver: Chuck Baxter, 2/7/2020
    /// Approver: Daulton Schilling, 2/7/2020
    /// 
    /// Accessor class thsat interacts with the database through stored procedures
    /// </summary>
    public class FacilityMaintenanceAccessor : IFacilityMaintenanceAccessor
    {


        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/6/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// Method to insert a FacilityMaintenanceRecord
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityMaintenance"></param>
        /// <returns>1 or 0 int depending if record was added</returns>
        public int InsertFacilityMaintenanceRecord(FacilityMaintenance facilityMaintenance)
        {
            int result = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_facility_maintenance", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters["@UserID"].Value = facilityMaintenance.UserID;

            cmd.Parameters.Add("@MaintenanceName", SqlDbType.NVarChar);
            cmd.Parameters["@MaintenanceName"].Value = facilityMaintenance.MaintenanceName;

            cmd.Parameters.Add("@MaintenanceInterval", SqlDbType.NVarChar);
            cmd.Parameters["@MaintenanceInterval"].Value = facilityMaintenance.MaintenanceInterval;

            cmd.Parameters.Add("@MaintenanceDescription", SqlDbType.NVarChar);
            cmd.Parameters["@MaintenanceDescription"].Value = facilityMaintenance.MaintenanceDescription;

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
        /// Created: 2/13/2020
        /// Approver: Ethan Murphy, 2/14/2020
        /// Approver: Daulton Chuck Baxter, 2/14/2020
        /// 
        /// Method to select all facility maintenance records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>List<FacilityMaintenance> objects</returns>
        public List<FacilityMaintenance> SelectAllFacilityMaintenance(bool active)
        {
            List<FacilityMaintenance> facilityMaintenances = new List<FacilityMaintenance>();

            // get a connection
            var conn = DBConnection.GetConnection();

            // create a sql command
            var cmd = new SqlCommand("sp_select_all_facility_maintenance", conn);

            // set the command type
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Active", SqlDbType.Bit);
            cmd.Parameters["@Active"].Value = active;

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
                        var facilityMaintenance = new FacilityMaintenance();
                        facilityMaintenance.FacilityMaintenanceID = reader.GetInt32(0);
                        facilityMaintenance.UserID = reader.GetInt32(1);
                        facilityMaintenance.MaintenanceName = reader.GetString(2);
                        facilityMaintenance.MaintenanceInterval = reader.GetString(3);
                        facilityMaintenance.MaintenanceDescription = reader.GetString(4);
                        facilityMaintenance.Active = reader.GetBoolean(5);

                        facilityMaintenances.Add(facilityMaintenance);

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

            return facilityMaintenances;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/13/2020
        /// Approver: Ethan Murphy, 2/14/2020
        /// Approver: Daulton Chuck Baxter, 2/14/2020
        /// 
        /// Method to select a facility maintenance record by id
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityMaintenanceID"></param>
        /// <returns>FacilityMaintenance object</returns>
        public FacilityMaintenance SelectFacilityMaintenanceByFacilityMaintenanceID(int facilityMaintenanceID, bool active)
        {

            FacilityMaintenance facilityMaintenance = new FacilityMaintenance();

            // get a connection
            var conn = DBConnection.GetConnection();

            // create a sql command
            var cmd = new SqlCommand("sp_select_facility_maintenance_by_id", conn);

            // set the command type
            cmd.CommandType = CommandType.StoredProcedure;

            // set the parameters for the sp
            cmd.Parameters.Add("@FacilityMaintenanceID", SqlDbType.Int);
            cmd.Parameters["@FacilityMaintenanceID"].Value = facilityMaintenanceID;
            cmd.Parameters.Add("@Active", SqlDbType.Bit);
            cmd.Parameters["@Active"].Value = active;

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

                        facilityMaintenance.FacilityMaintenanceID = reader.GetInt32(0);
                        facilityMaintenance.UserID = reader.GetInt32(1);
                        facilityMaintenance.MaintenanceName = reader.GetString(2);
                        facilityMaintenance.MaintenanceInterval = reader.GetString(3);
                        facilityMaintenance.MaintenanceDescription = reader.GetString(4);
                        facilityMaintenance.Active = reader.GetBoolean(5);
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

            return facilityMaintenance;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/13/2020
        /// Approver: Ethan Murphy, 2/14/2020
        /// Approver: Daulton Chuck Baxter, 2/14/2020
        /// 
        /// Method to select a facility maintenance record by user id
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="userID"></param>
        /// <returns>List<FacilityMaintenance> objects</returns>
        public List<FacilityMaintenance> SelectFacilityMaintenanceByUserID(int userID, bool active)
        {

            List<FacilityMaintenance> facilityMaintenances = new List<FacilityMaintenance>();

            // get a connection
            var conn = DBConnection.GetConnection();

            // create a sql command
            var cmd = new SqlCommand("sp_select_facility_maintenance_by_user_id", conn);

            // set the command type
            cmd.CommandType = CommandType.StoredProcedure;

            // set the parameters for the sp
            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters["@UserID"].Value = userID;
            cmd.Parameters.Add("@Active", SqlDbType.Bit);
            cmd.Parameters["@Active"].Value = active;

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
                        var facilityMaintenance = new FacilityMaintenance();
                        facilityMaintenance.FacilityMaintenanceID = reader.GetInt32(0);
                        facilityMaintenance.UserID = reader.GetInt32(1);
                        facilityMaintenance.MaintenanceName = reader.GetString(2);
                        facilityMaintenance.MaintenanceInterval = reader.GetString(3);
                        facilityMaintenance.MaintenanceDescription = reader.GetString(4);
                        facilityMaintenance.Active = reader.GetBoolean(5);
                        facilityMaintenances.Add(facilityMaintenance);

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
            return facilityMaintenances;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/13/2020
        /// Approver: Ethan Murphy, 2/14/2020
        /// Approver: Daulton Chuck Baxter, 2/14/2020
        /// 
        /// Method to select a facility maintenance record by maintenance name
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="facilityMaintenanceName"></param>
        /// <returns>List<FacilityMaintenance></returns>
        public List<FacilityMaintenance> SelectFacilityMaintenanceFacilityMaintenanceName(string facilityMaintenanceName, bool active)
        {
            List<FacilityMaintenance> facilityMaintenances = new List<FacilityMaintenance>();

            // get a connection
            var conn = DBConnection.GetConnection();

            // create a sql command
            var cmd = new SqlCommand("sp_select_facility_maintenance_by_name", conn);

            // set the command type
            cmd.CommandType = CommandType.StoredProcedure;

            // set the parameters for the sp
            cmd.Parameters.Add("@MaintenanceName", SqlDbType.NVarChar);
            cmd.Parameters["@MaintenanceName"].Value = facilityMaintenanceName;
            cmd.Parameters.Add("@Active", SqlDbType.Bit);
            cmd.Parameters["@Active"].Value = active;

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
                        var facilityMaintenance = new FacilityMaintenance();
                        facilityMaintenance.FacilityMaintenanceID = reader.GetInt32(0);
                        facilityMaintenance.UserID = reader.GetInt32(1);
                        facilityMaintenance.MaintenanceName = reader.GetString(2);
                        facilityMaintenance.MaintenanceInterval = reader.GetString(3);
                        facilityMaintenance.MaintenanceDescription = reader.GetString(4);
                        facilityMaintenance.Active = reader.GetBoolean(5);
                        facilityMaintenances.Add(facilityMaintenance);

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

            return facilityMaintenances;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/14/2020
        /// Approver: Ethan Murphy, 2/14/2020
        /// Approver: Daulton Schilling, 2/21/2020
        /// 
        /// Method to update a facility maintenance record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldFacilityMaintenance"></param>
        /// <param name="newFacilityMaintenance"></param>
        /// <returns>1 or 0 int depending if record was updated</returns>
        public int UpdateFacilityMaintenance(FacilityMaintenance oldFacilityMaintenance, FacilityMaintenance newFacilityMaintenance)
        {
            int result = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_facility_maintenance", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@FacilityMaintenanceID", SqlDbType.Int);
            cmd.Parameters["@FacilityMaintenanceID"].Value = oldFacilityMaintenance.FacilityMaintenanceID;

            cmd.Parameters.Add("@OldUserID", SqlDbType.Int);
            cmd.Parameters["@OldUserID"].Value = oldFacilityMaintenance.UserID;

            cmd.Parameters.Add("@OldMaintenanceName", SqlDbType.NVarChar);
            cmd.Parameters["@OldMaintenanceName"].Value = oldFacilityMaintenance.MaintenanceName;

            cmd.Parameters.Add("@OldMaintenanceInterval", SqlDbType.NVarChar);
            cmd.Parameters["@OldMaintenanceInterval"].Value = oldFacilityMaintenance.MaintenanceInterval;

            cmd.Parameters.Add("@OldMaintenanceDescription", SqlDbType.NVarChar);
            cmd.Parameters["@OldMaintenanceDescription"].Value = oldFacilityMaintenance.MaintenanceDescription;

            cmd.Parameters.Add("@NewUserID", SqlDbType.Int);
            cmd.Parameters["@NewUserID"].Value = newFacilityMaintenance.UserID;

            cmd.Parameters.Add("@NewMaintenanceName", SqlDbType.NVarChar);
            cmd.Parameters["@NewMaintenanceName"].Value = newFacilityMaintenance.MaintenanceName;

            cmd.Parameters.Add("@NewMaintenanceInterval", SqlDbType.NVarChar);
            cmd.Parameters["@NewMaintenanceInterval"].Value = newFacilityMaintenance.MaintenanceInterval;

            cmd.Parameters.Add("@NewMaintenanceDescription", SqlDbType.NVarChar);
            cmd.Parameters["@NewMaintenanceDescription"].Value = newFacilityMaintenance.MaintenanceDescription;

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
        /// Created: 2/14/2020
        /// Approver: Ethan Murphy 3/6/2020
        /// Approver: 
        /// 
        /// Method to deactivate a facility maintenance record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="facilityMaintenanceID"></param>
        /// <returns>int 1 or 0 depending if record was deleted</returns>
        public int DeactivateFacilityMaintenance(int facilityMaintenanceID)
        {
            int result = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_deactivate_facility_maintenance", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@FacilityMaintenanceID", SqlDbType.Int);
            cmd.Parameters["@FacilityMaintenanceID"].Value = facilityMaintenanceID;

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

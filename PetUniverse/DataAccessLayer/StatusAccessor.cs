using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Austin Gee
    /// Created: 3/11/2020
    /// Approver: Michael Thompson
    /// 
    /// class for status data access methods
    /// </summary>
    public class StatusAccessor : IStatusAccessor
    {
        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/11/2020
        /// Approver: Michael Thompson
        /// 
        /// data access method for inserting a status into the database
        /// </summary>
        /// <remarks>
        /// Updated BY: N/A
        /// Updated N/A
        /// Update: N/A
        /// </remarks>
        public int InsertStatus(string StatusID)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_status", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StatusID", StatusID);
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
        /// Creator: Austin Gee
        /// Created: 3/11/2020
        /// Approver: Michael Thompson
        /// 
        /// Selects all the statuses from the database
        /// </summary>
        /// <remarks>
        /// Updated BY: N/A
        /// Updated N/A
        /// Update: N/A
        /// </remarks>
        public List<string> SelectAllStatuses()
        {
            List<string> statuses = new List<string>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_statuses", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string status = reader.GetString(0);
                        statuses.Add(status);
                    }

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
            return statuses;
        }
    }
}

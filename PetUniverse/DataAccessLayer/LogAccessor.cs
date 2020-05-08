using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Zach Behrensmeyer
    /// Created: 2/11/2020
    /// Approver: Steven Cardona
    /// 
    /// This class accesses Log data 
    /// </summary>
    public class LogAccessor : ILogAccessor
    {


        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/11/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is used to get logs related to login and logouts
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>List of Logs</returns>
        public List<LogItem> GetLoginLogout()
        {
            List<LogItem> Logs = new List<LogItem>();

            //Get a connection
            var conn = DBConnection.GetConnection();

            //Call the sproc
            var cmd = new SqlCommand("sp_get_login_logout_logs", conn);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        LogItem log = new LogItem();
                        log.LogID = reader.GetInt32(0);
                        log.LogDate = reader.GetDateTime(1);
                        log.LogLevel = reader.GetString(2);
                        log.Message = reader.GetString(3);
                        Logs.Add(log);
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
            return Logs;
        }
    }
}

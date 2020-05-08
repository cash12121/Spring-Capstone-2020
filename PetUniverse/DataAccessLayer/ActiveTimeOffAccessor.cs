using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/4/15
///  APPROVER: Lane Sandburg
///  
///  Accessor Class for Availability
/// </summary>
namespace DataAccessLayer
{
    public class ActiveTimeOffAccessor : IActiveTimeOffAccessor
    {
        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/15
        ///  APPROVER: Lane Sandburg
        ///  
        ///  This method retrieves all Users' ActiveTimeOff
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public List<ActiveTimeOff> SelectAllUsersActiveTimeOff()
        {
            List<ActiveTimeOff> activeTimeOffs = new List<ActiveTimeOff>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_users_activeTimeOff", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ActiveTimeOff activeTimeOff = new ActiveTimeOff();

                        activeTimeOff.UserID = reader.GetInt32(0);
                        activeTimeOff.StartDate = reader.GetDateTime(1);
                        activeTimeOff.EndDate = reader.GetDateTime(2);

                        activeTimeOffs.Add(activeTimeOff);
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

            return activeTimeOffs;
        }
    }
}

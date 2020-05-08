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
    /// Creator: Jordan Lindo
    /// Created: 4/8/2020
    /// Approver: Chase Schulte
    /// 
    /// Class for schedule hours accessor
    /// </summary>
    public class ScheduleHoursAccessor : IScheduleHoursAccessor
    {

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/23/2020
        /// Approver: Chase Schulte
        /// 
        /// Add a list of schedule hours.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="scheduleID"></param>
        /// <param name="employees"></param>
        /// <returns></returns>
        public int InsertAllScheduleHours(int scheduleID, List<PUUserVMHours> employees)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_schedulehours", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ScheduleID", SqlDbType.Int);
            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters.Add("@HoursFirstWeek", SqlDbType.Decimal);
            cmd.Parameters.Add("@HoursSecondWeek", SqlDbType.Decimal);


            try
            {
                conn.Open();
                foreach (PUUserVMHours employee in employees)
                {
                    cmd.Parameters["@ScheduleID"].Value = scheduleID;
                    cmd.Parameters["@UserID"].Value = employee.PUUserID;
                    cmd.Parameters["@HoursFirstWeek"].Value = employee.Week1Hours;
                    cmd.Parameters["@HoursSecondWeek"].Value = employee.Week2Hours;
                    cmd.ExecuteNonQuery();
                    rows++;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }
    }
}

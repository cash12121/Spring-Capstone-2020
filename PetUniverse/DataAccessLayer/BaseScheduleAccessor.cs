using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Jordan Lindo
    /// Created: 3/15/2020
    /// Approver: 
    /// 
    /// BaseSchedule Accessor class for TSQL.
    /// </summary>
    public class BaseScheduleAccessor : IBaseScheduleAccessor
    {
        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/15/2020
        /// Approver: Chase Schulte
        /// 
        /// Inserts a new base schedule. 
        /// sp_insert_baseschedule deactivates old base schedules if the insert is
        /// successfull.
        /// </summary>
        /// <remarks>
        /// Updater: Jordan Lindo
        /// Updated: 4/1/2020
        /// Update: fixed the cast for the return from cmd
        /// 
        /// </remarks>
        /// <param name="baseScheduleVM"></param>
        /// <returns></returns>
        public int InsertBaseScheduleVM(BaseScheduleVM baseScheduleVM)
        {
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_baseschedule", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CreatingUserID", baseScheduleVM.CreatingUserID);
            cmd.Parameters.AddWithValue("@CreationDate", baseScheduleVM.CreationDate);

            try
            {
                conn.Open();
                var result = cmd.ExecuteScalar();
                baseScheduleVM.BaseScheduleID = int.Parse(result.ToString());

                foreach (var line in baseScheduleVM.BaseScheduleLines)
                {
                    var cmd2 = new SqlCommand("sp_insert_basescheduleline", conn);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@ERoleID", line.ERoleID);
                    cmd2.Parameters.AddWithValue("@BaseScheduleID", baseScheduleVM.BaseScheduleID);
                    cmd2.Parameters.AddWithValue("@ShiftTimeID", line.ShiftTimeID);
                    cmd2.Parameters.AddWithValue("@Count", line.Count);
                    cmd2.ExecuteNonQuery();
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
            return baseScheduleVM.BaseScheduleID;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/15/2020
        /// Approver: Chase Schulte
        /// 
        /// Retrieves the active base schedule.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <returns></returns>
        public BaseScheduleVM RetrieveActiveBaseSchedule()
        {
            BaseScheduleVM baseScheduleVM = null;


            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_active_baseschedule", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    baseScheduleVM = new BaseScheduleVM()
                    {
                        BaseScheduleID = reader.GetInt32(0),
                        CreatingUserID = reader.GetInt32(1),
                        CreationDate = reader.GetDateTime(2),
                        Active = reader.GetBoolean(3)
                    };

                }
                if (null != baseScheduleVM)
                {
                    baseScheduleVM.BaseScheduleLines =
                        RetrieveBaseScheduleLinesByBaseScheduleID(baseScheduleVM.BaseScheduleID);
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


            return baseScheduleVM;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/15/2020
        /// Approver: Chase Schulte
        /// 
        /// Retrieves all base schedules.
        /// </summary>
        /// <remarks>
        /// Updater: Chase Schulte
        /// Updated: 03/19/2020
        /// Update: added new List baseSchedule() to fix exception "{"Object reference not set to an instance of an object."}"
        /// 
        /// </remarks>
        /// <returns></returns>
        public List<BaseSchedule> RetrieveAllBaseSchedules()
        {
            List<BaseSchedule> baseSchedules = new List<BaseSchedule>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_baseschedules", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        baseSchedules.Add(new BaseScheduleVM()
                        {
                            BaseScheduleID = reader.GetInt32(0),
                            CreatingUserID = reader.GetInt32(1),
                            CreationDate = reader.GetDateTime(2),
                            Active = reader.GetBoolean(3)
                        });

                    }
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
            return baseSchedules;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/15/2020
        /// Approver: Chase Schulte
        /// 
        /// Retrieves all base schedule lines by baseScheduleID.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public List<BaseScheduleLine> RetrieveBaseScheduleLinesByBaseScheduleID(int baseScheduleID)
        {
            var conn = DBConnection.GetConnection();
            List<BaseScheduleLine> lines = new List<BaseScheduleLine>();
            var cmd =
                new SqlCommand("sp_select_baseschedulelines_by_basescheduleid", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BaseScheduleID", baseScheduleID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lines.Add(new BaseScheduleLine
                        {
                            ERoleID = reader.GetString(0),
                            ShiftTimeID = reader.GetInt32(1),
                            Count = reader.GetInt32(2),
                            DepartmentID = reader.GetString(3),
                            BaseScheduleID = baseScheduleID
                        });
                    }
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
            return lines;
        }
    }
}

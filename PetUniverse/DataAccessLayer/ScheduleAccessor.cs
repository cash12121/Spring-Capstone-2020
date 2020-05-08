using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ScheduleAccessor : IScheduleAccessor
    {

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/14/2020
        /// Approver: Chase Schulte
        /// 
        /// Retruns a list of available employees.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="date"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        public List<PUUserVMAvailability> GetListOfAvailableEmployees(DateTime date, BaseScheduleLine line)
        {
            List<PUUserVMAvailability> users = new List<PUUserVMAvailability>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_available_users_new_schedule", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DayOfWeek", date.ToString("dddd"));
            cmd.Parameters.AddWithValue("@ADate", date);
            cmd.Parameters.AddWithValue("@ERoleID", line.ERoleID);
            cmd.Parameters.AddWithValue("@ShiftTimeID", line.ShiftTimeID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        users.Add(new PUUserVMAvailability
                        {
                            PUUserID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Email = reader.GetString(3),
                            Availability = new EmployeeAvailability
                            {
                                StartTime = reader.GetString(4),
                                EndTime = reader.GetString(5),
                                DayOfWeek = date.ToString("dddd")
                            }
                        });
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
            return users;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/9/2020
        /// Approver: Chase Schulte
        /// 
        /// Inserts a Schedule including ScheduleLines.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="schedule"></param>
        /// <returns></returns>
        public int InsertSchedule(ScheduleVM schedule)
        {
            int scheduleID = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_schedule", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StartDate", schedule.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", schedule.EndDate);
            cmd.Parameters.AddWithValue("@CreatingUserID", schedule.CreatingUserID);

            try
            {
                conn.Open();
                var result = cmd.ExecuteScalar();
                scheduleID = int.Parse(result.ToString());
                foreach (Shift shift in schedule.ScheduleLines)
                {
                    var cmd2 = new SqlCommand("sp_insert_shift", conn);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@ShiftTimeID", shift.ShiftTimeID);
                    cmd2.Parameters.AddWithValue("@ScheduleID", scheduleID);
                    cmd2.Parameters.Add("@Date", SqlDbType.Date).Value = shift.ShiftDate.ToString("yyyy-MM-dd");
                    cmd2.Parameters.AddWithValue("@UserID", shift.EmployeeID);
                    cmd2.Parameters.AddWithValue("@ERoleID", shift.RoleID);
                    cmd2.ExecuteScalar();
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

            return scheduleID;
        }



        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/12/2020
        /// Approver: Chase Schulte
        /// 
        /// Retrieves a list of schedule vms.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<ScheduleVM> SelectAllSchedules(bool active)
        {
            List<ScheduleVM> schedules = new List<ScheduleVM>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_schedules_by_active", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Active", active);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ScheduleVM scheduleVM = new ScheduleVM
                        {
                            ScheduleID = reader.GetInt32(0),
                            StartDate = reader.GetDateTime(1),
                            EndDate = reader.GetDateTime(2),
                            CreatingUserID = reader.GetInt32(3),
                            CreatorName = reader.GetString(4)+" "+reader.GetString(5),
                            Active = active,
                            ScheduleLines = new List<ShiftUserVM>()
                        };

                        schedules.Add(scheduleVM);
                    }
                }
                reader.Close();
                foreach (ScheduleVM schedule in schedules)
                {


                    var cmd2 = new SqlCommand("sp_select_shifts_by_scheduleid", conn);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@ScheduleID", schedule.ScheduleID);
                    var reader2 = cmd2.ExecuteReader();
                    if (reader2.HasRows)
                    {
                        while (reader2.Read())
                        {
                            schedule.ScheduleLines.Add(new ShiftUserVM
                            {
                                ScheduleID = schedule.ScheduleID,
                                ShiftID = reader2.GetInt32(0),
                                ShiftTimeID = reader2.GetInt32(1),
                                ShiftDate = reader2.GetDateTime(2),
                                EmployeeID = reader2.GetInt32(3),
                                RoleID = reader2.GetString(4),
                                EmployeeName = reader2.GetString(5)+", "+reader2.GetString(6),
                                ShiftStart = reader2.GetString(7),
                                ShiftEnd = reader2.GetString(8)
                            });
                        }
                    }
                    reader2.Close();
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

            return schedules;
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/28/2020
        /// Approver: Kaleb Bachert 
        /// 
        /// Retrieves a count of active schedules.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <returns></returns>
        public int GetCountOfActiveSchedules()
        {
            int result = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_count_of_active_schedules",conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                result = (Int32)cmd.ExecuteScalar();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 4/28/2020
        /// Approver: Kaleb Bachert 
        /// 
        /// Deactiveates a schedule.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public int DeactivateSchedule(int scheduleID)
        {
            int result = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_deactivate_schedule", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ScheduleID", scheduleID);

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}

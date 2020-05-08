using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

/// <summary>
///  CREATOR: Kaleb Bachert
///  CREATED: 2020/4/1
///  APPROVER: Lane Sandburg
///  
///  Accessor Class for Requests
/// </summary>
namespace DataAccessLayer
{
    public class ShiftAccessor : IShiftAccessor
    {
        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/1
        ///  APPROVER: Lane Sandburg
        ///  
        ///  This method retrieves all scheduled Shifts with ShiftTimes from the Database by user.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public List<ShiftVM> SelectShiftsByUser(int userID)
        {
            List<ShiftVM> shiftVMs = new List<ShiftVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_shifts_by_user", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("UserID", userID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ShiftVM shiftVM = new ShiftVM();

                        shiftVM.ShiftID = reader.GetInt32(0);
                        shiftVM.ShiftTimeID = reader.GetInt32(1);
                        shiftVM.Date = reader.GetDateTime(3).ToShortDateString();
                        shiftVM.EmployeeWorking = reader.GetInt32(4);
                        shiftVM.Department = reader.GetString(6);
                        shiftVM.StartTime = reader.GetString(7);
                        shiftVM.EndTime = reader.GetString(8);

                        shiftVMs.Add(shiftVM);
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

            return shiftVMs;
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/15
        ///  APPROVER: Lane Sandburg
        ///  
        ///  This method retrieves all scheduled Shifts with ShiftTimes from the Database on the specified day.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="date"></param>
        public List<ShiftVM> SelectShiftsByDay(DateTime date)
        {
            List<ShiftVM> shiftVMs = new List<ShiftVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_shifts_by_day", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Date", date.ToShortDateString());

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ShiftVM shiftVM = new ShiftVM();

                        shiftVM.EmployeeWorking = reader.GetInt32(0);
                        shiftVM.Date = reader.GetDateTime(1).ToShortDateString();
                        shiftVM.StartTime = reader.GetString(2);
                        shiftVM.EndTime = reader.GetString(3);

                        shiftVMs.Add(shiftVM);
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

            return shiftVMs;
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/15
        ///  APPROVER: Lane Sandburg
        ///  
        ///  This method retrieves a User's scheduled hours for a given Schedule
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="dateInSchedule"></param>
        public ScheduleWithHoursWorked SelectScheduleHoursByUserAndDate(int userID, DateTime dateInSchedule)
        {
            ScheduleWithHoursWorked scheduleHours = new ScheduleWithHoursWorked();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_schedule_hours_by_user_and_date", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("UserID", userID);
            cmd.Parameters.AddWithValue("DateInSchedule", dateInSchedule);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        scheduleHours.ScheduleID = reader.GetInt32(0);
                        scheduleHours.ScheduleStartDate = reader.GetDateTime(1);
                        scheduleHours.ScheduleEndDate = reader.GetDateTime(2);
                        scheduleHours.FirstWeekHours = Convert.ToDouble(reader.GetDecimal(3));
                        scheduleHours.SecondWeekHours = Convert.ToDouble(reader.GetDecimal(4));
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

            return scheduleHours;
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/16
        ///  APPROVER: Lane Sandburg
        ///  
        ///  This method updates the Employee Working for a given shift
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="shiftID"></param>
        /// <param name="newUserWorking"></param>
        /// <param name="oldUserWorking"></param>
        public int UpdateShiftUserWorking(int shiftID, int newUserWorking, int oldUserWorking)
        {
            int rowsAffected = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_shift_user_working", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ShiftID", shiftID);
            cmd.Parameters.AddWithValue("NewUserWorking", newUserWorking);
            cmd.Parameters.AddWithValue("OldUserWorking", oldUserWorking);

            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rowsAffected;
        }

        /// <summary>
        ///  CREATOR: Kaleb Bachert
        ///  CREATED: 2020/4/16
        ///  APPROVER: Lane Sandburg
        ///  
        ///  This method updates the hours worked for an Employee on a given week of a given schedule by a given amount
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="userID"></param>
        /// <param name="scheduleID"></param>
        /// <param name="weekNumber"></param>
        /// <param name="changeAmount"></param>
        public int UpdateEmployeeHoursWorked(int userID, int scheduleID, int weekNumber, double changeAmount)
        {
            int rowsAffected = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_employee_hours_worked", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("UserID", userID);
            cmd.Parameters.AddWithValue("ScheduleID", scheduleID);
            cmd.Parameters.AddWithValue("WeekNumber", weekNumber);
            cmd.Parameters.AddWithValue("ChangeAmount", changeAmount);

            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rowsAffected;
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/05
        /// Approver: Kaleb Bachert
        /// 
        /// get a collection of shift details by user ID
        /// </summary>
        ///
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        public List<ShiftDetailsVM> SelectAllShiftsDetailsByUserID(int userID)
        {
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_shift_details_by_user_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("UserID", userID);
            List<ShiftDetailsVM> shifts = new List<ShiftDetailsVM>();
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        shifts.Add(new ShiftDetailsVM()
                        {
                            ShiftID = reader.GetInt32(0),
                            ShiftTimeID = reader.GetInt32(1),
                            ScheduleID = reader.GetInt32(2),
                            ShiftDate = reader.GetDateTime(3),
                            EmployeeID = reader.GetInt32(4),
                            RoleID = reader.GetString(5),
                            ShiftTimeDeptID = reader.GetString(6),
                            ShiftStartTime = reader.GetString(7),
                            ShiftEndTime = reader.GetString(8),
                            ShiftScheduleStartDate = reader.GetDateTime(9),
                            ShiftScheduleEndDate = reader.GetDateTime(10),
                            ShiftPUUserFirstName = reader.GetString(11),
                            ShiftPUUserLastName = reader.GetString(12),
                        });
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
            return shifts;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/04/05
        /// Approver: Kaleb Bachert
        /// 
        /// get a collection of shift details by ID
        /// </summary>
        ///
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="shiftID"></param>
        /// <returns></returns>
        public ShiftDetailsVM SelectShiftDetailsByID(int shiftID)
        {
            var conn = DBConnection.GetConnection();
            var cmd1 = new SqlCommand("sp_select_shift_details_by_id", conn);
            var cmd2 = new SqlCommand("sp_select_availabilties_by_employee_id", conn);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@ShiftID", shiftID);


            ShiftDetailsVM shift = new ShiftDetailsVM();
            try
            {
                conn.Open();
                var reader = cmd1.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    shift.ShiftID = reader.GetInt32(0);
                    shift.ShiftTimeID = reader.GetInt32(1);
                    shift.ScheduleID = reader.GetInt32(2);
                    shift.ShiftDate = reader.GetDateTime(3);
                    shift.EmployeeID = reader.GetInt32(4);
                    shift.RoleID = reader.GetString(5);
                    shift.ShiftTimeDeptID = reader.GetString(6);
                    shift.ShiftStartTime = reader.GetString(7);
                    shift.ShiftEndTime = reader.GetString(8);
                    shift.ShiftScheduleStartDate = reader.GetDateTime(9);
                    shift.ShiftScheduleEndDate = reader.GetDateTime(10);
                    shift.ShiftPUUserFirstName = reader.GetString(11);
                    shift.ShiftPUUserLastName = reader.GetString(12);
                }
                reader.Close();
                cmd2.Parameters.AddWithValue("UserID", shift.EmployeeID);
                reader = cmd2.ExecuteReader();
                shift.ShiftAvailabilities = new List<EmployeeAvailability>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        shift.ShiftAvailabilities.Add(new EmployeeAvailability()
                        {
                            StartTime = reader.GetString(2),
                            EndTime = reader.GetString(3),
                            DayOfWeek = reader.GetString(4)

                        });
                    }
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return shift;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 4/26/2020
        /// Approver: Kaleb Bachert
        /// 
        /// method to get all shifts by user, dept, and schedule id
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="scheduleID"></param>
        /// <param name="departmentID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<ShiftUserVM> SelectShiftsByScheduleAndDepartmentID(int scheduleID, string departmentID)
        {
            List<ShiftUserVM> shiftVMs = new List<ShiftUserVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_supervisor_shifts_by_schedule_department_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ScheduleID", scheduleID);
            cmd.Parameters.AddWithValue("DepartmentID", departmentID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ShiftUserVM shiftVM = new ShiftUserVM();

                        shiftVM.DateString = reader.GetDateTime(0).ToShortDateString();
                        shiftVM.EmployeeName = reader.GetString(1) + " " + reader.GetString(2);
                        shiftVM.ShiftStart = reader.GetString(3);
                        shiftVM.ShiftEnd = reader.GetString(4);
                        shiftVM.RoleID = reader.GetString(5);
                        shiftVM.ScheduleID = reader.GetInt32(6);
                        shiftVM.EmployeeID = reader.GetInt32(7);
                        shiftVM.ShiftID = reader.GetInt32(8);

                        shiftVMs.Add(shiftVM);
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

            return shiftVMs;
        }
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 4/26/2020
        /// Approver: Kaleb Bachert
        /// 
        /// method for getting shifts by schedule, department ids and date
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="scheduleID"></param>
        /// <param name="departmentID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<ShiftUserVM> SelectShiftsByScheduleAndDepartmentIDWithDate(int scheduleID, string departmentID, DateTime date)
        {
            List<ShiftUserVM> shiftVMs = new List<ShiftUserVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_supervisor_shifts_by_schedule_department_id_with_date", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ScheduleID", scheduleID);
            cmd.Parameters.AddWithValue("DepartmentID", departmentID);
            cmd.Parameters.AddWithValue("Date", date);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ShiftUserVM shiftVM = new ShiftUserVM();

                        shiftVM.DateString = reader.GetDateTime(0).ToShortDateString();
                        shiftVM.EmployeeName = reader.GetString(1) + " " + reader.GetString(2);
                        shiftVM.ShiftStart = reader.GetString(3);
                        shiftVM.ShiftEnd = reader.GetString(4);
                        shiftVM.RoleID = reader.GetString(5);
                        shiftVM.ScheduleID = reader.GetInt32(6);
                        shiftVM.EmployeeID = reader.GetInt32(7);
                        shiftVM.ShiftID = reader.GetInt32(8);
                        shiftVMs.Add(shiftVM);
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

            return shiftVMs;
        }
    }
}
using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    ///     AUTHOR: Timothy Lickteig
    ///     DATE: 2020-02-07
    ///     CHECKED BY: Zoey McDonald
    ///     Class for acessing the database for shift records
    /// </summary>
    /// <remarks>
    ///     UPDATED BY: N/A
    ///     UPDATE DATE: N/A
    ///     WHAT WAS CHANGED: N/A
    /// </remarks>
    public class VolunteerShiftAccessor : IVolunteerShiftAccessor
    {
        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-07
        ///     CHECKED BY: Zoey McDonald
        ///     Method for adding a shif to the DB
        /// </summary>
        /// <param name="shift">Shift Object to be added</param>
        /// <returns>Number of rows affected</returns>
        public int AddShift(VolunteerShiftVM shift)
        {
            //Declare variables
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_volunteer_shift");

            //Setup cmd object
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            //Add parameters
            cmd.Parameters.Add("@ShiftDescription", SqlDbType.NVarChar, 1080);
            cmd.Parameters.Add("@ShiftTitle", SqlDbType.NVarChar, 500);
            cmd.Parameters.Add("@ShiftDate", SqlDbType.Date);
            cmd.Parameters.Add("@ShiftStartTime", SqlDbType.Time);
            cmd.Parameters.Add("@ShiftEndTime", SqlDbType.Time);
            cmd.Parameters.Add("@IsSpecialEvent", SqlDbType.Bit);
            cmd.Parameters.Add("@Recurrance", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@ShiftNotes", SqlDbType.NVarChar, 1080);
            cmd.Parameters.Add("@ScheduleID", SqlDbType.Int);

            //Set parameter values
            cmd.Parameters["@ShiftDescription"].Value = shift.ShiftDescription;
            cmd.Parameters["@ShiftTitle"].Value = shift.ShiftTitle;
            cmd.Parameters["@ShiftDate"].Value = shift.VolunteerShiftDate;
            cmd.Parameters["@ShiftStartTime"].Value = shift.ShiftStartTime;
            cmd.Parameters["@ShiftEndTime"].Value = shift.ShiftEndTime;
            cmd.Parameters["@Recurrance"].Value = shift.Recurrance;
            cmd.Parameters["@ShiftNotes"].Value = shift.ShiftNotes;
            cmd.Parameters["@ScheduleID"].Value = shift.ScheduleID;
            cmd.Parameters["@IsSpecialEvent"].Value = shift.IsSpecialEvent;

            //Try to execute the query
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
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-08
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <param name="volunteerID">The volunteerID to use</param>
        /// <param name="volunteerShiftID">The volunteerShiftID to use</param>
        /// <returns>The number of rows affected</returns>
        public int CancelVolunteerShift(int volunteerID, int volunteerShiftID)
        {
            //Declare variables
            int rows = 0;
            var cmd = new SqlCommand("sp_cancel_volunteer_shift");
            var conn = DBConnection.GetConnection();

            //Setup cmd object
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            //Add parameters
            cmd.Parameters.Add("@VolunteerID", SqlDbType.Int);
            cmd.Parameters.Add("@VolunteerShiftID", SqlDbType.Int);

            //Set parameter values
            cmd.Parameters["@VolunteerID"].Value = volunteerID;
            cmd.Parameters["@VolunteerShiftID"].Value = volunteerShiftID;

            //Try to execute the query
            try
            {
                conn.Open();
                rows = Convert.ToInt32(cmd.ExecuteNonQuery());
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
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-05
        ///     CHECKED BY: Zoey McDonald
        ///     Method for removing a shift from the DB
        /// </summary>
        /// <param name="shiftID">ShiftID to be removed</param>
        /// <returns>Number of rows affected</returns>
        public int RemoveShift(int shiftID)
        {
            //Declare variables
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_delete_volunteer_shift");

            //Setup cmd object
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            //Add Parameters
            cmd.Parameters.Add("@ShiftID", SqlDbType.Int);
            cmd.Parameters["@ShiftID"].Value = shiftID;

            //Try to execute the query
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
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-17
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <returns>A list of shifts from the database</returns>
        public List<VolunteerShiftVM> SelectAllShifts()
        {
            //Declare variables
            List<VolunteerShiftVM> shifts = new List<VolunteerShiftVM>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_volunteer_shifts");

            //Setup cmd object
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            //Try to execute the query
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VolunteerShiftVM shift = new VolunteerShiftVM();
                    shift.VolunteerShiftID = Convert.ToInt32(reader.GetValue(0));
                    shift.ShiftDescription = Convert.ToString(reader.GetValue(1));
                    shift.ShiftTitle = Convert.ToString(reader.GetValue(2));
                    shift.ShiftStartTime = (TimeSpan)(reader.GetValue(3));
                    shift.ShiftEndTime = (TimeSpan)(reader.GetValue(4));
                    shift.Recurrance = Convert.ToString(reader.GetValue(5));
                    shift.IsSpecialEvent = Convert.ToBoolean(reader.GetValue(6));
                    shift.ShiftNotes = Convert.ToString(reader.GetValue(7));
                    shift.VolunteerShiftDate = Convert.ToDateTime(reader.GetValue(8));
                    shift.ScheduleID = Convert.ToInt32(reader.GetValue(9));
                    shift.VolunteerID = reader.IsDBNull(10) ? 0 : reader.GetInt32(10);
                    shift.VolunteerFirstName = reader.IsDBNull(11) ? "" : reader.GetString(11);
                    shift.VolunteerLastName = reader.IsDBNull(12) ? "" : reader.GetString(12);
                    shifts.Add(shift);
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

            return shifts;
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-01
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <param name="volunteerID">The volunteerID to query</param>
        /// <returns>A list of shifts from the database</returns>
        public List<VolunteerShiftVM> SelectAllShiftsForAVolunteer(int volunteerID)
        {
            //Declare variables
            List<VolunteerShiftVM> shifts = new List<VolunteerShiftVM>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_shifts_for_a_volunteer");

            //Setup cmd object
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            //Add paramaters
            cmd.Parameters.Add("@VolunteerID", SqlDbType.Int);
            cmd.Parameters["@VolunteerID"].Value = volunteerID;

            //Try to execute the query
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VolunteerShiftVM shift = new VolunteerShiftVM();
                    shift.VolunteerShiftID = reader.GetInt32(0);
                    shift.ShiftDescription = reader.GetString(1);
                    shift.ShiftTitle = reader.GetString(2);
                    shift.VolunteerShiftDate = reader.GetDateTime(3);
                    shift.ShiftStartTime = reader.GetTimeSpan(4);
                    shift.ShiftEndTime = reader.GetTimeSpan(5);
                    shift.Recurrance = reader.GetString(6);
                    shift.IsSpecialEvent = reader.GetBoolean(7);
                    shift.ShiftNotes = reader.GetString(8);
                    shift.ScheduleID = reader.GetInt32(9);
                    shift.VolunteerID = volunteerID;
                    shift.VolunteerFirstName = reader.IsDBNull(10) ? "" : reader.GetString(10);
                    shift.VolunteerLastName = reader.IsDBNull(11) ? "" : reader.GetString(11);
                    shifts.Add(shift);
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
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-01
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <param name="shiftID">The shiftID to query</param>
        /// <returns>A shift from the database</returns>
        public VolunteerShiftVM SelectShift(int shiftID)
        {
            //Declare variables
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_volunteer_shift");
            VolunteerShiftVM shift = new VolunteerShiftVM();

            //Setup cmd object
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            //Add parameter
            cmd.Parameters.Add("@VolunteerShiftID", SqlDbType.Int);
            cmd.Parameters["@VolunteerShiftID"].Value = shiftID;

            //Try to execute the query
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    shift.VolunteerShiftID = reader.GetInt32(0);
                    shift.ShiftDescription = reader.GetString(1);
                    shift.ShiftTitle = reader.GetString(2);
                    shift.VolunteerShiftDate = reader.GetDateTime(3);
                    shift.ShiftStartTime = reader.GetTimeSpan(4);
                    shift.ShiftEndTime = reader.GetTimeSpan(5);
                    shift.Recurrance = reader.GetString(6);
                    shift.IsSpecialEvent = reader.GetBoolean(7);
                    shift.ShiftNotes = reader.GetString(8);
                    shift.ScheduleID = reader.GetInt32(9);
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

            return shift;
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-02
        ///     CHECKED BY: Zoey McDonald
        /// </summary>        
        /// <param name="volunteerID">The volunteerID to use</param>
        /// <param name="volunteerShiftID">The volunteerShiftID to use</param>
        /// <returns>The number of rows affected</returns>
        public int SignVolunteerUpForShift(int volunteerID, int volunteerShiftID)
        {
            //Declare variables
            int rows = 0;
            var cmd = new SqlCommand("sp_sign_volunteer_up_for_shift");
            var conn = DBConnection.GetConnection();

            //Setup cmd object
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            //Add parameters
            cmd.Parameters.Add("@VolunteerID", SqlDbType.Int);
            cmd.Parameters.Add("@VolunteerShiftID", SqlDbType.Int);

            //Set parameter values
            cmd.Parameters["@VolunteerID"].Value = volunteerID;
            cmd.Parameters["@VolunteerShiftID"].Value = volunteerShiftID;

            //Try to execute the query
            try
            {
                conn.Open();
                rows = Convert.ToInt32(cmd.ExecuteNonQuery());
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
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-10
        ///     CHECKED BY: Zoey McDonald
        ///     Method for editing a shift inside the DB
        /// </summary>
        /// <param name="oldShift">The shift to be updated</param>
        /// <param name="newShift">The new shift</param>
        /// <returns>Number of rows affected</returns>
        public int UpdateShift(VolunteerShiftVM oldShift, VolunteerShiftVM newShift)
        {
            //Declare variables
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_volunteer_shift");

            //Setup cmd object
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            //Add Parameters
            cmd.Parameters.Add("@VolunteerShiftID", SqlDbType.Int);
            cmd.Parameters.Add("@ShiftDescription", SqlDbType.NVarChar, 1080);
            cmd.Parameters.Add("@ShiftDate", SqlDbType.Date);
            cmd.Parameters.Add("@ShiftTitle", SqlDbType.NVarChar, 500);
            cmd.Parameters.Add("@ShiftStartTime", SqlDbType.Time);
            cmd.Parameters.Add("@ShiftEndTime", SqlDbType.Time);
            cmd.Parameters.Add("@Recurrance", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@IsSpecialEvent", SqlDbType.Bit);
            cmd.Parameters.Add("@ShiftNotes", SqlDbType.NVarChar, 1080);
            cmd.Parameters.Add("@ScheduleID", SqlDbType.Int);

            //Set Parameter values
            cmd.Parameters["@VolunteerShiftID"].Value = oldShift.VolunteerShiftID;
            cmd.Parameters["@ShiftDescription"].Value = newShift.ShiftDescription;
            cmd.Parameters["@ShiftDate"].Value = newShift.VolunteerShiftDate;
            cmd.Parameters["@ShiftTitle"].Value = newShift.ShiftTitle;
            cmd.Parameters["@ShiftStartTime"].Value = newShift.ShiftStartTime;
            cmd.Parameters["@ShiftEndTime"].Value = newShift.ShiftEndTime;
            cmd.Parameters["@Recurrance"].Value = newShift.Recurrance;
            cmd.Parameters["@IsSpecialEvent"].Value = newShift.IsSpecialEvent;
            cmd.Parameters["@ShiftNotes"].Value = newShift.ShiftNotes;
            cmd.Parameters["@ScheduleID"].Value = newShift.ScheduleID;

            //Try to execute the query
            try
            {
                conn.Open();
                rows = Convert.ToInt32(cmd.ExecuteScalar());
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

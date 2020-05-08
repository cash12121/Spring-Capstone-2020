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
    /// Creator: Timothy Lickteig        
    /// Created: 04/27/2020
    /// Approver: Zoey McDonald
    /// 
    /// Class for accessing the database to get foster appointment records
    /// </summary>
    public class FosterAppointmentAccessor : IFosterAppointmentAccessor
    {
        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// method for deleting foster appointments
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="fosterAppointmentID">The ID of the record to delete</param>
        /// <returns>The number of rows affected</returns>
        public int DeleteFosterAppointment(int fosterAppointmentID)
        {
            //Declare variables
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_delete_foster_appointment");

            //Setup cmd object
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            //Add parameter
            cmd.Parameters.Add("@FosterAppointmentID", SqlDbType.Int);
            cmd.Parameters["@FosterAppointmentID"].Value = fosterAppointmentID;

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
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// method for inserting foster appointments
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="appointment">The record to insert</param>
        /// <returns>The number of rows affected</returns>
        public int InsertFosterAppointment(FosterAppointment appointment)
        {
            //Declare variables
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_foster_appointment");

            //Setup cmd object
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            //Add parameters
            cmd.Parameters.AddWithValue("@VolunteerID", appointment.VolunteerID);
            cmd.Parameters.AddWithValue("@StartTime", appointment.StartTime);
            cmd.Parameters.AddWithValue("@EndTime", appointment.EndTime);
            cmd.Parameters.AddWithValue("@Description", appointment.Description);

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
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// method for selecting all foster appointments
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>        
        /// <returns>The list of appointment records</returns>
        public List<FosterAppointmentVM> SelectAllFosterAppointments()
        {
            //Declare variables
            List<FosterAppointmentVM> appointments = new List<FosterAppointmentVM>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_foster_appointments");

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
                    FosterAppointmentVM appt = new FosterAppointmentVM();
                    appt.VolunteerID = reader.GetInt32(0);
                    appt.FosterAppointmentID = reader.GetInt32(1);
                    TimeSpan startTime = reader.GetTimeSpan(2);
                    TimeSpan endTime = reader.GetTimeSpan(3);
                    appt.StartTime = new DateTime(2000, 1, 1, startTime.Hours, startTime.Minutes, startTime.Seconds);
                    appt.EndTime = new DateTime(2000, 1, 1, endTime.Hours, endTime.Minutes, endTime.Seconds);
                    appt.Description = reader.GetString(4);
                    appt.FirstName = reader.GetString(5);
                    appt.LastName = reader.GetString(6);
                    appointments.Add(appt);
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

            return appointments;
        }

        /// <summary>
        /// Creator: Timothy Lickteig
        /// Created: 04/27/2020
        /// Approver: Zoey McDonald
        /// 
        /// method for updating foster appointments
        /// </summary>
        /// <remarks>
        /// Updater: N/A
        /// Updated: N/A
        /// Update: N/A
        /// </remarks>
        /// <param name="oldAppt">The old record</param>
        /// <param name="newAppt">The new record</param>
        /// <returns>The number of rows affected</returns>
        public int UpdateFosterAppointment(FosterAppointment oldAppt, FosterAppointment newAppt)
        {
            //Declare variables
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_foster_appointment");

            //Setup cmd object
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;            

            //Add parameters for old appt            
            cmd.Parameters.AddWithValue("@FosterAppointmentID", oldAppt.FosterAppointmentID);
            cmd.Parameters.AddWithValue("@OldVolunteerID", oldAppt.VolunteerID);
            cmd.Parameters.AddWithValue("@OldStartTime", oldAppt.StartTime);
            cmd.Parameters.AddWithValue("@OldEndTime", oldAppt.EndTime);
            cmd.Parameters.AddWithValue("@OldDescription", oldAppt.Description);

            //Add params for new appt            
            cmd.Parameters.AddWithValue("@NewVolunteerID", newAppt.VolunteerID);
            cmd.Parameters.AddWithValue("@NewStartTime", newAppt.StartTime.ToShortTimeString());            
            cmd.Parameters.AddWithValue("@NewEndTime", newAppt.EndTime.ToShortTimeString());
            cmd.Parameters.AddWithValue("@NewDescription", newAppt.Description);

            //Try to excecute the query
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
    }
}

using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Thomas Dupuy
    /// Created: 2020/02/06
    /// Approver: Awaab Elamin
    /// 
    /// This Accessor class is used as an accessor for the data objects
    /// </summary>
    public class AppointmentAccessor : IAppointmentAccessor
    {
        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 2020/04/12
        /// Approver: Michael Thompson
        /// This method deactivates an appointment
        /// </summary>        
        /// <remarks>
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/20
        /// Update: I Added param, returns tags for the comments.
        /// And updated the date format. 
        /// </remarks>
        /// <param name="appointment"></param>
        /// <returns>rows count</returns>
        public int DeactivateAppointment(Appointment appointment)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_deactivate_appointment", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AppointmentID", appointment.AppointmentID);
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
        /// Creator: Thomas Dupuy
        /// Created: 2020/04/12
        /// Approver: Michael Thompson
        /// 
        /// This method inserts an appointment
        /// </summary>        
        /// <remarks>
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/20
        /// Update: I Added param, returns tags for the comments.
        /// updated the date format .
        /// </remarks>
        /// <param name="appointment"></param>
        /// <param name=""></param>
        /// <returns>rows count</returns>
        public int InsertAppointment(Appointment appointment)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_appointment", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AdoptionApplicationID", appointment.AdoptionApplicationID);
            cmd.Parameters.AddWithValue("@AppointmentTypeID", appointment.AppointmentTypeID);
            cmd.Parameters.AddWithValue("@DateTime", appointment.DateTime);
            cmd.Parameters.AddWithValue("@LocationID", appointment.LocationID);
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
        /// Creator: Thomas Dupuy
        /// Created: 2020/02/06
        /// Approver: Awaab Elamin
        /// This method selects all appointments
        /// </summary>
        /// <remarks>
        /// Updater: Thomas Dupuy
        /// Updated: 2020/04/12
        /// Update: Updated it to match the AppointmentLocationVM instead on the Appointment DTO
        /// 
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/20
        /// Update: I Added param, returns tags for the comments. 
        /// And updated the date format. 
        /// </remarks>
        /// <returns>A list of active appointments</returns>
        public List<AppointmentLocationVM> SelectAllActiveAppointments()
        {
            List<AppointmentLocationVM> appointments = new List<AppointmentLocationVM>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_appointments_by_active");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AppointmentLocationVM newAppointment = new AppointmentLocationVM();
                    newAppointment.AppointmentID = reader.GetInt32(0);
                    newAppointment.AdoptionApplicationID = reader.GetInt32(1);
                    newAppointment.AppointmentTypeID = reader.GetString(2);
                    newAppointment.DateTime = reader.GetDateTime(3);
                    newAppointment.Notes = reader.IsDBNull(4) ? null : reader.GetString(4);
                    newAppointment.Decicion = reader.GetString(5);
                    newAppointment.LocationID = reader.GetInt32(6);
                    newAppointment.Active = reader.GetBoolean(7);
                    newAppointment.LocationName = reader.GetString(8);
                    newAppointment.LocationAddress1 = reader.GetString(9);
                    newAppointment.LocationAddress2 = reader.IsDBNull(10) ? null : reader.GetString(10);
                    newAppointment.LocationCity = reader.GetString(11);
                    newAppointment.LocationState = reader.GetString(12);
                    newAppointment.LocationZip = reader.GetString(13);
                    appointments.Add(newAppointment);
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
            return appointments;
        }

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 2020/04/12
        /// Approver: Michael Thompson
        /// This method selects an appointment by its id
        /// </summary>        
        /// <remarks>
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/20
        /// Update: I Added param, returns tags for the comments.
        /// And updated the date format. 
        /// </remarks>
        /// <param name="id"></param>
        /// <returns> An appointment by appointment ID</returns>
        public AppointmentLocationVM SelectAppointmentByID(int id)
        {
            AppointmentLocationVM appointment = new AppointmentLocationVM();
            var conn = DBConnection.GetConnection();
            var cmd1 = new SqlCommand("sp_select_appointment_by_appointment_id");
            var cmd2 = new SqlCommand("sp_select_location_by_location_id");
            cmd1.Connection = conn;
            cmd2.Connection = conn;
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@AppointmentID", id);
            cmd2.Parameters.Add("@LocationID", SqlDbType.Int);
            try
            {
                conn.Open();
                var reader1 = cmd1.ExecuteReader();

                if (reader1.Read())
                {
                    appointment.AppointmentID = id;
                    appointment.AdoptionApplicationID = reader1.GetInt32(1);
                    appointment.AppointmentTypeID = reader1.GetString(2);
                    appointment.DateTime = reader1.GetDateTime(3);
                    appointment.Notes = reader1.GetString(4);
                    appointment.Decicion = reader1.GetString(5);
                    appointment.LocationID = reader1.GetInt32(6);
                    appointment.Active = reader1.GetBoolean(7);
                }
                else
                {
                    throw new ApplicationException("User not found.");
                }
                cmd2.Parameters["@LocationID"].Value = appointment.LocationID;

                var reader2 = cmd2.ExecuteReader();

                if (reader2.Read())
                {
                    appointment.LocationName = reader2.GetString(1);
                    appointment.LocationAddress1 = reader2.GetString(2);
                    appointment.LocationAddress2 = reader2.GetString(3);
                    appointment.LocationCity = reader2.GetString(4);
                    appointment.LocationState = reader2.GetString(5);
                    appointment.LocationZip = reader2.GetString(6);
                }
                else
                {
                    throw new ApplicationException("Location not found.");
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
            return appointment;
        }

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 2020/04/15
        /// Approver: Michael Thompson
        /// 
        /// This method updates an appointment
        /// </summary>
        /// <remarks>
        /// Updater: Mohamed Elamin 
        /// Updated: 2020/04/20
        /// Update: I Added param, returns tags for the comments.
        /// And  updated the date format. 
        /// </remarks>
        /// <param name="oldAppointment"></param>
        /// <param name="newAppointment"></param>
        /// <returns>rows count</returns>
        public int UpdateAppointment(Appointment oldAppointment, Appointment newAppointment)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_appointment", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AppointmentID", oldAppointment.AppointmentID);
            cmd.Parameters.AddWithValue("@OldAdoptionApplicationID", oldAppointment.AdoptionApplicationID);
            cmd.Parameters.AddWithValue("@OldAppointmentTypeID", oldAppointment.AppointmentTypeID);
            cmd.Parameters.AddWithValue("@OldDateTime", oldAppointment.DateTime);
            cmd.Parameters.AddWithValue("@OldNotes", oldAppointment.Notes);
            cmd.Parameters.AddWithValue("@OldDecision", oldAppointment.Decicion);
            cmd.Parameters.AddWithValue("@OldLocationID", oldAppointment.LocationID);
            cmd.Parameters.AddWithValue("@OldActive", oldAppointment.Active);

            cmd.Parameters.AddWithValue("@NewAdoptionApplicationID", newAppointment.AdoptionApplicationID);
            cmd.Parameters.AddWithValue("@NewAppointmentTypeID", newAppointment.AppointmentTypeID);
            cmd.Parameters.AddWithValue("@NewDateTime", newAppointment.DateTime);
            cmd.Parameters.AddWithValue("@NewNotes", newAppointment.Notes);
            cmd.Parameters.AddWithValue("@NewDecision", newAppointment.Decicion);
            cmd.Parameters.AddWithValue("@NewLocationID", newAppointment.LocationID);
            cmd.Parameters.AddWithValue("@NewActive", newAppointment.Active);
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

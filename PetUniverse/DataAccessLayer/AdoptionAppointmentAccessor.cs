using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 2/20/2020
    /// CHECKED BY: Thomas Dupuy
    /// 
    /// This data access class is used to access data that pertains to the Adoption Appointment.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>
    public class AdoptionAppointmentAccessor : IAdoptionAppointmentAccessor
    {

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/12/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// This is used to insert appointments into the database
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public int InsertAdoptionAppointment(AdoptionAppointment adoptionAppointment)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_appointment", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AdoptionApplicationID", adoptionAppointment.AdoptionApplicationID);
            cmd.Parameters.AddWithValue("@AppointmentTypeID", adoptionAppointment.AppointmentTypeID);
            cmd.Parameters.AddWithValue("@DateTime", adoptionAppointment.AppointmentDateTime);
            cmd.Parameters.AddWithValue("@LocationID", adoptionAppointment.LocationID);


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
        /// NAME: Austin Gee
        /// DATE: 3/4/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// Selects an AdoptionAppointmentVM from the database
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public AdoptionAppointmentVM SelectAdoptionAppointmentByAppointmentID(int appointmentID)
        {
            AdoptionAppointmentVM adoptionAppointment = new AdoptionAppointmentVM();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_adoption_appointment_by_appointment_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AppointmentID", appointmentID);

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    adoptionAppointment.AppointmentID = reader.GetInt32(0);
                    adoptionAppointment.AdoptionApplicationID = reader.GetInt32(1);
                    adoptionAppointment.AppointmentTypeID = reader.GetString(2);
                    adoptionAppointment.AppointmentDateTime = reader.GetDateTime(3);
                    if (!reader.IsDBNull(4)) adoptionAppointment.Notes = reader.GetString(4);
                    if (!reader.IsDBNull(5)) adoptionAppointment.Decision = reader.GetString(5);
                    adoptionAppointment.LocationID = reader.GetInt32(6);
                    adoptionAppointment.AppointmentActive = reader.GetBoolean(7);
                    adoptionAppointment.CustomerEmail = reader.GetString(8);
                    adoptionAppointment.AnimalID = reader.GetInt32(9);
                    if (!reader.IsDBNull(10)) adoptionAppointment.AdoptionApplicationStatus = reader.GetString(10);
                    adoptionAppointment.AdoptionApplicationRecievedDate = reader.GetDateTime(11);
                    if (!reader.IsDBNull(12)) adoptionAppointment.LocationName = reader.GetString(12);
                    adoptionAppointment.LocationAddress1 = reader.GetString(13);
                    if (!reader.IsDBNull(14)) adoptionAppointment.LocationAddress2 = reader.GetString(14);
                    adoptionAppointment.LocationCity = reader.GetString(15);
                    adoptionAppointment.LocationState = reader.GetString(16);
                    adoptionAppointment.LocationZip = reader.GetString(17);

                    adoptionAppointment.CustomerFirstName = reader.GetString(18);
                    adoptionAppointment.CustomerLastName = reader.GetString(19);
                    adoptionAppointment.CustomerPhoneNumber = reader.GetString(20);
                    adoptionAppointment.CustomerActive = reader.GetBoolean(21);
                    adoptionAppointment.CustomerCity = reader.GetString(22);
                    adoptionAppointment.CustomerState = reader.GetString(23);
                    adoptionAppointment.CustomerZipCode = reader.GetString(24);
                    adoptionAppointment.AnimalName = reader.GetString(25);
                    if (!reader.IsDBNull(26)) adoptionAppointment.AnimalDob = reader.GetDateTime(26);
                    adoptionAppointment.AnimalSpeciesID = reader.GetString(27);
                    if (!reader.IsDBNull(28)) adoptionAppointment.AnimalBreed = reader.GetString(28);
                    adoptionAppointment.AnimalArrivalDate = reader.GetDateTime(29);
                    adoptionAppointment.AnimalCurrentlyHoused = reader.GetBoolean(30);
                    adoptionAppointment.AnimalAdoptable = reader.GetBoolean(31);
                    adoptionAppointment.AnimalActive = reader.GetBoolean(32);
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

            return adoptionAppointment;
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/27/2020
        /// Approver: Michael Thompson
        /// 
        /// Data Access Inteface that is used to Select Adoption Appointment VMs by Customer email and active
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="email"></param>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<AdoptionAppointmentVM> SelectAdoptionAppointmentByCustomerEmailAndActive(string email, bool active)
        {
            List<AdoptionAppointmentVM> adoptionAppointments = new List<AdoptionAppointmentVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_adoption_appointments_by_customer_email_and_active", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Active", active);
            cmd.Parameters.AddWithValue("@CustomerEmail", email);

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var adoptionAppointment = new AdoptionAppointmentVM();

                        adoptionAppointment.AppointmentID = reader.GetInt32(0);
                        adoptionAppointment.AdoptionApplicationID = reader.GetInt32(1);
                        adoptionAppointment.AppointmentTypeID = reader.GetString(2);
                        adoptionAppointment.AppointmentDateTime = reader.GetDateTime(3);
                        if (!reader.IsDBNull(4)) adoptionAppointment.Notes = reader.GetString(4);
                        if (!reader.IsDBNull(5)) adoptionAppointment.Decision = reader.GetString(5);
                        adoptionAppointment.LocationID = reader.GetInt32(6);
                        adoptionAppointment.AppointmentActive = reader.GetBoolean(7);
                        adoptionAppointment.CustomerEmail = reader.GetString(8);
                        adoptionAppointment.AnimalID = reader.GetInt32(9);
                        if (!reader.IsDBNull(10)) adoptionAppointment.AdoptionApplicationStatus = reader.GetString(10);
                        adoptionAppointment.AdoptionApplicationRecievedDate = reader.GetDateTime(11);
                        if (!reader.IsDBNull(12)) adoptionAppointment.LocationName = reader.GetString(12);
                        adoptionAppointment.LocationAddress1 = reader.GetString(13);
                        if (!reader.IsDBNull(14)) adoptionAppointment.LocationAddress2 = reader.GetString(14);
                        adoptionAppointment.LocationCity = reader.GetString(15);
                        adoptionAppointment.LocationState = reader.GetString(16);
                        adoptionAppointment.LocationZip = reader.GetString(17);

                        adoptionAppointment.CustomerFirstName = reader.GetString(18);
                        adoptionAppointment.CustomerLastName = reader.GetString(19);
                        adoptionAppointment.CustomerPhoneNumber = reader.GetString(20);
                        adoptionAppointment.CustomerActive = reader.GetBoolean(21);
                        adoptionAppointment.CustomerCity = reader.GetString(22);
                        adoptionAppointment.CustomerState = reader.GetString(23);
                        adoptionAppointment.CustomerZipCode = reader.GetString(24);
                        adoptionAppointment.AnimalName = reader.GetString(25);
                        if (!reader.IsDBNull(26)) adoptionAppointment.AnimalDob = reader.GetDateTime(26);
                        adoptionAppointment.AnimalSpeciesID = reader.GetString(27);
                        if (!reader.IsDBNull(28)) adoptionAppointment.AnimalBreed = reader.GetString(28);
                        adoptionAppointment.AnimalArrivalDate = reader.GetDateTime(29);
                        adoptionAppointment.AnimalCurrentlyHoused = reader.GetBoolean(30);
                        adoptionAppointment.AnimalAdoptable = reader.GetBoolean(31);
                        adoptionAppointment.AnimalActive = reader.GetBoolean(32);

                        adoptionAppointments.Add(adoptionAppointment);
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

            return adoptionAppointments;
        }


        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/29/2020
        /// Approver: Michael Thompson
        /// 
        /// Data Access Inteface that is used to Select Adoption Appointment VMs by and active
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<AdoptionAppointmentVM> SelectAdoptionAppointmentsByActive(bool active)
        {
            List<AdoptionAppointmentVM> adoptionAppointments = new List<AdoptionAppointmentVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_adoption_appointments_by_active", conn);
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
                        var adoptionAppointment = new AdoptionAppointmentVM();

                        adoptionAppointment.AppointmentID = reader.GetInt32(0);
                        adoptionAppointment.AdoptionApplicationID = reader.GetInt32(1);
                        adoptionAppointment.AppointmentTypeID = reader.GetString(2);
                        adoptionAppointment.AppointmentDateTime = reader.GetDateTime(3);
                        if (!reader.IsDBNull(4)) adoptionAppointment.Notes = reader.GetString(4);
                        if (!reader.IsDBNull(5)) adoptionAppointment.Decision = reader.GetString(5);
                        adoptionAppointment.LocationID = reader.GetInt32(6);
                        adoptionAppointment.AppointmentActive = reader.GetBoolean(7);
                        adoptionAppointment.CustomerEmail = reader.GetString(8);
                        adoptionAppointment.AnimalID = reader.GetInt32(9);
                        if (!reader.IsDBNull(10)) adoptionAppointment.AdoptionApplicationStatus = reader.GetString(10);
                        adoptionAppointment.AdoptionApplicationRecievedDate = reader.GetDateTime(11);
                        if (!reader.IsDBNull(12)) adoptionAppointment.LocationName = reader.GetString(12);
                        adoptionAppointment.LocationAddress1 = reader.GetString(13);
                        if (!reader.IsDBNull(14)) adoptionAppointment.LocationAddress2 = reader.GetString(14);
                        adoptionAppointment.LocationCity = reader.GetString(15);
                        adoptionAppointment.LocationState = reader.GetString(16);
                        adoptionAppointment.LocationZip = reader.GetString(17);

                        adoptionAppointment.CustomerFirstName = reader.GetString(18);
                        adoptionAppointment.CustomerLastName = reader.GetString(19);
                        adoptionAppointment.CustomerPhoneNumber = reader.GetString(20);
                        adoptionAppointment.CustomerActive = reader.GetBoolean(21);
                        adoptionAppointment.CustomerCity = reader.GetString(22);
                        adoptionAppointment.CustomerState = reader.GetString(23);
                        adoptionAppointment.CustomerZipCode = reader.GetString(24);
                        adoptionAppointment.AnimalName = reader.GetString(25);
                        if (!reader.IsDBNull(26)) adoptionAppointment.AnimalDob = reader.GetDateTime(26);
                        adoptionAppointment.AnimalSpeciesID = reader.GetString(27);
                        if (!reader.IsDBNull(28)) adoptionAppointment.AnimalBreed = reader.GetString(28);
                        adoptionAppointment.AnimalArrivalDate = reader.GetDateTime(29);
                        adoptionAppointment.AnimalCurrentlyHoused = reader.GetBoolean(30);
                        adoptionAppointment.AnimalAdoptable = reader.GetBoolean(31);
                        adoptionAppointment.AnimalActive = reader.GetBoolean(32);

                        adoptionAppointments.Add(adoptionAppointment);
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

            return adoptionAppointments;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/20/2020
        /// CHECKED BY: Mohamed Elamin, 02/07/2020
        /// 
        /// This data access class is used to access data that pertains to the Adoption customer.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public List<AdoptionAppointmentVM> SelectAdoptionAppointmentsByActiveAndType(bool active, string appointmentTypeID)
        {
            List<AdoptionAppointmentVM> adoptionAppointments = new List<AdoptionAppointmentVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_adoption_appointments_by_active_and_type", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Active", active);
            cmd.Parameters.AddWithValue("@AppointmentTypeID", appointmentTypeID);

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var adoptionAppointment = new AdoptionAppointmentVM();

                        adoptionAppointment.AppointmentID = reader.GetInt32(0);
                        adoptionAppointment.AdoptionApplicationID = reader.GetInt32(1);
                        adoptionAppointment.AppointmentTypeID = reader.GetString(2);
                        adoptionAppointment.AppointmentDateTime = reader.GetDateTime(3);
                        if (!reader.IsDBNull(4)) adoptionAppointment.Notes = reader.GetString(4);
                        if (!reader.IsDBNull(5)) adoptionAppointment.Decision = reader.GetString(5);
                        adoptionAppointment.LocationID = reader.GetInt32(6);
                        adoptionAppointment.AppointmentActive = reader.GetBoolean(7);
                        adoptionAppointment.CustomerEmail = reader.GetString(8);
                        adoptionAppointment.AnimalID = reader.GetInt32(9);
                        if (!reader.IsDBNull(10)) adoptionAppointment.AdoptionApplicationStatus = reader.GetString(10);
                        adoptionAppointment.AdoptionApplicationRecievedDate = reader.GetDateTime(11);
                        if (!reader.IsDBNull(12)) adoptionAppointment.LocationName = reader.GetString(12);
                        adoptionAppointment.LocationAddress1 = reader.GetString(13);
                        if (!reader.IsDBNull(14)) adoptionAppointment.LocationAddress2 = reader.GetString(14);
                        adoptionAppointment.LocationCity = reader.GetString(15);
                        adoptionAppointment.LocationState = reader.GetString(16);
                        adoptionAppointment.LocationZip = reader.GetString(17);

                        adoptionAppointment.CustomerFirstName = reader.GetString(18);
                        adoptionAppointment.CustomerLastName = reader.GetString(19);
                        adoptionAppointment.CustomerPhoneNumber = reader.GetString(20);
                        adoptionAppointment.CustomerActive = reader.GetBoolean(21);
                        adoptionAppointment.CustomerCity = reader.GetString(22);
                        adoptionAppointment.CustomerState = reader.GetString(23);
                        adoptionAppointment.CustomerZipCode = reader.GetString(24);
                        adoptionAppointment.AnimalName = reader.GetString(25);
                        if (!reader.IsDBNull(26)) adoptionAppointment.AnimalDob = reader.GetDateTime(26);
                        adoptionAppointment.AnimalSpeciesID = reader.GetString(27);
                        if (!reader.IsDBNull(28)) adoptionAppointment.AnimalBreed = reader.GetString(28);
                        adoptionAppointment.AnimalArrivalDate = reader.GetDateTime(29);
                        adoptionAppointment.AnimalCurrentlyHoused = reader.GetBoolean(30);
                        adoptionAppointment.AnimalAdoptable = reader.GetBoolean(31);
                        adoptionAppointment.AnimalActive = reader.GetBoolean(32);

                        adoptionAppointments.Add(adoptionAppointment);
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

            return adoptionAppointments;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 5/1/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// This data access class is used to access data that pertains to the Adoption customer.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="appointmentID"></param>
        /// <param name="active"></param>
        /// <returns></returns>
        public int UpdateAdoptionAppointmentActive(int appointmentID, bool active)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_update_adoption_appointment_active", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AppointmentID", appointmentID);
            cmd.Parameters.AddWithValue("@Active", active);
            
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
        /// Created: 4/27/2020
        /// Approver: Michael Thompson
        /// 
        /// updates an adoption appointment schedule
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="appointmentID"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public int UpdateAdoptionAppointmentDateTime(int appointmentID, DateTime dateTime)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_appointment_date_time", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AppointmentID", appointmentID);
            cmd.Parameters.AddWithValue("@AppointmentDateTime", dateTime);

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
        /// Created: 4/27/2020
        /// Approver: Michael Thompson
        /// 
        /// updates an adoption appointment 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="oldAppointment"></param>
        /// <param name="newAppointment"></param>
        /// <returns></returns>
        public int UpdateAdoptionAppopintment(AdoptionAppointment oldAppointment, AdoptionAppointment newAppointment)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_update_adoption_appointment", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OldAppointmentID", oldAppointment.AppointmentID);
            
            cmd.Parameters.AddWithValue("@OldAdoptionApplicationID", oldAppointment.AdoptionApplicationID);
            cmd.Parameters.AddWithValue("@OldAppointmentTypeID", oldAppointment.AppointmentTypeID);
            cmd.Parameters.AddWithValue("@OldDateTime", oldAppointment.AppointmentDateTime);
            //if (oldAppointment.Notes != null) oldAppointment.Notes = "";
            //cmd.Parameters.AddWithValue("@OldNotes", oldAppointment.Notes);
            //cmd.Parameters.AddWithValue("@OldDecision", oldAppointment.Decision);
            cmd.Parameters.AddWithValue("@OldLocationID", oldAppointment.LocationID);
            cmd.Parameters.AddWithValue("@OldActive", oldAppointment.AppointmentActive);
            
            cmd.Parameters.AddWithValue("@NewAdoptionApplicationID", newAppointment.AdoptionApplicationID);
            cmd.Parameters.AddWithValue("@NewAppointmentTypeID", newAppointment.AppointmentTypeID);
            cmd.Parameters.AddWithValue("@NewDateTime", newAppointment.AppointmentDateTime);
            cmd.Parameters.AddWithValue("@NewNotes", newAppointment.Notes);
            cmd.Parameters.AddWithValue("@NewDecision", newAppointment.Decision);
            cmd.Parameters.AddWithValue("@NewLocationID", newAppointment.LocationID);
            cmd.Parameters.AddWithValue("@NewActive", newAppointment.AppointmentActive);
            
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

using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/29
    /// Approver:  Awaab Elamin, 2020/03/03
    /// This Class for accessing InHome Inspection Appointment Decision Accessor
    /// data in the database.
    /// </summary>
    public class AdoptionInterviewerAccessor : IAdoptionInterviewerAccessor
    {
        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/29
        /// Approver:  Awaab Elamin, 2020/03/03
        /// This method used to get Adoption Applications by the adoption type.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <returns>Adoption Applications list</returns>
        public List<AdoptionAppointment> SelectAdoptionAappointmentsByAppointmentType()
        {
           
            List<AdoptionAppointment> adoptionAppointments = new List<AdoptionAppointment>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_interviewer_Appointments_by_AppointmentType", conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        var adoptionAppointment = new AdoptionAppointment();

                        adoptionAppointment.AppointmentID = reader.GetInt32(0);
                        adoptionAppointment.AdoptionApplicationID = reader.GetInt32(1);
                        adoptionAppointment.AppointmentTypeID = reader.GetString(2);
                        if (!reader.IsDBNull(3))
                        {
                            adoptionAppointment.AppointmentDateTime = reader.GetDateTime(3);
                        }
                        if (!reader.IsDBNull(4))
                        {
                            adoptionAppointment.Notes = reader.GetString(4);
                        }
                        else
                        {
                            adoptionAppointment.Notes = "";
                        }
                        if (!reader.IsDBNull(5))
                        {
                            adoptionAppointment.Decision = reader.GetString(5);
                        }
                        else
                        {
                            adoptionAppointment.Decision = "";
                        }

                        adoptionAppointment.LocationName =
                          RetrieveLocationNameByLocationID(reader.GetInt32(6));

                        adoptionAppointments.Add(adoptionAppointment);
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
            return adoptionAppointments;
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/29
        /// Approver:  Awaab Elamin, 2020/03/03
        /// This is private method gets the Location's name from the Location table in the database
        /// by Adoption ID.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="LocationID"></param>
        /// <returns>name</returns>
        private string RetrieveLocationNameByLocationID(int LocationID)
        {
            string name = "";
            // connection?
            var conn = DBConnection.GetConnection();
            // commands?
            var cmd = new SqlCommand("sp_location_Name_by_Location_Id", conn);
            // command type?
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LocationID", LocationID);
            try
            {

                // open the connection
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    name = reader.GetString(0);

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Location name not found!", ex);
            }
            finally
            {
                // close the connection
                conn.Close();
            }
            return name;
        }


        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/29
        /// Approver:  Awaab Elamin, 2020/03/03
        /// This method used to update an Adoptin Appliction notes.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="oldAdoptionAppointment"></param>
        /// <param name="newAdoptionAppointment"></param>
        /// <returns>Zero or one depending if the record was updated </returns>
        public int UpdateAppoinment(AdoptionAppointment oldAdoptionAppointment, AdoptionAppointment newAdoptionAppointment)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_Adoption_appointment_notes", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AppointmentID", newAdoptionAppointment
                .AppointmentID);



            cmd.Parameters.AddWithValue("@NewNotes",
                newAdoptionAppointment.Notes);

            cmd.Parameters.AddWithValue("@OldNotes",
                oldAdoptionAppointment.Notes);
            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    throw new ApplicationException("Record not found.");
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

            return rows;
        }
    }

}

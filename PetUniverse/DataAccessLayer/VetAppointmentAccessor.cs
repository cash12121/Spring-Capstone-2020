using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Ethan Murphy
    /// Created: 2/7/2020
    /// Approver: Carl Davis 2/14/2020
    /// Approver: Chuck Baxter 2/14/2020
    /// 
    /// A class used to access data pertaining to animal vet appointments
    /// </summary>
    public class VetAppointmentAccessor : IVetAppointmentAccessor
    {
        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/27/2020
        /// Approver:
        /// 
        /// Deletes an existing animal vet appointment record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="vetAppointment">Record to be deleted</param>
        /// <returns>Rows affected</returns>
        public int DeleteAnimalVetAppointment(AnimalVetAppointment vetAppointment)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_delete_animal_vet_record", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AnimalVetAppointmentID", vetAppointment.VetAppointmentID);
            cmd.Parameters.AddWithValue("@AnimalID", vetAppointment.AnimalID);
            cmd.Parameters.AddWithValue("@UserID", vetAppointment.UserID);
            cmd.Parameters.AddWithValue("@AppointmentDate", vetAppointment.AppointmentDateTime);
            cmd.Parameters.AddWithValue("@AppointmentDescription", vetAppointment.AppointmentDescription);
            cmd.Parameters.AddWithValue("@ClinicAddress", vetAppointment.ClinicAddress);
            cmd.Parameters.AddWithValue("@VetName", vetAppointment.VetName);

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
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// Creates a vet appointment record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalVetAppointment">An AnimalVetAppointment object</param>
        /// <returns>Insert succesful</returns>
        public bool InsertVetAppointment(AnimalVetAppointment animalVetAppointment)
        {
            bool result = false;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_create_vet_appointment", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AnimalID", animalVetAppointment.AnimalID);
            cmd.Parameters.AddWithValue("@UserID", animalVetAppointment.UserID);
            cmd.Parameters.AddWithValue("@AppointmentDate", animalVetAppointment.AppointmentDateTime);
            cmd.Parameters.AddWithValue("@AppointmentDescription", animalVetAppointment.AppointmentDescription);
            cmd.Parameters.AddWithValue("@ClinicAddress", animalVetAppointment.ClinicAddress);
            cmd.Parameters.AddWithValue("@VetName", animalVetAppointment.VetName);
            cmd.Parameters.Add("@FollowUpDate", SqlDbType.DateTime);
            if (animalVetAppointment.FollowUpDateTime == null)
            {
                cmd.Parameters["@FollowUpDate"].Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters["@FollowUpDate"].Value = animalVetAppointment.FollowUpDateTime;
            }

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// Gets all animal vet appointment records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>List of animal vet appointment</returns>
        public List<AnimalVetAppointment> SelectAllVetAppointments()
        {
            List<AnimalVetAppointment> vetAppointments = new List<AnimalVetAppointment>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_vet_appointments", conn);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AnimalVetAppointment vetAppointment = new AnimalVetAppointment()
                    {
                        VetAppointmentID = reader.GetInt32(0),
                        AnimalID = reader.GetInt32(1),
                        AnimalName = reader.GetString(2),
                        AppointmentDateTime = reader.GetDateTime(3),
                        AppointmentDescription = reader.GetString(4),
                        ClinicAddress = reader.GetString(5),
                        VetName = reader.GetString(6),
                        FollowUpDateTime = reader[7] as DateTime?,
                        UserID = reader.GetInt32(8)
                    };
                    vetAppointments.Add(vetAppointment);
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

            return vetAppointments;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/28/2020
        /// Approver: Carl Davis 4/30/2020
        /// 
        /// Selects all vet appointments record by active/inactive
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="active">Active status</param>
        /// <returns>List of vet appointment</returns>
        public List<AnimalVetAppointment> SelectVetAppointmentsByActive(bool active)
        {
            List<AnimalVetAppointment> vetAppointments = new List<AnimalVetAppointment>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_animal_vet_records_by_active", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Active", active);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AnimalVetAppointment vetAppointment = new AnimalVetAppointment()
                    {
                        VetAppointmentID = reader.GetInt32(0),
                        AnimalID = reader.GetInt32(1),
                        AnimalName = reader.GetString(2),
                        AppointmentDateTime = reader.GetDateTime(3),
                        AppointmentDescription = reader.GetString(4),
                        ClinicAddress = reader.GetString(5),
                        VetName = reader.GetString(6),
                        FollowUpDateTime = reader[7] as DateTime?,
                        UserID = reader.GetInt32(8),
                        Active = reader.GetBoolean(9)
                    };
                    vetAppointments.Add(vetAppointment);
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

            return vetAppointments;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/28/2020
        /// Approver: Carl Davis 4/30/2020
        /// 
        /// Sets vet appointment to active or inactive
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="vetAppointment">Record to change</param>
        /// <param name="active">State to be changed to</param>
        /// <returns>Rows affected</returns>
        public int SetVetAppointmentActiveStatus(AnimalVetAppointment vetAppointment, bool active)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_activate_animal_vet_record", conn);
            if (!active)
            {
                cmd.CommandText = "sp_deactivate_animal_vet_record";
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AnimalVetAppointmentID", vetAppointment.VetAppointmentID);

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
        /// Creator: Ethan Murphy
        /// Created: 3/1/2020
        /// Approver: Ben Hanna, 3/6/2020
        /// Approver:
        /// 
        /// Updates an existing vet appointment record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldAnimalVetAppointment">The existing record</param>
        /// <param name="newAnimalVetAppointment">The updated record</param>
        /// <returns>Insert succesful</returns>
        public bool UpdateVetAppointment(AnimalVetAppointment oldAnimalVetAppointment, AnimalVetAppointment newAnimalVetAppointment)
        {
            bool result = false;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_vet_appointment", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AnimalVetAppointmentID", oldAnimalVetAppointment.VetAppointmentID);
            cmd.Parameters.AddWithValue("@OldAnimalID", oldAnimalVetAppointment.AnimalID);
            cmd.Parameters.AddWithValue("@OldUserID", oldAnimalVetAppointment.UserID);
            cmd.Parameters.AddWithValue("@OldAppointmentDate", oldAnimalVetAppointment.AppointmentDateTime);
            cmd.Parameters.AddWithValue("@OldAppointmentDescription", oldAnimalVetAppointment.AppointmentDescription);
            cmd.Parameters.AddWithValue("@OldClinicAddress", oldAnimalVetAppointment.ClinicAddress);
            cmd.Parameters.AddWithValue("@OldVetName", oldAnimalVetAppointment.VetName);
            cmd.Parameters.AddWithValue("@NewAnimalID", newAnimalVetAppointment.AnimalID);
            cmd.Parameters.AddWithValue("@NewUserID", newAnimalVetAppointment.UserID);
            cmd.Parameters.AddWithValue("@NewAppointmentDate", newAnimalVetAppointment.AppointmentDateTime);
            cmd.Parameters.AddWithValue("@NewAppointmentDescription", newAnimalVetAppointment.AppointmentDescription);
            cmd.Parameters.AddWithValue("@NewClinicAddress", newAnimalVetAppointment.ClinicAddress);
            cmd.Parameters.AddWithValue("@NewVetName", newAnimalVetAppointment.VetName);
            cmd.Parameters.Add("@NewFollowUpDate", SqlDbType.DateTime);
            if (newAnimalVetAppointment.FollowUpDateTime == null)
            {
                cmd.Parameters["@NewFollowUpDate"].Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters["@NewFollowUpDate"].Value = newAnimalVetAppointment.FollowUpDateTime;
            }

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }
    }
}

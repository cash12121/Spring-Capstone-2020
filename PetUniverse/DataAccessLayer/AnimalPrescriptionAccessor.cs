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
    /// Created: 2/16/2020
    /// Approver: Carl Davis 2/21/2020
    /// Approver:
    /// 
    /// A class used to access data pertaining to animal prescriptions
    /// </summary>
    public class AnimalPrescriptionAccessor : IAnimalPrescriptionsAccessor
    {
        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/16/2020
        /// Approver: Carl Davis 2/21/2020
        /// Approver:
        /// 
        /// Creates an animal prescription record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalPrescription">An AnimalPrescription object</param>
        /// <returns>Creation succesful</returns>
        public bool CreateAnimalPrescriptionRecord(AnimalPrescriptionVM animalPrescription)
        {
            bool result = false;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_create_animal_prescription_record", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AnimalID", animalPrescription.AnimalID);
            cmd.Parameters.AddWithValue("@AnimalVetAppointmentID", animalPrescription.AnimalVetAppointmentID);
            cmd.Parameters.AddWithValue("@PrescriptionName", animalPrescription.PrescriptionName);
            cmd.Parameters.AddWithValue("@Dosage", animalPrescription.Dosage);
            cmd.Parameters.AddWithValue("@MedicationInterval", animalPrescription.Interval);
            cmd.Parameters.AddWithValue("@AdministrationMethod", animalPrescription.AdministrationMethod);
            cmd.Parameters.AddWithValue("@StartDate", animalPrescription.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", animalPrescription.EndDate);
            cmd.Parameters.AddWithValue("@Description", animalPrescription.Description);

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
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Selects all animal prescription records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>List of animal prescriptions</returns>
        public List<AnimalPrescriptionVM> SelectAllAnimalPrescriptionRecords()
        {
            List<AnimalPrescriptionVM> animalPrescriptions = new List<AnimalPrescriptionVM>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_animal_prescriptions", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AnimalPrescriptionVM animalPrescription = new AnimalPrescriptionVM()
                    {
                        AnimalPrescriptionID = reader.GetInt32(0),
                        AnimalID = reader.GetInt32(1),
                        AnimalVetAppointmentID = reader.GetInt32(2),
                        PrescriptionName = reader.GetString(3),
                        Dosage = reader.GetDecimal(4),
                        Interval = reader.GetString(5),
                        AdministrationMethod = reader.GetString(6),
                        StartDate = reader.GetDateTime(7),
                        EndDate = reader.GetDateTime(8),
                        Description = reader.GetString(9),
                        AnimalName = reader.GetString(10)
                    };
                    animalPrescriptions.Add(animalPrescription);
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
            return animalPrescriptions;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/15/2020
        /// Approver: Carl Davis 3/19/2020
        /// 
        /// Updates an existing animal prescription record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldAnimalPrescription">Existing record</param>
        /// <param name="newAnimalPrescription">Record to replace the existing one</param>
        /// <returns>Update successful</returns>
        public bool UpdateAnimalPrescriptionRecord(AnimalPrescriptionVM oldAnimalPrescription,
            AnimalPrescriptionVM newAnimalPrescription)
        {
            bool result = false;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_animal_prescription", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OldAnimalPrescriptionID", oldAnimalPrescription.AnimalPrescriptionID);
            cmd.Parameters.AddWithValue("@OldAnimalID", oldAnimalPrescription.AnimalID);
            cmd.Parameters.AddWithValue("@OldAnimalVetAppointmentID", oldAnimalPrescription.AnimalVetAppointmentID);
            cmd.Parameters.AddWithValue("@OldPrescriptionName", oldAnimalPrescription.PrescriptionName);
            cmd.Parameters.AddWithValue("@OldDosage", oldAnimalPrescription.Dosage);
            cmd.Parameters.AddWithValue("@OldInterval", oldAnimalPrescription.Interval);
            cmd.Parameters.AddWithValue("@OldAdministrationMethod", oldAnimalPrescription.AdministrationMethod);
            cmd.Parameters.AddWithValue("@OldStartDate", oldAnimalPrescription.StartDate);
            cmd.Parameters.AddWithValue("@OldEndDate", oldAnimalPrescription.EndDate);
            cmd.Parameters.AddWithValue("@OldDescription", oldAnimalPrescription.Description);

            cmd.Parameters.AddWithValue("@NewAnimalID", newAnimalPrescription.AnimalID);
            cmd.Parameters.AddWithValue("@NewAnimalVetAppointmentID", newAnimalPrescription.AnimalVetAppointmentID);
            cmd.Parameters.AddWithValue("@NewPrescriptionName", newAnimalPrescription.PrescriptionName);
            cmd.Parameters.AddWithValue("@NewDosage", newAnimalPrescription.Dosage);
            cmd.Parameters.AddWithValue("@NewInterval", newAnimalPrescription.Interval);
            cmd.Parameters.AddWithValue("@NewAdministrationMethod", newAnimalPrescription.AdministrationMethod);
            cmd.Parameters.AddWithValue("@NewStartDate", newAnimalPrescription.StartDate);
            cmd.Parameters.AddWithValue("@NewEndDate", newAnimalPrescription.EndDate);
            cmd.Parameters.AddWithValue("@NewDescription", newAnimalPrescription.Description);

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
        /// Created: 4/25/2020
        /// Approver: Chuck Baxter 4/27/2020
        /// 
        /// Changes the active status of an animal prescription record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalPrescription">Record to be updated</param>
        /// <param name="active">Active status</param>
        /// <returns>Update successful</returns>
        public int ChangeAnimalPrescriptionRecordActive(AnimalPrescription animalPrescription, bool active)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_activate_prescription_record", conn);
            if (!active)
            {
                cmd = new SqlCommand("sp_deactivate_prescription_record", conn);
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AnimalPrescriptionsID", animalPrescription.AnimalPrescriptionID);

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
        /// Created: 4/26/2020
        /// Approver: Chuck Baxter 4/27/2020
        /// 
        /// Selects animal prescriptions by active/inactive status
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="active">Active status</param>
        /// <returns>List of animal prescriptions</returns>
        public List<AnimalPrescriptionVM> SelectAnimalPrescriptionsByActive(bool active)
        {
            List<AnimalPrescriptionVM> animalPrescriptions = new List<AnimalPrescriptionVM>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_animal_prescriptions_by_active", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Active", active);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AnimalPrescriptionVM animalPrescription = new AnimalPrescriptionVM()
                    {
                        AnimalPrescriptionID = reader.GetInt32(0),
                        AnimalID = reader.GetInt32(1),
                        AnimalVetAppointmentID = reader.GetInt32(2),
                        PrescriptionName = reader.GetString(3),
                        Dosage = reader.GetDecimal(4),
                        Interval = reader.GetString(5),
                        AdministrationMethod = reader.GetString(6),
                        StartDate = reader.GetDateTime(7),
                        EndDate = reader.GetDateTime(8),
                        Description = reader.GetString(9),
                        AnimalName = reader.GetString(10),
                        Active = reader.GetBoolean(11)
                    };
                    animalPrescriptions.Add(animalPrescription);
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
            return animalPrescriptions;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/25/2020
        /// Approver: Chuck Baxter 4/27/2020
        /// 
        /// Deletes an existing animal prescription record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalPrescription">Record to be deleted</param>
        /// <returns>Rows updated</returns>
        public int DeleteAnimalPrescriptionRecord(AnimalPrescriptionVM animalPrescription)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_delete_animal_prescription_record", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AnimalPrescriptionsID", animalPrescription.AnimalPrescriptionID);
            cmd.Parameters.AddWithValue("@AnimalID", animalPrescription.AnimalID);
            cmd.Parameters.AddWithValue("@AnimalVetAppointmentID", animalPrescription.AnimalVetAppointmentID);
            cmd.Parameters.AddWithValue("@PrescriptionName", animalPrescription.PrescriptionName);
            cmd.Parameters.AddWithValue("@Dosage", animalPrescription.Dosage);
            cmd.Parameters.AddWithValue("@Interval", animalPrescription.Interval);
            cmd.Parameters.AddWithValue("@Administrationmethod", animalPrescription.AdministrationMethod);
            cmd.Parameters.AddWithValue("@StartDate", animalPrescription.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", animalPrescription.EndDate);
            cmd.Parameters.AddWithValue("@Description", animalPrescription.Description);
            cmd.Parameters.AddWithValue("@Active", animalPrescription.Active);

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

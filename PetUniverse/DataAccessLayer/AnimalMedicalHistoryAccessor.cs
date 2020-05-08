using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 3/13/2020
    /// Approver: 
    /// 
    /// Class for accessing medical history  
    /// </summary>
    public class AnimalMedicalHistoryAccessor : IAnimalMedicalHistoryAccessor
    {
        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/13/2020
        /// Approver: Chuck Baxter 3/13/2020
        /// Approver: 
        /// 
        /// Gets an animals medical history
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="AnimalID"></param>
        /// <Returns>
        /// List<NewAnimalChecklist>
        /// </Returns>
        public List<MedicalHistory> GetAnimalMedicalHistoryByAnimalID(int id)
        {

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_Select_AnimalMedicalHistory_By_AnimalID");


            List<MedicalHistory> animals = new List<MedicalHistory>();


            cmd.Connection = conn;


            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@AnimalID", SqlDbType.Int);
            cmd.Parameters["@AnimalID"].Value = id;


            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var animal = new MedicalHistory();

                        animal.AnimalID = reader.GetInt32(0);
                        animal.AnimalName = reader.GetString(1);
                        animal.AnimalSpeciesID = reader.GetString(2);
                        animal.Vaccinations = reader.GetString(3);
                        animal.Spayed_Neutered = reader.GetBoolean(4);
                        animal.MostRecentVaccinationDate = reader.GetDateTime(5);
                        animal.AdditionalNotes = reader.GetString(6);







                        animals.Add(animal);
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
            return animals;
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/18/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// 
        /// Method to update an animals medical history
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <Returns>
        /// bool
        /// </Returns>
        public int UpdateAnimalMedicalHistory(MedicalHistory old_, MedicalHistory new_)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("SP_Update_Animal_Medical_History", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AnimalID", new_
                .AnimalID);

            cmd.Parameters.AddWithValue("@NewVaccinations",
                new_.Vaccinations);

            cmd.Parameters.AddWithValue("@OldVaccinations",
                old_.Vaccinations);


            cmd.Parameters.AddWithValue("@NewSpayedNeutered",
               new_.Spayed_Neutered);

            cmd.Parameters.AddWithValue("@OldSpayedNeutered",
                old_.Spayed_Neutered);

            cmd.Parameters.AddWithValue("@NewMostRecentVaccinationDate",
              new_.MostRecentVaccinationDate);

            cmd.Parameters.AddWithValue("@OldMostRecentVaccinationDate",
                old_.MostRecentVaccinationDate);

            cmd.Parameters.AddWithValue("@NewAdditionalNotes",
             new_.AdditionalNotes);

            cmd.Parameters.AddWithValue("@OldAdditionalNotes",
                old_.AdditionalNotes);


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


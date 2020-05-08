using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{

    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 2/18/2020
    /// Approver: Carl Davis, 2/21/2020
    /// Approver: Chuck Baxter, 2/21/2020
    /// 
    /// Accessor class for NewAnimalChecklist/
    /// </summary>

    public class NewAnimalChecklistAccessor : INewAnimalChecklistAccessor
    {

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/18/2020
        /// Approver: Carl Davis, 2/21/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// 
        /// Gets a new animal checklist by AnimalID
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
        public List<NewAnimalChecklist> GetNewAnimalChecklistByAnimalID(int AnimalID)
        {

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_SELECT_NewAnimalCheckList_By_AnimalID");


            List<NewAnimalChecklist> animals = new List<NewAnimalChecklist>();


            cmd.Connection = conn;


            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@AnimalID", SqlDbType.Int);
            cmd.Parameters["@AnimalID"].Value = AnimalID;


            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var animal = new NewAnimalChecklist();

                        animal.AnimalID = reader.GetInt32(0);
                        animal.AnimalName = reader.GetString(1);
                        animal.DOB = reader.GetDateTime(2);
                        animal.AnimalSpeciesID = reader.GetString(3);
                        animal.AnimalBreed = reader.GetString(4);
                        animal.ArrivalDate = reader.GetDateTime(5);
                        animal.CurrentlyHoused = reader.GetBoolean(6);
                        animal.Adoptable = reader.GetBoolean(7);
                        animal.TempermantWarning = reader.GetString(9);
                        animal.Vaccinations = reader.GetString(11);
                        animal.AdditionalNotes = reader.GetString(13);
                        animal.AnimalHandlingNotes_ = reader.GetString(8);
                        animal.Spayed_Neutered = reader.GetBoolean(10);
                        animal.MostRecentVaccinationDate = reader.GetDateTime(12);


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


    }

}
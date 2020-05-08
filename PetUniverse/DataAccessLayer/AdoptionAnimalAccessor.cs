using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Austin Gee
    /// Created: 3/5/2020
    /// Approver: Thomas Dupuy
    /// 
    /// Holds the data access methods for the AdoptionAnimalAccessor Class
    /// </summary>
    public class AdoptionAnimalAccessor : IAdoptionAnimalAccessor
    {

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/4/2020
        /// Approver: Micheal Thompson, 4/9/2020
        /// 
        /// Deactivates a chosen animal
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="animalID"></param>
        /// <returns></returns>
        public int DeactivateAdoptionAnimal(int animalID)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_deactivate_animal", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AnimalID", animalID);

            try
            {
                conn.Open();

                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/5/2020
        /// Approver: Thomas Dupuy
        /// 
        /// Selects a list of Adoption Animal VMs from the database
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<AdoptionAnimalVM> SelectAdoptionAnimalsByActive(bool active)
        {
            List<AdoptionAnimalVM> adoptionAnimalVMs = new List<AdoptionAnimalVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_adoption_animals_by_active", conn);
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
                        var adoptionAnimalVM = new AdoptionAnimalVM();

                        if (!reader.IsDBNull(0)) adoptionAnimalVM.AnimalID = reader.GetInt32(0);
                        if (!reader.IsDBNull(1)) adoptionAnimalVM.AnimalName = reader.GetString(1);
                        if (!reader.IsDBNull(2)) adoptionAnimalVM.Dob = reader.GetDateTime(2);
                        if (!reader.IsDBNull(3)) adoptionAnimalVM.AnimalBreed = reader.GetString(3);
                        if (!reader.IsDBNull(4)) adoptionAnimalVM.ArrivalDate = reader.GetDateTime(4);
                        if (!reader.IsDBNull(5)) adoptionAnimalVM.CurrentlyHoused = reader.GetBoolean(5);
                        if (!reader.IsDBNull(6)) adoptionAnimalVM.Adoptable = reader.GetBoolean(6);
                        if (!reader.IsDBNull(7)) adoptionAnimalVM.Active = reader.GetBoolean(7);
                        if (!reader.IsDBNull(8)) adoptionAnimalVM.AnimalSpeciesID = reader.GetString(8);
                        if (!reader.IsDBNull(9)) adoptionAnimalVM.AnimalKennelID = reader.GetInt32(9);
                        if (!reader.IsDBNull(10)) adoptionAnimalVM.AnimalKennelInfo = reader.GetString(10);
                        if (!reader.IsDBNull(11)) adoptionAnimalVM.AnimalMedicalInfoID = reader.GetInt32(11);
                        if (!reader.IsDBNull(12)) adoptionAnimalVM.IsSpayedorNuetered = reader.GetBoolean(12);
                        if (!reader.IsDBNull(13)) adoptionAnimalVM.AdoptionApplicationID = reader.GetInt32(13);
                        if (!reader.IsDBNull(14)) adoptionAnimalVM.CustomerEmail = reader.GetString(14);                        
                        if (!reader.IsDBNull(15)) adoptionAnimalVM.CustomerFirstName = reader.GetString(15);
                        if (!reader.IsDBNull(16)) adoptionAnimalVM.CustomerLastName = reader.GetString(16);
                        if (!reader.IsDBNull(17)) adoptionAnimalVM.AnimalHandlingNotesID = reader.GetInt32(17);
                        if (!reader.IsDBNull(18)) adoptionAnimalVM.AnimalHandlingNotes = reader.GetString(18);
                        if (!reader.IsDBNull(19)) adoptionAnimalVM.TempermentWarning = reader.GetString(19);

                        adoptionAnimalVMs.Add(adoptionAnimalVM);


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

            return adoptionAnimalVMs;
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/29/2020
        /// Approver: 
        /// 
        /// Selects a list of Adoption Animals from the database based on active and adoptable
        /// </summary>
        /// <remarks>
        /// Updater: Michael Thompson
        /// Updated: 4/29/2020
        /// Update: To book Specifications for images
        /// </remarks>
        /// <param name="active"></param>
        /// <param name="adoptable"></param>
        /// <returns></returns>
        public List<Animal> SelectAdoptionAnimalsByActiveAndAdoptable(bool active, bool adoptable)
        {
            List<Animal> adoptionAnimalVM = new List<Animal>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_adoption_animals_by_active_and_adoptable", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Active", active);
            cmd.Parameters.AddWithValue("@Adoptable", adoptable);

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var adoptionAnimal = new AdoptionAnimalVM();

                        adoptionAnimal.AnimalID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        adoptionAnimal.AnimalName = reader.IsDBNull(1) ? null : reader.GetString(1);
                        adoptionAnimal.Dob = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        adoptionAnimal.AnimalBreed = reader.IsDBNull(3) ? null : reader.GetString(3);
                        adoptionAnimal.ArrivalDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4);
                        adoptionAnimal.CurrentlyHoused = reader.IsDBNull(5) ? false : reader.GetBoolean(5);
                        adoptionAnimal.Adoptable = reader.IsDBNull(6) ? false : reader.GetBoolean(6);
                        adoptionAnimal.Active = reader.IsDBNull(7) ? false : reader.GetBoolean(7);
                        adoptionAnimal.AnimalSpeciesID = reader.IsDBNull(8) ? null : reader.GetString(8);
                        if (reader[9] != System.DBNull.Value)
                        {
                            adoptionAnimal.ProfileImageData = (byte[])reader[9];
                        }
                        if (reader.GetString(10) != null)
                        {
                            adoptionAnimal.ProfileImageMimeType = reader.GetString(10);
                        }
                        adoptionAnimal.ProfileDescription = reader.IsDBNull(11) ? null : reader.GetString(11);

                        adoptionAnimalVM.Add(adoptionAnimal);
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

            return adoptionAnimalVM;
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/29/2020
        /// Approver: 
        /// 
        /// updates an animal as adoptable or unadoptable
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="animalID"></param>
        /// <param name="adoptable"></param>
        /// <returns></returns>
        public int UpdateAnimalAdoptable(int animalID, bool adoptable)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_animal_adoptable", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AnimalID", animalID);
            cmd.Parameters.AddWithValue("@Adoptable", adoptable);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }
    }
}

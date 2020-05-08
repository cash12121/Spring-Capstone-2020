using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
// needed for provides access to classes that represent the ADO.NET architecture
using System.Data;
// needed to connect to SQL server
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Chuck Baxter
    /// Created: 2/6/2020
    /// Approver: Carl Davis, 2/7/2020
    /// Approver: Daulton Schilling, 2/7/2020
    /// 
    /// animal accessor to interact with animal data
    /// </summary>

    public class AnimalAccessor : IAnimalAccessor
    {
        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/6/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020 
        ///
        /// a data access method that uses a stored procedure to add a new animal to the database
        /// </summary>
        /// <remarks>
        /// Updater: Chuck Baxter
        /// Updated: 2/28/2020
        /// Update: Removed status and image location
        /// Approver: Austin Gee
        /// 
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animal"></param>
        /// <returns></returns>
        public int InsertAnimal(Animal animal)
        {
            int AnimalID = 0;
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_animal", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AnimalName", animal.AnimalName);
            cmd.Parameters.AddWithValue("@Dob", animal.Dob);
            cmd.Parameters.AddWithValue("@AnimalBreed", animal.AnimalBreed);
            cmd.Parameters.AddWithValue("@ArrivalDate", animal.ArrivalDate);
            cmd.Parameters.AddWithValue("@AnimalSpeciesID", animal.AnimalSpeciesID);

            try
            {
                conn.Open();
                AnimalID = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return AnimalID;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/13/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Daulton Schilling, 2/14/2020 
        /// 
        /// a data access method that uses a stored procedure to select a list of animals where the active 
        /// field is true
        /// 
        /// need to add a default imagelocation later
        /// </summary>
        /// <remarks>
        /// Updater: Chuck Baxter
        /// Updated: 2/28/2020
        /// Update: Removed status and image location
        /// Approver: Austin Gee
        /// 
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="active"></param>
        /// <returns>a list of animal objects</returns>
        public List<Animal> SelectAnimalsByActive(bool active = true)
        {
            List<Animal> animals = new List<Animal>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_active_animals");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Active", SqlDbType.Bit);
            cmd.Parameters["@Active"].Value = active;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var animal = new Animal();
                        animal.AnimalID = reader.GetInt32(0);
                        animal.AnimalName = reader.GetString(1);
                        if (reader.IsDBNull(2))
                        {
                            animal.Dob = DateTime.Parse("01/01/2020");
                        }
                        else
                        {
                            animal.Dob = reader.GetDateTime(2);
                        }
                        animal.AnimalBreed = reader.GetString(3);
                        animal.ArrivalDate = reader.GetDateTime(4);
                        animal.CurrentlyHoused = reader.GetBoolean(5);
                        animal.Adoptable = reader.GetBoolean(6);
                        animal.Active = reader.GetBoolean(7);
                        animal.AnimalSpeciesID = reader.GetString(8);

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
        /// Creator: Chuck Baxter
        /// Created: 2/19/2020
        /// Approver: Zach Behrensmeyer
        /// Approver:  
        /// 
        /// a data access method that uses a stored procedure to select a list of animals where the active 
        /// field is false
        /// 
        /// need to add a default imagelocation later
        /// </summary>
        /// <remarks>
        /// Updater: Chuck Baxter
        /// Updated: 2/28/2020
        /// Update: Removed status and image location
        /// Approver: Austin Gee
        /// 
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="active"></param>
        /// <returns>a list of animal objects</returns>
        public List<Animal> SelectAnimalsByInactive(bool active = false)
        {
            List<Animal> animals = new List<Animal>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_active_animals");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Active", SqlDbType.Bit);
            cmd.Parameters["@Active"].Value = active;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var animal = new Animal();
                        animal.AnimalID = reader.GetInt32(0);
                        animal.AnimalName = reader.GetString(1);
                        if (reader.IsDBNull(2))
                        {
                            animal.Dob = DateTime.Parse("01/01/2020");
                        }
                        else
                        {
                            animal.Dob = reader.GetDateTime(2);
                        }
                        animal.AnimalBreed = reader.GetString(3);
                        animal.ArrivalDate = reader.GetDateTime(4);
                        animal.CurrentlyHoused = reader.GetBoolean(5);
                        animal.Adoptable = reader.GetBoolean(6);
                        animal.Active = reader.GetBoolean(7);
                        animal.AnimalSpeciesID = reader.GetString(8);

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
        /// Creator: Chuck Baxter
        /// Created: 2/28/2020
        /// Approver: Jordan Lindo, 2/28/2020
        /// Approver:  
        /// 
        /// a data access method that uses a stored procedure to select a list of strings of animal species
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param></param>
        /// <returns>a list of animal objects</returns>
        public List<string> SelectAnimalSpeciesID()
        {
            List<string> species = new List<string>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_animal_species");
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
                        species.Add(reader.GetString(0));
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
            return species;
        }
        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 2/19/2020
        /// Approver: Austin Gee
        /// Approver: 
        /// 
        /// a data access method for retrieving a list of all animal profiles
        /// </summary>
        /// <remarks>
        /// Updater: Michael Thompsom
        /// Updated: 4/28/2020
        /// Update: To book specifications
        /// Approver: Austin Gee
        /// </remarks>
        /// <returns>a list of animal objects</returns>
        public List<Animal> SelectAllAnimnalProfiles()
        {
            List<Animal> animals = new List<Animal>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_animal_profiles");
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
                        var animal = new Animal();
                        animal.AnimalID = reader.GetInt32(0);
                        animal.AnimalName = reader.GetString(1);
                        if (reader[2] != System.DBNull.Value)
                        {
                            animal.ProfileImageData = (byte[])reader[2];
                        }
                        if (reader.GetString(3) != null)
                        {
                            animal.ProfileImageMimeType = reader.GetString(3);
                        }
                        animal.ProfileDescription = reader.GetString(4);

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
        /// Creator: Michael Thompson
        /// Created: 2/19/2020
        /// Checked By: Austin Gee, 2/21/2020
        /// 
        /// This method if for passing the Animal's profile description and image path to the database. It returns True if 1 row is effected
        /// It will return False if zero rows effected
        /// </summary>
        /// <remarks>
        /// Updater: Michael Thompson
        /// Updated: 4/25/2020
        /// Update: Updating to books specifications for images
        /// Approver: Austin Gee
        /// </remarks>
        /// <param name="animalID"></param>
        /// <param name="profileDescription"></param>
        /// <param name="profileImageData"></param>
        /// <param name="profileImageMimeType"></param>
        /// <returns>True if the animal was updated and false if it was not</returns>
        public bool UpdateAnimalProfile(int animalID, string profileDescription, byte[] profileImageData, string profileImageMimeType)
        {
            bool updateSuccess = false;

            // connection
            var conn = DBConnection.GetConnection();

            // cmd
            var cmd = new SqlCommand("sp_update_animal_profile");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            // parameters
            cmd.Parameters.Add("@AnimalID", SqlDbType.Int);
            cmd.Parameters.Add("@ProfileImageData", SqlDbType.VarBinary);
            cmd.Parameters.Add("@ProfileImageMimeType", SqlDbType.NVarChar, 10);
            cmd.Parameters.Add("@ProfileDescription", SqlDbType.NVarChar, 500);

            // values
            cmd.Parameters["@AnimalID"].Value = animalID;
            cmd.Parameters["@ProfileImageData"].Value = profileImageData;
            cmd.Parameters["@ProfileImageMimeType"].Value = profileImageMimeType;
            cmd.Parameters["@ProfileDescription"].Value = profileDescription;

            // execute the command
            try
            {
                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                updateSuccess = (rows == 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return updateSuccess;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/12/2020
        /// Approver: Austin Gee, 3/12/2020
        /// Approver:  
        ///
        /// a data access method that uses a stored procedure to update an animal in the database
        /// </summary>
        /// <remarks>
        /// 
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldAnimal"></param>
        /// <param name="newAnimal"></param>
        /// <returns>int</returns>
        public int UpdateAnimal(Animal oldAnimal, Animal newAnimal)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_animal", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AnimalID", oldAnimal.AnimalID);

            cmd.Parameters.AddWithValue("@OldAnimalName", oldAnimal.AnimalName);
            cmd.Parameters.AddWithValue("@OldDob", oldAnimal.Dob);
            cmd.Parameters.AddWithValue("@OldAnimalBreed", oldAnimal.AnimalBreed);
            cmd.Parameters.AddWithValue("@OldArrivalDate", oldAnimal.ArrivalDate);
            cmd.Parameters.AddWithValue("@OldAnimalSpeciesID", oldAnimal.AnimalSpeciesID);

            cmd.Parameters.AddWithValue("@NewAnimalName", newAnimal.AnimalName);
            cmd.Parameters.AddWithValue("@NewDob", newAnimal.Dob);
            cmd.Parameters.AddWithValue("@NewAnimalBreed", newAnimal.AnimalBreed);
            cmd.Parameters.AddWithValue("@NewArrivalDate", newAnimal.ArrivalDate);
            cmd.Parameters.AddWithValue("@NewAnimalSpeciesID", newAnimal.AnimalSpeciesID);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rows;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/7/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Sets the animal's Adoptable state to 'true'
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="AnimalID"> The primary key that identifies the animal. </param>
        /// <returns> A count of the rows effected by the stored procedure. 1 is considered to be a successful result. </returns>
        public int ActivateAdoptable(int AnimalID)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_set_animal_adoptable", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AnimalID", AnimalID);

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
        /// Creator: Ben Hanna
        /// Created: 2/7/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Sets the animal's Active state to 'True'
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="AnimalID"> The primary key that identifies the animal. </param>
        /// <returns> A count of the rows effected by the stored procedure. 1 is considered to be a successful result. </returns>
        public int ActivateAnimal(int AnimalID)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_reactivate_animal", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AnimalID", AnimalID);

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
        /// Creator: Ben Hanna
        /// Created: 2/7/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Set's the animal's CurrentlyHoused state to 'True'
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="AnimalID"> The primary key that identifies the animal. </param>
        /// <returns> A count of the rows effected by the stored procedure. 1 is considered to be a successful result. </returns>
        public int ActivateCurrentlyHoused(int AnimalID)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_house_animal", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AnimalID", AnimalID);

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
        /// Creator: Ben Hanna
        /// Created: 2/7/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Sets the animal's Adoptable state to 'false'
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="AnimalID"> The primary key that identifies the animal. </param>
        /// <returns> A count of the rows effected by the stored procedure. 1 is considered to be a successful result. </returns>
        public int DeactivateAdoptable(int AnimalID)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_deset_animal_adoptable", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AnimalID", AnimalID);

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
        /// Creator: Ben Hanna
        /// Created: 2/7/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Sets the animal's Active state to 'false'
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="AnimalID"> The primary key that identifies the animal. </param>
        /// <returns> A count of the rows effected by the stored procedure. 1 is considered to be a successful result. </returns>
        public int DeactivateAnimal(int AnimalID)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_deactivate_animal", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AnimalID", AnimalID);

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
        /// Creator: Ben Hanna
        /// Created: 2/7/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Set's the animal's CurrentlyHoused state to 'True'
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="AnimalID"> The primary key that identifies the animal. </param>
        /// <returns> A count of the rows effected by the stored procedure. 1 is considered to be a successful result. </returns>
        public int DeactivateCurrentlyHoused(int AnimalID)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_dehouse_animal", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AnimalID", AnimalID);

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
        /// Creator: Daulton Schilling
        /// Created: 4/12/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// Gets a list of animal names
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <returns>List of animal names</returns>
        public List<AnimalNames> GetNames()
        {
            List<AnimalNames> name = new List<AnimalNames>(20);
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_Names");
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
                        AnimalNames names = new AnimalNames();

                        names.AnimalName = reader.GetString(0) + "                    ";//-Small bug

                        names.AnimalID = reader.GetInt32(1);


                        name.Add(names);
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
            return name;
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 4/12/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// Gets an animal by its ID number
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="ID"></param>
        /// <returns>List of animal attributes</returns>
        public List<Animal> GetAnimalByAnimalID(int ID)
        {
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_Select_Animal_By_AnimalID");

            List<Animal> animals = new List<Animal>();

            cmd.Connection = conn;

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@AnimalID", SqlDbType.Int);
            cmd.Parameters["@AnimalID"].Value = ID;
            conn.Open();
            var reader = cmd.ExecuteReader();

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var animal = new Animal();

                        animal.AnimalID = reader.GetInt32(0);
                        animal.Dob = reader.GetDateTime(2);
                        animal.AnimalName = reader.GetString(1);
                        animal.AnimalSpeciesID = reader.GetString(3);
                        animal.AnimalBreed = reader.GetString(4);
                        animal.ArrivalDate = reader.GetDateTime(5);

                        animal.CurrentlyHoused = reader.GetBoolean(6);
                        animal.Adoptable = reader.GetBoolean(7);
                        animal.Active = reader.GetBoolean(8);


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
        /// Creator: Michael Thompson
        /// Created: 4/27/2020
        /// Approver: Austin Gee
        /// 
        /// Gets an single animal by its ID
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// Approver: 
        /// </remarks>
        /// <param name="ID"> The primary key that identifies the animal. </param>
        /// <returns> An animal Object with that animalID </returns>
        public Animal GetOneAnimalByAnimalID(int ID)
        {
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_select_animal_profile_by_animalid");

            Animal animal = new Animal();

            cmd.Connection = conn;

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@AnimalID", SqlDbType.Int);
            cmd.Parameters["@AnimalID"].Value = ID;
            conn.Open();
            var reader = cmd.ExecuteReader();

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        animal.AnimalID = reader.GetInt32(0);
                        animal.AnimalName = reader.GetString(1);
                        if (reader[2] != System.DBNull.Value)
                        {
                            animal.ProfileImageData = (byte[])reader[2];
                        }
                        if (reader.GetString(3) != null)
                        {
                            animal.ProfileImageMimeType = reader.GetString(3);
                        }
                        animal.ProfileDescription = reader.GetString(4);
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
            return animal;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/13/2020
        /// Approver: Carl Davis, 3/18/2020 
        /// Approver: 
        ///
        /// a data access method that uses a stored procedure to add a new animal species to the database
        /// </summary>
        /// <remarks>
        /// 
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animal"></param>
        /// <returns>int</returns>
        public int InsertAnimalSpecies(string animalSpecies, string description)
        {
            int speciesID = 0;
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_animal_species", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AnimalSpeciesID", animalSpecies);
            cmd.Parameters.AddWithValue("@Description", description);

            try
            {
                conn.Open();
                speciesID = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return speciesID;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/18/2020 
        /// Approver: 
        ///
        /// a data access method that uses a stored procedure to delete an animal species from the database
        /// </summary>
        /// <remarks>
        /// 
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalSpeciesID"></param>
        /// <returns>int</returns
        public int DeleteAnimalSpecies(string animalSpeciesID)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_delete_animal_species", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AnimalSpeciesID", animalSpeciesID);

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
        /// Creator: Chuck Baxter
        /// Created: 3/18/2020
        /// Approver: Carl Davis, 3/18/2020 
        /// Approver: 
        ///
        /// a data access method that uses a stored procedure to update an animal species in the database
        /// </summary>
        /// <remarks>
        /// 
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldAnimalSpeciesID"></param>
        /// <param name="newAnimalSpeciesID"></param>
        /// <param name="description"></param>
        /// <returns>int</returns
        public int UpdateAnimalSpecies(string oldAnimalSpeciesID, string newAnimalSpeciesID, string description)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_animal_species", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OldAnimalSpeciesID", oldAnimalSpeciesID);
            cmd.Parameters.AddWithValue("@NewAnimalSpeciesID", newAnimalSpeciesID);
            cmd.Parameters.AddWithValue("@NewDescription", description);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rows;
        }
    }
}

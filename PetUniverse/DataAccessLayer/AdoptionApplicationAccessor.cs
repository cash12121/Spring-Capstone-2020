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
    /// DATE: 3/19/2020
    /// CHECKED BY: Michael Thompson
    /// 
    /// Interface that contains methods that relate to adoption application
    /// data access methods
    /// </summary>
    public class AdoptionApplicationAccessor : IAdoptionApplicationAccessor
    {

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/22/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Deactivates an adoption apllication
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="adoptionApplicationID"></param>
        /// <returns></returns>
        public int DeactivateAdoptionApplication(int adoptionApplicationID)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_deactivate_adoption_application", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AdoptionApplicationID", adoptionApplicationID);
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
        /// NAME: Austin Gee
        /// DATE: 4/28/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Deactivates an adoption apllication
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public int InsertAdoptionApplication(Application application)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_adoption_application", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CustomerEmail", application.CustomerEmail);
            cmd.Parameters.AddWithValue("@AnimalID", application.AnimalID);
            cmd.Parameters.AddWithValue("@Status", application.Status);
            cmd.Parameters.AddWithValue("@RecievedDate", application.RecievedDate);
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
        /// NAME: Austin Gee
        /// DATE: 4/11/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Selects an Adoption Applications by ID from the database
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="adoptionApplicationID"></param>
        /// <returns></returns>
        public ApplicationVM SelectAdoptionApplicationByID(int adoptionApplicationID)
        {
            var adoptionApplication = new ApplicationVM();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_adoption_application_by_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AdoptionApplicationID", adoptionApplicationID);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    adoptionApplication = new ApplicationVM()
                    {
                        AdoptionApplicationID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        CustomerEmail = reader.IsDBNull(1) ? null : reader.GetString(1),
                        AnimalID = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                        Status = reader.IsDBNull(3) ? null : reader.GetString(3),
                        RecievedDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4),
                        AnimalName = reader.IsDBNull(5) ? null : reader.GetString(5),
                        AnimalSpeciesID = reader.IsDBNull(6) ? null : reader.GetString(6),
                        AnimalBreed = reader.IsDBNull(7) ? null : reader.GetString(7),
                        AnimalActive = reader.IsDBNull(8) ? false : reader.GetBoolean(8),
                        ApplicationActive = reader.IsDBNull(9) ? false : reader.GetBoolean(9)

                    };
                }
            }
            catch (Exception)
            {

                throw;
            }
            return adoptionApplication;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 5/1/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Selects an Adoption Applications by ID from the database
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<ApplicationVM> SelectAdoptionApplicationsByActive(bool active)
        {
            var adoptionApplications = new List<ApplicationVM>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_adoption_applications_by_active", conn);
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
                        var application = new ApplicationVM()
                        {
                            AdoptionApplicationID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            CustomerEmail = reader.IsDBNull(1) ? null : reader.GetString(1),
                            AnimalID = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                            Status = reader.IsDBNull(3) ? null : reader.GetString(3),
                            RecievedDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4),
                            AnimalName = reader.IsDBNull(5) ? null : reader.GetString(5),
                            AnimalSpeciesID = reader.IsDBNull(6) ? null : reader.GetString(6),
                            AnimalBreed = reader.IsDBNull(7) ? null : reader.GetString(7),
                            AnimalActive = reader.IsDBNull(8) ? false : reader.GetBoolean(8)
                        };

                        adoptionApplications.Add(application);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return adoptionApplications;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 5/4/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Selects an Adoption Applications by active from the database
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<ApplicationNameVM> SelectAdoptionApplicationsByActiveWithName(bool active)
        {
            var adoptionApplications = new List<ApplicationNameVM>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_adoption_applications_by_active", conn);
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
                        var application = new ApplicationNameVM()
                        {
                            AdoptionApplicationID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            CustomerEmail = reader.IsDBNull(1) ? null : reader.GetString(1),
                            AnimalID = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                            Status = reader.IsDBNull(3) ? null : reader.GetString(3),
                            RecievedDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4),
                            AnimalName = reader.IsDBNull(5) ? null : reader.GetString(5),
                            AnimalSpeciesID = reader.IsDBNull(6) ? null : reader.GetString(6),
                            AnimalBreed = reader.IsDBNull(7) ? null : reader.GetString(7),
                            AnimalActive = reader.IsDBNull(8) ? false : reader.GetBoolean(8),
                            ApplicationActive = reader.IsDBNull(9) ? false : reader.GetBoolean(9),
                            FirstName = reader.IsDBNull(10) ? null : reader.GetString(10),
                            LastName = reader.IsDBNull(11) ? null : reader.GetString(11)

                        };

                        adoptionApplications.Add(application);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return adoptionApplications;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/19/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Selects a list of Adoption Applications by email from the database
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="email"></param>
        /// <returns></returns>
        public List<ApplicationVM> SelectAdoptionApplicationsByEmail(string email, bool active)
        {
            var adoptionApplications = new List<ApplicationVM>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_adoption_applications_by_email_and_active", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Active", active);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var application = new ApplicationVM()
                        {
                            AdoptionApplicationID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            CustomerEmail = reader.IsDBNull(1) ? null : reader.GetString(1),
                            AnimalID = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                            Status = reader.IsDBNull(3) ? null : reader.GetString(3),
                            RecievedDate = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4),
                            AnimalName = reader.IsDBNull(5) ? null : reader.GetString(5),
                            AnimalSpeciesID = reader.IsDBNull(6) ? null : reader.GetString(6),
                            AnimalBreed = reader.IsDBNull(7) ? null : reader.GetString(7),
                            AnimalActive = reader.IsDBNull(8) ? false : reader.GetBoolean(8)
                        };

                        adoptionApplications.Add(application);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return adoptionApplications;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 5/2/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Updates an adoption application
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="oldApplication"></param>
        /// <param name="newApplication"></param>
        /// <returns></returns>
        public int UpdateAdoptionApplication(Application oldApplication, Application newApplication)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_adoption_application", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AdoptionApplicationID", oldApplication.AdoptionApplicationID);
            cmd.Parameters.AddWithValue("@OldCustomerEmail", oldApplication.CustomerEmail);
            cmd.Parameters.AddWithValue("@OldAnimalID", oldApplication.AnimalID);
            cmd.Parameters.AddWithValue("@OldStatus", oldApplication.Status);
            cmd.Parameters.AddWithValue("@OldRecievedDate", oldApplication.RecievedDate);
            cmd.Parameters.AddWithValue("@OldActive", oldApplication.ApplicationActive);

            cmd.Parameters.AddWithValue("@NewCustomerEmail", newApplication.CustomerEmail);
            cmd.Parameters.AddWithValue("@NewAnimalID", newApplication.AnimalID);
            cmd.Parameters.AddWithValue("@NewStatus", newApplication.Status);
            cmd.Parameters.AddWithValue("@NewRecievedDate", newApplication.RecievedDate);
            cmd.Parameters.AddWithValue("@NewActive", newApplication.ApplicationActive);
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

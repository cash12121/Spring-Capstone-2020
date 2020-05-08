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
    /// DATE: 2/6/2020
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
    public class AdoptionCustomerAccessor : IAdoptionCustomerAccessor
    {

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/28/2020
        /// CHECKED BY: 
        /// 
        /// This method inserts a customer
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="customer"></param>
        /// <returns></returns>
        public int InsertAdoptionCustomer(AdoptionCustomer customer)
        {
            int rows = 0;
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_customer", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Email", customer.CustomerEmail);
            cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
            cmd.Parameters.AddWithValue("@LastName", customer.LastName);
            cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
            cmd.Parameters.AddWithValue("@addressLineOne", customer.AddressLineOne);
            cmd.Parameters.AddWithValue("@addressLineTwo", customer.AddressLineTwo);
            cmd.Parameters.AddWithValue("@City", customer.City);
            cmd.Parameters.AddWithValue("@State", customer.State);
            cmd.Parameters.AddWithValue("@Zipcode", customer.Zipcode);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteNonQuery();
                
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
        /// DATE: 3/18/2020
        /// CHECKED BY: Mohamed Elamin, 02/07/2020
        /// 
        /// This method retrieves an AdoptionCustomerVM from the database and returns it.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="email"></param>
        /// <returns></returns>
        public AdoptionCustomerVM SelectAdoptionCustomerByEmail(string email)
        {
            var adoptionCustomer = new AdoptionCustomerVM();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_customer_by_email", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Email", email);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    adoptionCustomer.FirstName = reader.GetString(0);
                    adoptionCustomer.LastName = reader.GetString(1);
                    adoptionCustomer.PhoneNumber = reader.IsDBNull(2) ? null : reader.GetString(2);
                    adoptionCustomer.Email = reader.GetString(3);
                    adoptionCustomer.Active = reader.GetBoolean(4);
                    adoptionCustomer.AddressLineOne = reader.GetString(5);
                    adoptionCustomer.AddressLineTwo = reader.IsDBNull(6) ? null : reader.GetString(6);
                    adoptionCustomer.City = reader.GetString(7);
                    adoptionCustomer.State = reader.GetString(8);
                    adoptionCustomer.ZipCode = reader.GetString(9);
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

            return adoptionCustomer;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/6/2020
        /// CHECKED BY: Mohamed Elamin, 02/07/2020
        /// 
        /// This method retrieves a list of AdoptionCustomerVMs from the database and returns it.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<AdoptionCustomerVM> SelectAdoptionCustomersByActive(bool active)
        {
            List<AdoptionCustomerVM> adoptionCustomers = new List<AdoptionCustomerVM>();
            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_adoption_customers_by_active", conn);
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
                        AdoptionCustomerVM adoptionCustomer = new AdoptionCustomerVM();

                        //adoptionCustomer.PUUserID = reader.GetInt32(0);
                        adoptionCustomer.FirstName = reader.GetString(0);
                        adoptionCustomer.LastName = reader.GetString(1);
                        adoptionCustomer.PhoneNumber = reader.IsDBNull(2) ? null : reader.GetString(2);
                        adoptionCustomer.Email = reader.GetString(3);
                        adoptionCustomer.Active = reader.GetBoolean(4);
                        adoptionCustomer.AddressLineOne = reader.GetString(5);
                        adoptionCustomer.AddressLineTwo = reader.IsDBNull(6) ? null : reader.GetString(6);
                        adoptionCustomer.City = reader.GetString(7);
                        adoptionCustomer.State = reader.GetString(8);
                        adoptionCustomer.ZipCode = reader.GetString(9);
                        //adoptionCustomer.CustomerID = reader.GetInt32(9);
                        //adoptionCustomer.AnimalID = reader.GetInt32(10);
                        //adoptionCustomer.CustomerAdoptionStatus = reader.GetString(11);
                        //adoptionCustomer.AdoptionApplicationRecievedDate = reader.GetDateTime(12);
                        //adoptionCustomer.AnimalName = reader.GetString(13);
                        //adoptionCustomer.AnimalBreed = reader.GetString(14);
                        //adoptionCustomer.AnimalArrivalDate = reader.GetDateTime(15);
                        //adoptionCustomer.CurrentlyHoused = reader.GetBoolean(16);
                        //adoptionCustomer.Adoptable = reader.GetBoolean(17);
                        //adoptionCustomer.AnimalActive = reader.GetBoolean(18);
                        //adoptionCustomer.AdoptionApplicationID = reader.GetInt32(19);
                        //adoptionCustomer.AnimalSpecies = reader.GetString(20);

                        adoptionCustomers.Add(adoptionCustomer);
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

            return adoptionCustomers;
        }
    }
}

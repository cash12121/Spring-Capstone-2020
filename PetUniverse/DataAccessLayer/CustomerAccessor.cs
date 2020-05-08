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
    /// Created: 2020/02/19
    /// Approver: Thomas Dupuy ,2020/02/19
    ///
    /// This Class for accessing Customer data in the database.
    /// </summary>
    public class CustomerAccessor : ICustomerAccessor
    {
        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver:Thomas Dupuy ,2020/02/21
        /// 
        /// This method used to get  a Customer by Customer's last name.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=" customerName"></param>
        /// <returns>customer</returns>
        public Customer RetrieveCustomerByCustomerEmail(string customerEmail)
        {
            Customer customer = null;
            // connection
            var conn = DBConnection.GetConnection();
            // commands
            var cmd = new SqlCommand("sp_select_Customer_by_Customer_Email", conn);
            // command type
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@customerEmail", SqlDbType.NVarChar, 250);
            cmd.Parameters["@customerEmail"].Value = customerEmail;
            try
            {
                // open the connection
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        customer = new Customer();

                        customer.Email = reader.GetString(0);
                        customer.FirstName = reader.GetString(1);
                        customer.LastName = reader.GetString(2);
                        customer.PhoneNumber = reader.GetString(3);
                        customer.AddressLineOne = reader.GetString(4);
                        customer.AddressLineTwo = reader.GetString(5);
                        customer.City = reader.GetString(6);
                        customer.State = reader.GetString(7);
                        customer.ZipCode = reader.GetString(8);
                        customer.Active = reader.GetBoolean(9);
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
                // Close the connection 
                conn.Close();
            }
            return customer;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/17/2020
        /// Approver: Steven Cardona
        ///
        /// Accessor method signature for selecting all active customers
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>Returns a list of active customers</returns>
        public List<Customer> SelectAllActiveCustomers()
        {
            List<Customer> customers = new List<Customer>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_active_customers", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    customers.Add(new Customer()
                    {
                        Email = reader.GetString(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        PhoneNumber = reader.GetString(3),
                        AddressLineOne = reader.GetString(4),
                        AddressLineTwo = reader.IsDBNull(5) ? null : reader.GetString(5),
                        City = reader.GetString(6),
                        State = reader.GetString(7),
                        ZipCode = reader.GetString(8),
                        Active = reader.GetBoolean(9)
                    });
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
            return customers;
        }

        /// <summary>
        /// NAME: Zach Behrensmeyer
        /// DATE: 4/25/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This method is used to authenticate the customer and make sure they exist for login
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// CHANGE:
        /// </remarks>
        /// <param name="username"></param>
        /// <param name="passwordHash"></param>
        /// <returns></returns>
        public Customer AuthenticateCustomer(string username, string passwordHash)
        {
            Customer result = null;

            //Get a connection
            var conn = DBConnection.GetConnection();

            //Call the sproc
            var cmd = new SqlCommand("sp_authenticate_customer");
            cmd.Connection = conn;

            //Set the command type
            cmd.CommandType = CommandType.StoredProcedure;

            //Create the parameters
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 250);
            cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 100);

            //Set the parameters
            cmd.Parameters["@Email"].Value = username;
            cmd.Parameters["@PasswordHash"].Value = passwordHash;

            try
            {
                conn.Open();

                if (1 == Convert.ToInt32(cmd.ExecuteScalar()))
                {
                    //Check the db for the given email
                    result = RetrieveCustomerByCustomerEmail(username);
                }
                else
                {
                    throw new ApplicationException("Customer not found.");
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
            return result;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 04/129/2020
        /// Approver: Steven Cardona
        ///
        /// This method connects to the database and inserts a customer
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// CHANGE:
        /// </remarks>
        /// <param name="customer"></param>
        /// <returns></returns>
        public bool InsertNewCustomer(Customer customer)
        {
            bool isInserted = false;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_customer", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
            cmd.Parameters.AddWithValue("@LastName", customer.LastName);
            cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", customer.Email);
            cmd.Parameters.AddWithValue("@Address1", customer.AddressLineOne);
            cmd.Parameters.AddWithValue("@Address2", customer.AddressLineTwo);
            cmd.Parameters.AddWithValue("@City", customer.City);
            cmd.Parameters.AddWithValue("@State", customer.State);
            cmd.Parameters.AddWithValue("@Zipcode", customer.ZipCode);

            try
            {
                conn.Open();
                isInserted = 1 == cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return isInserted;
        }
    }
}

using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/19
    /// Approver: Thomas Dupuy , 2020/02/21
    ///
    /// This Class manage Customer logic, and implements the 
    /// IHomeInspectorManager Interface
    /// </summary>
    public class CustomerManager : ICustomerManager
    {
        private ICustomerAccessor _customerAccessor;

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Thomas Dupuy , 2020/02/19
        /// 
        /// This a constructor method for the Customer 
        /// Manager class.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public CustomerManager()
        {
            _customerAccessor = new CustomerAccessor();

        }
        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Thomas Dupuy , 2020/02/19
        /// 
        /// This method is a constructor for the Customer 
        /// Manager.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="ICustomerAccessor"></param>
        /// <param name="customerAccessor"></param>
        /// <returns></returns>
        public CustomerManager(ICustomerAccessor customerAccessor)
        {
            _customerAccessor = customerAccessor;

        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Thomas Dupuy , 2020/02/19
        /// 
        /// This method gets a Customer by the Customer email
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="customerEmail"></param>
        /// <returns>Customer </returns>
        public Customer RetrieveCustomerByCustomerEmail(string customerEmail)
        {
            Customer customer = null;
            try
            {
                customer = _customerAccessor.RetrieveCustomerByCustomerEmail(customerEmail);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("customer not Found", ex);
            }

            return customer;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 04/25/2020
        /// Approver: Steven Cardona
        /// 
        /// Manager Method to retrieve Customers by email that returns a boolean
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool FindCustomer(string email)
        {
            try
            {
                return _customerAccessor.RetrieveCustomerByCustomerEmail(email) != null;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Database Error", ex);
            }
        }


        /// <summary>
        /// Creator : Zach Behrensmeyer
        /// Created: 2/3/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method hashes the given password
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="source"></param>
        /// <returns>Hashed Password</returns>
        private string hashPassword(string source)
        {
            string result = null;

            // we need a byte array because cryptography is bits and bytes
            byte[] data;

            using (SHA256 sha256hash = SHA256.Create())
            {
                // This part hashes the input
                data = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(source));
            }
            // builds a new string from the result
            var s = new StringBuilder();

            // loops through bytes to build the string
            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }
            result = s.ToString().ToUpper();
            return result;
        }

        /// <summary>
        /// Creator : Zach Behrensmeyer
        /// Created: 4/25/2020
        /// Approver: Steven Cardona
        /// 
        /// This calls the User Authentication Data Accessor Method for customers
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>Returns Valid User Info</returns>
        public Customer AuthenticateCustomer(string email, string password)
        {
            Customer result = null;
            var passwordHash = hashPassword(password);
            password = null;

            try
            {
                result = _customerAccessor.AuthenticateCustomer(email, passwordHash);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Login failed!", ex);
            }
            return result;
        }
        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/17/2020
        /// Approver: Steven Cardona
        ///
        /// Manager method to get all active customers
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>Returns a list of active PetUniverseUsers</returns>
        public List<Customer> RetrieveAllActiveCustomers()
        {
            List<Customer> customers = new List<Customer>();

            try
            {
                customers = _customerAccessor.SelectAllActiveCustomers();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No Customers Found", ex);
            }
            return customers;
        }
    }
}

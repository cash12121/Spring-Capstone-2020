using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 02/19/2020
    /// Approver:Thomas Dupuy, 02/21/2020
    ///
    /// This Class is for creating  fake Customer data which will be used 
    /// for testing Logic layer public methods.
    /// </summary>
    public class FakeCustomerAccessor : ICustomerAccessor
    {

        private List<Customer> customers = null;
        private Customer customer = new Customer();

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 02/19/2020
        /// Approver: Thomas Dupuy, 02/21/2020
        /// 
        /// This method will get fake Customer when whene it called. 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        /// <returns>Fack customers</returns>
        public FakeCustomerAccessor()
        {
            customers = new List<Customer>()
            {
                new Customer()
                {
                    FirstName = "John",
                    LastName = "Elamin",
                    PhoneNumber = "3192098622",
                    Email = "john@hotmail.com",
                    AddressLineOne = "12 us street SW",
                    AddressLineTwo = "Apt2",
                    ZipCode = "53987",
                    State = "NY",
                    City = "london",
                    Active = true
                },

                new Customer()
                {
                    FirstName = "Ali",
                    LastName = "Ahmed",
                    PhoneNumber = "3193762955",
                    Email = "ali@hotmail.com",
                    AddressLineOne = "12 kirkwood street SW",
                    AddressLineTwo = "Apt1",
                    ZipCode = "52487",
                    State = "IA",
                    City = "cedar rapids",
                    Active = true
                },

                new Customer()
                {
                    FirstName = "Zaic",
                    LastName = "kamal",
                    PhoneNumber = "9299556722",
                    Email = "zaic@hotmail.com",
                    AddressLineOne = "12 k street SW",
                    AddressLineTwo = "Apt4",
                    ZipCode = "50987",
                    State = "IA",
                    City = "cedar rapids",
                    Active = true
                }
            };
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/25/2020
        /// Approver: Steven Cardona
        /// 
        /// This fake method is called to get a fake customer
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks> 
        /// <param name="username"></param>
        /// <param name="passwordHash"></param>
        /// <returns></returns>
        public Customer AuthenticateCustomer(string username, string passwordHash)
        {
            bool userName = username.Equals("j.doe@RandoGuy.com");
            bool hash = passwordHash.Equals("A7574A42198B7D7EEE2C037703A0B95558F195457908D6975E681E2055FD5EB9");

            if (userName && hash)
            {
                customer = new Customer()
                {
                    Email = "j.doe@RandoGuy.com",
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNumber = "5632102101",
                    Active = true,
                    City = "Cedar Rapids",
                    State = "IA",
                    ZipCode = "52404"
                };
                return customer;
            }
            else
            {
                throw new ApplicationException("Invalid User");
            }
        }

        public bool InsertNewCustomer(Customer customer)
        {
            return true;
        }


        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 02/19/2020
        /// Approver: Thomas Dupuy, 02/21/2020
        /// 
        /// This fake method is called to get a fake Customer which has the same 
        /// passed last name. 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="customerName"></param>
        /// <returns>fake customer</returns>
        public Customer RetrieveCustomerByCustomerEmail(string customerEmail)
        {
            Customer _customer = new Customer();
            foreach (var customer in customers)
            {
                if (customer.Email == customerEmail)
                {
                    _customer = customer;
                    break;
                }
            }
            return _customer;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/17/2020
        /// Approver: Steven Cardona
        ///
        /// Data Access Face for selecting all active customers.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks> 
        /// <returns>Returns a list of Customers</returns>
        public List<Customer> SelectAllActiveCustomers()
        {
            List<Customer> customers = new List<Customer>()
            {
                new Customer()
                {
                    Email = "test1@PetUniverse.com",
                    FirstName = "Test1",
                    LastName = "Test1",
                    PhoneNumber = "5632341221",
                    AddressLineOne = "Test Address",
                    AddressLineTwo = "Test Address",
                    City = "Cedar Rapids",
                    State = "IA",
                    ZipCode = "52406",
                    Active = true
                },

                new Customer()
                {
                    Email = "test1@PetUniverse.com",
                    FirstName = "Test1",
                    LastName = "Test1",
                    PhoneNumber = "5632341221",
                    AddressLineOne = "Test Address",
                    AddressLineTwo = "Test Address",
                    City = "Cedar Rapids",
                    State = "IA",
                    ZipCode = "52406",
                    Active = true
                },

                new Customer()
                {
                    Email = "test1@PetUniverse.com",
                    FirstName = "Test1",
                    LastName = "Test1",
                    PhoneNumber = "5632341221",
                    AddressLineOne = "Test Address",
                    AddressLineTwo = "Test Address",
                    City = "Cedar Rapids",
                    State = "IA",
                    ZipCode = "52406",
                    Active = true
                }
            };

            customers = (from user in customers
                         where user.Active == true
                         select user).ToList();

            return customers;
        }
    }
}

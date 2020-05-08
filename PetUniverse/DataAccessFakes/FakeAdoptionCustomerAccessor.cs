using DataAccessInterfaces;
using DataTransferObjects;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DataAccessFakes
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 2/6/2020
    /// CHECKED BY: Mohamed Elamin, 02/07/2020
    /// 
    /// This class contains Data Access fakes for data pertaining to Adoption Customers.
    /// </summary>
    public class FakeAdoptionCustomerAccessor : IAdoptionCustomerAccessor
    {
        private List<AdoptionCustomerVM> adoptionCustomerVMs;
        private List<AdoptionCustomer> adoptionCustomers;

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/6/2020
        /// CHECKED BY: Mohamed Elamin, 02/07/2020
        /// 
        /// This method returns a Faked list of AdoptionCustomerVM's much the same way a data access object would.
        /// it is important to not that this method is used exclusively for unit testing and test driven development
        /// purposes.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: Zach Behrensmeyer
        /// UPDATE DATE: 4/9/2020
        /// WHAT WAS CHANGED: Removed commented out code
        /// 
        /// </remarks>
        public FakeAdoptionCustomerAccessor()
        {
            adoptionCustomerVMs = new List<AdoptionCustomerVM>()
            {
                new AdoptionCustomerVM()
                {
                    City = "City",
                    Email = "Fake@Fake.com",
                    FirstName = "Fake Customer First Name",
                    LastName = "Fake Customer Last Name",
                    PhoneNumber = "1234567890",
                    State = "FS",
                    Active = true,
                    ZipCode = "12345"
                }
            };

            adoptionCustomers = new List<AdoptionCustomer>
            {
                new AdoptionCustomer
                {
                    CustomerEmail = "Fake1@fake.com",
                    FirstName = "Fake",
                    LastName = "Fake",
                    PhoneNumber = "1110002222",
                    AddressLineOne = "Fake",
                    AddressLineTwo = "Fake",
                    City = "Fake",
                    State = "Fake",
                    Zipcode = "Fake",
                    Active = true
                },
                new AdoptionCustomer
                {
                    CustomerEmail = "Fake2@fake.com",
                    FirstName = "Fake",
                    LastName = "Fake",
                    PhoneNumber = "1110002222",
                    AddressLineOne = "Fake",
                    AddressLineTwo = "Fake",
                    City = "Fake",
                    State = "Fake",
                    Zipcode = "Fake",
                    Active = true
                },
                new AdoptionCustomer
                {
                    CustomerEmail = "Fake3@fake.com",
                    FirstName = "Fake",
                    LastName = "Fake",
                    PhoneNumber = "1110002222",
                    AddressLineOne = "Fake",
                    AddressLineTwo = "Fake",
                    City = "Fake",
                    State = "Fake",
                    Zipcode = "Fake",
                    Active = true
                }
            };
        }

        public int InsertAdoptionCustomer(AdoptionCustomer customer)
        {
            int rows = 0;
            try
            {
                adoptionCustomers.Add(customer);
                rows += 1;
            }
            catch (Exception)
            {

                throw ;
            }
            return rows;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/18/2020
        /// CHECKED BY: 
        /// 
        /// This method returns an adoptionCustomerVM that has a matching email
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
            return (from a in adoptionCustomerVMs
                    where a.Email == email
                    select a).First();
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/6/2020
        /// CHECKED BY: Mohamed Elamin, 02/07/2020
        /// 
        /// This class contains Data Access fakes for data pertaining to Adoption Customers.
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
            return (from a in adoptionCustomerVMs
                    where a.Active == true
                    select a).ToList();
        }
    }
}

using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LogicLayerTests
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 2/6/2020
    /// CHECKED BY: Mohamed Elamin, 02/07/2020
    /// 
    /// This class is used to unit test the AdopterCustomerManager
    /// </summary>

    [TestClass]
    public class AdoptionCustomerManagerTests
    {
        private IAdoptionCustomerAccessor _adoptionCustomerAccessor;


        public AdoptionCustomerManagerTests()
        {
            _adoptionCustomerAccessor = new FakeAdoptionCustomerAccessor();
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/6/2020
        /// CHECKED BY: Mohamed Elamin, 02/07/2020
        /// 
        /// This test method tests the RetriveAdoptionCustomersByActive method that is a part of the AdoptionCustomerManager class.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAdoptionCustomerRetrievesActiveAdoptionCustomers()
        {
            // arrange
            List<AdoptionCustomerVM> adoptionCustomerVMs;
            IAdoptionCustomerManager adoptionCustomerManager = new AdoptionCustomerManager(_adoptionCustomerAccessor);

            // act
            adoptionCustomerVMs = adoptionCustomerManager.RetrieveAdoptionCustomersByActive(true);

            // assert
            Assert.AreEqual(1, adoptionCustomerVMs.Count);
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/18/2020
        /// CHECKED BY: 
        /// 
        /// This test method tests the RetriveAdoptionCustomerByEmail method that is a part of the AdoptionCustomerManager class.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAdoptionCustomerRetrievesAdoptionCustomerByEmail()
        {
            // arrange
            AdoptionCustomerVM adoptionCustomerVM;
            IAdoptionCustomerManager adoptionCustomerManager = new AdoptionCustomerManager(_adoptionCustomerAccessor);

            // act
            adoptionCustomerVM = adoptionCustomerManager.RetrieveAdoptionCustomerByEmail("Fake@Fake.com");

            // assert
            Assert.AreEqual("Fake@Fake.com", adoptionCustomerVM.Email);
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 4/28/2020
        /// CHECKED BY: 
        /// 
        /// This test method tests the AddCustomer method that is a part of the AdoptionCustomerManager class.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAdoptionCustomerAddAdoptionCustomer()
        {
            // arrange
            IAdoptionCustomerManager adoptionCustomerManager = new AdoptionCustomerManager(_adoptionCustomerAccessor);

            var customer = new AdoptionCustomer
            {
                CustomerEmail = "Fake4@fake.com",
                FirstName = "Fake",
                LastName = "Fake",
                PhoneNumber = "1110002222",
                AddressLineOne = "Fake",
                AddressLineTwo = "Fake",
                City = "Fake",
                State = "Fake",
                Zipcode = "Fake",
                Active = true
            };

            // act
            int rows = _adoptionCustomerAccessor.InsertAdoptionCustomer(customer);

            // assert
            Assert.AreEqual(1, rows);
        }
    }
}

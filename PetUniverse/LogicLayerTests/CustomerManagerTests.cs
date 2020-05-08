using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/19
    /// Approver: Thomas Dupuy , 2020/02/21
    ///
    /// This Class for testing all public methods int the Customer Manager class.
    ///
    /// </summary>
    [TestClass]
    public class CustomerManagerTests
    {
        private ICustomerAccessor _fakeCustomerAccessor;
        private CustomerManager _customerManager;

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Thomas Dupuy ,2020/02/21
        /// 
        /// This is the Setup for tests.
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
        [TestInitialize]
        public void TestSetup()
        {
            _fakeCustomerAccessor = new FakeCustomerAccessor();
            _customerManager = new CustomerManager(_fakeCustomerAccessor);
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Thomas Dupuy
        /// 
        /// This is the test for SelectAdoptionApplicationByStatus method.
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
        [TestMethod]
        public void TestRetrieveCustomerByCustomerName()
        {
            // arrange
            Customer selectedCustomers = null;
            const string customerEmail = "zaic@hotmail.com";
            int result = 0;

            // act
            selectedCustomers = _customerManager.RetrieveCustomerByCustomerEmail(customerEmail);
            if (selectedCustomers != null)
            {
                result = 1;
            }
            // assert
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/17/2020
        /// Approver: Steven Cardona
        /// 
        /// Test method to retrieve all Customers
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// </remarks>
        [TestMethod]
        public void TestRetrieveAllCustomers()
        {
            // arrange
            List<Customer> customers = null;
            int expectedCount = 3;

            // act
            customers = _customerManager.RetrieveAllActiveCustomers();

            // assert
            Assert.AreEqual(expectedCount, customers.Count);
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/26/2020
        /// Approver: Steven Cardona
        /// 
        /// Test method to authenticate a customer
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// </remarks>
        [TestMethod]
        public void TestCustomerManagerAuthentication()
        {
            //Arrange       
            Customer customer = new Customer();
            string email = "j.doe@RandoGuy.com";
            string password = "passwordtest";
            //Act
            customer = _customerManager.AuthenticateCustomer(email, password);
            //Assert    
            Assert.AreEqual(email, customer.Email);
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/3/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method hashes the given password for tests
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

            byte[] data;

            using (SHA256 sha256hash = SHA256.Create())
            {
                data = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(source));
            }
            var s = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }

            result = s.ToString().ToUpper();

            return result;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/5/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is a failing test for the UserAuthentication() method
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA  
        /// 
        /// </remarks>
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestCustomerManagerAuthenticationUserNameException()
        {
            //Arrange            
            string email = "j.blue@RandoGuy.com";
            Customer customer = new Customer();
            //Value you want PasswordHash() to return
            //Hashing Password
            string goodPasswordHash = hashPassword("passwordtest");
            //Act
            customer = _customerManager.AuthenticateCustomer(email, goodPasswordHash);
            //Assert not needed   
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Thomas Dupuy , 2020/02/21
        /// 
        /// This method for clean up after the test is finshed.
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
        [TestCleanup]
        public void TestTearDown()
        {
            _fakeCustomerAccessor = null;
        }
    }
}

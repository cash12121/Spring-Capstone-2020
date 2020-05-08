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
    ///  Creator: Ryan Morganti
    ///  Created: 2020/04/05
    ///  Approver: Matt Deaton
    ///  
    ///  Test Class for DonationManager
    /// </summary>
    [TestClass]
    public class DonationManagerTests
    {
        private IDonationAccessor _donationAccessor;
        private IDonationManager _donationManager;

        public DonationManagerTests()
        {
            _donationAccessor = new FakeDonationAccessor();
        }

        [TestInitialize]
        public void TestSetup()
        {
            _donationManager = new DonationManager(_donationAccessor);
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/04/05
        /// Approver: Matt Deaton
        /// 
        /// Test Method for validating good output when asking for 
        /// a list of the past year's donation history.
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestRetrieveAllDonationsFromPastYear()
        {
            // Arrange
            List<Donation> donations = new List<Donation>();

            // Act
            donations = _donationManager.RetrieveAllDonationsFromPastYear();

            // Assert
            Assert.AreEqual(donations.Count, 3);
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/04/16
        /// Approver: Derek Taylor
        /// 
        /// Test Method for Inserting a new recurring donation record
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestInsertNewRecurringDonation()
        {
            // Arrange
            int result = 0;
            RecurringDonationVM donation = new RecurringDonationVM()
            {
                RecurringDonationID = 1,
                UserName = "ryan"
            };

            // Act
            result = _donationAccessor.InsertNewRecurringDonation(donation);

            // Assert
            Assert.AreEqual(4, result);
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/04/29
        /// Approver: Derek Taylor
        /// 
        /// Test Method for altering the active status of a 
        /// recurring donation record
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestDeactivateRecurringDonation()
        {
            // Arrange
            int result;
            int id = 2;

            // Act
            result = _donationManager.DeleteRecurringDonation(id);

            // Assert
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/04/29
        /// Approver: Derek Taylor
        /// 
        /// Test Method for retrieving a recurring donation record
        /// based on its ID
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestSelectRecurringDonationByID()
        {
            // Arrange
            RecurringDonationVM donation;
            string expected = "Bobby";
            int id = 2;

            // Act
            donation = _donationAccessor.SelectRecurringDonationByID(id);

            // Assert
            Assert.AreEqual(expected, donation.UserName);
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/04/29
        /// Approver: Derek Taylor
        /// 
        /// Test Method for throwing an exception when a bad
        /// record ID is given.
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void TestSelectRecurringDonationByInvalidID()
        {
            // Arrange
            RecurringDonationVM donation;
            int id = 7;

            // Act
            donation = _donationAccessor.SelectRecurringDonationByID(id);
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/04/29
        /// Approver: Derek Taylor
        /// 
        /// Test Method for selecting a collection of recurring
        /// donation records based on their associated username.
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestSelectRecurringDonationsByUser()
        {
            // Arrange
            int expected = 1;
            string username = "Bobby";
            List<RecurringDonationVM> donations;

            // Act
            donations = _donationAccessor.SelectRecurringDonationsByUser(username);

            // Assert
            Assert.AreEqual(expected, donations.Count);
        }

        [TestCleanup]
        public void TestTearDown()
        {
            _donationManager = null;
            _donationAccessor = null;
        }
    }
}

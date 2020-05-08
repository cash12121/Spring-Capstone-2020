using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LogicLayerTests
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 3/19/2020
    /// CHECKED BY: 
    /// 
    /// This class is used to unit test the AdopterApplicationManager
    /// </summary>
    [TestClass]
    public class AdoptionApplicationManagerTests
    {
        private IAdoptionApplicationAccessor _fakeAdoptionApplicationAccessor;

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/5/2020
        /// Approver: Michael Thompson
        /// 
        /// constructor for this class
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public AdoptionApplicationManagerTests()
        {
            _fakeAdoptionApplicationAccessor = new FakeApplicationAccessor();
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/5/2020
        /// Approver: Micheal Thompson,
        /// 
        /// Tests
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAdoptionApplicationManagerRetrieveAdoptionApplicationByEmail()
        {
            // arrange
            var adoptionApplications = new List<ApplicationVM>();
            IAdoptionApplicationManager adoptionApplicationManager = new AdoptionApplicationManager(_fakeAdoptionApplicationAccessor);

            // act
            adoptionApplications = adoptionApplicationManager.RetrieveAdoptionApplicationsByEmailAndActive("Fake@fake.com");

            //assert
            Assert.AreEqual(1, adoptionApplications.Count);
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/5/2020
        /// Approver: Micheal Thompson,
        /// 
        /// Tests
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAdoptionApplicationManagerRetrieveAdoptionApplicationByID()
        {
            // arrange
            IAdoptionApplicationManager adoptionApplicationManager = new AdoptionApplicationManager(_fakeAdoptionApplicationAccessor);

            // act
            var adoptionApplication = adoptionApplicationManager.RetrieveAdoptionApplicationByID(000);

            //assert
            Assert.AreEqual(000, adoptionApplication.AdoptionApplicationID);
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/22/2020
        /// Approver: Michael Thompson
        /// 
        /// Tests
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAdoptionApplicationManagerDeactivateAdoptionApplicationByID()
        {
            // arrange
            IAdoptionApplicationManager adoptionApplicationManager = new AdoptionApplicationManager(_fakeAdoptionApplicationAccessor);

            // act
            bool result = adoptionApplicationManager.DeactivateAdoptionApplication(000);

            //assert
            Assert.AreEqual(result, true);
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/28/2020
        /// Approver: Michael Thompson
        /// 
        /// Tests
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAdoptionApplicationManagerAddAdoptionApplication()
        {
            // arrange
            IAdoptionApplicationManager adoptionApplicationManager = new AdoptionApplicationManager(_fakeAdoptionApplicationAccessor);
            var application = new Application
            {
                AdoptionApplicationID = 002,
                AnimalID = 000,
                RecievedDate = DateTime.Parse("11/12/1984"),
                CustomerEmail = "Fake2@fake.com",
                Status = "Fake",
                ApplicationActive = true
            };

            // act
            bool result = adoptionApplicationManager.AddAdoptionApplication(application);

            //assert
            Assert.AreEqual(result, true);
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/5/2020
        /// Approver: Micheal Thompson,
        /// 
        /// Tests
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAdoptionApplicationManagerRetrieveAdoptionApplicationsByActive()
        {
            // arrange
            var adoptionApplications = new List<ApplicationVM>();
            IAdoptionApplicationManager adoptionApplicationManager = new AdoptionApplicationManager(_fakeAdoptionApplicationAccessor);

            // act
            adoptionApplications = adoptionApplicationManager.RetrieveAdoptionApplicationsByActive(true);

            //assert
            Assert.AreEqual(3, adoptionApplications.Count);
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 5/4/2020
        /// Approver: 
        /// 
        /// Tests
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAdoptionApplicationManagerRetrieveAdoptionApplicationNamesByActive()
        {
            // arrange
            var adoptionApplications = new List<ApplicationNameVM>();
            IAdoptionApplicationManager adoptionApplicationManager = new AdoptionApplicationManager(_fakeAdoptionApplicationAccessor);

            // act
            adoptionApplications = adoptionApplicationManager.RetrieveAdoptionApplicationsByActiveWithName(true);

            //assert
            Assert.AreEqual(3, adoptionApplications.Count);
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/5/2020
        /// Approver: Micheal Thompson,
        /// 
        /// Tests
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAdoptionApplicationUpdateAdoptionApplication()
        {
            // arrange
            var oldApplication = new Application
            {
                AdoptionApplicationID = 000,
                AnimalID = 000,
                RecievedDate = DateTime.Parse("11/12/1984"),
                CustomerEmail = "Fake@fake.com",
                Status = "Fake",
                ApplicationActive = true
            };

            var newApplication = new Application
            {
                AdoptionApplicationID = 000,
                AnimalID = 000,
                RecievedDate = DateTime.Parse("11/12/1984"),
                CustomerEmail = "Fake@fake.com",
                Status = "Next Fake",
                ApplicationActive = true
            };

            IAdoptionApplicationManager adoptionApplicationManager = new AdoptionApplicationManager(_fakeAdoptionApplicationAccessor);

            // act
            var result = adoptionApplicationManager.UpdateAdoptionApplication(oldApplication, newApplication);

            //assert
            Assert.IsTrue(result);
        }
    }
}

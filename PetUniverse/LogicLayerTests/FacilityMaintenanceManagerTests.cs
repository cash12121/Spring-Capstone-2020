using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 2/6/2020
    /// Approver: Chuck Baxter, 2/7/2020
    /// Approver: Daulton Schilling, 2/7/2020
    /// 
    /// Test Class to test the logic layer class
    /// </summary>
    [TestClass]
    public class FacilityMaintenanceManagerTests
    {
        private IFacilityMaintenanceAccessor _fakeFacilityMaintenanceAccessor;
        private FacilityMaintenanceManager _facilityMaintenanceManager;

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/6/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// Method to set up the objects for the test
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestInitialize]
        public void TestSetUp()
        {
            _fakeFacilityMaintenanceAccessor = new FakeFacilityMaintenanceAccessor();
            _facilityMaintenanceManager = new FacilityMaintenanceManager(_fakeFacilityMaintenanceAccessor);

        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/6/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// Method to test the InsertFacilityMaintenanceRecord in the Logic layer
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestInsertFacilityMaintenanceRecord()
        {
            // arrange
            FacilityMaintenance facilityMaintenance = new FacilityMaintenance()
            {
                FacilityMaintenanceID = 1000000,
                UserID = 1000000,
                MaintenanceName = "Window",
                MaintenanceInterval = "5 hours",
                MaintenanceDescription = "Fix cracked window"
            };
            bool result = false;

            // act
            result = _facilityMaintenanceManager.AddFacilityMaintenanceRecord(facilityMaintenance);

            // assert
            Assert.IsTrue(result);

        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/13/2020
        /// Approver: Ethan Murphy, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Method to test the RetrieveFacilityMaintenanceByFacilityMaintenanceID in the Logic layer
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveFacilityMaintenanceByFacilityMaintenanceID()
        {
            // arrange
            FacilityMaintenance facilityMaintenance = new FacilityMaintenance()
            {
                FacilityMaintenanceID = 1000000,
                UserID = 1000000,
                MaintenanceName = "Window",
                MaintenanceInterval = "5 hours",
                MaintenanceDescription = "Fix cracked window"
            };
            FacilityMaintenance result = new FacilityMaintenance();

            // act
            result = _facilityMaintenanceManager.RetrieveFacilityMaintenanceByFacilityMaintenanceID(facilityMaintenance.FacilityMaintenanceID, true);

            // assert
            Assert.AreEqual(facilityMaintenance.FacilityMaintenanceID, result.FacilityMaintenanceID);

        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/13/2020
        /// Approver: Ethan Murphy, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Method to test the RetrieveFacilityMaintenanceByUserID in the Logic layer
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveFacilityMaintenanceByUserID()
        {
            // arrange
            FacilityMaintenance facilityMaintenance = new FacilityMaintenance()
            {
                FacilityMaintenanceID = 1000000,
                UserID = 1000000,
                MaintenanceName = "Window",
                MaintenanceInterval = "5 hours",
                MaintenanceDescription = "Fix cracked window"
            };
            List<FacilityMaintenance> result = new List<FacilityMaintenance>();

            // act
            result = _facilityMaintenanceManager.RetrieveFacilityMaintenanceByUserID(facilityMaintenance.UserID, true);


            // assert
            Assert.AreEqual(1, result.Count);

        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/13/2020
        /// Approver: Ethan Murphy, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Method to test the RetrieveFacilityMaintenanceFacilityMaintenanceName in the Logic layer
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveFacilityMaintenanceFacilityMaintenanceName()
        {
            // arrange
            FacilityMaintenance facilityMaintenance = new FacilityMaintenance()
            {
                FacilityMaintenanceID = 1000000,
                UserID = 1000000,
                MaintenanceName = "Window",
                MaintenanceInterval = "5 hours",
                MaintenanceDescription = "Fix cracked window"
            };
            List<FacilityMaintenance> result = new List<FacilityMaintenance>();

            // act
            result = _facilityMaintenanceManager.RetrieveFacilityMaintenanceFacilityMaintenanceName(facilityMaintenance.MaintenanceName, true);

            // assert
            Assert.AreEqual(1, result.Count);

        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/13/2020
        /// Approver: Ethan Murphy, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Method to test the RetrieveFacilityMaintenanceFacilityMaintenanceName in the Logic layer
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveAllFacilityMaintenance()
        {
            // arrange
            FacilityMaintenance facilityMaintenance = new FacilityMaintenance()
            {
                FacilityMaintenanceID = 1000000,
                UserID = 1000000,
                MaintenanceName = "Window",
                MaintenanceInterval = "5 hours",
                MaintenanceDescription = "Fix cracked window"
            };
            List<FacilityMaintenance> result = new List<FacilityMaintenance>();

            // act
            result = _facilityMaintenanceManager.RetrieveAllFacilityMaintenance(true);

            // assert
            Assert.AreEqual(2, result.Count);

        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/14/2020
        /// Approver: Ethan Murphy, 2/14/2020
        /// Approver: Daulton Schilling, 2/21/2020
        /// 
        /// Method to test the EditFacilityMaintenance in the Logic layer
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestEditFacilityMaintenance()
        {
            // arrange
            FacilityMaintenance oldFacilityMaintenance = new FacilityMaintenance()
            {
                FacilityMaintenanceID = 1000000,
                UserID = 1000000,
                MaintenanceName = "Window",
                MaintenanceInterval = "5 hours",
                MaintenanceDescription = "Fix cracked window"
            };
            FacilityMaintenance newFacilityMaintenance = new FacilityMaintenance()
            {
                FacilityMaintenanceID = 1000000,
                UserID = 1000001,
                MaintenanceName = "Door",
                MaintenanceInterval = "6 hours",
                MaintenanceDescription = "Fix cracked window"
            };
            bool result = false;

            // act
            result = _facilityMaintenanceManager.EditFacilityMaintenance(oldFacilityMaintenance, newFacilityMaintenance);

            // assert
            Assert.IsTrue(result);

        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/14/2020
        /// Approver: Ethan Murphy 3/6/2020
        /// Approver: 
        /// 
        /// Method to test the DeactivateFacilityMaintenance in the Logic layer
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestDeactivateFacilityMaintenance()
        {
            // arrange
            FacilityMaintenance facilityMaintenance = new FacilityMaintenance()
            {
                FacilityMaintenanceID = 1000000,
                UserID = 1000000,
                MaintenanceName = "Window",
                MaintenanceInterval = "5 hours",
                MaintenanceDescription = "Fix cracked window"
            };

            bool result = false;

            // act
            result = _facilityMaintenanceManager.DeactivateFacilityMaintenance(facilityMaintenance.FacilityMaintenanceID);

            // assert
            Assert.IsFalse(result);

        }


        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/13/2020
        /// Approver: Ethan Murphy, 2/14/2020
        /// Approver: Chuck Baxter, 2/14/2020
        /// 
        /// Method to tear down the test and clear memory
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestCleanup]
        public void TestTearDown()
        {
            _fakeFacilityMaintenanceAccessor = null;
            _facilityMaintenanceManager = null;
        }
    }
}

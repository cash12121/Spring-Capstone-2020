using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 2/28/2020
    /// Approver: Ethan Murphy 3/6/2020
    /// Approver: 
    /// 
    /// Test Class to test the logic layer facility inspection class class
    /// </summary>
    [TestClass]
    public class FacilityInspectionManagerTests
    {
        private IFacilityInspectionAccessor _fakeFacilityInspectionAccessor;
        private FacilityInspectionManager _facilityInspectionManager;

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/28/2020
        /// Approver: Ethan Murphy 3/6/2020
        /// Approver: 
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
            _fakeFacilityInspectionAccessor = new FakeFacilityInspectionAccessor();
            _facilityInspectionManager = new FacilityInspectionManager(_fakeFacilityInspectionAccessor);
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/28/2020
        /// Approver: Ethan Murphy 3/6/2020
        /// Approver: 
        /// 
        /// Method to test the InsertFacilityInspectionRecord in the Logic layer
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestInsertFacilityInspectionRecord()
        {
            // arrange
            FacilityInspection facilityInspection = new FacilityInspection()
            {
                FacilityInspectionID = 1000000,
                UserID = 100000,
                InspectorName = "Bob",
                InspectionDate = new DateTime(2018, 7, 10, 7, 10, 24),
                InspectionDescription = "Inspect cracked window",
                InspectionCompleted = false
            };
            bool result = false;

            // act
            result = _facilityInspectionManager.AddFacilityInspectionRecord(facilityInspection);

            // assert
            Assert.IsTrue(result);

        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/11/2020
        /// Approver: Ethan Murphy 3/13/2020
        /// Approver: 
        /// 
        /// Method to test the RetrieveAllFacilityInspection in the Logic layer
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveAllFacilityInspection()
        {
            // arrange

            bool inspectionComplete = false;

            // act
            List<FacilityInspection> inspections = _facilityInspectionManager.RetrieveAllFacilityInspection(inspectionComplete);

            int count = inspections.Count;

            // assert
            Assert.AreEqual(3, count);

        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/11/2020
        /// Approver: Ethan Murphy 3/13/2020
        /// Approver: 
        /// 
        /// Method to test the RetrieveFacilityInspectionByID in the Logic layer
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveFacilityInspectionByID()
        {
            // arrange

            bool inspectionComplete = false;
            int facilityInspectionID = 1000000;

            // act
            List<FacilityInspection> inspections = _facilityInspectionManager.RetrieveFacilityInspectionByID(facilityInspectionID, inspectionComplete);

            int count = inspections.Count;

            // assert
            Assert.AreEqual(1, count);

        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/11/2020
        /// Approver: Ethan Murphy 3/13/2020
        /// Approver: 
        /// 
        /// Method to test the RetrieveFacilityInspectionByUserID in the Logic layer
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveFacilityInspectionByUserID()
        {
            // arrange

            bool inspectionComplete = false;
            int userID = 100000;

            // act
            List<FacilityInspection> inspections = _facilityInspectionManager.RetrieveFacilityInspectionByUserID(userID, inspectionComplete);

            int count = inspections.Count;

            // assert
            Assert.AreEqual(2, count);

        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/11/2020
        /// Approver: Ethan Murphy 3/13/2020
        /// Approver: 
        /// 
        /// Method to test the RetrieveFacilityInspectionByInspectorName in the Logic layer
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveFacilityInspectionByInspectorName()
        {
            // arrange

            bool inspectionComplete = false;
            string inspectorName = "Bob";

            // act
            List<FacilityInspection> inspections = _facilityInspectionManager.RetrieveFacilityInspectionByInspectorName(inspectorName, inspectionComplete);

            int count = inspections.Count;

            // assert
            Assert.AreEqual(3, count);

        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/13/2020
        /// Approver: Chuck Baxter, 3/18/2020
        /// 
        /// Method to test the EditFacilityInspection in the Logic layer
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestEditFacilityInspection()
        {
            // arrange
            FacilityInspection oldFacilityInspection = new FacilityInspection()
            {
                FacilityInspectionID = 1000000,
                UserID = 100000,
                InspectorName = "Bob",
                InspectionDate = new DateTime(2018, 7, 10, 7, 10, 24),
                InspectionDescription = "Inspect cracked window",
                InspectionCompleted = false
            };
            FacilityInspection newFacilityInspection = new FacilityInspection()
            {
                FacilityInspectionID = 1000000,
                UserID = 100000,
                InspectorName = "Jim",
                InspectionDate = new DateTime(2018, 7, 10, 7, 10, 24),
                InspectionDescription = "Inspect cracked window",
                InspectionCompleted = false
            };
            bool result = false;

            // act
            result = _facilityInspectionManager.EditFacilityInspection(oldFacilityInspection, newFacilityInspection);

            // assert
            Assert.IsTrue(result);

        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/28/2020
        /// Approver: Ethan Murphy 3/6/2020
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
            _fakeFacilityInspectionAccessor = null;
            _facilityInspectionManager = null;
        }
    }
}

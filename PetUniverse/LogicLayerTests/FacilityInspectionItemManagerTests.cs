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
    /// Created: 4/2/2020
    /// Approver: Ethan Murphy 4/3/2020
    /// Approver: 
    /// 
    /// Test Class to test the logic layer facility inspection item manager class 
    /// </summary>
    [TestClass]
    public class FacilityInspectionItemManagerTests
    {
        private IFacilityInspectionItemAccessor _fakeFacilityInspectionItemAccessor;
        private FacilityInspectionItemManager _facilityInspectionItemManager;

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/2/2020
        /// Approver: Ethan Murphy 4/3/2020
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
            _fakeFacilityInspectionItemAccessor = new FakeFacilityInspectionItemAccessor();
            _facilityInspectionItemManager = new FacilityInspectionItemManager(_fakeFacilityInspectionItemAccessor);
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/2/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// Approver: 
        /// 
        /// Method to test the InsertFacilityInspectionItemRecord in the Logic layer
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestAddFacilityInspectionItemRecord()
        {
            // arrange
            FacilityInspectionItem facilityInspectionItem = new FacilityInspectionItem()
            {
                FacilityInspectionItemID = 1000000,
                ItemName = "Pen",
                UserID = 100000,
                FacilityInpectionID = 1000000,
                ItemDescription = "To fill out reports"
            };
            bool result = false;

            // act
            result = _facilityInspectionItemManager.AddFacilityInspectionItemRecord(facilityInspectionItem);

            // assert
            Assert.IsTrue(result);

        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/2/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// Approver: 
        /// 
        /// Method to test the RetrieveAllFacilityInspectionItems in the Logic layer
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveAllFacilityItemInspectionItems()
        {
            // arrange

            // act
            List<FacilityInspectionItem> inspectionItems = _facilityInspectionItemManager.RetrieveAllFacilityInspectionItems();
            int count = inspectionItems.Count;

            // assert
            Assert.AreEqual(3, count);
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/2/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// Approver: 
        /// 
        /// Method to test the RetrieveFacilityInspectionItemByID in the Logic layer
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveFacilityInspectionItemByID()
        {
            // arrange

            int facilityInspectionItemID = 1000000;

            // act
            List<FacilityInspectionItem> inspectionItems = _facilityInspectionItemManager.RetrieveFacilityInspectionItemByID(facilityInspectionItemID);

            int count = inspectionItems.Count;

            // assert
            Assert.AreEqual(1, count);

        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/2/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// Approver: 
        /// 
        /// Method to test the RetrieveFacilityInspectionItemByUserID in the Logic layer
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveFacilityInspectionItemByUserID()
        {
            // arrange

            int userID = 100000;

            // act
            List<FacilityInspectionItem> inspectionItems = _facilityInspectionItemManager.RetrieveFacilityInspectionItemByUserID(userID);

            int count = inspectionItems.Count;

            // assert
            Assert.AreEqual(1, count);

        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/2/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// Approver: 
        /// 
        /// Method to test the RetrieveFacilityInspectionItemByFacilityInspectionID in the Logic layer
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveFacilityInspectionItemByFacilityInspectionID()
        {
            // arrange

            int facilityInspectionID = 1000001;

            // act
            List<FacilityInspectionItem> inspectionItems = _facilityInspectionItemManager.RetrieveFacilityInspectionItemByfacilityInspectionID(facilityInspectionID);

            int count = inspectionItems.Count;

            // assert
            Assert.AreEqual(2, count);

        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/2/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// Approver: 
        /// 
        /// Method to test the RetrieveFacilityInspectionItemByItemName in the Logic layer
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestRetrieveFacilityInspectionItemByItemName()
        {
            // arrange

            string itemName = "Pen";

            // act
            List<FacilityInspectionItem> inspectionItems = _facilityInspectionItemManager.RetrieveFacilityInspectionByItemName(itemName);

            int count = inspectionItems.Count;

            // assert
            Assert.AreEqual(3, count);

        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/2/2020
        /// Approver: Ethan Murphy 4/3/2020
        /// 
        /// Method to test the EditFacilityInspectionItem in the Logic layer
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestEditFacilityInspectionItem()
        {
            // arrange
            FacilityInspectionItem oldFacilityInspectionItem = new FacilityInspectionItem()
            {
                FacilityInspectionItemID = 1000000,
                ItemName = "Pen",
                UserID = 100000,
                FacilityInpectionID = 1000000,
                ItemDescription = "To fill out reports"
            };
            FacilityInspectionItem newFacilityInspectionItem = new FacilityInspectionItem()
            {
                FacilityInspectionItemID = 1000000,
                ItemName = "Board",
                UserID = 100001,
                FacilityInpectionID = 1000000,
                ItemDescription = "To fill out reports"
            };
            bool result = false;

            // act
            result = _facilityInspectionItemManager.EditFacilityInspectionItem(oldFacilityInspectionItem, newFacilityInspectionItem);

            // assert
            Assert.IsTrue(result);

        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 4/2/2020
        /// Approver: Ethan Murphy 4/3/2020
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
            _fakeFacilityInspectionItemAccessor = null;
            _facilityInspectionItemManager = null;
        }
    }
}

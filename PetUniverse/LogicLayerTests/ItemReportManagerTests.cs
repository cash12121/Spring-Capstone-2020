using DataAccessFakes;
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
    /// Creator: Brandyn T. Coverdill
    /// Created: 2020/04/07
    /// Approver: Dalton Reierson
    /// Approver:  Jesse Tomash
    ///
    /// Test class for testing Item Report Methods. (Items from Shelf.)
    /// </summary>
    [TestClass]
    public class ItemReportManagerTests
    {

        private ItemReport _itemReport;
        private ItemReportManager _itemReportManager;
        private FakeItemReportAccessor _fakeItemReportAccessor;

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/07
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Method to set up the tests.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestInitialize]
        public void TestSetup()
        {
            _fakeItemReportAccessor = new FakeItemReportAccessor();
            _itemReportManager = new ItemReportManager(_fakeItemReportAccessor);
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/07
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Tests adding a new Item Report.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestCreateNewItemReport()
        {
            // arrange
            ItemReport itemReport = new ItemReport()
            {
                Report = "Report Field: Test Create New Item Report",
                ItemID = 10000,
                ItemName = "Item A",
                Quantity = 10
            };
            bool created = false;
            bool expectedResult = true;

            // act
            created = _itemReportManager.createNewItemReport(itemReport);

            // assert
            Assert.AreEqual(expectedResult, created);
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 4/30/2020
        /// Approver: Steven Cardona        
        ///
        /// Tests failure of adding item report
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestCreateNewItemReportException()
        {
            // arrange
            ItemReport report = new ItemReport()
            {
                Report = "Report Field: Test Create New Item Report",
                ItemID = 0000,
                ItemName = "Item A",
                Quantity = 10
            };

            bool created = false;            

            // act
            created = _itemReportManager.createNewItemReport(report);
        }


        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/07
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Tests listing all Item Reports.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestListItemReport()
        {
            // Arrange
            int expectedResult = 3;
            List<ItemReport> itemReports = new List<ItemReport>();

            // Act
            itemReports = _itemReportManager.retrieveItemReports();

            // Assert
            Assert.AreEqual(expectedResult, itemReports.Count);
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/07
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Tests Updating an Item Report.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestUpdateItemReport()
        {
            // Arrange
            ItemReport oldItemReport = new ItemReport()
            {
                ItemID = 1000,
                ItemName = "Item 1",
                ItemQuantity = 20,
                Description = "Item Report 1"
            };

            ItemReport newItemReport = new ItemReport()
            {
                ItemID = 1000,
                ItemName = "Item 2",
                ItemQuantity = 30,
                Report = "Item Report 2"
            };

            // Act
            bool result = false;
            result = _itemReportManager.editItemReports(oldItemReport.ItemQuantity, oldItemReport.Report, newItemReport.ItemQuantity, newItemReport.Report, oldItemReport.ItemID);

            // Assert
            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/07
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Method to clean up for the next test run.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestCleanup]
        public void TestTearDown()
        {
            _itemReport = null;
            _fakeItemReportAccessor = null;
            _itemReportManager = null;
        }
    }
}

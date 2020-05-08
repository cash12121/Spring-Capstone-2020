using DataTransferObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessFakes;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Dalton Reierson
    /// Created: 2020/04/23
    /// Approver: Jesse Tomash
    /// Approver: 
    ///
    /// Tests for ReceivingRecordManager
    /// </summary>
    ///
    /// <remarks>
    /// Updated By: 
    /// Updated: 
    /// Update:
    /// </remarks>
    [TestClass]
    class ReceivingRecordManagerTests
    {
        private ReceivingRecordManager _receivingRecordManager = new ReceivingRecordManager();
        private FakeReceivingRecordAccessor _fakeReceivingRecordAccessor = new FakeReceivingRecordAccessor();

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// Set up for tests
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
            _fakeReceivingRecordAccessor = new FakeReceivingRecordAccessor();
            _receivingRecordManager = new ReceivingRecordManager(_fakeReceivingRecordAccessor);
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// Selects all receivingRecords
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void SelectAllReceivingRecords()
        {
            // Arrange
            List<ReceivingRecord> resultList = new List<ReceivingRecord>();

            List<ReceivingRecord> receivingRecordList = new List<ReceivingRecord>()
            {
                new ReceivingRecord
                {
                    ReceivingRecordID = 100000,
                    OrderID = 100000,
                    ShipperID = "100000",
                    ReceivingOrderDate = DateTime.Now
                 },

                new ReceivingRecord
                {
                    ReceivingRecordID = 100000,
                    OrderID = 100000,
                    ShipperID = "100000",
                    ReceivingOrderDate = DateTime.Now
                },

                new ReceivingRecord
                {
                    ReceivingRecordID = 100000,
                    OrderID = 100000,
                    ShipperID = "100000",
                    ReceivingOrderDate = DateTime.Now
                }
            };

            // Act
            resultList = _fakeReceivingRecordAccessor.SelectAllReceivingRecords();

            // Assert
            Assert.AreEqual(receivingRecordList, resultList);
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// Select receivingRecord with matching orderID
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void SelectReceivingRecordByOrderID()
        {
            // Arrange
            ReceivingRecord receivingRecord = new ReceivingRecord();
            ReceivingRecord result = new ReceivingRecord();

            receivingRecord.OrderID = 100000;
            receivingRecord.ShipperID = "100000";
            receivingRecord.ReceivingRecordID = 100000;
            receivingRecord.ReceivingOrderDate = DateTime.Now;

            // Act
            result = _fakeReceivingRecordAccessor.SelectReceivingRecordbyOrderID(100000);

            // Assert
            Assert.AreEqual(receivingRecord, result);
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/24
        /// Approver: Jesse Tomash
        /// Approver: 
        ///
        /// Test tear down
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
            _fakeReceivingRecordAccessor = null;
            _receivingRecordManager = null;
        }


    }
}

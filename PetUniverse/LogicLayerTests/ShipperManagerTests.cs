using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using DataAccessFakes;
using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Dalton Reierson
    /// Created: 2020/04/29
    /// Approver: Brandyn T. Coverdill
    /// Approver: 
    ///
    /// tests for shipper manager
    /// </summary>
    ///
    /// <remarks>
    /// Updated By: 
    /// Updated: 
    /// Update:
    /// </remarks>
    [TestClass]
    public class ShipperManagerTests
    {
        private Shipper _shipper;
        private ShipperManager _shipperManager;
        private FakeShipperAccessor _fakeShipperAccessor;

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        ///
        /// test setup
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
            _fakeShipperAccessor = new FakeShipperAccessor();
            _shipperManager = new ShipperManager(_fakeShipperAccessor);
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        ///
        /// test to create shipper
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestCreateShipper()
        {
            // Arrange
            bool expectedResult = true;
            bool result = false;

            Shipper shipper = new Shipper()
            {
                ShipperID = "100000",
                Complaint = "no"
            };

            // Act
            result = _shipperManager.createShipper(shipper);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        ///
        /// test to select all shippers
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestReadShipper()
        {
            // Arrange
            List<Shipper> shippers = new List<Shipper>();
            int expectedResult = 2;
            int result = 0;

            // Act
            shippers = _shipperManager.selectAllShippers();
            result = shippers.Count;

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        ///
        /// test to update shippers
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestUpdateShippers()
        {
            // Arrange
            bool expectedResult = true;
            bool result = false;

            Shipper shipper = new Shipper()
            {
                ShipperID = "100000",
                Complaint = "no"
            };

            Shipper newShipper = new Shipper()
            {
                ShipperID = "100001",
                Complaint = "yes"
            };

            // Act
            result = _shipperManager.updateShipper(shipper, newShipper);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        ///
        /// test to delete shippers
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestDeleteShipper()
        {
            // Arrange
            bool expectedResult = true;
            bool result = false;

            Shipper shipper = new Shipper();

            shipper.ShipperID = "100000";
            shipper.Complaint = "no"; ;

            // Act
            result = _shipperManager.deleteShipper(shipper);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/29
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        ///
        /// test  cleanup
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
            _shipper = null;
            _shipperManager = null;
            _fakeShipperAccessor = null;
        }
    }
}

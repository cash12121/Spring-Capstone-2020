using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using System.Collections.Generic;
using LogicLayerInterfaces;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 2020/04/16
	/// Approver: Kaleb Bachert
	/// Approver: Jesse Tomash
    ///
    /// Test class for Vendors.
    /// </summary>
    [TestClass]
    public class VendorManagerTests
    {

        private Vendor _vendor;
        private VendorManager _vendorManager;
        private FakeVendorAccessor _fakeVendorAccessor;


        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Sets up for the tests to run.
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
            _fakeVendorAccessor = new FakeVendorAccessor();
            _vendorManager = new VendorManager(_fakeVendorAccessor);
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Tests creating a new vendor.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>

        [TestMethod]
        public void TestCreateNewVendor()
        {
            // arrange
            Vendor vendor = new Vendor()
            {
                VendorID = 10,
                VendorAddress = "Address",
                VendorCity = "City",
                VendorEmail = "Email",
                VendorName = "Vendor",
                VendorPhone = "Phone",
                VendorState = "IA",
                VendorZip = "Zip"
            };
            bool created = false;
            bool expectedResult = true;

            // act
            created = _vendorManager.createNewVendor(vendor);

            // assert
            Assert.AreEqual(expectedResult, created);
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Tests getting a list of Vendors.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestListVendor()
        {
            // Arrange
            int expectedResult = 2;
            List<Vendor> vendors = new List<Vendor>();

            // Act
            vendors = _vendorManager.retrieveVendors();

            // Assert
            Assert.AreEqual(expectedResult, vendors.Count);
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        ///
        /// Test for updating a vendor.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestUpdateVendor()
        {
            // Arrange
            Vendor oldVendor = new Vendor()
            {
                VendorID = 9,
                VendorAddress = "Old Address",
                VendorCity = "Old City",
                VendorEmail = "Old Email",
                VendorName = "Old Vendor",
                VendorPhone = "Old Phone",
                VendorState = "OD",
                VendorZip = "Old"
            };

            Vendor newVendor = new Vendor()
            {
                VendorID = 10,
                VendorAddress = "new Address",
                VendorCity = "new City",
                VendorEmail = "new Email",
                VendorName = "new Vendor",
                VendorPhone = "new Phone",
                VendorState = "NW",
                VendorZip = "New"
            };

            // Act
            bool result = false;
            result = _vendorManager.editVendor(oldVendor.VendorID, oldVendor.VendorName, oldVendor.VendorAddress,
                oldVendor.VendorPhone, oldVendor.VendorEmail, oldVendor.VendorState, oldVendor.VendorCity,
                oldVendor.VendorZip, newVendor.VendorName, newVendor.VendorAddress, newVendor.VendorPhone,
                newVendor.VendorEmail, newVendor.VendorState, newVendor.VendorCity, newVendor.VendorZip);

            // Assert
            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/04/16
        /// Approver: Kaleb Bachert
        /// Approver: Jesse Tomash
        /// Tears down the test for the next tests to run.
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
            _vendor = null;
            _fakeVendorAccessor = null;
            _vendorManager = null;
        }
    }
}

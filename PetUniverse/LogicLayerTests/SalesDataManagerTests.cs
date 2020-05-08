using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LogicLayerTests
{
    [TestClass]
    public class SalesDataManagerTests
    {
        private ISalesDataAccessor _salesDataAccessor;

        /// <summary>
        /// Creator: Cash Carlson
        /// Created: 2020/03/19
        /// Approver: Rob Holmes
        ///
        /// Passing in SalesDataFakes at the start of every test
        /// </summary>
        /// <remarks>
        /// Updater: Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        [TestInitialize]
        public void InventoryItemsTestSetup()
        {
            _salesDataAccessor = new FakeSalesData();
        }

		/// <summary>
		/// Creator: Cash Carlson
		/// Created: 2020/03/19
		/// Approver: Rob Holmes
		///
		/// A Test for testing on making sure that the sales data is accurate and fits the method
		/// </summary>
		/// <remarks>
		/// Updater: Name
		/// Updated: yyyy/mm/dd 
		/// Update: ()
		/// </summary>
		[TestMethod]
		public void TestSalesDataManagerRetrieveAllTotalSalesData()
		{
			// arrange
			List<SalesDataVM> salesData;
			ISalesDataManager salesDataManager = new SalesDataManager(_salesDataAccessor);

            // act
            salesData = salesDataManager.RetrieveAllTotalSalesData();

            //assert
            Assert.AreEqual(1, salesData.Count);
        }

		/// <summary>
		/// Creator: Cash Carlson
		/// Created: 2020/04/25
		/// Approver: Rasha Mohammed
		///
		/// Test for retreing sales that is connected to an employee
		/// </summary>
		/// <remarks>
		/// Updater: Name
		/// Updated: yyyy/mm/dd 
		/// Update: ()
		/// </summary>
		[TestMethod]
		public void TestSalesDataManagerRetrieveAllEmployeeSalesData()
		{
			// arrange
			int employeeID = 6547898;
			List<SalesDataVM> salesData;
			ISalesDataManager salesDataManager = new SalesDataManager(_salesDataAccessor);

			// act
			salesData = salesDataManager.RetrieveAllEmployeeSalesData(employeeID);

			//assert
			Assert.AreEqual(1, salesData.Count);
		}

		/// <summary>
		/// Creator: Cash Carlson
		/// Created: 2020/03/19
		/// Approver: Rob Holmes
		///
		/// Tear down method that resets the accessor class
		/// </summary>
		/// <remarks>
		/// Updater: Name
		/// Updated: yyyy/mm/dd 
		/// Update: ()
		/// </remarks>
		[TestCleanup]
		public void TestTearDown()
		{
			_salesDataAccessor = null;
		}
	}
}

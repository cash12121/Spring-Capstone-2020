using DataAccessFakes;
using DataAccessInterfaces;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Austin Gee
    /// Created: 3/12/2020
    /// Approver: Thomas Dupuy
    /// 
    /// Test method for the Status Manager class
    /// </summary>
    [TestClass]
    public class StatusManagerTests
    {
        private IStatusAccessor _fakeStatusAccessor;

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/12/2020
        /// Approver: Thomas Dupuy
        /// 
        /// regular constructor for this class
        /// </summary>
        /// <remarks>
        /// Updated BY: N/A
        /// Updated N/A
        /// Update: N/A
        /// </remarks>
        public StatusManagerTests()
        {
            _fakeStatusAccessor = new FakeStatusAccessor();
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/12/2020
        /// Approver: Thomas Dupuy
        /// 
        /// Tests the Add status method of the Status Manager class
        /// </summary>
        /// <remarks>
        /// Updated BY: N/A
        /// Updated N/A
        /// Update: N/A
        /// </remarks>
        [TestMethod]
        public void TestStatusManagerAddStatus()
        {
            //arrange
            bool result = false;
            IStatusManager statusManager = new StatusManager(_fakeStatusAccessor);

            // act
            result = statusManager.AddStatus("TestAddStatus");

            // assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/12/2020
        /// Approver: Thomas Dupuy
        /// 
        /// Tests the Add status method of the Status Manager class
        /// </summary>
        /// <remarks>
        /// Updated BY: N/A
        /// Updated N/A
        /// Update: N/A
        /// </remarks>
        [TestMethod]
        public void TestStatusRetrieveAllStatuses()
        {
            // arrrange
            List<string> statuses = new List<string>();
            IStatusManager statusManager = new StatusManager(_fakeStatusAccessor);

            // act
            statuses = statusManager.RetriveAllStatuses();

            // assert
            Assert.AreEqual(4, statuses.Count);
        }
    }
}

using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2/5/2020
    /// Approver: Austin Gee, 2/7/2020
    /// This Class for testing all public methods int the HomeInspectorManager.
    /// </summary>
    /// 
    [TestClass]
    public class HomeInspectorManagerTest
    {
        private IHomeInspectorAccessor _fakeAdoptionApplicationAccessor;
        private HomeInspectorManager _homeInspectorManager;

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2/5/2020
        /// Approver: Austin Gee, 2/7/2020
        /// This is the Setup for tests.
        /// </summary>
        /// <remarks>
        /// Updater: Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        
        [TestInitialize]
        public void TestSetup()
        {
            _fakeAdoptionApplicationAccessor = new FakeAdoptionApplicationAccessor();
            _homeInspectorManager = new HomeInspectorManager(_fakeAdoptionApplicationAccessor);
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2/5/2020
        /// Approver: Austin Gee, 2/7/2020
        /// This is the test for Select Adoption Application By Status method.
        /// </summary>
        /// <remarks>
        /// Updater: Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        
        [TestMethod]
        public void TestSelectAdoptionApplicationByStatus()
        {
            // Arrange
            List<AdoptionApplication> SelectAdoptionApplicationsByStatus;
            // Act
            SelectAdoptionApplicationsByStatus = _homeInspectorManager.SelectAdoptionApplicationByStatus();
            //Assert
            Assert.AreEqual(2, SelectAdoptionApplicationsByStatus.Count);
        }
    }
}
